<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_etapas_det_proy.aspx.cs" Inherits="mn_etapas_det_proy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />    
    <script language="jscript" type="text/jscript" src="../../js/funciones.js"></script>
    
    <script language="JavaScript" type="text/JavaScript">
        <!--
               
        function func_valida_eliminar() {

        if (document.fmr_etapas.txtRegion.value == "") {
            alert("Debe ingresar región.");
            document.fmr_etapas.txtRegion.focus();
            return false;
        }

        if (document.fmr_etapas.txtPIA.value == "") {
            alert("Debe ingresar PIA.");
            document.fmr_etapas.txtPIA.focus();
            return false;
        }  

        if (document.fmr_etapas.txtTipoProyecto.value == "") {
            alert("Debe ingresar tipo proyecto.");
            document.fmr_etapas.txtTipoProyecto.focus();
            return false;
        }

        if (document.fmr_etapas.ddlEtapa.value == "(SELECCIONAR)") {
            alert("Debe seleccionar etapa.");
            document.fmr_etapas.ddlEtapa.focus();
            return false;
        }

        if (document.fmr_etapas.txtMontoTotal.value == "") {
            alert("Debe ingresar monto total.");
            document.fmr_etapas.txtMontoTotal.focus();
            return false;
        }
        
        if (document.fmr_etapas.txtCodigoBIP.value == "") {
            alert("Debe ingresar Codigo BIP.");
            document.fmr_etapas.txtCodigoBIP.focus();
            return false;
        }
        
        if (document.fmr_etapas.txtParte.value == "") {
            alert("Debe ingresar parte Codigo BIP.");
            document.fmr_etapas.txtParte.focus();
            return false;
        }
        /*
        if (document.fmr_etapas.txtDescripcion.value == "") {
            alert("Debe ingresar descripción.");
            document.fmr_etapas.txtDescripcion.focus();
            return false;
        }*/
        
        if (confirm("¿Seguro que desea eliminar este registro?"))
            return true;
        else
            return false;
    }
    
    function func_valida_grabar() {
        
        if (document.fmr_etapas.txtRegion.value == "") {
            alert("Debe ingresar región.");
            document.fmr_etapas.txtRegion.focus();
            return false;
        }

        if (document.fmr_etapas.txtPIA.value == "") {
            alert("Debe ingresar PIA.");
            document.fmr_etapas.txtPIA.focus();
            return false;
        }  

        if (document.fmr_etapas.txtTipoProyecto.value == "") {
            alert("Debe ingresar tipo proyecto.");
            document.fmr_etapas.txtTipoProyecto.focus();
            return false;
        }

        if (document.fmr_etapas.ddlEtapa.value == "(SELECCIONAR)") {
            alert("Debe seleccionar etapa.");
            document.fmr_etapas.ddlEtapa.focus();
            return false;
        }

        if (document.fmr_etapas.txtMontoTotal.value == "") {
            alert("Debe ingresar monto total.");
            document.fmr_etapas.txtMontoTotal.focus();
            return false;
        }
        
        if (document.fmr_etapas.txtCodigoBIP.value == "") {
            alert("Debe ingresar tipo proyecto.");
            document.fmr_etapas.txtCodigoBIP.focus();
            return false;
        }
        
        if (document.fmr_etapas.txtParte.value == "") {
            alert("Debe ingresar parte.");
            document.fmr_etapas.txtParte.focus();
            return false;
        }
        /*
        if (document.fmr_etapas.txtDescripcion.value == "") {
            alert("Debe ingresar descripción.");
            document.fmr_etapas.txtDescripcion.focus();
            return false;
        }*/
           
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;
    
    }
    
        
        
        function cmdCerrarFichaProyecto_onclick() {
            window.opener = null;
            window.close();
            return false;
        }
        
        //-->
    </script>
    
    </head>
<body>
    <form id="fmr_etapas" runat="server">
        
        <div id = "div_ficha_proyecto" 
            style="height: 117px; width: 650px;  background-color:White; " >
            <table style="width: 100%; border:thick solid #008BD5;">
                <tr>
                    <td colspan="2"  class="borde_celda" >
                            ETAPAS DEL PROYECTO</td>
                </tr>
                <tr>
                    <td colspan="2" style=" text-align:left ">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Agregar Mandante" onclick="cmdGrabar_Click" OnClientClick="return func_valida_grabar();" />
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Eliminar Mandante" onclick="cmdEliminar_Click" OnClientClick="return func_valida_eliminar();" />
                                <asp:ImageButton ID="cmdCerrar" runat="server"
                            ImageUrl="~/img/plantilla/exit.png" OnClick="cmdCerrar_Click"
                          ToolTip="Salir" /> 

                                
                    </td>
                </tr>
                <tr class="content">
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr class="content">
                    <td colspan="2" class="content">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 20%">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="borde_celda_small">
                                    Datos Proyecto</td>
                            </tr>
                            <tr>
                                <td style="width: 20%">
                                    Región</td>
                                <td>
                            <asp:TextBox ID="txtRegion" runat="server" CssClass="content" ReadOnly="True" 
                                Width="51px" Height="18px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    PIA</td>
                                <td>
                            <asp:TextBox ID="txtPIA" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="18px"></asp:TextBox>
                                &nbsp;Tipo Proyecto
                            <asp:TextBox ID="txtTipoProyecto" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="18px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Objeto</td>
                                <td>
                            <asp:TextBox ID="txtObjeto" runat="server" CssClass="content" ReadOnly="True" 
                                Width="455px" Height="18px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="borde_celda_small">
                                    Selección Mandante</td>
                            </tr>
                            <tr>
                                <td>
                                    Etapa</td>
                                <td>
                                    <asp:DropDownList ID="ddlEtapa" runat="server" CssClass="content" 
                                        Height="19px" Width="270px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Monto Total</td>
                                <td>
                                    <asp:TextBox ID="txtMontoTotal" runat="server" CssClass="content" 
                                        MaxLength="15"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Codigo BIP</td>
                                <td>
                                    <asp:TextBox ID="txtCodigoBIP" runat="server" CssClass="content" MaxLength="8" 
                                        ReadOnly="True"></asp:TextBox>
                                &nbsp;-
                                    <asp:TextBox ID="txtParte" runat="server" CssClass="content" MaxLength="2" 
                                        ReadOnly="True" Width="48px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Descripción</td>
                                <td>
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="content" 
                                        MaxLength="250" Width="468px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="content">
                            Registros:
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                                        &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                                    </td>
                </tr>
                <tr>
                    <td>
                <asp:GridView ID="grdEtapas" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="98%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="20%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="ETAPA" HeaderText="Etapa" >
                        </asp:BoundField>
                        <asp:BoundField DataField="MONTO_ETAPA2" HeaderText="Monto Total" >
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CODIGO_BIP" HeaderText="Codigo BIP" 
                            HtmlEncode="False" />
                        <asp:BoundField DataField="PARTE" HeaderText="Parte" HtmlEncode="False" />
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción" 
                            HtmlEncode="False" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#0095d9" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#666666" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        </div>  
    </form>
</body>
</html>
