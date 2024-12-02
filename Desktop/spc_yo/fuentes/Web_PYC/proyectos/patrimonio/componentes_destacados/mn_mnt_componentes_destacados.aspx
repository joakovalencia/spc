﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_componentes_destacados.aspx.cs" Inherits="mn_mnt_componentes_destacados" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function func_valida_eliminar() {

        if (document.frm_mn_mnt_componentes_destacados.ddlComponentes.value == "(SELECCIONAR)") {
            alert("Debe seleccionar componente.");
            document.frm_mn_mnt_componentes_destacados.ddlComponentes.focus();
            return false;
        }

        if (confirm("¿Seguro que desea eliminar componente?"))
            return true;
        else
            return false;

        return true;
    }

    function func_valida_formulario() {

        if (document.frm_mn_mnt_componentes_destacados.ddlComponentes.value == "(SELECCIONAR)") 
        {
            alert("Debe seleccionar componente.");
            document.frm_mn_mnt_componentes_destacados.ddlComponentes.focus();
            return false;
        }
        
        if (confirm("¿Seguro que desea crear-modificar componente?"))
            return true;
        else
            return false;

        return true;
    }
    
    //-->

</script>
    <style type="text/css">
        .style1
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            height: 21px;
            width: 200px;
        }
    </style>
</head>
<body>

<form id="frm_mn_mnt_componentes_destacados" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Componentes Destacados</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                <table style="WIDTH: 643px">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdLimpiar" runat="server" 
                                ImageUrl="~/img/plantilla/clean.png" onclick="cmdLimpiar_Click" />
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" onclick="cmdGrabar_Click" OnClientClick="return func_valida_formulario();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="return func_valida_eliminar();"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style1">
                        </td>
                        <td class="content">
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                                                        Componente</td>
                        <td class="content">
                            <asp:DropDownList ID="ddlComponentes" runat="server" Height="20px" 
                                Width="210" CssClass="content">
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td class="content" style="HEIGHT: 15px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style1">
                        </td>
                        <td class="content">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
                    </tr>
                    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Listado Componentes Destacados</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                <asp:GridView ID="grdPatrimonioDestacado" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" Width="100%" AutoPostBack="True" 
                                onselectedindexchanged="grdPatrimonioDestacado_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" >
                        <ItemStyle Width="20%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="COMPONENTE" HeaderText="Componente" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOMBRE_COMPONENTE" 
                            HeaderText="Descripción Componente">
                        <ItemStyle Width="50%" />
                        </asp:BoundField>
                        </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#0095d9" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#666666" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
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
