<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_imp_presup_contrato.aspx.cs" Inherits="mn_ing_imp_presup_contrato" %>

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

        Calendario_txtFecha = new JsDatePick({
            useMode: 2,
            target: "txtFecha",
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

        if (document.frm_datos_contrato.txtSufijo.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }
        /*
        if (document.frm_datos_contrato.txtAno.value == "") {
            alert("Debe ingresar año.");
            document.frm_datos_contrato.txtAno.focus();
            return false;
        }*/

//        if (document.frm_datos_contrato.ddlMandante.value == "(SELECCIONAR)") {
//            alert("Debe seleccionar mandante.");
//            document.frm_datos_contrato.ddlMandante.focus();
//            return false;
//        }

        if (document.frm_datos_contrato.ddlTipoFondo.value == "(SELECCIONAR)") {
            alert("Debe seleccionar fondo.");
            document.frm_datos_contrato.ddlTipoFondo.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlResOrig.value == "(SELECCIONAR)") {
            alert("Debe seleccionar resolución origen.");
            document.frm_datos_contrato.ddlResOrig.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtNumero.value == "") {
            alert("Debe ingresar numero resolución.");
            document.frm_datos_contrato.txtNumero.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFecha.value == "") {
            alert("Debe ingresar fecha resolución.");
            document.frm_datos_contrato.txtFecha.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtSUBT.value == "") {
            alert("Debe ingresar SUBT.");
            document.frm_datos_contrato.txtSUBT.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtIT.value == "") {
            alert("Debe ingresar IT.");
            document.frm_datos_contrato.txtIT.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtASIG.value == "") {
            alert("Debe ingresar ASIG.");
            document.frm_datos_contrato.txtASIG.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtMontoImputado.value == "") {
            alert("Debe ingresar monto imputado.");
            document.frm_datos_contrato.txtMontoImputado.focus();
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

        if (document.frm_datos_contrato.txtSufijo.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }
        /*
        if (document.frm_datos_contrato.txtAno.value == "") {
            alert("Debe ingresar año.");
            document.frm_datos_contrato.txtAno.focus();
            return false;
        }*/

        if (document.frm_datos_contrato.ddlMandante.value == "(SELECCIONAR)" || document.frm_datos_contrato.ddlMandante.value == "")        
        {
            alert("Debe seleccionar mandante.");
            document.frm_datos_contrato.ddlMandante.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlTipoFondo.value == "(SELECCIONAR)") {
            alert("Debe seleccionar fondo.");
            document.frm_datos_contrato.ddlTipoFondo.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlResOrig.value == "(SELECCIONAR)") {
            alert("Debe seleccionar resolución origen.");
            document.frm_datos_contrato.ddlResOrig.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtNumero.value == "") {
            alert("Debe ingresar numero resolución.");
            document.frm_datos_contrato.txtNumero.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFecha.value == "") {
            alert("Debe ingresar fecha resolución.");
            document.frm_datos_contrato.txtFecha.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtSUBT.value == "") {
            alert("Debe ingresar SUBT.");
            document.frm_datos_contrato.txtSUBT.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtIT.value == "") {
            alert("Debe ingresar IT.");
            document.frm_datos_contrato.txtIT.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtASIG.value == "") {
            alert("Debe ingresar ASIG.");
            document.frm_datos_contrato.txtASIG.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtMontoImputado.value == "") {
            alert("Debe ingresar monto imputado.");
            document.frm_datos_contrato.txtMontoImputado.focus();
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
                Modificación Imputación Presupuestaria del Contrato <div class="content_small">(Contrato-Imputación)</div></td>
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
                                ToolTip="Modifica Imputación Presupuestaria del Contrato" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Modifica Imputación Presupuestaria del Contrato" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla imput" Visible="False"></asp:Label>
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
                        &nbsp;Código Contrato
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
                                        Edición Imputación Presupuestaria</td>
                                </tr>
                                <tr>
                                    <td>
                                        Año</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAno" runat="server" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Fecha Resolución</td>
                                    <td>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mandante</td>
                                    <td>
                                        <asp:DropDownList ID="ddlMandante" runat="server" CssClass="content" 
                                            Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        SUBT</td>
                                    <td>
                            <asp:TextBox ID="txtSUBT" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Fondo</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoFondo" runat="server" CssClass="content" 
                                            Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        IT</td>
                                    <td>
                            <asp:TextBox ID="txtIT" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Resolución Origen</td>
                                    <td>
                                        <asp:DropDownList ID="ddlResOrig" runat="server" CssClass="content" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        ASIG</td>
                                    <td>
                            <asp:TextBox ID="txtASIG" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="3"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        N° Resolución</td>
                                    <td>
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Monto Imputado</td>
                                    <td>
                            <asp:TextBox ID="txtMontoImputado" runat="server" CssClass="content" 
                                Width="160px" Height="18px" MaxLength="15"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        <asp:HiddenField ID="txtLlave" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        Imputaciones Presupuestarias relacionados al contrato</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                <asp:GridView ID="grdImputacion" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="95%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="8%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="AGNO" HeaderText="Año" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MANDANTE" HeaderText="Mandante" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="T_F1" HeaderText="Tipo Fondo" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OR_RES" HeaderText="Resoluc. Origen" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="N_RES" HeaderText="N° Res" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="F_RES" HeaderText="Fecha Res" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="SUBT" DataField="SUBT" HtmlEncode="False" >
                        <HeaderStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="IT" DataField="IT" HtmlEncode="False" >
                        <HeaderStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ASIG" DataField="ASIG" HtmlEncode="False" >
                        <HeaderStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Monto Imputado" DataField="MONTO2" >
                        <HeaderStyle Width="15%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="llave" HeaderText="llave" HtmlEncode="False">
                        <HeaderStyle HorizontalAlign="Right" Width="15%" CssClass="cell_hidde" />
                        <ItemStyle HorizontalAlign="Right" CssClass="cell_hidde" />
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
