﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mn_mnt_muestra_imganen.aspx.cs" Inherits="mantenedores_mn_mnt_muestra_imganen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><% Response.Write(ConfigurationManager.AppSettings["TituloSistema"].ToString()); %></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" />
    
    </div>
    </form>
</body>
</html>
