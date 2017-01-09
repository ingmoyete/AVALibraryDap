using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace DataLibrary 
{
    public class Helper : IDisposable
    {

        // Internal 
    protected string connString = WebConfigurationManager.AppSettings["dbConnection"].ToString();
    protected SqlConnection conn   = null;
    protected SqlTransaction trans = null;
    protected bool disposed        = false;

    /// <summary>
    /// Sets or returns the connection string use by all instances of this class.
    /// </summary>
    public static string ConnectionString { get; set; }

    /// <summary>
    /// Returns the current SqlTransaction object or null if no transaction     
    /// is in effect.
    /// </summary>
    public SqlTransaction Transaction { get { return trans; } }

    /// <summary>
    /// Constructor using global connection string.
    /// </summary>
    public Helper()
    {
        ConnectionString = connString;
        Connect();
    }

    /// <summary>
    /// Constructure using connection string override
    /// </summary>
    /// <param name="connString">Connection string for this instance</param>
    public Helper(string _connString)
    {
        connString = _connString;
        Connect();
    }

    // Creates a SqlConnection using the current connection string
    protected void Connect()
    {
        conn = new SqlConnection(connString);
        conn.Open();
    }

    /// <summary>
    /// Constructs a SqlCommand with the given parameters. This method is normally called
    /// from the other methods and not called directly. But here it is if you need access
    /// to it.
    /// </summary>
    /// <param name="_storeProcedure">SQL query or stored procedure name</param>
    /// <param name="type">Type of SQL command</param>
    /// <param name="args">Query arguments. Arguments should be in pairs where one is the
    /// name of the parameter and the second is the value. The very last argument can
    /// optionally be a SqlParameter object for specifying a custom argument type</param>
    /// <returns></returns>
    public SqlCommand CreateCommand(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        SqlCommand cmd = new SqlCommand(_storeProcedure, conn);

        // Associate with current transaction, if any
        if (trans != null)
            cmd.Transaction = trans;

        // Set command type
        cmd.CommandType = CommandType.StoredProcedure;
        
        // Assign parameters
        if (_sqlParameter != null)
            {
                cmd.Parameters.Clear();

                foreach (SqlParameter singleParameter in _sqlParameter)
                {
                    cmd.Parameters.AddWithValue(singleParameter.ParameterName, singleParameter.Value);
                }
            }
        if (_output != null)
	    {
		    _output.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_output);
	    }

        return cmd;
    }

    #region Exec Members

    /// <summary>
    /// Executes a query that returns no results
    /// </summary>
    /// <param name="qry">Query text</param>
    /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
    /// <returns>The number of rows affected</returns>
    public int ExecNonQuery(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        using (SqlCommand cmd = CreateCommand(_storeProcedure, _sqlParameter, _output))
        {
            int ret;

            // Execute the query
            ret = cmd.ExecuteNonQuery();

            // If there is an output parameter, and there is more than one row affected, then it gets the index
            if (_output != null && ret > 0)
            {
                ret = Convert.ToInt32(cmd.Parameters[_output.ParameterName].Value);
            }
            else
            {
                ret = -1;
            }

            // Return the index of the last written record 
            return ret;
        }
    }

    /// <summary>
    /// Executes a stored procedure that returns no results
    /// </summary>
    /// <param name="proc">Name of stored proceduret</param>
    /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
    /// <returns>The number of rows affected</returns>
    public int ExecNonQueryProc(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        using (SqlCommand cmd = CreateCommand(_storeProcedure, _sqlParameter, _output))
        {
            return cmd.ExecuteNonQuery();
        }
    }

    /// <summary>
    /// Executes a query that returns a single value
    /// </summary>
    /// <param name="qry">Query text</param>
    /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
    /// <returns>Value of first column and first row of the results</returns>
    public object ExecScalar(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        using (SqlCommand cmd = CreateCommand(_storeProcedure, _sqlParameter, _output))
        {
            return cmd.ExecuteScalar();
        }
    }

    /// <summary>
    /// Executes a query that returns a single value
    /// </summary>
    /// <param name="proc">Name of stored proceduret</param>
    /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
    /// <returns>Value of first column and first row of the results</returns>
    public object ExecScalarProc(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        using (SqlCommand cmd = CreateCommand(_storeProcedure, _sqlParameter, _output))
        {
            return cmd.ExecuteScalar();
        }
    }

    /// <summary>
    /// Executes a query and returns the results as a SqlDataReader
    /// </summary>
    /// <param name="qry">Query text</param>
    /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
    /// <returns>Results as a SqlDataReader</returns>
    public SqlDataReader ExecDataReader(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        using (SqlCommand cmd = CreateCommand(_storeProcedure, _sqlParameter, _output))
        {
            return cmd.ExecuteReader();
        }
    }

    /// <summary>
    /// Executes a stored procedure and returns the results as a SqlDataReader
    /// </summary>
    /// <param name="proc">Name of stored proceduret</param>
    /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
    /// <returns>Results as a SqlDataReader</returns>
    public SqlDataReader ExecDataReaderProc(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        using (SqlCommand cmd = CreateCommand(_storeProcedure, _sqlParameter, _output))
        {
            return cmd.ExecuteReader();
        }
    }

    /// <summary>
    /// Executes a query and returns the results as a DataSet
    /// </summary>
    /// <param name="qry">Query text</param>
    /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
    /// <returns>Results as a DataSet</returns>
    public DataSet ExecDataSet(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        using (SqlCommand cmd = CreateCommand(_storeProcedure, _sqlParameter, _output))
        {
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            return ds;
        }
    }

    /// <summary>
    /// Executes a stored procedure and returns the results as a Data Set
    /// </summary>
    /// <param name="proc">Name of stored proceduret</param>
    /// <param name="args">Any number of parameter name/value pairs and/or SQLParameter arguments</param>
    /// <returns>Results as a DataSet</returns>
    public DataSet ExecDataSetProc(string _storeProcedure, SqlParameter[] _sqlParameter = null, SqlParameter _output = null)
    {
        using (SqlCommand cmd = CreateCommand(_storeProcedure, _sqlParameter, _output))
        {
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            return ds;
        }
    }

    #endregion

    #region Transaction Members

    /// <summary>
    /// Begins a transaction
    /// </summary>
    /// <returns>The new SqlTransaction object</returns>
    public SqlTransaction BeginTransaction()
    {
        Rollback();
        trans = conn.BeginTransaction();
        return Transaction;
    }

    /// <summary>
    /// Commits any transaction in effect.
    /// </summary>
    public void Commit()
    {
        if (trans != null)
        {
            trans.Commit();
            trans = null;
        }
    }

    /// <summary>
    /// Rolls back any transaction in effect.
    /// </summary>
    public void Rollback()
    {
        if (trans != null)
        {
            trans.Rollback();
            trans = null;
        }
    }

    #endregion

    #region IDisposable Members

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            // Need to dispose managed resources if being called manually
            if (disposing)
            {
                if (conn != null)
                {
                    Rollback();
                    conn.Dispose();
                    conn = null;
                }
            }
            disposed = true;
        }
    }

    #endregion
    }
}
