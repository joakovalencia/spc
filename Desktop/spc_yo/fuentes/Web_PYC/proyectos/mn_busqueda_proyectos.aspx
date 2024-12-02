<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_busqueda_proyectos.aspx.cs"
    Inherits="mn_busqueda_proyectos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />
    <title>
        <% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %>
    </title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/dataTables.min.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" type="text/css" href="../js/DataTables-1.10.20/css/jquery.dataTables.css"/>
    <link rel="stylesheet" type="text/css" href="../js/Buttons-1.6.0/css/buttons.dataTables.css"/>
    <link rel="stylesheet" type="text/css" href="../js/Scroller-2.0.1/css/scroller.dataTables.css"/>
    
    <script type="text/javascript" src="../js/jQuery-3.3.1/jquery-3.3.1.js"></script>
    <script type="text/javascript" src="../js/DataTables-1.10.20/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="../js/Buttons-1.6.0/js/dataTables.buttons.js"></script>
    <script type="text/javascript" src="../js/Buttons-1.6.0/js/buttons.colVis.js"></script>
    <script type="text/javascript" src="../js/Buttons-1.6.0/js/buttons.flash.js"></script>
    <script type="text/javascript" src="../js/Scroller-2.0.1/js/dataTables.scroller.js"></script>

    <script language="jscript" type="text/jscript" src="../js/funciones.js"></script>
    

    <script language="JavaScript" type="text/JavaScript">
        $(document).ready(function() 
        {
            $('#grdProyectos').DataTable(
            {
                "language":
                    {
                        "sProcessing": "Procesando...",
                        "sLengthMenu": "Mostrar _MENU_ registros",
                        "sZeroRecords": "No se encontraron resultados",
                        "sEmptyTable": "Ningún dato disponible en esta tabla",
                        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                        "sInfoEmpty": "No hay registros que mostrar",
                        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                        "sInfoPostFix": "",
                        "sSearch": "Buscar:",
                        "sUrl": "",
                        "sInfoThousands": ",",
                        "sLoadingRecords": "Cargando...",
                        "oPaginate": {
                            "sFirst": "Primero",
                            "sLast": "Último",
                            "sNext": "Siguiente",
                            "sPrevious": "Anterior"
                        },
                        "oAria": {
                            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                        }
                    }
            }
            );
        });

    </script>

    <style type="text/css">
        .style1
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            font-size: 28px;
            width: 933px;
        }
        
        .dataTables_filter
        {
            margin-right: 50%!important;
            font-family: Verdana;
        }     
        
        .dataTables_length , .dataTables_info , .dataTables_paginate
        {
            font-family: Verdana;
        }      
        
        
    </style>
</head>
<body>
    <form id="frm_mnt_comunas" runat="server">
    <div class="head_principal">
    </div>
    <div class="main_principal">
        <br />
        <table style="width: 100%;">
            <tr>
                <td style="width: 93px;">
                    &nbsp;
                </td>
                <td class="style1">
                    Búsqueda de proyectos, programas, estudios
                    <div class="content_small">
                        (Proyecto)</div>
                </td>
            </tr>
            <tr>
                <td style="width: 93px;">
                    &nbsp;
                </td>
                <td style="width: 933px;">
                    <table style="width: 80%" class="content">
                        <tr>
                            <td style="width: 25%">
                                &nbsp;
                            </td>
                            <td style="width: 25%">
                                &nbsp;
                            </td>
                            <td style="width: 25%">
                                <asp:Label ID="lblTabla" runat="server" Text="Tabla Proyecto" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 25%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:ImageButton ID="cmdLimpiar" runat="server" ImageUrl="~/img/plantilla/clean.png"
                                    OnClick="cmdLimpiar_Click" ToolTip="Limpiar" />
                                <asp:ImageButton ID="cmdAgregar" runat="server" ImageUrl="~/img/plantilla/add.png"
                                    OnClick="cmdAgregar_Click" ToolTip="Nuevo Proyecto" />
                                <asp:ImageButton ID="cmdBuscar" runat="server" ImageUrl="~/img/plantilla/find.png"
                                    OnClick="cmdBuscar_Click" ToolTip="Buscar Proyectos" />
                                <asp:ImageButton ID="cmdSalir" runat="server" ImageUrl="~/img/plantilla/exit.png"
                                    OnClick="cmdSalir_Click" ToolTip="Salir" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="rdProyectos" runat="server" OnCheckedChanged="rdpr_CheckedChanged"
                                    Text="Proyectos" GroupName="grpSelOpt" AutoPostBack="True" Checked="True" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rdProgramas" runat="server" OnCheckedChanged="rdP_CheckedChanged"
                                    Text="Programas" GroupName="grpSelOpt" AutoPostBack="True" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rdEstudios" runat="server" OnCheckedChanged="rdE_CheckedChanged"
                                    Text="Estudios" GroupName="grpSelOpt" AutoPostBack="True" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rdBusquedaDirecta" runat="server" OnCheckedChanged="rdE_CheckedChanged"
                                    Text="Busqueda directa" GroupName="grpSelOpt" AutoPostBack="True" />
                            </td>
                        </tr>
                        <tr>
                            
                            
                            <td>
                                <asp:RadioButton ID="rdConvenioscol" runat="server" OnCheckedChanged="rdE_CheckedChanged"
                                    Text="Convenios de Colaboración" GroupName="grpSelOpt" AutoPostBack="True" />
                              
                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                Desde
                            </td>
                            <td>
                                Hasta
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Regiones
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRegDesde" runat="server" CssClass="content" Font-Size="X-Small"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlRegHasta" runat="server" CssClass="content" Font-Size="X-Small"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RadioButton ID="rdContrato" runat="server" OnCheckedChanged="rdE_CheckedChanged"
                                    Text="Contrato" GroupName="grpBD" Checked="True" CssClass="content_small" />
                                &nbsp;<asp:RadioButton ID="rdProyecto" runat="server" OnCheckedChanged="rdE_CheckedChanged"
                                    Text="Código PIA" GroupName="grpBD" CssClass="content_small" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Estados
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEstDesde" runat="server" CssClass="content" Font-Size="X-Small"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlEstHasta" runat="server" CssClass="content" Font-Size="X-Small"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBusquedaDirecta" runat="server" MaxLength="15" CssClass="content"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Procesos
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProDesde" runat="server" CssClass="content" Font-Size="X-Small"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProHasta" runat="server" CssClass="content" Font-Size="X-Small"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="width: 93px;">
                    &nbsp;
                </td>
                <td style="width: 933px;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 93px;">
                    &nbsp;
                </td>
                <td class="style1">
                    Proyectos Existentes
                </td>
            </tr>
            <tr>
                <td style="width: 93px;">
                    &nbsp;
                </td>
                <td style="width: 933px;">
                    <asp:ImageButton ID="cmdExportarExcel" runat="server" ImageUrl="~/img/plantilla/export.png"
                        OnClick="cmdExportarExcel_Click" Visible="False" />
                    <asp:Label ID="lblCantRegistros" runat="server" CssClass="content"></asp:Label>
                    <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 93px;">
                    &nbsp;
                </td>
                <td style="width: 933px;">
                    <asp:GridView ID="grdProyectos" runat="server" CellPadding="4" 
                        AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333"
                        AllowSorting="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:HyperLinkField DataNavigateUrlFields="url_proyecto" HeaderText="Selección" Text="Selección"
                                ControlStyle-ForeColor="#284775">
                                <ControlStyle ForeColor="#284775"></ControlStyle>
                                <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                <ItemStyle Width="7%" HorizontalAlign="Center" />
                            </asp:HyperLinkField>
                            <asp:BoundField DataField="Region" HeaderText="Región">
                                <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="pia" HeaderText="PIA">
                                <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="proceso" HeaderText="Proceso">
                                <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="estado" HeaderText="Estado">
                                <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="financiamiento" HeaderText="Financ.">
                                <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="comuna" HeaderText="Comuna">
                                <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                <ItemStyle Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DESC_PROYECTO" HeaderText="Descripción Proyecto">
                                <HeaderStyle Width="25%" />
                                <ItemStyle Width="40%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CODIGO_PROYECTO_EXP" HeaderText="Codigo Proyecto (Exploratorio)">
                                <HeaderStyle Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CODIGO_BIP" HeaderText="Codigo BIP" />
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
                    &nbsp;
                </td>
                <td style="width: 933px;">
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
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
