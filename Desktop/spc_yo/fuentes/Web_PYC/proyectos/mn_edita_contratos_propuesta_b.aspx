<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mn_edita_contratos_propuesta_b.aspx.vb" Inherits="proyectos_mn_edita_contratos_propuesta_b" %>

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

        Calendario_txtFechaDoctoR5 = new JsDatePick({
            useMode: 2,
            target: "txtFechaDoctoR5",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaLicitacion = new JsDatePick({
            useMode: 2,
            target: "txtFechaLicitacion",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaResNoAdjudica = new JsDatePick({
            useMode: 2,
            target: "txtFechaResNoAdjudica",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaApertTecnica = new JsDatePick({
            useMode: 2,
            target: "txtFechaApertTecnica",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaAperturaTecnicaProp = new JsDatePick({
            useMode: 2,
            target: "txtFechaAperturaTecnicaProp",
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

        if (document.frm_datos_contrato.ddlLlamado.value == "(SELECCIONAR)" ) {
            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Llamado.");
            document.frm_datos_contrato.ddlLlamado.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPresupuestoOficial.value == "0" || document.frm_datos_contrato.txtPresupuestoOficial.value == "" ) {
            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Presupuesto Oficial.");
            document.frm_datos_contrato.txtPresupuestoOficial.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPlazoOficial.value == "0" || document.frm_datos_contrato.txtPlazoOficial.value == "" ) {
            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Plazo Oficial.");
            document.frm_datos_contrato.txtPlazoOficial.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaLicitacion.value == "" || document.frm_datos_contrato.txtFechaLicitacion.value == "01/01/1900") {
            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Fecha Licitación.");
            document.frm_datos_contrato.txtFechaLicitacion.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaApertTecnica.value == "" || document.frm_datos_contrato.txtFechaApertTecnica.value == "01/01/1900") {
            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Fecha Apertura Tecnica.");
            document.frm_datos_contrato.txtFechaApertTecnica.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaAperturaTecnicaProp.value == "" || document.frm_datos_contrato.txtFechaAperturaTecnicaProp.value == "01/01/1900") {
            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Fecha Apertura Tecnica Prop.");
            document.frm_datos_contrato.txtFechaAperturaTecnicaProp.focus();
            return false;
        }


        /* Fechas no deben ser del futuro */
        if (esFechaFuturo(document.frm_datos_contrato.txtFechaLicitacion.value )) {
            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar una Fecha de Licitación igual o menor a hoy.");
            document.frm_datos_contrato.txtFechaLicitacion.focus();
            return false;
        }

//        if (esFechaFuturo(document.frm_datos_contrato.txtFechaApertTecnica.value )) {
//            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Fecha Apertura Tecnica igual o menor a hoy. ");
//            document.frm_datos_contrato.txtFechaApertTecnica.focus();
//            return false;
//        }


//        if (esFechaFuturo(document.frm_datos_contrato.txtFechaAperturaTecnicaProp.value)) {
//            alert("Para cambiar a Estado 'Proceso de Publicación': Debe ingresar Fecha Apertura Tecnica Prop. igual o menor a hoy.");
//            document.frm_datos_contrato.txtFechaAperturaTecnicaProp.focus();
//            return false;
//        }
        
        
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
                            <asp:ImageButton ID="cmdSeguir" runat="server" 
                                ImageUrl="~/img/plantilla/next.png" 
                                ToolTip="Seguir"  onclick="cmdSeguir_Click" 
                                />
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
                                        B) PROCESO DE LICITACIÓN - Proceso de Publicación = En Licitación</td>
                                </tr>
                                <tr>
                                    <td>
                                        Responsable Licitación</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlResponsableLicitacion" runat="server" CssClass="content_small" 
                                            Height="16px" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td colspan="2">
                                        Ingresar Nº de llamado a licitación de este contrato</td>
                                    <td>
                                        <asp:DropDownList ID="ddlLlamado" runat="server" CssClass="content_small" 
                                            Height="16px" Width="130px">
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
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                            <asp:TextBox ID="txtNDoctoR5" runat="server" CssClass="content" Width="120px" Height="18px" MaxLength="6" Visible="False"></asp:TextBox>
                           <asp:TextBox ID="txtFechaDoctoR5" runat="server" CssClass="content" ReadOnly="True" Width="100px" Height="22px" Visible="False"></asp:TextBox>
                    
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
                                </tr>
                                <tr>
                                    <td>
                                        Presupuesto Oficial</td>
                                    <td>
                            <asp:TextBox ID="txtPresupuestoOficial" runat="server" CssClass="content" 
                                Width="145px" Height="18px" MaxLength="15"></asp:TextBox>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        Plazo Oficial</td>
                                    <td>
                                       <asp:TextBox ID="txtPlazoOficial" runat="server" CssClass="content" Width="52px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                        <asp:TextBox ID="txtNumResNoAdjudica" runat="server" CssClass="content" Width="52px" Height="18px" MaxLength="6" Visible="False"></asp:TextBox>
                                        <asp:TextBox ID="txtFechaResNoAdjudica" runat="server" CssClass="content" ReadOnly="True" Width="100px" Height="22px" Visible="False"></asp:TextBox>
                    
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

