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

    $(document).on('change', '#dplProfesores', function (e) {
        e.preventDefault();

        RefrescarReporte();

    });
})

function RefrescarReporte()
{
    var ano = $('#dplAnos option:selected');
    var trimestre = $('#dplTrimesters option:selected');
    var profesor = $('#dplProfesores option:selected');
    document.getElementById("myReport").src = "../../Reportes/RptRevisionesProfesor.aspx?area=" +
        $('#hdnCodigoArea').val() + "&trimestre=" + trimestre.val()
        + "&ano=" + ano.val() + "&profesorId=" + profesor.val()
        + "&tipo=2&anoText=" + ano.text() + "&trimestreText=" + trimestre.text()
        + "&filtroCondicional=" + profesor.text();
}