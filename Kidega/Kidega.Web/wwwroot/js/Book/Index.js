var dataTable;
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: "/Book/GetAll" },
        columns: [
            { data: 'id', "width": "10%" },
            { data: 'title', "width": "20%" },
            { data: 'authorName', "width": "20%" },
            { data: 'categoryName', "width": "15%" },
            { data: 'price', render: $.fn.dataTable.render.number(',', '.', 2,'', '$') , "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `
                        <div class="w-100 pt-2 btn-group" role="group">
                            <a href="/Book/Update/${data}" class="btn btn-dark mx-2" style="cursor:pointer">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a onClick=Delete("/Book/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
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

