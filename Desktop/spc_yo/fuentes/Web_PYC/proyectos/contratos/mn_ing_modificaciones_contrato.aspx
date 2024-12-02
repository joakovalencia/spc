<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_modificaciones_contrato.aspx.cs" Inherits="mn_ing_modificaciones_contrato" %>

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

        Calendario_txtSMMFecha = new JsDatePick({
            useMode: 2,
            target: "txtSMMFecha",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtResMFechaTram = new JsDatePick({
            useMode: 2,
            target: "txtResMFechaTram",
            dateFormat: "%d/%m/%Y"
        });
        
        Calendario_txtResMFecha = new JsDatePick({
            useMode: 2,
            target: "txtResMFecha",
            dateFormat: "%d/%m/%Y"
        });

        

        Calendario_txtRMFecha = new JsDatePick({
            useMode: 2,
            target: "txtRMFecha",
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
            alert("Debe ingresar sufijo.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
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
            alert("Debe ingresar sufijo.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
            return false;
        }
                
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;
    
    }
    
    //-->

</script>    

    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            text-align: center;
            font-weight: bold;
        }
    </style>

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
                Modificación de Contrato <div class="content_small">(Contrato-Modificación Contrato)</div></td>
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
                                ToolTip="Modifica Contrato" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Elimina Modifcación Contrato" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla MODIF" Visible="False"></asp:Label>
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
                                    <td class="borde_celda" colspan="4">
                                        Datos Modificación Contrato</td>
                                </tr>
                                <tr>
                                    <td style="width: 20%">
                                        F.Incio Legal</td>
                                    <td style="width: 30%">
                            <asp:TextBox ID="txtFechaInicioLegal" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td style="width: 20%">
                                        F.Térm.Legal Vigente</td>
                                    <td style="width: 30%">
                            <asp:TextBox ID="txtFechaTerminoLegal" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%">
                                        Monto Vigente</td>
                                    <td style="width: 30%">
                            <asp:TextBox ID="txtMontoVigente" runat="server" CssClass="content" 
                                Width="50%" Height="18px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td style="width: 20%">
                                        Plazo Vigente</td>
                                    <td style="width: 30%">
                            <asp:TextBox ID="txtPlazoVigente" runat="server" CssClass="content" 
                                Width="50px" Height="18px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
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
                                        Edición / Modificación Contrato</td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Modificación</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoMod" runat="server" CssClass="content" Width="70%">
                                            <asp:ListItem Value="0">(SELECCIONAR)</asp:ListItem>
                                            <asp:ListItem Value="1">1 - Aumento o disminución de contrato</asp:ListItem>
                                            <asp:ListItem Value="2">2 - Reajuste</asp:ListItem>
                                            <asp:ListItem Value="3">3 - Ampliación de plazo</asp:ListItem>
                                            <asp:ListItem Value="4">4 - Otros</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="style2" colspan="2">
                                        Resolución de Modificación</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Origen</td>
                                    <td>
                                        <asp:DropDownList ID="ddlResMOrigen" runat="server" CssClass="content" 
                                            Width="60%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1" colspan="2">
                                        <b>Solicitud Modificación al Mandante</b></td>
                                    <td>
                                        Nº</td>
                                    <td>
                            <asp:TextBox ID="txtResMNumdoc" runat="server" CssClass="content" 
                                Width="50px" Height="18px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nº Documento</td>
                                    <td>
                            <asp:TextBox ID="txtSMMNumDocto" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtResMFecha" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtSMMFecha" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Monto</td>
                                    <td>
                            <asp:TextBox ID="txtSMMMonto" runat="server" CssClass="content" 
                                Width="50%" Height="18px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha Tramite</td>
                                    <td>
                            <asp:TextBox ID="txtResMFechaTram" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Plazo</td>
                                    <td>
                            <asp:TextBox ID="txtSMMPlazo" runat="server" CssClass="content" 
                                Width="50px" Height="18px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Motivo</td>
                                    <td>
                                        <asp:DropDownList ID="ddlResMTipo" runat="server" CssClass="content" 
                                            Width="90%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        M2</td>
                                    <td valign="top">
                            <asp:TextBox ID="txtSMM_M2" runat="server" CssClass="content" 
                                Width="50px" Height="18px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Renovo Boleta?</td>
                                    <td valign="top">
                                        <asp:DropDownList ID="ddlResMRenovo" runat="server" CssClass="content" 
                                            Width="60%">
                                            <asp:ListItem Value="0">(SELECCIONAR)</asp:ListItem>
                                            <asp:ListItem Value="Si">Si</asp:ListItem>
                                            <asp:ListItem Value="No">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;</td>
                                    <td valign="top">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td valign="top">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style1" colspan="2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style1" colspan="2">
                                        <b>Respuesta del Mandante</b></td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Nº Documento</td>
                                    <td>
                            <asp:TextBox ID="txtRMNumDoc" runat="server" CssClass="content" 
                                Width="50px" Height="18px" ></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="txtLlave" runat="server" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha</td>
                                    <td><div>
                            <asp:TextBox ID="txtRMFecha" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox></div>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />                    
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                </table>
                        </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td>
                                                </td>
        </tr>
        <tr>
            <td>
                <table class="content" style="width:100%">
                    <tr>
                        <td width="5%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                        <td width="6%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            &nbsp;</td>
                        <td rowspan="2" class = "borde_celda_small" >
                            Tipo Modif.</td>
                        <td colspan="5" class = "borde_celda_small" >
                            Solicitud Modificación a Mandante</td>
                        <td colspan="2" class = "borde_celda_small" >
                            Respuesta al Mandante</td>
                        <td colspan="3" class = "borde_celda_small" >
                            Resolución Modificación</td>
                        <td class = "borde_celda_small" >
                            Fecha</td>
                        <td rowspan="2" class = "borde_celda_small" >
                            Motivo</td>
                        <td rowspan="2" class = "borde_celda_small" >
                            Renovo Boleta?</td>
                    </tr>
                    <tr>
                        <td class = "borde_celda_small" >
                            Nº Docto.</td>
                        <td class = "borde_celda_small" >
                            Fecha</td>
                        <td class = "borde_celda_small" >
                            Monto</td>
                        <td class = "borde_celda_small" >
                            Plazo</td>
                        <td class = "borde_celda_small" >
                            M2</td>
                        <td class = "borde_celda_small" >
                            Nº Docto</td>
                        <td class = "borde_celda_small" >
                            Fecha</td>
                        <td class = "borde_celda_small" >
                            Origen</td>
                        <td class = "borde_celda_small" >
                            Nº</td>
                        <td class = "borde_celda_small" >
                            Fecha</td>
                        <td class = "borde_celda_small" >
                            Tramite</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdEdicion" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="100%" onselectedindexchanged="grdInspector_SelectedIndexChanged" 
                    EmptyDataText="No hay registros" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="6%" />
                        </asp:CommandField>
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
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                                        </td>
        </tr>
    </table>
    <br />
    <br />
</div>

<div class="footer" >
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label ID="lblCorreo" runat="server" CssClass="content"></asp:Label><strong>GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
</div>

</form>

</body>
</html>
