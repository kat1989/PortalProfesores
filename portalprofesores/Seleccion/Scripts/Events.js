$(document).ready(function () {
    AceptarTerminos();
    retirarManteria();
    enableMessages();
    getMessages();
});

function loadInfoGrid(table, result) {
    var elements = table.children().children().find('td:first');

    elements.click(addRow);
    function addRow() {
        if ($(this).next().text() != "CLAVE" && $(this).next().text() != "Clave") {
            removeRow($(this));


            var user = $('#lblTitulo').text().match('[0-9]+');
            var IES_ID = $('#CodigoInstitucion').val();
            var clave = $(this).first().next();
            var seccion = clave.next();
            var creditos = seccion.next();
            var asignatura = creditos.next();
            var rowCount = result.find('tr').length - 1;

            //if (puedeInsertar(table)) {
            var html = "<tr class=ColNormal style=\"background-color: #FFFFCC;\">" +
                            "<td>" +
                                "<a href=\"#\">" +
                                    "<img src=\"../../Content/themes/base/images/delete_icon.gif\"/>" +
                                "</a>" +
                            "</td>" +

                            "<td>" +
                                " <input type=text readonly=true class= asLabel" +
                                " id=\"Asignaturas_" + rowCount + "__Codigo\"" +
                                " name=\"Asignaturas[" + rowCount + "].Codigo\"" +
                                " value=" + clave.text() + ">" +
                            "</td>" +

                            "<td>" +
                                " <input type=text readonly=true class= asLabel" +
                                " id=\"Asignaturas_" + rowCount + "__Seccion\"" +
                                " name=\"Asignaturas[" + rowCount + "].Seccion\"" +
                                "value=\"" + seccion.text() + "\">" +
                            "</td>" +

                            "<td>" +
                                " <input type=text readonly=true class= asLabel" +
                                " id=\"Asignaturas_" + rowCount + "__Creditos\"" +
                                " name=\"Asignaturas[" + rowCount + "].Creditos\"" +
                                "value=\"" + creditos.text() + "\">" +
                            "</td>" +
                            "<td>" +
                                "<input type=text readonly=true class= asLabel style=text-align:left" +
                                " id=\"Asignaturas_" + rowCount + "__Nombre\"" +
                                " name=\"Asignaturas[" + rowCount + "].Nombre\"" +
                                " value=\"" + asignatura.text() + "\">" +
                            "</td>" +

                            "<td>" +
                                "<input type=text readonly=true class= asLabel" +
                                " id=\"Asignaturas_" + rowCount + "__Calificacion\"" +
                                " name=\"Asignaturas[" + rowCount + "].Calificacion\"" +
                                " >" +
                            "</td>" +

                            "<td class=noDisplay>" +
                                "<input type=text readonly=true class= asLabel" +
                                " id=\"Asignaturas_" + rowCount + "__Estatus\"" +
                                " name=\"Asignaturas[" + rowCount + "].Estatus\"" +
                                " value=\"1\">" +
                            "</td>" +
                            "<td class=noDisplay>" +
                                "<input type=text readonly=true class= asLabel" +
                                " id=\"Asignaturas_" + rowCount + "__New\"" +
                                " name=\"Asignaturas[" + rowCount + "].New\"" +
                                " value=\"true\">" +
                            "</td>" +

                        "</tr>";

            result.find('tr').last().after($(html));
            result.find('tr').last().find('td').first().click(function () {
                removeRow($(this));
                var backHtml = "<tr class=ColNormal bgcolor=White style=background-color: rgb(255, 255, 204);>" +
                                "<td>" +
                                    "<a href=\"#\">" +
                                        "<img src=\"../../Content/themes/base/images/delete_icon.gif\"/>" +
                                    "</a>" +
                                "</td>" +
                                "<td>" + clave.text() + "</td>" +
                                "<td>" + seccion.text() + "</td>" +
                                "<td>" + creditos.text() + "</td>" +
                                "<td style=text-align:left;>" + asignatura.text() + "</td>" +
                                "<td> </td>"
                "</tr>";
                table.find('tr').last().after($(backHtml));

                var count = 0;
                $.each(result.find('tr'), function (index, value) {
                    if (index == 0) return;
                    $.each(value.getElementsByTagName('input'), function (iindex, ivalue) {
                        var newId = ivalue.id.replace(/[0-9]+/g, count);
                        var newName = ivalue.name.replace(/[0-9]+/g, count);

                        ivalue.id = newId;
                        ivalue.name = newName;
                    });
                    count++;
                });

                table.find('tr').last().find('td:first').click(addRow);
            });
        }
    }
}

function removeRow(button) {
    console.log(button);
    button.parent().remove();
}

function submitForm(e) {
    document.getElementsByTagName('form')[0].submit();
    e.preventDefault();
}

function AceptarTerminos() {
    $('#termsbody').click(function () {
        if ($(this).attr('checked')) {
            $('#terms').removeAttr('disabled');
        } else {
            $('#terms').attr('disabled','true');
        }
    })
    $('#terms').click(function () {
        $(this).parent().parent().hide();
        $('#mask').hide();
    })
}

function retirarManteria() {
    $('#btnTerminar1').click(function () {
        $('#mask').show();
        $('#dialog1').show();
    });

    $('#btnSalirSin2').click(function () {
        $('#mask').hide();
        $('#dialog1').hide();
    })

    $('#btnTerminar').click(function () {
        $('#dialog1').hide();
        $('#login').show();
    });

    $('#btnLogin').click(function () {
        submitForm();
    });

    $('#btnSalirSin3').click(function () {
        $('#mask').hide();
        $('#login').hide();
    });

}

function enableMessages()
{
    var msgMatricula = $('#msgMatricula');
    var msgID = $('#msgID');
    var txtUsername = $('#txtUserName');
    var txtID = $('#txtID');
    var txtPassword = $('#txtUserPass');

    txtID.mask("9999999");

    txtUsername.focus(function () {
        msgMatricula.show();
        msgID.hide();
    });

    txtID.focus(function () {
        msgMatricula.hide();
        msgID.show();
    })
    
    txtPassword.focus(function () {
        msgMatricula.hide();
        msgID.hide();
    })
}

function getMessages() {
    if ($('#grdAsignatura tr').length > 2) {
        $('#strMessage').text('La(s) siguiente(s) asignaturas han sido formalmente retiradas');
    }
    else {
        $('#strMessage').text('La siguiente asignatura ha sido formalmente retirada');
    }
}

function popitup(value, windowName) {
    if (value) {
        var url = '/Seleccion/Ofertas?codArea=' + value;
        newwindow = window.open(url, null, 'height=500,width=1000,resizable=yes,scrollbars=yes');
    }
    if (window.focus) { newwindow.focus() }
    return false;
}

function salir() {
    var result = confirm('¿Está seguro que quiere salir sin guardar los cambios?');
    if (result) {
        window.location.href = "/Seleccion/SalirSinGuardar?estudiante="+$('#IdEstudiante').html();
    }
}