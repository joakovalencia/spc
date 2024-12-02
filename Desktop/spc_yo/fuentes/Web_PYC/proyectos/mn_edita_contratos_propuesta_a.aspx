<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mn_edita_contratos_propuesta_a.aspx.vb" Inherits="proyectos_mn_edita_contratos_propuesta_a" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">    

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings("TituloSistema").ToString())%></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" type="text/css" media="all" href="../js/reloj/jsDatePick_ltr.min.css" />
    <script type="text/javascript" src="../js/reloj/jquery.1.4.2.js"></script>
    <script type="text/javascript" src="../js/reloj/jsDatePick.jquery.min.1.3.js"></script>
    
    <script language="jscript" type="text/jscript" src="../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
    <!--

    window.onload = function () {

        Calendario_txtFechaPermEdificacion = new JsDatePick({
            useMode: 2,
            target: "txtFechaPermEdificacion",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaPublicacion = new JsDatePick({
            useMode: 2,
            target: "txtFechaPublicacion",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtFechaAperturaTecnica = new JsDatePick({
            useMode: 2,
            target: "txtFechaAperturaTecnica",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaAperturaEconomica = new JsDatePick({
            useMode: 2,
            target: "txtFechaAperturaEconomica",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaEstimada = new JsDatePick({
            useMode: 2,
            target: "txtFechaEstimada",
            dateFormat: "%d/%m/%Y"
        });


        Calendario_txtFechaDoctoR26 = new JsDatePick({
            useMode: 2,
            target: "txtFechaDoctoR26",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaDoctoR28 = new JsDatePick({
            useMode: 2,
            target: "txtFechaDoctoR28",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaDoctoR29 = new JsDatePick({
            useMode: 2,
            target: "txtFechaDoctoR29",
            dateFormat: "%d/%m/%Y"
        });

} 
    
    function func_txtAnticipoContempladoPorc() {

        if (document.frm_datos_contrato.txtAnticipoContempladoPorc.value != "") {
            document.frm_datos_contrato.txtAnticipoContemplado.value =
                (parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtPresupEstimado.value))
                    * parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtAnticipoContempladoPorc.value))) / 100;

            document.frm_datos_contrato.txtAnticipoContemplado.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.txtAnticipoContemplado.value));
        }
    
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

        if (document.frm_datos_contrato.txtSufijo.value == "") {
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlTipoLicitacion.value == "(SELECCIONAR)" ) {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Tipo Licitación.");
            document.frm_datos_contrato.ddlTipoLicitacion.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlMoContratacion.value == "(SELECCIONAR)" ) {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Monto Contratacion.");
            document.frm_datos_contrato.ddlMoContratacion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPresupEstimado.value == "0" || document.frm_datos_contrato.txtPresupEstimado.value == "" ) {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Presupuesto Estimado.");
            document.frm_datos_contrato.txtPresupEstimado.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPlazoEstimado.value == "0" || document.frm_datos_contrato.txtPlazoEstimado.value == "") {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Plazo Estimado.");
            document.frm_datos_contrato.txtPlazoEstimado.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlRegistro.value == "(SELECCIONAR)" ) {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Registro.");
            document.frm_datos_contrato.ddlRegistro.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaPublicacion.value == "" || document.frm_datos_contrato.txtFechaPublicacion.value == "01/01/1900") {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Fecha Publicación.");
            document.frm_datos_contrato.txtFechaPublicacion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaAperturaTecnica.value == "" || document.frm_datos_contrato.txtFechaAperturaTecnica.value == "01/01/1900") {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Fecha Apertura Tecnica.");
            document.frm_datos_contrato.txtFechaAperturaTecnica.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaAperturaEconomica.value == "" || document.frm_datos_contrato.txtFechaAperturaEconomica.value == "01/01/1900") {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Fecha Apertura Economica.");
            document.frm_datos_contrato.txtFechaAperturaEconomica.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaEstimada.value == "" || document.frm_datos_contrato.txtFechaEstimada.value == "01/01/1900") {
            alert("Para cambiar a Estado 'Programado': Debe ingresar Fecha Inicio Estimada");
            document.frm_datos_contrato.txtFechaEstimada.focus();
            return false;
        }
                
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;

    }
    
    //-->

</script>    

    <style type="text/css">
        .style2
        {
            width: 26%;
        }
        .style3
        {
            width: 15%;
        }
        .style4
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            width: 15%;
        }
        .style5
        {
            width: 25%;
        }
        .style6
        {
            height: 24px;
        }
        .style7
        {
            width: 26%;
            height: 24px;
        }
        .style8
        {
            width: 15%;
            height: 24px;
        }
        .style9
        {
            width: 25%;
            height: 24px;
        }
        .style10
        {
            border: thin solid #008BD5;
            color: #666666;
            font-family: Verdana,sans-serif;
            height: 24px;
        }
        .style11
        {
            width: 93px;
        }
    </style>

    </head>

<body>

<form id="frm_datos_contrato" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

    <br />
	<table style="width:90%;">
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td class="title">
                Edición de Contratos (Propuesta)<div class="content_small">(Contrato)</div></td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 95%">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Grabar Contrato" onclick="cmdGrabar_Click" OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdSeguir" runat="server" 
                                ImageUrl="~/img/plantilla/next.png" 
                                ToolTip="Seguir"  onclick="cmdSeguir_Click" 
                                />
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla Contrato" Visible="False"></asp:Label>
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
                            Estado</td>
                        <td class="content">
                            <asp:TextBox ID="txtEstado" runat="server" CssClass="content" ReadOnly="True" 
                                Width="223px" Height="18px"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
               
                    </table>
            </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td style="width: 933px;">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td class="style11">
                &nbsp;</td>
            <td style="width: 933px;">
                            <br />
                            <table class="content" style=" width:101%">
                                <tr>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6"  class="borde_celda">
                                        A) PROGRAMACIÓN LICITACIÓN - Programado = Por Licitar</td>
                                </tr>
                                <tr>
                                    <td>
                                        Reg. Especial (S/N)</td>
                                    <td class="style2">
                                        <asp:DropDownList ID="ddlReqRegEspecial" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">                    
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3">
                                        Tipo Licitación</td>
                                    <td class="style5">
                                        <asp:DropDownList ID="ddlTipoLicitacion" runat="server" CssClass="content" 
                                            Height="16px" Width="95%" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Reajuste</td>
                                    <td class="style2">
                                        <asp:DropDownList ID="ddlTipoReajuste" runat="server" CssClass="content" 
                                            Height="16px" Width="225px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3">
                                        Mod. Contratación</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlMoContratacion" runat="server" CssClass="content" 
                                            Height="16px" Width="95%" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="borde_celda_small">
                                        <b>Bases Administrativas</b></td>
                                    <td class="style4">
                                        Presup. Estimado</td>
                                    <td class="style5">
                            <asp:TextBox ID="txtPresupEstimado" runat="server" CssClass="content" 
                                Width="150px" Height="18px" MaxLength="15" 
                                            onkeypress="return digits(this, event, true, true);"></asp:TextBox>
                                    </td>
                                    <td>
                                        Plazo Estimado</td>
                                    <td>
                            <asp:TextBox ID="txtPlazoEstimado" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borde_left_celda">
                                        Especiales</td>
                                    <td class="style2">
                                        <asp:DropDownList ID="ddlBAEspeciales" runat="server" CssClass="content" 
                                            Height="18px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style4">
                                        Anticipo Contemplado</td>
                                    <td class="style5">
                            <asp:TextBox ID="txtAnticipoContemplado" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="10" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        % Anticipo Contemplado</td>
                                    <td>
                            <asp:TextBox ID="txtAnticipoContempladoPorc" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="5" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borde_left_celda">
                                        Generales</td>
                                    <td class="style2">
                                        <asp:DropDownList ID="ddlBAGerenciales" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3">
                                        Registro</td>
                                    <td class="style5">
                                        <asp:DropDownList ID="ddlRegistro" runat="server" CssClass="content_small" 
                                            Height="16px" Width="95%" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Categoria</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="content_small" 
                                            Height="16px" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borde_left_celda">
                                        Tecnicas</td>
                                    <td class="style2">
                                        <asp:DropDownList ID="ddlBATecnicas" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="borde_left_celda">
                                        Carpeta Tecnica Licitación</td>
                                    <td class="style2">
                                        <asp:DropDownList ID="ddlBACarpetaTecnica" runat="server" CssClass="content" 
                                            Height="18px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style3">
                                        Responsable <div class="content_small">(preparación antecedentes propuesta)</div> </td>
                                    <td class="style5">
                                        <asp:DropDownList ID="ddlRespAntPPTA" runat="server" CssClass="content_small" 
                                            Height="18px" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        ID ChileCompra</td>
                                    <td>
                            <asp:TextBox ID="txtIDChileCompra" runat="server" CssClass="content" 
                                Width="131px" Height="18px" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                               
                               <tr>
                                <td>
                                    Diseño pasivo y EE
                                </td>
                                <td class="style2">
                                <asp:DropDownList ID="ddlCes" runat="server" CssClass="content_small" 
                                            Height="18px" Width="85%">
                                        </asp:DropDownList>
                                </td>
                               </tr>
                               
                                <tr>
                               
                                    <td class="style6">
                                        </td>
                                    <td class="style7">
                                        </td>
                                    <td class="style8">
                                        </td>
                                    <td class="style9">
                                        </td>
                                    <td colspan="2" class="style10">
                                        <b>Permiso Edificación</b></td>
                                </tr>
                                <tr>
                                    <td class="style6">
                                        Publicación</td>
                                    <td class="style7">
                    <asp:TextBox ID="txtFechaPublicacion" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                        </td>
                                    <td class="style8">
                                        Apertura Económica</td>
                                    <td class="style9">
                    <asp:TextBox ID="txtFechaAperturaEconomica" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                        </td>
                                    <td>
                                        Nº</td>
                                    <td>
                            <asp:TextBox ID="txtNumeroPermEdificacion" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        Fecha</td>
                                    <td>
                    <asp:TextBox ID="txtFechaPermEdificacion" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Apertura Técnica</td>
                                    <td class="style2">
                                        <asp:TextBox ID="txtFechaAperturaTecnica" runat="server" CssClass="content" 
                                            ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Fecha Inicio Estimada</td>
                                    <td class="style2">
                                        <asp:TextBox ID="txtFechaEstimada" runat="server" CssClass="content" 
                                            Height="22px" ReadOnly="True" Width="100px" ></asp:TextBox>
                                        <asp:Image ID="Image8" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                            <asp:Button ID="cmdPropuestaTentativa" runat="server" CssClass="content" 
                                            Text="Prgramación Financiera Estimada" Width="250px" Height="26px" Font-Strikeout="False" 
                                            onclick="cmdProgramacion_Tentativa_OnClick" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                                    <asp:DropDownList ID="ddlAplicaCartillaR26" runat="server" CssClass="content_small" Visible="False" ></asp:DropDownList>
                                    <asp:TextBox ID="txtFechaDoctoR26" runat="server" CssClass="content" Visible="False"></asp:TextBox>
                                    <asp:DropDownList ID="ddlAplicaCartillaR28" runat="server" CssClass="content_small" Visible="False"></asp:DropDownList>
                                   <asp:TextBox ID="txtFechaDoctoR28" runat="server" CssClass="content" ReadOnly="True" Width="100px" Height="22px" Visible="False"></asp:TextBox>
                                       
                                
                    
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                    
                                        <asp:DropDownList ID="ddlAplicaCartillaR29" runat="server" CssClass="content_small" Visible="False"></asp:DropDownList>
                                        <asp:TextBox ID="txtFechaDoctoR29" runat="server" CssClass="content" ReadOnly="True" Width="100px" Height="22px" Visible="False"></asp:TextBox>
                    
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td class="style5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            
                        </td>
                </tr>
        </table>
    
</div>

<div class="footer" >
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"> </asp:Label> <asp:Label ID="lblCorreo" runat="server" CssClass="content"> </asp:Label>
    <strong> GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"> </asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"> </asp:Label>
</div>

</form>

</body>
</html>

