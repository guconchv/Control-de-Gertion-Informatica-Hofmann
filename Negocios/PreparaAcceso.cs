using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using Datos;
using System.Text.RegularExpressions;

namespace Negocios
{
    public class PreparaAcceso
    {
       

        public static DataTable BuscaParametrosPorTabla(int CodTab,string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ObtenerParamentrosPorTabla(CodTab,  CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscaParametrosPadre(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ObtenerParamentrosPadre(CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscaListaParmetrosInfCompletaPorCodigo(int CodTab, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ObtenerParamentrosInfComPorCodigo(CodTab,CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        //inicio Roberto Gajardo
        public static bool Buscar_Descripcion(string descripcion, string CadenaConexion)
        {

            bool var = false;
            IDataReader lector = AccesoDatos.VerificaDescripcion(descripcion, CadenaConexion);
            while (lector.Read())
            {
                var = true;
            }
            return var;
        }
        public static bool Buscar_DescripcionDeTabPar(int codpar,string descripcion, string CadenaConexion)
        {

            bool var = false;
            IDataReader lector = AccesoDatos.VerificaDescripcionDeTabPar(codpar,descripcion, CadenaConexion);
            while (lector.Read())
            {
                var = true;
            }
            return var;
        }
        public static DataTable Crear_ParametroNuevo(int codTab, string CodDescrip, int CdoEstado, int cod_sis, string CodAux, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.CrearComParametroNuevo(codTab, CodDescrip, CdoEstado, cod_sis , CodAux, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
            //return AccesoDatos.Crear_NuevoParametro(codTab, CodDescrip,CdoEstado,CodAux,Comentario, usuario,CadenaConexion);
        }
        public static DataTable Crear_DescripPar(string Descrip, int estado, int cod_sis ,string cod_aux, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.CrearComandoTablaPar(Descrip, estado, cod_sis, cod_aux, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
            //return AccesoDatos.Crear_Descripcion_TablaPar(Descrip, estado, cod_aux, comentario, usuario,CadenaConexion);
        }
        public static DataTable Modificar_Descripcion(int codigo, string Descrip, int estado,int cod_sis, string cod_aux, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.CrearComandoModificaTabla(codigo, Descrip, estado, cod_sis, cod_aux, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
            //return AccesoDatos.Modificar_Descripcion_Tabla(codigo, Descrip, estado, cod_aux, comentario, usuario, CadenaConexion);
        }
        public static DataTable Modifica_Parametros(int codPar, int codigo, string CodDescrip, int CdoEstado, int cod_sis, string CodAux, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ActualizarParametros(codPar, codigo, CodDescrip, CdoEstado, cod_sis, CodAux, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
            //return AccesoDatos.Actualizar_Parametros(codPar,codigo,CodDescrip,CdoEstado,CodAux,Comentario,Session,CadenaConexion);
        }
        public static DataTable BuscadatosGuiasGrid(string CadenaConexion, int numguia, int rutcliente, int sucursal, int estado)
        {
            SqlCommand _comando = AccesoDatos.ObtenerDatosGuiasGrid(CadenaConexion, numguia, rutcliente, sucursal, estado);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscaGuiaPorNro(int nroguia, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ObtenerGuiaPorNro(nroguia, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable InsertarGuia(Decimal nroGuia,int rutcliente, string nomusuario, string CueServidor, string passServidor, string numserie, string sisasignado, int sucursal, string nomequipo, string descripcion, string dirrecionip, string sisoperativo, string antivirus, string office, string idteamviewer, string passteamviewer, DateTime fecha, string observaciones, int estado, string usuresponsable,int TipoEquipo, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.IngresarNuevaGuia(nroGuia, rutcliente, nomusuario, CueServidor, passServidor, numserie, sisasignado, sucursal, nomequipo, descripcion, dirrecionip, sisoperativo, antivirus, office, idteamviewer, passteamviewer, fecha, observaciones, estado, usuresponsable, TipoEquipo, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static void ActualizarGuia(int nroGuia, string nomusuario, string CueServidor, string passServidor, string numserie, string sisasignado, int sucursal, string nomequipo, string descripcion, string dirrecionip, string sisoperativo, string antivirus, string office, string idteamviewer, string passteamviewer, DateTime fecha, string observaciones, int estado, string usuresponsable,int TipoEquipo, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.actualizarGuia(nroGuia, nomusuario, CueServidor, passServidor, numserie, sisasignado, sucursal, nomequipo, descripcion, dirrecionip, sisoperativo, antivirus, office, idteamviewer, passteamviewer, fecha, observaciones, estado, usuresponsable, TipoEquipo,CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            AccesoDatos.EjecutarComando(_comando);
        }
        public static void EliminarGuiaPorNro(int nroguia, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.EliminarGuia(nroguia, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable ObtenerNumGuia(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.GenerarNumGuia(CadenaConexion);
            //_comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarRutNomClientes(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ObtenerRutNomClientes(CadenaConexion);
            //_comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarDatosTabPar_Cod(int codigo, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ObtenerDatosTabPar_Cod(codigo, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        //Si existe número de guía envía un verdadero
        public static bool BuscaGuiaPorNumero(decimal NroGuia, string CadenaConexion)
        {
            bool var = false;
            IDataReader lector = AccesoDatos.BuscarGuia(NroGuia, CadenaConexion);
            while (lector.Read())
            {
                var = true;
            }
            return var;
        }
        //fin Roberto Gajardo
        //************************* FDiaz*****************************************************
        public static DataTable LLenarListaCliente(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.LLenar_Lista_Cliente(CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarCliente(Decimal Rut, string Nombre, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Buscar_Cliente(Rut, Nombre, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable AgregaCliente(Decimal Rut, string Digito, string Nombre, string Direccion, int Comuna, int Ciudad, string TelFijo, string TelMovil, string Correo, DateTime Fecha, int Estado, string Usuario, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Agrega_Cliente(Rut, Digito, Nombre, Direccion, Comuna, Ciudad, TelFijo, TelMovil, Correo, Fecha, Estado, Usuario, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarClientePorId(Decimal Rut, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Buscar_Cliente_Por_Id(Rut, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable ActualizaCliente(Decimal Rut, string Nombre, string Direccion, int Comuna, int Ciudad, string TelFijo, string TelMovil, string Correo, DateTime Fecha, int Estado, string Usuario, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Actualiza_Cliente(Rut, Nombre, Direccion, Comuna, Ciudad, TelFijo, TelMovil, Correo, Fecha, Estado, Usuario, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable EliminarCliente(Decimal Rut, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Eliminar_Cliente(Rut, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        
        public static DataTable LLenarCliente(Decimal Rut, string Nombre, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.LLenar_Cliente(Rut, Nombre, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscaNombreParametrosPadre(int Codigo, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Busca_Nombre_Parametro_Padre(Codigo, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable LLenarListaEnsamble(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.LLenar_Lista_Ensamble(CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable IngresaEnsambleCabecera(Decimal NHoja, Decimal RutCliente, DateTime Fecha, int TipoEquipo, string Venta, string Tecnico, int CodEstado, string Usuario, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Ingresa_Ensamble_Cabecera(NHoja, RutCliente, Fecha, TipoEquipo, Venta, Tecnico, CodEstado, Usuario, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable ModificaEnsambleCabecera(Decimal NHoja, DateTime Fecha, int TipoEquipo, string Venta, string Tecnico, int CodEstado, string Usuario, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Modifica_Ensamble_Cabecera(NHoja, Fecha, TipoEquipo, Venta, Tecnico, CodEstado, Usuario, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable InsertarEnsambleDetalle(Decimal NHoja, int Cor, int CodigoHrw, string Serie, string Marca, string Modelo, string Observacion, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Insertar_Ensamble_Detalle(NHoja, Cor, CodigoHrw, Serie, Marca, Modelo, Observacion, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable ModificarEnsambleDetalle(Decimal NHoja, int Cor, int CodigoHrw, string Serie, string Marca, string Modelo, string Observacion, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Modificar_Ensamble_Detalle(NHoja, Cor, CodigoHrw, Serie, Marca, Modelo, Observacion, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarNroEnsamble(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Buscar_Nro_Ensamble(CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable CancelarNroEnsamble(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Cancelar_Nro_Ensamble(CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarIdeNomTecnicos(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ObtenerIdeNomTecnicos(CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscaCodigoParametrosPorNombre(string Descripcion, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Busca_Codigo_Parametro_Por_Nombre(Descripcion, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarCabeceraPorNroHoja(Decimal NroHoja, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Buscar_Cabecera_Por_NroHoja(NroHoja, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarDetallePorNroHoja(Decimal NroHoja, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Buscar_Detalle_Por_NroHoja(NroHoja, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarEnsamblePorRutFecha(Decimal Rut, string Fecha, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Buscar_Ensamble_Por_RutFecha(Rut, Fecha, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable LLenarConsultaGuia(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.LLenar_Consulta_Guia(CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }

        public static DataTable BuscarLLenarConsulta(string Fecha,int Estado,int TipoEquipo, string IP, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.Buscar_LLenar_Consulta(Fecha, Estado, TipoEquipo, IP, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        // *****************    Funcion valida campos Vacios del formularios    ************************
        public static bool funsionValFormVacios(string[] arrayform)
        {
            bool var = true;
            // foreach que reccorre el ArrayForm buscando Campos Vacios o ceros retorna falso si los encuentra
            foreach (string elemento in arrayform)
            {
                if (elemento == string.Empty || elemento == "0")
                {
                    var = false;
                }
            }
            return var;
        }
        //*************************************************************************************************
        public static bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }
        // ************  Funcion que calcula el digito verificador del rut ingresado
        public static string Dv(string r)
        {
            int suma = 0;
            for (int x = r.Length - 1; x >= 0; x--)
                suma += int.Parse(char.IsDigit(r[x]) ? r[x].ToString() : "0") * (((r.Length - (x + 1)) % 6) + 2);
            int numericDigito = (11 - suma % 11);
            string digito = numericDigito == 11 ? "0" : numericDigito == 10 ? "K" : numericDigito.ToString();
            return digito;
        } 

        //***************************************************************************************************************************************
        //************************* Fin FDiaz ************************************************
        //************************* Inicio Katherine Candia *********************************************
        public static DataTable ObtenerGuiasDevueltas(int Cliente,string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.LlenarGuiasDevueltas(Cliente,CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando); 
        }
        public static DataTable ModificarEstadoGuia(int NroGuia, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.ModificarEstadoGuia(NroGuia,CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable ObtenerDevoluciones(string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.LlenarConsultaDevoluciones(CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        public static DataTable BuscarDevoluciones(string Fecha, int Sucursal, int Cliente,string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.BuscarLlenaDevoluciones(Fecha,Sucursal,Cliente,CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        //************************* Fin KCandia *********************************************

        //*************************Andres****************************************************

        public static DataTable BuscarEnsamble(int ruten, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.BuscarEnsamble(ruten, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }
        //*************************Fin Andres************************************************


        public static DataTable BuscarNomTecnicos(string CadenaConexexion)
        {
            SqlCommand _comando = AccesoDatos.BuscarTecnicoPorNombre(CadenaConexexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);

        }

        public static DataTable BuscarTecnicoRut(int RutTec, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.BuscarTecnicoPorRut(RutTec, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }


        //*********DROGUERIA HOFMANN***********

        public static DataTable RegistroEquipo(string rut, string nombre, string telef, string depar, string correo, DateTime fecha,
            string tip, string tecnico, int licen_off, int licen_win, string id_equipo, string eq_hardware, string eq_marca, string eq_modelo, string eq_serie,
            string comentarios, string CadenaConexion)
        {
            SqlCommand _comando = AccesoDatos.AgregarRegistroEquipos(rut, nombre, telef, depar, correo, fecha,tip, tecnico, licen_off, licen_win, id_equipo, eq_hardware, eq_marca, eq_modelo, eq_serie,comentarios, CadenaConexion);
            _comando.CommandType = CommandType.StoredProcedure;
            return AccesoDatos.EjecutarComando(_comando);
        }

    }
}
