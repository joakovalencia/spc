<%@ page language="C#" autoeventwireup="true" CodeFile="mn_ing_program_financ_contrato.aspx.cs" Inherits="mn_ing_program_financ_contrato" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
            alert("Debe ingresar un monto.");
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
            alert("Debe ingresar un monto.");
            document.frm_datos_contrato.txtPorc.focus();
            return false;
        }

        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;

    }

    function soloNumeros(e) {

        var key = window.Event ? e.which : e.keyCode

        return ((key > 47 && key < 58) || key == 46)

    }

    function format(input) {
        var num = input.value.replace(/\./g, '');
        if (!isNaN(num)) {
            num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
            num = num.split('').reverse().join('').replace(/^[\.]/, '');
            input.value = num;
        }

        else {
            //alert('Solo se permiten numeros');
            input.value = input.value.replace(/[^\d\.]*/g, '');
        }
    }

    //-->

</script>    

    <style type="text/css">
        .style1
        {
            border: thin solid #008BD5;
            color: #666666;
            font-family: Verdana,sans-serif;
            text-align: center;
            padding: 5px;
            height: 41px;
        }
        .style2
        {
            width: 28%;
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
                Modificación Programacion Financiera del contrato <div class="content_small">(Contrato-Programa Mes)</div></td>
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
                                
                                ToolTip="Salir" /> <!--OnClientClick="return func_msg_salir();" Modificado por ARB 28-03-2016 -->
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla PROGRAMA_MES" 
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
                                        F. Inicio Legal</td>
                                    <td width="80%">
                            <asp:TextBox ID="txtFechaInicioLegal" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        F. Termino Legal</td>
                                    <td>
                            <asp:TextBox ID="txtFechaTerminoLegal" runat="server" CssClass="content" ReadOnly="True" 
                                Width="80px" Height="20px"></asp:TextBox>
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/plantilla/calendar.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Monto Vigente</td>
                                    <td>
                            <asp:TextBox ID="txtMontoVigente" runat="server" CssClass="content" ReadOnly="True" 
                                Width="25%" Height="18px"></asp:TextBox>
                                    </td>
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
                                    <td style="width: 40%">
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td style="width: 15%">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="style1" >
                                        Edición Programación</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        Año
                                        &nbsp;<asp:DropDownList ID="ddlAno" runat="server" CssClass="content" 
                                            BackColor="#CCFFCC">
                                        </asp:DropDownList>
&nbsp;Mes
                                        <asp:DropDownList ID="ddlMes" runat="server" CssClass="content" 
                                            BackColor="#CCFFCC" Height="20px" Width="90px">
                                        </asp:DropDownList>
                                        &nbsp; $
                            <asp:TextBox ID="txtPorc" runat="server" CssClass="content" 
                                        Width="14%" Height="18px" MaxLength="15" 
                                            onKeyPress="return soloNumeros(event)" Onchange="format(this)" 
                                            BackColor="#CCFFCC"></asp:TextBox>
                                        Fondo<asp:DropDownList ID="ddlFondo" runat="server" BackColor="#CCFFCC" 
                                            Height="16px" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        Programación Financiera Vigente
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                            <asp:Label ID="lblCantRegistros" runat="server"  CssClass="content"></asp:Label>
                <asp:GridView ID="grdPrograma" runat="server" CellPadding="4" 
                    AutoGenerateColumns="False" CssClass="content_small" ForeColor="#333333" 
                    Width="100%" onselectedindexchanged="grdInspector_SelectedIndexChanged" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <%--                        <asp:BoundField DataField="MONTO_PROG" HeaderText="%" >
                        <HeaderStyle HorizontalAlign="Right" Width="10%" />
                        <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>--%>     <%--//Comentado el 18/03/2016 por ARB--%>
                        <%--                        <asp:BoundField HeaderText="%" DataField="MONTO_PROG_ACUM" >
                        <HeaderStyle Width="10%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>--%>     <%--//Comentado el 18/03/2016 por ARB--%>
                        <asp:CommandField HeaderText="Selección" ShowSelectButton="True">
                        <HeaderStyle Width="10%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="FONDO" HeaderText="FONDO" SortExpression="FONDO" />
                        <asp:BoundField DataField="AGNO" HeaderText="Año" >
                        <HeaderStyle HorizontalAlign="Right" Width="10%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MES" HeaderText="Mes" >
                        <HeaderStyle HorizontalAlign="Right" Width="10%" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Principales" DataField="MTOPESOS" >
                        <HeaderStyle Width="20%" HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Acumulados" DataField="MTOPESOSACUM" >
                        <HeaderStyle Width="20%" HorizontalAlign="Right" />
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
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        Totales&nbsp;&nbsp;                                     
                                    </td>
                                    <td>
                                        <%--                        <asp:BoundField DataField="MONTO_PROG" HeaderText="%" >
                        <HeaderStyle HorizontalAlign="Right" Width="10%" />
                        <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>--%>   <%--//Comentado el 18/03/2016 por ARB--%>
                                        $
                                        <asp:TextBox ID="txtTotales" runat="server" CssClass="content" ReadOnly="True" Width="44%" Height="18px" style=" text-align:right;"></asp:TextBox>
                                    </td>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        Saldo x Programar&nbsp;&nbsp;</td>
                                    <td>
<%--                            <asp:TextBox ID="txtSaldoXProgramarPorc" runat="server" CssClass="content" ReadOnly="True" 
                                Width="24%" Height="18px" MaxLength="3" style=" text-align:right;"></asp:TextBox>--%>   <%--//Comentado el 18/03/2016 por ARB--%>
                                        $ 
                                        <asp:TextBox ID="txtSaldoXProgramar" runat="server" CssClass="content" ReadOnly="True" 
                                Width="44%" Height="18px" MaxLength="3" style=" text-align:right;"></asp:TextBox>
                                    </td>
                                    <td class="style2">
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
