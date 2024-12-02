using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class mantenedores_mn_mnt_muestra_imganen : System.Web.UI.Page
{

    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_ImagenesContratos.aspx");

        string str_tipo = Page.Request.QueryString["tipo"];
        string str_cod_con = Page.Request.QueryString["cod_con"];
        string str_codigo_da = Page.Request.QueryString["codigo_da"];

        Response.ContentType = "image/jpeg";

        SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion_bd"].ConnectionString);
        string sqlText = "SELECT * FROM IMAGENESCONTRATOS WHERE COD_CON = '" + str_cod_con + "' and Codigo_da = '" + str_codigo_da + "'" ;
        SqlCommand cmd = new SqlCommand(sqlText, cnx);
        
        cmd.CommandType = CommandType.Text;

        try
        {
            cnx.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Response.ContentType = "image/jpeg";
            if (dr.Read())
            {
                if (str_tipo == "fp") Response.BinaryWrite((byte[])dr["Imagen_proyecto"]);
                if (str_tipo == "p1") Response.BinaryWrite((byte[])dr["Imagen_patri1"]);
                if (str_tipo == "p2") Response.BinaryWrite((byte[])dr["Imagen_patri2"]);
                if (str_tipo == "p3") Response.BinaryWrite((byte[])dr["Imagen_patri3"]);

                

            }

        }
        finally
        {
            if (cnx != null)
            {
            cnx.Close();
            }
        }       

    }

 
}
