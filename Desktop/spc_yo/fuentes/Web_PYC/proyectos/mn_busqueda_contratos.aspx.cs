///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Pantalla busqueda contrato
///</summary>
///
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Collections;

public partial class mn_busqueda_contratos : System.Web.UI.Page 
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        Func_Libreria.FUNC_Valida_Sesion("/mn_busqueda_contratos.aspx");

        lblError.Text = "";
       
        string[] arrNombreParametros;
        string[] arrValoresParametros;
        

        /**********************************************************************/
        lblUsuario.Text = Session["ID_Usuario"].ToString();
        lblPerfil.Text = Session["ID_Desc_Tipo_Usuario"].ToString();
        lblFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");

        arrNombreParametros = new string[] { "usuario" };
        arrValoresParametros = new string[] { lblUsuario.Text };

        SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Datos_Usuario", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                lblCorreo.Text = "(" + SQL_Execute.oReader["correo_electronico"].ToString() + ")"; 
                //lblMensajes.Text = "Tiene " + SQL_Execute.oReader["cant_mensajes"].ToString() + " mensaje(s)";
            }
        }
        
        /**********************************************************************/

        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        
        if (!IsPostBack)
        {
            arrNombreParametros = new string[] { "codigo_pia", "codigo_region" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Proyecto_Encabezado", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error == 0)
            {

                if (SQL_Execute.oReader.HasRows == false)
                {
                    HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
                    HttpContext.Current.Response.Write("alert('Proyecto, Programa, Estudio, No encontrado.');\n");
                    HttpContext.Current.Response.Write("window.location.href='mn_busqueda_proyectos.aspx'\n");
                    HttpContext.Current.Response.Write("</SCRIPT>");
                    HttpContext.Current.Response.End();
                }

                while (SQL_Execute.oReader.Read())
                {
                    txtRegion.Text = SQL_Execute.oReader["region"].ToString();
                    txtObjeto.Text = SQL_Execute.oReader["objeto"].ToString();
                    txtPIA.Text = SQL_Execute.oReader["codigo_da"].ToString();
                    txtProceso.Text = SQL_Execute.oReader["proceso"].ToString();
                    lblTipoProyecto.Text = SQL_Execute.oReader["tipo_proyecto"].ToString();
                    txtTipoProyecto.Text = SQL_Execute.oReader["tipo_proy"].ToString();
                    txtCodigoExploratorio.Text = SQL_Execute.oReader["CODIGO_PROYECTO_EXP"].ToString();
                }
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }

            
            /********************************************************************/

            arrNombreParametros = new string[] { "codigo_pia", "codigo_region" };
            arrValoresParametros = new string[] { strCdigoPIA, strCdigoRegion };

            SQL_Execute.FUNC_Ejecuta_SP("GetBusca_Proyecto_Contratos_Relacionados_Detalle", arrNombreParametros, arrValoresParametros);

            lblCantRegistros.Text = "Contratos relacionados al proyecto: 0";

            if (SQL_Execute.numero_error == 0)
            {
                
                grdContratos.DataSource = SQL_Execute.oReader;
                grdContratos.DataBind();

                lblCantRegistros.Text = "Contratos relacionados al proyecto: " + grdContratos.Rows.Count.ToString();
                
            }
            else
            {
                lblError.Text = SQL_Execute.desc_error;
            }
            
        }
        
    }

    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        //string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        //string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        //Response.Redirect("mn_busqueda_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
        Response.Redirect("mn_busqueda_proyectos.aspx");
    }

    protected void cmdAgregar_Click(object sender, ImageClickEventArgs e)
    {

        if(txtTipoProyecto.Text == "ATE")
        {
            string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
            string strCdigoRegion = Page.Request.QueryString["codigo_region"];

            string strURLBACK = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Este es un convenio de colaboración, no considera crear prpuestas');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLBACK + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        if (txtCodigoExploratorio.Text == "")
        {
            string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
            string strCdigoRegion = Page.Request.QueryString["codigo_region"];

            string strURLBACK = "mn_busqueda_contratos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion;
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Debe ingresar el Código Exploratorio antes de crear una licitación.');\n");
            HttpContext.Current.Response.Write("window.location.href='" + strURLBACK + "'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
        else
        {
            string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
            string strCdigoRegion = Page.Request.QueryString["codigo_region"];
            Response.Redirect("mn_ing_contrato.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
        }
    }

    /*
    protected void grdContratos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("mn_proyectos_contratos_rel_datos.aspx");
        
        //mn_proyectos_contratos_rel_datos.aspx
    }*/

    protected void cmdDetalleProyecto_Click(object sender, ImageClickEventArgs e)
    {
        //abre pantalla detalle proyecto
        string strCdigoPIA = Page.Request.QueryString["codigo_pia"];
        string strCdigoRegion = Page.Request.QueryString["codigo_region"];
        Response.Redirect("mn_edi_proyectos.aspx?codigo_pia=" + strCdigoPIA + "&codigo_region=" + strCdigoRegion);
    }
    
}
