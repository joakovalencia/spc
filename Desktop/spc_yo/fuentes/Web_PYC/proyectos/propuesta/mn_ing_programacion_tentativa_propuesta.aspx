<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_ing_programacion_tentativa_propuesta.aspx.cs" Inherits="mn_ing_programacion_tentativa_propuesta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    <link href="../../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    <script language="jscript" type="text/jscript" src="../../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
<!--

    function func_msg_salir() {

        intSaldo = FUNC_MontoASPv2(document.frm_datos_contrato.txtTotalesPorc.value);

        if (intSaldo != "100.00") {
            alert("El porcentaje financiero inicial indica " + intSaldo + "%, y debe ser 100%");
        }

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

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlAno.value == "") {
            alert("Debe ingresar año.");
            document.frm_datos_contrato.ddlAno.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlMes.value == "") {
            alert("Debe ingresar mes.");
            document.frm_datos_contrato.ddlMes.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPorc.value == "") {
            alert("Debe ingresar porcentaje.");
            document.frm_datos_contrato.txtPorc.focus();
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

        if (document.frm_datos_contrato.txtCodCon.value == "") {
            alert("Debe ingresar codigo contrato.");
            document.frm_datos_contrato.txtCodCon.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlAno.value == "") {
            alert("Debe ingresar año.");
            document.frm_datos_contrato.ddlAno.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlMes.value == "") {
            alert("Debe ingresar mes.");
            document.frm_datos_contrato.ddlMes.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtPorc.value == "") {
            alert("Debe ingresar porcentaje.");
            document.frm_datos_contrato.txtPorc.focus();
            return false;
        }

        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;

    }
    
    //-->

</script>    

    <style type="text/css">
        .style1
        {
            height: 57px;
        }
        .style3
        {
            width: 309px;
        }
        .style4
        {
            width: 36%;
        }
    </style>

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
                Modificación Programación Tentativa Propuesta <div class="content_small">(Programación_Tentativa)</div></td>
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
                                ToolTip="Modifica Programación Financiera del Contrato " onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                            <asp:ImageButton ID="cmdEliminar" runat="server" 
                                ImageUrl="~/img/plantilla/delete.png" 
                                ToolTip="Modifica Programación Financiera del Contrato" 
                                OnClientClick="return func_valida_eliminar();" 
                                onclick="cmdEliminar_Click"/>
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                OnClientClick="return func_msg_salir();" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla PROGRAMA_PROPUESTA" 
                                Visible="False"></asp:Label>
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
                    <tr>
                        <td class="content">
                            &nbsp;</td>
                        <td class="content">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="content">
                            &nbsp;</td>
                        <td class="content">
                            <table width="100%">
                                <tr>
                                    <td width="20%">
                                        &nbsp;</td>
                                    <td width="80%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Presupuesto Estimado</td>
                                    <td>
                            <asp:TextBox ID="txtMontoVigente" runat="server" CssClass="content" ReadOnly="True" 
                                Width="25%" Height="18px"></asp:TextBox>
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
                                    <td style="width: 30%">
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                   
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda" >
                                        Edición Programación</td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="style1">
                                        Año
                                        &nbsp;<asp:DropDownList ID="ddlAno" runat="server" CssClass="content" 
                                            BackColor="#CCFFCC" Height="18px">
                                        </asp:DropDownList>
                                         &nbsp;Mes
                                        <asp:DropDownList ID="ddlMes" runat="server" CssClass="content" TabIndex="1" 
                                            BackColor="#CCFFCC" Height="18px">
                                        </asp:DropDownList>
                                        &nbsp; %
                                        <asp:TextBox ID="txtPorc" runat="server" CssClass="content" 
                                         Width="60px" Height="18px" MaxLength="5" TabIndex="2" BackColor="#CCFFCC"></asp:TextBox>
                                       
                                        
                                        Fondo<asp:DropDownList ID="ddlFondo" runat="server" Height="18px" Width="195px" 
                                            BackColor="#CCFFCC" TabIndex="3">
                                        </asp:DropDownList>
                                       
                                        
                                    </td>
                                </tr>
                               <tr>
                               <!-- <td>
                                &nbsp;
                                </td>-->
                                <td>                       
                                        <asp:Label ID="Label1" runat="server" Text="Mano de obra calificada "></asp:Label>
                                        <asp:TextBox ID="txtMOC" runat="server" Width="60px" MaxLength="5" TabIndex="6" 
                                            BackColor="#CCFFCC">0</asp:TextBox>
                                        <td class="style4"> 
                                        <asp:Label ID="Label2" runat="server" Text=" Mano de obra semicalificada "></asp:Label>
                                        <asp:TextBox ID="txtMOSC" runat="server" Width="60px" MaxLength="5" TabIndex="5" 
                                                BackColor="#CCFFCC">0</asp:TextBox>
                                        </td>
                                        <td class="style3"> 
                                        <asp:Label ID="Label3" runat="server" Text="Mano de obra no calificada "></asp:Label>
                                        <asp:TextBox ID="txtMONC" runat="server" Width="60px" MaxLength="5" TabIndex="6" 
                                                BackColor="#CCFFCC">0</asp:TextBox>
                                        </td>
                                </td>
  </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style4">
                                        &nbsp;</td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        Programación Tentativa Propuesta Vigente
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                <asp:GridView ID="grdPrograma" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="99%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="10%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="FONDO" HeaderText="Fondo" SortExpression="FONDO" />
                        <asp:BoundField DataField="AGNO" HeaderText="Año" >
                        <HeaderStyle HorizontalAlign="Right" Width="10%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MES" HeaderText="Mes" >
                        <HeaderStyle HorizontalAlign="Right" Width="10%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MONTO_PROG" HeaderText="%" >
                        <HeaderStyle HorizontalAlign="Right" Width="10%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Principales" DataField="MTOPESOS" >
                        <HeaderStyle Width="20%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="%" DataField="MONTO_PROG_ACUM" >
                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Acumulados" DataField="MTOPESOSACUM" >
                        <HeaderStyle Width="20%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MANO_DE_OBRA_CALIFICADA" 
                            HeaderText="Mano de obra Calificada" SortExpression="MANO_DE_OBRA_CALIFICADA" />
                        <asp:BoundField DataField="MANO_DE_OBRA_SEMI_CALIFICADA" 
                            HeaderText="Mano de obra Semicalificada" 
                            SortExpression="MANO_DE_OBRA_SEMI_CALIFICADA" />
                        <asp:BoundField DataField="MANO_DE_OBRA_NO_CALIFICADA" 
                            HeaderText="Mano de obra no calificada" 
                            SortExpression="MANO_DE_OBRA_NO_CALIFICADA" />
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
                                    <td style="text-align: right">
                                        Totales&nbsp;%&nbsp;                                     
                                    </td>
                                    <td class="style4">
                                        <asp:TextBox ID="txtTotalesPorc" runat="server" CssClass="content" 
                                            ReadOnly="True" style=" text-align:right;" Width="24%" Height="18px" 
                                            MaxLength="3"></asp:TextBox>
                                        $
                                        <asp:TextBox ID="txtTotales" runat="server" CssClass="content" ReadOnly="True" Width="44%" Height="18px" style=" text-align:right;"></asp:TextBox>
                                    </td>
                                    <td class="style3">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        Saldo x Programar&nbsp;%&nbsp;</td>
                                    <td class="style4">
                            <asp:TextBox ID="txtSaldoXProgramarPorc" runat="server" CssClass="content" ReadOnly="True" 
                                Width="24%" Height="18px" MaxLength="3" style=" text-align:right;"></asp:TextBox>
                                        $ 
                                        <asp:TextBox ID="txtSaldoXProgramar" runat="server" CssClass="content" ReadOnly="True" 
                                Width="44%" Height="18px" MaxLength="3" style=" text-align:right;"></asp:TextBox>
                                    </td>
                                    <td class="style3">
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
