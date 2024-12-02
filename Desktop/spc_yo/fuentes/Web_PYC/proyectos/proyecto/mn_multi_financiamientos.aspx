<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_multi_financiamientos.aspx.cs" Inherits="mn_multi_financiamientos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    <script language="JavaScript" type="text/JavaScript">
        <!--

        function cmdCerrarFichaProyecto_onclick() {
            window.opener = null;
            window.close();
            return false;
        }

        function func_valida_grabar() {

            if (document.frm_mandantes.txtRegion.value == "") {
                alert("Debe ingresar región.");
                document.frm_mandantes.txtRegion.focus();
                return false;
            }

            if (document.frm_mandantes.txtPIA.value == "") {
                alert("Debe ingresar PIA.");
                document.frm_mandantes.txtPIA.focus();
                return false;
            }

            if (document.frm_mandantes.ddlFinanciamiento.value == "(SELECCIONAR)") {
                alert("Debe seleccionar financiamiento.");
                document.frm_mandantes.ddlFinanciamiento.focus();
                return false;
            }

            if (confirm("¿Seguro que desea guardar este financiamiento?"))
                return true;
            else
                return false;
        }

        function func_valida_eliminar() {

            if (document.frm_mandantes.txtRegion.value == "") {
                alert("Debe ingresar región.");
                document.frm_mandantes.txtRegion.focus();
                return false;
            }

            if (document.frm_mandantes.txtPIA.value == "") {
                alert("Debe ingresar PIA.");
                document.frm_mandantes.txtPIA.focus();
                return false;
            }

            if (document.frm_mandantes.ddlFinanciamiento.value == "(SELECCIONAR)") {
                alert("Debe seleccionar financiamiento.");
                document.frm_mandantes.ddlFinanciamiento.focus();
                return false;
            }

            if (confirm("¿Seguro que desea eliminar este financiamiento?"))
                return true;
            else
                return false;
        }
        
        //-->
    </script>
    
    </head>
<body>
    <form id="frm_mandantes" runat="server">
        
        <div id = "div_ficha_proyecto" 
            style="height: 117px; width: 650px;  background-color:White; " >
            <table style="width: 100%; border:thick solid #008BD5;">
                <tr>
                    <td colspan="2" class="borde_celda"  >
                            MULTIPLES FINANCIAMIENTOS</td>
                </tr>
                <tr>
                    <td colspan="2" style=" text-align:left ">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Agregar Mandante" onclick="cmdGrabar_Click" OnClientClick="return func_valida_grabar();" />
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Eliminar Mandante" onclick="cmdEliminar_Click" OnClientClick="return func_valida_eliminar();"/>
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
                                    Selección Financiamiento</td>
                            </tr>
                            <tr>
                                <td>
                                    Financ.</td>
                                <td>
                                    <asp:DropDownList ID="ddlFinanciamiento" runat="server" CssClass="content" 
                                        Height="21px" Width="270px">
                                    </asp:DropDownList>
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
                            Registros:<asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                                        &nbsp;<asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                <asp:GridView ID="grdFinanciamiento" runat="server" CellPadding="4"  
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="95%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="20%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="codigo" HeaderText="Financiamiento" >
                        <HeaderStyle Width="40%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripción">
                        <HeaderStyle Width="40%" />
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
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        </div>  
    </form>
</body>
</html>
