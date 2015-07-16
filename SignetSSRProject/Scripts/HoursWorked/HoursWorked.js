$(function () {

    

    $("#jsGrid").jsGrid({
        width: "100%",
        height: "400px",

        filtering: true,
        editing: true,
        sorting: true,
        paging: true,
        autoload: true,
        pageSize: 25,
        pageButtonCount: 5,
        deleteConfirm: "Do you really want to delete the hours worked record?",


        controller: {
            loadData: function (filter) {
                return $.ajax({
                    type: "GET",
                    url: "/HoursWorkeds/HoursWorkedsData",
                    data: filter,
                    dataType: "json"
                });
            },

            insertItem: function (item) {
                delete item.HoursWorkedID;
                if (validateHoursWorked(item)) {
                    return $.ajax({
                        type: "POST",
                        url: "/HoursWorkeds/InsertHoursWorkedsData",
                        data: item,
                        dataType: "json"
                    });
                }
                else {
                    return nothing; //Work around: Force a javascript error to prevent grid from loading
                }
                
            },

            updateItem: function (item) {
                if (validateHoursWorked(item)) {
                    return $.ajax({
                        type: "POST",
                        url: "/HoursWorkeds/UpdateHoursWorkedsData",
                        data: item,                        
                        dataType: "json"
                    });

                } else {
                    return nothing; //Work around: Force a javascript error to prevent grid from loading
                }
                
            },

            deleteItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/HoursWorkeds/DeleteHoursWorkedData",
                    data: item,
                    dataType: "json"
                });
            },
        },

        fields: [
            { title: "ID", name: "HoursWorkedID", width: 25, align: "center" },
            { title: "Employee Name", name: "EmployeeID", type: "select", items: listEmployeeName, valueField: "EmployeeID", textField: "EmployeeName", width: 60, align: "center" },
            { title: "Job Number", name: "JobID", type: "select", items: listJobNumber, valueField: "JobID", textField: "JobNumber", width: 50, align: "center" },
            { title: "Item Number", name: "ItemNumber", type: "text", width: 40, align: "center" },
            { title: "Date", name: "Date", type: "text", width: 50, align: "center" },
            { title: "Hours Worked RT", name: "HoursWorkedRT", type: "text", width: 40, align: "center", itemTemplate: function (value) {return parseFloat(value).toFixed(2);} },
            { title: "Hours Worked OT", name: "HoursWorkedOT", type: "text", width: 40, align: "center", itemTemplate: function (value) { return parseFloat(value).toFixed(2);} },
            { title: "Job Desc", name: "JobDescription", type: "text", width: 75, align: "center" },
            { type: "control" }
        ]
    });
});

