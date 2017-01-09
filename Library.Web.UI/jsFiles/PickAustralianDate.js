    // Data Picker
    $(function () {
        $(".datePick").datepicker({
            dateFormat: 'dd/mm/yy'
        }).on('change', function () { $(".datePick").valid(); })
    });



    // AustralianDat
    $.validator.addMethod(
    "australianDate",
    function (value, element) {
        // put your own logic here, this is just a (crappy) example
        return value.match(/^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$/);
    },
    "Please enter a date in the format dd/mm/yyyy."
    );
