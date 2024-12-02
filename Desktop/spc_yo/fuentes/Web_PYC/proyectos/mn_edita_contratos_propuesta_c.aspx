<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mn_edita_contratos_propuesta_c.aspx.vb" Inherits="proyectos_mn_edita_contratos_propuesta_c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">    

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings("TituloSistema").ToString())%></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" type="text/css" media="all" href="../js/reloj/jsDatePick_ltr.min.css" />
    <script type="text/javascript" src="../js/reloj/jquery.1.4.2.js"></script>
    <script type="text/javascript" src="../js/reloj/jsDatePick.jquery.min.1.3.js"></script>
    
    <script language="jscript" type="text/jscript" src="../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
    <!--

    window.onload = function() {

        Calendario_txtFechaRes = new JsDatePick({
        useMode: 2,
        target: "txtFechaRes",
        dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaInformeAdj = new JsDatePick({
        useMode: 2,
        target: "txtFechaInformeAdj",
        dateFormat: "%d/%m/%Y"
        });
        Calendario_txtFechaTramite = new JsDatePick({
        useMode: 2,
        target: "txtFechaTramite",
        dateFormat: "%d/%m/%Y"
        });
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
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaTramite.value.trim() != "" ) {

            if (document.frm_datos_contrato.ddlRutContratista.value == "(SELECCIONAR)" ) {
                alert("Para cambiar a Estado 'En ejecución': Debe seleccionar un contratista.");
                document.frm_datos_contrato.ddlRutContratista.focus();
                return false;
            }

            if (document.frm_datos_contrato.txtMontoAdjudicado.value == "" || document.frm_datos_contrato.txtMontoAdjudicado.value == "0" ) {
                alert("Para cambiar a Estado 'En ejecución': Debe ingresar el monto adjudicado.");
                document.frm_datos_contrato.txtMontoAdjudicado.focus();
                return false;
            }

            if (document.frm_datos_contrato.txtPlazoAdjudicado.value == "" || document.frm_datos_contrato.txtPlazoAdjudicado.value == "0" ) {
                alert("Para cambiar a Estado 'En ejecución': Debe ingresar el plazo de ejecución.");
                document.frm_datos_contrato.txtPlazoAdjudicado.focus();
                return false;
            }

            if (document.frm_datos_contrato.txtFechaInformeAdj.value == "" || document.frm_datos_contrato.txtFechaInformeAdj.value == "01/01/1900") {
                alert("Para cambiar a Estado 'En ejecución': Debe ingresar la fecha inf. adjudicación.");
                document.frm_datos_contrato.txtFechaInformeAdj.focus();
                return false;
            }

            if (document.frm_datos_contrato.ddlResOrigen.value == "(SELECCIONAR)") {
                alert("Para cambiar a Estado 'En ejecución': Debe seleccionar una resolución origen.");
                document.frm_datos_contrato.ddlResOrigen.focus();
                return false;
            }

            if (document.frm_datos_contrato.txtNumeroRes.value == "" || document.frm_datos_contrato.txtNumeroRes.value == "0") {
                alert("Para cambiar a Estado 'En ejecución': Debe ingresar un numero de resolución.");
                document.frm_datos_contrato.txtNumeroRes.focus();
                return false;
            }

            if (document.frm_datos_contrato.txtFechaRes.value == "" || document.frm_datos_contrato.txtFechaRes.value == "01/01/1900") {
                alert("Para cambiar a Estado 'En ejecución': Debe ingresar la fecha de resolución.");
                document.frm_datos_contrato.txtFechaRes.focus();
                return false;
            }

            document.frm_datos_contrato.txtAdjudicado.value = "Si";

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
                Edición de Contratos (Propuesta)<div class="content_small">(Contrato)</div></td>
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
               
                    <tr>
                        <td class="content">
                            Estado</td>
                        <td class="content">
                            <asp:TextBox ID="txtEstado" runat="server" CssClass="content" ReadOnly="True" 
                                Width="223px" Height="18px"></asp:TextBox>
                            &nbsp;
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
                            <br />
                            <table class="content" style="width: 100%;">
                                <tr>
                                    <td style="width: 25%;">
                                        &nbsp;</td>
                                    <td style="width: 25%;">
                                        &nbsp;</td>
                                    <td style="width: 25%;">
                                        &nbsp;</td>
                                    <td style="width: 25%;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        C) PROCESO DE ADJUDICACIÓN - En Adjudicación</td>
                                </tr>
                                <tr>
                                    <td>
                                        Comision Evaluadora</td>
                                    <td>
                            <asp:TextBox ID="txtComEval1" runat="server" CssClass="content" 
                                Width="95%" Height="18px" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td>
                                        Res. Origen </td>
                                    <td>
                                        <asp:DropDownList ID="ddlResOrigen" runat="server" CssClass="content" 
                                            Height="16px" Width="95%" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                            <asp:TextBox ID="txtComEval2" runat="server" CssClass="content" 
                                Width="95%" Height="18px" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td>
                                        Nº Res </td>
                                    <td>
                            <asp:TextBox ID="txtNumeroRes" runat="server" CssClass="content" 
                                Width="52px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                            <asp:TextBox ID="txtComEval3" runat="server" CssClass="content" 
                                Width="95%" Height="18px" MaxLength="100"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha </td>
                                    <td>
                    <asp:TextBox ID="txtFechaRes" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image14" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Fecha inf. Adjudicación</td>
                                    <td>
                    <asp:TextBox ID="txtFechaInformeAdj" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image13" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    
                            <asp:TextBox ID="txtAdjudicado" runat="server" CssClass="content" Width="52px" Height="18px" MaxLength="6" ReadOnly="True" Visible="False"></asp:TextBox>
                            
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Fecha Tramite</td>
                                    <td>
                    <asp:TextBox ID="txtFechaTramite" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px" ></asp:TextBox>
                    <asp:Image ID="Image15" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                        Contratista Adjudicado</td>
                                    <td>
                                        <asp:DropDownList ID="ddlRutContratista" runat="server" CssClass="content" 
                                            Height="16px" Width="95%" Font-Size="X-Small" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Monto Adjudicado</td>
                                    <td>
                            <asp:TextBox ID="txtMontoAdjudicado" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="20"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Plazo de Ejecución</td>
                                    <td>
                            <asp:TextBox ID="txtPlazoAdjudicado" runat="server" CssClass="content" 
                                Width="52px" Height="18px" MaxLength="6"></asp:TextBox>
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
                                </tr>
                            </table>
                            <br />
                        </td>
                </tr>
        </table>
    
</div>

<div class="footer" >
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"> </asp:Label> <asp:Label ID="lblCorreo" runat="server" CssClass="content"> </asp:Label>
    <strong> GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"> </asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"> </asp:Label>
</div>

    </form>

</body>
</html>

