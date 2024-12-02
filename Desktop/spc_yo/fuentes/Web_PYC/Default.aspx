<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
    
    <link href="css/GlobalStyle.css" rel="stylesheet" type="text/css" />
        
<script language="JavaScript" type="text/JavaScript">    
<!--
function valida_formulario()
{

	if (document.form_login.txtUsuario.value.length == 0)
	{ 
      	 alert("Debe ingresar su nombre de usuario.") ;
      	 document.form_login.txtUsuario.focus();
      	 return false;
   	}

	if (document.form_login.txtContrasena.value.length == 0)
	{ 
      	 alert("Debe ingresar su contraseña.");
      	 document.form_login.txtContrasena.focus();
      	 return false;
   	}

	return true;
}
//-->
</script>

    <style type="text/css">
        
        html,
        body {
            margin:0;
            padding:0;
            height:100%;
            flex-direction:column;
            justify-content:center;
            align-items:center;
        }
     

        #wrapper {
            min-height:100%;
            position:relative;
            top: 4px;
            left: 1px;
        }
        #header 
        {
            width: 80%;	
	        height: 205px;
	        background:url('img/plantilla/logo_mop.png') no-repeat left 50%;
	        position: absolute;
            top: -14px;
            left: 100px;
        }
        #content {
            padding-bottom:30px; /* Altura del footer */
        }
        #footer_login {
            width:80%;
            height:22px;
            position:absolute;
            bottom:-178px;
            left:0;
            background:url('img/plantilla/ribbon.png') no-repeat left 50%;
            left: 102px;
            font-size: small;
            top:90%;
        }
      
        
        .frm_login{
            width: 100%;
            position: absolute;
            top: 10%;
        }
        /* Animaciones en el login con los botones de entrar y de limpiar */
        #cmdLogin{
            cursor:pointer;
            transition: background-color 0.3s ease, transform 0.3s ease;
        }
        #cmdLogin:hover{
            background-color: azure; 
            transform: scale(1.05); 
            cursor: pointer;
        }
        #cmdLimpiar{
            cursor:pointer;
             transition: background-color 0.3s ease, transform 0.3s ease;
        }
        #cmdLimpiar:hover{
            background-color: azure; 
            transform: scale(1.05); 
            cursor: pointer;
        }

        /* Alineación del campo de texto de Usuario */
        #txtUsuario {
            display: inline-block;
            vertical-align: middle;
        }

        /* Alineación del campo de texto de Contraseña */
        #txtContrasena {
            display: inline-block;
            vertical-align: middle;
        }

        /* Alineación de los labels de Usuario y Contraseña */
        #lblUsuario, #lblContrasena {
            display: inline-block;
            vertical-align: middle;
            margin-right: 5px;  /* Espacio entre el label y el input */
        }

        /* Alineación del placeholder (Texto en gris) dentro del input */
        #txtUsuario::placeholder, #txtContrasena::placeholder {
            text-align: left;  /* Alinea el texto del placeholder a la izquierda */
        }


                
        

    </style>

</head>

<body>

<div id="wrapper">

    <div id = "header" align="center" class="content">
        <br />
        <br />
        <h2>Sistema de Proyectos y Contratos         <br />
        SPC</h2>
    </div>

    <div id="content" align="center" class="frm_login">
        <form id="form_login" runat="server" onsubmit="return valida_formulario();">
                <table style="width: 400px">
                    <tr>
                        <td colspan="2" >
							<div align="center" class="content">Accesos al sistema
                            </div>
							</td>
                    </tr>
					<tr>
                        <td style="width: 100px; height: 13px">
                        </td>
                        <td style="width: 183px; height: 13px">
                        </td>
                    </tr>
					<tr>
                        <td style="width: 100px; height: 13px">
                        </td>
                        <td style="width: 183px; height: 13px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 100px">
                            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" CssClass="content" ></asp:Label></td>
                        <td style="width: 183px">
                            <asp:TextBox ID="txtUsuario" runat="server" Width="150px" MaxLength="50" CssClass="content"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 100px">
                            <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:" CssClass="content" ></asp:Label></td>
                        <td style="width: 183px">
                            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" Width="150px" MaxLength="50" CssClass="content"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 100px; height: 15px">
                        </td>
                        <td style="width: 183px; height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 16px;" align="center" colspan="2">
                            <asp:Label ID="lblMensajes" runat="server" ForeColor="#C00000" CssClass="error" Font-Size="Small"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="style1">
                            <asp:Button ID="cmdLogin" runat="server" OnClick="cmdLogin_Click" Text="Entrar" 
                                CssClass="content" style="Width:80px; Height:25px" Height="16px"/>
                            <input id="cmdLimpiar" type="reset" value="Limpiar" class="content" style="Width:80px; Height:25px" /></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 24px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 24px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 24px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 24px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 24px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="height: 24px">
                            &nbsp;</td>
                    </tr>
                </table>
	    </form>
	    
    </div>
    <br />
    
    <div id="footer_login" align="right" class="content">
            Dirección de Arquitectura - Ministerio de Obras Públicas - Soporte (02)2-449-3613
            <asp:Label ID="lblVersion" runat="server"></asp:Label>
    </div>
</div>
        
</body>
</html>
