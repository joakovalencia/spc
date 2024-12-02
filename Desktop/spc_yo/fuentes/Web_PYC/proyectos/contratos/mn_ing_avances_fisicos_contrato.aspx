<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_ing_avances_fisicos_contrato.aspx.cs" Inherits="mn_ing_avances_fisicos_contrato" %>

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

        Calendario_txtFecha = new JsDatePick({
            useMode: 2,
            target: "txtFecha",
            dateFormat: "%d/%m/%Y"
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

        if (document.frm_datos_contrato.txtProceso.value == "") {
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtProceso.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtSufijo.value == "") {
            alert("Debe ingresar sufijo.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
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

        if (document.frm_datos_contrato.txtSufijo.value == "") {
            alert("Debe ingresar sufijo.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
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
                Modificación Prog. Avances Físicos del Contrato <div class="content_small">(Contrato-Avances 
                    Físicos)</div></td>
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
                                ToolTip="Modifica Imputación Presupuestaria del Contrato" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Modifica Imputación Presupuestaria del Contrato" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla FORMATOM" Visible="False"></asp:Label>
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
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Modificación Programacion Vigente de Avances Fisicos</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="borde_celda_small" style=" text-align:center; ">
                                                                                                        Avances en %</td>
                                    <td colspan="2" class="borde_celda_small" style=" text-align:center; ">
                                                    Mediciones Reales</td>
                                </tr>
                                <tr>
                                    <td>
                                        Año</td>
                                    <td>
                                        <asp:DropDownList ID="ddlAno" runat="server" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Fecha</td>
                                    <td>
                            <asp:TextBox ID="txtFecha" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mes</td>
                                    <td>
                                        <asp:DropDownList ID="ddlMes" runat="server" CssClass="content">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Avances Fis. Parcial</td>
                                    <td>
                            <asp:TextBox ID="txtAvancesFiscParcial" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Parcial</td>
                                    <td>
                            <asp:TextBox ID="txtParcial" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                    <td>
                                        Calificada</td>
                                    <td>
                            <asp:TextBox ID="txtCalificada" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="5"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Acumulado</td>
                                    <td>
                            <asp:TextBox ID="txtAcumulado" runat="server" CssClass="content" 
                                Width="50px" Height="18px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        Semi Calificada</td>
                                    <td>
                            <asp:TextBox ID="txtSemiCalificada" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Avance Fis. Actual</td>
                                    <td>
                            <asp:TextBox ID="txtAvancesFiscAct" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="4"></asp:TextBox>
                                    </td>
                                    <td>
                                        No Calificada</td>
                                    <td>
                            <asp:TextBox ID="txtNoCalificada" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="4"></asp:TextBox>
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
                                    <td colspan="4">
                                        <asp:HiddenField ID="txtLlave" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style=" text-align:center; ">
                                        Observaciones
                            <asp:TextBox ID="txtObs" runat="server" CssClass="content" 
                                Width="70%" Height="18px" MaxLength="300"></asp:TextBox>
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
                                    <td colspan="4" class="borde_celda">Programacion Vigente de Avances Fisicos</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table width="100%">
                                            <tr>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                                <td width="9%">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td colspan="4" class="borde_celda_small" style=" text-align:center; ">
                                                    Avances en %</td>
                                                <td colspan="5" class="borde_celda_small" style=" text-align:center; ">
                                                    Mediciones Reales</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="11">
                <asp:GridView ID="grdAvanceFisico" runat="server" CellPadding="10" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="100%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="9%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="AGNO" HeaderText="Año" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MES" HeaderText="Mes" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AV_FIS_PR" HeaderText="Parcial" HtmlEncode="False" DataFormatString="{0:0,0}" >
                        <HeaderStyle HorizontalAlign="Right" Width="7%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AV_FIS_ACUM" HeaderText="Acum" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Right" Width="7%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AVANCE_FISICO_ACTUAL" HeaderText="Avance Fis. Actual" DataFormatString="{0:0,0}" >
                        <HeaderStyle HorizontalAlign="Right" Width="9%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FECHA_MEDICION" HeaderText="Fecha" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Center" Width="9%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AV_FIS_RE" HeaderText="Avance Fis. Parcial" HtmlEncode="False" DataFormatString="{0:0,0}" HtmlEncodeFormatString="False" >
                        <HeaderStyle HorizontalAlign="Right" Width="9%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Calificada" DataField="MANO_DE_OBRA_CALIFICADA" HtmlEncode="False" >
                        <HeaderStyle Width="9%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Semi Clif." DataField="MANO_DE_OBRA_SEMI_CALIFICADA" HtmlEncode="False" >
                        <HeaderStyle Width="9%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="No Calif." DataField="MANO_DE_OBRA_NO_CALIFICADA" HtmlEncode="False" >
                        <HeaderStyle Width="9%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Obs" DataField="OBSERV" HtmlEncode="False" HtmlEncodeFormatString="False">
                        <HeaderStyle Width="9%" HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="llave" HeaderText="llave">
                        <HeaderStyle HorizontalAlign="Right" Width="15%" CssClass="cell_hidde" />
                        <ItemStyle HorizontalAlign="Right" CssClass="cell_hidde" />
                        </asp:BoundField>
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
                                            <tr class="content_small">
                                                <td colspan="2">
                                                    <b>Totales:</b></td>
                                                <td align="right">
                                                    <b>
                                                    <asp:Label ID="lblTot" runat="server"></asp:Label>
                                                    </b></td>
                                                <td align="right">
                                                    &nbsp;</td>
                                                <td colspan="2" >
                                                    <b>&nbsp;Avance a la Fecha:</b></td>
                                                <td align="right">
                                                    <b>
                                                    <asp:Label ID="lblAFe" runat="server"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </b></td>
                                                <td colspan="3">
                                                    <b>&nbsp;M.O. Calificada utilizada a la fecha:</b></td>
                                                <td align="right">
                                                    <b>
                                                    <asp:Label ID="lblMC" runat="server"></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr class="content_small">
                                                <td colspan="2">
                                                    <b>Saldo x Programar:</b></td>
                                                <td align="right">
                                                    <b>
                                                    <asp:Label ID="lblSxP" runat="server"></asp:Label>
                                                    </b></td>
                                                <td align="right">
                                                    &nbsp;</td>
                                                <td colspan="2">
                                                    <b>&nbsp;Avance Restante:</b></td>
                                                <td align="right">
                                                    <b>
                                                    <asp:Label ID="lblARe" runat="server"></asp:Label>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;</b></td>
                                                <td colspan="3">
                                                    <b>&nbsp;M.O. NO Calificada utilizada al fecha:</b></td>
                                                <td align="right">
                                                    <b>
                                                    <asp:Label ID="lblMNC" runat="server"></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr class="content_small">
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
                                                <td align="right">
                                                    &nbsp;</td>
                                                <td colspan="3">
                                                    <b>&nbsp;M.O. Semi Calificada:</b></td>
                                                <td align="right">
                                                    <b>
                                                    <asp:Label ID="lblMOSC" runat="server"></asp:Label>
                                                    </b></td>
                                            </tr>
                                        </table>
                                    <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
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
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"></asp:Label><asp:Label ID="lblCorreo" runat="server" CssClass="content"></asp:Label>
    <strong> GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"></asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"></asp:Label>
</div>

</form>

</body>
</html>
