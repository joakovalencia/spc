///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Funciones de conexion AD
///</summary>

using System;
using System.DirectoryServices;

public class LdapAuthentication
{
    private string _path = "";
    private string vMsgError = "";

    public LdapAuthentication(string path)
    {
        _path = path;
    }

    public string msgError
    {
        get
        {
            return vMsgError;
        }
    }

    public bool IsAuthenticated(string domain, string username, string pwd)
    {
        try
        {
            string domainAndUsername = domain + "\\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path, domainAndUsername, pwd);
            Object native = entry.NativeObject;
            return true;
        }
        catch (Exception ex)
        {
            vMsgError = ex.Message.ToString();
            return false;
        }
    }



}
