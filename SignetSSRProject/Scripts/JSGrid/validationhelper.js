bootstrap_alert = function () { }
bootstrap_alert.warning = function (message) {
    $('#error_placeholder').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')
    
}

function validateHoursWorked(item) {
    if (item.JobDescription.length > 255) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Job description. Make sure the text is less than 255 characters. Please hit F5 or refresh Screen");
        return false;
    } else if (item.JobID == 0) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Job Number. Make sure that a value for the Job Number is selected. Please hit F5 or refresh Screen");
        return false;
    } else if (item.EmployeeID == 0) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Employee. Make sure that a value Employee is selected. Please hit F5 or refresh Screen");
        return false;
    } else if ($.isNumeric(item.ItemNumber) == false) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Item Number. Make sure the item number is numeric. Please hit F5 or refresh Screen");
        return false;
    } else if ($.isNumeric(item.HoursWorkedRT) == false) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Hours Worked RT. Make sure the Hours worked are numeric. Please hit F5 or refresh Screen");
        return false;
    } else if ($.isNumeric(item.HoursWorkedOT) == false) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Hours Worked OT. Make sure the Hours worked are numeric. Please hit F5 or refresh Screen");
        return false;
    } else {
        return true;
    };
}


function validateMaterials(item) {
    if ($.isNumeric(item.Expense) == false) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Expense. Make sure that the value for expense is numeric. Please hit F5 or refresh Screen");
        return false;
    } else if (item.JobID == 0) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Job Number. Make sure that a value for the Job Number is selected. Please hit F5 or refresh Screen");
        return false;
    } else if ($.isNumeric(item.ItemNumber) == false && item.ItemNumber != 0) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Item Number. Make sure the item number is numeric. Please hit F5 or refresh Screen");
        return false;
    } else if (item.ExpenseDescription.length > 50) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Expense Description. Make sure the expense description is not longer than 50 characcters. Please hit F5 or refresh Screen");
        return false;
    } else if (item.PONumber.length > 7) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Expense Description. Make sure the expense description is not longer than 50 characcters. Please hit F5 or refresh Screen");
        return false;
    } else if (item.InvoiceNumber.length > 8) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Expense Description. Make sure the expense description is not longer than 50 characcters. Please hit F5 or refresh Screen");
        return false;
    } else if ($.isNumeric(item.TaxPercentage) == false && item.TaxPercentage != 0) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Tax percentage. Make sure the tax percentage is numeric (Leave out % symbol). Please hit F5 or refresh Screen");
        return false;
    } else if ($.isNumeric(item.MarkupPercentage) == false && item.MarkupPercentage != 0) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Markup Percentage. Make sure the Markup percentage is numeric (Leave out % symbol). Please hit F5 or refresh Screen");
        return false;
    } else {
        return true;
    };
}


function validateWageHistory(item) {
    if ($.isNumeric(item.WageRT) == false) {
        alert(item.WageRT);
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Wage Rate RT. Make sure that the value for Wage Rate RT is numeric. Please hit F5 or refresh Screen");
        return false;
    } else if ($.isNumeric(item.WageOT) == false) {
        bootstrap_alert.warning("ERROR! Row not saved. Invalid Wage Rate OT. Make sure that the value for Wage Rate OT is numeric. Please hit F5 or refresh Screen");
        return false;
    } else {
        return true;
    };
}
