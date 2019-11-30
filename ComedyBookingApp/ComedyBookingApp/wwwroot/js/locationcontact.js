var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/locationcontact/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "fname", "width": "20%" },
            { "data": "lname", "width": "20%" },
            { "data": "email", "width": "20%" },
            { "data": "phoneNumber", "width": "20%" },
            { "data": "location", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/locationcontact/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/locationcontact/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-trash'></i> Delete
                                </a>
                            </div>
                            `;
                }, "width":"20%"
            }

        ],
        "language": {
            "emptyTable":"No records found."
        },
        "width":"100%"
    });
}