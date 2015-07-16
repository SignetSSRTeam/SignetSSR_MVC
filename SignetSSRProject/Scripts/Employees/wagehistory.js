$(function () {

    $("#jsGrid").jsGrid({
        width: "100%",
        height: "400px",

        filtering: false,
        inserting: true,
        editing: true,
        sorting: true,
        paging: true,
        autoload: true,
        pageSize: 25,
        pageButtonCount: 5,
        deleteConfirm: "Do you really want to delete this employees Wage History detail?",


        controller: {
            loadData: function (filter) {
                var wageHistory = $.ajax({
                    type: "GET",
                    url: "/Employee/WageHistoryData",
                    data: { EmployeeID: employeeID },
                    dataType: "json"
                });
                /*return $.grep(wageHistory, function (mat) {
                    return (!filter.Description || client.Name.indexOf(filter.Description) > -1);
                });*/
                return wageHistory;
            },

            insertItem: function (item) {
                delete item.WageHistoryID;
                item.EmployeeID = employeeID;
                return $.ajax({
                    type: "POST",
                    url: "/Employee/InsertWageHistoryData",
                    data: item,
                    dataType: "json"
                });
            },

            updateItem: function (item) {
                item.EmployeeID = employeeID;
                return $.ajax({
                    type: "POST",
                    url: "/Employee/UpdateWageHistoryData",
                    data: item,
                    dataType: "json"
                });
            },

            deleteItem: function (item) {
                item.EmployeeID = employeeID;
                return $.ajax({
                    type: "POST",
                    url: "/Employee/DeleteWageHistoryData",
                    data: item,
                    dataType: "json"
                });
            }
        },

        fields: [
            { title: "ID", name: "WageHistoryID", width: 25, align: "center" },
            { title: "Wage RT", name: "WageRT", type: "number", width: 50, itemTemplate: function (value) { return "$" + value.toFixed(2); }, align: "center" },
            { title: "Wage OT", name: "WageOT", type: "number", width: 50, itemTemplate: function (value) { return "$" + value.toFixed(2); }, align: "center" },
            { title: "Start Date", name: "DateStart", type: "text", width: 50, align: "center" },
            { title: "End Date", name: "DateEnd", type: "text", width: 50, align: "center" },
            { title: "Is Current", name: "IsCurrent", type: "checkbox", width: 35 },
            { type: "control" }
        ]
    });
});