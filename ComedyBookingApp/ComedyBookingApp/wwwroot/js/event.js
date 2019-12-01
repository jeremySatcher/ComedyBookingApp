var dataTableEvent;

$(document).ready(function () {
    loadEventDataTable();
});

function loadEventDataTable() {
    dataTableEvent = $('#tblData').DataTable({
        "ajax": {
            "url": "/admin/event/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { data: "name", "width": "15%" },
            { data: "price", "width": "15%" },
            { data: "date", "width": "15%" },
            { data: "time", "width": "15%" },
            { data: "location", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/event/Upsert/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                    <i class='fa fa-edit'></i> Edit
                                </a>
                                &nbsp;
                                <a onclick=Delete("/Admin/event/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class='fa fa-trash'></i> Delete
                                </a>
                            </div>
                            `;
                }, "width": "25%"
            }
        ],
        "language": {
            "emptyTable": "No records found."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        text: "You will not be able to restore the content!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTableEvent.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}