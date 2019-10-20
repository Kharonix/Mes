$("#datepicker").datepicker({ format: mm / dd / yyyy })

$(function () {
    $('#datetimepicker2').datetimepicker({
        locale: 'ru'
    });
});

function hover(){
    $('.glyphicon123').toggleClass('glyphicon-menu-down,glyphicon-menu-up');
}
