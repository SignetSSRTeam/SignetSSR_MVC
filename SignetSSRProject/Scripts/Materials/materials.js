
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
        deleteConfirm: "Do you really want to delete the materials detail?",
        

        controller: {
            

            loadData: function (filter) {
                var materials = $.ajax({
                    type: "GET",
                    url: "/Materials/MaterialsData",
                    data: filter,
                    dataType: "json"
                });
                return materials;
            },



            insertItem: function (item) {
                delete item.MaterialsExpenseID;
                if (validateMaterials(item)) {
                    return $.ajax({
                        type: "POST",
                        url: "/Materials/InsertMaterialsData",
                        data: item,
                        dataType: "json"
                    });
                } else {
                    return nothing;//force a javascript error to keep the grid from rendering
                }

                
            },

            updateItem: function (item) {
                if (validateMaterials(item)) {
                    return $.ajax({
                        type: "POST",
                        url: "/Materials/UpdateMaterialsData",
                        data: item,
                        dataType: "json"
                    });
                } else {
                    return nothing;//force a javascript error to keep the grid from rendering
                }
                
            },

            deleteItem: function (item) {
                return $.ajax({
                    type: "POST",
                    url: "/Materials/DeleteMaterialsData",
                    data: item,
                    dataType: "json"
                });
            }
        },

        fields: [
            { title: "ID", name: "MaterialsExpenseID", width: 25, align: "center"},
            { name: "Expense", type: "text", width: 35, itemTemplate: function (value) { return "$" + value.toFixed(2); }, align: "center" },
            { title: "Job #", name: "JobID", type: "select", items: listJobNumber, valueField: "JobID", textField: "JobNumber", width: 50, align: "center" },
            { title: "Date", name: "ExpenseDate", type: "text", width: 50, align: "center" },
            { title: "Item #", name: "ItemNumber", type: "number", width: 30, align: "center" },
            { title: "Description", name: "ExpenseDescription", type: "text", width: 75, align: "center" },
            { title: "PO Number", name: "PONumber", type: "text", width: 35, align: "center" },
            { title: "Invoice Number", name: "InvoiceNumber", type: "text", width: 35, align: "center" },
            { title: "Tax Included", name: "TaxIncluded", type: "checkbox", width: 25, align: "center" },
            { title: "Invoice Received", name: "InvoiceReceived", type: "checkbox", width: 25, align: "center" },
            { title: "Tax %", name: "TaxPercentage", type: "text", width: 35, itemTemplate: function (value) { if (value !== null) { return value.toFixed(2) + "%"; }}, align: "center" },
            { title: "Markup %", name: "MarkupPercentage", type: "text", width: 35, itemTemplate: function (value) { if (value !== null) { return value.toFixed(2) + "%"; }}, align: "center" },
            { type: "control" }
        ]
    });
});