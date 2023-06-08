var dataTable;
$(document).ready(function () {
    var params = new URLSearchParams(window.location.search);
    loadDataTable(params.get('search') ?? '');

    dataTable.on('search.dt', function (e, settings) {
        var search = dataTable.search();
        //console.log(settings.oPreviousSearch.sSearch);
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
        pageLength: 12,
        autoWidth: true,
    });
}

function searchFromTable(search) {
    
    dataTable.search(search).draw();
}