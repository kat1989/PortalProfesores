$(function () {
    inicializar();
    $(document).on('click', '.page', function (e) {
        e.preventDefault();
        var pagina = parseInt($(this).html());
        obtenerRevisiones(pagina);


    });
    $(document).on('change', '#dplAnos', function (e) {
        e.preventDefault();

        obtenerRevisiones(1);
        RefrescaLeyenda();


    });
    $(document).on('change', '#dplTrimesters', function (e) {
        e.preventDefault();

        obtenerRevisiones(1);
        RefrescarLeyenda();


    });
    $(document).on('change', '#dplAsignatura', function (e) {
        e.preventDefault();

        obtenerRevisiones(1);
        RefrescarLeyenda();


    });
    $(document).on('change', '#dplEstados', function (e) {
        e.preventDefault();

        obtenerRevisiones(1);



    });

    $(document).on('change', '#dplProfesores', function (e) {
        e.preventDefault();

        obtenerRevisiones(1);



    });
    $(document).on('change', 'select.select-status-change', function (e) {
        e.preventDefault();
        var revisionId = $(this).closest('tr').data("revisionid");
        if ($(this).val() == 7) {
            $("#txtValorNota_" + revisionId).prop("disabled", false);
        } else {
            $("#txtValorNota_" + revisionId).val('');
            $("#txtCodigoNota_" + revisionId).val('');
            $("#txtValorNota_" + revisionId).prop("disabled", true);

        }



    });
    $(document).on('click', '.uk-close', function (e) {
        e.preventDefault();
        var tooltipCerrar = $(this).data('estatus');
        $('.' + tooltipCerrar + '').tooltipster('hide');

    });
    $(document).on('change', 'input.assigned-grade_value', function (e) {
        e.preventDefault();
       
        var revisionId = $(this).closest('tr').data("revisionid");
        $.ajax({
            url: '/RevisionArea/ObtenerCodigoNota',
            data: {
                "nota": $("#txtValorNota_" + revisionId).val(),
                "notaActual": $('#'+revisionId).find("td:eq( 3 ) span").text()

            },
            success: function (data) {

                $("#txtCodigoNota_" + revisionId).val(data.codigoNota);



            },
            error: function (data) {

                $("#txtCodigoNota_" + revisionId).val('');
                alert('La nota debe ser superior a la obtenida!');



            }

        });


    });

    $(document).on('click', 'button.revision-Action', function (e) {
        e.preventDefault();
        var fila = $(this).closest('tr');

        if ($(this).hasClass('icon-arrow')) {
            $("tr[data-revisionId='" + fila.attr('id') + "']").show();
            $(this).removeClass('icon-arrow');
            $(this).addClass('icon-arrow-down');
            var idEstado = $('#estadoId_' + fila.attr('id')).val();
            $('#dplCambios_' + fila.attr('id') + " option[value='" + idEstado + "']").attr('selected', 'selected');
            obtenerDocentesRevision(fila.attr('id'));
            obtenerRepresentantesRevision(fila.attr('id'));
        } else {
            $("tr[data-revisionId='" + fila.attr('id') + "']").hide();
            $(this).removeClass('icon-arrow-down');
            $(this).addClass('icon-arrow');


        }


    });
    $(document).on('click', 'button.btn-guardar-revision', function (e) {
        e.preventDefault();

        var tab = $(this).closest('tr');
        actualizarRevision(tab);


    });
    $(document).on('click', 'button.btn-cancelar-revision', function (e) {
        e.preventDefault();

        var tab = $(this).closest('tr');
        var buttonSlide = $('#' + tab.data('revisionid')).find('button.revision-Action');
        buttonSlide.removeClass('icon-arrow-down');
        buttonSlide.addClass('icon-arrow');
        tab.hide();


    });
    $(document).on('click', 'button.btn-imprimir-reporte', function (e) {
        e.preventDefault();
        var row = $(this).closest('tr');
        var currentTab = row.find('li.uk-active');
        var idRevision = row.data('revisionid');
        var idEstado = $('#estadoId_' + idRevision).val();

        var url;
        if (currentTab.hasClass('revision-decision')) {
            url = "/RevisionArea/ObtenerReporteCambioCalificacion?idRevision=" + idRevision +
                "&idEstado=" + idEstado;

        } else {
            url = "/RevisionArea/ObtenerFormularioSolicitud?idRevision=" + idRevision +
                "&idEstado=" + idEstado;


        }

        window.open(url);




    });
    $(document).on('click', 'li.uk-active a', function (e) {
        e.preventDefault();
        if ($(this).closest('li').hasClass('revision-decision')) {
            $(this).closest('tr').find('button.btn-imprimir-reporte').text('IMPRIMIR REPORTE DE CALIF.');
        }
        else {
            $(this).closest('tr').find('button.btn-imprimir-reporte').text('IMPRIMIR SOLICITUD REVISION');

        }
     



    });


}
);

function obtenerRevisiones(pagina) {
    $.ajax({
        url: '/RevisionArea/GetAsignaturasRevision',
        data: {
            "pagina": pagina, "ano": $("#dplAnos option:selected").val(),
            "trimestre": $("#dplTrimesters option:selected").val(),
            "asignatura": $("#dplAsignatura option:selected").val(),
            "idEstado": $("#dplEstados option:selected").val(),
            "idProfesor": $("#dplProfesores option:selected").val()
        },
        success: function (data) {
            $("#revisionesContainer").html(data);
            $('.total-filas').text($('#TotalRows').val());
            $('.trimester-filter').text($("#dplTrimesters option:selected").text());
            $('.year-filter').text($("#dplAnos option:selected").text());
            $('.subject-filter').text($("#dplAsignatura option:selected").text());
            inicializarTooltips(false,"");
            $('.date-picker').datetimepicker({
                timeFormat: "hh:mm:ss tt",
                dateFormat: "dd/mm/yy"

            }, $.datepicker.regional['es']);

        }

    });



}

function RefrescarLeyenda() {
    $.ajax({
        url: '/RevisionArea/ObtenerTotalesCategoria',
        data: {
            "ano": $("#dplAnos option:selected").val(),
            "trimestre": $("#dplTrimesters option:selected").val(),
            "asignatura": $("#dplAsignatura option:selected").val()
        },
        success: function (data) {

            $('span.bg-color-normal').text(data.normal);
            $('span.bg-color-modarate').text(data.moderado);
            $('span.bg-color-critic').text(data.critico);



        }

    });

}
function inicializar() {


    $('.trimester-filter').text($("#dplTrimesters option:selected").text());
    $('.year-filter').text($("#dplAnos option:selected").text());
    $('.subject-filter').text($("#dplAsignatura option:selected").text());

    $('.date-picker').datetimepicker({
        timeFormat: "hh:mm:ss tt",
        dateFormat: "dd/mm/yy"

    }, $.datepicker.regional['es']);
    RefrescarLeyenda();
    inicializarTooltips(false,"");
}



function inicializarTooltips(resetear,mensajeTooltip) {
    var mensaje = mensajeTooltip;
    var titulo = "";
    var position = "";
    var estatusData = "";

    $('#tblRevisiones tbody tr td button.tooltip').each(function (subject) {
        if (mensajeTooltip == "") {
            mensaje = $(this).attr('title');
            
        }
           
            var revisionId = $(this).closest('tr').attr('id');

            if ($(this).attr('data-idstatus') == "5") {
                titulo = "SOLICTUD DECLINADA";
                position = "bottom-left";
                estatusData = "estatus-declined-"+revisionId;
            } else if ($(this).attr('data-idstatus') == "6") {
                titulo = "SOLICTUD CERRADA";
                position = "top-right";
                estatusData = "estatus-closed-"+revisionId;

            } else if ($(this).attr('data-idstatus') == "3") {
                titulo = "SOLICTUD AGENDADA";
                position = "top-right";
                estatusData = "estatus-scheduled-"+revisionId;


            } else if ($(this).attr('data-idstatus') == "2") {
                titulo = "SOLICTUD SOLICITADA";
                position = "top-right";
                estatusData = "estatus-requested-"+revisionId;


            }
            if (!$(this).hasClass(estatusData)) {
                $(this).addClass(estatusData);
            }
            $('.' + estatusData + '').tooltipster(
                {
                    theme: 'tooltipster-shadow',

                    content: $('<p class="section-title color-red ">' + titulo + '</p><a  href="" class="uk-close" data-estatus="' + estatusData + '"></a>' + mensaje + ''),
                    position: position,
                    interactive: true,
                    contentAsHTML: true,
                    
                    autoClose: false,
                   
                    trigger: 'click'
                });


        });
        if(!resetear)
            {
        $('td.tooltip').each(function (subject) {
            $(this).tooltipster({
                content: 'Cargando...',
                theme: 'tooltipster-shadow',
                contentAsHTML: true,
                updateAnimation: false,
                position: "top-left",
                interactive: true,
                trigger: 'click',
             
                functionBefore: function (origin, continueTooltip) {

                    continueTooltip();
                    if (origin.data('ajax') !== 'cached') {
                        $.ajax({
                            data: {
                                "id": $(this).text()
                            },
                            type: 'POST',
                            url: '/RevisionArea/GetDatosEstudiante',
                            success: function (data) {
                                var contenido = '<p class="section-title color-red ">' + data.Nombre + '</p><br/><div class="icon-phone"></div>' +
                                    data.Telefono + '<br/><div class="icon-cellphone"></div>' + data.Celular + '<br/><div class="icon-email"></div>' + data.Correo;
                                origin.tooltipster('content', contenido).data('ajax', 'cached');
                            }
                        });
                    }
                }
            });
        });
    }
}

function cargarFormularioRevision(elemento) {
    $.ajax({
        url: '/RevisionArea/GetFormularioRevision',
        data: {

        },
        success: function (data) {
            elemento.after(data);
            $('tr.tabsContainer').data('revisionId', elemento.attr('id'));


        }

    });



}

function obtenerDocentesRevision(idRevision) {
    $.getJSON("/RevisionArea/ObtenerDocentes", null, function (data) {
        data = $.map(data, function (item, a) {
            return "<option value=" + item.Codigo + ">" + item.Descripcion + "</option>";
        });

        $("#dplProfesores_" + idRevision).append(data.join(""));
        var idDocente = $("#docenteId_" + idRevision).val();

        $("#dplProfesores_" + idRevision + " option[value='" + idDocente + "']").attr('selected', 'selected');
    });
}
function obtenerRepresentantesRevision(idRevision) {
    $.getJSON("/RevisionArea/ObtenerRepresentantes", null, function (data) {
        data = $.map(data, function (item, a) {
            return "<option value=" + item.Codigo + ">" + item.Descripcion + "</option>";
        });

        $("#dplRepresentantes_" + idRevision).append(data.join(""));
        var idRepresentante = $("#representanteId_" + idRevision).val();

        $("#dplRepresentantes_" + idRevision + " option[value='" + idRepresentante + "']").attr('selected', 'selected');
    });


}

function actualizarRevision(tab) {

    var idRevision = tab.data('revisionid');
    var docenteAsignado = $("#dplProfesores_" + idRevision + " option:selected").val();
    var representanteAsignado = $("#dplRepresentantes_" + idRevision + " option:selected").val();
    var lugar = $("#txtLugarDisponible_" + idRevision).val();
    var comentarios = $("#txtComentarios_" + idRevision).val();
    var fechaCita = $("#txtFechaCita_" + idRevision).val();
    var codigoCambio = $("#dplCambios_" + idRevision + " option:selected").val();
    var codigoNota = $("#txtCodigoNota_" + idRevision).val();
    var valorNota = $("#txtValorNota_" + idRevision).val();
    var profesorAsistio = $("#chkProfesor_" + idRevision).is(':checked');
    var estudianteAsistio = $("#chkEstudiante_" + idRevision).is(':checked')
    var representanteAsistio = $("#chkRepresentante_" + idRevision).is(':checked');
    var idEstado = $("#estadoId_" + idRevision).val();
    var tabSeleccionado = tab.find('li.uk-active').hasClass('revision-decision') ? 2 : 1;

    $.ajax({
        url: "/RevisionArea/ActualizarRevision",
        data: {
            "revisionId": idRevision,
            "docenteAsignado": docenteAsignado,
            "representanteId": representanteAsignado,
            "lugar": lugar,
            "comentarios": comentarios,
            "fechaCita": fechaCita,
            "codigoCambio": codigoCambio,
            "codigoNota": codigoNota,
            "valorNota": valorNota,
            "profesorAsistio": profesorAsistio,
            "estudianteAsistio": estudianteAsistio,
            "representanteAsistio": representanteAsistio,
            "idEstadoActual": idEstado,
            "tabSeleccionado": tabSeleccionado
        },

        type: "POST",

        success: function (data) {
            tab.find('li.uk-disabled').removeClass('uk-disabled');
            var fila = $('#' + idRevision);
           
            var buttonEstatus = fila.find("td:eq( 5 ) button");
          
            buttonEstatus.removeClass('tooltipstered');
            var lastClass = buttonEstatus.attr('class').split(' ').pop();
            if (buttonEstatus.hasClass('tooltip')) {
                $('.' + lastClass).tooltipster('destroy');
                buttonEstatus.removeClass(lastClass);
            }


            buttonEstatus.text(data.estado);
            fila.find("td:eq( 6 )").text(data.fechaClave);
            $("#estadoId_" + idRevision).val(data.idEstado);
        
            if (data.idEstado == 6) {
                fila.find('td').addClass('color-disabled');
                buttonEstatus.addClass('color-disabled');
                fila.find('span').addClass('color-disabled');
            } else {
                fila.find('td').removeClass('color-disabled');
                buttonEstatus.removeClass('color-disabled');
                fila.find('span').removeClass('color-disabled');

            }
         
          
            if (data.idEstado != 7) {
                if (!buttonEstatus.hasClass('tooltip')) {
                    buttonEstatus.addClass('tooltip');
                }
            } else {
                buttonEstatus.removeClass('tooltip');
            }
         
            buttonEstatus.attr('data-idstatus', data.idEstado);
            inicializarTooltips(true, data.mensajeEstado);
            alert('Cambios guardados satisfactoriamente!');

        },
        error: function (data) {


            alert('Se ha producido un error al guardar!');

        }
    });



}

