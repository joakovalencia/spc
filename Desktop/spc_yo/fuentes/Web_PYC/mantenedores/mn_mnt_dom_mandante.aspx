﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_dom_mandante.aspx.cs" Inherits="mn_mnt_dom_mandante" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function valida_eliminar_dom_mandante() 
    {
        if (confirm("¿Seguro que desea eliminar la Mandante?"))
            return true;
        else
            return false;
    }

    function valida_formulario() {

        if (document.frm_mnt_dom_mandante.txtSigla.value == "") 
        {
            alert("Debe ingresar Sigla de Mandante.");
            document.frm_mnt_dom_mandante.txtSigla.focus();
            return false;
        }

        if (document.frm_mnt_dom_mandante.txtDescripcion.value == "") 
        {
            alert("Debe ingresar Descripcion de Mandante.");
            document.frm_mnt_dom_mandante.txtDescripcion.focus();
            return false;
        }

        
        if (confirm("¿Seguro que desea crear-modificar Mandante?"))
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
            width: 219px;
        }
    </style>
</head>
<body>

<form id="frm_mnt_dom_mandante" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

<script type="text/javascript">
    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return ((tecla > 47 && tecla < 58) || tecla == 46);
    }
</script>

<script type="text/javascript">
     <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return true;

        return false;
    }
     //-->
  </script>



    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Mantención de Mandantes</td>
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
                                ImageUrl="~/img/plantilla/save.png" onclick="cmdGrabar_Click" OnClientClick="return valida_formulario();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="return valida_eliminar_dom_mandante();"/>
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
                            Sigla</td>
                        <td class="content">
                            <asp:TextBox ID="txtSigla" runat="server" CssClass="content" MaxLength="50" 
                                Width="150px" ontextchanged="txtSigla_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Descripcion</td>
                        <td class="content" style="HEIGHT: 15px">
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="content" 
                                Width="363px" onkeypress="return isNumberKey(event)" 
                                ontextchanged="txtDescripcion_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
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
                Listado de Mandantes</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                            <asp:ImageButton ID="cmdExportarExcel" runat="server" 
                                ImageUrl="~/img/plantilla/export.png" onclick="cmdExportarExcel_Click" 
                    />
                <asp:GridView ID="grdMandante" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" Width="100%" AutoPostBack="True" 
                                onselectedindexchanged="grdMandante_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                        <asp:BoundField DataField="sigla" HeaderText="Sigla" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="60%" />
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