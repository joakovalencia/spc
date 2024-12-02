<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_convenios_det_proy.aspx.cs" Inherits="mn_convenios_det_proy" %>

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

        Calendario_txtFechaConvenio = new JsDatePick({
            useMode: 2,
            target: "txtFechaConvenio",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaRes = new JsDatePick({
            useMode: 2,
            target: "txtFechaRes",
            dateFormat: "%d/%m/%Y"
        });

    } 

    function func_monto_compromet()
    {
        document.frm_datos_contrato.txtMontoCompromet.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtMontoNeto.value))
                                                                + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtGastosAdmin.value))
                                                                + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtGastosConsultoria.value))
                                                                + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtOtrosGastos.value));

        document.frm_datos_contrato.txtMontoCompromet.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.txtMontoCompromet.value));
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
                 
        if (document.frm_datos_contrato.txtCorrelativo.value == "") {
            alert("Debe ingresar N°.");
            document.frm_datos_contrato.txtCorrelativo.focus();
            return false;
        }       
         
//        if (document.frm_datos_contrato.ddlMandante.value == "(SELECCIONAR)") {
//            alert("Debe seleccionar mandante.");
//            document.frm_datos_contrato.ddlMandante.focus();
//            return false;
//        }
        
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

        if (document.frm_datos_contrato.txtCorrelativo.value == "") {
            alert("Debe ingresar N°.");
            document.frm_datos_contrato.txtCorrelativo.focus();
            return false;
        }
                 
        if (document.frm_datos_contrato.ddlEtapa.value == "(SELECCIONAR)") {
            alert("Debe seleccionar etapa.");
            document.frm_datos_contrato.ddlEtapa.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlMandante.value == "(SELECCIONAR)" || document.frm_datos_contrato.ddlMandante.value == "")        
        {
            alert("Debe seleccionar mandante.");
            document.frm_datos_contrato.ddlMandante.focus();
            return false;
        }        
         
        if (document.frm_datos_contrato.txtFechaConvenio.value == "") {
            alert("Debe ingresar fecha convenio.");
            document.frm_datos_contrato.txtFechaConvenio.focus();
            return false;
        }        
         
        /*
        if (document.frm_datos_contrato.txtNumeroRes.value == "") {
            alert("Debe ingresar n° res.");
            document.frm_datos_contrato.txtNumeroRes.focus();
            return false;
        }        
         
        if (document.frm_datos_contrato.txtFechaRes.value == "") {
            alert("Debe ingresar fecha res.");
            document.frm_datos_contrato.txtFechaRes.focus();
            return false;
        }*/
                 
        if (document.frm_datos_contrato.ddlTipoConvenio.value == "(SELECCIONAR)") {
            alert("Debe seleccionar tipo convenio.");
            document.frm_datos_contrato.ddlTipoConvenio.focus();
            return false;
        }        
           
        /*     
        if (document.frm_datos_contrato.txtMontoCompromet.value == "") {
            alert("Debe ingresar monto comprometido.");
            document.frm_datos_contrato.txtMontoCompromet.focus();
            return false;
        }*/
                
        if (document.frm_datos_contrato.txtMontoNeto.value == "") {
            alert("Debe ingresar monto neto.");
            document.frm_datos_contrato.txtMontoNeto.focus();
            return false;
        }
                 
        if (document.frm_datos_contrato.txtGastosAdmin.value == "") {
            alert("Debe ingresar gastos administrativos.");
            document.frm_datos_contrato.txtGastosAdmin.focus();
            return false;
        }
                
        if (document.frm_datos_contrato.txtGastosConsultoria.value == "") {
            alert("Debe ingresar gastos consultoria.");
            document.frm_datos_contrato.txtGastosConsultoria.focus();
            return false;
        }

        /*     
        if (document.frm_datos_contrato.ddlEstadoConvenio.value == "(SELECCIONAR)") {
            alert("Debe seleccionar convenio.");
            document.frm_datos_contrato.ddlEstadoConvenio.focus();
            return false;
        }*/
           
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
                Convenios con Mandantes <div class="content_small">(Proyecto-Convenios)</div></td>
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
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla CONVENIO" 
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
                            &nbsp;</td>
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
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Datos Convenio</td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>N° (Correlativo)</b></td>
                                    <td>
                            <asp:TextBox ID="txtCorrelativo" runat="server" CssClass="content" 
                                Width="82px" Height="18px" MaxLength="3"></asp:TextBox>
                                    </td>
                                    <td>
                                        Tipo Convenio</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoConvenio" runat="server" CssClass="content" 
                                            Height="20px" Width="125px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Etapa</td>
                                    <td>
                                        <asp:DropDownList ID="ddlEtapa" runat="server" CssClass="content" 
                                            Height="20px" Width="125px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Monto Compromet.</td>
                                    <td >
                            <asp:TextBox ID="txtMontoCompromet" runat="server" CssClass="content" 
                                Width="150px" Height="18px" MaxLength="15" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>Mandante</b>
                                        </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMandante" runat="server" CssClass="content" 
                                            Height="20px" Width="125px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Monto Neto</td>
                                    <td >
                            <asp:TextBox ID="txtMontoNeto" runat="server" CssClass="content" 
                                Width="150px" Height="18px" MaxLength="15" OnChange="javascript: func_monto_compromet();"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Convenio</td>
                                    <td>
                            <asp:TextBox ID="txtFechaConvenio" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Gastos Administrat.</td>
                                    <td>
                            <asp:TextBox ID="txtGastosAdmin" runat="server" CssClass="content" 
                                Width="150px" Height="18px" MaxLength="15" OnChange="javascript: func_monto_compromet();"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Res.</td>
                                    <td>
                            <asp:TextBox ID="txtNumeroRes" runat="server" CssClass="content" 
                                Width="82px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Gastos Consultoria</td>
                                    <td>
                            <asp:TextBox ID="txtGastosConsultoria" runat="server" CssClass="content" 
                                Width="150px" Height="18px" MaxLength="15" OnChange="javascript: func_monto_compromet();"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                          Estado Convenio</td>
                                    <td>
                                        <asp:DropDownList ID="ddlEstadoConvenio" runat="server" CssClass="content" 
                                            Height="20px" Width="125px" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Otros Gastos</td>
                                    <td>
                                        <asp:TextBox ID="txtOtrosGastos" runat="server" CssClass="content" 
                                            Width="150px" Height="18px" MaxLength="15" OnChange="javascript: func_monto_compromet();"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Fecha Res.</td>
                                    <td>
                            <asp:TextBox ID="txtFechaRes" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td valign="top">
                                        Observaciones</td>
                                    <td rowspan="2">
                            <asp:TextBox ID="txtObs" runat="server" CssClass="content" 
                                Width="95%" Height="80px" MaxLength="250" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
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
                
                                                                                Convenios     Convenios</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                     
                                     
                    <asp:GridView ID="grdConvenio" runat="server" CellPadding="4"  
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="100%" onselectedindexchanged="grdConvenio_SelectedIndexChanged" OnRowDataBound="OnRowDataBound" EnableModelValidation="True"  >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selec." ShowSelectButton="True">
                        <HeaderStyle Width="9%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="CORRELATIVO" HeaderText="N°" HtmlEncode="False" >
                        </asp:BoundField>
                        <asp:BoundField DataField="ETAPA" HeaderText="Etapa" HtmlEncode="False" >
                        </asp:BoundField>
                        <asp:BoundField DataField="MANDANTE" HeaderText="Mandante" HtmlEncode="False" >
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHA_CONVENIO" HeaderText="Fecha Convenio" 
                            HtmlEncode="False" >
                        </asp:BoundField>
                        <asp:BoundField DataField="NUM_DECRETO" HeaderText="Res." HtmlEncode="False" >
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHA_DECRETO" HeaderText="Fecha Res." 
                            HtmlEncode="False" >
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Tipo Convenio" DataField="TIPO_CONVENIO" 
                            HtmlEncode="False" >
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Monto Compromet." 
                            DataField="MONTO_COMPROMET2" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Monto Neto" DataField="MONTO_NETO2" >
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GASTOS_ADMINISTRATIVOS2" HeaderText="Gastos Admin.">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONSUL2" HeaderText="Gastos Consultria">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>    
                        <asp:BoundField DataField="OTROS_GASTOS2" HeaderText="Otros Gastos">
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ESTADO_CONVENIO" HeaderText="Estado Convenio" 
                            HtmlEncode="False" />
                        <asp:BoundField DataField="OBSERVACION" HeaderText="Obs" HtmlEncode="False" />
                        <asp:HyperLinkField DataNavigateUrlFields="url_seleccion" HeaderText="Modif." 
                            Text="Select" />
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
                                    <td colspan="2">
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                                        </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style1">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="auto-style1">
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
