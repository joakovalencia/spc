﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_estado_convenio.aspx.cs" Inherits="mn_mnt_estado_convenio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
<!--

    
    function valida_formulario() {

        if (document.frm_mnt_contratistas.txtCodigoPIA.value == "") 
        {
            alert("Debe ingresar codigo PIA.");
            document.frm_mnt_contratistas.txtCodigoPIA.focus();
            return false;
        }

        if (document.frm_mnt_contratistas.txtMandante.value == "") 
        {
            alert("Debe ingresar mandante convenio.");
            document.frm_mnt_contratistas.txtMandante.focus();
            return false;
        }

        if (document.frm_mnt_contratistas.txtCorrelativo.value == "") {
            alert("Debe ingresar correlativo convenio.");
            document.frm_mnt_contratistas.txtCorrelativo.focus();
            return false;
        }
    
        if (confirm("¿Seguro que desea modificar Convenio?"))
            return true;
        else
            return false;

        return true;
    }
    
    //-->

</script>    

<script type="text/javascript">
    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;

        if (e.keyCode == 46) tecla = 0;

        return ((tecla > 47 && tecla < 58) || tecla == 46);
    }

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return true;

        return false;
    }
</script>
   
    <style type="text/css">
        .style1
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            font-size: 28px;
            width: 731px;
        }
        .style2
        {
            width: 731px;
        }
    </style>
   
</head>
<body>

<form id="frm_mnt_contratistas" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td class="style1">
                Modificación de estado convenio</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td class="style2">
                <table style="WIDTH: 643px">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdLimpiar" runat="server" 
                                ImageUrl="~/img/plantilla/clean.png" onclick="cmdLimpiar_Click" />
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" onclick="cmdGrabar_Click" OnClientClick="return valida_formulario();"/>
                            <asp:ImageButton ID="cmdBuscar" runat="server" 
                                ImageUrl="~/img/plantilla/find.png" onclick="cmdBuscar_Click" 
                                />
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="content" style="width:30%;">
                            &nbsp;</td>
                        <td class="content" style="width:70%;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="content">
                            Región</td>
                        <td class="content">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="content" 
                                Height="21px" Width="279px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Código PIA</td>
                        <td class="content">
                            <asp:TextBox ID="txtCodigoPIA" runat="server" CssClass="content" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Madante</td>
                        <td class="content">
                            <asp:TextBox ID="txtMandante" runat="server" CssClass="content" MaxLength="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Correlativo</td>
                        <td class="content">
                            <asp:TextBox ID="txtCorrelativo" runat="server" CssClass="content" 
                                MaxLength="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="content">
                            Estado</td>
                        <td class="content">
                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="content" 
                                Height="21px" Width="279px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td class="style2">
                            &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td class="style2">
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
