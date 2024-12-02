<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_mnt_ImagenesContratos.aspx.cs" Inherits="mantenedores_mn_mnt_ImagenesContratos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    
    <script type="text/javascript" >

        function validaCodPro() {
            if (document.frm_mnt_ImagenesContratos.txtCodCon.value == "") {
                alert("Debe ingresar codigo de contrato");
                return false;
            }

            return true;
        }
    
    </script>
        
    </head>
<body>

<form id="frm_mnt_ImagenesContratos" runat="server" style="position:relative;">

<div class="head_principal">
   
</div>

<div class="main_principal">
 <br />
 
    <table style=" width:100% ">
        <tr>
            <td style=" width:20% ">
                &nbsp;</td>
            <td style=" width:60% ">
                &nbsp;</td>
            <td style=" width:20% ">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="title">
                Mantención de Imagenes<br />
                <div class="content_small">(Ficha Proyecto/Reporte Patrimonio)</div>                
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                            <asp:ImageButton ID="cmdLimpiar" runat="server" 
                                ImageUrl="~/img/plantilla/clean.png" onclick="cmdLimpiar_Click" />
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" onclick="cmdGrabar_Click" OnClientClick="javascript:return validaCodPro();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="javascript:return validaCodPro();"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" />    
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
            <center>
                <asp:Label ID="Label5" runat="server" Font-Size="Small" ForeColor="Red" 
                    Text="SOLO IMAGENES EXENCION JPG"></asp:Label>
            </center>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <table style=" width:100% " class=" content ">
                    <tr>
                        <td style=" width:30% ">
                            &nbsp;</td>
                        <td style=" width:70% ">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            Código Contrato</td>
                        <td>
                            <asp:TextBox ID="txtCodCon" runat="server" Width="180px" TabIndex="1" 
                                CssClass="content"></asp:TextBox>
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
                    <tr>
                        <td>
                            Imagen Ficha Proyecto</td>
                        <td>
                             <asp:FileUpload  ID="fuImgProyecto" runat="server" CssClass="content" />
                             <br />
                             <asp:Label ID="Label1" runat="server" Font-Size="XX-Small" ForeColor="Red" 
                                 Text="Tamaño: 20cm; 10cm o 755,9 px;  377,9 px"></asp:Label>
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
                            Imagen N° 1 Reporte Patrimonio</td>
                        <td>
                    
                     <asp:FileUpload ID="fuImgPatri1" runat="server" CssClass="content" />
                            <br />
                            <asp:Label ID="Label2" runat="server" Font-Size="XX-Small" ForeColor="Red" 
                                Text="Tamaño: 20cm; 10cm o 755,9 px;  377,9 px"></asp:Label>
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
                            Imagen N° 2 Reporte Patrimonio</td>
                        <td>
                             <asp:FileUpload ID="fuImgPatri2" runat="server" CssClass="content" />
                             <br />
                             <asp:Label ID="Label3" runat="server" Font-Size="XX-Small" ForeColor="Red" 
                                 Text="Tamaño: 20cm; 10cm o 755,9 px;  377,9 px"></asp:Label>
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
                            Imagen N° 3 Reporte Patrimonio</td>
                        <td>
                             <asp:FileUpload ID="fuImgPatri3" runat="server" CssClass="content" />
                             <br />
                             <asp:Label ID="Label4" runat="server" Font-Size="XX-Small" ForeColor="Red" 
                                 Text="Tamaño: 20cm; 10cm o 755,9 px;  377,9 px"></asp:Label>
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
            <td>
                &nbsp;</td>
            <td>
                    <asp:Label ID="lblTituloImgExistentes" runat="server" CssClass="title" 
                        Text="Imagenes Contratos"></asp:Label>
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
            <td align="center" colspan="3">
                   <asp:GridView ID="grdImagenes" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="80%" onselectedindexchanged="grdImagenes_SelectedIndexChanged" 
                                >                                
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                        <asp:BoundField DataField="cod_con" HeaderText="Codigo Contrato" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="7%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="codigo_da" HeaderText="Codigo Proyecto" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="8%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="imagen_ficha_proyecto" HeaderText="Ruta Ficha Proyecto"   > 
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />    
                        </asp:BoundField>
                            
                        <asp:BoundField DataField="imagen_reporte_patrimonio1" HeaderText="Ruta Patrimonio 1" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                           
                        <asp:BoundField DataField="imagen_reporte_patrimonio2" HeaderText="Ruta Patrimonio 2" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                            
                        <asp:BoundField DataField="imagen_reporte_patrimonio3" HeaderText="Ruta Patrimonio 3"  >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                            
                        <asp:BoundField DataField="nombImgFichaProyecto" HeaderText="Imagen Ficha Proyecto" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="nombImgPatrimonio1" HeaderText="Imagen N°1 Reporte Patrimonio" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="nombImgPatrimonio2" HeaderText="Imagen N°2 Reporte Patrimonio" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="nombImgPatrimonio3" HeaderText="Imagen N°3 Reporte Patrimonio" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="20%" />
                        </asp:BoundField>
                        
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#0095d9" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#666666" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
 
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
