<!-- Colores
// #6f6a5c = #ffffff
// #000000 = #e01a22 // TEST COLOR #24248C
// #DDD4AB = #3a0a0b
// #808080 = gris
// obj.borderTopColor = "#ffffff"
// borderLeftColor = "#ffffff"
// obj.borderBottomColor = "#ffffff"
// borderRightColor = "#ffffff"
<!--
/////////////////////////////////////////////////
// Coalesys WebMenu Studio IE4 DHTML script
// Build 67 COPYRIGHT 2000-2002 Coalesys, Inc.
/////////////////////////////////////////////////
var gcDetectedBrowser = 'IE4DHTML';var gcMBZ=false;var gcCSDS=false;var gcOM="document.all.";var gcBgCo=".style.backgroundColor";var gcCo=".style.color";var gcDi=".style.display";var gcTI="";var gcClkd=-1;var gcPI=new Array();var gcPx=new Array();var gcPy=new Array();var gcNH=new Array();var gcPW=0;var gcPH=0;var gcSPnt="";var gcDir="";var gcMB=0;var gcSI="";var gcSE=new Object();var gcSEL=0;var gcSET=0;var gcSEH=0;var gcSEW=0;var gcBW=0;var gcBH=0;var gcAR=0;var gcAB=0;var gcSLA=0;var gcSTA=0;var gcExIS=new Image();gcExIS.src="/appintec.net/images/Popup.gif";var gcExdIS=new Image();gcExdIS.src="/appintec.net/images/Popup.gif";var gcCTH=true;var gcXOff=0;var gcYOff=0;var gcFP=0;var gcSTI=0;function gcT(ms){if(ms!="off"){if(gcCTH!=0){gcTI=setTimeout("gcHP(0);",ms);}}else{clearTimeout(gcTI);}}function gcST(l,g,i){if(i){gcSTI = setTimeout("gcHP("+l+");gcSP("+g+",'"+i+"');",350);}else if(l){gcSTI = setTimeout("gcHP("+l+");",350);}else{clearTimeout(gcSTI);}}function gcShow(id,srcid,relpos,offsetX,offsetY,fixedpos){clearTimeout(gcTI);if(gcClkd!=id){gcHP(0);gcSI=srcid;gcSPnt=relpos;gcClkd=id;gcDir="right";if(eval(gcOM+"gcPopup"+id)){if(offsetX)gcXOff=offsetX;if(offsetY)gcYOff=offsetY;if(fixedpos)gcFP=fixedpos;gcButtonClickState=true;gcSP(id);}}}function gcHide(){gcTI=setTimeout("gcHP(0);",350);}function gcHiI(id,l){if(!document.all["gcItem"+id]){return;}var bgco;if(document.all['gcItem'+id].getAttribute('gcSelColor')!=null){bgco =  document.all['gcItem'+id].getAttribute('gcSelColor');}else{bgco = false;}
eval(gcOM+"gcItem"+id+gcCo+"=\"#ffffff\""); // Color de la letras del menu

eval(gcOM+"gcExpand"+id+gcCo+"=\"#ffffff\""); // ??

if(bgco){document.all["gcItem"+id].style.backgroundColor=bgco;document.all["gcExpand"+id].style.backgroundColor=bgco;}
else{
	eval(gcOM+"gcItem"+id+gcBgCo+"=\"#e01a22\""); //#3a0a0b
	eval(gcOM+"gcExpand"+id+gcBgCo+"=\"#e01a22\""); //#3a0a0b

}if(document.all['gcIcoOn'+id]){document.all['gcIco'+id].style.display='none';document.all['gcIcoOn'+id].style.display='inline';}if(eval(gcOM+"gcExpandIc"+id)){eval(gcOM+"gcExpandIc"+id+".src=gcExdIS.src");}gcNHM(id,l);gcNH[l-1]=id;}function gcNHM(id,l){if(gcNH[l-1]!=id){var count=l-1;for(count=l-1;count<gcNH.length;count++){gcDiI(gcNH[count]);}gcNH.length=l;}}function gcDiI(id){if(!document.all["gcItem"+id]){return;}var bgco;if(document.all['gcItem'+id].getAttribute('gcUnSelColor')!=null){bgco =  document.all['gcItem'+id].getAttribute('gcUnSelColor');}else{bgco = false;}

eval(gcOM+"gcItem"+id+gcCo+"=\"#ffffff\""); // Color letra luego de mover cursor por la opcion del menu

eval(gcOM+"gcExpand"+id+gcCo+"=\"#ffffff\""); // ??

if(bgco){document.all["gcItem"+id].style.backgroundColor=bgco;document.all["gcExpand"+id].style.backgroundColor=bgco;}else{eval(gcOM+"gcItem"+id+gcBgCo+"=\"\"");eval(gcOM+"gcExpand"+id+gcBgCo+"=\"\"");}if(document.all['gcIcoOn'+id]){document.all['gcIcoOn'+id].style.display='none';document.all['gcIco'+id].style.display='inline';}if(eval(gcOM+"gcExpandIc"+id)){eval(gcOM+"gcExpandIc"+id+".src=gcExIS.src");}}function gcSP(id,itemid){if(!itemid){if(gcFP){gcSEL=gcXOff;gcSET=gcYOff;gcSEH=1;gcSEW=1;gcFP=0;}else{if(!document.all[gcSI]){return;}gcSE=new Object(eval(gcOM+gcSI));var gcPrO=gcSE;var gcPrT="";gcSEL=gcSE.offsetLeft+gcXOff;gcSET=gcSE.offsetTop+gcYOff;gcSEH=gcSE.offsetHeight;gcSEW=gcSE.offsetWidth;while(gcPrT!="BODY"){gcPrO=gcPrO.offsetParent;gcSEL+=gcPrO.offsetLeft;gcSET+=gcPrO.offsetTop;gcPrT=gcPrO.tagName;}}eval(gcOM+"gcPopup"+id+".style.width=1");eval(gcOM+"gcPopup"+id+".style.height=1");eval(gcOM+"gcPopup"+id+gcDi+"=\"block\"");gcPW=eval(gcOM+"gcPopup"+id+".clientWidth");gcPH=eval(gcOM+"gcPopup"+id+".clientHeight");gcBW=document.body.clientWidth;gcBH=document.body.clientHeight;gcSLA=document.body.scrollLeft;gcSTA=document.body.scrollTop;switch(gcSPnt){case "above":gcPx[gcPx.length]=gcSEL;gcPy[gcPy.length]=gcSET-gcPH;gcCA();gcCR();break;case "below":gcPx[gcPx.length]=gcSEL;gcPy[gcPy.length]=gcSET+gcSEH;gcCB();gcCR();break;case "right":gcPx[gcPx.length]=gcSEL+gcSEW;gcPy[gcPy.length]=gcSET;gcCR();gcCB();break;case "left":gcPx[gcPx.length]=gcSEL-gcPW;gcPy[gcPy.length]=gcSET;gcCL();gcCB();gcDir="left";break;}gcXOff=0;gcYOff=0;eval(gcOM+"gcPopup"+id+".style.left=gcPx[gcPx.length-1]");eval(gcOM+"gcPopup"+id+".style.top=gcPy[gcPy.length-1]");gcPI[gcPI.length]=id;}else{gcPx[gcPx.length]=eval(gcOM+"gcPopup"+gcPI[gcPI.length-1]+".clientWidth")+gcPx[gcPx.length-1]-4;var szPrE="";if(document.all["gcItem"+itemid].offsetParent.offsetTop==0){if(document.all["gcItem"+itemid].offsetParent.offsetParent.offsetParent.offsetParent.className!="gcPopupBox"){var szPrE="offsetParent.offsetParent.offsetParent.";}}gcPy[gcPy.length]=eval(gcOM+"gcItem"+itemid+".offsetParent."+szPrE+"offsetTop")+gcPy[gcPy.length-1];eval(gcOM+"gcPopup"+id+".style.width=1");eval(gcOM+"gcPopup"+id+".style.height=1");eval(gcOM+"gcPopup"+id+gcDi+"=\"block\"");gcPW=eval(gcOM+"gcPopup"+id+".clientWidth");gcPH=eval(gcOM+"gcPopup"+id+".clientHeight");var gcPrW=eval(gcOM+"gcPopup"+gcPI[gcPI.length-1]+".clientWidth");gcAR=gcBW-gcPx[gcPx.length-1]+gcSLA;gcAB=gcBH-gcPy[gcPy.length-1]+gcSTA;if(gcPx[gcPx.length-2]==gcSLA){gcDir="right";}if((gcAR<gcPW)||(gcDir=="left")){gcMB=(gcPx[gcPx.length-1]-gcPW-gcPrW)+8;if((gcMB>=0)&&(gcMB>gcSLA)){gcDir="left";}else{gcMB=gcSLA;}gcPx[gcPx.length-1]=gcMB;}if(gcAB<gcPH){gcMB=gcPy[gcPy.length-1]-(gcPH-gcAB);if(gcMB<0){gcMB=gcSTA;}gcPy[gcPy.length-1]=gcMB;}eval(gcOM+"gcPopup"+id+".style.left=gcPx[gcPx.length-1]");eval(gcOM+"gcPopup"+id+".style.top=gcPy[gcPy.length-1]");gcPI[gcPI.length]=id;}}function gcHP(level){if(gcClkd==-1){return false;}else if(level==0){gcClkd=-1;var id = gcPI[0];var count=0;for(count=0;count<gcNH.length;count++){gcDiI(gcNH[count]);}gcNH.length=0;gcButtonNormal("gcMenuButton"+id);gcButtonClickState=false;}var count=level;for(count=level;count<gcPI.length;count++){eval(gcOM+"gcPopup"+gcPI[count]+gcDi+"=\"none\"");}gcPI.length=level;gcPx.length=level;gcPy.length=level;}function gcCR(){gcAR=(gcBW+gcSLA)-gcPx[gcPx.length-1];if(gcAR<gcPW){if(gcSPnt=="below"||gcSPnt=="above"){gcMB=gcPx[gcPx.length-1]-(gcPW-gcAR);if(gcMB<0||gcMB<gcSLA){gcMB=gcSLA;}gcPx[gcPx.length-1]=gcMB;}else{gcMB=gcSEL-gcPW;if(gcMB>=0){gcPx[gcPx.length-1]=gcMB;}}}}function gcCL(){if(gcPx[gcPx.length-1]<(gcSLA)){gcPx[gcPx.length-1]=gcSEL+gcSEW;gcCR();}}function gcCB(){gcAB=(gcBH+gcSTA)-gcPy[gcPy.length-1];if(gcAB<gcPH){if(gcSPnt=="below"){gcMB=gcPy[gcPy.length-1]-gcPH-gcSEH;if(gcMB>=0){gcPy[gcPy.length-1]=gcMB;}}else{gcMB=gcPy[gcPy.length-1]-(gcPH-gcAB);if(gcMB<0||gcMB<gcSTA){gcMB=gcSTA;}gcPy[gcPy.length-1]=gcMB;}}}function gcCA(){if(gcPy[gcPy.length-1]<(gcSTA)){gcPy[gcPy.length-1]=gcSET+gcSEH;gcCB();}}function gcHideSelectBox(){}function gcShowInFrame(MenuID,x,y){x+=document.body.scrollLeft;y+=document.body.scrollTop;gcShow(MenuID,'','below',x,y,1);}function gcRefresh(){}var gcButtonClickState=false;var gcCurrentButtonId;var gcButtonsObj;var gcNeedPosInit=true;var gcTop=10;var gcLeft=10;function gcButtonDown(id,gid){gcCurrentButtonId=id;gcButtonSunken(id);gcShow(gid, id, 'below', 2, 2);}function gcButtonSelect(id,gid){if(!gcButtonClickState){gcButtonRaised(id);}else{gcButtonNormal(gcCurrentButtonId);clearTimeout(gcTI);gcButtonDown(id,gid);}}function gcButtonUnSelect(id){if(!gcButtonClickState){gcButtonNormal(id);}else{gcHide();}}function gcButtonRaised(id){var obj = document.all(id).style;obj.borderTopColor = "#ffffff";obj.borderLeftColor = "#ffffff";obj.borderBottomColor = "#808080";obj.borderRightColor = "#808080";obj.backgroundColor = "";obj.paddingBottom = "4px";obj.paddingTop = "4px";obj.paddingLeft = "6px";obj.paddingRight = "6px";
obj.backgroundColor =  "#e01a22"; //Color fondo menu principal mouseover

}function gcButtonSunken(id){var obj = document.all(id).style;obj.borderTopColor = "#808080";obj.borderLeftColor = "#808080";obj.borderBottomColor = "#ffffff";obj.borderRightColor = "#ffffff";obj.backgroundColor = "";obj.paddingBottom = "3px";obj.paddingTop = "5px";obj.paddingLeft = "7px";obj.paddingRight = "5px";obj.color = "#ffffff";}function gcButtonNormal(id){var obj = document.all(id).style;obj.borderTopColor = "";obj.borderLeftColor = "";obj.borderBottomColor = "";obj.borderRightColor = "";obj.backgroundColor = "";obj.paddingBottom = "4px";obj.paddingTop = "4px";obj.paddingLeft = "6px";obj.paddingRight = "6px";obj.color = "#ffffff";}function gcMenuBarInit(){}
//-->