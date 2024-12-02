<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_estado_pago_contrato.aspx.cs" Inherits="mn_ing_estado_pago_contrato" %>

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

        Calendario_txtFechaEstadoPago = new JsDatePick({
            useMode: 2,
            target: "txtFechaEstadoPago",
            dateFormat: "%d/%m/%Y"
        });

    } 

    function func_valida_nuevo() {

        if (document.frm_datos_contrato.ddlNumEstadoPago.value == "(NUEVO)") {
            alert("Debe seleccionar Estado Pago, para utilizar esta opción.");
            document.frm_datos_contrato.ddlNumEstadoPago.focus();
            return false;
        }

        return true;
    }

    function func_suma_replica() {

        document.frm_datos_contrato.lblVEPContratoMatriz.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtContratoMatriz.value));
        document.frm_datos_contrato.lblCAPContratoMatriz.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtContratoMatriz.value));

        document.frm_datos_contrato.lblVEPAumenoContrato.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtAumenoContrato.value));
        document.frm_datos_contrato.lblCAPAumenoContrato.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtAumenoContrato.value));

        document.frm_datos_contrato.lblVEPReajuste.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtReajuste.value));
        document.frm_datos_contrato.lblCAPReajuste.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtReajuste.value));

        document.frm_datos_contrato.lblVEPAnticipo.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtAnticipo.value));
        document.frm_datos_contrato.lblCAPAnticipo.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtAnticipo.value));

        document.frm_datos_contrato.lblVEPCanjeRetencion.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtCanjeRetencion.value));

        document.frm_datos_contrato.lblVEPDevolucionRetencion.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtDevolucionRetencion.value));

        document.frm_datos_contrato.lblCAPDevolucionAnticipo.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtDevolucionAnticipo.value));

        document.frm_datos_contrato.lblVEPReajusteDevolucionAnticipo.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtReajusteDevolucionAnticipo.value));
        document.frm_datos_contrato.lblCAPReajusteDevolucionAnticipo.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtReajusteDevolucionAnticipo.value));

        document.frm_datos_contrato.lblLiquidoPagar.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtContratoMatriz.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtAumenoContrato.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtReajuste.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtAnticipo.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtCanjeRetencion.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtDevolucionRetencion.value))
                            - parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtDevolucionAnticipo.value))
                            - parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtReajusteDevolucionAnticipo.value))
                            - parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtRetencion.value))
                            - parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtMulta.value))
                            - parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.txtImpuestoHonorarios.value));

        document.frm_datos_contrato.lblValorEstadoPago.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblVEPContratoMatriz.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblVEPAumenoContrato.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblVEPReajuste.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblVEPAnticipo.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblVEPCanjeRetencion.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblVEPDevolucionRetencion.value))                     
                            - parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblVEPReajusteDevolucionAnticipo.value));

        document.frm_datos_contrato.lblCargoAPresupuesto.value = parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblCAPContratoMatriz.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblCAPAumenoContrato.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblCAPReajuste.value))
                            + parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblCAPAnticipo.value))
                            - parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblCAPDevolucionAnticipo.value))
                            - parseFloat(FUNC_MontoSQLv2(document.frm_datos_contrato.lblCAPReajusteDevolucionAnticipo.value));

        document.frm_datos_contrato.lblLiquidoPagar.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblLiquidoPagar.value));

        document.frm_datos_contrato.lblValorEstadoPago.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblValorEstadoPago.value));

        document.frm_datos_contrato.lblCargoAPresupuesto.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblCargoAPresupuesto.value));

        document.frm_datos_contrato.lblVEPContratoMatriz.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblVEPContratoMatriz.value));
        document.frm_datos_contrato.lblCAPContratoMatriz.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblCAPContratoMatriz.value));

        document.frm_datos_contrato.lblVEPAumenoContrato.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblVEPAumenoContrato.value));
        document.frm_datos_contrato.lblCAPAumenoContrato.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblCAPAumenoContrato.value));

        document.frm_datos_contrato.lblVEPReajuste.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblVEPReajuste.value));
        document.frm_datos_contrato.lblCAPReajuste.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblCAPReajuste.value));

        document.frm_datos_contrato.lblVEPAnticipo.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblVEPAnticipo.value));
        document.frm_datos_contrato.lblCAPAnticipo.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblCAPAnticipo.value));

        document.frm_datos_contrato.lblVEPCanjeRetencion.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblVEPCanjeRetencion.value));

        document.frm_datos_contrato.lblVEPDevolucionRetencion.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblVEPDevolucionRetencion.value));

        document.frm_datos_contrato.lblCAPDevolucionAnticipo.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblCAPDevolucionAnticipo.value));

        document.frm_datos_contrato.lblVEPReajusteDevolucionAnticipo.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblVEPReajusteDevolucionAnticipo.value));
        document.frm_datos_contrato.lblCAPReajusteDevolucionAnticipo.value = FUNC_MontoASPv2(addCommas(document.frm_datos_contrato.lblCAPReajusteDevolucionAnticipo.value));
    
    }

    function func_valida_num_estado_pago() {
        if (document.frm_datos_contrato.ddlNumEstadoPago.value == "(NUEVO)") {
            alert("Debe seleccionar numero estado pago.");
            document.frm_datos_contrato.ddlNumEstadoPago.focus();
            return false;
        }
        else
            return true;
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

        if (document.frm_datos_contrato.ddlNumEstadoPago.value == "(NUEVO)") {
            alert("Debe ingresar seleccionar estado pago.");
            document.frm_datos_contrato.ddlNumEstadoPago.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtFechaEstadoPago.value == "") {
            alert("Debe ingresar numero fecha estado pago.");
            document.frm_datos_contrato.txtFechaEstadoPago.focus();
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

        /*
        if (document.frm_datos_contrato.ddlNumEstadoPago.value == "(NUEVO)") {
            alert("Debe ingresar seleccionar estado pago.");
            document.frm_datos_contrato.ddlNumEstadoPago.focus();
            return false;
        }*/

        if (document.frm_datos_contrato.txtFechaEstadoPago.value == "") {
            alert("Debe ingresar numero fecha estado pago.");
            document.frm_datos_contrato.txtFechaEstadoPago.focus();
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
                Estado de Pago del Contrato <div class="content_small">(Contrato-Estado Pago)</div></td>
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
                            <asp:ImageButton ID="cmdBuscaEstadoPago" runat="server" 
                                ImageUrl="~/img/plantilla/find.png" 
                                ToolTip="Busca Estado Pago" onclick="cmdBuscaEstadoPago_Click" 
                                OnClientClick="return func_valida_num_estado_pago();" />
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
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla ESTADO_PAGO" 
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
                                        <asp:Button ID="cmdCargoPresup" runat="server" CssClass="content" 
                                            onclick="cmdCargoPresup_Click" Text="Cargo Presupuesto" 
                                            onclientclick="return func_valida_nuevo();" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Estado de Pago</td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        Nº E.P.</td>
                                    <td valign="top">
                                        <asp:DropDownList ID="ddlNumEstadoPago" runat="server" CssClass="content" 
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlNumEstadoPago_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td valign="top">
                                        Fecha                             <asp:TextBox ID="txtFechaEstadoPago" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td >
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
                                    <td class="borde_celda_small" style=" text-align:left;">
                                        Liquido a Pagar</td>
                                    <td class="borde_celda_small" style=" text-align:right;">
                                        Valor Estado Pago</td>
                                    <td class="borde_celda_small" style=" text-align:right;">
                                        Cargo a Presupuesto</td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="borde_celda_small" style=" text-align:left;">
                            <asp:TextBox ID="lblLiquidoPagar" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td class="borde_celda_small" style=" text-align:right;">
                            <asp:TextBox ID="lblValorEstadoPago" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td class="borde_celda_small" style=" text-align:right;">
                            <asp:TextBox ID="lblCargoAPresupuesto" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Contrato Matriz</td>
                                    <td>
                            <asp:TextBox ID="txtContratoMatriz" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" ></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblVEPContratoMatriz" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblCAPContratoMatriz" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Aumeno del Contrato</td>
                                    <td>
                            <asp:TextBox ID="txtAumenoContrato" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblVEPAumenoContrato" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblCAPAumenoContrato" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Reajuste</td>
                                    <td>
                            <asp:TextBox ID="txtReajuste" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblVEPReajuste" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblCAPReajuste" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Anticipo</td>
                                    <td>
                            <asp:TextBox ID="txtAnticipo" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblVEPAnticipo" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblCAPAnticipo" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Canje Retención</td>
                                    <td>
                            <asp:TextBox ID="txtCanjeRetencion" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblVEPCanjeRetencion" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Devolución Retención</td>
                                    <td>
                            <asp:TextBox ID="txtDevolucionRetencion" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblVEPDevolucionRetencion" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Devolución Anticipo</td>
                                    <td>
                            <asp:TextBox ID="txtDevolucionAnticipo" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblCAPDevolucionAnticipo" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Reajuste devolución Anticipo</td>
                                    <td>
                            <asp:TextBox ID="txtReajusteDevolucionAnticipo" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblVEPReajusteDevolucionAnticipo" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                    <td style=" text-align:right;">
                            <asp:TextBox ID="lblCAPReajusteDevolucionAnticipo" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();" 
                                            BorderStyle="None" ReadOnly="True" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Retención</td>
                                    <td>
                            <asp:TextBox ID="txtRetencion" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Multa</td>
                                    <td>
                            <asp:TextBox ID="txtMulta" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Impuesto 10% Honorarios</td>
                                    <td>
                            <asp:TextBox ID="txtImpuestoHonorarios" runat="server" CssClass="content" style = "text-align:right"
                                Width="70%" Height="20px" OnChange="javascript: func_suma_replica();"></asp:TextBox>
                                    </td>
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
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label ID="lblCorreo" runat="server" CssClass="content"></asp:Label><strong>GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
</div>

</form>

</body>
</html>
