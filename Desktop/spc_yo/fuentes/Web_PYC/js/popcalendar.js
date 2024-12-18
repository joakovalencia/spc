//	written by Tan Ling Wee	on 2 Dec 2001
//	last updated 14 Mayo 2003
//	email : fuushikaden@yahoo.com

//	Modificado por Pablo Rivera G.
//	el 14 de Mayo del 2003


var c_nTilde = unescape("%F1")
var c_aTilde = unescape("%E1")
var c_eTilde = unescape("%E9")
var c_iTilde = unescape("%ED")
var c_oTilde = unescape("%F3")
var c_uTilde = unescape("%FA")
var c_NTilde = unescape("%D1")
var c_ATilde = unescape("%C1")
var c_ETilde = unescape("%C9")
var c_ITilde = unescape("%CD")
var c_OTilde = unescape("%D3")
var c_UTilde = unescape("%DA")

var objPopCalendar = null

function getCalendarInstance()
{
	if (!PopCalInstanceCreated())
	{
		objPopCalendar = new PoPCalCreateCalendarInstance()
	
		if (!objPopCalendar.ns4)
		{
			if (objPopCalendar.dom)
			{
				document.write ("<div id='CalendarInstanceCreated' Style='display:none'></div>")
				var PopCal = PopCalInstanceCreated()
				if (PopCal)
				{
					if (objPopCalendar.ie)
					{
						PopCal.style.filter="alpha()"
						PopCal.style.filter="blendTrans()"
						
					}
					PopCal.initialized = 0
				}
			}
		}
	}
	return (objPopCalendar)
}

function PoPCalCreateCalendarInstance()
{

	if (!PopCalInstanceCreated())
	{
		this.initCalendar = PopCalInitCalendar
		this.show = PopCalShow
		this.addHoliday = PopCalAddHoliday
		this.formatDate = PopCalFormatDate
		this.forcedToday = PopCalForcedToday
		this.selectWeekendHoliday = PopCalSelectWeekendHoliday

		this.startAt = 0 // 0 - sunday, 1 - monday
		this.showWeekNumber = 0 // 0 - don't show, 1 - show
		this.showToday = 1 // 0 - don't show, 1 - show
		this.showWeekend = 0  // 0 - don't show, 1 - show
		this.showHolidays = 1 // 0 - don't show, 1 - show
		this.selectWeekend = 1 // 0 - don't Select, 1 - Select
		this.selectHoliday = 1 // 0 - don't Select, 1 - Select
		this.addCarnival = 0 // 0 - don't Add, Add to Holiday (Tuesday)
		this.addGoodFriday = 0 // 0 - don't Add, Add to Holiday
		this.language = 0 // 0 - Spanish, 1 - English
		this.defaultFormat = "dd-mm-yyyy" //Default Format
		this.fixedX = -1 // x position (-1 if to appear below control)
		this.fixedY = -1 // y position (-1 if to appear below control)
		this.fade = 0 // 0 - don't fade, .1 to 1 - fade (Only IE) 
		this.shadow = 0 // 0  - don't shadow, 1 - shadow
		this.move = 0  // 0  - don't move, 1 - move
		this.saveMovePos = 0  // 0  - don't save, 1 - save
		this.centuryLimit = 40 // 1940 - 2039
		this.GXLink = 0
		
		this.showEndOfWeek = null // compatibility version 2.0
		this.selectEndOfWeek = null // compatibility version 2.0
		this.executeFade = true
		this.forceTodayTo = null
		this.forceTodayFormat = null
		this.overWriteSelectWeekend = null
		this.overWriteSelectHoliday = null
		this.overWriteWeekend = null
		this.overWriteHoliday = null
		//this.imgDir = "../../images/" // directory for images ... e.g. var imgDir="/img/"
		this.imgDir = (typeof(rutaImg)=="undefined" ? '' : rutaImg) + "../img/";
		this.gotoString = ""
		this.todayString = ""
		this.weekString = ""
		this.scrollLeftMessage = ""
		this.scrollRightMessage = ""
		this.selectMonthMessage = ""
		this.selectYearMessage = ""
		this.selectDateMessage = ""

		this.crossobj = null
		this.crossShadowRObj = null
		this.crossShadowBObj = null
		this.crossMonthObj = null
		this.crossYearObj = null
		this.monthSelected = null
		this.yearSelected = null
		this.dateSelected = null
		this.omonthSelected = null
		this.oyearSelected = null
		this.odateSelected = null
		this.monthConstructed = null
		this.yearConstructed = null
		this.intervalID1 = null
		this.intervalID2 = null
		this.timeoutID1 = null
		this.timeoutID2 = null
		this.timeoutID3 = null
		this.ctlToPlaceValue = null
		this.ctlNow = null
		this.dateFormat = null
		this.nStartingYear = null
		this.onKeyPress = null
		this.onClick = null
		this.onSelectStart = null
		this.onContextMenu = null
		this.onmousemove = null
		this.onmouseup = null
		this.onresize = null

		this.ie = document.all
		this.dom = document.getElementById
		this.ns4 = document.layers
		this.ieVersion = 0
		var ms = navigator.appVersion.indexOf("MSIE")
		if (ms>0)
		{
			this.ieVersion = parseFloat(navigator.appVersion.substring(ms+5, ms+8))
		}
	
		this.dateFrom = 01
		this.monthFrom = 00
		this.yearFrom = 1900

		this.dateUpTo = 31
		this.monthUpTo = 11
		this.yearUpTo = 2099

		this.oDate = null
		this.oMonth = null
		this.oYear = null

		this.countMonths = 12

		this.today = null
		this.dayNow = 0
		this.dateNow = 0
		this.monthNow = 0
		this.yearNow = 0
		
		this.defaultX = 0
		this.defaultY = 0

		this.keepMonth = false
		this.keepYear = false
		this.bShow = false

		this.HalfYearList = 5

		this.HolidaysCounter = 0
		this.Holidays = new Array()
		this.movePopCal = false
		this.styleAnchor="text-decoration:none;color:black;cursor:default;"
		this.styleLightBorder="border-style:solid;border-width:1px;border-color:#a0a0a0;"
		this.commandExecute = null
		
	}
}

function PopCalInitCalendar()
{
	var PopCal=PopCalInstanceCreated()

	if (PopCal)
	{
		if (PopCal.initialized==0)
		{
			if ((objPopCalendar.language > 1) || (objPopCalendar.language < 0))
			{
				objPopCalendar.language = 0
			}
			if (objPopCalendar.showEndOfWeek!=null) // compatibility
			{
				objPopCalendar.showWeekend = objPopCalendar.showEndOfWeek
			}
			if (objPopCalendar.selectEndOfWeek!=null) // compatibility
			{
				objPopCalendar.selectWeekend = objPopCalendar.selectEndOfWeek
			}

			if ((objPopCalendar.centuryLimit < 0) || (objPopCalendar.centuryLimit > 99))
			{
				objPopCalendar.centuryLimit = 40
			}

			document.write ("<div id='popupSuperShadowRight' style='z-index:+999;position:absolute;top:0;left:0;font-size:10px;width:10;visibility:hidden;background-color:black;'></div>")

			document.write ("<div id='popupSuperShadowBottom' style='z-index:+999;position:absolute;top:0;left:0;font-size:10px;height:10;visibility:hidden;background-color:black'></div>")

			document.write ("<div id='popupSuperCalendar' onclick='PopCalDownMonth();PopCalDownYear();objPopCalendar.bShow=true;' style='z-index:+999;position:absolute;top:0;left:0;visibility:hidden;background-color:#ffffff'><table id='popupSuperHighLight' width="+((objPopCalendar.showWeekNumber==1)?250:220)+" style='font-family:arial;font-size:11px;border-width:1;border-style:solid;border-color:#a0a0a0;font-family:arial; font-size:11px}' bgcolor='#ffffff'><tr bgcolor='#D91623'><td Style='cursor:default'><table width='"+((objPopCalendar.showWeekNumber==1)?248:218)+"'><tr><td style='padding:2px;font-family:arial; font-size:11px;cursor:default'><font color='#ffffff'><B><span id='popupSuperCaption'></span></B></font></td><td id='popupSuperMoveCalendar' width='1px'></td><td align=right Style='cursor:default'><a onClick='PopCalHideCalendar()'><IMG SRC='"+objPopCalendar.imgDir+"close.gif' WIDTH='15' HEIGHT='13' BORDER='0'></a></td></tr></table></td></tr><tr><td style='padding:5px;cursor:default' bgcolor=#ffffff><span id='popupSuperContent'></span></td></tr>")

			if (objPopCalendar.showToday==1)
			{
				document.write ("<tr bgcolor=#f0f0f0><td style='padding:5px;cursor:default' align=center><span id='popupSuperToday'></span></td></tr>")
			}

			document.write ("</table></div>") 
			document.write ("<div id='popupSuperMonth' style='z-index:+999;position:absolute;top:0;left:0;display:none;' onclick='objPopCalendar.bShow=true;'></div>")
			document.write ("<div id='popupSuperYear' style='z-index:+999;position:absolute;top:0;left:0;display:none;' onclick='objPopCalendar.bShow=true;' onMouseWheel='PopCalWheelYear()'></div>")

			if (objPopCalendar.language == 0)
			{

				objPopCalendar.monthName = new Array("Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre")

				if (objPopCalendar.startAt==0)
				{
					objPopCalendar.dayName = new Array ("Domingo","Lunes","Martes","Mi" + c_eTilde + "rcoles","Jueves","Viernes","Sabado")
				}
				else
				{
					objPopCalendar.dayName = new Array ("Lunes","Martes","Mi" + c_eTilde + "rcoles","Jueves","Viernes","Sabado","Domingo")
				}

				objPopCalendar.gotoString = "Mes Actual"
				objPopCalendar.weekString = "Sem"
				objPopCalendar.scrollLeftMessage = "Mes Anterior. Presionar el boton del mouse para ir autom" + c_aTilde + "ticamente."
				objPopCalendar.scrollRightMessage = "Mes Siguiente. Presionar el boton del mouse para ir autom" + c_aTilde + "ticamente."
				objPopCalendar.selectMonthMessage = "Seleccionar Mes."
				objPopCalendar.selectYearMessage = "Seleccionar A" + c_nTilde + "o."
				objPopCalendar.selectDateMessage = "Seleccionar [date] ." // do not replace [date], it will be replaced by date.

			}
			else
			{
				objPopCalendar.monthName = new Array("January","February","March","April","May","June","July","August","September","October","November","December")

				if (objPopCalendar.startAt==0)
				{
					objPopCalendar.dayName = new Array ("Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday")
				}
				else
				{
					objPopCalendar.dayName = new Array ("Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday")
				}

				objPopCalendar.gotoString = "Current Month"
				objPopCalendar.weekString = "Week"
				objPopCalendar.scrollLeftMessage = "Previous Month."
				objPopCalendar.scrollRightMessage = "Next Month."
				objPopCalendar.selectMonthMessage = "Select Month."
				objPopCalendar.selectYearMessage = "Select Year."
				objPopCalendar.selectDateMessage = "Select [date] ." // do not replace [date], it will be replaced by date.
			}

			objPopCalendar.today = new Date()

			if (objPopCalendar.forceTodayTo!=null)
			{
				if (objPopCalendar.forceTodayFormat==null)
				{
					objPopCalendar.forceTodayFormat = objPopCalendar.defaultFormat
				}
				
				if (PopCalSetDMY(objPopCalendar.forceTodayTo, objPopCalendar.forceTodayFormat))
				{
					objPopCalendar.today = new Date(objPopCalendar.oYear, objPopCalendar.oMonth, objPopCalendar.oDate)
				}
			}

			objPopCalendar.dayNow = objPopCalendar.today.getDay()
			objPopCalendar.dateNow = objPopCalendar.today.getDate()
			objPopCalendar.monthNow = objPopCalendar.today.getMonth()
			objPopCalendar.yearNow = objPopCalendar.today.getFullYear()

			if (objPopCalendar.language == 0)
			{
				objPopCalendar.todayString = "Hoy es " + objPopCalendar.dayName[(objPopCalendar.dayNow-objPopCalendar.startAt==-1)?6:(objPopCalendar.dayNow-objPopCalendar.startAt)]+ ", " + objPopCalendar.dateNow + " de " + objPopCalendar.monthName[objPopCalendar.monthNow] + " de " + objPopCalendar.yearNow
			}
			else
			{
				objPopCalendar.todayString = "Today is " + objPopCalendar.dayName[(objPopCalendar.dayNow-objPopCalendar.startAt==-1)?6:(objPopCalendar.dayNow-objPopCalendar.startAt)]+ ", " + objPopCalendar.monthName[objPopCalendar.monthNow] + " " + objPopCalendar.dateNow + ", " + objPopCalendar.yearNow
			}

			objPopCalendar.crossShadowRObj = (objPopCalendar.dom)?document.getElementById("popupSuperShadowRight").style : objPopCalendar.ie? document.all.popupSuperShadowRight : document.popupSuperShadowRight
			objPopCalendar.crossShadowBObj = (objPopCalendar.dom)?document.getElementById("popupSuperShadowBottom").style : objPopCalendar.ie? document.all.popupSuperShadowBottom : document.popupSuperShadowBottom

			if(objPopCalendar.ie)
			{
				objPopCalendar.crossShadowRObj.filter="alpha(opacity=50)"
				objPopCalendar.crossShadowBObj.filter="alpha(opacity=50)"
			}
			else
			{
				objPopCalendar.crossShadowRObj.MozOpacity=.5
				objPopCalendar.crossShadowBObj.MozOpacity=.5
			}
			
			objPopCalendar.crossobj = (objPopCalendar.dom)?document.getElementById("popupSuperCalendar").style : objPopCalendar.ie? document.all.popupSuperCalendar : document.popupSuperCalendar

			if (objPopCalendar.ie)
			{
				objPopCalendar.crossobj.filter="blendTrans()"
			}

			objPopCalendar.crossMonthObj=(objPopCalendar.dom)?document.getElementById("popupSuperMonth").style : objPopCalendar.ie? document.all.popupSuperMonth : document.popupSuperMonth

			objPopCalendar.crossYearObj=(objPopCalendar.dom)?document.getElementById("popupSuperYear").style : objPopCalendar.ie? document.all.popupSuperYear : document.popupSuperYear

			objPopCalendar.monthConstructed=false
			objPopCalendar.yearConstructed=false

			if (objPopCalendar.showToday==1)
			{
				document.getElementById("popupSuperToday").innerHTML = "<a onmouseover='window.status=\""+objPopCalendar.gotoString+"\"' onmouseout='window.status=\"\"' title='"+objPopCalendar.gotoString+"' style='"+objPopCalendar.styleAnchor+"' onClick='PopCalChangeCurrentMonth();'>" + objPopCalendar.todayString	+ "</a>"
			}

			var sHTML1="<span id='popupSuperSpanLeft' style='border-style:solid;border-width:1;border-color:#CDDCED;cursor:default;' onmouseover='PopCalSwapImage(\"popupSuperChangeLeft\",\"left2.gif\");this.style.borderColor=\"#FFFFFF\";window.status=\""+objPopCalendar.scrollLeftMessage+"\"' onclick='PopCalDecMonth()' onmouseout='clearInterval(objPopCalendar.intervalID1);PopCalSwapImage(\"popupSuperChangeLeft\",\"left1.gif\");this.style.borderColor=\"#8AB0D7\";window.status=\"\"' onmousedown='clearTimeout(objPopCalendar.timeoutID1);objPopCalendar.timeoutID1=setTimeout(\"PopCalStartDecMonth()\",100)' onmouseup='clearTimeout(objPopCalendar.timeoutID1);clearInterval(objPopCalendar.intervalID1)'>&nbsp<IMG id='popupSuperChangeLeft' SRC='"+objPopCalendar.imgDir+"left1.gif' width=10 height=11 BORDER=0>&nbsp</span>&nbsp;"
			sHTML1+="<span id='popupSuperSpanRight' style='border-style:solid;border-width:1;border-color:#CDDCED;cursor:default;' onmouseover='PopCalSwapImage(\"popupSuperChangeRight\",\"right2.gif\");this.style.borderColor=\"#FFFFFF\";window.status=\""+objPopCalendar.scrollRightMessage+"\"' onmouseout='clearInterval(objPopCalendar.intervalID1);PopCalSwapImage(\"popupSuperChangeRight\",\"right1.gif\");this.style.borderColor=\"#8AB0D7\";window.status=\"\"' onclick='PopCalIncMonth()' onmousedown='clearTimeout(objPopCalendar.timeoutID1);objPopCalendar.timeoutID1=setTimeout(\"PopCalStartIncMonth()\",100)'	onmouseup='clearTimeout(objPopCalendar.timeoutID1);clearInterval(objPopCalendar.intervalID1)'>&nbsp<IMG id='popupSuperChangeRight' SRC='"+objPopCalendar.imgDir+"right1.gif' width=10 height=11 BORDER=0>&nbsp</span>&nbsp"
			sHTML1+="<span id='popupSuperSpanMonth' style='border-style:solid;border-width:1;border-color:#CDDCED;cursor:default;' onmouseover='PopCalSwapImage(\"popupSuperChangeMonth\",\"drop2.gif\");this.style.borderColor=\"#FFFFFF\";window.status=\""+objPopCalendar.selectMonthMessage+"\"' onmouseout='PopCalSwapImage(\"popupSuperChangeMonth\",\"drop1.gif\");this.style.borderColor=\"#8AB0D7\";window.status=\"\"' onclick='objPopCalendar.keepMonth=!PopCalIsVisible(objPopCalendar.crossMonthObj);PopCalUpMonth()'></span>&nbsp;"
			sHTML1+="<span id='popupSuperSpanYear' style='border-style:solid;border-width:1;border-color:#CDDCED;cursor:default;' onmouseover='PopCalSwapImage(\"popupSuperChangeYear\",\"drop2.gif\");this.style.borderColor=\"#FFFFFF\";window.status=\""+objPopCalendar.selectYearMessage+"\"'	onmouseout='PopCalSwapImage(\"popupSuperChangeYear\",\"drop1.gif\");this.style.borderColor=\"#8AB0D7\";window.status=\"\"' onclick='objPopCalendar.keepYear=!PopCalIsVisible(objPopCalendar.crossYearObj);PopCalUpYear()' onMouseWheel='PopCalWheelYear()'></span>&nbsp;"

			document.getElementById("popupSuperCaption").innerHTML = sHTML1

			if (objPopCalendar.ie)
			{
				if (objPopCalendar.move == 1)
				{
					document.getElementById("popupSuperMoveCalendar").width="100%"
					document.getElementById("popupSuperMoveCalendar").onmousedown=PopCalDrag
					document.getElementById("popupSuperMoveCalendar").ondblclick=PopCalMoveDefault
					document.getElementById("popupSuperMoveCalendar").onmouseup=PopCalDrop
				}
			}
			PopCalAddRegularHolidays()
			PopCal.startAt = objPopCalendar.startAt
			PopCal.showWeekNumber = objPopCalendar.showWeekNumber
			PopCal.showToday = objPopCalendar.showToday
			PopCal.showWeekend = objPopCalendar.showWeekend
			PopCal.showHolidays = objPopCalendar.showHolidays
			PopCal.selectWeekend = objPopCalendar.selectWeekend
			PopCal.selectHoliday = objPopCalendar.selectHoliday
			PopCal.addCarnival = objPopCalendar.addCarnival
			PopCal.addGoodFriday = objPopCalendar.addGoodFriday
			PopCal.language = objPopCalendar.language
			PopCal.defaultFormat = objPopCalendar.defaultFormat
			PopCal.fixedX = objPopCalendar.fixedX
			PopCal.fixedY = objPopCalendar.fixedY
			PopCal.fade = objPopCalendar.fade
			PopCal.shadow = objPopCalendar.shadow
			PopCal.centuryLimit = objPopCalendar.centuryLimit
			PopCal.move = objPopCalendar.move
			PopCal.saveMovePos = objPopCalendar.saveMovePos
			PopCal.GXLink = objPopCalendar.GXLink

			if(objPopCalendar.ie)
			{
				if (objPopCalendar.ieVersion < 5.5)
				{
					PopCal.fade = 0
				}
			}

			PopCal.initialized = 1
		}
	}
}

function PopCalShow(ctl, format, from, to, execute)
{
	var PopCal=PopCalInstanceCreated()
	var CenturyOn = true

	if (PopCal)
	{
		if (PopCal.initialized==1)
		{
			objPopCalendar.movePopCal = false

			if (objPopCalendar.timeoutID3 != null)
			{
				clearTimeout(objPopCalendar.timeoutID3)
				objPopCalendar.timeoutID3 = null
			}
			if ( objPopCalendar.crossobj.visibility == "hidden" ) 
			{

				objPopCalendar.overWriteSelectWeekend = objPopCalendar.overWriteWeekend
				objPopCalendar.overWriteSelectHoliday = objPopCalendar.overWriteHoliday
				objPopCalendar.overWriteWeekend = null
				objPopCalendar.overWriteHoliday = null

				objPopCalendar.commandExecute = null

				if (execute!=null)
				{
					objPopCalendar.commandExecute = execute
				}

				if (objPopCalendar.ie)
				{
					objPopCalendar.onKeyPress = document.onkeypress
					document.onkeypress = PopCalPressEscape
					if (PopCal.move == 1)
					{
						objPopCalendar.onmousemove = document.onmousemove
						document.onmousemove=PopCalTrackMouse
						objPopCalendar.onmouseup = document.onmouseup
						document.onmouseup=new Function("objPopCalendar.movePopCal=false;")
					}
					objPopCalendar.onresize = window.onresize
					window.onresize = PopCalResizeWindow
				}
				else
				{
					objPopCalendar.onKeyPress = document.onkeyup
					document.captureEvents(Event.KEYUP)
					document.onkeyup = PopCalPressEscape
				}


				objPopCalendar.onClick = document.onclick
				document.onclick = PopCalClickDocumentBody

				if (objPopCalendar.ie)
				{
					objPopCalendar.onSelectStart = document.onselectstart
					document.onselectstart=new Function('return(false);')

					objPopCalendar.onContextMenu = document.oncontextmenu
					document.oncontextmenu=new Function('return(false);')
				}

				objPopCalendar.yearConstructed=false
				objPopCalendar.monthConstructed=false

				objPopCalendar.ctlToPlaceValue = ctl
				objPopCalendar.dateFormat=""

				if (format!=null)
				{
					objPopCalendar.dateFormat = format.toLowerCase()
				}
				else if (PopCal.defaultFormat!=null)
				{
					objPopCalendar.dateFormat = PopCal.defaultFormat.toLowerCase()
				}

				objPopCalendar.dateFrom = 01
				objPopCalendar.monthFrom = 00
				objPopCalendar.yearFrom = 1900
				objPopCalendar.dateUpTo = 31
				objPopCalendar.monthUpTo = 11
				objPopCalendar.yearUpTo = 2099

				objPopCalendar.dateSelected = 0
				objPopCalendar.monthSelected = objPopCalendar.monthNow
				objPopCalendar.yearSelected = objPopCalendar.yearNow

				if (PopCalSetDMY(ctl.value, objPopCalendar.dateFormat))
				{
					objPopCalendar.dateSelected = objPopCalendar.oDate
					objPopCalendar.monthSelected = objPopCalendar.oMonth
					objPopCalendar.yearSelected = objPopCalendar.oYear
				}

				if (from!=null)
				{
					if ((from.toLowerCase() == "hoy") || (from.toLowerCase() == "now"))
					{
						objPopCalendar.dateFrom = objPopCalendar.dateNow
						objPopCalendar.monthFrom = objPopCalendar.monthNow
						objPopCalendar.yearFrom = objPopCalendar.yearNow
					}
					else if (PopCalSetDMY(from, objPopCalendar.dateFormat))
					{
						objPopCalendar.dateFrom = objPopCalendar.oDate
						objPopCalendar.monthFrom = objPopCalendar.oMonth
						objPopCalendar.yearFrom = objPopCalendar.oYear
					}
				}

				if (to!=null)
				{
					if ((to.toLowerCase() == "hoy") || (to.toLowerCase() == "now"))
					{
						objPopCalendar.dateUpTo = objPopCalendar.dateNow
						objPopCalendar.monthUpTo = objPopCalendar.monthNow
						objPopCalendar.yearUpTo = objPopCalendar.yearNow
					}
					else if (PopCalSetDMY(to, objPopCalendar.dateFormat))
					{
						objPopCalendar.dateUpTo = objPopCalendar.oDate
						objPopCalendar.monthUpTo = objPopCalendar.oMonth
						objPopCalendar.yearUpTo = objPopCalendar.oYear
					}
				}

				if (!PopCalCenturyOn(objPopCalendar.dateFormat))
				{
					if (PopCalDateFrom() < PopCalPadZero4(1900 + objPopCalendar.centuryLimit) + "0001")
					{
						objPopCalendar.dateFrom = 01
						objPopCalendar.monthFrom = 00
						objPopCalendar.yearFrom = 1900 + objPopCalendar.centuryLimit
					}

					if (PopCalDateUpTo() >  PopCalPadZero4(2000 + (objPopCalendar.centuryLimit-1)) + "1131")
					{
						objPopCalendar.dateUpTo = 31
						objPopCalendar.monthUpTo = 11
						objPopCalendar.yearUpTo = 2000 + (objPopCalendar.centuryLimit-1)
					}
				}

				if (PopCalDateFrom() > PopCalDateUpTo())
				{
					objPopCalendar.oDate = objPopCalendar.dateFrom
					objPopCalendar.oMonth = objPopCalendar.monthFrom
					objPopCalendar.oYear = objPopCalendar.yearFrom

					objPopCalendar.dateFrom = objPopCalendar.dateUpTo
					objPopCalendar.monthFrom = objPopCalendar.monthUpTo
					objPopCalendar.yearFrom = objPopCalendar.yearUpTo

					objPopCalendar.dateUpTo = objPopCalendar.oDate
					objPopCalendar.monthUpTo = objPopCalendar.oMonth
					objPopCalendar.yearUpTo = objPopCalendar.oYear
				}

				if (PopCalDateSelect() < PopCalDateFrom())
				{
					objPopCalendar.dateSelected = 0
					objPopCalendar.monthSelected = objPopCalendar.monthFrom
					objPopCalendar.yearSelected = objPopCalendar.yearFrom
				}

				if (PopCalDateSelect() > PopCalDateUpTo())
				{
					objPopCalendar.dateSelected = 0
					objPopCalendar.monthSelected = objPopCalendar.monthUpTo
					objPopCalendar.yearSelected = objPopCalendar.yearUpTo
				}

				objPopCalendar.odateSelected = objPopCalendar.dateSelected
				objPopCalendar.omonthSelected = objPopCalendar.monthSelected
				objPopCalendar.oyearSelected = objPopCalendar.yearSelected

				PopCalMoveDefaultPos()

				if (objPopCalendar.ie)
				{
					if ((PopCal.move == 1) && (PopCal.saveMovePos == 1))
					{
						if (objPopCalendar.ctlToPlaceValue != null)
						{
							if (objPopCalendar.ctlToPlaceValue.CalendarTop != null)
							{
								objPopCalendar.crossobj.top = objPopCalendar.ctlToPlaceValue.CalendarTop
							}
							if (objPopCalendar.ctlToPlaceValue.CalendarLeft != null)
							{
								objPopCalendar.crossobj.left = objPopCalendar.ctlToPlaceValue.CalendarLeft
							}
						}
					}
				}

				PopCalConstructCalendar()
				
				PopCalFadeIn()

				PopCalHideElement( 'SELECT', document.getElementById("popupSuperCalendar") )
				PopCalHideElement( 'APPLET', document.getElementById("popupSuperCalendar") )
				if (objPopCalendar.shadow==1)
				{
					PopCalHideElement( 'SELECT', document.getElementById("popupSuperShadowRight") )
					PopCalHideElement( 'APPLET', document.getElementById("popupSuperShadowRight") )
					PopCalHideElement( 'SELECT', document.getElementById("popupSuperShadowBottom") )
					PopCalHideElement( 'APPLET', document.getElementById("popupSuperShadowBottom") )
				}

				objPopCalendar.bShow = (PopCal.GXLink == 0)

			}
			else
			{
				objPopCalendar.executeFade = (objPopCalendar.ctlNow==ctl)
				
				PopCalHideCalendar()

				if (objPopCalendar.ctlToPlaceValue != null)
				{
					objPopCalendar.ctlToPlaceValue = null
				}
				
				if (objPopCalendar.ctlNow!=ctl) 
				{
					objPopCalendar.show(ctl, format, from, to, execute)
				}
				
				objPopCalendar.executeFade = true
			}
			objPopCalendar.ctlNow = ctl
		}
	}
}

function PopCalResizeWindow()
{
	if ((objPopCalendar.ctlToPlaceValue.CalendarTop == null) && (objPopCalendar.ctlToPlaceValue.CalendarLeft == null))
	{
		PopCalDownMonth()
		PopCalDownYear()
		PopCalMoveDefault()
	}
}

function PopCalMoveDefaultPos()
{
	var leftpos=0
	var toppos=0
	var PopCal = PopCalInstanceCreated()
	var aTag = objPopCalendar.ctlToPlaceValue
	
	do 
	{
		aTag = aTag.offsetParent
		leftpos += aTag.offsetLeft
		toppos  += aTag.offsetTop
	} 
	while(aTag.tagName!="BODY")

	objPopCalendar.crossobj.left = parseInt(PopCal.fixedX==-1 ? objPopCalendar.ctlToPlaceValue.offsetLeft + leftpos: PopCal.fixedX, 10)
	objPopCalendar.crossobj.top = parseInt(PopCal.fixedY==-1 ? objPopCalendar.ctlToPlaceValue.offsetTop + toppos + objPopCalendar.ctlToPlaceValue.offsetHeight + 7 : PopCal.fixedY, 10)

}

function PopCalMoveDefault()
{
	var PopCal = PopCalInstanceCreated()

	PopCalMoveDefaultPos()

	PopCalMoveShadow()

	PopCalShowAllElements()

	if (PopCal.saveMovePos == 1)
	{
		if (objPopCalendar.ctlToPlaceValue != null)
		{
			objPopCalendar.ctlToPlaceValue.CalendarLeft = null
			objPopCalendar.ctlToPlaceValue.CalendarTop = null
		}
	}

	objPopCalendar.bShow = false
}

function PopCalDrag()
{
	if (!objPopCalendar.movePopCal)
	{
		var PopCal = PopCalInstanceCreated()
		var ex = event.clientX+document.body.scrollLeft
		var ey = event.clientY+document.body.scrollTop
		document.getElementById("popupSuperHighLight").style.borderColor = "red"
		objPopCalendar.crossobj.xoff=parseInt(objPopCalendar.crossobj.left)-ex
		objPopCalendar.crossobj.yoff=parseInt(objPopCalendar.crossobj.top)-ey
		if (PopCal.shadow==1)
		{
			objPopCalendar.crossShadowRObj.xoff=parseInt(objPopCalendar.crossShadowRObj.left)-ex
			objPopCalendar.crossShadowRObj.yoff=parseInt(objPopCalendar.crossShadowRObj.top)-ey
			objPopCalendar.crossShadowBObj.xoff=parseInt(objPopCalendar.crossShadowBObj.left)-ex
			objPopCalendar.crossShadowBObj.yoff=parseInt(objPopCalendar.crossShadowBObj.top)-ey
		}
		PopCalDownMonth()
		PopCalDownYear()
		objPopCalendar.movePopCal = true
	}
	objPopCalendar.bShow = true
}

function PopCalTrackMouse()
{
	var PopCal = PopCalInstanceCreated()
	
	if (objPopCalendar.movePopCal)
	{
		
		var lLeft = (objPopCalendar.crossobj.xoff + event.clientX+document.body.scrollLeft)
		var lTop = (objPopCalendar.crossobj.yoff + event.clientY+document.body.scrollTop)
		if ((parseInt(objPopCalendar.crossobj.left) != parseInt(lLeft)) || (parseInt(objPopCalendar.crossobj.top) != parseInt(lTop)))
		{

			objPopCalendar.crossobj.left = lLeft
			objPopCalendar.crossobj.top = lTop

			if (PopCal.shadow==1)
			{
				objPopCalendar.crossShadowRObj.left = (objPopCalendar.crossShadowRObj.xoff + event.clientX+document.body.scrollLeft)
				objPopCalendar.crossShadowRObj.top = (objPopCalendar.crossShadowRObj.yoff + event.clientY+document.body.scrollTop)
				objPopCalendar.crossShadowBObj.left = (objPopCalendar.crossShadowBObj.xoff + event.clientX+document.body.scrollLeft)
				objPopCalendar.crossShadowBObj.top = (objPopCalendar.crossShadowBObj.yoff + event.clientY+document.body.scrollTop)
			}

			PopCalShowAllElements()

			if (PopCal.saveMovePos == 1)
			{
				if (objPopCalendar.ctlToPlaceValue != null)
				{
					objPopCalendar.ctlToPlaceValue.CalendarLeft = parseInt(objPopCalendar.crossobj.left)
					objPopCalendar.ctlToPlaceValue.CalendarTop = parseInt(objPopCalendar.crossobj.top)
				}
			}
		}
		objPopCalendar.bShow = true
	}
}

function PopCalDrop()
{
	objPopCalendar.bShow = true
	objPopCalendar.movePopCal = false
	document.getElementById("popupSuperHighLight").style.borderColor = "#a0a0a0"
}

function PopCalSelectWeekendHoliday(weekend, holidays)
{
	objPopCalendar.overWriteWeekend = weekend
	objPopCalendar.overWriteHoliday = holidays
}

function PopCalHolidayRec (d, m, y, desc0, desc1)
{
	this.d = d
	this.m = m
	this.y = y
	this.desc = Array("","")
	this.desc[0] = desc0
	this.desc[1] = desc1
	if (desc1==null) this.desc[1] = this.desc[0]
	if (desc0==null) this.desc[0] = this.desc[1]
	
}

function PopCalAddHoliday (d, m, y, desc0, desc1)
{
	objPopCalendar.Holidays[objPopCalendar.HolidaysCounter++] = new PopCalHolidayRec ( d, m, y, desc0, desc1 )
}

function PopCalFormatDate(dateValue, oldFormat, newFormat)
{
	var PopCal = PopCalInstanceCreated()
	if (PopCal)
	{

		var formatOld = PopCal.defaultFormat
		if (oldFormat!=null) 
		{
			formatOld = oldFormat
		}

		var formatNew = PopCal.defaultFormat 

		if (newFormat!=null) 
		{
			formatNew = newFormat
		}

		var newValue = ""
		if (PopCalSetDMY(dateValue, formatOld))
		{
			newValue = PopCalConstructDate(objPopCalendar.oDate,objPopCalendar.oMonth,objPopCalendar.oYear,formatNew)
		}
		return newValue
	}
	else
	{
		return ""
	}
}

function PopCalForcedToday(dateValue, format)
{
	if (PopCalInstanceCreated())
	{
		objPopCalendar.forceTodayTo = dateValue
		objPopCalendar.forceTodayFormat = format
	}
}

function PopCalInstanceCreated()
{
	if (!document.layers)
	{
		if (document.getElementById)
		{
			return (document.getElementById("CalendarInstanceCreated"))
		}
	}
	return false
}

/* hides <select> and <applet> objects (for IE only) */
function PopCalHideElement( elmID, overDiv )
{
	if( objPopCalendar.ie )
	{
		for( var i = 0; i < document.all.tags( elmID ).length; i++ )
		{
			var obj = document.all.tags( elmID )[i]
			if( !obj || !obj.offsetParent )
			{
				continue
			}

			// Find the element's offsetTop and offsetLeft relative to the BODY tag.
			var objLeft   = obj.offsetLeft
			var objTop    = obj.offsetTop
			var objParent = obj.offsetParent

			while( objParent.tagName.toUpperCase() != "BODY" )
			{
				objLeft  += objParent.offsetLeft
				objTop   += objParent.offsetTop
				objParent = objParent.offsetParent
			}

			objHeight = obj.offsetHeight
			objWidth = obj.offsetWidth
	    
			if(( overDiv.offsetLeft + overDiv.offsetWidth ) <= objLeft )
				continue
			else if(( overDiv.offsetTop + overDiv.offsetHeight ) <= objTop )
				continue
			else if( overDiv.offsetTop >= ( objTop + objHeight ))
				continue
			else if( overDiv.offsetLeft >= ( objLeft + objWidth ))
				continue
			else
			{
				if (obj.savedStyleDisplay==null)
				{
					obj.savedStyleDisplay = obj.style.visibility
				}
				obj.style.visibility = "hidden"
			}
		}
	}
}

   
/*
* unhides <select> and <applet> objects (for IE only)
*/
function PopCalShowElement( elmID )
{
	if ( objPopCalendar.ie )
	{
		for( var i = 0; i < document.all.tags( elmID ).length; i++ )
		{
			var obj = document.all.tags( elmID )[i]

			if( !obj || !obj.offsetParent )
			{
				continue
			}
			if (obj.savedStyleDisplay!=null)
			{
				if (obj.savedStyleDisplay.toLowerCase() != "hidden")
				{
					obj.style.visibility = ""
				}

			}
			obj.savedStyleDisplay = null
		}
	}
}

function PopCalShowAllElements()
{

	var PopCal = PopCalInstanceCreated()

	PopCalShowElement( 'SELECT' )
	PopCalShowElement( 'APPLET' )

	PopCalHideElement( 'SELECT', document.getElementById("popupSuperCalendar") )
	PopCalHideElement( 'APPLET', document.getElementById("popupSuperCalendar") )

	if (PopCal.shadow==1)
	{
		PopCalHideElement( 'SELECT', document.getElementById("popupSuperShadowRight") )
		PopCalHideElement( 'APPLET', document.getElementById("popupSuperShadowRight") )
		PopCalHideElement( 'SELECT', document.getElementById("popupSuperShadowBottom") )
		PopCalHideElement( 'APPLET', document.getElementById("popupSuperShadowBottom") )
	}
}

function PopCalSwapImage(srcImg, destImg)
{
	if (objPopCalendar.ie) 
	{ 
		document.getElementById(srcImg).setAttribute("src",objPopCalendar.imgDir + destImg) 
	}
}


function PopCalHideCalendar()	
{
	var PopCal = PopCalInstanceCreated()

	if (objPopCalendar.ie)
	{
		document.onkeypress = objPopCalendar.onKeyPress
	}
	else
	{
		document.releaseEvents(Event.KEYUP)
		document.onkeyup = objPopCalendar.onKeyPress
	}

	document.onclick = objPopCalendar.onClick
	
	if (objPopCalendar.ie)
	{
		document.onselectstart = objPopCalendar.onSelectStart
		document.oncontextmenu = objPopCalendar.onContextMenu
	}

	if (objPopCalendar.ie)
	{
		if (PopCal.move == 1)
		{
			document.onmousemove = objPopCalendar.onmousemove
			document.onmouseup = objPopCalendar.onmouseup
		}
		window.onresize = objPopCalendar.onresize
	}
		
	objPopCalendar.onKeyPress = null
	objPopCalendar.onClick = null
	objPopCalendar.onSelectStart = null
	objPopCalendar.onContextMenu = null
	objPopCalendar.onmousemove = null
	objPopCalendar.onmouseup = null
	objPopCalendar.onresize = null

	
	if (objPopCalendar.crossMonthObj != null)
	{
		objPopCalendar.crossMonthObj.display="none"
	}

	if (objPopCalendar.crossYearObj != null)
	{
		objPopCalendar.crossYearObj.display="none"
	}

	PopCalShowElement( 'SELECT' )
	PopCalShowElement( 'APPLET' )

	PopCalFadeOut()
}

function PopCalFadeIn() 
{

	var PopCal = PopCalInstanceCreated()

	var objCal = document.getElementById("popupSuperCalendar")
	var objShdR = document.getElementById("popupSuperShadowRight")
	var objShdB = document.getElementById("popupSuperShadowBottom")

	if (!objPopCalendar.ie)
	{
		if (PopCal.shadow==1)
		{
			objShdR.style.display="none"
			objShdR.style.visibility="visible"
			objShdR.style.display=""
			objShdB.style.display="none"
			objShdB.style.visibility="visible"
			objShdB.style.display=""
		}
		objCal.style.display="none"
		objCal.style.visibility="visible"
		objCal.style.display=""
	}
	else if ((PopCal.fade>0) && (objPopCalendar.executeFade))
	{
		
		objCal.filters.blendTrans.Stop()

		if (PopCal.fade > 1) PopCal.fade = 1

		objCal.style.filter="blendTrans(duration=" + PopCal.fade + ")"

		if ((objCal.style.visibility != "visible") && (objCal.filters.blendTrans.status != 2))
		{
			if (PopCal.shadow==1)
			{
				objShdR.style.filter="alpha(opacity=50)"
				objShdB.style.filter="alpha(opacity=50)"
			}
			objCal.filters.blendTrans.Apply()
			objCal.style.visibility="visible"
			objCal.filters.blendTrans.Play()
			
			if (PopCal.shadow==1)
			{
				objShdR.style.visibility="visible"
				objShdB.style.visibility="visible"
			}
		}
		else
		{
			if (PopCal.shadow==1)
			{
				objShdR.style.visibility="visible"
				objShdB.style.visibility="visible"
			}
			objCal.style.visibility="visible"
		}
	}
	else
	{
		if (PopCal.shadow==1)
		{
			objShdR.style.visibility="visible"
			objShdB.style.visibility="visible"
		}
		objCal.style.visibility="visible"
	}
}

function PopCalFadeOut()
{
	var PopCal = PopCalInstanceCreated()

	var objCal = document.getElementById("popupSuperCalendar")
	var objShdR = document.getElementById("popupSuperShadowRight")
	var objShdB = document.getElementById("popupSuperShadowBottom")

	if ((objPopCalendar.ie) && (PopCal.fade>0) && (objPopCalendar.executeFade))
	{

		objCal.filters.blendTrans.Stop()

		if (PopCal.fade > 1) PopCal.fade = 1

		objCal.style.filter="blendTrans(duration=" + PopCal.fade + ")"

		if ((objCal.style.visibility != "hidden") && (objCal.filters.blendTrans.status != 2))
		{
			if (PopCal.shadow==1)
			{
				objShdR.style.filter="alpha(opacity=0)"
				objShdB.style.filter="alpha(opacity=0)"
			}
			objCal.filters.blendTrans.Apply()
			objCal.style.visibility="hidden"
			objCal.filters.blendTrans.Play()
			objPopCalendar.timeoutID3=setTimeout("PopCalMoveTo(0, 0)",(PopCal.fade + .05) * 1000)
		}
		else
		{
			objCal.style.visibility="hidden"
			PopCalMoveTo(0, 0)
		}
	}
	else
	{
		objCal.style.visibility="hidden"
		PopCalMoveTo(0, 0)
	}	
	
}

function PopCalMoveTo(t, l)
{
	var objShdR = document.getElementById("popupSuperShadowRight")
	var objShdB = document.getElementById("popupSuperShadowBottom")
	var PopCal = document.getElementById("popupSuperCalendar")

	PopCal.style.top = t
	PopCal.style.left = l

	objShdR.style.visibility="hidden"

	objShdB.style.visibility="hidden"

	objShdR.style.top = t
	objShdR.style.left = l
	objShdR.style.height = 1

	objShdB.style.left = l
	objShdB.style.top = t
	objShdB.style.width = 1
	
	if (objPopCalendar.timeoutID3 != null)
	{
		clearTimeout(objPopCalendar.timeoutID3)
		objPopCalendar.timeoutID3 = null
	}
}

function PopCalPadZero(num) 
{
	return (num < 10)? '0' + num : num 
}

function PopCalPadZero4(num) 
{
	if (num < 10)
	{
		return ('000' + num)
	}
	else if (num < 100)
	{
		return ('00' + num)
	}
	else if (num < 1000)
	{
		return ('0' + num)
	}
	else
	{
		return ('' + num)
	}
}


function PopCalIsVisible(o)
{
	return (o.display != "none")
}

function PopCalConstructDate(d,m,y,format)
{
	var sTmp = format
	sTmp = sTmp.replace ("dd","<e>")
	sTmp = sTmp.replace ("d","<d>")
	sTmp = sTmp.replace ("<e>",PopCalPadZero(d))
	sTmp = sTmp.replace ("<d>",d)
	sTmp = sTmp.replace ("mmmm","<l>")
	sTmp = sTmp.replace ("mmm","<s>")
	sTmp = sTmp.replace ("mm","<n>")
	sTmp = sTmp.replace ("m","<m>")
	sTmp = sTmp.replace ("yyyy",PopCalPadZero4(y))
	sTmp = sTmp.replace ("yy",PopCalPadZero4(y).substr(2))
	sTmp = sTmp.replace ("<m>",m+1)
	sTmp = sTmp.replace ("<n>",PopCalPadZero(m+1))
	sTmp = sTmp.replace ("<s>",objPopCalendar.monthName[m].substr(0,3))
	sTmp = sTmp.replace ("<l>",objPopCalendar.monthName[m])
	return sTmp
}

function PopCalCloseCalendar() 
{
	PopCalHideCalendar()
	

	
	objPopCalendar.ctlToPlaceValue.value = PopCalConstructDate(objPopCalendar.dateSelected,objPopCalendar.monthSelected,objPopCalendar.yearSelected,objPopCalendar.dateFormat)

	if (objPopCalendar.ctlToPlaceValue.type)
	{
		if (objPopCalendar.ctlToPlaceValue.type.toLowerCase() == "text")
		{
			if (objPopCalendar.ctlToPlaceValue.style.display.toLowerCase() != "none")
			{
				if (objPopCalendar.ctlToPlaceValue.style.visibility.toLowerCase() != "hidden")
				{   if (objPopCalendar.ctlToPlaceValue.disabled == false)
				    {   // solo si no esta desabilitado ubico el focus
				      if (objPopCalendar.ctlToPlaceValue.readonly == false)
					  {	
						objPopCalendar.ctlToPlaceValue.focus();
						
					  }
 				    }
				  


				}
			}
		}
		
		try
		{ 
			var fechad = document.Form1.FECHA_DESDE.value
			document.Form1.FECHA_HASTA_RH.value = addToDate(document.Form1.FECHA_DESDE.value, "31")
		}
		catch (e)
		{} 
		
		try
		{ 
			var fechad = document.Form1.FECHA_INICIO_cyv.value
			__doPostBack("ChangedFecha");
		}
		catch (e)
		{} 

	}

	if (objPopCalendar.commandExecute!=null)
	{
		eval(objPopCalendar.commandExecute)
	}

}

function PopCalPressEscape(e)
{
	if (objPopCalendar.ie)
	{
		if (event.keyCode==27) 
		{
			PopCalHideCalendar()
		}
	}
	else
	{
		if (e.which == 27)
		{
			PopCalHideCalendar()
		}
	}
}

function PopCalClickDocumentBody() 
{ 		
	if (!objPopCalendar.bShow)
	{
		PopCalHideCalendar()
	}
	objPopCalendar.bShow = false
}


/*** Month Pulldown	***/

function PopCalStartDecMonth()
{
	objPopCalendar.intervalID1=setInterval("PopCalDecMonth()",80)
}

function PopCalStartIncMonth()
{
	objPopCalendar.intervalID1=setInterval("PopCalIncMonth()",80)
}

function PopCalIncMonth () 
{
	objPopCalendar.monthSelected++
	if (objPopCalendar.monthSelected>11) {
		objPopCalendar.monthSelected=0
		objPopCalendar.yearSelected++
	}

	if ((objPopCalendar.yearSelected > objPopCalendar.yearUpTo) || (objPopCalendar.yearSelected == objPopCalendar.yearUpTo && objPopCalendar.monthSelected > objPopCalendar.monthUpTo))
	{
		PopCalDecMonth()
	}
	else
	{
		PopCalConstructCalendar()
	}
	
	PopCalShowAllElements()
}

function PopCalDecMonth () 
{
	objPopCalendar.monthSelected--
	if (objPopCalendar.monthSelected<0) 
	{
		objPopCalendar.monthSelected=11
		objPopCalendar.yearSelected--
	}

	if ((objPopCalendar.yearSelected < objPopCalendar.yearFrom) || (objPopCalendar.yearSelected == objPopCalendar.yearFrom && objPopCalendar.monthSelected < objPopCalendar.monthFrom))
	{
		PopCalIncMonth()
	}
	else
	{
		PopCalConstructCalendar()
	}
	
	PopCalShowAllElements()
}

function PopCalConstructMonth() 
{
	PopCalDownYear()
	if (!objPopCalendar.monthConstructed) 
	{
		var beginMonth = 0
		var endMonth = 11

		objPopCalendar.countMonths = 0

		if (objPopCalendar.yearSelected == objPopCalendar.yearFrom)
		{
			beginMonth = objPopCalendar.monthFrom
		}

		if (objPopCalendar.yearSelected == objPopCalendar.yearUpTo)
		{
			endMonth = objPopCalendar.monthUpTo
		}

		var sHTML = ""
		for (var i=beginMonth; i<=endMonth; i++) 
		{
			objPopCalendar.countMonths++

			var sName = objPopCalendar.monthName[i]
			if (i==objPopCalendar.monthSelected){
				sName =	"<B>" +	sName +	"</B>"
			}
			sHTML += "<tr><td id='popupSuperMonth" + i + "' onmouseover='objPopCalendar.bShow=true;this.style.backgroundColor=\"#8AB0D7\"' onmouseout='objPopCalendar.bShow=false;this.style.backgroundColor=\"\"' style='cursor:default' onclick='objPopCalendar.bShow=false;objPopCalendar.monthConstructed=false;objPopCalendar.monthSelected=" + i + ";PopCalConstructCalendar();PopCalDownMonth();event.cancelBubble=true'>&nbsp;" + sName + "&nbsp;</td></tr>"
		}

		document.getElementById("popupSuperMonth").innerHTML = "<table width=70 style='font-family:arial; font-size:11px; border-width:1; border-style:solid; border-color:#a0a0a0;' bgcolor='#E9E7ED' cellspacing=0 onmouseover='clearTimeout(objPopCalendar.timeoutID1)' onmouseout='clearTimeout(objPopCalendar.timeoutID1);event.cancelBubble=true'>" + sHTML + "</table>"

		objPopCalendar.monthConstructed=true
	}
}

function PopCalUpMonth() 
{
	if ((objPopCalendar.yearSelected == objPopCalendar.yearFrom) || (objPopCalendar.yearSelected == objPopCalendar.yearUpTo))
	{
		objPopCalendar.monthConstructed=false
	}
	else if (objPopCalendar.countMonths != 12)
	{
		objPopCalendar.monthConstructed=false
	}
	
	PopCalConstructMonth()

	objPopCalendar.crossMonthObj.display = ""
	objPopCalendar.crossMonthObj.left = parseInt(objPopCalendar.crossobj.left, 10) + 50
	objPopCalendar.crossMonthObj.top = parseInt(objPopCalendar.crossobj.top, 10) + 26

	PopCalHideElement( 'SELECT', document.getElementById("popupSuperMonth") )
	PopCalHideElement( 'APPLET', document.getElementById("popupSuperMonth") )

}

function PopCalDownMonth()
{
	if (objPopCalendar.crossMonthObj.display != "none")
	{
		if (!objPopCalendar.keepMonth)
		{
			objPopCalendar.crossMonthObj.display = "none"
			PopCalShowAllElements()
		}
	}
	objPopCalendar.keepMonth = false
}


/*** Year Pulldown ***/

function PopCalWheelYear()
{
	if (PopCalIsVisible(objPopCalendar.crossYearObj))
	{
		if (event.wheelDelta >= 120)
		{
			for	(var i=0; i<3; i++)
			{
				PopCalDecYear()
			}
		}
		else if (event.wheelDelta <= -120)
		{
			for	(var i=0; i<3; i++)
			{
				PopCalIncYear()
			}
		}
	}
}


function PopCalIncYear() 
{
	if ((objPopCalendar.nStartingYear+(objPopCalendar.HalfYearList*2+1)) <= objPopCalendar.yearUpTo)
	{
		for	(var i=0; i<(objPopCalendar.HalfYearList*2+1); i++){
			var newYear = (i+objPopCalendar.nStartingYear)+1
			var txtYear
			if (newYear==objPopCalendar.yearSelected)
			{ 
				txtYear = "&nbsp;<B>" + newYear + "</B>&nbsp;" 
			}
			else
			{
				txtYear = "&nbsp;" + newYear + "&nbsp;" 
			}
			document.getElementById("popupSuperYear"+i).innerHTML = txtYear
		}
		objPopCalendar.nStartingYear ++
	}
	objPopCalendar.bShow=true
}

function PopCalDecYear() 
{
	if (objPopCalendar.nStartingYear-1 >= objPopCalendar.yearFrom)
	{

		for (var i=0; i<(objPopCalendar.HalfYearList*2+1); i++)
		{
			var newYear	= (i+objPopCalendar.nStartingYear)-1
			var txtYear

			if (newYear==objPopCalendar.yearSelected)
			{
				txtYear = "&nbsp;<B>"+ newYear + "</B>&nbsp;"
			}
			else
			{
				txtYear = "&nbsp;" + newYear + "&nbsp;" 
			}
			document.getElementById("popupSuperYear"+i).innerHTML = txtYear
		}
		objPopCalendar.nStartingYear --
	}
	objPopCalendar.bShow=true
}

function PopCalSelectYear(nYear) 
{
	objPopCalendar.yearSelected=parseInt(nYear+objPopCalendar.nStartingYear, 10)
	if ((objPopCalendar.yearSelected == objPopCalendar.yearFrom) && (objPopCalendar.monthSelected < objPopCalendar.monthFrom))
	{
		objPopCalendar.monthSelected = objPopCalendar.monthFrom
	}
	else if ((objPopCalendar.yearSelected == objPopCalendar.yearUpTo) && (objPopCalendar.monthSelected > objPopCalendar.monthUpTo))
	{
		objPopCalendar.monthSelected = objPopCalendar.monthUpTo
	}
	objPopCalendar.yearConstructed=false
	PopCalConstructCalendar()
	PopCalDownYear()
}

function PopCalConstructYear() 
{
	PopCalDownMonth()

	var sHTML = ""
	var longList = true
	if (!objPopCalendar.yearConstructed)
	{
		var beginYear = objPopCalendar.yearSelected-objPopCalendar.HalfYearList
		var endYear = objPopCalendar.yearSelected+objPopCalendar.HalfYearList

		if ((objPopCalendar.yearUpTo - objPopCalendar.yearFrom + 1) <= (objPopCalendar.HalfYearList * 2 + 1))
		{
			beginYear = objPopCalendar.yearFrom
			endYear = objPopCalendar.yearUpTo
			longList = false
		}
		else if (beginYear < objPopCalendar.yearFrom)
		{
			beginYear = objPopCalendar.yearFrom
			endYear = beginYear + objPopCalendar.HalfYearList * 2
		}
		else if (endYear > objPopCalendar.yearUpTo)
		{
			endYear = objPopCalendar.yearUpTo
			beginYear = endYear - (objPopCalendar.HalfYearList * 2)
		}

		objPopCalendar.nStartingYear = beginYear

		if (longList)
		{
			sHTML += "<tr><td align='center' onmouseover='objPopCalendar.bShow=true;this.style.backgroundColor=\"#8AB0D7\"' onmouseout='objPopCalendar.bShow=false;clearInterval(objPopCalendar.intervalID1);this.style.backgroundColor=\"\"' style='cursor:default;border-bottom:1px #a0a0a0 solid' onmousedown='clearInterval(objPopCalendar.intervalID1);objPopCalendar.intervalID1=setInterval(\"PopCalDecYear()\",15)' onmouseup='clearInterval(objPopCalendar.intervalID1)'><IMG id='popupSuperUpYear' SRC='"+objPopCalendar.imgDir+"up.gif' BORDER=0></td></tr>"
		}

		var j =	0
		for (var i=(beginYear); i<=(endYear); i++)
		{
			var sName =	i
			if (i==objPopCalendar.yearSelected)
			{
				sName = "<B>" + sName + "</B>"
			}

			sHTML += "<tr><td id='popupSuperYear" + j + "' align='center' onmouseover='objPopCalendar.bShow=true;this.style.backgroundColor=\"#8AB0D7\"' onmouseout='objPopCalendar.bShow=false;this.style.backgroundColor=\"\"' style='cursor:default' onclick='objPopCalendar.bShow=false;PopCalSelectYear("+j+");event.cancelBubble=true'>&nbsp;" + sName + "&nbsp;</td></tr>"
			j ++
		}

		if (longList)
		{
			sHTML += "<tr><td align='center' onmouseover='objPopCalendar.bShow=true;this.style.backgroundColor=\"#8AB0D7\"' onmouseout='objPopCalendar.bShow=false;clearInterval(objPopCalendar.intervalID2);this.style.backgroundColor=\"\"' style='cursor:default;border-top:1px #a0a0a0 solid' onmousedown='clearInterval(objPopCalendar.intervalID2);objPopCalendar.intervalID2=setInterval(\"PopCalIncYear()\",15)' onmouseup='clearInterval(objPopCalendar.intervalID2)'><IMG id='popupSuperDownYear' SRC='"+objPopCalendar.imgDir+"down.gif' BORDER=0></td></tr>"
		}

		document.getElementById("popupSuperYear").innerHTML	= "<table width=44 style='font-family:arial; font-size:11px; border-width:1; border-style:solid; border-color:#a0a0a0;'	bgcolor='#E9E7ED' onmouseover='clearTimeout(objPopCalendar.timeoutID2)' onmouseout='clearTimeout(objPopCalendar.timeoutID2);' cellspacing=0>"	+ sHTML	+ "</table>"

		objPopCalendar.yearConstructed = true
	}
}

function PopCalDownYear() 
{
	if (objPopCalendar.crossYearObj.display != "none")
	{
		if (!objPopCalendar.keepYear)
		{
			clearInterval(objPopCalendar.intervalID1)
			clearTimeout(objPopCalendar.timeoutID1)
			clearInterval(objPopCalendar.intervalID2)
			clearTimeout(objPopCalendar.timeoutID2)
			objPopCalendar.crossYearObj.display = "none"

			PopCalShowAllElements()
		}
	}
	objPopCalendar.keepYear = false
}

function PopCalUpYear()
{

	var leftOffset
	PopCalConstructYear()
	objPopCalendar.crossYearObj.display = ""
	leftOffset = parseInt(objPopCalendar.crossobj.left, 10) + document.getElementById("popupSuperSpanYear").offsetLeft
	if (objPopCalendar.ie)
	{
		leftOffset += 6
	}
	else
	{
		leftOffset += 7
	}
	objPopCalendar.crossYearObj.left = leftOffset
	objPopCalendar.crossYearObj.top = parseInt(objPopCalendar.crossobj.top, 10) + 26

	PopCalHideElement( 'SELECT', document.getElementById("popupSuperYear") )
	PopCalHideElement( 'APPLET', document.getElementById("popupSuperYear") )

}

/*** calendar ***/
function PopCalWeekNbr(n) 
{
    // Algorithm used:
    // From Klaus Tondering's Calendar document (The Authority/Guru)
    // hhtp://www.tondering.dk/claus/calendar.html
    // a = (14-month) / 12
    // y = year + 4800 - a
    // m = month + 12a - 3
    // J = day + (153m + 2) / 5 + 365y + y / 4 - y / 100 + y / 400 - 32045
    // d4 = (J + 31741 - (J mod 7)) mod 146097 mod 36524 mod 1461
    // L = d4 / 1460
    // d1 = ((d4 - L) mod 365) + L
    // WeekNumber = d1 / 7 + 1

	var PopCal=PopCalInstanceCreated()


	var year = n.getFullYear()
	var month = n.getMonth() + 1
	var day
	if (PopCal.startAt == 0) 
	{
		day = n.getDate() + 1
	}
	else 
	{
		day = n.getDate()
	}

	var a = Math.floor((14-month) / 12)
	var y = year + 4800 - a
	var m = month + 12 * a - 3
	var b = Math.floor(y/4) - Math.floor(y/100) + Math.floor(y/400)
	var J = day + Math.floor((153 * m + 2) / 5) + 365 * y + b - 32045
	var d4 = (((J + 31741 - (J % 7)) % 146097) % 36524) % 1461
	var L = Math.floor(d4 / 1460)
	var d1 = ((d4 - L) % 365) + L
	var week = Math.floor(d1/7) + 1

	return week
}

function PopCalConstructCalendar ()
{
	var PopCal=PopCalInstanceCreated()

	var aNumDays = Array (31,0,31,30,31,30,31,31,30,31,30,31)

	var dateMessage
	var startDate = new Date(objPopCalendar.yearSelected,objPopCalendar.monthSelected,1)
	var endDate
	var numDaysInMonth
	var notSelect
	var selectWeekends = PopCal.selectWeekend
	var selectHolidays = PopCal.selectHoliday
	
	if (objPopCalendar.overWriteSelectWeekend!=null)
	{
		selectWeekends = objPopCalendar.overWriteSelectWeekend
	}

	if (objPopCalendar.overWriteSelectHoliday!=null)
	{
		selectHolidays = objPopCalendar.overWriteSelectHoliday
	}
	
	if (objPopCalendar.monthSelected==1)
	{
		endDate = new Date (objPopCalendar.yearSelected,2,1)
		
		endDate = new Date (endDate - (86400000))

		numDaysInMonth = endDate.getDate()
	}
	else
	{
		numDaysInMonth = aNumDays[objPopCalendar.monthSelected]
	}

	var datePointer	= 0
	dayPointer = startDate.getDay() - PopCal.startAt
	
	if (dayPointer<0)
	{
		dayPointer = 6
	}

	var sHTML = "<table border=0 style='font-family:verdana;font-size:10px;'><tr>"

	if (PopCal.showWeekNumber==1)
	{
		sHTML += "<td width=27 Style='cursor:default'><b>" + objPopCalendar.weekString + "</b></td><td width=1 rowspan=7 bgcolor='#d0d0d0' style='padding:0px'></td>"
	}

	for (var i=0; i<7; i++)
	{
		sHTML += "<td width='27' align='right' Style='cursor:default'><B>"+ objPopCalendar.dayName[i].substr(0,3)+"</B></td>"
	}
	sHTML +="</tr><tr>"
	
	if (PopCal.showWeekNumber==1)
	{
		sHTML += "<td align=right Style='cursor:default'>" + PopCalWeekNbr(startDate) + "&nbsp;</td>"
	}

	for (var i=1; i<=dayPointer;i++ )
	{
		sHTML += "<td Style='cursor:default'>&nbsp;</td>"
	}

	//Martes de Carnaval y Viernes Santo para el a�o actual
	if ((PopCal.addCarnival==1) || (PopCal.addGoodFriday==1))
	{
		var dtDomingoPascuas = PopCalDomingoPascuas(objPopCalendar.yearSelected)

		if (PopCal.addCarnival==1)
		{
			var dtDate = new Date(dtDomingoPascuas - (47 * 86400000))
			PopCalAddHoliday(dtDate.getDate(), dtDate.getMonth() + 1, dtDate.getFullYear(),"Martes de Carnaval", "Carnival's Tuesday")
		}

		if (PopCal.addGoodFriday==1)
		{
			var dtDate = new Date(dtDomingoPascuas - (2 * 86400000))
			PopCalAddHoliday(dtDate.getDate(), dtDate.getMonth() + 1, dtDate.getFullYear() ,"Viernes Santo", "Good Friday")
		}
	}
	
	for (var datePointer=1; datePointer<=numDaysInMonth; datePointer++ )
	{
		dayPointer++
		sHTML += "<td align=right Style='cursor:default'>"
		var sStyle=objPopCalendar.styleAnchor
		
		if ((datePointer==objPopCalendar.odateSelected) && (objPopCalendar.monthSelected==objPopCalendar.omonthSelected)	&& (objPopCalendar.yearSelected==objPopCalendar.oyearSelected))
		{ 
			sStyle+=objPopCalendar.styleLightBorder 
		}

		notSelect = false

		var sHint = ""
		for (var k=0;k<objPopCalendar.HolidaysCounter;k++)
		{
			if ((parseInt(objPopCalendar.Holidays[k].d, 10)==datePointer)&&(parseInt(objPopCalendar.Holidays[k].m, 10)==(objPopCalendar.monthSelected+1)))
			{
				if ((parseInt(objPopCalendar.Holidays[k].y)==0, 10)||((parseInt(objPopCalendar.Holidays[k].y, 10)==objPopCalendar.yearSelected))&&(parseInt(objPopCalendar.Holidays[k].y, 10)!=0))
				{
					if (PopCal.showHolidays==1)
					{
						sStyle+="background-color:#8AB0D7;"
					}
						
					sHint+=sHint==""?objPopCalendar.Holidays[k].desc[PopCal.language]:"\n"+objPopCalendar.Holidays[k].desc[PopCal.language]
					
					if (selectHolidays!=1)
					{
						notSelect = true
					}
					else if (PopCal.showHolidays!=1)
					{
						sHint = ""
					}
				}
			}
		}
		
		var regexp= /\"/g
		sHint=sHint.replace(regexp,"&quot;")

		dateMessage = "onmouseover='window.status=\""+objPopCalendar.selectDateMessage.replace("[date]",PopCalConstructDate(datePointer,objPopCalendar.monthSelected,objPopCalendar.yearSelected,objPopCalendar.dateFormat))+"\"' onmouseout='window.status=\"\"' "
		
		if (objPopCalendar.yearSelected == objPopCalendar.yearFrom && objPopCalendar.monthSelected == objPopCalendar.monthFrom)
		{
			if (datePointer < objPopCalendar.dateFrom)
			{
				notSelect = true
			}
		}

		if (objPopCalendar.yearSelected == objPopCalendar.yearUpTo && objPopCalendar.monthSelected == objPopCalendar.monthUpTo)
		{
			if (datePointer > objPopCalendar.dateUpTo)
			{
				notSelect = true
			}
		}
		
		if ((selectWeekends!=1) && (!notSelect))
		{
			if ((dayPointer % 7 == (PopCal.startAt * -1)+1) || (dayPointer % 7 == (PopCal.startAt * -1)+7) || (dayPointer % 7 == (PopCal.startAt * -1)))
			{
				notSelect = true
			}
		}

		if (notSelect)
		{
			if ((datePointer==objPopCalendar.dateNow)&&(objPopCalendar.monthSelected==objPopCalendar.monthNow)&&(objPopCalendar.yearSelected==objPopCalendar.yearNow))
			{
				sHTML += "<b><Span title=\"" + sHint + "\" Style='" + sStyle + "text-decoration:line-through;color=#000000'>&nbsp;" + datePointer + "&nbsp;</Span></b>"
			}
			else if (((dayPointer % 7 == (PopCal.startAt * -1)+1) || (dayPointer % 7 == (PopCal.startAt * -1)+7) || (dayPointer % 7 == (PopCal.startAt * -1))) && (PopCal.showWeekend==1))
			{
				sHTML += "<Span title=\"" + sHint + "\" Style='" + sStyle + "text-decoration:line-through'>&nbsp;<font color=#909090>" + datePointer + "</font>&nbsp;</Span>"
			}
			else
			{
				sHTML += "<Span title=\"" + sHint + "\" Style='" + sStyle + "text-decoration:line-through'>&nbsp;" + datePointer + "&nbsp;</Span>"
			}
		}
		else if ((datePointer==objPopCalendar.dateNow)&&(objPopCalendar.monthSelected==objPopCalendar.monthNow)&&(objPopCalendar.yearSelected==objPopCalendar.yearNow))
		{
			sHTML += "<b><a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' onClick='objPopCalendar.dateSelected="+datePointer+";PopCalCloseCalendar();'>&nbsp;<font color=#000000>" + datePointer + "</font>&nbsp;</a></b>"
		}
		else if (((dayPointer % 7 == (PopCal.startAt * -1)+1) || (dayPointer % 7 == (PopCal.startAt * -1)+7) || (dayPointer % 7 == (PopCal.startAt * -1))) && (PopCal.showWeekend==1))
		{
			sHTML += "<a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' onClick='objPopCalendar.dateSelected=" + datePointer + ";PopCalCloseCalendar();'>&nbsp;<font color=#909090>" + datePointer + "</font>&nbsp;</a>" 
		}
		else
		{
			sHTML += "<a "+dateMessage+" title=\"" + sHint + "\" style='"+sStyle+"' onClick='objPopCalendar.dateSelected=" + datePointer + ";PopCalCloseCalendar();'>&nbsp;" + datePointer + "&nbsp;</a>"
		}

		sHTML += ""
		if ((dayPointer+PopCal.startAt) % 7 == PopCal.startAt) { 
			sHTML += "</tr><tr>" 
			if ((PopCal.showWeekNumber==1)&&(datePointer<numDaysInMonth))
			{
				sHTML += "<td align=right Style='cursor:default'>" + (PopCalWeekNbr(new Date(objPopCalendar.yearSelected,objPopCalendar.monthSelected,datePointer+1))) + "&nbsp;</td>"
			}
		}
		

	}
	if (PopCal.addGoodFriday==1)
	{
		objPopCalendar.Holidays[objPopCalendar.HolidaysCounter--]
	}

	if (PopCal.addCarnival==1)
	{
		objPopCalendar.Holidays[objPopCalendar.HolidaysCounter--]
	}

	document.getElementById("popupSuperContent").innerHTML = sHTML
	document.getElementById("popupSuperSpanMonth").innerHTML = "&nbsp;" + objPopCalendar.monthName[objPopCalendar.monthSelected] + "&nbsp;<IMG id='popupSuperChangeMonth' SRC='"+objPopCalendar.imgDir+"drop1.gif' WIDTH='12' HEIGHT='10' BORDER=0>"
	document.getElementById("popupSuperSpanYear").innerHTML = "&nbsp;" + objPopCalendar.yearSelected + "&nbsp;<IMG id='popupSuperChangeYear' SRC='"+objPopCalendar.imgDir+"drop1.gif' WIDTH='12' HEIGHT='10' BORDER=0>"

	PopCalMoveShadow()	
}


function PopCalMoveShadow()
{
	var PopCal=PopCalInstanceCreated()

	if (PopCal.shadow==1)
	{
		objPopCalendar.crossShadowRObj.height = document.getElementById("popupSuperCalendar").offsetHeight - 10
		objPopCalendar.crossShadowRObj.top =  (document.getElementById("popupSuperCalendar").offsetTop + 10)
		objPopCalendar.crossShadowRObj.left = (document.getElementById("popupSuperCalendar").offsetLeft + document.getElementById("popupSuperCalendar").offsetWidth)

		objPopCalendar.crossShadowBObj.width = document.getElementById("popupSuperCalendar").offsetWidth
		objPopCalendar.crossShadowBObj.top =  (document.getElementById("popupSuperCalendar").offsetTop + document.getElementById("popupSuperCalendar").offsetHeight)
		objPopCalendar.crossShadowBObj.left = ((document.getElementById("popupSuperCalendar").offsetLeft + document.getElementById("popupSuperCalendar").offsetWidth) + 10) - document.getElementById("popupSuperCalendar").offsetWidth
	}
}

function PopCalDateNow()
{
	return PopCalPadZero4(objPopCalendar.yearNow) + PopCalPadZero(objPopCalendar.monthNow) + PopCalPadZero(objPopCalendar.dateNow)
}

function PopCalDateSelect()
{
	return PopCalPadZero4(objPopCalendar.yearSelected) + PopCalPadZero(objPopCalendar.monthSelected) + PopCalPadZero(objPopCalendar.dateSelected)
}

function PopCalDateFrom()
{
	return PopCalPadZero4(objPopCalendar.yearFrom) + PopCalPadZero(objPopCalendar.monthFrom) + PopCalPadZero(objPopCalendar.dateFrom)
}

function PopCalDateUpTo()
{
	return PopCalPadZero4(objPopCalendar.yearUpTo) + PopCalPadZero(objPopCalendar.monthUpTo) + PopCalPadZero(objPopCalendar.dateUpTo)
}

function PopCalCenturyOn(dateFormat)
{
	var formatChar =  " "

	dateFormat = dateFormat.toLowerCase()
	
	var aFormat = dateFormat.split(formatChar)
	if (aFormat.length<3)
	{
		formatChar = "/"
		aFormat = dateFormat.split(formatChar)
		if (aFormat.length<3)
		{
			formatChar = "."
			aFormat = dateFormat.split(formatChar)
			if (aFormat.length<3)
			{
				formatChar = "-"
				aFormat = dateFormat.split(formatChar)
				if (aFormat.length<3)
				{
					// invalid date	format
					formatChar = ""
				}
			}
		}
	}

	if ( formatChar != "" )
	{
		for (var i=0;i<3;i++)
		{
			if (aFormat[i]=="yyyy")
			{
				return true
			}
		}
	}
	return false
}

function PopCalSetDMY(dateValue, dateFormat)
{

	var PopCal=PopCalInstanceCreated()
	
	objPopCalendar.oDate = null
	objPopCalendar.oMonth = null
	objPopCalendar.oYear = null

	var formatChar =  " "

	dateFormat = dateFormat.toLowerCase()
	
	var aFormat = dateFormat.split(formatChar)
	if (aFormat.length<3)
	{
		formatChar = "/"
		aFormat = dateFormat.split(formatChar)
		if (aFormat.length<3)
		{
			formatChar = "."
			aFormat = dateFormat.split(formatChar)
			if (aFormat.length<3)
			{
				formatChar = "-"
				aFormat = dateFormat.split(formatChar)
				if (aFormat.length<3)
				{
					// invalid date	format
					formatChar = ""
				}
			}
		}
	}

	var tokensChanged = 0

	if ( formatChar != "" )
	{
		// use user's date
		var aData = dateValue.split(formatChar)

		for (var i=0;i<3;i++)
		{
			if ((aFormat[i]=="d") || (aFormat[i]=="dd"))
			{
				objPopCalendar.oDate = parseInt(aData[i], 10)
				tokensChanged ++
			}
			else if ((aFormat[i]=="m") || (aFormat[i]=="mm"))
			{
				if (((parseInt(aData[i], 10) - 1)>=0) && ((parseInt(aData[i], 10) - 1)<=11))
				{
					objPopCalendar.oMonth = parseInt(aData[i], 10) - 1
					tokensChanged ++
				}
			}
			else if ((aFormat[i]=="yy") || (aFormat[i]=="yyyy"))
			{
				objPopCalendar.oYear = parseInt(aData[i], 10)
				tokensChanged ++
				if (objPopCalendar.oYear < 100)
				{
					if (objPopCalendar.oYear < PopCal.centuryLimit)
					{
						objPopCalendar.oYear += 100
					}
					objPopCalendar.oYear += 1900
				}
			}
			else if ((aFormat[i]=="mmm") || (aFormat[i]=="mmmm"))
			{
				for (j=0; j<12;	j++)
				{
					if (aData[i])
					{
						if (aData[i].toLowerCase().substr(0,3)==objPopCalendar.monthName[j].toLowerCase().substr(0,3))
						{
							objPopCalendar.oMonth=j
							tokensChanged ++
							break
						}
					}
				}
			}
		}
	}
	return ((tokensChanged==3)&&!isNaN(objPopCalendar.oDate)&&!isNaN(objPopCalendar.oMonth)&&!isNaN(objPopCalendar.oYear))
}

function PopCalChangeCurrentMonth()
{
	if ((PopCalDateFrom().substr(0,6) <= PopCalDateNow().substr(0,6)) && (PopCalDateNow().substr(0,6) <= PopCalDateUpTo().substr(0,6)))
	{

		objPopCalendar.monthSelected=objPopCalendar.monthNow
		objPopCalendar.yearSelected=objPopCalendar.yearNow
		objPopCalendar.yearConstructed=false
		objPopCalendar.monthConstructed=false
		PopCalConstructCalendar()
	}
}

function PopCalDomingoPascuas(y)
{
	var lnCentena
	var lnAux
	var lnNroAureo
	var lnDomingo
	var lnEpactaJul
	var lnCorrSolar
	var lnCorrLunar
	var lnEpactaGreg
	var lnDiasLunaP
	var lnDiasLuna15
	var lnDiasPascua
	var dtFecIni
	var dtFecPascua
	
	lnCentena = parseInt(y/100, 10)
	lnAux = (y+1)%19
	lnNroAureo = lnAux+(19*parseInt((19-lnAux)/19, 10))
	lnDomingo = 7+(1-y-parseInt(y/4, 10)+lnCentena-parseInt(lnCentena/4, 10))%7
	lnEpactaJul = ((11*lnNroAureo)-10)%30
	lnCorrSolar = -(lnCentena-16)+parseInt((lnCentena-16)/4, 10)
	lnCorrLunar = parseInt((lnCentena-15-parseInt((lnCentena-17)/25, 10))/3, 10)
	lnEpactaGreg = (30+lnEpactaJul+lnCorrSolar+lnCorrLunar)%30
	lnDiasLunaP = 24-lnEpactaGreg+(30*parseInt(lnEpactaGreg/24, 10))
	lnDiasLuna15 = (27-lnEpactaGreg+(30*parseInt(lnEpactaGreg/24, 10)))%7
	lnDiasPascua = lnDiasLunaP+(7+lnDomingo-lnDiasLuna15)%7
	dtFecIni = new Date(y, 2, 21)
	dtFecPascua = new Date(dtFecIni -(-(lnDiasPascua * 86400000)))
	
	return (dtFecPascua)
}

function PopCalAddRegularHolidays()
{
	//Dias Feriados en Chile
	PopCalAddHoliday(1,1,0,"A" + c_nTilde + "o Nuevo","Happy New Year")
//	PopCalAddHoliday(18,4,0,"Viernes Santo", "Good Friday") // S�lo en A�o 2003
//	PopCalAddHoliday(19,4,0,"S" + c_aTilde + "bado Santo", "Saturday Saint") // S�lo en A�o 2003
	PopCalAddHoliday(1,5,0,"D" + c_iTilde + "a del Trabajo", "Labor Day")
	PopCalAddHoliday(21,5,0,"Combate Naval de Iquique", "Naval action of Iquique")
	PopCalAddHoliday(16,6,0,"Conm. Corpus Christi", "Conm. Corpus Christi")
	PopCalAddHoliday(15,8,0,"Asunci" + c_oTilde + "n de la Virgen", "Assumption of the Virgin")
	PopCalAddHoliday(18,9,0,"Fiestas Patrias", "Celebrations Mother countries")
	PopCalAddHoliday(19,9,0,"D" + c_iTilde + "a del Ej" + c_eTilde + "rcito", "Day of the Army")
	PopCalAddHoliday(1,11,0,"Todos los Santos", "All the Saints")
	PopCalAddHoliday(8,12,0,"Inmaculada Concepci" + c_oTilde + "n", "Immaculate Conception")
	PopCalAddHoliday(25,12,0,"Navidad", "Christmas")
}

var aFinMes = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31) 

  function finMes(nMes, nAno){ 
   return aFinMes[nMes - 1] + (((nMes == 2) && (nAno % 4) == 0)? 1: 0) 
  } 

   function padNmb(nStr, nLen, sChr){ 
    var sRes = String(nStr) 
    for (var i = 0; i < nLen - String(nStr).length; i++) 
     sRes = sChr + sRes 
    return sRes 
   } 

   function makeDateFormat(nDay, nMonth, nYear){ 
    var sRes 
    sRes = padNmb(nDay, 2, "0") + "/" + padNmb(nMonth, 2, "0") + "/" + padNmb(nYear, 4, "0")
    return sRes
   } 
    
  function incDate(sFec0){ 
   var nDia = parseInt(sFec0.substr(0, 2), 10) 
   var nMes = parseInt(sFec0.substr(3, 2), 10) 
   var nAno = parseInt(sFec0.substr(6, 4), 10) 
   nDia += 1 
   if (nDia > finMes(nMes, nAno)){ 
    nDia = 1 
    nMes += 1 
    if (nMes == 13){ 
     nMes = 1 
     nAno += 1 
    } 
   } 
   return makeDateFormat(nDia, nMes, nAno); 
  } 

  function decDate(sFec0){ 
   var nDia = Number(sFec0.substr(0, 2))
   var nMes = Number(sFec0.substr(3, 2)) 
   var nAno = Number(sFec0.substr(6, 4)) 
   nDia -= 1 
   if (nDia == 0){ 
    nMes -= 1 
    if (nMes == 0){ 
     nMes = 12 
     nAno -= 1 
    } 
    nDia = finMes(nMes, nAno)
   } 
   return makeDateFormat(nDia, nMes, nAno)
  } 

  function addToDate(sFec0, sInc){ 
   var nInc = Math.abs(parseInt(sInc)) 
   var sRes = sFec0 
   if (parseInt(sInc) >= 0) 
    for (var i = 0; i < nInc; i++) sRes = incDate(sRes) 
   else 
    for (var i = 0; i < nInc; i++) sRes = decDate(sRes) 
   return sRes 
  } 


function GetFecha(objTarget, FinSemanaActivo, HoyAdelanteActivo, HoyAtrasActivo){
	try{
		if (FinSemanaActivo == true) popcalendar.selectWeekendHoliday(1,1);
		else popcalendar.selectWeekendHoliday(2,2);
		popcalendar.show(objTarget, null, HoyAdelanteActivo, HoyAtrasActivo);
	}
	catch(e){alert(e.description)}
}