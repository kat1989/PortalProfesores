function asyncPost(url, data) {
    $.ajaxSetup({ contentType: "application/json; charset=utf-8" });

    $.post(url, data,
        function (info) {
            $('body').html(info);
        }
    );
}

$(function () {
    //$('#btnEntrar').click(asyncPost("/Main/Login", null));
    //$('#lnkPublicacion').click(asyncPost("/Publicacion/Index", null))
    $('#btnOkDialog').click(function () { asyncPost("/Publicacion/Guardar", JSON.stringify(json)); });



    //TODO Hacer que se ejecute la funcion cuando cargue el input
    $('.txtPublicacion').bind("keyup", ConvertirLetra);
    $('.txtPublicacion').on("focusout", ValidarEntrada);
    $('.chkPublicacion').click(ColocarIncompleto);
    $('#btnSalir').click(function () { window.location.href = "/Publicacion/Index" })

    $.fn.autoHeight = function () {

        var d = $(this), o = [];
        Array.max = function (array) { return Math.max.apply(Math, array); };
        $.each($(d), function () { o.push(parseInt($(this).height())); });
        var p = Array.max(o), w = $(window).height() - d.eq(0).position().top;
        //console.log(w + "-" + p);
        if (p > w) { d.css('height', p + 'px') } else { d.css('height', w + 'px') }
    }
    $('.auto-height').autoHeight();
    $('#btnGuardar').click(function () {
        $("#msgGuardarPublicacion").fadeIn('fast');
    });
    $('.uk-close, .uk-modal').click(function () {
        $("#msgGuardarPublicacion").fadeOut('fast');
    });
    $('#btnOkDialog').click(function () {
        $("#msgGuardarPublicacion").fadeOut('fast');
        $('.loading').fadeIn('fast');
    });

    $('#txtId').focusout(function () {
        ObtenerCarreras();
    });

    $('#btnGenerar').click(function (e) {
        e.preventDefault();
        var ano = $('#ddlAno').val() ? $('#ddlAno').val() : "";
        var termino = $('#ddlPeriodo').val() ? $('#ddlPeriodo').val() : "";
        var asignatura = $('#ddlAsignatura').val() ? $('#ddlAsignatura').val() : "";
        var id = $('#txtId').val() ? $('#txtId').val() : "";
        var programa = $('#ddlCarreras').val() ? $('#ddlCarreras').val() : "";
        var area = $('#ddlAreas').val() ? $('#ddlAreas').val() : "";

        if (id === "" && $('#txtId').length > 0) {
            alert('No puede dejar el ID del estudiante en blanco.');
        } else if (programa == "" && $('#ddlCarreras').length > 0) {
            alert('No puede dejar la carrera del estudiante en blanco.');
        } else {

            window.location.href = '/Reporte/Exportar?indiceReporte=' + $('#txtReporte').val() +
                                "&parametros.Ano=" + ano +
                                "&parametros.Termino=" + termino +
                                "&parametros.Asignatura=" + asignatura +
                                "&parametros.ID=" + id +
                                "&parametros.Programa=" + programa +
                                "&parametros.Area=" + area;
        }
    });

    setInterval(function(){
        $('#reportViewer').contents().find('#rptViewer_ctl09').height($('#reportViewer').contents().find('#rptViewer_fixedTable div#VisibleReportContentrptViewer_ctl09 table').height() + 'px');      
    },1000);

});

function isEventObject(obj) {
    return obj.type != undefined
}

function ConvertirLetra(nivel) {
    var input = $(this);
    var nivel = $('#txtNivel').val();
    var value = input.val();
    var num = input.attr('id').substring(input.attr('id').indexOf('-') + 1);
    var alpha;

    if (value <= 100 && value >= 90) { $('#nota' + num).html('A'); alpha = 'A'; }
    else if (value < 90 && value >= 85) { $('#nota' + num).html('B+'); alpha = 'B+'; }
    else if (value < 85 && value >= 80) { $('#nota' + num).html('B'); alpha = 'B'; }
    else if (value < 80 && value >= 75) { $('#nota' + num).html('C+'); alpha = 'C+'; }
    else if (value < 75 && value >= 70) { $('#nota' + num).html('C'); alpha = 'C'; }
    else if (nivel == 'G' && value < 70 && value >= 60) { $('#nota' + num).html('D'); alpha = 'D'; }
    else if (nivel == 'G' && value < 60 && value != "") { $('#nota' + num).html('F'); alpha = 'F'; }
    else if (nivel != 'G' && value < 70 && value != "") { $('#nota' + num).html('F'); alpha = 'F'; }
    else $('#nota' + num).html('');

    if (json[num]) {
        json[num].Nota = value;
        json[num].Alpha = alpha;
    }
}

function ColocarIncompleto() {
    var self = $(this);
    var num = self.attr('id').substring(self.attr('id').indexOf('-') + 1);
    if (self.is(':checked')) {
        $('#nota' + num).html('I');
        $('#txtCalificacion-' + num).attr('disabled', 'disabled')
        $('#txtCalificacion-' + num).addClass('color-gray');
        $('#txtCalificacion-' + num).val('')
        if (json[num]) json[num].Incompleto = 'Y';
    }
    else {
        $('#nota' + num).html('');
        $('#txtCalificacion-' + num).removeAttr('disabled')
        $('#txtCalificacion-' + num).removeClass('color-gray');
        if (json[num]) json[num].Incompleto = 'N';
    }
}

function ValidarEntrada() {
    var self = $(this);
    var intVal = parseInt(self.val(), 10);
    if (intVal === NaN && intVal === '') {
        alert('Solo se permiten calificaciones con valores numericos');
        self.val("0");
        self.trigger("focus");
    }
    else if (!(intVal <= 100 && intVal >= 0)) {        
        self.val("0");
        //self.trigger("focus");
    }
}

function ObtenerCarreras() {
    var url = '/Reporte/ObtenerCarreras';
    var data = { idEstudiante: $('#txtId').val() };

    $.ajaxSetup({ contentType: "application/json; charset=utf-8" });
    $.post(url, JSON.stringify(data), function (info) {
        if (info.carreras.length > 0) {
            var ddlCarreras = $('#ddlCarreras');
            ddlCarreras.empty();
            $.each(info.carreras, function (indice, valor) {
                ddlCarreras.append($('<option />', { value: valor.Codigo, text: valor.Descripcion }));
            });
        } else {
            alert('Ese ID no tiene ninguna carrera asignada');
        }
    });
}
