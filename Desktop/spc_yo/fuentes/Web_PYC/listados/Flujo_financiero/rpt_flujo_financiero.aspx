<%@ Page Language="VB" AutoEventWireup="false" CodeFile="rpt_flujo_financiero.aspx.vb" Inherits="listados_Flujo_financiero_rpt_flujo_financiero" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function valida_eliminar_comunas() 
    {
       if (confirm("¿Seguro que desea eliminar la Comuna?"))
            return true;
        else
            return false; 
    }

    function valida_formulario() {

        if (document.frm_mnt_comunas.txtNombre.value == "") 
        {
            alert("Debe ingresar el nombre de la Comuna.");
            document.frm_mnt_comunas.txtNombre.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtRegion.value == "") {
        
            alert("Debe ingresar el nombre de la Region.");
            document.frm_mnt_comunas.txtRegion.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtProvincia.value == "") {

            alert("Debe ingresar el nombre de la Provincia.");
            document.frm_mnt_comunas.txtProvincia.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtNumComuna.value == "") {

            alert("Debe ingresar el nombre de la Numero de Comuna.");
            document.frm_mnt_comunas.txtNumComuna.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtCodigoComuna.value == "") {
            alert("Debe ingresar el nombre de la Comuna.");
            document.frm_mnt_comunas.txtCodigoComuna.focus();
            return false;
        }

        if (document.frm_mnt_comunas.txtPoblacion.value == "") 
        {
            alert("Debe ingresar el nombre de la Comuna.");
            document.frm_mnt_comunas.txtPoblacion.focus();
            return false;
        }
        
        if (confirm("¿Seguro que desea crear-modificar Comuna?"))
            return true;
        else
            return false;

        return true;
    }
    //-->

</script>    
     
    <style type="text/css">
        .style2
        {
            height: 28px;
            width: 268px;
        }
        .style3
        {
            height: 25px;
        }
        .style4
        {
            width: 20%;
            height: 29px;
        }
        .style5
        {
            width: 60%;
            height: 29px;
        }
        .style6
        {
            height: 29px;
        }
        .style7
        {
            width: 268px;
        }
        .style8
        {
            width: 268px;
            color: #3399FF;
            font-weight: bold;
            font-family: "Arial Black";
            font-style: italic;
            text-decoration: underline;
        }
        .style9
        {
            height: 25px;
            color: #3399FF;
            font-weight: bold;
            font-family: "Arial Black";
            font-style: italic;
        }
    </style>
     
</head>
<body>

<form id="frm_mnt_comunas" runat="server">

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
            <td style="width: 60%" class="style3">
                &nbsp;</td>
            <td style="width: 60%" class="style9">
                &nbsp;</td>
            <td style="width: 60%; line-height: inherit;" class="style8">
                AVANCE Y ESTIMACIÓN DE INVERSIÓN VIGENTE</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
            <td style="width: 60%">
                <table style="WIDTH: 643px">
                    <tr>
                        <td class="style7">
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Label ID="lblError" runat="server" ForeColor="#C00000"></asp:Label>
                        </td>
                    </tr>
                    </table>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                </td>
            <td class="style5">
                </td>
            <td class="style5">
                </td>
            <td class="style5">
                </td>
            <td class="style6">
                </td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                          
                            &nbsp;</td>
            <td style="width: 60%">
                          
                            &nbsp;</td>
            <td style="width: 60%">
                          
                            <asp:Button ID="CMD_DESCARGAR" runat="server" 
                                Text="¿Descargar información a Excel ?" Width="325px" Visible="False" 
                                BackColor="#009933" BorderColor="White" 
                                style="font-family: 'Arial Black'; color: #FFFFFF; font-style: italic" />
            </td>
           
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 20%">
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
            <td style="width: 60%">
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
                &nbsp;</td>
            <td style="width: 60%">
                &nbsp;</td>
            <td style="width: 60%">
                <asp:GridView ID="grdFlujoFinanaciero" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="100%" EnableViewState="False">                                
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <Columns>
                        <asp:BoundField DataField="OBS_CONTRATOS" HeaderText="OBSERVACION" />
                        <asp:BoundField DataField="CODIGO_BIP" HeaderText="BIP" />
                        <asp:BoundField DataField="CODIGO_PROYECTO_EXP" 
                            HeaderText="EXPLORATORIO" />
                        <asp:BoundField DataField="NOMBRE_PROY" HeaderText="NOMBRE PROYECTO" />
                        <asp:BoundField DataField="REGION" HeaderText="REGION" 
                            SortExpression="REGION" />
                        <asp:BoundField DataField="COD_CON" HeaderText="CODIGO CONTRATO" 
                            SortExpression="COD_CON" />
                        <asp:BoundField DataField="NOMBRE_CONTRATO" HeaderText="NOMBRE CONTRATO" 
                            SortExpression="NOMBRE_CONTRATO" />
                        <asp:BoundField DataField="ESTATUS" HeaderText="ESTADO" 
                            SortExpression="ESTATUS" />
                        <asp:BoundField DataField="FECHA_LICITACION" HeaderText="LICITACION" 
                            SortExpression="FECHA_LICITACION" />
                        <asp:BoundField DataField="F_APERTURA_TECNICA" HeaderText="APERTURA TÉCNICA" 
                            SortExpression="F_APERTURA_TECNICA" />
                        <asp:BoundField DataField="F_APERTURA_ECONOMICA" 
                            HeaderText="APERTURA ECONÓMICA" SortExpression="F_APERTURA_ECONOMICA" />
                        <asp:BoundField DataField="F_INICIO" HeaderText="INICIO" 
                            SortExpression="F_INICIO" />
                        <asp:BoundField DataField="F_TERMINO" HeaderText="TERMINO" 
                            SortExpression="F_TERMINO" />
                        <asp:BoundField DataField="MONTO_VIGENTE" HeaderText="MONTO VIGENTE" 
                            SortExpression="MONTO_VIGENTE" />
                        <asp:BoundField DataField="INV_ANTERIOR" HeaderText="INVERSIÓN ANTERIOR" 
                            SortExpression="INV_ANTERIOR" />
                        
                        <asp:BoundField DataField="INV_AÑO_ANTERIOR" HeaderText="INV AÑO ANTERIOR" 
                            SortExpression="INV_AÑO_ANTERIOR" />
                        
                        <asp:BoundField DataField="ENERO" HeaderText="ENERO" SortExpression="ENERO" />
                        <asp:BoundField DataField="FEBRERO" HeaderText="FEBRERO" 
                            SortExpression="FEBRERO" />
                        <asp:BoundField DataField="MARZO" HeaderText="MARZO" SortExpression="MARZO" />
                        <asp:BoundField DataField="ABRIL" HeaderText="ABRIL" SortExpression="ABRIL" />
                        <asp:BoundField DataField="MAYO" HeaderText="MAYO" SortExpression="MAYO" />
                        <asp:BoundField DataField="JUNIO" HeaderText="JUNIO" SortExpression="JUNIO" />
                        <asp:BoundField DataField="JULIO" HeaderText="JULIO" SortExpression="JULIO" />
                        <asp:BoundField DataField="AGOSTO" HeaderText="AGOSTO" 
                            SortExpression="AGOSTO" />
                        <asp:BoundField DataField="SEPTIEMBRE" HeaderText="SEPTIEMBRE" 
                            SortExpression="SEPTIEMBRE" />
                        <asp:BoundField DataField="OCTUBRE" HeaderText="OCTUBRE" 
                            SortExpression="OCTUBRE" />
                        <asp:BoundField DataField="NOVIEMBRE" HeaderText="NOVIEMBRE" 
                            SortExpression="NOVIEMBRE" />
                        <asp:BoundField DataField="DICIEMBRE" HeaderText="DICIEMBRE" 
                            SortExpression="DICIEMBRE" />
                        <asp:BoundField DataField="TOTALAGNOACTUAL" HeaderText="ESTIMADO INVERTIR AÑO" 
                            SortExpression="TOTALAGNOACTUAL" >
                            <ControlStyle BackColor="#009933" />
                            <HeaderStyle BackColor="#33CC33" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AGNAOSIGUIENTE" HeaderText="ESTIMADO AÑO SIGUIENTE" 
                            SortExpression="AGNAOSIGUIENTE" />
                        <asp:BoundField DataField="AGNOSUBSIGUIENTE" HeaderText="ESTIMADO AÑO SUB SIGUIENTE" 
                            SortExpression="AGNOSUBSIGUIENTE" />
                        <asp:BoundField DataField="AGNOSUBSIGUIENTE2" HeaderText="ESTIMADO AÑO SIGUIENTE2" 
                            SortExpression="AGNOSUBSIGUIENTE2" />
                        <asp:BoundField DataField="SALDOOTROSAGNOS" HeaderText="SALDO OTROS AÑOS" 
                            SortExpression="SALDOOTROSAGNOS" />
                        <asp:BoundField DataField="IVERSIONTOTAL" HeaderText="IVERSIONTOTAL" 
                            SortExpression="IVERSIONTOTAL" />
                        <asp:BoundField DataField="INVERSION_AÑO" HeaderText="INVERTIDO AÑO" 
                            SortExpression="INVERSION_AÑO" />
                        <asp:BoundField DataField="MES_EN_CURSO" HeaderText="PAGO EN CURSO" 
                            SortExpression="MES_EN_CURSO" />
                        
                        <asp:BoundField DataField="AV_FINANCIERO" HeaderText="AV_FINANCIERO" 
                            SortExpression="AV_FINANCIERO" />
                        <asp:BoundField DataField="AV_FIS_ACUM" HeaderText="AV_FIS_ACUM" 
                            SortExpression="AV_FIS_ACUM" />
                        
                        <asp:BoundField DataField="ETAPA" HeaderText="ETAPA" SortExpression="ETAPA" />
                        
                        <asp:BoundField DataField="MANDANTE" HeaderText="MANDANTE" 
                            SortExpression="MANDANTE" />
                        <asp:BoundField DataField="FINANCIAMIENTO" HeaderText="FINANCIAMIENTO" 
                            SortExpression="FINANCIAMIENTO" />
                        <asp:BoundField DataField="COMUNA" HeaderText="COMUNA" 
                            SortExpression="COMUNA" />
                        <asp:BoundField DataField="TIPO_PROCESO" HeaderText="TIPO_PROCESO" 
                            SortExpression="TIPO_PROCESO" />
                        <asp:BoundField DataField="TIPO_CONTRATACION" HeaderText="TIPO DE CONTRATACION" 
                            SortExpression="TIPO_CONTRATACION" />
                        <asp:BoundField DataField="SECTOR_DESTINO" HeaderText="SECTOR_DESTINO" 
                            SortExpression="SECTOR_DESTINO" />
                        <asp:BoundField DataField="SUB_SECTOR" HeaderText="SUB_SECTOR" 
                            SortExpression="SUB_SECTOR" />
                        <asp:BoundField DataField="TIPO_EDIFICACION" HeaderText="TIPO_EDIFICACION" 
                            SortExpression="TIPO_EDIFICACION" />
                        <asp:BoundField DataField="R_CTTA" HeaderText="RUT CONTRATISTA" 
                            SortExpression="R_CTTA" />
                        <asp:BoundField DataField="CONTRATISTA" HeaderText="CONTRATISTA/CONSULTOR" 
                            SortExpression="CONTRATISTA" />
                        <asp:BoundField DataField="ID_MERCADO_PUBLICO" HeaderText="MERCADO PÚBLICO" 
                            SortExpression="ID_MERCADO_PUBLICO" />
                    </Columns>
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