<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_contratistas.aspx.cs" Inherits="mn_mnt_contratistas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function valida_eliminar_contratistas() 
    {
        if (confirm("¿Seguro que desea eliminar al usuario seleccionado?"))
            return true;
        else
            return false;
    }

    function valida_formulario() {

        if (document.frm_mnt_contratistas.txtRut.value == "") 
        {
            alert("Debe ingresar el Rut de Contratista.");
            document.frm_mnt_contratistas.txtRut.focus();
            return false;
        }

        if (document.frm_mnt_contratistas.txtNombre.value == "") 
        {
            alert("Debe ingresar el Nombre de Contratista.");
            document.frm_mnt_contratistas.txtNombre.focus();
            return false;
        }

        if (document.frm_mnt_contratistas.txtRegistro.value == "") 
        {
            alert("Debe ingresar el nombre del Registro.");
            document.frm_mnt_contratistas.txtRegistro.focus();
            return false;
        }

        if (document.frm_mnt_contratistas.txtCategoria.value == "") 
        {
            alert("Debe ingresar el nombre de la Categoria.");
            document.frm_mnt_contratistas.txtCategoria.focus();
            return false;
        }

        if (document.frm_mnt_contratistas.txtTeleFax.value == "") {
            alert("Debe ingresar el numero Telefono y/o Fax.");
            document.frm_mnt_contratistas.txtTeleFax.focus();
            return false;
        }

        if (document.frm_mnt_contratistas.txtSexo.value == "") {
            alert("Debe ingresar el Sexo.");
            document.frm_mnt_contratistas.txtSexo.focus();
            return false;
        }
        
        if (confirm("¿Seguro que desea crear-modificar Contratista?"))
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
                Mantención de Contratistas</td>
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
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="return valida_eliminar_contratistas();"/>
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
                        </td>
                        <td class="content">
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Rut Contratista</td>
                        <td class="content">
                            <asp:TextBox ID="txtRut" runat="server" CssClass="content" MaxLength="50"
                                Width="150px" ontextchanged="txtRut_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Nombre Contratista</td>
                        <td class="content" style="HEIGHT: 15px">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="content" MaxLength="200" Width="290px" onkeypress="return isNumberKey(event)" 
                                ontextchanged="txtNombre_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Registro</td>
                        <td class="content">
                            <asp:TextBox ID="txtRegistro" runat="server" CssClass="content" 
                                MaxLength="50" Width="150px" onkeypress="return isNumberKey(event)" ontextchanged="txtRegistro_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Categoria</td>
                        <td class="content">
                            <asp:TextBox ID="txtCategoria" runat="server" CssClass="content" 
                                MaxLength="50" Width="150px" 
                                ontextchanged="txtCategoria_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Telefono / Fax</td>
                        <td class="content">
                            <asp:TextBox ID="txtTeleFax" runat="server" CssClass="content" MaxLength="50" 
                                Width="150px" ontextchanged="txtTeleFax_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Sexo</td>
                        <td class="content">
                            <asp:TextBox ID="txtSexo" runat="server" CssClass="content" MaxLength="50" 
                                Width="34px" ontextchanged="txtSexo_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                        </td>
                        <td class="content">
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
            <td class="style1">
                Listado de Contratistas</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td class="style2">
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
            <td class="style2">
                <asp:GridView ID="grdContratistas" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="100%" AutoPostBack="True" 
                                onselectedindexchanged="grdContratistas_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                        <asp:BoundField DataField="rut_ctta" HeaderText="Rut Contratista" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="n_ctta" HeaderText="Nombre Contratista" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="50%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="registro" HeaderText="Registro" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="categoria" HeaderText="Categoria" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="telefono_fax" HeaderText="Telefono / Fax" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sexo" HeaderText="Sexo" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="5%" />
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
