<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_edi_proyectos.aspx.cs" Inherits="mn_edi_proyectos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="all" href="../css/jquery-ui.css" />
   <script type="text/javascript" src="../js/jquery-1.12.4.js"></script>
   <script type="text/javascript" src="../js/jquery-ui.js"></script>
   <script type="text/javascript" src="../js/jquery.ui.datepicker-es.js"></script>

    <script language="jscript" type="text/jscript" src="../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
   

    
    window.onload = function() {

        
        $(function () {
            $("#txtFechaHito").datepicker({

                changeYear: true,
                changeMonth: true
            });
        });

        $(function () {
            $("#txtFechaTerminoProyecto").datepicker({
                changeYear: true,
                changeMonth: true
            });
        });

        $(function () {
            $("#txtFechaLiquidacionProyecto").datepicker({
                changeYear: true,
                changeMonth: true
            });
        });

        $(function () {
            $("#txtFechaOficioApoyo").datepicker({
                changeYear: true,
                changeMonth: true
            });
        });

        $(function () {
            $("#txtTerritorioFechaCerificado").datepicker({
                changeYear: true,
                changeMonth: true
            });
        });

        $(function () {
            $("#txtFechaEstimadaFirmaConvenio").datepicker({
                changeYear: true,
                changeMonth: true
            });
        });

        $(function () {
            $("#txtFechaEstimadaPublicacion").datepicker({
                changeYear: true,
                changeMonth: true
            });
        });

        $(function () {
            $("#txtFechaEstimadaInicio").datepicker({
                changeYear: true,
                changeMonth: true
            });
        });

        $(function () {
            $("#txtFechaEstimadaTermino").datepicker({
                changeYear: true,
                changeMonth: true
            });
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

        if (confirm("¿Seguro que desea eliminar el proyecto?"))
            return true;
        else
            return false;
    }
    
    
    function cmdConexionExploValida_Click() {
        if (document.frm_datos_contrato.txtCodigoBIP.value == "") {
            alert("Debe ingresar Codigo BIP.");
            document.frm_datos_contrato.txtCodigoBIP.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlEtapaIdea.value == "(SELECCIONAR)") {
            alert("Debe seleccionar una etapa actual de la IDEA");
            document.frm_datos_contrato.ddlEtapaIdea.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtCodigoExploratorio.value == "") {
            alert("Proyecto ya posee Código Proyecto Exploratorio, no se puede obtener otro.");
            return false;
        }

        return true;
    }
    
    function cmdModuloPatrimonioClient_Click() {

        if (document.frm_datos_contrato.txtCodigoExploratorio.value == "") {
            alert("Debe ingresar codigo proyecto exploratorio.");
            document.frm_datos_contrato.txtCodigoExploratorio.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtCodigoBIP.value == "") {
            alert("Debe ingresar codigo BIP.");
            document.frm_datos_contrato.txtCodigoBIP.focus();
            return false;
        }

        return true;
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
        
        
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;

    }

    
</script>    

    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            height: 20px;
        }
        .style3
        {
            width: 93px;
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
            <td class="style3">
                &nbsp;</td>
            <td class="title">
                Detalle Proyecto <div class="content_small">(Proyecto)</div></td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 90%">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Grabar Proyecto" onclick="cmdGrabar_Click" OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Eliminar Proyecto" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla Proyecto" Visible="False"></asp:Label>
                            <asp:HiddenField ID="hddEstado" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="borde_celda" colspan="2">
                            Datos del Proyecto</td>
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
                        &nbsp;Tipo
                            <asp:TextBox ID="txtTipoProyecto" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                        &nbsp;Código Exploratorio
                            <asp:TextBox ID="txtCodigoExploratorio" runat="server" CssClass="content" ReadOnly="True" 
                                Width="124px" Height="18px"></asp:TextBox>   
                        </td>
                    </tr>
                    <tr>
                        <td></td>

                        <td class="style2">
                           Numero of. Solicitud apoyo técnico
                            <asp:TextBox ID="txtOficioApoyo" runat="server" CssClass="content" Width="94px"></asp:TextBox>
                              
                       
                       <asp:TextBox ID="txtFechaOficioApoyo" runat="server" CssClass="content" Width="100px"></asp:TextBox>
                       </td>
    
                           <!-- <asp:TextBox ID="txtCodigoPRIGRH" runat="server" CssClass="content"
                                Width="124px" Height="18px" Visible="False"></asp:TextBox></td>
                               -->
                    </tr>

                    </table>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td style="width: 933px;">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td style="width: 933px;">
                            <table class="style1">
                                <tr>
                                    <td class="borde_celda" colspan="4">
                                        Identificación del Proyecto</td>
                                </tr>
                                <tr>
                                    <td style="width: 20%;" class="content">
                                        Plan o programa asociado</td>
                                    <td style="width: 30%;" class="content">
                                        <asp:DropDownList ID="ddlPlan" runat="server" CssClass="content" 
                                            Height="21px" Width="160px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20%;" class="content">
                                        Proyecto con seguimiento</td>
                                    <td style="width: 30%;" class="content">
                                        <asp:DropDownList ID="ddlSeguimiento" runat="server" CssClass="content" 
                                            Height="21px" Width="160px">
                                        </asp:DropDownList>
                                      
            

                                         <asp:Button ID="cmdMandantes" runat="server" Text="Mandantes" 
                                            Width="200px" CssClass="content" 
                                             Font-Strikeout="False" onclick="cmdMandantes_Click" 
                                            Height="30px" />



                                    </td>



                                </tr>
                                <tr>
                                    <td class="content">
                                        </td>
                                    <td class="content">
                                        <asp:TextBox ID="txtFechaHito" runat="server" CssClass="content" Width="100px" Visible="False"></asp:TextBox>
                                     
                                    </td>
                                    <td class="content">
                                        Estado Proyecto</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlEstadoProyecto" runat="server" CssClass="content" 
                                            Height="21px" Width="160px" BackColor="#FFFF99">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        B.I.P.</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtCodigoBIP" runat="server" CssClass="content" Width="94px" 
                                            BackColor="#FFFF99"></asp:TextBox>
                                        &nbsp;-
                                        <asp:TextBox ID="txtDVBIP" runat="server" Width="44px" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        </td>
                                    <td class="content">
                                        <asp:TextBox ID="txtFechaTerminoProyecto" runat="server" CssClass="content" Width="100px" Visible="False"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        </td>
                                    <td class="content">

                                        <asp:TextBox ID="txtFechaLiquidacionProyecto" runat="server" CssClass="content" Width="100px" Visible="False"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content" colspan="2">
                                        Seleccione etapa actual de la IDEA</td>
                                    <td class="content" colspan="2">
                                        <asp:DropDownList ID="ddlEtapaIdea" runat="server" CssClass="content" 
                                            Height="21px" Width="40%">
                                        </asp:DropDownList>
                                    &nbsp;&nbsp;<asp:Button ID="cmdProgramacionIDEA" runat="server" Text="Progrmación por año Ideas" 
                                            Width="200px" CssClass="content" 
                                             Font-Strikeout="False" onclick="cmdProgramacionIDEA_Click" 
                                            Height="30px" />
                                        </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                   <td class="content" colspan="2">
                                        Diseño pasivo y EE:
                                    </td>
                                    <td class="content" colspan="2">
                                        <asp:DropDownList ID="ddlCes" runat="server" CssClass="content" 
                                            Height="21px" Width="40%">
                                        </asp:DropDownList>
                                    </td>    
                                    
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">    
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content" colspan="2">
                                        Seleccione Profesional encargado de la gestión de la IDEA</td>
                                    <td class="content" colspan="2">
                                        <asp:DropDownList ID="ddlResponsableIdea" runat="server" CssClass="content" 
                                            Height="21px" Width="400px">
                                        </asp:DropDownList>
                                    &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Fecha Estimada Firma Convenio</td>
                                    <td class="content">

                                            <asp:TextBox ID="txtFechaEstimadaFirmaConvenio" runat="server" CssClass="content" Width="100px"></asp:TextBox>

                                        
                                    </td>
                                    <td class="content">
                                        Fecha Estimada Publicación</td>
                                    <td class="content">

                                            <asp:TextBox ID="txtFechaEstimadaPublicacion" runat="server" CssClass="content" Width="100px"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Fecha Estimada Inicio</td>
                                    <td class="content">

                                            <asp:TextBox ID="txtFechaEstimadaInicio" runat="server" CssClass="content" Width="100px"></asp:TextBox>
                                        
                                    </td>
                                    <td class="content">
                                        Fecha Estimada Termino</td>
                                    <td class="content">

                                            <asp:TextBox ID="txtFechaEstimadaTermino" runat="server" CssClass="content" Width="100px"></asp:TextBox>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content" colspan="2">
                                        Seleccione Profesional encargado de gestionar el convenio</td>
                                    <td class="content" colspan="2">
                                        <asp:DropDownList ID="ddlResponsableConvenio" runat="server" CssClass="content" 
                                            Height="21px" Width="400px">
                                        </asp:DropDownList>
                                        &nbsp;<asp:Button ID="cmdEtapas" runat="server" Text="Etapa" 
                                            Width="200px" CssClass="content" 
                                             Font-Strikeout="False" onclick="cmdEtapas_Click" 
                                            Height="30px" />
                                    </td>   
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content" colspan="2">
                                        Of. Solicitud Apoyo Técnico</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <table  style=" width:100%; " >
                                <tr>
                                    <td class="borde_celda" colspan="4">
                                        Clasificación del Proyecto</td>
                                </tr>
                                <tr>
                                    <td style="width: 20%;" class="content">
                                        Sector Destino</td>
                                    <td style="width: 30%;" class="content">
                                        <asp:DropDownList ID="ddlSectorDestino" runat="server" CssClass="content" 
                                            Height="21px" Width="60%" AutoPostBack="True" 
                                            onselectedindexchanged="ddlSectorDestino_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 20%;" class="content">
                                        Sub Sector</td>
                                    <td style="width: 30%;" class="content">
                                        <asp:DropDownList ID="ddlSubSector" runat="server" CssClass="content" 
                                            Height="21px" Width="60%" AutoPostBack="True"
                                            onselectedindexchanged="ddlSubSector_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Provincia <div class="content_small">(Exploratorio)</div></td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="content" 
                                            Height="21px" Width="60%" AutoPostBack="True" 
                                            onselectedindexchanged="ddlProvincia_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        Financiamiento<br />
                                        Principal</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlFondo" runat="server" CssClass="content" 
                                            Height="21px" Width="90%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Comuna <div class="content_small">(Exploratorio)</div></td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlComuna" runat="server" CssClass="content" 
                                            Height="21px" Width="60%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        Multiples
                                        Financiamientos</td>
                                    <td class="content">
                                       <asp:Button ID="cmdFinanciamientos" runat="server" Text="Financiamientos" 
                                            Width="200px" CssClass="content" 
                                             Font-Strikeout="False" onclick=" cmdFinanciamientos_Click" 
                                            Height="30px" />
                                   </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Proceso <div class="content_small">(Exploratorio)</div></td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlProceso" runat="server" CssClass="content" 
                                            Height="21px" Width="60%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        Modalidad Contratación
                                    </td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlMoContratacionP" runat="server">
                                        </asp:DropDownList>
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Tipo Edificio</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlTipologia" runat="server" CssClass="content" 
                                            Height="21px" Width="60%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        Tipo de Reajuste
                                     </td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlTipoReajusteP" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        M2</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtProgramaFinal" runat="server" CssClass="content" 
                                            Width="94px"></asp:TextBox>
                                        </td>
                                    <td class="content">
                                        Rate</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlRate" runat="server" CssClass="content" 
                                            Height="21px" Width="60%">
                                        </asp:DropDownList>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Objeto <div class="content_small">(Exploratorio)</div></td>
                                    <td class="content">
                                        <asp:TextBox ID="txtObjeto" runat="server" CssClass="content" Width="95%" 
                                            Height="90px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    <td class="content">
                                        Descripción</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="content" Width="95%" 
                                            Height="90px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <table style=" width:100%; " >
                                <tr>
                                    <td class="borde_celda" colspan="4">
                                        Datos Complementarios</td>
                                    <td class="borde_celda">
                                        Observaciones</td>
                                </tr>
                                <tr>
                                    <td style="width: 20%;" class="content">
                                        Usuarios</td>
                                    <td style="width: 20%;" class="content">
                                        <asp:TextBox ID="txtUsuarios" runat="server" Width="70px" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td style="width: 20%;" class="content">
                                        &nbsp;</td>
                                    <td style="width: 20%;" class="content">
                                        &nbsp;</td>
                                    <td style="width: 20%;" class="content" rowspan="7">
                                        <asp:TextBox ID="txtObservaciones" runat="server" Height="100px" 
                                            TextMode="MultiLine" Width="97%" CssClass="content"></asp:TextBox>
                                        <br />
                                        <asp:CheckBox ID="chkObrasComplementarias" runat="server" 
                                            Text="Obras Complementarias"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Beneficiarios</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtBeneficiarios" runat="server" Width="70px" 
                                            CssClass="content"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Factibilidades</td>
                                    <td class="content">
                                        <asp:CheckBox ID="chkFactElectrica" runat="server" Text="Eléctrica"/>
                                     </td>
                                    <td class="content">
                                        <asp:CheckBox ID="chkFactAgua" runat="server" Text="Agua"/>
                                     </td>
                                    <td class="content">
                                        <asp:CheckBox ID="chkFactAlcantarillado" runat="server" Text="Alcantarillado"/>
                                     </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content" colspan="2">
                                        Datos del Terreno</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        N° Certificado</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtTerritorioNumeroCert" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        Fecha</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtTerritorioFechaCerificado" runat="server" Width="100px" 
                                            CssClass="content"></asp:TextBox>
                                        <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        Propiedad</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlPropiedad" runat="server" CssClass="content" 
                                            Height="21px" Width="160px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        Superficie M2</td>
                                    <td class="content">
                                        <asp:TextBox ID="txtSuperficie" runat="server" CssClass="content"></asp:TextBox>
                                    </td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content" colspan="2" align="right">
                                        Antecedentes Previos municipales</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlCondicionesTecnicas" runat="server" CssClass="content" 
                                            Height="21px" Width="160px">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="content">
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <table class="style1">
                                <tr>
                                    <td width="33%">
                                        &nbsp;</td>
                                    <td width="33%">
                                        &nbsp;</td>
                                    <td width="33%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3"  class="borde_celda" >
                                        Conexión Exploratorio / Ingreso convenios</td>
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
                                        <asp:Button ID="cmdConexionExplo" runat="server" CssClass="content" 
                                            onclick="cmdConexionExplo_Click" Text="Obtener Codigo Exploratorio" 
                                            OnClientClick = "cmdConexionExploValida_Click"
                                            Width="200px" Height ="30px"/>
                                         <asp:Button ID="cmdConveniosMandantes" runat="server" Text="Convenios Mandantes" 
                                            Width="200px" CssClass="content" 
                                            Font-Strikeout="False" onclick="cmdConveniosMandantes_Click" 
                                            Height="30px" />
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
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align:center;">
                                        <asp:Label ID="lblMSGExplo" runat="server" CssClass="borde_celda" Width="90%"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table style="width:100%;">
                                <tr>
                                    <td style="width:50%;">
                                        &nbsp;</td>
                                    <td style="width:50%;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    
                                    <td align="center">
                                        <asp:Button ID="cmdModuloPatrimonio" runat="server" Text="Modulo Patrimonio"
                                            Width="200px" CssClass="content" OnClientClick="return cmdModuloPatrimonioClient_Click();"
                                            Font-Strikeout="False" OnClick="cmdModuloPatrimonio_Click" Height="30px" Visible="False" />
                                    </td>
                                </tr>
                                <tr>
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
                                </tr>
                            </table>
                            <br />
            </td>
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
