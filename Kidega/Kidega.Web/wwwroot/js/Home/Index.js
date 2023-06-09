var dataTable;
$(document).ready(function () {
    var params = new URLSearchParams(window.location.search);
    loadDataTable(params.get('search') ?? '');

    dataTable.on('search.dt', function (e, settings) {
        var search = dataTable.search();
        if (history.pushState) {
            var params = new URLSearchParams(window.location.search);
            params.set('search', search.trim());
            var newUrl = window.location.origin
                + window.location.pathname
                + '?' + params.toString();
            window.history.pushState({ path: newUrl }, '', newUrl);
        }
    });
})
function loadDataTable(defaultSearch) {
    dataTable = $('#tblData').DataTable({
        "oSearch": { "sSearch": defaultSearch },
        stripeClasses: [],
        "dom": 'frtip',
        pageLength: 20,
        autoWidth: true,
        "ajax": { url: "/Home/GetAllBooks" },
        columns: [
            { data: 'id', "render": function (data) { return `<a href="Home/Details/${data}" style="text-decoration:none;"> <img src="https://picsum.photos/200/300" height="270" class="card-img-top rounded" /> </a>` }, "width": "10%" },
            { data: null, className: 'card-title h5 text-dark opacity-75 text-uppercase text-center', "render": function (data) { return `<a href="Home/Details/${data.id}" class="text-dark"> ${data.title}</a>` }, "width": "10%" },
            { data: 'authorName', className: 'card-title text-warning py-0 my-0', "render": function (data) { return `by <b><button class="text-warning" onclick="searchFromTable('${data}')">${data}</button> </b>` }, "width": "20%" },
            { data: 'categoryName', "render": function (data) { return `<button class="text-dark" onclick="searchFromTable('${data}')" >${data}</button>` }, "width": "10%" },
            { data: 'price', className:'card-title h5 text-warning py-0 my-0 text-center' , render: $.fn.dataTable.render.number(',', '.', 2, '', '$'), "width": "10%" },
            { data: 'id', "render": function (data) {return `<a id="action" asp-controller="Home" asp-action="Details" asp-route-id="@item.Id" class="btn btn-sm btn-dark bg-gradient border-0 shadow-none form-control" style="cursor:pointer"> Details </a>`;}, "width": "10%" }
        ],
        "rowCallback": function (row, data, index) {
            $(row).addClass('card-body border-0 p-3 shadow border-top border-5 rounded')
            $(row).css('width', '15rem')
            $(row).css('height', '33rem')
        }
    });
}

function searchFromTable(search) {

    dataTable.search(search).draw();
}