<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_comunas.aspx.cs" Inherits="mn_mnt_comunas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function valida_eliminar_comunas() 
    {
       if (confirm("¿Seguro que desea eliminar la Comuna?"))
            return true;
        else
            return false; 
    }

    function valida_formulario() {

        if (document.frm_mnt_comunas.txtNombre.value == "") 
        {
            alert("Debe ingresar el nombre de la Comuna.");
            document.frm_mnt_comunas.txtNombre.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtRegion.value == "") {
        
            alert("Debe ingresar el nombre de la Region.");
            document.frm_mnt_comunas.txtRegion.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtProvincia.value == "") {

            alert("Debe ingresar el nombre de la Provincia.");
            document.frm_mnt_comunas.txtProvincia.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtNumComuna.value == "") {

            alert("Debe ingresar el nombre de la Numero de Comuna.");
            document.frm_mnt_comunas.txtNumComuna.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtCodigoComuna.value == "") {
            alert("Debe ingresar el nombre de la Comuna.");
            document.frm_mnt_comunas.txtCodigoComuna.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtPoblacion.value == "") 
        {
            alert("Debe ingresar el nombre de la Comuna.");
            document.frm_mnt_comunas.txtPoblacion.focus();
            return false;
        }
        
        if (confirm("¿Seguro que desea crear-modificar Comuna?"))
            return true;
        else
            return false;

        return true;
    }
    //-->

</script>    
     
</head>
<body>

<form id="frm_mnt_comunas" runat="server">

<div class="head_principal">

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
   
</div>

<div class="main_principal">
    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Mantención de Comunas</td>
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
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="return valida_eliminar_comunas();"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" />
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
                            Codigo de Comuna</td>
                        <td class="content">
                            <asp:TextBox ID="txtCodigoComuna" runat="server" CssClass="content" 
                                MaxLength="150" Width="150px" ontextchanged="txtCodigoComuna_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Region</td>
                        <td class="content">
                            <asp:TextBox ID="txtRegion" runat="server" CssClass="content" 
                                MaxLength="150" Width="150px" ontextchanged="txtRegion_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Provincia</td>
                        <td class="content">
                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="content" 
                                MaxLength="150" Width="150px" ontextchanged="txtProvincia_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Nombre Comuna</td>
                        <td class="content">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="content" 
                                MaxLength="150" Width="150px" onkeypress="return isNumberKey(event)" ontextchanged="txtNombre_TextChanged"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td class="content">
                            N° Comuna </td>
                        <td class="content">
                            <asp:TextBox ID="txtNumComuna" runat="server" CssClass="content" 
                                MaxLength="150" Width="150px" ontextchanged="txtComuna_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Poblacion</td>
                        <td class="content">
                            <asp:TextBox ID="txtPoblacion" runat="server" CssClass="content" 
                                MaxLength="150" Width="150px" ontextchanged="txtPoblacion_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
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
                Listado de Comunas</td>
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
                <asp:GridView ID="grdComunas" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" Width="100%" 
                                onselectedindexchanged="grdComunas_SelectedIndexChanged">                                
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                        <asp:BoundField DataField="region" HeaderText="Region" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="provincia" HeaderText="Provincia" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="comuna" HeaderText="N° Comuna" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cod_comun" HeaderText="Codigo Comuna" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="n_comu" HeaderText="Nombre Comuna" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="poblacion" HeaderText="Poblacion" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="15%" />
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
