<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_detalle_termino_consultoria.aspx.cs" Inherits="mn_detalle_termino_consultoria" %>

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

        Calendario_txtFechaTermFisInfITO = new JsDatePick({
            useMode: 2,
            target: "txtFechaTermFisInfITO",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaEntregaDefCon = new JsDatePick({
            useMode: 2,
            target: "txtFechaEntregaDefCon",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaResLiqAntCon = new JsDatePick({
            useMode: 2,
            target: "txtFechaResLiqAntCon",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaDocApruebaLiqAnti = new JsDatePick({
            useMode: 2,
            target: "txtFechaDocApruebaLiqAnti",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaResLiqCon = new JsDatePick({
            useMode: 2,
            target: "txtFechaResLiqCon",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaEntRevEta = new JsDatePick({
            useMode: 2,
            target: "txtFechaEntRevEta",
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

        /*txtFechaTermFisInfITO
        ddlRespTermContrato
        txtFechaEntregaDefCon
        txtObsTerminoContrato*/
        
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
                Detalle Termino de Consultoría <div class="content_small">(Contrato-Contrato Termino)</div></td>
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
                                ToolTip="Crea Termino de Contrato" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Cancela Contrato" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla CONTRATO_TERMINO" 
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
                        &nbsp;Etapa
                            <asp:TextBox ID="txtEtapa" runat="server" CssClass="content" ReadOnly="True" 
                                Width="87px" Height="18px"></asp:TextBox>
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
                                    <td style="width: 35%">
                                        &nbsp;</td>
                                    <td style="width: 15%">
                                        &nbsp;</td>
                                    <td style="width: 15%">
                                        &nbsp;</td>
                                    <td style="width: 35%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Inicio Proceso Termino</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Responsable Termino Consultoría</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Fecha Término ITO Consultoría</td>
                                    <td>
                            <asp:TextBox ID="txtFechaTermFisInfITO" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRespTermContrato" runat="server" CssClass="content" 
                                            Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Fecha Entrega Definitiva Consultoría</td>
                                    <td>
                            <asp:TextBox ID="txtFechaEntregaDefCon" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image19" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                    <td>
                                        Liquidación Anticipada N º Resol</td>
                                    <td>
                                        <asp:TextBox ID="txtNumResLiqAntCon" runat="server" Width="100px" 
                                            CssClass="content" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtFechaResLiqAntCon" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image20" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        RF5.Liquidaciones anticipada visadas por el D.R. con NºDocto</td>
                                    <td>
                                        <asp:TextBox ID="txtNumDocApruebaLiqAnti" runat="server" Width="100px" 
                                            CssClass="content" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtFechaDocApruebaLiqAnti" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image21" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                    <td>
                                        Liquidación Consultoría Nº Resol</td>
                                    <td>
                                        <asp:TextBox ID="txtNumResLiqCon" runat="server" Width="100px" 
                                            CssClass="content" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtFechaResLiqCon" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image22" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Autoridad que liquida
                                        <asp:TextBox ID="txtAutoridadLiqCon" runat="server" Width="50%" 
                                            CssClass="content" MaxLength="30"></asp:TextBox>
                                    </td>
                                    <td>
                                        Calificación</td>
                                    <td>
                                        <asp:TextBox ID="txtClasifCon" runat="server" Width="100px" CssClass="content" 
                                            MaxLength="5"></asp:TextBox>
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
                                        Etapas Consultoría</td>
                                </tr>
                                <tr>
                                    <td>
                                        Número Etapa</td>
                                    <td>
                                        <asp:TextBox ID="txtNumeroEtapa" runat="server" Width="100px" 
                                            CssClass="content" MaxLength="4"></asp:TextBox>
                                    </td>
                                    <td>
                                        Días Revisíon</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasRevision" runat="server" Width="100px" 
                                            CssClass="content" MaxLength="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Días Legales</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasLegales" runat="server" Width="100px" 
                                            CssClass="content" MaxLength="4"></asp:TextBox>
                                    </td>
                                    <td>
                                        Días Totales</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasTotales" runat="server" Width="100px" 
                                            CssClass="content" MaxLength="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Entrega Revisión Etapa</td>
                                    <td>
                            <asp:TextBox ID="txtFechaEntRevEta" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image23" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Observación</td>
                                    <td>
                                        <asp:TextBox ID="txtObs" runat="server" Width="250px" CssClass="content" 
                                            MaxLength="100" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                                        </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                <asp:GridView ID="grdEtapas" runat="server" CellPadding="10" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="100%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="10%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="ETAPA_C" HeaderText="Número Etapa" >
                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Días Legales" DataField="DIAS_LEGALES" >
                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Fecha Entrega Revisión Etapa" 
                            DataField="F_ENTREGA_REVISION_ETAPA" >
                        <HeaderStyle Width="15%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DIAS_REVISION" HeaderText="Días Revisíon" >
                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Días Totales" DataField="PLAZO_TOTAL" >
                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Observación" DataField="OBSERVACION_C" >
                        <HeaderStyle Width="30%" />
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
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        Observaciones Termino Consultoría</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="txtObsTerminoContrato" runat="server" CssClass="content" 
                                            MaxLength="200" Rows="3" TextMode="MultiLine" Width="98%"></asp:TextBox>
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
                                        Conexión SSD</td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:ImageButton ID="cmdObtenerDocSSD" runat="server" 
                                        ImageUrl="~/img/plantilla/download.png" 
                                        ToolTip="Descargar documentos desde SSD" onclick="cmdObtenerDocSSD_Click" />
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
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label ID="lblCorreo" runat="server" CssClass="content"></asp:Label>
    <strong> GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
</div>

</form>

</body>
</html>
