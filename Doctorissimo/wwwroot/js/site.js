// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Basic example
$(document).ready(function () {
    $('#appointmentsTable').DataTable({
        "paging": false
    });
    $('.dataTables_length').addClass('bs-select');
});
// Basic example
$(document).ready(function () {
    $('#appointmentsTable').DataTable({
        "pagingType": "simple" // "simple" option for 'Previous' and 'Next' buttons only
    });
    $('.dataTables_length').addClass('bs-select');
});
