bootstrap_alert = function () { }
bootstrap_alert.warningRpt1 = function (message) {
    $('#error_placeholderRpt1').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

}
bootstrap_alert.warningRpt2 = function (message) {
    $('#error_placeholderRpt2').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

}
bootstrap_alert.warningRpt3 = function (message) {
    $('#error_placeholderRpt3').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

}
bootstrap_alert.warningRpt4 = function (message) {
    $('#error_placeholderRpt4').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

}
bootstrap_alert.warningRpt5 = function (message) {
    $('#error_placeholderRpt5').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

}
bootstrap_alert.warningRpt6 = function (message) {
    $('#error_placeholderRpt6').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

}
bootstrap_alert.warningRpt7 = function (message) {
    $('#error_placeholderRpt7').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

}
bootstrap_alert.warningRpt8 = function (message) {
    $('#error_placeholderRpt8').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')
    
}

function validateRpt1ProjHrsByClass(event) {
    var rpt1Begin = new Date($('[name=rpt1BeginDate]').val());
    var rpt1End = new Date($('[name=rpt1EndDate]').val());

    event = event || window.event || event.srcElement;
    if ($('[name=RateID]').val() == null) {
        bootstrap_alert.warningRpt1("ERROR! Please Enter a value for Job Type");
        event.preventDefault();
    } else if ($('[name=rpt1BeginDate]').val() == "") {
        bootstrap_alert.warningRpt1("ERROR! Please Enter a value for the Begin Date");
        event.preventDefault();
    } else if ($('[name=rpt1EndDate]').val() == "") {
        bootstrap_alert.warningRpt1("ERROR! Please Enter a value for the End Date");
        event.preventDefault();
    } else if (rpt1Begin > rpt1End) {
        bootstrap_alert.warningRpt1("ERROR!The value for Begin date has to be before End date");
        event.preventDefault();
    } else {
    }
}

function validateRpt2ProjHrsWeek(event) {
    event = event || window.event || event.srcElement;
    if ($('[name=rpt2Date]').val() == "") {
        bootstrap_alert.warningRpt2("ERROR! Please Enter a value for the Date");
        event.preventDefault();
    } else {
    }
}

function validateRpt3ProjHrsMnth(event) {
    event = event || window.event || event.srcElement;
    if ($('[name=Month]').val() == "") {
        bootstrap_alert.warningRpt3("ERROR! Please Enter a value for the Month");
        event.preventDefault();
    } else if ($('[name=Year]').val() == "") {
        bootstrap_alert.warningRpt3("ERROR! Please Enter a value for the Year");
        event.preventDefault();
    } else {
    }
}

function validateRpt4HoursEmp(event) {
    var rpt4Begin = new Date($('[name=rpt4BeginDate]').val());
    var rpt4End = new Date($('[name=rpt4EndDate]').val());

    event = event || window.event || event.srcElement;
    if ($('[name=EmployeeID]').val() == null) {
        bootstrap_alert.warningRpt4("ERROR! Please Enter a value for Employee Name");
        event.preventDefault();
    } else if ($('[name=rpt4BeginDate]').val() == "") {
        bootstrap_alert.warningRpt4("ERROR! Please Enter a value for the Begin Date");
        event.preventDefault();
    } else if ($('[name=rpt4EndDate]').val() == "") {
        bootstrap_alert.warningRpt4("ERROR! Please Enter a value for the End Date");
        event.preventDefault();
    } else if (rpt4Begin > rpt4End) {
        bootstrap_alert.warningRpt4("ERROR!The value for Begin date has to be before End date");
        event.preventDefault();
    } else {
    }
}

function validateRpt5EmpHrsWeek(event) {
    event = event || window.event || event.srcElement;
    if ($('[name=rpt5Date]').val() == "") {
        bootstrap_alert.warningRpt5("ERROR! Please Enter a value for the Date of Week");
        event.preventDefault();
    } else {
    }
}

function validateRpt6ProfSum(event) {
    var rpt6Begin = new Date($('[name=rpt6BeginDate]').val());
    var rpt6End = new Date($('[name=rpt6EndDate]').val());

    event = event || window.event || event.srcElement;
    if ($('[name=JobID]').val() == null) {
        bootstrap_alert.warningRpt6("ERROR! Please Enter a value for Job Name");
        event.preventDefault();
    } else if ($('[name=Status]').val() == null) {
        bootstrap_alert.warningRpt6("ERROR! Please Enter a value for Job Status");
        event.preventDefault();
    } else if ($('[name=rpt6BeginDate]').val() == "") {
        bootstrap_alert.warningRpt6("ERROR! Please Enter a value for the Begin Date");
        event.preventDefault();
    } else if ($('[name=rpt6EndDate]').val() == "") {
        bootstrap_alert.warningRpt6("ERROR! Please Enter a value for the End Date");
        event.preventDefault();
    } else if (rpt6Begin > rpt6End) {
        bootstrap_alert.warningRpt6("ERROR!The value for Begin date has to be before End date");
        event.preventDefault();
    } else {
    }
}

function validateRpt7MatExp(event) {
    var rpt7Begin = new Date($('[name=rpt7BeginDate]').val());
    var rpt7End = new Date($('[name=rpt7EndDate]').val());

    event = event || window.event || event.srcElement;
    if ($('[name=Rpt7JobID]').val() == null) {
        bootstrap_alert.warningRpt7("ERROR! Please Enter a value for Job Name");
        event.preventDefault();
    }  else if ($('[name=rpt7BeginDate]').val() == "") {
        bootstrap_alert.warningRpt7("ERROR! Please Enter a value for the Begin Date");
        event.preventDefault();
    } else if ($('[name=rpt7EndDate]').val() == "") {
        bootstrap_alert.warningRpt7("ERROR! Please Enter a value for the End Date");
        event.preventDefault();
    } else if (rpt7Begin > rpt7End) {
        bootstrap_alert.warningRpt7("ERROR!The value for Begin date has to be before End date");
        event.preventDefault();
    } else {
    }
}

function validateRpt8AbsAndTard(event)
{
    var rpt8Begin = new Date($('[name=rpt8BeginDate]').val());
    var rpt8End = new Date($('[name=rpt8EndDate]').val());

    event = event || window.event || event.srcElement;
    if ($('[name=Rpt8EmployeeID]').val() == null) {
        bootstrap_alert.warningRpt8("ERROR! Please Enter a value for Employee Name");
        event.preventDefault();
    } else if ($('[name=rpt8BeginDate]').val() == "")
    {
        bootstrap_alert.warningRpt8("ERROR! Please Enter a value for the Begin Date");
        event.preventDefault();
    } else if ($('[name=rpt8EndDate]').val() == "") {
        bootstrap_alert.warningRpt8("ERROR! Please Enter a value for the End Date");
        event.preventDefault();
    } else if (rpt8Begin > rpt8End) {
        bootstrap_alert.warningRpt8("ERROR!The value for Begin date has to be before End date");
        event.preventDefault();
    } else
    {
    }
}