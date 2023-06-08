var dataTable;
$(document).ready(function () {
    var params = new URLSearchParams(window.location.search);
    loadDataTable(params.get('search') ?? '');
})
function loadDataTable(defaultSearch) {
    dataTable = $('#tblData').DataTable({
        "oSearch": { "sSearch": defaultSearch },
        stripeClasses: [],
        "dom": 'frtip',
        pageLength: 12,
        autoWidth: true,
    });
}

function searchFromTable(search) {
    if (history.pushState) {
        var params = new URLSearchParams(window.location.search);
        params.set('search', search.trim());
        var newUrl = window.location.origin
            + window.location.pathname
            + '?' + params.toString();
        window.history.pushState({ path: newUrl }, '', newUrl);
    }
    dataTable.search(search).draw();
}