<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_cargo_presup_contrato.aspx.cs" Inherits="mn_ing_cargo_presup_contrato" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />    
    <script language="jscript" type="text/jscript" src="../../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
    <!--

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

        if (document.frm_datos_contrato.txtEP.value == "") {
            alert("Debe ingresar numero estado pago.");
            document.frm_datos_contrato.txtEP.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtAno.value == "") {
            alert("Debe ingresar año.");
            document.frm_datos_contrato.txtAno.focus();
            return false;
        }

//        if (document.frm_datos_contrato.ddlMandante.value == "(SELECCIONAR)") {
//            alert("Debe seleccionar mandante.");
//            document.frm_datos_contrato.ddlMandante.focus();
//            return false;
//        }

        if (document.frm_datos_contrato.ddlFondo.value == "(SELECCIONAR)") {
            alert("Debe seleccionar fondo.");
            document.frm_datos_contrato.ddlFondo.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlSUBT.value == "(SELECCIONAR)") {
            alert("Debe ingresar SUBT.");
            document.frm_datos_contrato.ddlSUBT.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlItem.value == "(SELECCIONAR)") {
            alert("Debe ingresar ITEM.");
            document.frm_datos_contrato.ddlItem.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlAsig.value == "(SELECCIONAR)") {
            alert("Debe ingresar ASIG.");
            document.frm_datos_contrato.ddlAsig.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtMonto.value == "" || document.frm_datos_contrato.txtMonto.value == "0") {
            alert("Debe ingresar monto estado pago.");
            document.frm_datos_contrato.txtMonto.focus();
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

        if (document.frm_datos_contrato.txtEP.value == "") {
            alert("Debe ingresar numero estado pago.");
            document.frm_datos_contrato.txtEP.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtAno.value == "") {
            alert("Debe ingresar año.");
            document.frm_datos_contrato.txtAno.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlMandante.value == "(SELECCIONAR)" || document.frm_datos_contrato.ddlMandante.value == "")        
         {
            alert("Debe seleccionar mandante.");
            document.frm_datos_contrato.ddlMandante.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlFondo.value == "(SELECCIONAR)") {
            alert("Debe seleccionar fondo.");
            document.frm_datos_contrato.ddlFondo.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlSUBT.value == "(SELECCIONAR)") {
            alert("Debe ingresar SUBT.");
            document.frm_datos_contrato.ddlSUBT.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlItem.value == "(SELECCIONAR)") {
            alert("Debe ingresar ITEM.");
            document.frm_datos_contrato.ddlItem.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlAsig.value == "(SELECCIONAR)") {
            alert("Debe ingresar ASIG.");
            document.frm_datos_contrato.ddlAsig.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtMonto.value == "" || document.frm_datos_contrato.txtMonto.value == "0") {
            alert("Debe ingresar monto estado pago.");
            document.frm_datos_contrato.txtMonto.focus();
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
                Estado de Pago del Contrato - Cargo a Presupuesto <div class="content_small">(Contrato-Estado Pago)</div></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 95%">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdLimpiar" runat="server" 
                                ImageUrl="~/img/plantilla/clean.png" onclick="cmdLimpiar_Click" 
                                ToolTip="Limpiar" />
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Graba Estado Pago" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Elimina Estado Pago" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla CARGO_PRESUP" 
                                Visible="False"></asp:Label>
                        &nbsp;</td>
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
                                    <td style="width: 25%">
                                        &nbsp;</td>
                                    <td style="width: 25%">
                                        &nbsp;</td>
                                    <td style="width: 25%">
                                        &nbsp;</td>
                                    <td style="width: 25%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Cargo Presupuesto</td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        E.P</td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtEP" runat="server" ReadOnly="True" Width="55px" 
                                            CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        Año</td>
                                    <td valign="top">
                                        <asp:TextBox ID="txtAno" runat="server" ReadOnly="True" Width="61px" 
                                            CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mandante</td>
                                    <td>
                                        <asp:DropDownList ID="ddlMandante" runat="server" CssClass="content" 
                                            Height="20px" Width="166px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Fondo</td>
                                    <td>
                                        <asp:DropDownList ID="ddlFondo" runat="server" CssClass="content" Height="20px" 
                                            Width="166px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mes</td>
                                    <td>
                                        <asp:TextBox ID="txtMes" runat="server" ReadOnly="True" Width="55px" 
                                            CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        SUBT</td>
                                    <td>
                                        <asp:DropDownList ID="ddlSUBT" runat="server" CssClass="content" Height="20px" 
                                            Width="166px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Item</td>
                                    <td>
                                        <asp:DropDownList ID="ddlItem" runat="server" CssClass="content" Height="20px" 
                                            Width="166px" >
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Asig</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAsig" runat="server" CssClass="content" Height="20px" 
                                            Width="166px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Monto</td>
                                    <td>
                                        <asp:TextBox ID="txtMonto" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="txtFechaEstadoPago" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
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
                                        Registros del Estado Pago</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                    <asp:GridView ID="grdUno" runat="server" CellPadding="4"  
                                        AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                                        Width="98%" onselectedindexchanged="grdUno_SelectedIndexChanged"  >
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                                            <HeaderStyle Width="10%" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="NUM_EPAGO" HeaderText="E.P" >
                                            <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AGNO" HeaderText="Año" >
                                            <HeaderStyle HorizontalAlign="Right" Width="5%" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MANDANTE" HeaderText="Mandante" >
                                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fondo" DataField="T_F1" >
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Mes" DataField="MES_CARGO" >
                                            <HeaderStyle Width="5%" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="SUBT" DataField="SUBT" >
                                            <HeaderStyle Width="10%" HorizontalAlign="Right" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Item" DataField="ITEM">
                                            <HeaderStyle HorizontalAlign="Right" Width="10%" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Asig" DataField="ASIG">
                                            <HeaderStyle HorizontalAlign="Right" Width="10%" />
                                            <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Monto" DataField="MONTO2" >
                                            <HeaderStyle HorizontalAlign="Right" Width="10%" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                        <HeaderStyle BackColor="#0095d9" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#666666" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                
                                        <br />
                                    </td>
                                </tr>
                                </table>
                            <br />
                        </td>
        </tr>
        </table>
</div>

<div class="footer" >
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label ID="lblCorreo" runat="server" CssClass="content"></asp:Label><strong>GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
</div>

</form>

</body>
</html>
