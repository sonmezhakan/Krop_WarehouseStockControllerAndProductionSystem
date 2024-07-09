$(document).ready(() => {
})

function intitializeDataTable(tableId, orderColumn, orderStatu) {
    $('#' + tableId).DataTable({
        destroy: true,
        "scrollX": true,
        responsive: true,
        "order": [[orderColumn, orderStatu]],
        language: {
            url: '//cdn.datatables.net/plug-ins/2.0.8/i18n/tr.json'
        },
        columnDefs: [
            { type: 'de_datetime', targets: orderColumn }
        ]
    });
    
}
function redirectToSelectedPage(pathParts) {
    const protocol = window.location.protocol;
    const host = window.location.host;

    window.location = protocol + "//" + host + "/" + pathParts;
}
