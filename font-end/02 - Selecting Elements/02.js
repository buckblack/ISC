$(document).ready(function () {
    $('#selected-plays>li').addClass('horizontal');
    $('#selected-plays li:not(.horizontal)').addClass('sub-level');
    $('tr:nth-child(odd)').addClass('alt');
    $('td:contains(Henry)').addClass('highlight');
});
