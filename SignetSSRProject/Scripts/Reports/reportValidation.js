bootstrap_alert = function () { }
bootstrap_alert.warning = function (message) {
    $('#error_placeholder').html('<div class="alert alert-danger"><a class="close" data-dismiss="alert">×</a><span>' + message + '</span></div>')

}

function validateRpt8AbsAndTard(event)
{
    event = event || window.event || event.srcElement;
    if ($('[name=EmployeeID]').val() == null) {

        alert("Validation failed");
        bootstrap_alert.warning("ERROR! Please Enter a value for EmployeeID");
        event.preventDefault();
    } else {
    }
}