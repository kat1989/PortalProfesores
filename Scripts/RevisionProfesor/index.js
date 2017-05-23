$(function () {
        inicializar();
        $(document).on('click', '.page', function(e) {
            e.preventDefault();
            var pagina = parseInt($(this).html());
            obtenerRevisiones(pagina);
          

        });
        $(document).on('change', '#dplAnos', function (e) {
            e.preventDefault();
         
            obtenerRevisiones(1);
            RefrescarLeyenda();
        

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
        $(document).on('click', '.uk-close', function (e) {
            e.preventDefault();
            var tooltipCerrar = $(this).data('estatus');
            $('.' + tooltipCerrar + '').tooltipster('hide');

        });
       


    }
);

function obtenerRevisiones(pagina) {
    $.ajax({
        url: '/RevisionProfesor/GetAsignaturasRevision',
        data: {
            "pagina": pagina, "ano": $("#dplAnos option:selected").val(),
            "trimestre": $("#dplTrimesters option:selected").val(),
            "asignatura": $("#dplAsignatura option:selected").val(),
            "idEstado": $("#dplEstados option:selected").val()
        },
        success: function (data) {
            $("#revisionesContainer").html(data);
            $('.total-filas').text($('#TotalRows').val());
            $('.trimester-filter').text($("#dplTrimesters option:selected").text());
            $('.year-filter').text($("#dplAnos option:selected").text());
            $('.subject-filter').text($("#dplAsignatura option:selected").text());
            inicializarTooltips();
         
        }
          
    });
   
  
    
}

function RefrescarLeyenda() {
    $.ajax({
        url: '/RevisionProfesor/ObtenerTotalesCategoria',
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
    RefrescarLeyenda();
    inicializarTooltips();
}



function inicializarTooltips()
{
    $('#tblRevisiones tbody tr td button.tooltip').each(function (subject) {
        var mensaje = $(this).attr('title');
        var titulo = "";
        var position = "";
        var estatusData = "";
      
        if ($(this).data('idstatus') == "5") {
            titulo = "SOLICTUD DECLINADA";
            position = "bottom-left";
            estatusData = "estatus-declined";
        } else if ($(this).data('idstatus') == "6") {
            titulo = "SOLICTUD CERRADA";
            position = "top-right";
            estatusData = "estatus-closed";

        }
        else if ($(this).data('idstatus') == "3") {
            titulo = "SOLICTUD AGENDADA";
            position = "top-right";
            estatusData = "estatus-scheduled";
         

        }
        else if ($(this).data('idstatus') == "2") {
            titulo = "SOLICTUD SOLICITADA";
            position = "top-right";
            estatusData = "estatus-requested";


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
                    url: '/RevisionProfesor/GetDatosEstudiante',
                    success: function(data) {
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