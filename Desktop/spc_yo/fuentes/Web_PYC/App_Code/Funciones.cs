///<summary>
///Creado por: Erick Kleiner - GSI Asesorias
///Fecha: 23-10-2012
///Descripción: Funciones genericas
///</summary>
///
using System;
using System.Collections;
using System.Globalization;
using System.Text;
using System.Web;

public class Funciones
{
    ConexionWS SQL_Execute = new ConexionWS();

    public string FUNC_Quita_Seleccionar(string strDato, string strReemplazo)
    {

        string retorno = "";

        if (strDato == null) strDato = "";

        if (strDato.Trim().ToUpper().ToString() == "(SELECCIONAR)")
        {
            retorno = strReemplazo;
        }
        else
        {
            retorno = strDato;
        }

        return retorno;

    }

    public void FUNC_Valida_Sesion(string strOpcionMenu)
    {
        Boolean bolSessionValida = true;
        string strMensaje = "";

        object objSession = HttpContext.Current.Session["ID_Sesion"];
        object objTipoUsuario = HttpContext.Current.Session["ID_Codigo_Tipo_Usuario"];
        object objUsuario = HttpContext.Current.Session["ID_Usuario"];

        if (objSession == null)
        {
            bolSessionValida = false;
            strMensaje = "Su sesión ha expirado.";
        }
        else
        {
            if (objSession.ToString() != HttpContext.Current.Session.SessionID)
            {
                bolSessionValida = false;
                strMensaje = "Su sesión ha expirado.";
            }
        }

        if (objTipoUsuario == null)
        {
            bolSessionValida = false;
            strMensaje = "Su sesión ha expirado.";
        }
        else
        {
            if (FUNC_Valida_Acceso_Pagina(strOpcionMenu, objTipoUsuario.ToString()) == false)
            {
                bolSessionValida = false;
                strMensaje = "Acceso denegado.";
            }
        }

        if (bolSessionValida == false)
        {
            string strBackPage = FUNC_Retorna_BackPage(strOpcionMenu);

            HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='javascript'>\n");
            HttpContext.Current.Response.Write("alert('" + strMensaje.ToString() + "');\n");
            HttpContext.Current.Response.Write("window.top.location.href='" + strBackPage + "Default.aspx'\n");
            HttpContext.Current.Response.Write("</SCRIPT>");
            HttpContext.Current.Response.End();
        }

        if (bolSessionValida == true)
        {
            FUNC_Graba_Log(objUsuario.ToString(), objTipoUsuario.ToString(), strOpcionMenu);

        }
    }

    private void FUNC_Graba_Log(string strUsuario, string strTipoUsuario, string strOpcionMenu)
    {
        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "nombre_usuario", "codigo_tipo_usuario", "url_opcion" };
        arrValoresParametros = new string[] { strUsuario, strTipoUsuario, strOpcionMenu };

        SQL_Execute.FUNC_Ejecuta_SP("SetGrabaLog", arrNombreParametros, arrValoresParametros);
    }

    private string FUNC_Retorna_BackPage(string strURL)
    {
        string strRetorno = "";

        for (int i = 0; i < strURL.Length; i++)
        {
            if (strURL[i].ToString() == "/") { strRetorno = strRetorno + "../"; }
        }

        return strRetorno;

    }

    private Boolean FUNC_Valida_Acceso_Pagina(string strOpcionMenu, string strTipoUsuario)
    {
        Boolean retorno = false;

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "codigo_tipo_usuario", "opcion_menu" };
        arrValoresParametros = new string[] { strTipoUsuario, strOpcionMenu };

        SQL_Execute.FUNC_Ejecuta_SP("SetValida_Acceso_Menu_Usuario", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                if (SQL_Execute.oReader["resp"].ToString() == "si")
                {
                    retorno = true;
                }
            }

        }
        else
        {
            retorno = false;
        }

        return retorno;
    }

    public string FUNC_FiltraString(string cadena, string largo)
    {
        if (cadena == null) return "";
        cadena = cadena.Replace("<", "");
        cadena = cadena.Replace("!", "");
        cadena = cadena.Trim();

        if (largo != "")
            if (cadena.Length > Convert.ToInt16(largo)) cadena = cadena.Substring(0, Convert.ToInt16(largo));

        Byte[] codigo = ASCIIEncoding.ASCII.GetBytes(cadena);
        ArrayList lista = new ArrayList();
        Int32 i = 0;
        for (i = 0; i < codigo.Length; i++)
        {
            if ((codigo[i] >= 45 && codigo[i] <= 57) || (codigo[i] >= 64 && codigo[i] <= 90) || (codigo[i] >= 97 && codigo[i] <= 122) || (codigo[i] == 32 || codigo[i] == 95))
                lista.Add(codigo[i]);
        }
        byte[] tableau = ((byte[])(lista.ToArray(typeof(byte))));
        return ASCIIEncoding.ASCII.GetString(tableau);
    }

    public string FUNC_Fecha_SQL(string fecha)
    {
        fecha = FUNC_FiltraString(fecha, "");
        if (fecha == "") return "19000101";
        if (fecha.IndexOf("/", StringComparison.Ordinal) != 0) fecha = fecha.Replace("/", "-");
        string valor = ""; string[] ArrFecha;
        ArrFecha = fecha.Split(new char[] { '-' });
        valor = ArrFecha[2];
        if (ArrFecha[1].Length == 1) valor += "0" + ArrFecha[1];
        else valor += ArrFecha[1];
        if (ArrFecha[0].Length == 1) valor += "0" + ArrFecha[0];
        else valor += ArrFecha[0];
        return valor;
    }

    public string digitoVerificador(int rut)
    {
        int Digito;
        int Contador;
        int Multiplo;
        int Acumulador;
        string RutDigito;

        Contador = 2;
        Acumulador = 0;

        while (rut != 0)
        {
            Multiplo = (rut % 10) * Contador;
            Acumulador = Acumulador + Multiplo;
            rut = rut / 10;
            Contador = Contador + 1;
            if (Contador == 8)
            {
                Contador = 2;
            }

        }

        Digito = 11 - (Acumulador % 11);
        RutDigito = Digito.ToString().Trim();
        if (Digito == 10)
        {
            RutDigito = "K";
        }
        if (Digito == 11)
        {
            RutDigito = "0";
        }
        return (RutDigito);
    }

    public string FUNC_Trae_Fecha_Proceso(string tipo)
    {
        string strFecha = "";

        SQL_Execute.FUNC_Ejecuta_SP("sp_busca_datos_proceso"); //OK

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                if (tipo == "proceso")
                {
                    strFecha = SQL_Execute.oReader["fecha_proceso"].ToString();
                }

                if (tipo == "proximo")
                {
                    strFecha = SQL_Execute.oReader["fecha_proximo_proceso"].ToString();
                }

                if (tipo == "anterior")
                {
                    strFecha = SQL_Execute.oReader["fecha_anterior_proceso"].ToString();
                }
            }
        }

        return strFecha;
    }

    public string FUNC_Quita_Espacio_HTML(string strValor)
    {
        if (strValor.ToLower().Trim() == "&nbsp;") strValor = "";

        return strValor;
    }

    public string FUNC_EnteroSQL(string strMonto)
    {
        long dblRetorno = 0;
        string strRetorno = "0";

        /*strMonto = strMonto.Replace(",", "dec");
        strMonto = strMonto.Replace(".", "");
        strMonto = strMonto.Replace("dec", ".");*/

        if (long.TryParse(strMonto, out dblRetorno))
        {
            strRetorno = long.Parse(strMonto).ToString().Replace(",", ".");
        }
        else
        {
            strRetorno = "0";
        }

        return strRetorno;
    }

    public string FUNC_MontoSQL(string strMonto)
    {
        double dblRetorno = 0;
        string strRetorno = "0";

        /*strMonto = strMonto.Replace(",", "dec");
        strMonto = strMonto.Replace(".", "");
        strMonto = strMonto.Replace("dec", ".");*/

        if (double.TryParse(strMonto, out dblRetorno))
        {
            strRetorno = double.Parse(strMonto).ToString();
        }
        else
        {
            strRetorno = "0";
        }

        return strRetorno;
    }


    public string FUNC_MontoSQLv2(string strMonto)
    {
        double dblRetorno = 0;
        string strRetorno = "0";

        //strMonto = strMonto.Replace(",", "x");
        strMonto = strMonto.Replace(".", "");
        //strMonto = strMonto.Replace("x", ".");

        if (double.TryParse(strMonto, out dblRetorno))
        {
            strRetorno = double.Parse(strMonto).ToString();
        }
        else
        {
            strRetorno = "0";
        }

        return strRetorno;
    }

    public string FUNC_MontoASPv2(string strMonto, int intDecimales)
    {
        CultureInfo ci = new CultureInfo("es-CL");
        double dblRetorno = 0;
        string strRetorno = "0";
        string strFormato = "###,###";

        intDecimales = intDecimales - 1;

        if (intDecimales < 0) intDecimales = 0;

        string strFormatoDec = new String('#', intDecimales);

        if (intDecimales == 0)
            strFormato = "###,##0";
        else
            strFormato = "###,###." + strFormatoDec + "0";

        strMonto = strMonto.Replace(".", "x");
        strMonto = strMonto.Replace(",", "");
        strMonto = strMonto.Replace("x", ",");

        if (double.TryParse(strMonto, NumberStyles.Number, ci, out dblRetorno))
        {
            strRetorno = dblRetorno.ToString(strFormato);
        }
        else
        {
            strRetorno = "0";
        }

        return strRetorno;
    }

    public bool FUNC_Cheked(string strValor)
    {
        bool bolRetorno = false;
        if (strValor == "1") bolRetorno = true;
        if (strValor == "0") bolRetorno = false;
        if (strValor == "true") bolRetorno = true;
        if (strValor == "false") bolRetorno = false;
        return bolRetorno;
    }

    public string FUNC_ChekedSQL(string strValor)
    {
        string bolRetorno = "0";
        if (strValor == "1") bolRetorno = "1";
        if (strValor == "true") bolRetorno = "1";
        if (strValor == "on") bolRetorno = "1";
        return bolRetorno;
    }

    /*public string FUNC_WS_Reporte_Contratos_Sectorial(string strRegInicio, string strRegFin, string strClave)
    {

        string strErrores = "";

        BuscadorContratosMandantes ws_sector = new BuscadorContratosMandantes();

        ContratoEntidad[] ws_contratos = ws_sector.BuscarContratoPorFiltro(int.Parse(strRegInicio), int.Parse(strRegFin));

        for (int i = 1; i <= ws_contratos.Length - 1; i++)
        {
            string[] arrNombreParametros;
            string[] arrValoresParametros;

            arrNombreParametros = new string[] {     "accion"
                                                ,    "clave"
                                                ,    "region_inicio"
                                                ,    "region_fin"

                                                ,    "codigosafi"
                                                ,    "descripcionregion"
                                                ,    "descripcioncomuna"
                                                ,    "descripcionprovincia"
                                                ,    "rutcontratista"
                                                ,    "montocontrato"
                                                ,    "montoinicial"
                                                ,    "montovigente"
                                                ,    "rutinspector"
                                                ,    "estadocontrato"
                                                ,    "tipogasto"
                                                ,    "pptooficial"
                                                ,    "aumentodisminucion"
                                                ,    "fechatermino"
                                                ,    "descripcion_tipo_registro"
                                                ,    "descripcion_categoria"
                                                ,    "codigo_bip"
                                                ,    "proceso"
                                                ,    "etapa"
                                                ,    "calificacion"
                                                ,    "f_recep_provisional"
                                                ,    "f_recep_definitiva"
                                                ,    "f_res_liq_contrato"
                                                ,    "f_termino_ito"
                                                ,    "ultimo"
                                                ,    "objeto"
                                                ,    "sector_destino"
                                                ,    "sub_sec"
                                                ,    "tipo_edificacion"
                                                ,    "plazo_adjudicado"
                                                ,    "inicio_legal"
                                                ,    "f_res_adjudicacion"
                                                ,    "plazo_vigente"
                                                ,    "inversion_anno"
                                                ,    "inversion_acumulada"
                                                ,    "cantidad_obra"
                                                ,    "observaciones_contrato"
                                                ,    "av_fin"
                                                ,    "av_fis_acum"
                                                };

            arrValoresParametros = new string[] { i.ToString()
                                            ,   strClave
                                            ,   strRegInicio
                                            ,   strRegFin
                                            ,   ws_contratos[i].CodigoSafi.ToString()
                                            ,   ws_contratos[i].DescripcionRegion.ToString()
                                            ,   ws_contratos[i].DescripcionComuna.ToString()
                                            ,   ws_contratos[i].DescripcionProvincia.ToString()
                                            ,   ws_contratos[i].RutContratista.ToString()
                                            ,   ws_contratos[i].MontoContrato.ToString()
                                            ,   ws_contratos[i].MontoInicial.ToString()
                                            ,   ws_contratos[i].MontoVigente.ToString()
                                            ,   ws_contratos[i].RutInspector.ToString()
                                            ,   ws_contratos[i].EstadoContrato.ToString()
                                            ,   ws_contratos[i].TipoGasto.ToString()
                                            ,   ws_contratos[i].PptoOficial.ToString()
                                            ,   ws_contratos[i].AumentoDisminucion.ToString()
                                            ,   ws_contratos[i].FechaTermino.ToString()
                                            ,   ws_contratos[i].Descripcion_Tipo_Registro.ToString()
                                            ,   ws_contratos[i].Descripcion_Categoria.ToString()
                                            ,   ws_contratos[i].Codigo_Bip.ToString()
                                            ,   ws_contratos[i].Proceso.ToString()
                                            ,   ws_contratos[i].Etapa.ToString()
                                            ,   ws_contratos[i].Calificacion.ToString()
                                            ,   ws_contratos[i].F_Recep_Provisional.ToString()
                                            ,   ws_contratos[i].F_Recep_Definitiva.ToString()
                                            ,   ws_contratos[i].F_Res_Liq_Contrato.ToString()
                                            ,   ws_contratos[i].F_Termino_Ito.ToString()
                                            ,   ws_contratos[i].Ultimo.ToString()
                                            ,   ws_contratos[i].Objeto.ToString()
                                            ,   ws_contratos[i].Sector_Destino.ToString()
                                            ,   ws_contratos[i].Sub_Sec.ToString()
                                            ,   ws_contratos[i].Tipo_Edificacion.ToString()
                                            ,   ws_contratos[i].Plazo_Adjudicado.ToString()
                                            ,   ws_contratos[i].Inicio_Legal.ToString()
                                            ,   ws_contratos[i].F_Res_Adjudicacion.ToString()
                                            ,   ws_contratos[i].Plazo_Vigente.ToString()
                                            ,   ws_contratos[i].Inversion_Anno.ToString()
                                            ,   ws_contratos[i].Inversion_Acumulada.ToString()
                                            ,   ws_contratos[i].Cantidad_Obra.ToString()
                                            ,   ws_contratos[i].Observaciones_Contrato.ToString()
                                            ,   ws_contratos[i].Av_Fin.ToString()
                                            ,   ws_contratos[i].Av_Fis_Acum.ToString()
                                            };

            SQL_Execute.FUNC_Ejecuta_SP("Set_graba_ws_contratos_sectoriales", arrNombreParametros, arrValoresParametros);

            if (SQL_Execute.numero_error != 0)
            {
                strErrores = strErrores + " - " + SQL_Execute.desc_error;
            }
        }

        return strErrores;
    }
    */

    public bool FUNC_Valida_Acceso_Region(string strUsuario, string strCodigoRegion)
    {

        Boolean retorno = false;

        string[] arrNombreParametros;
        string[] arrValoresParametros;

        arrNombreParametros = new string[] { "usuario", "region" };
        arrValoresParametros = new string[] { strUsuario, strCodigoRegion };

        SQL_Execute.FUNC_Ejecuta_SP("SetValida_Acceso_Region", arrNombreParametros, arrValoresParametros);

        if (SQL_Execute.numero_error == 0)
        {
            while (SQL_Execute.oReader.Read())
            {
                if (SQL_Execute.oReader["resp"].ToString() == "si")
                {
                    retorno = true;
                }
            }

        }
        else
        {
            retorno = false;
        }

        return retorno;
    }

    public string FUNC_Colores_Eng(string strColorESP)
    {
        string strColorENG = strColorESP;

        switch (strColorESP.ToLower().Trim().ToString())
        {
            case "verde":
                strColorENG = "Green";
                break;

            case "amarillo":
                strColorENG = "Yellow";
                break;

            case "rojo":
                strColorENG = "Red";
                break;
        }

        return strColorENG;
    }

}
