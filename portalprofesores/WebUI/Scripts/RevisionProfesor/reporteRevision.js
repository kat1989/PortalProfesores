$(function () {
    RefrescarReporte();
    $(document).on('change', '#dplTrimesters', function (e) {
        e.preventDefault();

        RefrescarReporte();

    });

    $(document).on('change', '#dplAnos', function (e) {
        e.preventDefault();

        RefrescarReporte();

    });

    $(document).on('change', '#dplAreas', function (e) {
        e.preventDefault();

        RefrescarReporte();

    });
})

function RefrescarReporte()
{
    var ano = $('#dplAnos option:selected');
    var trimestre = $('#dplTrimesters option:selected');
    var area = $('#dplAreas option:selected');
    document.getElementById("myReport").src = "../../Reportes/RptRevisionesProfesor.aspx?profesorId=" +
        $('#hdnIdProfesor').val() + "&trimestre=" +trimestre.val()
        + "&ano=" + ano.val() + "&area=" + area.val() + "&tipo=1&anoText=" + ano.text() + "&trimestreText=" + trimestre.text()
        + "&filtroCondicional=" + area.text();
}