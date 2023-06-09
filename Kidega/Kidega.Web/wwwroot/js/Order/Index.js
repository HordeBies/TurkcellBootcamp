var dataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: "/Admin/Order/GetAll" },
        columns: [
            { data: 'id', "width": "15%" },
            { data: 'orderDate', "width": "30%" },
            { data: 'orderTotal', render: $.fn.dataTable.render.number(',', '.', 2, '', '$') ,"width": "30%" },
            {
                data: 'id',
                "render": function (data) {
                    return `
                        <div class="w-100 pt-2 btn-group" role="group">
                            <a href="/Admin/Order/Update/${data}" class="btn btn-dark mx-2" style="cursor:pointer">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a onClick=Delete("/Admin/Order/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>
                    `;
                },
                "width": "25%"
            }
        ]
    });
}

