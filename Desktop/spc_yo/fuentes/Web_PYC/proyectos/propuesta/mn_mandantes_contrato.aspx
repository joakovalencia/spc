<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_mandantes_contrato.aspx.cs" Inherits="mn_mandantes_contrato" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    <script language="jscript" type="text/jscript" src="../../js/funciones.js"></script>
    
    <script language="JavaScript" type="text/JavaScript">
        <!--

        function cmdCerrarFichaProyecto_onclick() {
            window.opener = null;
            window.close();
            return false;
        }
        
        //-->
    </script>
    
    </head>
<body>
    <form id="frm_listado_proyecto" runat="server">
        
        <div id = "div_ficha_proyecto" 
            style="height: 117px; width: 650px;  background-color:White; " >
            <table style="width: 100%; border:thick solid #008BD5;">
                <tr>
                    <td colspan="2"  class="borde_celda">
                            MANDANTES DEL CONTRATO</td>
                </tr>
                <tr>
                    <td colspan="2" style=" text-align:left ">
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" 
                                ToolTip="Agregar Mandante" onclick="cmdGrabar_Click"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Eliminar Mandante" onclick="cmdEliminar_Click" />
                                <asp:Image ID="cmdCerrarDiv_ficha_proyecto" runat="server" ImageUrl="~/img/plantilla/exit.png" onclick = "javascript: cmdCerrarFichaProyecto_onclick() " style="CURSOR: pointer;" />
                                
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
                                    Datos del Contrato</td>
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
                                    Sufijo</td>
                                <td>
                            <asp:TextBox ID="txtSufijo" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="18px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Código Contrato</td>
                                <td>
                            <asp:TextBox ID="txtCodigoContrato" runat="server" CssClass="content" ReadOnly="True" 
                                Width="128px" Height="18px"></asp:TextBox>
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
                                    Mandante</td>
                                <td>
                                    <asp:DropDownList ID="ddlMandante" runat="server" CssClass="content" 
                                        Height="19px" Width="270px">
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
                    <td colspan="2">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                                    </td>
                </tr>
                <tr>
                    <td>
                <asp:GridView ID="grdMandantes" runat="server" CellPadding="4"  
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="63%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="20%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="mandante" HeaderText="Mandante" >
                        <HeaderStyle HorizontalAlign="Right" Width="80%" />
                        <ItemStyle HorizontalAlign="Right" />
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
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <br />
        </div>  
    </form>
</body>
</html>
