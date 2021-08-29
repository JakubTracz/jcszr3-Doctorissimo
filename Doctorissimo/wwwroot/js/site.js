// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function ToggleRowDisplay() {
    const nextRow = (this).parentNode.row.nextElementSibling();
    alert(nextRow.innerHTML);
}
