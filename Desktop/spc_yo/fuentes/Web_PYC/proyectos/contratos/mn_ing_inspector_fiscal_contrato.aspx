<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_inspector_fiscal_contrato.aspx.cs" Inherits="mn_ing_inspector_fiscal_contrato" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" type="text/css" media="all" href="../../js/reloj/jsDatePick_ltr.min.css" />
    <script type="text/javascript" src="../../js/reloj/jquery.1.4.2.js"></script>
    <script type="text/javascript" src="../../js/reloj/jsDatePick.jquery.min.1.3.js"></script>
    
    <script language="jscript" type="text/jscript" src="../../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
    <!--

    window.onload = function() {

        Calendario_txtFechaRes = new JsDatePick({
            useMode: 2,
            target: "txtFechaRes",
            dateFormat: "%d/%m/%Y"
        });

    } 
    function func_valida_eliminar() {

        if (document.frm_datos_contrato.txtRegion.value == "") {
            alert("Debe ingresar región.");
            document.frm_datos_contrato.txtRegion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPIA.value == "") {
            alert("Debe ingresar PIA.");
            document.frm_datos_contrato.txtPIA.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtProceso.value == "") {
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtProceso.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlRut.value == "(SELECCIONAR)") {
            alert("Debe seleccionar inspector fiscal.");
            document.frm_datos_contrato.ddlRut.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtNombre.value == "") {
            alert("Debe seleccionar inspector fiscal.");
            document.frm_datos_contrato.txtNombre.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtProfesion.value == "(SELECCIONAR)") {
            alert("Debe seleccionar inspector fiscal.");
            document.frm_datos_contrato.txtProfesion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtNumeroRes.value == "(SELECCIONAR)") {
            alert("Debe ingresar numero de resolción.");
            document.frm_datos_contrato.txtNumeroRes.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaRes.value == "(SELECCIONAR)") {
            alert("Debe ingresar numero de resolción.");
            document.frm_datos_contrato.txtFechaRes.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlTitular.value == "(SELECCIONAR)") {
            alert("Debe seleccionar Titular S/N.");
            document.frm_datos_contrato.ddlTitular.focus();
            return false;
        }

        if (confirm("¿Seguro que desea eliminar este registro?"))
            return true;
        else
            return false;
    }
    
    function func_valida_grabar() {

        if (document.frm_datos_contrato.txtRegion.value == "") {
            alert("Debe ingresar región.");
            document.frm_datos_contrato.txtRegion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPIA.value == "") {
            alert("Debe ingresar PIA.");
            document.frm_datos_contrato.txtPIA.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtProceso.value == "") {
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtProceso.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlRut.value == "(SELECCIONAR)") {
            alert("Debe seleccionar inspector fiscal.");
            document.frm_datos_contrato.ddlRut.focus();
            return false;
        }
        
        if (document.frm_datos_contrato.txtNombre.value == "") {
            alert("Debe seleccionar inspector fiscal.");
            document.frm_datos_contrato.txtNombre.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtProfesion.value == "(SELECCIONAR)") {
            alert("Debe seleccionar inspector fiscal.");
            document.frm_datos_contrato.txtProfesion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtNumeroRes.value == "(SELECCIONAR)") {
            alert("Debe ingresar numero de resolción.");
            document.frm_datos_contrato.txtNumeroRes.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaRes.value == "(SELECCIONAR)") {
            alert("Debe ingresar fecha de resolción.");
            document.frm_datos_contrato.txtFechaRes.focus();
            return false;
        }
        
        if (document.frm_datos_contrato.ddlTitular.value == "(SELECCIONAR)") {
            alert("Debe seleccionar Titular S/N.");
            document.frm_datos_contrato.ddlTitular.focus();
            return false;
        }
           
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;
    
    }
    
    //-->

</script>    

    </head>

<body>

<form id="frm_datos_contrato" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

    <br />
	<table style="width:90%;">
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td class="title">
                Modificación Inspector Fiscal del Contrato <div class="content_small">(Contrato-Inspector Fiscal)</div></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 95%">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Crea Inspector Fiscal del Contrato" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Elimina Inspector Fiscal del Contrato" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla INSPECTOR_FISCAL_CONTRATO" 
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="borde_celda" colspan="2">
                            Datos del Contrato</td>
                    </tr>
                    <tr>
                        <td class="content">
                            Región</td>
                        <td class="content">
                            <asp:TextBox ID="txtRegion" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="18px"></asp:TextBox>
                        &nbsp;PIA
                            <asp:TextBox ID="txtPIA" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="18px"></asp:TextBox>
                        &nbsp;Proceso
                            <asp:TextBox ID="txtProceso" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                            &nbsp;Sufijo
                            <asp:TextBox ID="txtSufijo" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                        &nbsp;Códio Contrato
                            <asp:TextBox ID="txtCodCon" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Objeto</td>
                        <td class="content">
                            <asp:TextBox ID="txtObjeto" runat="server" CssClass="content" ReadOnly="True" 
                                Width="470px" Height="18px"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            <table class="content" style="width: 95%">
                                <tr>
                                    <td style="width: 20%">
                                        &nbsp;</td>
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                    <td style="width: 20%">
                                        &nbsp;</td>
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Edición Inspector Fiscal</td>
                                </tr>
                                <tr>
                                    <td>
                                        Rut</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlRut" runat="server" AutoPostBack="True" 
                                            CssClass="content" Height="20px" Width="95%" 
                                            onselectedindexchanged="ddlRut_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nombre</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="content" 
                                            Width="95%" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Profesion</td>
                                    <td>
                            <asp:TextBox ID="txtProfesion" runat="server" CssClass="content" ReadOnly="True" 
                                Width="95%" Height="18px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <b>N° Res.</b></td>
                                    <td>
                            <asp:TextBox ID="txtNumeroRes" runat="server" CssClass="content" 
                                Width="82px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Fecha Res.</b></td>
                                    <td>
                            <asp:TextBox ID="txtFechaRes" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        <b>Titular? </b>(Si/No)</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTitular" runat="server" CssClass="content" 
                                            Height="20px" Width="125px">
                                            <asp:ListItem Value="(SELECCIONAR)">(SELECCIONAR)</asp:ListItem>
                                            <asp:ListItem Value="S">Si</asp:ListItem>
                                            <asp:ListItem Value="N">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        Inspectores relacionados al contrato</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                <asp:GridView ID="grdInspector" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="90%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="10%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="rut" HeaderText="Rut" >
                        <HeaderStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="profesion" HeaderText="Profesion" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="N_RES" HeaderText="N° Resoluc." >
                        <HeaderStyle HorizontalAlign="Left" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fecha_res" HeaderText="Fecha Res." >
                        <HeaderStyle HorizontalAlign="Left" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="titularsn" HeaderText="ITO Titular" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="10%" />
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
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
