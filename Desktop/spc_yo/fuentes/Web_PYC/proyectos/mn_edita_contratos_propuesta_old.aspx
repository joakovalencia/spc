<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mn_edita_contratos_propuesta_old.aspx.vb" Inherits="proyectos_mn_edita_contratos_propuesta_old" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">    
    <title><% Response.Write(ConfigurationManager.AppSettings("TituloSistema").ToString())%></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    <script language="jscript" type="text/jscript" src="../js/popcalendar.js"></script>
    <script language="jscript" type="text/jscript" src="../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
    <!--
  
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

        if (document.frm_datos_contrato.ddlEstado.value == "(SELECCIONAR)") {
            alert("Debe seleccionar estado.");
            document.frm_datos_contrato.ddlEstado.focus();
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
            text-align: right;
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
                        &nbsp;Codio Contrato
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
                            &nbsp;</td>
                        <td class="content">
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
            <td style="width: 933px;" class="content">
                            Estado del Contrato:
                            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="content" 
                                Height="20px" Width="252px">
                            </asp:DropDownList>
&nbsp;&nbsp;<asp:HiddenField ID="txtMandantesConvenio" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                                        <asp:Button ID="cmdIngresoMandantes" runat="server" Height="29px" 
                                            Text="Ingreso Mandantes (Convenios)" Width="264px" 
                                            CssClass="content" />
                                    </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            <table class="content" style="width: 100%">
                                <tr>
                                    <td style="width: 25%">
                                        Provincia                            <td style="width: 25%">
                                        <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="content" 
                                            Height="17px" Width="195px" Font-Size="X-Small" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 10%">
                                        Comuna</td>
                                    <td style="width: 40%">
                                        <asp:DropDownList ID="ddlComuna" runat="server" CssClass="content" 
                                            Height="17px" Width="195px" Font-Size="X-Small" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Localización</td>
                                    <td>
                                        <asp:DropDownList ID="ddlLocalizacion" runat="server" CssClass="content" 
                                            Height="17px" Width="195px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Dirección</td>
                                    <td>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="content" 
                                Width="95%" Height="18px" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Nº</td>
                                    <td valign="top">
                            <asp:TextBox ID="txtDireNumero" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                    <td valign="top">
                                        &nbsp;</td>
                                    <td valign="top">
                                        &nbsp;</td>
                                </tr>
                                </table>
                            <br />
                            <table class="content" style=" width:100%">
                                <tr>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6"  class="borde_celda">
                                        A) PROGRAMACIÓN LICITACIÓN</td>
                                </tr>
                                <tr>
                                    <td>
                                        Reg. Especial (S/N)</td>
                                    <td>
                                        <asp:DropDownList ID="ddlReqRegEspecial" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">                    
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Tipo Licitación</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoLicitacion" runat="server" CssClass="content" 
                                            Height="16px" Width="95%" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Mod. Contratación</td>
                                    <td>
                                        <asp:DropDownList ID="ddlMoContratacion" runat="server" CssClass="content" 
                                            Height="16px" Width="95%" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Reajuste</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipoReajuste" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
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
                                    <td colspan="2" class="borde_celda_small">
                                        <b>Bases Administrativas</b></td>
                                    <td class="content">
                                        Presup. Estimado</td>
                                    <td>
                            <asp:TextBox ID="txtPresupEstimado" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6" onkeypress="return digits(this, event, true, true);"></asp:TextBox>
                                    </td>
                                    <td>
                                        Plazo Estimado</td>
                                    <td>
                            <asp:TextBox ID="txtPlazoEstimado" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borde_left_celda">
                                        Especiales</td>
                                    <td class="borde_right_celda">
                                        <asp:DropDownList ID="ddlBAEspeciales" runat="server" CssClass="content" 
                                            Height="18px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        Anticipo Contemplado</td>
                                    <td>
                            <asp:TextBox ID="txtAnticipoContemplado" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        % Anticipo Contemplado</td>
                                    <td>
                            <asp:TextBox ID="txtAnticipoContempladoPorc" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borde_left_celda">
                                        Generales</td>
                                    <td class="borde_right_celda">
                                        <asp:DropDownList ID="ddlBAGerenciales" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Registro</td>
                                    <td>
                                        <asp:DropDownList ID="ddlRegistro" runat="server" CssClass="content_small" 
                                            Height="16px" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Categoria</td>
                                    <td>
                                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="content_small" 
                                            Height="16px" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borde_left_celda">
                                        Tecnicas</td>
                                    <td class="borde_right_celda">
                                        <asp:DropDownList ID="ddlBATecnicas" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
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
                                    <td class="borde_left_celda">
                                        Carpeta Tecnica Licitación</td>
                                    <td class="borde_right_celda">
                                        <asp:DropDownList ID="ddlBACarpetaTecnica" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Responsable <div class="content_small">(preparación antecedentes propuesta)</div> </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRespAntPPTA" runat="server" CssClass="content_small" 
                                            Height="16px" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        ID ChileCompra</td>
                                    <td>
                            <asp:TextBox ID="txtIDChileCompra" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="borde_top_celda">
                                        &nbsp;</td>
                                    <td class="borde_top_celda">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="2" class="borde_celda_small">
                                        <b>Permiso Edificación</b></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style1" colspan="2">
                                        &nbsp;</td>
                                    <td>
                                        Nº</td>
                                    <td>
                            <asp:TextBox ID="txtNumeroPermEdificacion" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6"></asp:TextBox>
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
                                    <td>
                                        Fecha</td>
                                    <td>
                    <asp:TextBox ID="txtFechaPermEdificacion" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Publicación</td>
                                    <td>
                    <asp:TextBox ID="txtFechaPublicacion" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Apertura Técnica</td>
                                    <td>
                    <asp:TextBox ID="txtFechaAperturaTecnica" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Apertura Económica</td>
                                    <td>
                    <asp:TextBox ID="txtFechaAperturaEconomica" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        RP3.RP3. Cartilla de chequeo propuesta técnica de ofertas de licitación de 
                                        consultorias y obras </td>
                                    <td>
                                        Aplicó?</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAplicaCartillaR26" runat="server" CssClass="content_small" 
                                            Height="16px" Width="130px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                    <asp:TextBox ID="txtFechaDoctoR26" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        RP7.Monitoreo de aplicación de cartilla de chequeo previo de Terreno</td>
                                    <td>
                                        Aplicó?</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAplicaCartillaR28" runat="server" CssClass="content_small" 
                                            Height="16px" Width="130px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                    <asp:TextBox ID="txtFechaDoctoR28" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        RP8.Monitoreo de aplicación de cartilla de chequeo previo de Obras</td>
                                    <td>
                                        Aplicó?</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAplicaCartillaR29" runat="server" CssClass="content_small" 
                                            Height="16px" Width="130px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                    <asp:TextBox ID="txtFechaDoctoR29" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image7" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                </tr>
                            </table>
                            <br />
                            <table class="content" style=" width:100%">
                                <tr>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                    <td style="width:16%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6"  class="borde_celda">
                                        B) PROCESO DE LICITACIÓN</td>
                                </tr>
                                <tr>
                                    <td>
                                        Responsable Licitación</td>
                                    <td>
                                        <asp:DropDownList ID="ddlResponsableLicitacion" runat="server" CssClass="content_small" 
                                            Height="16px" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        Ingresar Nº de llamado a lictación de este contrato</td>
                                    <td>
                                        <asp:DropDownList ID="ddlLlamado" runat="server" CssClass="content_small" 
                                            Height="16px" Width="130px">
                                        </asp:DropDownList>
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        RF2.-Si en el primer llamado de este contrato no se presentaron oferentes 
                                        ingrese nº y fecha de informe GIP de análisis de honorarios o presupuesto</td>
                                    <td>
                                        Nº</td>
                                    <td>
                            <asp:TextBox ID="txtNDoctoR5" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                    <asp:TextBox ID="txtFechaDoctoR5" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" valign="top">
                                        Observaciones</td>
                                    <td colspan="4">
                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="content" 
                                Width="95%" Height="45px" MaxLength="300" TextMode="MultiLine"></asp:TextBox>
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Presupuesto Oficial</td>
                                    <td>
                            <asp:TextBox ID="txtPresupuestoOficial" runat="server" CssClass="content" 
                                Width="120px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                    <td colspan="4">
                                        RF3.- SI se presentaron oferentes y no se adjudicó la propuesta, ingresar nº y 
                                        fecha de informe GIP del análisis de la causa</td>
                                </tr>
                                <tr>
                                    <td>
                                        Plazo Oficial</td>
                                    <td>
                            <asp:TextBox ID="txtPlazoOficial" runat="server" CssClass="content" 
                                Width="52px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                    <td>
                                        Nº</td>
                                    <td>
                            <asp:TextBox ID="txtNumResNoAdjudica" runat="server" CssClass="content" 
                                Width="52px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                    <asp:TextBox ID="txtFechaResNoAdjudica" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Publicación</td>
                                    <td>
                    <asp:TextBox ID="txtFechaLicitacion" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image12" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
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
                                        Apertura Técnica</td>
                                    <td>
                    <asp:TextBox ID="txtFechaApertTecnica" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image11" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td colspan="3">
                                        En caso de no ser positivo el resultado de la propuesta, favor ingresar el 
                                        motivo</td>
                                    <td>
                                        <asp:DropDownList ID="ddlResTipoNoAdjudica" runat="server" CssClass="content" 
                                            Height="16px" Width="130px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Apertura Económica</td>
                                    <td>
                    <asp:TextBox ID="txtFechaAperturaTecnicaProp" runat="server" CssClass="content" 
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
                    <asp:Image ID="Image10" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
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
                                    <td colspan="2">
                                        <asp:Button ID="cmdRegistroOfertaContratista" runat="server" Height="29px" 
                                            Text="Registro de Ofertas de Contratistas" Width="264px" 
                                            CssClass="content" />
                                    </td>
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
                            </table>
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
                                        C) PROCESO DE ADJUDICACIÓN</td>
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
                                    <td>
                                        Se Adjudica contrato?</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAdjudicado" runat="server" CssClass="content" 
                                            Height="16px" Width="50%" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
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
                        ReadOnly="True" Width="100px" Height="22px"></asp:TextBox>
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
                                            Height="16px" Width="95%" Font-Size="X-Small">
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

<script language="javascript" type="text/javascript">

    popcalendar = getCalendarInstance();
    popcalendar.startAt = 1;
    popcalendar.showWeekNumber = 0;
    popcalendar.showToday = 1;
    popcalendar.showWeekend = 1;
    popcalendar.showHolidays = 1;
    popcalendar.selectWeekend = 1;
    popcalendar.selectHoliday = 1;
    popcalendar.addCarnival = 0;
    popcalendar.addGoodFriday = 0;
    popcalendar.language = 0;
    popcalendar.defaultFormat = "dd/mm/yyyy";
    popcalendar.fixedX = -1;
    popcalendar.fixedY = -1;
    popcalendar.fade = .5;
    popcalendar.shadow = 1;
    popcalendar.move = 1;
    popcalendar.saveMovePos = 1;
    popcalendar.centuryLimit = 40;
    popcalendar.initCalendar();     
</script>

</body>
</html>

