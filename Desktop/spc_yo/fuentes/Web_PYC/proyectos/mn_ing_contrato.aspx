<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_contrato.aspx.cs" Inherits="mn_ing_contrato" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    <script language="jscript" type="text/jscript" src="../js/funciones.js"></script>

<script language="JavaScript" type="text/JavaScript">
    <!--
  
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

        if (document.frm_datos_contrato.ddlCorrConvenio.value == "(SELECCIONAR)") {
            alert("Debe seleccionar correlativo convenio.");
            document.frm_datos_contrato.ddlCorrConvenio.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlMandante.value == "(SELECCIONAR)" || document.frm_datos_contrato.ddlMandante.value == "")        
        {
            alert("Debe seleccionar mandante.");
            document.frm_datos_contrato.ddlMandante.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlEtapa.value == "(SELECCIONAR)") {
            alert("Debe seleccionar etapa.");
            document.frm_datos_contrato.ddlEtapa.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlProceso.value == "(SELECCIONAR)") {
            alert("Debe seleccionar proceso.");
            document.frm_datos_contrato.ddlProceso.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlFinanciamiento.value == "(SELECCIONAR)") {
            alert("Debe seleccionar financiamiento.");
            document.frm_datos_contrato.ddlFinanciamiento.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtObjetoContrato.value == "") {
            alert("Debe ingresar objeto.");
            document.frm_datos_contrato.txtObjetoContrato.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtEstatus.value == "") {
            alert("Debe ingresar estatus.");
            document.frm_datos_contrato.txtEstatus.focus();
            return false;
        }

        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;

    }

    function func_valida_obtener_codigo_SAFI() {

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

        if (document.frm_datos_contrato.ddlCorrConvenio.value == "(SELECCIONAR)") {
            alert("Debe seleccionar correlativo convenio.");
            document.frm_datos_contrato.ddlCorrConvenio.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlMandante.value == "(SELECCIONAR)" || document.frm_datos_contrato.ddlMandante.value == "")        
        {
            alert("Debe seleccionar mandante.");
            document.frm_datos_contrato.ddlMandante.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlEtapa.value == "(SELECCIONAR)") {
            alert("Debe seleccionar etapa.");
            document.frm_datos_contrato.ddlEtapa.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlProceso.value == "(SELECCIONAR)") {
            alert("Debe seleccionar proceso.");
            document.frm_datos_contrato.ddlProceso.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlFinanciamiento.value == "(SELECCIONAR)") {
            alert("Debe seleccionar financiamiento.");
            document.frm_datos_contrato.ddlFinanciamiento.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtObjetoContrato.value == "") {
            alert("Debe ingresar objeto.");
            document.frm_datos_contrato.txtObjetoContrato.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtEstatus.value == "") {
            alert("Debe ingresar estatus.");
            document.frm_datos_contrato.txtEstatus.focus();
            return false;
        }

        if (confirm("¿Seguro que desea obtener el codigo SAFI para este contrato?"))
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
                Creación Nuevo Contrato <div class="content_small">(Contrato)</div></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 643px">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Grabar Contrato" onclick="cmdGrabar_Click" OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla Contrato" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="borde_celda" colspan="2">
                            Datos del Proyecto</td>
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
                        &nbsp;Tipo
                            <asp:TextBox ID="txtTipoProyecto" runat="server" CssClass="content" ReadOnly="True" 
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
                            <table style=" width: 100% ">
                                <tr>
                                    <td class="borde_celda" colspan="2">
                                        Convenio Asociado</td>
                                    <td class="borde_celda" colspan="2">
                                        Datos Contrato</td>
                                </tr>
                                <tr>
                                    <td style="width: 20%;" class="content">
                                        Corrativo Convenio&nbsp;</td>
                                    <td style="width: 25%;" class="content">
                                        <asp:DropDownList ID="ddlCorrConvenio" runat="server" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20%;" class="content">
                                        &nbsp;</td>
                                    <td style="width: 35%;" class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Mandante</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlMandante" runat="server" CssClass="content"
                                        Height="20px" Width="180px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        Proceso</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlProceso" runat="server" CssClass="content" 
                                            Height="20px" Width="295px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Etapa</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlEtapa" runat="server" CssClass="content" 
                                            AutoPostBack="True" onselectedindexchanged="ddlEtapa_SelectedIndexChanged"
                                            Height="20px" Width="180px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        Financiamiento</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlFinanciamiento" runat="server" CssClass="content" 
                                            Height="20px" Width="295px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content" valign="top">
                                        &nbsp;</td>
                                    <td valign="top">
                                        <br />
                                        <asp:HiddenField ID="txtCodigoSAFI" runat="server" />
                                    </td>
                                    <td class="content" valign="top">
                                        Objeto</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtObjetoContrato" runat="server" CssClass="content" 
                                            MaxLength="300" Width="295px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        Situación</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtEstatus" runat="server" CssClass="content" MaxLength="100" 
                                            ReadOnly="True" Width="270px">Propuesta sin programación</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                            </table>
            </td>
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
