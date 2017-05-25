<!-- Colores
// #6f6a5c = #ffffff
// #000000 = #e01a22
// #DDD4AB = #3a0a0b
// #808080 = gris
// obj.borderTopColor = "#ffffff"
// borderLeftColor = "#ffffff"
// obj.borderBottomColor = "#ffffff"
// borderRightColor = "#ffffff"
<!--
////////////////////////////////////////////////////
// Coalesys WebMenu Studio NN6/Moz1 DHTML script
// Build 67 COPYRIGHT 2000-2002 Coalesys, Inc.
/////////////////////////////////////////////////////
var gcDetectedBrowser = 'Moz1DHTML';var gcMBZ=false;var gcCSDS=false;var gcTI="";var gcClkd=-1;var gcPI=new Array();var gcPL=new Array();var gcPT=new Array();var gcNH=new Array();var gcPW=0;var gcPH=0;var gcSPnt="";var gcDir="";var gcMB=0;var gcSI="";var gcSE=new Object();var gcSEL=0;var gcSET=0;var gcSEH=0;var gcSEW=0;var gcBW=0;var gcBH=0;var gcAR=0;var gcAB=0;var gcSLA=0;var gcSTA=0;var gcExIS=new Image();gcExIS.src="/appintec.net/images/Popup.gif";var gcExdIS=new Image();gcExdIS.src="/appintec.net/images/Popup.gif";var gcCTH=true;var gcXOff=0;var gcYOff=0;var gcFP=0;var gcSTI=0;function gcT(ms){if(ms!="off"){if(gcCTH!=0){gcTI=setTimeout("gcHP(0);",ms);}}else{clearTimeout(gcTI);}}function gcST(l,g,i){if(i){gcSTI = setTimeout("gcHP("+l+");gcSP("+g+",'"+i+"');",350);}else if(l){gcSTI = setTimeout("gcHP("+l+");",350);}else{clearTimeout(gcSTI);}}function gcShow(id,srcid,relpos,offsetX,offsetY,fixedpos){clearTimeout(gcTI);if(gcClkd!=id){gcHP(0);gcSI=srcid;gcSPnt=relpos;gcClkd=id;gcDir="right";if(document.getElementById("gcPopup"+id)){if(offsetX)gcXOff=offsetX;if(offsetY)gcYOff=offsetY;if(fixedpos)gcFP=fixedpos;gcButtonClickState=true;gcSP(id);}}}function gcHide(){gcTI=setTimeout("gcHP(0);",350);}function gcHiI(id,l){if(!document.getElementById("gcItem"+id)){return;}var bgco;try{bgco =  document.getElementById("gcItem"+id).getAttribute('gcSelColor');}catch(e){bgco = false;}if(document.getElementById("gcIcoOn"+id)){document.getElementById("gcIcoOn"+id).style.display="inline";document.getElementById("gcIco"+id).style.display="none";}

document.getElementById("gcItem"+id).style.color="#ffffff"; // Color de la letras del menu 
document.getElementById("gcExpand"+id).style.color="#ffffff";  // ??

	if(bgco)
	{
		document.getElementById("gcItem"+id).style.backgroundColor=bgco;
		document.getElementById("gcExpand"+id).style.backgroundColor=bgco;
	}
	else
	{
		document.getElementById("gcItem"+id).style.backgroundColor= "#e01a22";/*"#3a0a0b";*/
		
		document.getElementById("gcItem"+id).style.color= "#3a0a0b";/*"#3a0a0b";*/ // Color para la letra mouseover menu
		
		document.getElementById("gcExpand"+id).style.backgroundColor="#e01a22";
	}
	if(document.getElementById("gcExpandIc"+id)){document.getElementById("gcExpandIc"+id).src=gcExdIS.src;}gcNHM(id,l);gcNH[l-1]=id;}function gcNHM(id,l){if(gcNH[l-1]!=id){var count=l-1;for(count=l-1;count<gcNH.length;count++){gcDiI(gcNH[count]);}gcNH.length=l;}}function gcDiI(id,bgco){if(!document.getElementById("gcItem"+id)){return;}var bgco;try{bgco =  document.getElementById("gcItem"+id).getAttribute('gcUnSelColor');}catch(e){bgco = false;}if(document.getElementById("gcIcoOn"+id)){document.getElementById("gcIco"+id).style.display="inline";document.getElementById("gcIcoOn"+id).style.display="none";}

document.getElementById("gcItem"+id).style.color="#ffffff"; // Color letra luego de mover cursor por la opcion del menu
document.getElementById("gcExpand"+id).style.color="#ffffff"; //??

if(bgco){document.getElementById("gcItem"+id).style.backgroundColor=bgco;document.getElementById("gcExpand"+id).style.backgroundColor=bgco;}else{document.getElementById("gcItem"+id).style.backgroundColor="";document.getElementById("gcExpand"+id).style.backgroundColor="";}if(document.getElementById("gcExpandIc"+id)){document.getElementById("gcExpandIc"+id).src=gcExIS.src;}}function gcSP(id,itemid){if(!itemid){if(gcFP){gcSEL=gcXOff;gcSET=gcYOff;gcSEH=1;gcSEW=1;gcFP=0;}else{if(!document.getElementById(gcSI)){return;}gcSE=new Object(document.getElementById(gcSI));gcSEL=new Number(gcSE.offsetLeft+gcXOff+document.body.offsetLeft);gcSET=new Number(gcSE.offsetTop+gcYOff+document.body.offsetTop);gcSEH=gcSE.offsetHeight;gcSEW=gcSE.offsetWidth;var gcPrO=gcSE;var gcPrT="";if(navigator.productSub<20010726){while(gcPrT!="BODY"){if(gcPrO.style.position == "absolute"){gcSEH-=document.body.offsetTop;gcSEL-=document.body.offsetLeft;break;}gcPrO=gcPrO.parentNode;gcPrT=gcPrO.tagName;}}else{gcSEL=gcSE.offsetLeft+gcXOff;gcSET=gcSE.offsetTop+gcYOff;gcSEH=gcSE.offsetHeight;gcSEW=gcSE.offsetWidth;while(gcPrT!="BODY"){gcPrO=gcPrO.offsetParent;gcSEL+=gcPrO.offsetLeft;gcSET+=gcPrO.offsetTop;gcPrT=gcPrO.tagName;}}}document.getElementById("gcPopup"+id).style.display="inline";gcPW=document.getElementById("gcPopup"+id).offsetWidth;gcPH=document.getElementById("gcPopup"+id).offsetHeight;gcBW=document.width;gcBH=window.innerHeight-15;gcSLA=window.pageXOffset;gcSTA=window.pageYOffset;switch(gcSPnt){case "above":gcPL[gcPL.length]=gcSEL;gcPT[gcPT.length]=gcSET-gcPH;gcCA();gcCR();break;case "below":gcPL[gcPL.length]=gcSEL;gcPT[gcPT.length]=gcSET+gcSEH;gcCB();gcCR();break;case "right":gcPL[gcPL.length]=gcSEL+gcSEW;gcPT[gcPT.length]=gcSET;gcCR();gcCB();break;case "left":gcPL[gcPL.length]=gcSEL-gcPW;gcPT[gcPT.length]=gcSET;gcCL();gcCB();gcDir="left";break;}gcXOff=0;gcYOff=0;document.getElementById("gcPopup"+id).style.left=gcPL[gcPL.length-1];document.getElementById("gcPopup"+id).style.top=gcPT[gcPT.length-1];gcPI[gcPI.length]=id;}else{gcPL[gcPL.length]=document.getElementById("gcPopup"+gcPI[gcPI.length-1]).offsetWidth+gcPL[gcPL.length-1]-4;if(navigator.productSub>20010725){gcPT[gcPT.length]=gcPT[gcPT.length-1];var gcPrO=document.getElementById("gcItem"+itemid);var gcPrT="";while(gcPrT!="gcPopupBox"){gcPT[gcPT.length-1]+=gcPrO.offsetTop;gcPrO=gcPrO.offsetParent;gcPrT=gcPrO.className;}}else{gcPT[gcPT.length]=document.getElementById("gcItem"+itemid).offsetTop;}document.getElementById("gcPopup"+id).style.display="inline";gcPW=document.getElementById("gcPopup"+id).offsetWidth;gcPH=document.getElementById("gcPopup"+id).offsetHeight;var gcPrW=document.getElementById("gcPopup"+gcPI[gcPI.length-1]).offsetWidth;gcAR=gcBW-gcPL[gcPL.length-1]+gcSLA;gcAB=gcBH-gcPT[gcPT.length - 1]+gcSTA;if(gcPL[gcPL.length-2]==gcSLA){gcDir="right";}if((gcAR<gcPW)||(gcDir=="left")){gcMB=(gcPL[gcPL.length-1]-gcPW-gcPrW)+8;if((gcMB>=0)&&(gcMB>gcSLA)){gcDir="left";}else{gcMB=gcSLA;}gcPL[gcPL.length-1]=gcMB;}if(gcAB<gcPH){gcMB=gcPT[gcPT.length-1]-(gcPH-gcAB);if(gcMB<0){gcMB=gcSTA;}gcPT[gcPT.length-1]=gcMB;}document.getElementById("gcPopup"+id).style.left=gcPL[gcPL.length-1];document.getElementById("gcPopup"+id).style.top=gcPT[gcPT.length-1];gcPI[gcPI.length]=id;}}function gcHP(level){if(gcClkd==-1){return false;}else if(level==0){gcClkd=-1;var id = gcPI[0];var count=0;for(count=0;count<gcNH.length;count++){gcDiI(gcNH[count]);}gcNH.length=0;gcButtonNormal("gcMenuButton"+id);gcButtonClickState=false;}var count=level;for(count=level;count<gcPI.length;count++){document.getElementById("gcPopup"+gcPI[count]).style.display="none";}gcPI.length=level;gcPL.length=level;gcPT.length=level;}function gcCR(){gcAR=(gcBW+gcSLA)-gcPL[gcPL.length-1];if(gcAR<gcPW){if(gcSPnt=="below"||gcSPnt=="above"){gcMB=gcPL[gcPL.length-1]-(gcPW-gcAR);if(gcMB<0||gcMB<gcSLA){gcMB=gcSLA;}gcPL[gcPL.length-1]=gcMB;}else{gcMB=gcSEL-gcPW;if(gcMB>=0){gcPL[gcPL.length-1]=gcMB;}}}}function gcCL(){if(gcPL[gcPL.length-1]<(gcSLA)){gcPL[gcPL.length-1]=gcSEL+gcSEW;gcCR();}}function gcCB(){gcAB=(gcBH+gcSTA)-gcPT[gcPT.length-1];if(gcAB<gcPH){if(gcSPnt=="below"){gcMB=gcPT[gcPT.length-1]-gcPH-gcSEH;if(gcMB>=0){gcPT[gcPT.length-1]=gcMB;}}else{gcMB=gcPT[gcPT.length-1]-(gcPH-gcAB);if(gcMB<0||gcMB<gcSTA){gcMB=gcSTA;}gcPT[gcPT.length-1]=gcMB;}}}function gcCA(){if(gcPT[gcPT.length-1]<(gcSTA)){gcPT[gcPT.length-1]=gcSET+gcSEH;gcCB();}}function gcShowInFrame(MenuID,x,y){x+=window.pageXOffset;y+=window.pageYOffset;gcShow(MenuID,'','below',x,y,1);}function gcHideSelectBox(){}function gcRefresh(){}var gcButtonClickState=false;var gcCurrentButtonId;var gcButtonsObj;var gcNeedPosInit=true;var gcTop=10;var gcLeft=10;
function gcButtonDown(id,gid)
{
	gcCurrentButtonId=id;
	gcButtonSunken(id);
	gcShow(gid, id, 'below', 2, 2);
}
function gcButtonSelect(id,gid){if(!gcButtonClickState){gcButtonRaised(id);}else{gcButtonNormal(gcCurrentButtonId);clearTimeout(gcTI);gcButtonDown(id,gid);}}
function gcButtonUnSelect(id)
{
	if(!gcButtonClickState)
	{
		gcButtonNormal(id);
	} 
	else
	{
		gcHide();
	}
}
function gcButtonRaised(id){var obj = document.getElementById(id).style;obj.borderTopColor = "#ffffff";obj.borderLeftColor = "#ffffff";obj.borderBottomColor = "#808080";obj.borderRightColor = "#808080";obj.backgroundColor = "";obj.paddingBottom = "4px";obj.paddingTop = "4px";obj.paddingLeft = "6px";obj.paddingRight = "6px";

obj.backgroundColor =  "#e01a22"; //Color fondo menu principal mouseover

}
function gcButtonSunken(id)
{
	var obj = document.getElementById(id).style;
	obj.borderTopColor = "#808080";
	obj.borderLeftColor = "#808080";
	obj.borderBottomColor = "#ffffff";
	obj.borderRightColor = "#ffffff";
	obj.backgroundColor = ""; /**/
	obj.paddingBottom = "0px";/*"3px";*/
	obj.paddingTop = "5px";
	obj.paddingLeft = "7px";
	obj.paddingRight = "5px";
	obj.color = "#ffffff";}
function gcButtonNormal(id)
{
	var obj = document.getElementById(id).style;
	obj.borderTopColor = "";
	obj.borderLeftColor = "";
	obj.borderBottomColor = "";
	obj.borderRightColor = "";
	obj.backgroundColor = "";
	obj.paddingBottom = "4px";
	obj.paddingTop = "4px";
	obj.paddingLeft = "6px";
	obj.paddingRight = "6px";
	obj.color = "#ffffff";
	}
	function gcMenuBarInit(){}
//-->
