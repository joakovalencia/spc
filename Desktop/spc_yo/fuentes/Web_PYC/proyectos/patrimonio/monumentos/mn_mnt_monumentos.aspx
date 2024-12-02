<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_monumentos.aspx.cs" Inherits="mn_mnt_monumentos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" type="text/css" media="all" href="../../../js/reloj/jsDatePick_ltr.min.css" />
    <script type="text/javascript" src="../../../js/reloj/jquery.1.4.2.js"></script>
    <script type="text/javascript" src="../../../js/reloj/jsDatePick.jquery.min.1.3.js"></script>
    <script language="jscript" type="text/jscript" src="../../../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function func_valida_eliminar() {
    
        if (document.frm_mn_mnt_monumentos.ddlProcesos.value == "(SELECCIONAR)") {
            alert("Debe seleccionar componente.");
            document.frm_mn_mnt_monumentos.ddlProcesos.focus();
            return false;
        }

        if (document.frm_mn_mnt_monumentos.ddlTipoDocumento.value == "(SELECCIONAR)") {
            alert("Debe seleccionar tipo documento.");
            document.frm_mn_mnt_monumentos.ddlTipoDocumento.focus();
            return false;
        }

        if (document.frm_mn_mnt_monumentos.txtNumero.value == "") {
            alert("Debe ingresa numerod documento.");
            document.frm_mn_mnt_monumentos.txtNumero.focus();
            return false;
        }

        if (document.frm_mn_mnt_monumentos.txtFecha.value == "") {
            alert("Debe seleccionar fecha.");
            document.frm_mn_mnt_monumentos.txtFecha.focus();
            return false;
        }        
        
        if (confirm("¿Seguro que desea eliminar monumento?"))
            return true;
        else
            return false;
    }

    function func_valida_formulario() {

        if (document.frm_mn_mnt_monumentos.ddlProcesos.value == "(SELECCIONAR)") 
        {
            alert("Debe seleccionar componente.");
            document.frm_mn_mnt_monumentos.ddlProcesos.focus();
            return false;
        }

        if (document.frm_mn_mnt_monumentos.ddlTipoDocumento.value == "(SELECCIONAR)") 
        {
            alert("Debe seleccionar tipo documento.");
            document.frm_mn_mnt_monumentos.ddlTipoDocumento.focus();
            return false;
        }

        if (document.frm_mn_mnt_monumentos.txtNumero.value == "") {
            alert("Debe ingresa numerod documento.");
            document.frm_mn_mnt_monumentos.txtNumero.focus();
            return false;
        }

        if (document.frm_mn_mnt_monumentos.txtFecha.value == "") {
            alert("Debe seleccionar fecha.");
            document.frm_mn_mnt_monumentos.txtFecha.focus();
            return false;
        }        
        
        if (confirm("¿Seguro que desea crear-modificar monumento?"))
            return true;
        else
            return false;

        return true;
    }

    window.onload = function() {
 
        Calendario_txtFecha = new JsDatePick({
            useMode: 2,
            target: "txtFecha",
            dateFormat: "%d/%m/%Y"
        });

    }
		
    //-->

</script>
</head>
<body>

<form id="frm_mn_mnt_monumentos" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">
    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Monumento Nacional</td>
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
                            Componentes</td>
                        <td class="content">
                            <asp:DropDownList ID="ddlProcesos" runat="server" Height="20px" Width="210" 
                                CssClass="content">
                                <asp:ListItem Value="1">Monumento Histórico</asp:ListItem>
                                <asp:ListItem Value="2">Zona Típica</asp:ListItem>
                                <asp:ListItem Value="3">Monumento arqueológico</asp:ListItem>
                            </asp:DropDownList>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Tipo Documento</td>
                        <td class="content" style="HEIGHT: 15px">
                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" Height="20px" 
                                Width="210" CssClass="content">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Número Documento</td>
                        <td class="content">
                            <asp:TextBox ID="txtNumero" runat="server" Height="20px" Width="117px" 
                                CssClass="content" MaxLength="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Fecha Docummento</td>
                        <td class="content">
                            <asp:TextBox ID="txtFecha" runat="server" Height="20px" Width="94px" 
                                CssClass="content" ReadOnly="True"></asp:TextBox>
                    <asp:Image ID="Image13" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                                                Listado Monumento Nacional</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;
                        <asp:GridView ID="grdMonumentosNacionales" runat="server" CellPadding="4" 
                        AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" Width="100%" AutoPostBack="True" 
                        onselectedindexchanged="grdMonumentosNacionales_SelectedIndexChanged" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" >
                        <ItemStyle Width="10%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="TIPO" HeaderText="Componente" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DESC_TIPO" HeaderText="Descripción Componente">

                        <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TIPO_DOC" HeaderText="Tipo Documento" >
                        </asp:BoundField>
                        <asp:BoundField DataField="DESC_TIPO_DOC" HeaderText="Descripción Tipo Documento">

                        <ItemStyle Width="20%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="NUM_DOC" HeaderText="N° Doc" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHA" HeaderText="Fecha" >
                        <HeaderStyle HorizontalAlign="Left" />
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
