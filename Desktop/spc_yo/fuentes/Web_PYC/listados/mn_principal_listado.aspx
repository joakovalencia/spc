<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_principal_listado.aspx.cs"
    Inherits="mn_principal_listado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %>
    </title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="all" href="../js/reloj/jsDatePick_ltr.min.css" />

    <script type="text/javascript" src="../js/reloj/jquery.1.4.2.js"></script>

    <script type="text/javascript" src="../js/reloj/jsDatePick.jquery.min.1.3.js"></script>

    <script language="JavaScript" type="text/JavaScript">
    <!--

        window.onload = function() {

            Calendario_txtFechaInicio = new JsDatePick({
                useMode: 2,
                target: "txtFechaInicio",
                dateFormat: "%d/%m/%Y"
            });

            Calendario_txtFechaFinal = new JsDatePick({
                useMode: 2,
                target: "txtFechaFinal",
                dateFormat: "%d/%m/%Y"
            });

        }

    
    </script>

    <meta http-equiv="content-type" content="text/html;" />
    <meta name="author" content="alor86" />
    <style type="text/css">
        .style1
        {
            height: 22px;
        }
        .style2
        {
            height: 26px;
        }
        .style3
        {
            height: 60px;
        }
        .style4
        {
            height: 27px;
        }
        .style7
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            width: 25%;
            height: 20px;
        }
        .style8
        {
            height: 27px;
            width: 175px;
        }
        .oculto
        {
            display: none;
            visibility: hidden;
            height: 0px;
            width: 0px;
        }
        
         input[type=submit]
        {
            box-shadow:0 2px 4px 0 rgba(0,0,0,0.2), 0 6px 5px 0 rgba(0,0,0,0.19);
            border-radius: 4px;
            padding:  4px 2px 4px 2px;
             -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
            
        }
        
        input[type=submit]:hover 
        {
         background-color:lightgray white; 
         color: black;
         font-weight:bold;
        }
        
        input[id^="Btn"]
        {
            color:Black;
            font-weight:bolder;            
        }
        
        .botonera
        {
            margin-bottom:-3px;
        }
    </style>
</head>
<body>
    <form id="frm_listados" runat="server">
    <div class="head_principal">
    </div>|
    <div class="main_principal">
        <br />
        <div style="text-align: center">
            <table style="width: 90%">
                <tr>
                    <td style="width: 50%" class="title">
                        Listados
                    </td>
                    <td>
                        <asp:ImageButton ID="cmdSalir" runat="server" ImageUrl="~/img/plantilla/exit.png"
                            OnClick="cmdSalir_Click" />
                    </td>
                </tr>
            </table>
            <br />
            <table style="width: 90%">
                <tr>
                    <td style="color: #666666; font-family: Verdana,sans-serif; height: 23px; width: 25%;">
                        De la región
                    </td>
                    <td style="color: #666666; font-family: Verdana,sans-serif; height: 23px; width: 25%;">
                        Hasta la región
                    </td>
                    <td style="color: #666666; font-family: Verdana,sans-serif; height: 23px; width: 25%;">
                        Fecha Inicial
                    </td>
                    <td style="color: #666666; font-family: Verdana,sans-serif; height: 23px; width: 25%;">
                        Fecha Final
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%" class="content">
                        <asp:DropDownList ID="ddlRegionInicio" runat="server" CssClass="content" Style="width: 190px;
                            height: 22px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 25%" class="content">
                        <asp:DropDownList ID="ddlRegionFinal" runat="server" CssClass="content" Style="width: 190px;
                            height: 22px">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 25%" class="content">
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="content" ReadOnly="True"
                            Width="100px" Height="22px"></asp:TextBox>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                    </td>
                    <td style="width: 25%" class="content">
                        <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="content" ReadOnly="True"
                            Width="100px" Height="22px"></asp:TextBox>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%" class="content">
                        &nbsp;
                    </td>
                    <td style="width: 25%" class="content">
                        &nbsp;
                    </td>
                    <td style="width: 25%" class="content">
                        &nbsp;
                    </td>
                    <td style="width: 25%" class="content">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <br />
           
            <!--
            <table style="width: 90%">
                <tr class="content">
                    <td>
                        Proyectos
                    </td>
                    <td>
                        Propuestas
                    </td>
                </tr>
                <tr class="content">
                    <td>
                        &nbsp;
                    </td>
                    <td>
             
                        <asp:Button ID="Btn_Cartolas" runat="server" Text="Mostrar Cartolas" Style="width: 300px;
                            height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                            OnClick="Btn_Cartolas_Click" />
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 25%" class="content" valign="top">
                        <table style="width: 90%">
                            <tr class="content">
                                <td class="style1">
                                    Proyectos
                                </td>
                                <td>
                                    Propuestas
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                   
                                    <input id="cmdFichaProyecto" class="content" style="width: 187px;" type="submit"
                                     value="Ficha de Proyecto" onclick="return cmdFichaProyecto_onclick()" />

                                </td>
                                <td style="width: 25%" class="content">
                                    <asp:Button ID="cmdPropuestasProgramadas" runat="server" Text="Propuestas Programadas"
                                        Style="width: 190px; height: 25px;" CssClass="content" OnClick="cmdPropuestasProgramadas_Click"
                                        OnClientClick="JavaScript:document.frm_listados.target ='_blank';" />
                                </td>
                                       
                            </tr>
                            <tr>
                                
                                <td class="style2">
                                    <asp:Button ID="CmdPRO_proy_estado_idea" runat="server" Text="Proy.Estado de Idea"
                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmdPRO_proy_estado_idea_Click" Height="34px" />
                                </td>
                                <td style="width: 25%" class="content">
                                    <asp:Button ID="CmdPRO_propuestas_abiertas" runat="server" Text="Propuestas Abiertas"
                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmdPRO_propuestas_abiertas_Click" Height="25px" />
                                </td>
                                    
                            </tr>

                             <tr>
                                 
                                <td class="style2">
                                    
                                    <asp:Button ID="CmbPRO_Proyectos_Mandatado" runat="server" Text="Proy.Estado Mandatado"
                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_Proyectos_Mandatado_Click" />
                                </td>
                                <td style="width: 25%" class="content">
                                    <asp:Button ID="CmbPRO_adjudicadas" runat="server" Text="Propuestas Adjudicadas"
                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_adjudicadas_Click" />
                                </td>
                                 
                            </tr>
                            <tr>
                                
                                <td class="style2">
                                    <asp:Button ID="CmbPRO_estado_ejecucion" runat="server" Text="Proy.Estado ejecución"
                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_estado_ejecucion_Click" />
                                </td>
                                <td style="width: 25%" class="content">
                                    <asp:Button ID="CmbPRO_Convenios" runat="server" Text="Convenios" Style="width: 190px;
                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_Convenios_Click" />
                                </td>
                                
                            </tr>
                            <tr>
                               
                                <td class="style2">
                                    <asp:Button ID="CmbPRO_estado_otro" runat="server" Text="Proyectos en estado Otro"
                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_estado_otro_Click" />
                                </td>
                                <td style="width: 25%" class="content">
                                    <asp:Button ID="CmbPRO_contratos_ITO" runat="server" Text="Contratos ITO" Style="width: 190px;
                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_contratos_ITO_Click" />
                                </td>
                                   
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                
                                <td style="width: 25%" class="content">
                                    <asp:Button ID="CmbPRO_estado_terminado" runat="server" Text="Proy.Estado Terminado"
                                        Style="width: 190px; height: 25px;" CssClass="content oculto" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_estado_terminado_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td style="width: 25%" class="content">
                                    <asp:Button ID="CmbPRO_estado_liquidado" runat="server" Text="Proy. Estado Liquidado"
                                        Style="width: 190px; height: 25px;" CssClass="content oculto" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_estado_liquidado_Click" />
                                </td>
                              
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td style="width: 25%" class="content">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2" colspan="2">
                                    Varios
                                </td>
                            </tr>
                            <tr>
                              
                                <td class="style2">
                                    <asp:Button ID="CmbPRO_VAR_Info_contratista" runat="server" Text="Contratista Específico"
                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="CmbPRO_VAR_Info_contratista_Click" />
                                </td>
                                <td style="width: 25%" class="content">
                                    <asp:Button ID="cmdInversionMandante" runat="server" Text="Inversión por Mandante"
                                        Style="width: 190px;" CssClass="content" 
                                        OnClick="cmdInversionMandante_Click" Height="24px" />
                                </td>
                              
                            </tr>
                            <tr>
                                
                                <td class="style2">
                                    <input id="cmdAuditoria" class="content" style="width: 190px;" type="submit" value="Informes de Auditoria"
                                        onclick="return cmdAuditoria_onclick()" />
                                </td>
                                <td style="width: 25%" class="content">
                                    &nbsp;
                                </td>
                                    
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td style="width: 25%" class="content">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style2" colspan="2">
                                    Alertas
                                </td>
                            </tr>
                            <tr>
                                
                                <td class="style2">
                                    <input id="cmdADiarias" class="content" style="width: 190px;" type="submit" value="Diarias"
                                        onclick="return cmdInfAlertas_onclick('1')" />
                                </td>
                                <td style="width: 25%" class="content">
                                    <input id="cmdAQuincenales" class="content" style="width: 190px;" type="submit" value="Semanal"
                                        onclick="return cmdInfAlertas_onclick('2')" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <input id="cmdAMensuales" class="content" style="width: 190px;" type="submit" value="Mensuales"
                                        onclick="return cmdInfAlertas_onclick('3')" />
                                </td>
                                <td style="width: 25%" class="content">
                                    &nbsp;
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td style="width: 25%" class="content">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                
                                
                                
                            </tr>
                            <tr>
                                <td class="style2">
                                    &nbsp;
                                </td>
                                <td style="width: 25%" class="content">
                                    &nbsp;
                                </td>
                            </tr>
             </table>
                
                    </td>
                    <td valign="top">
                        <table id="botonera" class="botonera">
                            <tr>
                                <td>
                                    <!--
                                    <input id="Btn_vigentes" class="content" style="width: 82px; height: 25px;" type="button"
                                        value="Vigentes" onclick="muestra_oculta('tab_vigentes')" />
                                </td>
                                <td>
                                    <input id="Btn_ejecucion" class="content" style="width: 82px; height: 25px;" type="button"
                                        value="Ejecucion" onclick="muestra_oculta('tab_ejecucion')" />
                                </td>
                                <td>
                                    <input id="Btn_termino" class="content" style="width: 82px; height: 25px;" type="button"
                                        value="Termino" onclick="muestra_oculta('tab_termino')" />
                                </td>
                                <td>
                                    <input id="Btn_provisoria" class="content" style="width: 130px; height: 25px;" type="button"
                                        value="Recep.Provisoria" onclick="muestra_oculta('tab_provisoria')" />
                                </td>
                                <td>
                                    <input id="Btn_acta" class="content" style="width: 130px; height: 25px;" type="button"
                                        value="Acta Explotación" onclick="muestra_oculta('tab_acta')" />
                                </td>
                                <td>
                                    <input id="Btn_liquidacion" class="content" style="width: 82px; height: 25px;" type="button"
                                        value="Liquidación" onclick="muestra_oculta('tab_liquidacion')" />
                                </td>
                                <td>
                                    <input id="Btn_Riesgos" class="content" style="width: 82px; height: 25px;" type="button"
                                        value="Otros" onclick="muestra_oculta('tab_riesgos')" />
                                </td>
                
                            </tr>
                        </table>
                

                        <div id="tab_vigentes">
                            <table border="2" cellpadding="0" cellspacing="1" style="width: 100%; border-collapse: collapse">
                                <tr>
                                    <td style="background-color: #dbe5f1; text-align: center" class="style3">
                                        <table>
                                            <tr class="oculto">
                                                <td class="content">
                                                    Excel
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <table class="oculto">
                                            
                                        </table>
                                            
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    General
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                               
                                                <td class="style4">
                                                    <asp:Button ID="cmdVIG_Ordenado_Sector_Destino" runat="server" Text="Contratos Vigentes"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="200px" Width="300px" 
                                                        OnClick="cmdVIG_Ordenado_Sector_Destino_Click" EnableTheming="True" 
                                                        BackColor="#66CCFF" />
                                                </td>
                                                <td class="style4">

                                                    <asp:Button ID="cmdVIG_Cttos_Sec_Destino_Sectorial" runat="server" Text="Cttos Sector Destino Sectorial"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="cmdVIG_Cttos_Sec_Destino_Sectorial_Click" />
                                                   -->
                                    <asp:Button ID="Cmd_flujo_financiero" runat="server" Text="Estimación de inv. del año" Style="width: 190px;
                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                        OnClick="Cmd_flujo_financiero_Click" Width="203px" BackColor="#66CCFF" />
             
            <!--                                    
            </td>
                                            </tr>
                                            <tr>
                                             
                                                <td class="style4">
                                                    <asp:Button ID="cmdVIG_Ordenado_Tipo_Fondo" runat="server" Text="Cont. Orden Tipo Fondo"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="cmdVIG_Ordenado_Tipo_Fondo_Click" 
                                                        Visible="False" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="cmdVIG_Contrato_Vig_Prod_Estrategico" runat="server" Text="Cont. Vig. Prod. Estrategico"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        OnClick="cmdVIG_Contrato_Vig_Prod_Estrategico_Click" />
                                                </td>
                                                 
                                            </tr>
                                        </table>
                            
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Diseños
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbDIS_Contratos_Orden_Sec_Desti" runat="server" Text="Cont. orden Sector Destino"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbDIS_Contratos_Orden_Sec_Desti_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="CmbDIS_Contra_Ord_TipoFondo" runat="server" Text="Cont. Orden Tipo de Fondo"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbDIS_Contra_Ord_TipoFondo_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Obras
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style8">
                                                    <asp:Button ID="CmdOBRA_Contra_Orden_Sec_Destino" runat="server" Text="Cont. Orden Sector Destino"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="165px" OnClick="CmdOBRA_Contra_Orden_Sec_Destino_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="CmbOBRA_Tipo_de_Fondo" runat="server" Text="Cont. orden Tipo de Fondo"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbOBRA_Tipo_de_Fondo_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style8">
                                                </td>
                                                <td class="style4">
                                                </td>
                                                <td class="style4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                           
                        </div>
                        
                        <div id="tab_ejecucion" style="display: none;">
                            <table border="2" cellpadding="0" cellspacing="1" style="width: 100%; border-collapse: collapse">
                                <tr>
                                    <td style="background-color: #dbe5f1; text-align: center" class="style3">
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    General
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbEJE_Ordenados_provincias" runat="server" Text="Cont. orden por Provincia"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbEJE_Ordenados_provincias_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="CmbEJE_progra_avance_finan" runat="server" Text="Programaciòn Avance finan."
                                                        Style="width: 190px; height: 25px;" CssClass="content oculto" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbEJE_progra_avance_finan_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbEJE_Ordenado_por_Comuna" runat="server" Text="Cont. Orden Comuna"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbEJE_Ordenado_por_Comuna_Click" />
                                                </td>
                                                <td class="style4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Diseños
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbEJE_Orden_Provi" runat="server" Text="Cont. Orden Provincias"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbEJE_Orden_Provi_Click" />
                                                </td>
                                                <td class="style4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Obras
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    
                                                </td>
                                                <td class="style4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                </td>
                                                <td class="style4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="tab_termino" style="display: none;">
                            <table border="2" cellpadding="0" cellspacing="1" style="width: 100%; border-collapse: collapse">
                                <tr>
                                    <td style="background-color: #dbe5f1; text-align: center" class="style3">
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    General
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbTER_GEN_fecha_ito" runat="server" Text="Cont. Terminados F.ITO"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbTER_GEN_fecha_ito_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="CmbTER_GEN_proyec_termino" runat="server" Text="Proy. de Términos de cont."
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbTER_GEN_proyec_termino_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Diseños
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbTER_DIS_segun_fecha_ITO" runat="server" Text="Cont. terminados F.ITO"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbTER_DIS_segun_fecha_ITO_Click" />
                                                </td>
                                                <td class="style4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Obras
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbTER_OBRA_contratos_terminados" runat="server" Text="Cont. Terminados"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="165px" OnClick="CmbTER_OBRA_contratos_terminados_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="CmbTER_OBRA_termindas_plazo" runat="server" Text="Obras nuevas Ter. en plazo"
                                                        Style="width: 190px; height: 25px;" CssClass="content oculto" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="165px" OnClick="CmbTER_OBRA_termindas_plazo_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                </td>
                                                <td class="style4">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="tab_provisoria" style="display: none;">
                            <table border="2" cellpadding="0" cellspacing="1" style="width: 100%; border-collapse: collapse">
                                <tr>
                                    <td style="background-color: #dbe5f1; text-align: center" class="style3">
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Obras
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbREC_OBRA_recepcion_provisoria" runat="server" Text="Cont. Recepcion Provisoria"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbREC_OBRA_recepcion_provisoria_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="tab_acta" style="display: none;">
                            <table border="2" cellpadding="0" cellspacing="1" style="width: 100%; border-collapse: collapse">
                                <tr>
                                    <td style="background-color: #dbe5f1; text-align: center" class="style3">
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Obras
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbACT_GEN_acta_explotacion" runat="server" Text="Cont.Acta entrega Explo."
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbACT_GEN_acta_explotacion_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="tab_liquidacion" style="display: none;">
                            <table border="2" cellpadding="0" cellspacing="1" style="width: 100%; border-collapse: collapse">
                                <tr>
                                    <td style="background-color: #dbe5f1; text-align: center" class="style3">
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Diseños
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbLIQ_DIS_Contratos_Liquidados" runat="server" Text="Contratos liquidados"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbLIQ_DIS_Contratos_Liquidados_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="CmbLIQ_DIS_cont_liq_anti" runat="server" Text="Contratos Liquidación Ant."
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbLIQ_DIS_cont_liq_anti_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Obras
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="CmbLIQ_OBRAS_Contratos_Liquidados" runat="server" Text="Contratos Liquidados"
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbLIQ_OBRAS_Contratos_Liquidados_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="CmbLIQ_OBRAS_Cont_Liq_Anti" runat="server" Text="Contratos Liquidación Ant."
                                                        Style="width: 190px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="CmbLIQ_OBRAS_Cont_Liq_Anti_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="tab_riesgos" style="display: none;">
                            <table border="2" cellpadding="0" cellspacing="1" style="width: 100%; border-collapse: collapse">
                                <tr>
                                    <td style="background-color: #dbe5f1; text-align: center" class="style3">
                                        <table>
                                            <tr>
                                                <td class="content">
                                                    Listado de Riesgos Críticos
                                                </td>
                                            </tr>
                                        </table>
                                        <table>
                                            <tr class="oculto">
                                                <td class="style4">
                                                    <asp:Button ID="RF2" runat="server" Text="RF2.Prop. sin oferentes primer llamado"
                                                        Style="width: 340px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RF2_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="RP2" runat="server" Text="RP2.Monitoreo plazos de lic." Style="width: 340px;
                                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RP2_Click" />
                                                </td>
                                            </tr>
                                            <tr class="oculto">
                                                <td class="style4">
                                                    <asp:Button ID="RF3" runat="server" Text="RF3.Licitación no adjudicados" Style="width: 340px;
                                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RF3_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="RP3" runat="server" Text="RP3.Cartilla Cheq. Propuesta Técnica" Style="width: 340px;
                                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RP3_Click" />
                                                </td>
                                            </tr>
                                            <tr class="oculto">
                                                <td class="style4">
                                                    <asp:Button ID="RF4" runat="server" Text="RF4.Monitoreo de nuevas boletas de garantías"
                                                        Style="width: 340px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RF4_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="RP4" runat="server" Text="RP4.Demora del Mandante en aprobar modif."
                                                        Style="width: 340px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RP4_Click" />
                                                </td>
                                            </tr>
                                            <tr class="oculto">
                                                <td class="style4">
                                                    <asp:Button ID="RF5" runat="server" Text="RF5.Obras mal valorizadas en liq. anti."
                                                        Style="width: 340px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RF5_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="RP5" runat="server" Text="RP5.Recepción Definitiva de Contratos de Obras"
                                                        Style="width: 340px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RP5_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="RF6" runat="server" Text="RF6. Cance. estados pagos sobre avances reales"
                                                        Style="width: 340px; height: 25px;" CssClass="content oculto" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RF6_Click" />
                                                </td>                                                
                                            </tr>
                                            <tr>
                                                <td class="style4">
                                                    <asp:Button ID="RF7" runat="server" Text="RF7.Vencimientos boletas de Garantías"
                                                        Style="width: 340px; height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RF7_Click" />
                                                </td>
                                                <td class="style4">
                                                    <asp:Button ID="RP6" runat="server" Text="RP6.Seguimiento consultorías" Style="width: 340px;
                                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RP6_Click" />
                                                </td>
                                                <td class="style4 oculto">
                                                    <asp:Button ID="RP7" runat="server" Text="RP7.Cartilla Chequeo Previo Terreno" Style="width: 340px;
                                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RP7_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style4 oculto">
                                                    <asp:Button ID="RP8" runat="server" Text="RP8.Cartilla Chequeo Previo Obras" Style="width: 340px;
                                                        height: 25px;" CssClass="content" OnClientClick="JavaScript:document.frm_listados.target ='_blank';"
                                                        Height="120px" Width="184px" OnClick="RP8_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                            
                    </td>
                </tr>
                
                <tr>
                    <td class="style7">
                        &nbsp;
                    </td>
                </tr>
            </table>
                -->
            <br />
          
        </div>
        <br />
        <br />
    </div>
    <br />

        <asp:Image ID="gt" runat="server" ImageUrl="~/img/plantilla/gttml.jpg" Height="565px" />
             
    <div class="footer">
        <strong>USUARIO: </strong>
        <asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label
            ID="lblCorreo" runat="server" CssClass="content"></asp:Label>
        <strong>GRUPO: </strong>
        <asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
        <strong>FECHA: </strong>
        <asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
    </div>
    </form>
</body>
</html>
