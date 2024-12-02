
function func_change_gridrow_color(estado, color, obj)
{
	if (estado=="over")
	{
	    obj.style.backgroundColor= color;
	    obj.style.cursor="hand";
	}
	else
	{
	    obj.style.backgroundColor= color;
	    obj.style.cursor="cross";
	}
}


function valida_rut_dv(T)
{
    var M=0,S=1;for(;T;T=Math.floor(T/10))S=(S+T%10*(9-M++%6))%11;return S?S-1:'k';
}

function func_ventana_emergente(url) 
{
   retorno = window.open(url,null,'width=500, height=500, menubar=no, resizable=no, fullscreen = no, scrollbars = no');
   return retorno;
}

function valida_numeros(variable, valor_input) 
{
	switch (variable)
	{
		case 48: break;
		case 49: break;
		case 50: break;
		case 51: break;
		case 52: break;
		case 53: break;
		case 54: break;
		case 55: break;
		case 56: break;
		case 57: break;
		default: window.event.keyCode=0;
	}
}

function valida_decimal(numero)
{
  if (!/^([0-9])*[.]?[0-9]*$/.test(numero)) return false;
  return true;
}

function validaFloat(numero)
{
  if (!/^([0-9])*[.]?[0-9]*$/.test(numero))
   alert("El valor " + numero + " no es un número");
}

function valida_numeros_decimal(variable, valor_input, cantidad_decimales) 
{    
	switch (variable)
	{
		case 48: break;
		case 49: break;
		case 50: break;
		case 51: break;
		case 52: break;
		case 53: break;
		case 54: break;
		case 55: break;
		case 56: break;
		case 57: break;
		case 44: break; //coma decimal
		default: window.event.keyCode=0;
	}
}

function selectItemByValue(elmnt, value)
{
    for(var i=0; i < elmnt.options.length; i++)
    {
    
        if(elmnt.options[i].value == value)
            elmnt.selectedIndex = i;
    }
}


function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;

        if (e.keyCode == 46) tecla = 0;
        
        return ((tecla > 47 && tecla < 58) || tecla == 46);
    }

    function ValidNum2(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;

        if (e.keyCode == 46) tecla = 0;

        return ((tecla > 47 && tecla < 58) || tecla == 46 || tecla == 45);
    }


function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return true;

    return false;
}    


function digits(obj, e, allowDecimal, allowNegative) {
        var key;
        var isCtrl = false;
        var keychar;
        var reg;

        if (window.event) {
            key = e.keyCode;
            isCtrl = window.event.ctrlKey
        }
        else if (e.which) {
            key = e.which;
            isCtrl = e.ctrlKey;
        }

        if (isNaN(key)) return true;

        keychar = String.fromCharCode(key);

        // check for backspace or delete, or if Ctrl was pressed
        if (key == 8 || isCtrl) {
            return true;
        }

        reg = /\d/;
        var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
        var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;

        return isFirstN || isFirstD || reg.test(keychar);
    }


    function Trim(myString)
    {
    return myString.replace(/^\s+/g,'').replace(/\s+$/g,'')
    }

    function getDaysBetweenDates(first, second) {

        //12/05/2012
        // Copy date parts of the timestamps, discarding the time parts.
        var one = new Date(first.substr(6, 4), first.substr(3, 2), first.substr(0, 2));
        var two = new Date(second.substr(6, 4), second.substr(3, 2), second.substr(0, 2));

        // Do the math.
        var millisecondsPerDay = 1000 * 60 * 60 * 24;
        var millisBetween = two.getTime() - one.getTime();
        var days = millisBetween / millisecondsPerDay;

        // Round down.
        if (second == "" || first == "")
            return Math.floor(0);
        else
            return Math.floor(days);
    }
  

    /************************************************************************************************************/
    // OnKeyPress="return isNumberKey(this, event);"  onBlur="mathRoundForTaxes(this.id,0);" onfocus="dropComa(this.id);" onpaste="return false;"
    
        function isNumberKey(sender, evt) 
        { 
            var txt = sender.value;
            var dotcontainer = txt.split(','); 
            var charCode = (evt.which) ? evt.which : event.keyCode;     
            //46 -> punto .
            //44 -> coma ,
            //45 -> guion -
                        
            if (charCode == 45)
            {
                if (txt.indexOf("-") == -1)
                {
                    sender.value= "-" + sender.value;
                    return false;
                }
            }
            
            if (!(dotcontainer.length == 1 && charCode == 44 ) && charCode > 31 && (charCode < 48 || charCode > 57)) 
            {   
                return false;
            }   
            return true; 
        }
      
        function dropComa (source)
        {
            var txtBox = document.getElementById(source);
            
            var strReg = txtBox.value;
            
            strReg = strReg.replace(".","");
            strReg = strReg.replace(".","");
            strReg = strReg.replace(".","");
            strReg = strReg.replace(".","");
            strReg = strReg.replace(".","");
            
            txtBox.value = strReg;
        }
      
        function mathRoundForTaxes(source, decplaces) 
        {   
            
            var txtBox = document.getElementById(source);

            if (txtBox.value == ",")
                txtBox.value = "0";

            if (txtBox.value == "")
                txtBox.value = "0";

            if (txtBox.value.indexOf(",") == 0)
                txtBox.value = txtBox.value.replace(",","");
            
            var txt = txtBox.value.replace(",",".");
            var diviporc = "1" + repeat("0",decplaces);            
            if (!isNaN(txt) && isFinite(txt) && txt.length != 0) { 
            var rounded = Math.round(txt * diviporc) / diviporc;             
            
            var strReg = addCommas(rounded.toFixed(decplaces));
            strReg = strReg.replace(".","x");
            
            strReg = strReg.replace(",",".");
            strReg = strReg.replace(",",".");
            strReg = strReg.replace(",",".");
            strReg = strReg.replace(",",".");
            strReg = strReg.replace(",",".");
            strReg = strReg.replace(",",".");
            strReg = strReg.replace(",",".");
            
            strReg = strReg.replace("x",",");
                        
            txtBox.value = strReg ;
            } 
        }
        
        function repeat(str, times) {
            return new Array(times + 1).join(str);
        }
        
        function addCommas(nStr)
        {
            nStr += '';
            x = nStr.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
	            x1 = x1.replace(rgx, '$1' + ',' + '$2');
            }
            return x1 + x2;
        }

        function FUNC_MontoSQLv2(Value) {

            var strReg = Value;

            strReg = strReg.replace(".", "");
            strReg = strReg.replace(".", "");
            strReg = strReg.replace(".", "");
            strReg = strReg.replace(".", "");
            strReg = strReg.replace(".", "");
            strReg = strReg.replace(".", "");
            strReg = strReg.replace(".", "");
            strReg = strReg.replace(".", "");
            strReg = strReg.replace(".", "");

            strReg = strReg.replace(",", ".");

            return strReg;
        }

        function FUNC_MontoASPv2(Value) {

            var strReg = Value;
            
            strReg = strReg.replace(",", ".");
            strReg = strReg.replace(",", ".");
            strReg = strReg.replace(",", ".");
            strReg = strReg.replace(",", ".");
            strReg = strReg.replace(",", ".");
            strReg = strReg.replace(",", ".");
            strReg = strReg.replace(",", ".");
            strReg = strReg.replace(",", ".");

            strReg = strReg.replace("x", ".");

            return strReg;
        }

        /************************************************************************************************************/

        function dateFormat(date, format) {
            // Calculate date parts and replace instances in format string accordingly
            format = format.replace("DD", (date.getDate() < 10 ? '0' : '') + date.getDate()); // Pad with '0' if needed
            format = format.replace("MM", (date.getMonth() < 9 ? '0' : '') + (date.getMonth() + 1)); // Months are zero-based
            format = format.replace("YYYY", date.getFullYear());
            return format;
        }
        
        function DateAdd(objDate, strInterval, intIncrement) {
            if (typeof (objDate) == "string") {
                objDate = new Date(objDate);

                if (isNaN(objDate)) {
                    throw ("DateAdd: Date is not a valid date");
                }
            }
            else if (typeof (objDate) != "object" || objDate.constructor.toString().indexOf("Date()") == -1) {
                throw ("DateAdd: First parameter must be a date object");
            }

            if (
        strInterval != "M"
        && strInterval != "D"
        && strInterval != "Y"
        && strInterval != "h"
        && strInterval != "m"
        && strInterval != "uM"
        && strInterval != "uD"
        && strInterval != "uY"
        && strInterval != "uh"
        && strInterval != "um"
        && strInterval != "us"
        ) {
                throw ("DateAdd: Second parameter must be M, D, Y, h, m, uM, uD, uY, uh, um or us");
            }

            if (typeof (intIncrement) != "number") {
                throw ("DateAdd: Third parameter must be a number");
            }

            switch (strInterval) {
                case "M":
                    objDate.setMonth(parseInt(objDate.getMonth()) + parseInt(intIncrement));
                    break;

                case "D":
                    objDate.setDate(parseInt(objDate.getDate()) + parseInt(intIncrement));
                    break;

                case "Y":
                    objDate.setYear(parseInt(objDate.getYear()) + parseInt(intIncrement));
                    break;

                case "h":
                    objDate.setHours(parseInt(objDate.getHours()) + parseInt(intIncrement));
                    break;

                case "m":
                    objDate.setMinutes(parseInt(objDate.getMinutes()) + parseInt(intIncrement));
                    break;

                case "s":
                    objDate.setSeconds(parseInt(objDate.getSeconds()) + parseInt(intIncrement));
                    break;

                case "uM":
                    objDate.setUTCMonth(parseInt(objDate.getUTCMonth()) + parseInt(intIncrement));
                    break;

                case "uD":
                    objDate.setUTCDate(parseInt(objDate.getUTCDate()) + parseInt(intIncrement));
                    break;

                case "uY":
                    objDate.setUTCFullYear(parseInt(objDate.getUTCFullYear()) + parseInt(intIncrement));
                    break;

                case "uh":
                    objDate.setUTCHours(parseInt(objDate.getUTCHours()) + parseInt(intIncrement));
                    break;

                case "um":
                    objDate.setUTCMinutes(parseInt(objDate.getUTCMinutes()) + parseInt(intIncrement));
                    break;

                case "us":
                    objDate.setUTCSeconds(parseInt(objDate.getUTCSeconds()) + parseInt(intIncrement));
                    break;
            }
            return objDate;
        }


        var DateDiff = {

            inDays: function(d1, d2) {
                var t2 = d2.getTime();
                var t1 = d1.getTime();

                return parseInt((t2 - t1) / (24 * 3600 * 1000));
            },

            inWeeks: function(d1, d2) {
                var t2 = d2.getTime();
                var t1 = d1.getTime();

                return parseInt((t2 - t1) / (24 * 3600 * 1000 * 7));
            },

            inMonths: function(d1, d2) {
                var d1Y = d1.getFullYear();
                var d2Y = d2.getFullYear();
                var d1M = d1.getMonth();
                var d2M = d2.getMonth();

                return (d2M + 12 * d2Y) - (d1M + 12 * d1Y);
            },

            inYears: function(d1, d2) {
                return d2.getFullYear() - d1.getFullYear();
            }
           }

           function esFechaFuturo(valor) 
           {         
		//Javascript trabaja los meses desde cero.
  	
           	var Ahora = new Date();
           	var Fecha = new Date(valor.substr(6, 4) , Number(valor.substr(3, 2))-1 , valor.substr(0, 2));

           	return  Fecha > Ahora
           }