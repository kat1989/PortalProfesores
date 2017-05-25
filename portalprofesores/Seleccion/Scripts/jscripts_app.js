// -----------------------------------------------------------------------------------------
//
// Diseado por : Paul Goris Rodriguez
// Gerente de Desarrollo
// GC & Asociados, S.A. (Tel. 256-6752)
//
// Modificada por : ?
//
// -----------------------------------------------------------------------------------------
var csIncludeDir = "";
var csFallBackFile = "fallback.js";
var csIE4File = "ie4.js";
var csIE5File = "ie5.js";
var csIE6File = "ie6.js";
var csIE7File = "ie7.js";
var csIE8File = "ie8.js";
var csNN4File = "nn4.js";
var csNN6File = "nn6.js";
var csMoz1File = "moz1.js";
// -----------------------------------------------------------------------------------------
function csBrowserInfo()
{
	var csAppName = String(navigator.appName);
	var csAppVer = String(navigator.appVersion);
	var csPlatform = String(navigator.platform);
	var csUserAgent = String(navigator.userAgent);
	var csVendor = String(navigator.vendor);
	var csProduct = String(navigator.product);
	if(csUserAgent.indexOf("Opera") > -1)
		return 0;
	else if(csUserAgent.indexOf("MSIE 4") > -1 && csPlatform != "MacPPC")
		return 1;
	else if(csUserAgent.indexOf("MSIE 5") > -1)
		return 2;
	else if(csUserAgent.indexOf("MSIE 6") > -1)
		return 5;
	else if(csUserAgent.indexOf("MSIE 7") > -1)
		return 5;
	else if(csUserAgent.indexOf("MSIE 8") > -1)
		return 5;
	else if(csUserAgent.indexOf("MSIE 9") > -1)
		return 5;
	else if(csVendor == "Netscape6")
		return 4;
	else if(csProduct == "Gecko")
		return 6;
	else if(csAppName == "Netscape")
	{
		if(parseFloat(csAppVer) >= 4.06 && parseFloat(csAppVer) < 5)
			return 3;
		else
			return 0;
	}
	else
		return 0;
}
// -----------------------------------------------------------------------------------------
var csBrowserType = csBrowserInfo();
document.write("<script language=\"JavaScript\" type=\"text/javascript\" src=\"");
if(csBrowserType == 0)
	document.write(csIncludeDir + "/" + csFallBackFile);
else if(csBrowserType == 1)
	document.write(csIncludeDir + "/" + csIE4File);
else if(csBrowserType == 2)
	document.write(csIncludeDir + "/" + csIE5File);
else if(csBrowserType == 3)
	document.write(csIncludeDir + "/" + csNN4File);
else if(csBrowserType == 4)
	document.write(csIncludeDir + "/" + csNN6File);
else if(csBrowserType == 5)
	document.write(csIncludeDir + "/" + csIE6File);
else if(csBrowserType == 6)
	document.write(csIncludeDir + "/" + csMoz1File);
else
	document.write(csIncludeDir + "/" + csFallBackFile);
document.write("\"></script>");
// -----------------------------------------------------------------------------------------
function MakAyuda(titulo,nombre) {
  document.write("<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\" height=\"10\"><tr>");
  document.write("<td valign=\"center\"  class=\"OpcTopMenu\" nowrap=\"nowrap\">"+titulo+"<td>");
  document.write("<td valign=\"center\" align=\"right\">");
  document.write("<img style=\"CURSOR: hand\" onclick=\"javascript:ScrAyuda('"+nombre+"')\" height=\"16\" alt=\"Ayuda/Información de la Página\" src=\"/appsee.net/images/help.gif\" border=\"0\"/>"); 
  document.write("</td></tr></table>");
}
function ScrAyuda(pagina) {
  pagina = '../help/'+pagina+'.htm';
  window.showModalDialog(pagina,pagina,'dialogHeight:480px;dialogWidth:640px;center');
}
// -----------------------------------------------------------------------------------------
function VVoluntario() {
  if (document.forms[0].comVoluntarioConyugeId.value == '0') {
    window.document.forms[0].comVoluntarioConyugeId.value = window.document.forms[0].comVoluntarioId.value;
  }
}
// -----------------------------------------------------------------------------------------
function ZProgramaCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomProgramaCodigo.aspx?tipo=' + tipo,'BuscarProgramaCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZAsignaturaCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomAsignaturaCodigo.aspx?tipo=' + tipo,'BuscarAsignaturaCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
function Zaviso(pagina) {
 pagina = './avisos/'+pagina+'.html';
  window.open(pagina,'avisos','width=600px, height=600px, help=no, resizable=no, status=no, scrollbars=yes');
}

// -----------------------------------------------------------------------------------------
function ZAsignaturaAnterior(tipo) {
  window.open('/appintec.net/zoom/ZoomAsignaturaAnterior.aspx?tipo=' + tipo,'BuscarAsignaturaAnterior','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZAulaCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomAulaCodigo.aspx?tipo=' + tipo,'BuscarAulaCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZProgramaDescripcion(tipo) {
  window.open('/appintec.net/zoom/ZoomProgramaDescripcion.aspx?tipo=' + tipo,'BuscarProgramaDescripcion','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZProvinciaCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomProvinciaCodigo.aspx?tipo=' + tipo,'BuscarProvinciaCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZProgramaGrupo(tipo) {
  window.open('/appintec.net/zoom/ZoomProgramaGrupo.aspx?tipo=' + tipo,'BuscarProgramaGrupo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZMunicipioCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomMunicipioCodigo.aspx?tipo=' + tipo,'BuscarMunicipioCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZCiudadCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomCiudadCodigo.aspx?tipo=' + tipo,'BuscarCiudadCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZPaisCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomPaisCodigo.aspx?tipo=' + tipo,'BuscarPaisCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZSectorCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomSectorCodigo.aspx?tipo=' + tipo,'BuscarSectorCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZCodigoProfesor(tipo) {
  window.open('/appintec.net/zoom/ZoomCodigoProfesor.aspx?tipo=' + tipo,'BuscarCodigoProfesor','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZEstudiante(tipo) {
  window.open('/appintec.net/zoom/ZoomEstudiante.aspx?tipo=' + tipo,'BuscarEstudiante','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZEmpresaCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomEmpresaCodigo.aspx?tipo=' + tipo,'BuscarEmpresaCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZInstitucionCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomInstitucionCodigo.aspx?tipo=' + tipo,'BuscarInstitucionCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZCuenta(tipo) {
  window.open('/appintec.net/zoom/ZoomNumeroCuenta.aspx?tipo=' + tipo,'BuscarNumeroCuenta','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZCodigoEmpleado(tipo) {
  window.open('/appintec.net/zoom/ZoomCodigoEmpleado.aspx?tipo=' + tipo,'BuscarCodigoEmpleado','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZCentroCodigo(tipo) {
  window.open('/appintec.net/zoom/ZoomCentroCodigo.aspx?tipo=' + tipo,'BuscarCentroCodigo','width=700px, height=500px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZCodigoEmpleadosActivos(tipo) {
  window.open('/appintec.net/zoom/ZoomCodigoEmpleadosActivos.aspx?tipo=' + tipo,'BuscarCodigoEmpleadosActivos','width=520px, height=420px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
function ZCodigoDepartamento(tipo) {
  window.open('/appintec.net/zoom/ZoomCodigoDepartamento.aspx?tipo=' + tipo,'BuscarCodigoDepartamento','width=520px, height=420px, help=no, resizable=no, status=yes, scrollbars=yes');
}
// -----------------------------------------------------------------------------------------
