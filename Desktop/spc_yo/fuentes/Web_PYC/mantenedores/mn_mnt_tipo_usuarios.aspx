<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_tipo_usuarios.aspx.cs" Inherits="mn_mnt_tipo_usuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function valida_eliminar_usuario() 
    {
        if (document.frm_mnt_usuario.ddlTipoUsuario.value == "(NUEVO USUARIO)") 
        {
            alert("Debe seleccionar a un grupo de usuario.");
            return false;
        }

        if (confirm("¿Seguro que desea eliminar al grupo de usuario seleccionado?"))
            return true;
        else
            return false;
    }

    function valida_formulario() {

        if (document.frm_mnt_usuario.txtTipoUsuario.value == "") 
        {
            alert("Debe ingresar el nombre del grupo de usuario.");
            document.frm_mnt_usuario.txtTipoUsuario.focus();
            return false;
        }

        if (document.frm_mnt_usuario.ddlTipoUsuario.value == "") 
        {
            alert("Debe seleccionar un grupo de usuario.");
            return false;
        }

        if (confirm("¿Seguro que desea crear-modificar grupo usuario?"))
            return true;
        else
            return false;

        return true;
    }
    
    //-->

</script>    

    
</head>
<body>

<form id="frm_mnt_usuario" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Mantención de Grupos de Usuario</td>
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
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="return valida_eliminar_usuario();"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td class="content">
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Seleccione Grupo usuario</td>
                        <td class="content">
                            <asp:DropDownList ID="ddlTipoUsuario" runat="server" AutoPostBack="True" 
                                CssClass="content" Font-Size="X-Small" 
                                OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="content" style="HEIGHT: 15px">
                        </td>
                        <td class="content" style="HEIGHT: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Nombre de Grupo usuario</td>
                        <td class="content">
                            <asp:TextBox ID="txtTipoUsuario" runat="server" CssClass="content" MaxLength="50" 
                                Width="150px"></asp:TextBox>
                        &nbsp; <div class="content_small">Máximo 50 caracteres</div></td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td class="content">
                        </td>
                    </tr>
                    <tr>
                        <td>
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
