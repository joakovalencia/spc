<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_usuarios.aspx.cs" Inherits="mn_mnt_usuarios" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />


<!--
///Modificado por: Alexi Rodríguez Barrientos - MOP
///Fecha: 21-04-2014
///Descripción: Mantenedor de usuario del sistema
///Detalle: Se agrega validación de selección de región en línea N° 51 a 54
 -->


<script language="JavaScript" type="text/JavaScript">
<!--

    function valida_eliminar_usuario() 
    {
        if (document.frm_mnt_usuario.ddlUsuario.value == "(NUEVO USUARIO)") 
        {
            alert("Debe seleccionar a un usuario.");
            return false;
        }

        if (confirm("¿Seguro que desea eliminar al usuario seleccionado?"))
            return true;
        else
            return false;
    }

    function valida_formulario() {

        if (document.frm_mnt_usuario.txtUsuario.value == "") 
        {
            alert("Debe ingresar el nombre de usuario.");
            document.frm_mnt_usuario.txtUsuario.focus();
            return false;
        }

        if (document.frm_mnt_usuario.ddlTipoUsuario.value == "") 
        {
            alert("Debe seleccionar un tipo de usuario.");
            return false;
        }
        //Se agrega validación de selección de región. Modificado por Alexi Rodríguez B. el 21-04-2014
        if (document.frm_mnt_usuario.ddlRegion.value == "(SELECCIONAR)") {
            alert("Debe seleccionar una región.");
            return false;
        }

        if (document.frm_mnt_usuario.txtCorreoElectronico.value.length == 0) 
        {
            alert("Debe ingresar el correo electronico.");
            document.frm_mnt_usuario.txtCorreoElectronico.focus();
            return false;
        }

        if (document.frm_mnt_usuario.txtNombreCompleto.value.length == 0) 
        {
            alert("Debe ingresar el nombre completo del usuario.");
            document.frm_mnt_usuario.txtNombreCompleto.focus();
            return false;
        }

        var $ingreso = "";
        $ingreso = document.frm_mnt_usuario.txtCorreoElectronico.value;

        if (!$ingreso.match("@")) 
        {
            alert("El correo electrónico ingresado no es valido.");
            document.frm_mnt_usuario.txtCorreoElectronico.focus();
            return false;
        }

        if (confirm("¿Seguro que desea crear-modificar usuario?"))
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
            height: 37px;
        }
    </style>

    
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
                Mantención de Usuarios</td>
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
                        <td style="width: 50%">
                            &nbsp;</td>
                        <td class="content" style="width: 50%">
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
                            Seleccione usuario</td>
                        <td class="content">
                            <asp:DropDownList ID="ddlUsuario" runat="server" AutoPostBack="True" 
                                CssClass="content" Font-Size="X-Small" 
                                OnSelectedIndexChanged="ddlUsuario_SelectedIndexChanged" Width="80%">
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
                        <td class="style1">
                            Nombre de usuario (Cuenta Windows)</td>
                        <td class="style1">
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="content" MaxLength="50" 
                                Width="60%"></asp:TextBox>
                        &nbsp; <div class="content_small">Máximo 50 caracteres</div></td>
                    </tr>
                    <tr>
                        <td class="content">
                            Nombre de usuario (Corto)</td>
                        <td class="style1">
                            <asp:TextBox ID="txtUsuarioCorto" runat="server" CssClass="content" MaxLength="10" 
                                Width="150px"></asp:TextBox>
                        &nbsp; <div class="content_small">Máximo 10 caracteres</div></td>
                    </tr>
                    <tr>
                        <td class="content">
                            Nombre Completo</td>
                        <td class="content">
                            <asp:TextBox ID="txtNombreCompleto" runat="server" CssClass="content" 
                                MaxLength="200" Width="60%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Tipo Usuario</td>
                        <td class="content">
                            <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="content" 
                                Font-Size="X-Small" Width="60%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Correo Eléctronico</td>
                        <td class="content">
                            <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="content" 
                                MaxLength="150" Width="60%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Región</td>
                        <td class="content">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="content" 
                                Font-Size="X-Small" Width="60%">
                            </asp:DropDownList>
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
            <td style="width: 60%" class="title">
                Listado de Usuarios</td>
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
            <td colspan="2">
                <asp:GridView ID="grdUsuarios" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="90%" >
                    
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="nombre_usuario" HeaderText="Nombre Usuario" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre_completo" HeaderText="Nombre Completo" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="correo_electronico" HeaderText="E-Mail" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fecha_creacion" HeaderText="Fecha Creación" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="hora_creacion" HeaderText="Hora Creación" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre_tipo_usuario" HeaderText="Tipo Usuario" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="20%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre_usuario_corto" 
                            HeaderText="Nombre Usuario Corto">
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NOMBRE_REGION" HeaderText="Región">
                        <ItemStyle Width="10%" />
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
