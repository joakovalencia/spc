<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="menu_principal_pyc.aspx.cs" Inherits="menu_principal_pyc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">    

</script>    
    
    <style type="text/css">
        
    
        
                
        .style1
        {
            width: 100%;
        }
        
    
        
                
        .style2
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            font-size: 28px;
            text-align: center;
        }
        
    
        
                
    </style>
        
</head>
<body>

    <form id="form1" runat="server">

<div class="head_principal">
      

</div>

    <div class="style1">
        <br />
        <table class="style1">
            <tr>
                <td>
                    <div class="style2">Menu Principal</div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center">
                    <asp:ImageMap ID="ImageMap1" runat="server" 
                        ImageUrl="~/img/plantilla/menu_pri_img.png" onclick="ImageMap1_Click">
                        <asp:RectangleHotSpot AlternateText="Ingreso Proyectos" Bottom="166" Left="12" 
                            NavigateUrl="~/proyectos/mn_busqueda_proyectos.aspx" Right="112" 
                            Top="70" />
                        <asp:RectangleHotSpot AlternateText="Salir" Bottom="292" Left="649" 
                            NavigateUrl="~/cerrar_sesion.aspx" Right="750" Top="183" />
                        <asp:RectangleHotSpot AlternateText="Mantenedores" Bottom="110" Left="365" 
                            NavigateUrl="~/menu_principal.aspx" Right="495" Top="8" />
                        <asp:RectangleHotSpot AlternateText="Listados" Bottom="280" Left="298" 
                            NavigateUrl="~/listados/mn_principal_listado.aspx" Right="398" Top="177" />
                    </asp:ImageMap>
                </td>
            </tr>
        </table>
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
