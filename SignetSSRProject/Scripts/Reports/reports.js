$(document).ready(function () {
    $('[id^=detail-]').hide();
    $('.toggle').click(function () {
        $input = $(this);
        $target = $('#' + $input.attr('data-toggle'));
        $target.slideToggle();
    });

    $('[name=RateID]').dropdown();
    $('[name=EmployeeID]').dropdown();
    $('[name=Rpt8EmployeeID]').dropdown();
    $('[name=JobID]').dropdown();
    $('[name=Rpt7JobID]').dropdown();
    $('[name=Status]').dropdown();
});