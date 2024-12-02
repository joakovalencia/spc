<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_patrimonio.aspx.cs" Inherits="mn_mnt_patrimonio" %>

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


    function func_calcula_Dias()
    {   
                
    }

    function func_valida_imprimir() {

        if (document.frm_mn_mnt_patrimonio.txtCodigo_proyecto.value == "") {
            alert("Debe ingresar Código Proyecto Exploratorio.");
            document.frm_mn_mnt_patrimonio.txtCodigo_proyecto.focus();
            return false;
        }

        if (document.frm_mn_mnt_patrimonio.hddExisteContrato.value == "N" || document.frm_mn_mnt_patrimonio.hddExisteContrato.value == "") {
            alert("Este proyecto no tiene contratos asociados, no se puede imprimir Ficha Patrimonio.");            
            return false;
        }

        document.URL.tar

    }
    
    function func_valida_grabar() 
    {
        
		if (document.frm_mn_mnt_patrimonio.txtActualizacion_data_p.value == "") 
        {
            alert("Debe ingresar Fecha De Actualización.");
            document.frm_mn_mnt_patrimonio.txtActualizacion_data_p.focus();
            return false;
        }       
                
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;

        return true;
    }

    window.onload = function() {
        Calendario_txtRev_anteproy_cmn_recepcion = new JsDatePick({
            useMode: 2,
            target: "txtRev_anteproy_cmn_recepcion",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtActualizacion_data_p = new JsDatePick({
            useMode: 2,
            target: "txtActualizacion_data_p",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtRev_anteproy_cmn_envio = new JsDatePick({
            useMode: 2,
            target: "txtRev_anteproy_cmn_envio",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtRev_proy_cmn_envio = new JsDatePick({
            useMode: 2,
            target: "txtRev_proy_cmn_envio",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txttxtRev_minvu_envio = new JsDatePick({
            useMode: 2,
            target: "txtRev_minvu_envio",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtRev_dom_envio = new JsDatePick({
            useMode: 2,
            target: "txtRev_dom_envio",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtRev_otra_envio = new JsDatePick({
            useMode: 2,
            target: "txtRev_otra_envio",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtRev_proy_cmn_recepcion = new JsDatePick({
            useMode: 2,
            target: "txtRev_proy_cmn_recepcion",
            dateFormat: "%d/%m/%Y"
        });
        Calendario_txtRev_dom_recepcion = new JsDatePick({
            useMode: 2,
            target: "txtRev_dom_recepcion",
            dateFormat: "%d/%m/%Y"
        });
        Calendario_txtRev_sea_recepcion = new JsDatePick({
            useMode: 2,
            target: "txtRev_sea_recepcion",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtRev_minvu_recepcion = new JsDatePick({
            useMode: 2,
            target: "txtRev_minvu_recepcion",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtRev_otra_recepcionas = new JsDatePick({
            useMode: 2,
            target: "txtRev_otra_recepcionas",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtRev_sea_envio = new JsDatePick({
            useMode: 2,
            target: "txtRev_sea_envio",
            dateFormat: "%d/%m/%Y"
        });       
		
    }
    
   

</script>    
      
    </head>
<body>

<form id="frm_mn_mnt_patrimonio" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">
<script type="text/javascript">
    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return ((tecla > 47 && tecla < 58) || tecla == 46);
    }
</script>

<script type="text/javascript">
     <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return true;

        return false;
    }
     //-->
  </script>
    <br />   
	<table style="width:100%;">
        <tr>
            <td class="content">
                </td>
            <td class="title">
                Ficha Identificación de Proyectos de Patrimonio</td>
        </tr>
        <tr>
            <td class="content">
                &nbsp;</td>
            <td class="content">
                <table style="WIDTH: 643px">
                    <tr>
                        <td>
                            <asp:ImageButton ID="cmdGabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" onclick="cmdGabar_Click" 
                                OnClientClick ="return func_valida_grabar();" 
                                ToolTip="Grabar Ficha Patrimonio" />
                            <asp:ImageButton ID="cmdImprimir" runat="server" 
                                ImageUrl="~/img/plantilla/print.png" onclick="cmdImprimir_Click" 
                                ToolTip="Reporte Ficha Patrimonio" />
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" ToolTip="Salir" />
                            <asp:HiddenField ID="hddCodigoContrato" runat="server" />
                            <asp:HiddenField ID="hddSufijo" runat="server" />
                            <asp:HiddenField ID="hddExisteContrato" runat="server" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td class="content">
                &nbsp;</td>
            <td class="content">
                            &nbsp;<table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%" >
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6" class="borde_celda">
                                        Identificacion del proyecto</td>
                                </tr>
                                <tr>
                                    <td>
                                        Región</td>
                                    <td>
                            <asp:TextBox ID="txtRegion" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="22px"></asp:TextBox>
                                    </td>
                                    <td>
                                        PIA</td>
                                    <td>
                            <asp:TextBox ID="txtPIA" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="22px"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Código Proyecto (Exploratorio)</td>
                                    <td>
                                        <asp:TextBox ID="txtCodigo_proyecto" runat="server" ReadOnly =true Width="90%" Height="22px"
                                            CssClass="content" ></asp:TextBox>
                                    </td>
                                    <td>
                                        Actualización de Datos</td>
                                    <td>
                                        <asp:TextBox ID="txtActualizacion_data_p" ReadOnly="true" runat="server" Height="22px"
                                            Width="100px" CssClass="content" ImageUrl="~/img/plantilla/calendar.gif"></asp:TextBox>
                    <asp:Image ID="Image13" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td colspan="2">
                                        Autor Ficha
                                        <asp:DropDownList ID="ddlInsFiscales" runat="server" Height="22px" 
                                            Width="65%" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Usos Actuales</td>
                                    <td>
                                        <asp:Button ID="cmdUso_actual" runat="server" Text="Usos Actuales" 
                                            Width="90%" 
                                            OnClienClik= "JavaScript:document.frm_mn_mnt_patrimonio.target ='_blank'; " 
                                            onclick="cmdUso_actual_Click" CssClass="content" Height="30px" />
                                    </td>
                                    <td>
                                        Nombre Proyecto </td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtNombreProyecto" runat="server" Width="95%" 
                                            ReadOnly="True" Height="20px" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Código BIP</td>
                                    <td>
                                        <asp:TextBox ID="txtBip" runat="server" ReadOnly="True" Width="95%" 
                                            CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        Financiamiento</td>
                                    <td>
                                        <asp:Button ID="cmdfinanciamiento" runat="server" Text="Financiamiento" 
                                            Width="125px" 
                                            OnClienClik= "JavaScript:document.frm_mn_mnt_patrimonio.target ='_blank'; " 
                                            onclick="cmdfinanciamiento_Click" CssClass="content" Height="30px"/>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Ubicación                                         <br />
                                        (U o R)</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTipo_ubicacion" runat="server" Height="22px" 
                                            Width="95%" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        RATE</td>
                                    <td>
                                        <asp:DropDownList ID="ddlRATE" runat="server" Height="22px" 
                                            Width="65%" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
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
                            &nbsp;<br />
                            <table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6"  class="borde_celda" >
                                        Coordenadas Geograficas del Proyecto</td>
                                </tr>
                                <tr>
                                    <td>
                                        Latitud Coordenada</td>
                                    <td>
                                        <asp:TextBox ID="txtLatitud_coordenada" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        Longitud Coordenada</td>
                                    <td>
                                        <asp:TextBox ID="txtLongitud_coordenada" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        UTM X</td>
                                    <td>
                                        <asp:TextBox ID="txtUtm_x" runat="server" onkeypress = "return ValidNum(event)" 
                                            CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Latitud Grados</td>
                                    <td>
                                        <asp:TextBox ID="txtLatitud_grados" runat="server" 
                                            onkeypress = "return ValidNum(event)" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        Longitud Grados</td>
                                    <td>
                                        <asp:TextBox ID="txtLongitud_grados" runat="server" 
                                            onkeypress = "return ValidNum(event)" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        UTM Y</td>
                                    <td>
                                        <asp:TextBox ID="txtUtm_y" runat="server" onkeypress = "return ValidNum(event)" 
                                            CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Latitud Minutos</td>
                                    <td>
                                        <asp:TextBox ID="txtLatitud_minutos" runat="server" 
                                            onkeypress = "return ValidNum(event)" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        Longitud Minutos</td>
                                    <td>
                                        <asp:TextBox ID="txtLongitud_minutos" runat="server" 
                                            onkeypress = "return ValidNum(event)" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        UTM USO</td>
                                    <td>
                                        <asp:TextBox ID="txtUtm_uso" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Latitud Segundos</td>
                                    <td>
                                        <asp:TextBox ID="txtLatitud_segundos" runat="server" 
                                            onkeypress = "return ValidNum(event)" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        Longitud Segundos</td>
                                    <td>
                                        <asp:TextBox ID="txtLongitud_segundos" runat="server" 
                                            onkeypress = "return ValidNum(event)" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br/>
                            <table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6"  class="borde_celda" >
                                        Propiedad Y Administración</td>
                                </tr>
                                <tr>
                                    <td>
                                        Propietario</td>
                                    <td>
                                        <asp:TextBox ID="txtPropietario" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        Administrador</td>
                                    <td>
                                        <asp:TextBox ID="txtAdministrador" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td>
                                        Figura Legal </td>
                                    <td>
                                    <asp:DropDownList ID="txtFigura_legal" runat="server" Height="22px" 
                                            Width="90%" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Uso Historico: Idem Categoria de Uso</td>
                                    <td>
                                        <asp:Button ID="cmdUso_historico" runat="server" Text="Usos Historicos" 
                                            Width="120px" CssClass="content"
                                            OnClienClik= "JavaScript:document.frm_mn_mnt_patrimonio.target ='_blank'; " 
                                            onclick="cmdUso_historico_Click" Height="30px" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Cuenta con modelo de gestión S/N?</td>
                                    <td>
                                    <asp:DropDownList ID="ddlModelo_gestion" runat="server" Height="22px" 
                                            Width="65%" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                </table>
                            <br/>
                            <table class="content" width="98%">
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="7"  class="borde_celda" >
                                        Protección Legal Inmueble Patrimonial </td>
                                </tr>
                                <tr>
                                    <td class="content" colspan="3">
                                        Ley N° 17.288 Monumento Nacional</td>
                                    <td class="content">
                                        <asp:Button ID="cmdMonumentos" runat="server" Text="Monumentos" Width="109px" CssClass="content"
                                            OnClienClik= "JavaScript:document.frm_mn_mnt_patrimonio.target ='_blank'; " 
                                            onclick="cmdMonumentos_Click" Height="30px" />
                                        </td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content" colspan="3">
                                        </td>
                                    <td class="content">
                                        </td>
                                    <td class="content">
                                        </td>
                                    <td class="content">
                                        </td>
                                    <td class="content">
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="7" class="borde_celda">
                                        Ley General de Urbanismo y Construcción Artículo 60</tr>
                                <tr>
                                    <td class="content" colspan="3">
                                        <asp:CheckBox ID="chbInmuebleConservacion" runat="server" 
                                            Text="Inmueble de Conservación Histórica" />
                                    </td>
                                    <td class="content" colspan="3">
                                        <asp:CheckBox ID="chbInmuebleHistorica" runat="server" 
                                            Text="Zona de Conservación Histórica" />
                                    </td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            
                            <br />
                            <table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="borde_celda" colspan="6">
                                        Tipo Proyecto</td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Proyecto</td>
                                    <td>
                                        <asp:Button ID="btnProcesosPatrimoniales" runat="server" CssClass="content"
                                            Text="Procesos Patrimoniales" Width="161px" 
                                            OnClienClik= "JavaScript:document.frm_mn_mnt_patrimonio.target ='_blank'; " 
                                            onclick="btnProcesosPatrimoniales_Click" Height="30px"/>
                                    </td>
                                    <td class="content">
                                        <asp:CheckBox ID="chbComponenteArqueologico" runat="server" 
                                            Text="Componente Arqueológico" />
                                    </td>
                                    <td class="content">
                                        <asp:CheckBox ID="chbComponenteAmbiental" runat="server" Text="Componente Ambiental" />
                                    </td>
                                    <td class="content">
                                        Complemento Ambiental</td>
                                    <td>
                                        <asp:Button ID="cmdComplementoAmbiental" runat="server" CssClass="content"
                                            Text="Complementos" Width="161px" 
                                            OnClienClik= "JavaScript:document.frm_mn_mnt_patrimonio.target ='_blank'; " 
                                             Height="30px" onclick="cmdComplementoAmbiental_Click"/>
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
                                </table>
                            <br />
                            <table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="borde_celda" colspan="6">
                                        Superficies Inmueble</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Superficie Inmueble Patrimonial</td>
                                    <td>
                                        <asp:Button ID="cmdSuperficie" runat="server" Text="Superficie" Width="127px" CssClass="content"
                                            OnClienClik= "JavaScript:document.frm_mn_mnt_patrimonio.target ='_blank'; " 
                                            onclick="cmdSuperficie_Click" Height="30px"/>
                                    </td>
                                    <td colspan="2">
                                        Superficie Espacio Exterior (Patios, Parques,etc)</td>
                                    <td>
                                        <asp:TextBox ID="txtOtras_superficies" runat="server" onkeypress = "return ValidNum(event)" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td colspan="2">
                                        Superficie Terreno (Total)</td>
                                    <td>
                                        <asp:TextBox ID="txtSuperficieTotal" runat="server" 
                                            onkeypress = "return ValidNum(event)" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                </table>
                                <br />
                            <table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="borde_celda" colspan="6">
                                        Diagnostico y Proyecto de Intervencion</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Antecedentes Historicós</td>
                                    <td colspan="2">
                                        Estado de Conservacion Actual</td>
                                    <td colspan="2">
                                        Principales valores asociados al Monumento, Culturales, Sociales, Urbanos, 
                                        Paisajes...</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtAntecedentes_historicos" runat="server" Height="108px" CssClass="content"
                                            Width="95%" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtEstado_conservacion_actual" runat="server" Height="108px" CssClass="content" 
                                            Width="95%" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtPrincipales_valores" runat="server" Height="108px" 
                                            Width="95%" CssClass="content" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td colspan="2">
                                        El Proyecto de Intervención</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtProyecto_intervencion" runat="server" Height="108px" CssClass="content"
                                            Width="95%" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="borde_celda" colspan="6">
                                        Caracteristicas Constructivas y Acabados</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        Sistema constructivo predominante con proyecto de Restauración</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlSCPredomPR" runat="server" Height="22px" 
                                            Width="65%" CssClass="content">
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
                                    <td colspan="3">
                                        Sistema constructivo predominante Obra nueva</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlSCPredomON" runat="server" Height="22px" 
                                            Width="65%" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        &nbsp;</td>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        Principales caracteristicas constructivas y de acabado.<br />
                                        <asp:TextBox ID="txtDesc_conts_acabado" runat="server" Width="90%" 
                                            CssClass="content" Height="69px" MaxLength="400" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="borde_celda" colspan="6">
                                        Componente(s) del Proyecto a Destacar</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        Componentes Destacados</td>
                                    <td colspan="3">
                                        <asp:Button ID="cmdComponentesDestacados" runat="server" 
                                            Text="Componentes Destacados" CssClass="content"
                                            Width="242px" 
                                            OnClienClik= "JavaScript:document.frm_mn_mnt_patrimonio.target ='_blank'; " 
                                            onclick="cmdComponentesDestacados_Click" Height="32px"/>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="content">
Breve descripcion(es) de opcion(es) marcada(s)<br />
                                        <asp:TextBox ID="txtDescripcion_componentes" runat="server" Width="90%" 
                                            CssClass="content" Height="69px" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        </td>
                                    <td class="content">
                                        </td>
                                    <td class="content">
                                        </td>
                                </tr>
                                </table>
                            <br />
                            <table class="content" width="98%">
                                <tr>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                    <td width="15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="borde_celda" colspan="6">
                                        Revisión <div class="content_small"> (para ver dias revisión, debe grabar primero)</div>
                                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        Envio a Revisión de Anteproyecto CMN</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_anteproy_cmn_envio" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();" onmouseover="javascript: func_calcula_Dias()"></asp:TextBox>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Recepción Revisión de Anteproyecto CMN</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_anteproy_cmn_recepcion" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();" onmouseover="javascript: func_calcula_Dias()"></asp:TextBox>
                                            <asp:Image ID="Image7" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Dias Revisión</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasRevision" ReadOnly="true" runat="server" 
                                            CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Envio a Revisión de Proyecto CMN</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_proy_cmn_envio" ReadOnly="true"  runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Recepción Revisión de proyecto CMN</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_proy_cmn_recepcion" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image8" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Dias Revisión</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasRevisionCMN" ReadOnly="true" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Envio a Revisión DOM</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_dom_envio" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Recepción Revisión DOM</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_dom_recepcion" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image9" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Dias Revisión</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasRevisionDOM" ReadOnly="true" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Envio a Revisión SEA</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_sea_envio" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Recepción Revisión SEA</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_sea_recepcion" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image10" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Dias Revisión</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasRevisionSEA" ReadOnly="true" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Envio a Revisión MINVU</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_minvu_envio" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Recepción Revisión MINVU</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_minvu_recepcion" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image11" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Dias Revisión</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasRevisionMINVU" ReadOnly="true" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Envio a Revisión OTRA</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_otra_envio" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();"></asp:TextBox>
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Recepción Revisión OTRA</td>
                                    <td>
                                        <asp:TextBox ID="txtRev_otra_recepcionas" ReadOnly="true" runat="server" 
                                            CssClass="content" Width="100px" onblur="javascript: func_calcula_Dias();" 
                                            ></asp:TextBox>
                    <asp:Image ID="Image12" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                    <td>
                                        Dias Revisión</td>
                                    <td>
                                        <asp:TextBox ID="txtDiasRevisionOTRA" ReadOnly="true" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br/>  
                                                      
                            
            </td>
        </tr>
        <tr>
            <td class="content">
                </td>
            <td class="borde_celda">
                Conexión SSD</td>
        </tr>
        <tr>
            <td class="content">
                &nbsp;</td>
            <td class="content"  align="center">
                <asp:ImageButton ID="cmdObtenerDocSSD" runat="server" 
                                ImageUrl="~/img/plantilla/download.png" 
                                ToolTip="Descargar documentos desde SSD" onclick="cmdObtenerDocSSD_Click" />
    
            </td>
        </tr>
        <tr>
            <td class="content">
                &nbsp;</td>
            <td class="content">
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
