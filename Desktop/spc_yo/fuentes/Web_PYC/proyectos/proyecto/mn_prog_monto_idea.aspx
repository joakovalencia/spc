<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_prog_monto_idea.aspx.cs" Inherits="proyecto_mn_prog_monto_idea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />    
    <script language="jscript" type="text/jscript" src="../../js/funciones.js"></script>
    
    <script language="JavaScript" type="text/JavaScript">

        function format(input) {
            var num = input.value.replace(/\./g, '');
            if (!isNaN(num)) {
                num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
                num = num.split('').reverse().join('').replace(/^[\.]/, '');
                input.value = num;
            }

            else {
                alert('Solo se permiten numeros');
                input.value = input.value.replace(/[^\d\.]*/g, '');
            }
        }

        function func_valida_eliminar() {

            if (document.frm_programacion.txtRegion.value == "") {
                alert("Debe ingresar región.");
                document.frm_programacion.txtRegion.focus();
                return false;
            }

            if (document.frm_programacion.txtPIA.value == "") {
                alert("Debe ingresar PIA.");
                document.frm_programacion.txtPIA.focus();
                return false;
            }

            if (document.frm_programacion.txtMonto.value == "") {
                alert("Debe ingresar Monto.");
                document.frm_programacion.txtMonto.focus();
                return false;
            }

            if (confirm("¿Seguro que desea eliminar este registro?"))
                return true;
            else
                return false;
        }

        function func_valida_grabar() {

            if (document.frm_programacion.txtRegion.value == "") {
                alert("Debe ingresar región.");
                document.frm_programacion.txtRegion.focus();
                return false;
            }

            if (document.frm_programacion.txtPIA.value == "") {
                alert("Debe ingresar PIA.");
                document.frm_programacion.txtPIA.focus();
                return false;
            }

            if (document.frm_programacion.txtMonto.value == "") {
                alert("Debe ingresar Monto.");
                document.frm_programacion.txtMonto.focus();
                return false;
            }

            if (confirm("¿Seguro que desea guardar los datos?"))
                return true;
            else
                return false;
        }

        //function cmdCerrarFichaProyecto_onclick() {
         //   window.opener = null;
         //   window.close();
         //   return false;
       // }
        
    </script>
    
    </head>
<body>
    <form id="frm_programacion" runat="server">
        
        <div id = "div_ficha_proyecto" 
            style="height: 117px; width: 650px;  background-color:White; " >
            <table style="width: 100%; border:thick solid #008BD5;">
                <tr>
                    <td colspan="2"  class="borde_celda" >
                            PROGRAMACIÓN MONTO IDEA</td>
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
                                    Programación Monto Anual</td>
                            </tr>
                            <tr>
                                <td>
                                    Año</td>
                                <td>
                                    <asp:DropDownList ID="ddlagno" runat="server" CssClass="content" 
                                        Height="19px" Width="100px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Monto</td>
                                <td>
                                    <asp:TextBox ID="txtMonto" runat="server" CssClass="content" 
                                        MaxLength="19"  onkeyup="format(this)" onchange="format(this)" Width="175px"></asp:TextBox>
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
                            <asp:GridView ID="grdProgramacionMonto" runat="server" CellPadding="4"  
                                AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                                Width="98%" onselectedindexchanged="grdInspector_SelectedIndexChanged" 
                                        EnableModelValidation="True" HorizontalAlign = "Right"
                                onrowdatabound="grdProgramacionMonto_RowDataBound" ShowFooter="True" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                                    <HeaderStyle Width="20%" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="AGNO" HeaderText="Año" >
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MONTO" HeaderText="Monto" >
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" HorizontalAlign="Right"/>
                                <HeaderStyle BackColor="#0095d9" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#666666" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            </asp:GridView>
                    </td>
                    <td></td>
                </tr>
            </table>
            <br />
        </div>  
    </form>
</body>
</html>
