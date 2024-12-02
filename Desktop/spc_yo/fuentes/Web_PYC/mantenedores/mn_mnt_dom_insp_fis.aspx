<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_dom_insp_fis.aspx.cs" Inherits="mn_mnt_dom_insp_fis" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function valida_eliminar_dom_insp_fis() 
    {
        if (confirm("¿Seguro que desea eliminar al Inspector seleccionado?"))
            return true;
        else
            return false;
    }

    function valida_formulario() {

        if (document.frm_mnt_dom_insp_fis.txtRut.value == "") 
        {
            alert("Debe ingresar el Rut de Inspector.");
            document.frm_mnt_dom_insp_fis.txtRut.focus();
            return false;
        }

        if (document.frm_mnt_dom_insp_fis.txtNombre.value == "") 
        {
            alert("Debe ingresar el Nombre de Inspector.");
            document.frm_mnt_dom_insp_fis.txtNombre.focus();
            return false;
        }
        
        if (document.frm_mnt_dom_insp_fis.txtProfesion.value == "") 
        {
            alert("Debe ingresar el nombre de la Region.");
            document.frm_mnt_dom_insp_fis.txtProfesion.focus();
            return false;
        }
        
        if (document.frm_mnt_dom_insp_fis.txtSexo.value == "") 
        {
            alert("Debe ingresar el Sexo del Inspector.");
            document.frm_mnt_dom_insp_fis.txtSexo.focus();
            return false;
        }

        if (confirm("¿Seguro que desea crear-modificar al Inspector?"))
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
            width: 274px;
        }
        .style2
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            height: 21px;
            width: 274px;
        }
        .style3
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            height: 15px;
            width: 274px;
        }
    </style>

    
</head>
<body>

<form id="frm_mnt_dom_insp_fis" runat="server">

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
        return ((tecla > 47 && tecla < 58) || tecla == 46)
    }
     //-->
  </script>



    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Mantención de Inspectores Fiscales</td>
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
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="return valida_eliminar_dom_insp_fis();"/>
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
                        <td class="style2">
                            Rut Inspector</td>
                        <td class="content">
                            <asp:TextBox ID="txtRut" runat="server" CssClass="content" MaxLength="50" 
                                Width="150px" ontextchanged="txtRut_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3">
                            Nombre</td>
                        <td class="content" style="HEIGHT: 15px">
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="content" 
                                MaxLength="200" Width="275px" onkeypress="return isNumberKey(event)" 
                                ontextchanged="txtNombre_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Profesion</td>
                        <td class="content">
                            <asp:TextBox ID="txtProfesion" runat="server" CssClass="content" 
                                MaxLength="50" Width="183px" onkeypress="return isNumberKey(event)" 
                                ontextchanged="txtProfesion_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            Sexo</td>
                        <td class="content">
                            <asp:TextBox ID="txtSexo" runat="server" CssClass="content" 
                                MaxLength="50" Width="150px" 
                                ontextchanged="txtSexo_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                        </td>
                        <td class="content">
                        </td>
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
                Listado de Inspectores Fiscales</td>
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
                <asp:GridView ID="grdInspectores" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" Width="100%" 
                                onselectedindexchanged="grdInspectores_SelectedIndexChanged"  

                    >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                        <asp:BoundField DataField="rut" HeaderText="Rut" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="35%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="profesion" HeaderText="Profesion" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="30%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sexo" HeaderText="Sexo" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="7%" />
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
