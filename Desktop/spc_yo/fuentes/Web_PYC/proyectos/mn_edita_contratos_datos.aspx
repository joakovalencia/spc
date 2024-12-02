<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_edita_contratos_datos.aspx.cs" Inherits="mn_edita_contratos_datos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" type="text/css" media="all" href="../js/reloj/jsDatePick_ltr.min.css" />
        
    <script type="text/javascript" src="../js/reloj/jquery.1.4.2.js"></script>
    <script type="text/javascript" src="../js/reloj/jsDatePick.jquery.min.1.3.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
    <!--

    window.onload = function() {

        Calendario_txtFechaLicitacion = new JsDatePick({
            useMode: 2,            
            target: "txtFechaLicitacion",
            dateFormat: "%d/%m/%Y"
        });
/*
        Calendario_txtFechaLicitacion.setOnSelectedDelegate(function() {
        var obj = Calendario_txtFechaLicitacion.getSelectedDay();
            alert("a date was just selected and the date is : " + obj.day + "/" + obj.month + "/" + obj.year);
            document.frm_datos_contrato.txtFechaLicitacion.value = obj.day + "/" + obj.month + "/" + obj.year;
        });*/


        Calendario_txtFechaPPiedra = new JsDatePick({
            useMode: 2,
            target: "txtFechaPPiedra",
            dateFormat: "%d/%m/%Y"
        });

        Calendario_txtFechaInaguracion = new JsDatePick({
            useMode: 2,
            target: "txtFechaInaguracion",
            dateFormat: "%d/%m/%Y"
        });
    } 
    
    /*
    function cmdObtenerDocSSDValida_Click() {

        if (document.frm_datos_contrato.txtCodigoContrato.value == "") {
            alert("Para conexión con SSD, debe ingresar un codigo de contrato.");
            document.frm_datos_contrato.txtCodigoContrato.focus();
            return false;
        }

        return true;
    }
*/  
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

        strAlerta = "";        
        strRojo = "3";

        if (document.frm_datos_contrato.ddlLegal.value == strRojo) strAlerta = "S";

        if (document.frm_datos_contrato.ddlAmbiental.value == strRojo) strAlerta = "S";

        if (document.frm_datos_contrato.ddlAmbiental.value == strRojo) strAlerta = "S";

        if (document.frm_datos_contrato.ddlExpropiacion.value == strRojo) strAlerta = "S";

        if (document.frm_datos_contrato.ddlLicitacion.value == strRojo) strAlerta = "S";

        if (document.frm_datos_contrato.ddlEjecTecnicaObras.value == strRojo) strAlerta = "S";

        if (document.frm_datos_contrato.ddlAumento.value == strRojo) strAlerta = "S";

        if (document.frm_datos_contrato.ddlAumento.value == strRojo) strAlerta = "S";

        if (document.frm_datos_contrato.txtExplicacion.value != "") strAlerta = "N";

        if (strAlerta == "S") {
            if (confirm("No olvide que debe justificar los riesgos ROJOS u otra alerta que estime conveniente que pueda afectar la normal terminación y/o/ ejecución del contrato. ¿Desea justificar los riesgos en 'ROJO'?"))
            {
                document.frm_datos_contrato.txtExplicacion.focus();
                return false;
            }
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
            width: 25%;
            height: 28px;
        }
        .style2
        {
            width: 18%;
            height: 28px;
        }
        .style3
        {
            width: 57%;
            height: 28px;
        }
        .auto-style1 {
            color: #666666;
            font-family: Verdana,sans-serif;
            height: 22px;
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
                Seguimiento de Licitaciones y Contratos</td>
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
                            Objeto</td>
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
                            <table class="content" style=" width:100%;">
                                <tr>
                                    <td style=" width:25%;">
                                        &nbsp;</td>
                                    <td style=" width:18%;">
                                        &nbsp;</td>
                                    <td style=" width:57%;">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style = "width: 20%;">
                                    Próxima Gestión
                                    </td>
                                    <td colspan="2">
                                      <asp:DropDownList ID="ddlProximoHito" runat="server" 
                                      CssClass="content" Height="21px" 
                                      Width="491px">
                                      </asp:DropDownList>
                                    </td>
                                                                     
                                </tr>
                                <tr>
                                    <td style = "width: 20%;">
                                     Responsable Gestión
                                    </td>
                                    <td style=" width:57%;">
                                        <asp:DropDownList ID="ddlRespAdmin" runat="server" CssClass="content" Height="21px" 
                                            Width="491px">
                                        </asp:DropDownList>
                                    </td>   
                                </tr> 
                                <tr>     
                                        <td style = "width: 30%;">
                                        Fecha estimada cumplimiento 
                                        </td>
                                      <td style = "width: 17%;">
                                      <asp:TextBox ID="txtFechaLicitacion" runat="server" CssClass="content" 
                                      ReadOnly="True" Width="100px" Height="18px"></asp:TextBox>
                                      <asp:Image ID="Image2" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                      </td>
                                    
                                </tr>
                                <tr>
                                    <td style = "width: 30%;">
                                     Descripción próxima Gestión  
                                    </td>
                                     <td>
                                     <asp:TextBox ID="txtExplicacion" runat="server" CssClass="content" Height="117px" 
                                      MaxLength="600" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>   
                                     <td style = "width: 30%;">
                                     Observación Depto.  
                                    </td>
                                     <td>
                                     <asp:TextBox ID="txtobservacionM" runat="server" CssClass="content" Height="117px" 
                                      MaxLength="600" TextMode="MultiLine" Width="100%" BackColor="#FFFFCC" 
                                             ForeColor="Black" Visible="False"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td class="style1">
                                        &nbsp;
                                    </td>
                                    <td class="style2">
                                        &nbsp;
                                    </td>
                                    <td class="style3">
                                        &nbsp;
                                   </td>
                                </tr>
                               
                                <tr>
                                    <td class="borde_celda">
                                        Alertas</td>
                                </tr>
                               
                                <tr>
                                    <td class="content">
                                        <span class="content">Administrativa</span>
                                    </td>
                                    <td class="content">
                                  <asp:DropDownList ID="ddlLicitacion" runat="server" CssClass="content" 
                                            Height="20px" Width="156px" >
                                        </asp:DropDownList>
                                    </td>
                                
                                        
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        Costos</td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlAumento" runat="server" CssClass="content" 
                                            Height="20px" Width="156px" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        &nbsp;</td>
                                    <td class="auto-style1">
                                        <asp:DropDownList ID="ddlExpropiacion" runat="server" CssClass="content" 
                                            Height="20px" Width="156px" Visible="False" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">
                                        &nbsp;</td>
                                    <td class="auto-style1">
                                        
                                      
                                        <asp:DropDownList ID="ddlLegal" runat="server" CssClass="content" Height="20px" 
                                            Width="156px" Visible="False">
                                        </asp:DropDownList>


                                    </td>
                                </tr>
                                <tr>
                                    <td class="content">
                                        &nbsp;</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlEjecTecnicaObras" runat="server" CssClass="content" 
                                            Height="20px" Width="156px" Visible="False" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="content" 
                                        .</td>
                                    <td class="content">
                                        <asp:DropDownList ID="ddlAmbiental" runat="server" CssClass="content" 
                                            Height="20px" Width="156px" Visible="False" >
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
                                </tr>
                            </table>
            </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                <table class="content">
                    <tr class="content">
                        
                        <td style = "width: 17%;">
                            <asp:TextBox ID="txtFechaPPiedra" runat="server" CssClass="content" 
                                ReadOnly="True" Width="100px" Height="18px" Visible="False"></asp:TextBox>
                        
                        </td>
                      <td style = "width: 17%;">
                            <asp:TextBox ID="txtFechaInaguracion" runat="server" CssClass="content" 
                                ReadOnly="True" Width="100px" Height="18px" Visible="False"></asp:TextBox>
                     
                        </td>
                    </tr>
                    <tr class="content">
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                    </tr>
                    <tr class="content">
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                    </tr>
                    
                    <tr class="content">
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                    </tr>
                    <tr class="content">
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                        <td style = "width: 15%;">
                            &nbsp;</td>
                        <td style = "width: 17%;">
                            &nbsp;</td>
                    </tr>
                </table>
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
