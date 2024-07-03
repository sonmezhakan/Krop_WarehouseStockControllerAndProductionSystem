$(document).ready(() => {
})

function intitializeDataTable(tableId, orderColumn, orderStatu) {
    $('#' + tableId).DataTable({
        destroy: true,
        "order": [[orderColumn, orderStatu]],
        language: {
            lengthMenu: "Sayfa başına _MENU_ göster",
            search: "Arama",
            info: "Gösterilen _START_ ile _END_ arası. Toplamda _TOTAL_ bulunmaktadır."
        }
    })
}
function redirectToSelectedPage(pathParts) {
    const fullUrl = window.location.href;
    const protocol = window.location.protocol;
    const host = window.location.host;

    window.location = protocol + "//" + host + "/" + pathParts;
}