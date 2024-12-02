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


public partial class mantenedores_mn_mnt_ImagenesContratos : System.Web.UI.Page
{
    Funciones Func_Libreria = new Funciones();
    ConexionWS SQL_Execute = new ConexionWS();


    protected void Page_Load(object sender, EventArgs e)
    {
        Func_Libreria.FUNC_Valida_Sesion("/mn_mnt_ImagenesContratos.aspx");

        /**********************************************************************/
        string[] arrNombreParametros;
        string[] arrValoresParametros;

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

        if (!IsPostBack)
        {
            actualizaGrid();

            generadorLink();
        }
    }
    protected void cmdLimpiar_Click(object sender, ImageClickEventArgs e)
    {
        this.txtCodCon.Enabled = true;        
        this.txtCodCon.Text = "";
        
     }
    protected void cmdSalir_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("../menu_principal.aspx");
    }
    protected void grdImagenes_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Deshabilitar el ingreso o cambio de codigo de contrato.
        this.txtCodCon.Enabled = false;        
        this.txtCodCon.Text = grdImagenes.Rows[grdImagenes.SelectedIndex].Cells[1].Text;               
    }

    protected void cmdGrabar_Click(object sender, ImageClickEventArgs e)
    {
        //Si el textBox de Codigo contrato esta vacio, envia alert con mensaje.
        if (this.txtCodCon.Text.Trim() == "")
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Debe ingresar CODIGO DE CONTRATO');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_ImagenesContratos.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        } 
        
        //////////////////////////   Contrato nuevo    \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\       
        //Ejecuta SP

        //Crea los array para ejecutar SP
        string[] arrNombreParametros;
        string[] arrValoresParametros;
        
        //Pasa los parametros a Array
        arrNombreParametros = new string[] { "cod_con", "codigo_da" };
        arrValoresParametros = new string[] { this.txtCodCon.Text.Trim(), "" };
        
        //Si el codigo no estaba en BD lo crea. Solo los campos cod_con y codigo_da PK es cod_con
        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_valida_existencia_contrato", arrNombreParametros, arrValoresParametros);
        

        //////////////////////////   Fin contrato nuevo    \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        //establece ruta de directorios para insertar en base de datos.
        string path = Server.MapPath(@"../img/ImagenesProyectos/" + this.txtCodCon.Text.Trim() + "/");
        //Carga de imagen Ficha Proyecto
        if (fuImgProyecto.FileName != "")
        {
            updateImagenes(path, fuImgProyecto, "0");
        }
        if (fuImgPatri1.FileName != "")
        {
            updateImagenes(path, fuImgPatri1, "1");
        }
        if (fuImgPatri2.FileName != "")
        {
            updateImagenes(path, fuImgPatri2, "2");
        }
        if (fuImgPatri3.FileName != "")
        {
            updateImagenes(path, fuImgPatri3, "3");
        }


        /* EKV 19.02.2013 */

        // Create SQL Connection 
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings
                               ["conexion_bd"].ConnectionString;

        // Create SQL Command 

        /*BORRA REGISTRO DE CONTRATO */
        SqlParameter CodCon = new SqlParameter
                            ("@CodCon", SqlDbType.VarChar, 50);

        int result = 0;


        /* INSERTA REGISTRO DE CONTRATO */
        SqlCommand cmd = new SqlCommand();
        

        /*INSERTA IMAGEN DE CONTRATO*/ 
        if (fuImgProyecto.PostedFile != null &&
            fuImgProyecto.PostedFile.FileName != "")
        {
            string strImageName = fuImgProyecto.FileName;

            byte[] imageSize = new byte
                          [fuImgProyecto.PostedFile.ContentLength];
            HttpPostedFile uploadedImage = fuImgProyecto.PostedFile;
            uploadedImage.InputStream.Read
               (imageSize, 0, (int)fuImgProyecto.PostedFile.ContentLength);

            cmd.CommandText = "UPDATE IMAGENESCONTRATOS SET Imagen_proyecto = @Image " +
                              " WHERE Cod_Con = '" + this.txtCodCon.Text.Trim()+ "'" ;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            SqlParameter UploadedImage = new SqlParameter
                          ("@Image", SqlDbType.Image, imageSize.Length);
            UploadedImage.Value = imageSize;
            cmd.Parameters.Add(UploadedImage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();


        }

        /* INSERT IMAGEN DE PATRIMONIO1 */
        if (fuImgPatri1.PostedFile != null &&
            fuImgPatri1.PostedFile.FileName != "")
        {
            string strImageName = fuImgPatri1.FileName;

            byte[] imageSize = new byte
                          [fuImgPatri1.PostedFile.ContentLength];
            HttpPostedFile uploadedImage = fuImgPatri1.PostedFile;
            uploadedImage.InputStream.Read
               (imageSize, 0, (int)fuImgPatri1.PostedFile.ContentLength);

            cmd.CommandText = "UPDATE IMAGENESCONTRATOS SET Imagen_patri1 = @Image " +
                              " WHERE Cod_Con = '" + this.txtCodCon.Text.Trim() + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            SqlParameter UploadedImage = new SqlParameter
                          ("@Image", SqlDbType.Image, imageSize.Length);
            UploadedImage.Value = imageSize;
            cmd.Parameters.Add(UploadedImage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();
        }

        /* INSERT IMAGEN DE PATRIMONIO2 */
        if (fuImgPatri2.PostedFile != null &&
            fuImgPatri2.PostedFile.FileName != "")
        {
            string strImageName = fuImgPatri2.FileName;

            byte[] imageSize = new byte
                          [fuImgPatri2.PostedFile.ContentLength];
            HttpPostedFile uploadedImage = fuImgPatri2.PostedFile;
            uploadedImage.InputStream.Read
               (imageSize, 0, (int)fuImgPatri2.PostedFile.ContentLength);

            cmd.CommandText = "UPDATE IMAGENESCONTRATOS SET Imagen_patri2 = @Image " +
                              " WHERE Cod_Con = '" + this.txtCodCon.Text.Trim() + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            SqlParameter UploadedImage = new SqlParameter
                          ("@Image", SqlDbType.Image, imageSize.Length);
            UploadedImage.Value = imageSize;
            cmd.Parameters.Add(UploadedImage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();
        }

        /* INSERT IMAGEN DE PATRIMONIO3 */
        if (fuImgPatri3.PostedFile != null &&
            fuImgPatri3.PostedFile.FileName != "")
        {
            string strImageName = fuImgPatri3.FileName;

            byte[] imageSize = new byte
                          [fuImgPatri3.PostedFile.ContentLength];
            HttpPostedFile uploadedImage = fuImgPatri3.PostedFile;
            uploadedImage.InputStream.Read
               (imageSize, 0, (int)fuImgPatri3.PostedFile.ContentLength);

            cmd.CommandText = "UPDATE IMAGENESCONTRATOS SET Imagen_patri3 = @Image " +
                              " WHERE Cod_Con = '" + this.txtCodCon.Text.Trim() + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            SqlParameter UploadedImage = new SqlParameter
                          ("@Image", SqlDbType.Image, imageSize.Length);
            UploadedImage.Value = imageSize;
            cmd.Parameters.Add(UploadedImage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();

        }
        

        actualizaGrid();
        generadorLink();
    }



    protected void updateImagenes(string directorio, FileUpload fp, string tipo)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;
        string nombre = Path.GetFileName(fp.PostedFile.FileName);
        arrNombreParametros = new string[] { "cod_con", "codigo_da", "pathImagen", "nombImagen", "TipoImagen" };
        //GSI 21.02.2013
        //arrValoresParametros = new string[] { this.txtCodCon.Text.Trim(), "0", ("../img/ImagenesProyectos/" + this.txtCodCon.Text.Trim() + "/" + nombre), nombre, tipo };
        arrValoresParametros = new string[] { this.txtCodCon.Text.Trim(), "0", "", nombre, tipo };
        SQL_Execute.FUNC_Ejecuta_SP("SetMnt_updateImagenesContratos", arrNombreParametros, arrValoresParametros);
        
        //GSI 21.02.2013
        //Directory.CreateDirectory(directorio);
        //fp.PostedFile.SaveAs(directorio + nombre);
    }
    protected void actualizaGrid() {
            
            //Mostrar columnas para actualizarlas.
            // la funcion generadorLink las oculta.
            grdImagenes.Columns[3].Visible = true;
            grdImagenes.Columns[4].Visible = true;
            grdImagenes.Columns[5].Visible = true;
            grdImagenes.Columns[6].Visible = true;

            //Llena gried de contratos.
            SQL_Execute.FUNC_Ejecuta_SP("sp_busca_img");
            if (SQL_Execute.numero_error == 0)
            {
                grdImagenes.DataSource = SQL_Execute.oReader;
                grdImagenes.DataBind();
            }            
            
    }
    protected void generadorLink() {

        for (int i = 0; i < grdImagenes.Rows.Count; i++) {
            //Genera link Ficha Proyecto
            if (grdImagenes.Rows[i].Cells[7].Text != "&nbsp;")
            {
                grdImagenes.Rows[i].Cells[7].Text = "<a style='color:Blue;' href ='" + grdImagenes.Rows[i].Cells[3].Text + "' target='_blank'>" + grdImagenes.Rows[i].Cells[7].Text + "</a>";
               //this.TextBox1.Text = grdImagenes.Rows[i].Cells[3].Text;
            }
            //Genera link Patrimonio 1
            if (grdImagenes.Rows[i].Cells[8].Text != "&nbsp;")
            {
                grdImagenes.Rows[i].Cells[8].Text = "<a style='color:Blue;' href ='" + grdImagenes.Rows[i].Cells[4].Text + "' target='_blank'>" + grdImagenes.Rows[i].Cells[8].Text + "</a>";
            }
            //Genera link Patrimonio 2
            if (grdImagenes.Rows[i].Cells[9].Text != "&nbsp;")
            {
                grdImagenes.Rows[i].Cells[9].Text = "<a style='color:Blue;' href ='" + grdImagenes.Rows[i].Cells[5].Text + "' target='_blank'>" + grdImagenes.Rows[i].Cells[9].Text + "</a>";
            }
            //Genera link Patrimonio 3
            if (grdImagenes.Rows[i].Cells[10].Text != "&nbsp;")
            {
                grdImagenes.Rows[i].Cells[10].Text = "<a style='color:Blue;' href ='" + grdImagenes.Rows[i].Cells[6].Text + "' target='_blank'>" + grdImagenes.Rows[i].Cells[10].Text + "</a>";
            }
        }

        grdImagenes.Columns[3].Visible = false;
        grdImagenes.Columns[4].Visible = false;
        grdImagenes.Columns[5].Visible = false;
        grdImagenes.Columns[6].Visible = false; 
    
    
    }

    protected void cmdEliminar_Click(object sender, ImageClickEventArgs e)
    {

        if (this.txtCodCon.Text.Trim() == "")
        {
            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Debe ingresar CODIGO DE CONTRATO');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_ImagenesContratos.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        if (this.txtCodCon.Text.Trim() !=""){

            string[] arrNombreParametros;
            string[] arrValoresParametros;
                        
            arrNombreParametros = new string[] { "cod_con"};
            arrValoresParametros = new string[] { this.txtCodCon.Text.Trim() };

            SQL_Execute.FUNC_Ejecuta_SP("Setmnt_ImagenesContrato_BorraContrato", arrNombreParametros, arrValoresParametros);
            

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('Se elimino correctamente el contrato seleccionado.');\n");
            HttpContext.Current.Response.Write("window.location.href='mn_mnt_ImagenesContratos.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }
    }
}
