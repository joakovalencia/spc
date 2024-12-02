<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_detalle_termino_contrato.aspx.cs" Inherits="mn_detalle_termino_contrato" %>

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
    
<script language="JavaScript" type="text/JavaScript">
    <!--

    window.onload = function() {

        Calendario_txtFechaSolRecepContratista = new JsDatePick({
            useMode: 2,
            target: "txtFechaSolRecepContratista",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtFechaTermFisInfITO = new JsDatePick({
            useMode: 2,
            target: "txtFechaTermFisInfITO",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtLAFechaActaRecep = new JsDatePick({
            useMode: 2,
            target: "txtLAFechaActaRecep",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtLAFechaLiqAnticip = new JsDatePick({
            useMode: 2,
            target: "txtLAFechaLiqAnticip",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtLAFechaDoc = new JsDatePick({
            useMode: 2,
            target: "txtLAFechaDoc",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtRPFechaResComp = new JsDatePick({
            useMode: 2,
            target: "txtRPFechaResComp",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtRPFechaInfObs = new JsDatePick({
            useMode: 2,
            target: "txtRPFechaInfObs",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtRPFechaActa = new JsDatePick({
            useMode: 2,
            target: "txtRPFechaActa",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtRPFechaTermReal = new JsDatePick({
            useMode: 2,
            target: "txtRPFechaTermReal",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtRPFechaRepMuni = new JsDatePick({
            useMode: 2,
            target: "txtRPFechaRepMuni",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtAEFechaActa = new JsDatePick({
            useMode: 2,
            target: "txtAEFechaActa",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtRDFechaInfObs = new JsDatePick({
            useMode: 2,
            target: "txtRDFechaInfObs",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtRDFechaActa = new JsDatePick({
            useMode: 2,
            target: "txtRDFechaActa",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtRDFechaRecepDef = new JsDatePick({
            useMode: 2,
            target: "txtRDFechaRecepDef",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtLQFecha = new JsDatePick({
            useMode: 2,
            target: "txtLQFecha",
            dateFormat: "%d/%m/%Y"
        });
    } 
    function func_valida_eliminar() {

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

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
            return false;
        }            
        
        if (confirm("¿Seguro que desea eliminar este registro?"))
            return true;
        else
            return false;
    }
    
    function func_valida_grabar() {

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

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlAEReservadas.value == "S")
        {
            if (document.frm_datos_contrato.txtAEPlazo.value == "" || document.frm_datos_contrato.txtAEMonto.value == "" || document.frm_datos_contrato.txtAEPlazo.value == "0" || document.frm_datos_contrato.txtAEMonto.value == "0") {
                alert("Debe ingresar codigo Plazo Dias y Monto, sección Acta Entrega Explotación.");
                document.frm_datos_contrato.txtAEPlazo.focus();
                return false;
            }
        }
        
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;
    
    }
    
    //-->

</script>    

    </head>

<body>

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
                Detalle Termino de Contrato <div class="content_small">(Contrato-Contrato Termino)</div></td>
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
                                ToolTip="Crea Termino de Contrato" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Cancela Contrato" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla CONTRATO_TERMINO" 
                                Visible="False"></asp:Label>
                        </td>
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
                    <tr>
                        <td class="content">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
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
                                    <td style="width: 25%">
                                        &nbsp;</td>
                                    <td style="width: 15%">
                                        &nbsp;</td>
                                    <td style="width: 25%">
                                        &nbsp;</td>
                                    <td style="width: 35%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Inicio Proceso Termino</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Fecha Solicitud Recepción del Contratista</td>
                                    <td>
                            <asp:TextBox ID="txtFechaSolRecepContratista" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Responsable Termino Contrato</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Fecha Término físico informada por ITO</td>
                                    <td>
                            <asp:TextBox ID="txtFechaTermFisInfITO" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRespTermContrato" runat="server" CssClass="content" 
                                            Width="95%">
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
                                    <td colspan="4" class="borde_celda">
                                        Recepción Unica o Liquidación Anticipada</td>
                                </tr>
                                <tr>
                                    <td>
                                        Comisión Nº Res.</td>
                                    <td>
                            <asp:TextBox ID="txtLAComisionNumRes" runat="server" CssClass="content" 
                                Width="80px" Height="20px" onkeypress="return digits(this, event, true, true);" 
                                            MaxLength="10"></asp:TextBox>
                                    &nbsp;</td>
                                    <td>
                                        Fecha Comisión</td>
                                    <td>
                            <asp:TextBox ID="txtLAFechaLiqAnticip" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Acta Recpción</td>
                                    <td>
                            <asp:TextBox ID="txtLAFechaActaRecep" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Integrantes</td>
                                    <td>
                            <asp:TextBox ID="txtLAIntegrantes" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        ¿Es una liquidación anticipada s/n?</td>
                                    <td>
                                        <asp:DropDownList ID="ddlLAAnticipada" runat="server" CssClass="content">
                                            <asp:ListItem Value="0">(SELECCIONAR)</asp:ListItem>
                                            <asp:ListItem Value="S">Si</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                            <asp:TextBox ID="txtLAIntegrantes2" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
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
                            <asp:TextBox ID="txtLAIntegrantes3" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        RF5.Liquidaciones anticipada visadas por el D.R. con Nº Docto</td>
                                    <td>
                            <asp:TextBox ID="txtLANumDoc" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                                        <asp:TextBox ID="txtLAFechaDoc" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                    <td colspan="4" class="borde_celda">
                                        Recepción Provisional</td>
                                </tr>
                                <tr>
                                    <td >
                                        Comisión Nº Res.</td>
                                    <td>
                            <asp:TextBox ID="txtRPComisionNumRes" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        Plazo en días</td>
                                    <td>
                            <asp:TextBox ID="txtRPPlazo" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtRPFechaResComp" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Fecha Térm. Real</td>
                                    <td>
                            <asp:TextBox ID="txtRPFechaTermReal" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image13" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        Fecha Informe de Observaciones</td>
                                    <td>
                            <asp:TextBox ID="txtRPFechaInfObs" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image10" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Integrantes</td>
                                    <td>
                            <asp:TextBox ID="txtRPIntegrantes" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        Fecha Acta Recpción Provisional</td>
                                    <td>
                            <asp:TextBox ID="txtRPFechaActa" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image11" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                            <asp:TextBox ID="txtRPIntegrantes2" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                            <asp:TextBox ID="txtRPIntegrantes3" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        Cert. Municipal Nº</td>
                                    <td>
                            <asp:TextBox ID="txtRPNumCertRepMuni" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Fecha
                            <asp:TextBox ID="txtRPFechaRepMuni" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image12" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        Acta Entrega Explotacion</td>
                                </tr>
                                <tr>
                                    <td>
                                        Calificación</td>
                                    <td>
                            <asp:TextBox ID="txtAEClasif" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="4"></asp:TextBox>
                                    </td>
                                    <td>
                                        Mandatario que Entrega</td>
                                    <td>
                            <asp:TextBox ID="txtAEMandatEntreg" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Acta</td>
                                    <td>
                            <asp:TextBox ID="txtAEFechaActa" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image14" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Mandante que Recibe</td>
                                    <td>
                            <asp:TextBox ID="txtAEMandatRecib" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
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
                                    <td>
                                        Reservas</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAEReservadas" runat="server" CssClass="content">
                                            <asp:ListItem Value="0">(SELECCIONAR)</asp:ListItem>
                                            <asp:ListItem Value="S">Si</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Plazo Dias</td>
                                    <td>
                            <asp:TextBox ID="txtAEPlazo" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Monto $</td>
                                    <td>
                            <asp:TextBox ID="txtAEMonto" runat="server" CssClass="content" 
                                Width="154px" Height="20px" MaxLength="10"></asp:TextBox>
                                    </td>
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
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        Recepción Definitiva</td>
                                </tr>
                                <tr>
                                    <td>
                                        Comisión Nº Res.</td>
                                    <td>
                            <asp:TextBox ID="txtRDComRes" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtRDFechaRecepDef" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image17" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Informe de Observaciones</td>
                                    <td>
                            <asp:TextBox ID="txtRDFechaInfObs" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image15" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Plazo en días</td>
                                    <td>
                            <asp:TextBox ID="txtRDPlazoRecepDef" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Acta Recpción Definitiva</td>
                                    <td>
                            <asp:TextBox ID="txtRDFechaActa" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image16" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Integrantes</td>
                                    <td>
                            <asp:TextBox ID="txtRDIntegrantes" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
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
                            <asp:TextBox ID="txtRDIntegrantes2" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
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
                            <asp:TextBox ID="txtRDIntegrantes3" runat="server" CssClass="content" 
                                Width="95%" Height="20px" MaxLength="60"></asp:TextBox>
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
                                    <td colspan="4" class="borde_celda">
                                        Liquidación</td>
                                </tr>
                                <tr>
                                    <td>
                                        Nº Res.</td>
                                    <td>
                            <asp:TextBox ID="txtLQNumRes" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        Autoridad que liquida</td>
                                    <td>
                            <asp:TextBox ID="txtLQAutoridasLiq" runat="server" CssClass="content" 
                                Width="95%" Height="20px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Fecha</td>
                                    <td valign="top">
                            <asp:TextBox ID="txtLQFecha" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image18" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td valign="top">
                                        Obs Relevantes al termino</td>
                                    <td>
                            <asp:TextBox ID="txtLQObs" runat="server" CssClass="content" 
                                Width="95%" Height="103px" TextMode="MultiLine" MaxLength="300"></asp:TextBox>
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
                                    <td colspan="4" class="borde_celda">
                                        Conexión SSD</td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:ImageButton ID="cmdObtenerDocSSD" runat="server" 
                                        ImageUrl="~/img/plantilla/download.png" 
                                        ToolTip="Descargar documentos desde SSD" onclick="cmdObtenerDocSSD_Click" />
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
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label ID="lblCorreo" runat="server" CssClass="content"></asp:Label>
    <strong> GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
</div>

</form>

</body>
</html>
