<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_proyectos.aspx.cs" Inherits="mn_ing_proyectos" %>

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

        

        if (document.frm_ing_proyecto.ddlRegion.value == "(SELECCIONAR)") {
            alert("Debe seleccionar una Región.");
            document.frm_ing_proyecto.ddlRegion.focus();
            return false;
        }

        if (document.frm_ing_proyecto.ddlTipologia.value == "(SELECCIONAR)") {
            alert("Debe seleccionar una Tipologia.");
            document.frm_ing_proyecto.ddlTipologia.focus();
            return false;
        }

        if (document.frm_ing_proyecto.ddlPlanAsociado.value == "(SELECCIONAR)") {
            alert("Debe seleccionar un Plan Asociado.");
            document.frm_ing_proyecto.ddlPlanAsociado.focus();
            return false;
        }

        if (document.frm_ing_proyecto.ddlProductoEstrategico.value == "(SELECCIONAR)") {
            alert("Debe seleccionar un Producto Estrategico.");
            document.frm_ing_proyecto.ddlProductoEstrategico.focus();
            return false;
        }

        if (document.frm_ing_proyecto.ddlProceso.value == "(SELECCIONAR)") {
            alert("Debe seleccionar un Proceso.");
            document.frm_ing_proyecto.ddlProceso.focus();
            return false;
        }

        if (document.frm_ing_proyecto.txtObjeto.value == "") {
            alert("Debe ingresar objeto.");
            document.frm_ing_proyecto.txtObjeto.focus();
            return false;
        }

        if (document.frm_ing_proyecto.ddlFinanciamiento.value == "(SELECCIONAR)") {
            alert("Debe seleccionar Financiamiento.");
            document.frm_ing_proyecto.ddlFinanciamiento.focus();
            return false;
        }

        if (document.frm_ing_proyecto.ddlFinanciamiento.value == "(SELECCIONAR)") {
            alert("Debe seleccionar Financiamiento.");
            document.frm_ing_proyecto.ddlFinanciamiento.focus();
            return false;
        }

        if (document.frm_ing_proyecto.ddlSectorDestino.value == "(SELECCIONAR)") {
            alert("Debe seleccionar Sector Destino.");
            document.frm_ing_proyecto.ddlSectorDestino.focus();
            return false;
        }       


        if (confirm("¿Seguro que desea crear el proyecto?"))
            return true;
        else
            return false;
    
    }
    
    //-->

</script>    
    
</head>
<body>

<form id="frm_ing_proyecto" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td class="title">
                Creación de Nuevo Proyecto, Programa, Estudio <div class="content_small">(Proyecto)</div></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 643px">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdLimpiar" runat="server" 
                                ImageUrl="~/img/plantilla/clean.png" onclick="cmdLimpiar_Click" 
                                ToolTip="Limpiar" />
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Grabar Proyecto" onclick="cmdGrabar_Click" OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                        </td>
                        <td>
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla Proyecto" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td style="width: 933px;">
                <table width="95%" class="content">
                    <tr>
                        <td>
                            Región</td>
                        <td>
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="content" 
                                Width="400px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tipo Proyecto</td>
                        <td>
                            <asp:DropDownList ID="ddlTipologia" Width="200px" runat="server" 
                                CssClass="content" AutoPostBack="True" 
                                onselectedindexchanged="ddlTipologia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Plan asociado</td>
                        <td>
                            <asp:DropDownList ID="ddlPlanAsociado" runat="server" CssClass="content" 
                                Width="400px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Producto Estratégico</td>
                        <td>
                            <asp:DropDownList ID="ddlProductoEstrategico" Width="250px" runat="server" 
                                CssClass="content">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Proceso</td>
                        <td>
                            <asp:DropDownList ID="ddlProceso" Width="200px" runat="server" 
                                CssClass="content">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Objeto</td>
                        <td>
                            <asp:TextBox ID="txtObjeto" runat="server" Width="400px" CssClass="content" 
                                MaxLength="300"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Financiamiento</td>
                        <td>
                            <asp:DropDownList ID="ddlFinanciamiento" Width="400px" runat="server" 
                                CssClass="content">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Sector Destino</td>
                        <td>
                            <asp:DropDownList ID="ddlSectorDestino" Width="400px" runat="server" 
                                CssClass="content">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td>
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
