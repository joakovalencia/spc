<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_garantias_contrato.aspx.cs" Inherits="mn_ing_garantias_contrato" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" type="text/css" media="all" href="../../js/reloj/jsDatePick_ltr.min.css" />
    <script type="text/javascript" src="../../js/reloj/jquery.1.4.2.js"></script>
    <script type="text/javascript" src="../../js/reloj/jsDatePick.jquery.min.1.3.js"></script>
    
    <script language="jscript" type="text/jscript" src="../../js/funciones.js"></script>
    
<!--
///Modificado por: Alexi Rodríguez Barrientos - MOP
///Fecha: 22-04-2014
///Descripción: Modificación Boleta de Garantía del Contrato
///Detalle: - Se agrega evento en etiqueta boby, para mostrar fecha ingresada en textbox txtFechaNuevoVcto en el textbox txtFechaVctoVig.
///         - Se asigna valor ingresado en txtFechaNuevoVcto en txtFechaVctoVig.
///         - Se agrega boton de eliminación de registro de boleta.
 -->

<script language="JavaScript" type="text/JavaScript">
    <!--

    window.onload = function() {

        Calendario_txtFechaEmision = new JsDatePick({
            useMode: 2,
            target: "txtFechaEmision",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaVctoInicial = new JsDatePick({
            useMode: 2,
            target: "txtFechaVctoInicial",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaOfDestinoDocumento = new JsDatePick({
            useMode: 2,
            target: "txtFechaOfDestinoDocumento",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaOfSolicitudGarantia = new JsDatePick({
            useMode: 2,
            target: "txtFechaOfSolicitudGarantia",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaDevGarantia = new JsDatePick({
            useMode: 2,
            target: "txtFechaDevGarantia",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaProrroga = new JsDatePick({
            useMode: 2,
            target: "txtFechaProrroga",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaNuevoVcto = new JsDatePick({
            useMode: 2,
            target: "txtFechaNuevoVcto",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaVctoVig = new JsDatePick({
            useMode: 2,
            target: "txtFechaVctoVig",
            dateFormat: "%d/%m/%Y"
        });

    }
    
    function cmdObtenerDocSSDValida_Click() {

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Para conexión con SSD, debe ingresar un codigo de contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
            return false;
        }

        return true;
    }
    
    function func_valida_eliminar() {

        if (document.frm_datos_contrato.ddlGarantia.value == "(SELECCIONAR)") {
            alert("Debe seleccionar una garantía.");
            document.frm_datos_contrato.ddlGarantia.focus();
            return false;
        }
        
        if (document.frm_datos_contrato.txtRegion.value == "") {
            alert("Debe ingresar región.");
            document.frm_datos_contrato.txtRegion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPIA.value == "") {
            alert("Debe ingresar PIA.");
            document.frm_datos_contrato.txtPIA.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtProceso.value == "") {
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtProceso.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtSufijo.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }
        
        if (confirm("¿Seguro que desea eliminar este registro?"))
            return true;
        else
            return false;
    }
    
    function func_valida_grabar() {

        if (document.frm_datos_contrato.ddlGarantia.value == "(SELECCIONAR)") {
            alert("Debe seleccionar una garantía.");
            document.frm_datos_contrato.ddlGarantia.focus();
            return false;
        }
        
        if (document.frm_datos_contrato.txtRegion.value == "") {
            alert("Debe ingresar región.");
            document.frm_datos_contrato.txtRegion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPIA.value == "") {
            alert("Debe ingresar PIA.");
            document.frm_datos_contrato.txtPIA.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtProceso.value == "") {
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtProceso.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtSufijo.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }
        
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;
    
    }

    function func_vcto_inicial() {
        document.frm_datos_contrato.txtFechaVctoVig.value = document.frm_datos_contrato.txtFechaVctoInicial.value;
    }

    function func_vcto_nuevo() {

        if (Trim(document.frm_datos_contrato.txtFechaNuevoVcto.value) != "" && Trim(document.frm_datos_contrato.txtFechaVctoInicial.value) != "")
        {
            document.frm_datos_contrato.txtFechaVctoVig.value = document.frm_datos_contrato.txtFechaNuevoVcto.value;

            if (document.frm_datos_contrato.txtFechaNuevoVcto.value != "01/01/1900" && document.frm_datos_contrato.txtFechaVctoInicial.value != "01/01/1900") {

                dia = document.frm_datos_contrato.txtFechaNuevoVcto.value.substring(0, 2);
                mes = document.frm_datos_contrato.txtFechaNuevoVcto.value.substring(3, 5);
                ano = document.frm_datos_contrato.txtFechaNuevoVcto.value.substring(6, 10);

                var strFechaNuevoVcto = new Date(mes + "/" + dia + "/" + ano);

                dia = document.frm_datos_contrato.txtFechaVctoInicial.value.substring(0, 2);
                mes = document.frm_datos_contrato.txtFechaVctoInicial.value.substring(3, 5);
                ano = document.frm_datos_contrato.txtFechaVctoInicial.value.substring(6, 10);

                var strFechaVctoInicial = new Date(mes + "/" + dia + "/" + ano);

                //strFechaNuevoVcto = document.frm_datos_contrato.txtFechaNuevoVcto.value;
                //strFechaVctoInicial = document.frm_datos_contrato.txtFechaVctoInicial.value;
                //document.frm_datos_contrato.txtDiasProrroga.value = getDaysBetweenDates(strFechaVctoInicial, strFechaNuevoVcto);

                document.frm_datos_contrato.txtDiasProrroga.value = DateDiff.inDays(strFechaVctoInicial, strFechaNuevoVcto);
            }
        }
    }
    
    //-->

</script>    

    </head>

<body onmouseout = "javascript:return func_vcto_nuevo();"  >

<form id="frm_datos_contrato" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

    <br />
	<table style="width:90%;">
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td class="title">
                Modificación Boleta Garantía del Contrato <div class="content_small">(Contrato-Garantías)</div></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 95%">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Crea Garantías del Contrato" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>

                                <!--Se agrega boton de eliminación 22-04-2014 por ARB -->
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="return func_valida_eliminar();"/>
                                <!-- -->

                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla garantia" Visible="False"></asp:Label>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="borde_celda" colspan="2">
                            Datos del Contrato</td>
                    </tr>
                    <tr>
                        <td class="content">
                            Región</td>
                        <td class="content">
                            <asp:TextBox ID="txtRegion" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="18px"></asp:TextBox>
                        &nbsp;PIA
                            <asp:TextBox ID="txtPIA" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="18px"></asp:TextBox>
                        &nbsp;Proceso
                            <asp:TextBox ID="txtProceso" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                            &nbsp;Sufijo
                            <asp:TextBox ID="txtSufijo" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                        &nbsp;Código Contrato
                            <asp:TextBox ID="txtCodCon" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Objeto</td>
                        <td class="content">
                            <asp:TextBox ID="txtObjeto" runat="server" CssClass="content" ReadOnly="True" 
                                Width="470px" Height="18px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            <table class="content" style="width: 95%">
                                <tr>
                                    <td style="width: 20%">
                                        &nbsp;</td>
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                    <td style="width: 20%">
                                        &nbsp;</td>
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        Selección de Garantía</td>
                                </tr>
                                <tr>
                                    <td style="width: 20%">
                                        Garantía</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlGarantia" runat="server" CssClass="content" 
                                            Width="95%" Height="21px" 
                                            onselectedindexchanged="ddlGarantia_SelectedIndexChanged" 
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 20%">
                                        &nbsp;</td>
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                    <td style="width: 20%">
                                        &nbsp;</td>
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Datos de la Garantía</td>
                                </tr>
                                <tr>
                                    <td>
                                        Número</td>
                                    <td>
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="content" 
                                Width="160px" Height="18px" MaxLength="15"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha Emisión</td>
                                    <td >
                                    
                                        <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="content" ReadOnly="True" 
                                        Width="80px" Height="20px"></asp:TextBox>
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Documento</td>
                                    <td>
                                    
                                        <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="content" 
                                            Width="80%" Height="21px">
                                            <asp:ListItem Selected="True">(SELECCIONAR)</asp:ListItem>
                                            <asp:ListItem Value="Póliza">Póliza</asp:ListItem>
                                            <asp:ListItem Value="Boleta">Boleta</asp:ListItem>
                                        </asp:DropDownList>
                                    
                                    </td>
                                    <td>
                                        Moneda</td>
                                    <td>
                                        <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="content" 
                                            Width="70%" Height="21px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Monto</td>
                                    <td>
                            <asp:TextBox ID="txtMonto" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        Tipo Garantía</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoGarantia" runat="server" CssClass="content" 
                                            Width="95%" Height="21px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ent. Financiera</td>
                                    <td>
                            <asp:TextBox ID="txtEntFinanciera" runat="server" CssClass="content" 
                                Width="215px" Height="20px" MaxLength="50"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha Vcto Inicial</td>
                                    <td onmouseout="javascript:return func_vcto_inicial();">
                            <asp:TextBox ID="txtFechaVctoInicial" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px" onblur = "javascript:return func_vcto_inicial();"
                                 onmouseout = "javascript:return func_vcto_inicial();"
                                 onmouseover = "javascript:return func_vcto_inicial();"></asp:TextBox>
                             <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr> <!-- -->
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <b>Vcto. Vigente</b></td>
                                    <td>
                                           <asp:TextBox ID="txtFechaVctoVig" runat="server" CssClass="content" ReadOnly="True" 
                                               Width="80px" Height="20px"></asp:TextBox>
                                           <asp:Image ID="Image10" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <b>Días Prorrogados</b></td>
                                    <td>
                            <asp:TextBox ID="txtDiasProrroga" runat="server" CssClass="content" 
                                Width="100px" Height="18px" MaxLength="4" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Oficio Destino Documento N°
                            <asp:TextBox ID="txtNumOfDestinoDocumento" runat="server" CssClass="content" 
                                Width="100px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtFechaOfDestinoDocumento" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Of. Solicitud de Garantía N°&nbsp;&nbsp;
                            <asp:TextBox ID="txtNumOfSolicitudGarantia" runat="server" CssClass="content" 
                                Width="100px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtFechaOfSolicitudGarantia" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        Entidad que custodia el documento
                            <asp:TextBox ID="txtEntCustodiaDocumento" runat="server" CssClass="content" 
                                Width="331px" Height="18px" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Devolución Garantia</td>
                                    <td>
                            <asp:TextBox ID="txtFechaDevGarantia" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Devuelta (S/N)</td>
                                    <td>
                                        <asp:DropDownList ID="ddlDevuelta" runat="server" CssClass="content" 
                                            Width="50%" Height="21px">
                                            <asp:ListItem Selected="True">(SELECCIONAR)</asp:ListItem>
                                            <asp:ListItem Value="S">Si</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Prorroga Vencimiento Boleta</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Fecha Docto que prorroga la boleta</td>
                                    <td>
                            <asp:TextBox ID="txtFechaProrroga" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Fecha Nuevo Vencimiento</td>
                                    <td>
                            <asp:TextBox ID="txtFechaNuevoVcto" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px" onblur = "javascript:return func_vcto_nuevo();" 
                                            onmouseout = "javascript:return func_vcto_nuevo();" 
                                            onmouseover = "javascript:return func_vcto_nuevo();">
                            </asp:TextBox>
                                            <asp:Image ID="Image9" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    
                                </tr>
                                </table>
                        </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                &nbsp;</td>
        </tr>
        </table>
    <br />
    <br />
</div>

<div class="footer" >
    <strong>USUARIO: </strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label ID="lblCorreo" runat="server" CssClass="content"></asp:Label>
    <strong> GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
</div>

</form>

</body>
</html>
