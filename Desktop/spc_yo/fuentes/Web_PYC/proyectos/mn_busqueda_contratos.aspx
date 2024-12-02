<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_busqueda_contratos.aspx.cs" Inherits="mn_busqueda_contratos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
    <!--
        
    //-->

</script>    

    
    </head>
<body>

<form id="frm_proyectos_contratos_rel" runat="server">

<div class="head_principal">
   
</div>

<div class="main_principal">

    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td class="title">
                <asp:Label ID="lblTipoProyecto" runat="server"></asp:Label>&nbsp;y Contratos Relacionados <div class="content_small">(Contrato)</div></td>
        </tr>
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td style="width: 933px;">
                <table style="WIDTH: 843px">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdDetalleProyecto" runat="server" 
                                ImageUrl="~/img/plantilla/find.png" 
                                ToolTip="Detalle Proyecto" onclick="cmdDetalleProyecto_Click"/>
                            <asp:ImageButton ID="cmdAgregar" runat="server" 
                                ImageUrl="~/img/plantilla/add.png" onclick="cmdAgregar_Click" 
                                ToolTip="Nuevo Contrato"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                        &nbsp;<asp:Label ID="lblTabla" runat="server" Text="Tabla Contrato" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="borde_celda" colspan="2">
                            Datos de Proyecto</td>
                    </tr>
                    <tr>
                        <td class="content">
                            Región</td>
                        <td class="content">
                            <asp:TextBox ID="txtRegion" runat="server" CssClass="content" ReadOnly="True" 
                                Width="51px" Height="18px"></asp:TextBox>
                        &nbsp;PIA
                            <asp:TextBox ID="txtPIA" runat="server" CssClass="content" ReadOnly="True" 
                                Width="50px" Height="18px"></asp:TextBox>
                        &nbsp;Proceso
                            <asp:TextBox ID="txtProceso" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                        &nbsp;Tipo
                            <asp:TextBox ID="txtTipoProyecto" runat="server" CssClass="content" ReadOnly="True" 
                                Width="70px" Height="18px"></asp:TextBox>
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="content">
                            Código Proyecto
                            <br />
                            Exploratorio</td>
                        <td class="content">
                            <asp:TextBox ID="txtCodigoExploratorio" runat="server" CssClass="content" ReadOnly="True" 
                                Width="110px" Height="18px"></asp:TextBox>
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
                    <tr>
                        <td class="style4">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                    </tr>
                    </table>
            </td>
        </tr>
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td style="width: 933px;">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
        </tr>
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td style="width: 933px;">
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 93px;">
                &nbsp;</td>
            <td style="width: 933px;">
   
                <asp:GridView ID="grdContratos" runat="server" CellPadding="4"  
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="98%" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:HyperLinkField DataNavigateUrlFields="url_edicion" 
                            HeaderText="Editar Registro" Text="Editar" 
                            ControlStyle-ForeColor="#284775" 
                            HeaderImageUrl="~/img/plantilla/save_small.png">
                        <ControlStyle ForeColor="#284775"></ControlStyle>
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:BoundField DataField="cod_con" HeaderText="Codigo Contrato">
                        <HeaderStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Correlativo Convenio" 
                            DataField="correlativo_convenio" >
                            <HeaderStyle Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Mandante" DataField="mandante" >
                            <HeaderStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Etapa" DataField="ETAPA" >
                            <HeaderStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Sufijo" DataField="SUFIJO" >
                            <HeaderStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Proceso" DataField="TIPO_PROCESO" >
                            <HeaderStyle Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Financ." DataField="financimianeto" >
                            <HeaderStyle Width="5%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Objeto" DataField="objeto" >
                            <HeaderStyle Width="27%" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Situación" DataField="situacion" >
                            <HeaderStyle Width="10%" />
                        </asp:BoundField>
                        <asp:HyperLinkField DataNavigateUrlFields="url_datos" Text="Datos" 
                            ControlStyle-ForeColor="#284775" 
                            HeaderImageUrl="~/img/plantilla/save_small.png" HeaderText="Ver Datos" >
<ControlStyle ForeColor="#284775"></ControlStyle>
                        <HeaderStyle Width="5%" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField DataNavigateUrlFields="url_propuesta" Text="Propuesta" 
                            ControlStyle-ForeColor="#284775" 
                            HeaderImageUrl="~/img/plantilla/save_small.png" HeaderText="Ver Propuesta" >
<ControlStyle ForeColor="#284775"></ControlStyle>
                        <HeaderStyle Width="7%" />
                        </asp:HyperLinkField>
                        <asp:HyperLinkField DataNavigateUrlFields="url_contrato" Text="Contrato" 
                            ControlStyle-ForeColor="#284775" 
                            HeaderImageUrl="~/img/plantilla/save_small.png" HeaderText="Ver Contrato" >
<ControlStyle ForeColor="#284775"></ControlStyle>
                        <HeaderStyle Width="7%" />
                        </asp:HyperLinkField>
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
            <td style="width: 93px;">
                &nbsp;</td>
            <td style="width: 933px;">
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
