﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="menu_principal.aspx.cs" Inherits="menu_principal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">    

</script>    

    
    
</head>
<body>

    <form id="form1" runat="server">

<div class="head_principal">
       

</div>
<style>
    img
    {
        border-radius: 30px;
    }
</style>

<div class="main_principal" align="center">
    <br />
	<div class="title">Mantenedores</div>
	<br />
	<div class="title">                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" />
                        </div>
    <br />
	<asp:Label ID="lblTabla" runat="server"></asp:Label>
    <br />
    <br />
</div>

<div class="footer"  >
    <strong>USUARIO: </strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label ID="lblCorreo" runat="server" CssClass="content"></asp:Label>
    <strong> GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
</div>

</form>

</body>
</html>
