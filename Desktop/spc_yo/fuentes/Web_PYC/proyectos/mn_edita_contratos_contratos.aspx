<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_edita_contratos_contratos.aspx.cs" Inherits="mn_edita_contratos_contratos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" type="text/css" media="all" href="../js/reloj/jsDatePick_ltr.min.css" />
    <script type="text/javascript" src="../js/reloj/jquery.1.4.2.js"></script>
    <script type="text/javascript" src="../js/reloj/jsDatePick.jquery.min.1.3.js"></script>
    
    <script language="jscript" type="text/jscript" src="../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
    <!--

    function func_calcula_term_legal() {

        dia = document.frm_datos_contrato.txtFechaInicioLegal.value.substring(0, 2);
        mes = document.frm_datos_contrato.txtFechaInicioLegal.value.substring(3, 5);
        ano = document.frm_datos_contrato.txtFechaInicioLegal.value.substring(6, 10);

        var strFecha = new Date(mes + "/" + dia + "/" + ano);

        intDias = document.frm_datos_contrato.txtPlazoDias.value - 1;

        dtFecha = DateAdd(strFecha, "D", intDias);
        
        document.frm_datos_contrato.txtFechaTerminoLegalInicial.value = dateFormat(dtFecha,'DD/MM/YYYY');
        
    }

    window.onload = function() {

        Calendario_txtFechaInicioLegal = new JsDatePick({
            useMode: 2,
            target: "txtFechaInicioLegal",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaEntregaTerreno = new JsDatePick({
            useMode: 2,
            target: "txtFechaEntregaTerreno",
            dateFormat: "%d/%m/%Y"
        });

    } 
    function cmdObtenerDocSSDValida_Click() {

        if (document.frm_datos_contrato.txtCodigoContrato.value == "") {
            alert("Para conexión con SSD, debe ingresar un codigo de contrato.");
            document.frm_datos_contrato.txtCodigoContrato.focus();
            return false;
        }

        return true;
    }

    function func_valida_grabar() {

        document.frm_datos_contrato.target = '_self';

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
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtSufijo.focus();
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
                                Edición de Contratos <div class="content_small">(Contrato)</div></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 743px">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Grabar Contrato" onclick="cmdGrabar_Click" OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla Contrato" Visible="False"></asp:Label>
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
                                Width="41px" Height="18px"></asp:TextBox>
                        &nbsp;Código Contrato
                            <asp:TextBox ID="txtCodigoContrato" runat="server" CssClass="content" ReadOnly="True" 
                                Width="87px" Height="18px"></asp:TextBox>
                                    &nbsp;
                        &nbsp;</td>
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
                            <table class="content" style="width: 100%">
                                <tr>
                                    <td style="width: 12%">
                                        &nbsp;</td>
                                    <td style="width: 12%">
                                        &nbsp;</td>
                                    <td style="width: 12%">
                                        &nbsp;</td>
                                    <td style="width: 12%">
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td style="width: 12%">
                                        &nbsp;</td>
                                    <td style="width: 12%">
                                        &nbsp;</td>
                                    <td style="width: 12%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="8" class="borde_celda">
                                        IDENTIFICACIÓN DEL CONTRATO</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Fecha Ingreso</td>
                                    <td>
                            <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td class="style2">
                                        Digitador</td>
                                    <td>
                            <asp:TextBox ID="txtDigitador" runat="server" CssClass="content" ReadOnly="True" 
                                Width="100px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha Actualización</td>
                                    <td>
                            <asp:TextBox ID="txtFechaActualizacion" runat="server" CssClass="content" ReadOnly="True" 
                                Width="100px" Height="20px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Provincia</td>
                                    <td>
                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="content" ReadOnly="True" 
                                Width="100px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Comuna</td>
                                    <td>
                            <asp:TextBox ID="txtComuna" runat="server" CssClass="content" ReadOnly="True" 
                                Width="95%" Height="20px"></asp:TextBox>
                                    </td>
                                    <td class="style2">
                                        T. Fondo</td>
                                    <td>
                            <asp:TextBox ID="txtFondo" runat="server" CssClass="content" ReadOnly="True" 
                                Width="100px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <b>M2</b></td>
                                    <td>
                            <asp:TextBox ID="txtM2" runat="server" CssClass="content" 
                                Width="100px" Height="20px" MaxLength="8" BackColor="#FFFFCC"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Localizacion</td>
                                    <td colspan="7">
                            <asp:TextBox ID="txtLocalizacion" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50%" Height="21px"></asp:TextBox>
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
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="8" class = " borde_celda" >
                                        DATOS DEL CONTRATO</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Button ID="cmdInspectorFiscal" runat="server" CssClass="content" 
                                            Text="Inspector Fiscal" Width="232px" onclick="cmdInspectorFiscal_Click" 
                                            Height="22px" />
                                    </td>
                                    <td colspan="3" style="text-align: right; font-weight: bold;" >
                                        Descripción Contrato</td>
                                    <td colspan="2" rowspan="4">
                                        <asp:TextBox ID="txtDescContrato" runat="server" Height="85px" 
                                            TextMode="MultiLine" Width="95%" CssClass="content" MaxLength="400" 
                                            BackColor="#FFFFCC"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Button ID="cmdDetalleTerminoContrato" runat="server" CssClass="content" 
                                            Text="Detalle Termino Contrato" Width="232px" Font-Strikeout="False" 
                                            onclick="cmdDetalleTerminoContrato_Click" Height="22px" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
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
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        Contratista
                                        <asp:TextBox ID="txtContratista" runat="server" Height="21px" Width="301px" 
                                            CssClass="content" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        Resolución de Adjudicación
                                        Orig.</td>
                                    <td>
                            <asp:TextBox ID="txtResAdjuOrig" runat="server" CssClass="content" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td class="style2">
                                        Nº</td>
                                    <td>
                            <asp:TextBox ID="txtNumeroRes" runat="server" CssClass="content" 
                                Width="77px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtFechaRes" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha Tramite</td>
                                    <td>
                            <asp:TextBox ID="txtFechaTramite" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Monto Adjudicado</td>
                                    <td>
                            <asp:TextBox ID="txtMontoAdjudicado" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td class="style2">
                                        Plazo Ejec en (días)</td>
                                    <td>
                            <asp:TextBox ID="txtPlazoDias" runat="server" CssClass="content" 
                                Width="77px" Height="20px" onchange="javascript:return func_calcula_term_legal();" 
                                            ReadOnly="True"></asp:TextBox>
                                    </td>
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
                                        <b>Fecha Inicio Legal</b></td>
                                    <td>
                            <asp:TextBox ID="txtFechaInicioLegal" runat="server" CssClass="content" 
                                Width="80px" Height="20px" BackColor="#FFFFCC" 
                                            onblur="javascript:return func_calcula_term_legal();" 
                                            onmouseout = "javascript:return func_calcula_term_legal();" 
                                            onmouseover = "javascript:return func_calcula_term_legal();"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        <b>Fecha Entrega Terreno</b></td>
                                    <td>
                            <asp:TextBox ID="txtFechaEntregaTerreno" runat="server" CssClass="content" 
                                Width="80px" Height="20px" BackColor="#FFFFCC"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td >
                                        F. Term. Legal Inicial</td>
                                    <td>
                            <asp:TextBox ID="txtFechaTerminoLegalInicial" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        <b>Plazo no Computable</b></td>
                                    <td>
                            <asp:TextBox ID="txtPlazoNoComputable" runat="server" CssClass="content" 
                                Width="80px" Height="20px" MaxLength="4" BackColor="#FFFFCC"></asp:TextBox>
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
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="8" class="borde_celda">
                                        RESUMEN DATOS VIGENTES</td>
                                </tr>
                                <tr>
                                    <td>
                                        Variación Monto</td>
                                    <td>
                            <asp:TextBox ID="txtVariacionMonto" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Monto Vigente</td>
                                    <td>
                            <asp:TextBox ID="txtMontoVigente" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td class="style2">
                                        Inv. Acumulada</td>
                                    <td>
                            <asp:TextBox ID="txtInversionAcumulada" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Saldo Por Invertir</td>
                                    <td>
                            <asp:TextBox ID="txtSaldoPorInvertir" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Variaciones Plazo</td>
                                    <td>
                            <asp:TextBox ID="txtVariacionesPlazo" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Plazo Vigente (Días)</td>
                                    <td>
                            <asp:TextBox ID="txtPlazoVigenteDias" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td class="style2">
                                        Fecha Termino Legal</td>
                                    <td>
                            <asp:TextBox ID="txtFechaTerminoLegal" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Avance Financiero %</td>
                                    <td>
                            <asp:TextBox ID="txtPorcAvanceFinanc" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Avance Físico %</td>
                                    <td>
                            <asp:TextBox ID="txtPorAvanceFisico" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="20px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                         Libro Digital</td>
                                    <td>
                                        <asp:DropDownList ID="ddlLod" runat="server"
                                        Width="110px" Height="20px" BackColor="#FFFFCC"></asp:DropDownList>
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
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="8" class="borde_celda">
                                        OBSERVACIONES RELEVANTES DEL CONTRATO</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="8">
                                        <asp:TextBox ID="txtObsRelContrato" runat="server" Height="55px" 
                                            TextMode="MultiLine" Width="98%" MaxLength="300" CssClass="content" 
                                            BackColor="#FFFFCC"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="8">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="8" class="borde_celda">
                                        DETALLE DEL MOVIMIENTO DEL CONTRATO</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="8">
                                        <asp:Button ID="cmdGarantias" runat="server" CssClass="content" 
                                            Text="Garantías" Width="140px" Height="26px" Font-Bold="False" 
                                            Font-Overline="False" Font-Strikeout="False" 
                                            onclick="cmdGarantias_Click" Enabled="False" />
                                    &nbsp;<asp:Button ID="cmdImputaPresup" runat="server" CssClass="content" 
                                            Text="Imputac. Presusp." Width="140px" Font-Italic="False" 
                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                            Height="26px" onclick="cmdImputaPresup_Click" Enabled="False" />
                                    &nbsp;<asp:Button ID="cmdProgramacion" runat="server" CssClass="content" 
                                            Text="Programación" Width="140px" Height="26px" Font-Strikeout="False" 
                                            onclick="cmdProgramacion_Click" Enabled="False" />
                                    &nbsp;<asp:Button ID="cmdEstadoPagos" runat="server" CssClass="content" 
                                            Text="Estado Pagos" Width="140px" Height="26px" Font-Strikeout="False" 
                                            onclick="cmdEstadoPagos_Click" Enabled="False" />
                                    &nbsp;<asp:Button ID="cmdAvancesFisicos" runat="server" CssClass="content" 
                                            Text="Avances Físicos" Width="140px" Height="26px" 
                                            Font-Strikeout="False" onclick="cmdAvancesFisicos_Click" Enabled="False" />
                                    &nbsp;<asp:Button ID="cmdModificaciones" runat="server" CssClass="content" 
                                            Text="Modificaciones" Width="140px" Height="26px" Font-Strikeout="False" 
                                            onclick="cmdModificaciones_Click" Enabled="False" />
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
                                    <td class="style2">
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
