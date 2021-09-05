// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function ToggleRowDisplay() {
    const row = $(this).closest("tr");
    const nextRow = row.next();
    nextRow.addClass("test");
}
