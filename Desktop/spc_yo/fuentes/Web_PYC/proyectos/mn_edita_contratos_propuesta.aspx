<%@ Page Language="VB" AutoEventWireup="false" CodeFile="mn_edita_contratos_propuesta.aspx.vb" Inherits="proyectos_mn_edita_contratos_propuesta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">    

<meta http-equiv="X-UA-Compatible" content="IE=9; IE=8; IE=7;" />

    <title><% Response.Write(ConfigurationManager.AppSettings("TituloSistema").ToString())%></title>
    <link href="../css/GlobalStyle.css" rel="stylesheet" type="text/css" />
    
    <script language="jscript" type="text/jscript" src="../js/funciones.js"></script>
    
<script language="JavaScript" type="text/JavaScript">
    <!--
  
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

        if (document.frm_datos_contrato.txtSufijo.value == "") {
            alert("Debe ingresar proceso.");
            document.frm_datos_contrato.txtSufijo.focus();
            return false;
        }
        
        if (document.frm_datos_contrato.ddlProvincia.value == "(SELECCIONAR)")
        {
            alert("Para cambiar a Estado 'En Programación': Debe seleccionar provincia.");
            document.frm_datos_contrato.ddlProvincia.focus();
            return false;
        }

        if (document.frm_datos_contrato.ddlComuna.value == "(SELECCIONAR)")
        {
            alert("Para cambiar a Estado 'En Programación': Debe seleccionar comuna.");
            document.frm_datos_contrato.ddlComuna.focus();
            return false;
        }

        /*
        if (document.frm_datos_contrato.ddlLocalizacion.value == "(SELECCIONAR)")
        {
            alert("Para cambiar a Estado 'En Programación': Debe seleccionar localización.");
            document.frm_datos_contrato.ddlLocalizacion.focus();
            return false;
        }*/

        if (document.frm_datos_contrato.txtDireNumero.value == "")
        {
            alert("Para cambiar a Estado 'En Programación': Debe ingresar número dirección.");
            document.frm_datos_contrato.txtDireNumero.focus();
            return false;
        }

        if (document.frm_datos_contrato.txtObjeto.value == "")
        {
            alert("Para cambiar a Estado 'En Programación': Debe ingresar objeto del contrato.");
            document.frm_datos_contrato.txtObjeto.focus();
            return false;
        }
                
        if (confirm("¿Seguro que desea guardar los datos?"))
            return true;
        else
            return false;
    
    }
    
    //-->

</script>    

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
                Edición de Contratos (Propuesta)<div class="content_small">(Contrato)</div></td>
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
                                ToolTip="Grabar Contrato" onclick="cmdGrabar_Click" 
                                OnClientClick="return func_valida_grabar();"/>
                                
                            <asp:ImageButton ID="cmdSeguir2" runat="server" 
                                ImageUrl="~/img/plantilla/next.png" 
                                ToolTip="Seguir" onclick="cmdSeguir2_Click" 
                                />
                                
                            <asp:ImageButton ID="cmdSalir" runat="server" 
                                ImageUrl="~/img/plantilla/exit.png" onclick="cmdSalir_Click" 
                                ToolTip="Salir" />
                            <asp:Label ID="lblTabla" runat="server" Text="Tabla Contrato" Visible="False"></asp:Label>
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
                            Estado</td>
                        <td class="content">
                            <asp:TextBox ID="txtEstado" runat="server" CssClass="content" ReadOnly="True" 
                                Width="223px" Height="18px"></asp:TextBox>
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
            <td style="width: 933px;" class="content">
                            &nbsp;<asp:HiddenField ID="txtMandantesConvenio" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                <asp:Button ID="cmdIngresoMandantes" runat="server" Height="29px"
                    Text="Ingreso Mandantes (Convenios)" Width="264px"
                    CssClass="content" Visible="False" />
                                    </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 933px;">
                            
                            <br />
                            <table class="content" style="width: 100%">
                                <tr>
                                    <td style="width: 20%">
                                        </td>
                                    <td style="width: 30%">
                                        </td>
                                    <td style="width: 15%">
                                        </td>
                                    <td style="width: 35%">
                                        </td>
                                </tr>
                                <tr>
                                    <td colspan="4" class="borde_celda">
                                        ENCABEZADO -
                                        En Programación</td>
                                </tr>
                                <tr>
                                    <td>
                                        Provincia                            </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="content" 
                                            Height="17px" Width="195px" Font-Size="X-Small" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Comuna</td>
                                    <td>
                                        <asp:DropDownList ID="ddlComuna" runat="server" CssClass="content" 
                                            Height="17px" Width="195px" Font-Size="X-Small" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Localización</td>
                                    <td>
                                        <asp:DropDownList ID="ddlLocalizacion" runat="server" CssClass="content" 
                                            Height="17px" Width="195px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Dirección</td>
                                    <td>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="content" 
                                Width="95%" Height="18px" MaxLength="100"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nº</td>
                                    <td>
                            <asp:TextBox ID="txtDireNumero" runat="server" CssClass="content" 
                                Width="50px" Height="18px" MaxLength="6"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                            Objeto</td>
                                    <td colspan="3">
                            <asp:TextBox ID="txtObjetoNuevo" runat="server" CssClass="content" 
                                Width="470px" Height="18px" MaxLength="300"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
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
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                                    <br />
                            
                        </td>
                </tr>
        </table>
    
</div>

<div class="footer" >
    <strong>USUARIO:</strong><asp:Label ID="lblUsuario" runat="server" CssClass="content"> </asp:Label> <asp:Label ID="lblCorreo" runat="server" CssClass="content"> </asp:Label>
    <strong> GRUPO: </strong><asp:Label ID="lblPerfil" runat="server" CssClass="content"> </asp:Label>
    <strong> FECHA: </strong><asp:Label ID="lblFecha" runat="server" CssClass="content"> </asp:Label>
</div>

</form>

</body>
</html>

