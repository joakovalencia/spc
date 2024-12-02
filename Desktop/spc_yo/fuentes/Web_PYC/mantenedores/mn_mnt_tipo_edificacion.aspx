<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="mn_mnt_tipo_edificacion.aspx.cs" Inherits="mn_mnt_tipo_edificacion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
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
    
    
     <script language="JavaScript" type="text/JavaScript">
         $(document).ready(function() {
         $('#grdTiposEdifi').DataTable(
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
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function valida_eliminar_comunas() 
    {
       if (confirm("¿Seguro que desea eliminar el Tipo de Edificación?"))
            return true;
        else
            return false; 
    }

    function valida_formulario() {

        if (document.frm_mnt_comunas.ddlSectorDestino == "") 
        {
            alert("Debe seleccionar el Sector Destino");
            document.frm_mnt_comunas.ddlSectorDestino.focus();
            return false;
        }

        if (document.frm_mnt_comunas.ddlSubSector.value == "") {
        
            alert("Debe seleccionar el Sub Sector.");
            document.frm_mnt_comunas.ddlSubSector.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtTopologia.value == "") {

            alert("Debe ingresar la tipología.");
            document.frm_mnt_comunas.txtProvincia.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtDescripcion.value == "") {

            alert("Debe ingresar la descripción.");
            document.frm_mnt_comunas.txtDescripcion.focus();
            return false;
        }
        
        
        if (confirm("¿Seguro que desea crear-modificar el tipo de Edificación?"))
            return true;
        else
            return false;

        return true;
    }
    //-->

</script>    
     
    <style type="text/css">
        .style1
        {
            color: #666666;
            font-family: Verdana,sans-serif;
            width: 192px;
        }
    </style>
     
</head>
<body>

<form id="frm_mnt_comunas" runat="server" submitdisabledcontrols="true">

<div class="head_principal">

<script type="text/javascript">
    function ValidNum(e) {
        var tecla = document.all ? tecla = e.keyCode : tecla = e.which;
        return ((tecla > 47 && tecla < 58) || tecla == 46);
    }
</script>

<script type="text/javascript">
     <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return true;

        return false;
    }
     //-->
  </script>
   
</div>

<div class="main_principal">
    <br />
	<table style="width:100%;">
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Mantención de Tipos de Edificación</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                <table style="WIDTH: 643px">
                    <tr>
                        <td colspan="2">
                            <asp:ImageButton ID="cmdLimpiar" runat="server" 
                                ImageUrl="~/img/plantilla/clean.png" onclick="cmdLimpiar_Click" />
                            <asp:ImageButton ID="cmdGrabar" runat="server" 
                                ImageUrl="~/img/plantilla/save.png" onclick="cmdGrabar_Click" />
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" onclick="cmdEliminar_Click" OnClientClick="return valida_eliminar_comunas();"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                                        Sector Destino</td>
                        <td class="content">
                                        <asp:DropDownList ID="ddlSectorDestino" runat="server" CssClass="content" 
                                            Height="21px" Width="60%" AutoPostBack="True" 
                                            onselectedindexchanged="ddlSectorDestino_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                    </tr>
                    <tr>
                        <td class="style1">
                                        Sub Sector</td>
                        <td class="content">
                                        <asp:DropDownList ID="ddlSubSector" runat="server" CssClass="content" 
                                            Height="21px" Width="60%" AutoPostBack="True"
                                            onselectedindexchanged="ddlSubSector_SelectedIndexChanged">
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Tipología</td>
                        <td class="content">
                            <asp:TextBox ID="txtTopologia" runat="server" CssClass="content" 
                                MaxLength="2" Width="150px"  
                                ontextchanged="txtNombre_TextChanged"></asp:TextBox>
                            </td>
                    </tr>                    
                    <tr>
                        <td class="style1">
                            Descripción</td>
                        <td class="content">
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="content" 
                                MaxLength="70" Width="150px" 
                                ontextchanged="txtNombre_TextChanged"></asp:TextBox>
                            </td>
                    </tr>                    
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                    </tr>                    
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
                    </tr>
                    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%" class="title">
                Listado de Tipos de Edificación</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                            <asp:ImageButton ID="cmdExportarExcel" runat="server" 
                                ImageUrl="~/img/plantilla/export.png" onclick="cmdExportarExcel_Click" 
                    />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                <asp:GridView ID="grdTiposEdifi" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" Width="100%" 
                                onselectedindexchanged="grdTiposEdifi_SelectedIndexChanged">                                
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />                        
                        <asp:BoundField DataField="Sector" HeaderText="Sector" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="8%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="subSector" HeaderText="Sub Sector" HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tipologia" HeaderText="Tipología" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" 
                            HtmlEncode="False" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="30%" />
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
