using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace Datos
{
    public class AccesoDatos
    {
        //**************** EejecutarComando es publico y usado por todas las consultas **************
        public static DataTable EjecutarComando(SqlCommand _comando)
        {
            DataTable _tabla = new DataTable();
            try
            {
                _comando.Connection.Open();
                SqlDataAdapter _adaptador = new SqlDataAdapter();
                _adaptador.SelectCommand = _comando;
                _adaptador.Fill(_tabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _comando.Connection.Close();
            }
            return _tabla;
        }

        public static IDataReader BuscarGuia(Decimal NroGuia, string CadenaConexion)
        {

            SqlConnection Conexion = new SqlConnection(CadenaConexion);
            SqlCommand cmd = new SqlCommand("CE_Existe_Numero_Guia", Conexion);
            cmd.Parameters.AddWithValue("@NroGuia", NroGuia);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                Conexion.Open();
                IDataReader lector = cmd.ExecuteReader();
                return lector;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //********************************* Agregar desde aca ****** poner entre sus iniciales su parte
        //************************* RGajardo **************************************************
        public static IDataReader VerificaDescripcion(string descripcion, string CadenaConexion)
        {
            string Cadena = CadenaConexion;
            SqlConnection Conexion = new SqlConnection();
            Conexion.ConnectionString = Cadena;
            SqlCommand Comando = new SqlCommand();
            Comando.CommandText = "CE_Existe_DescParametroPar";
            Comando.Parameters.AddWithValue("@Descripcion", descripcion);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Connection = Conexion;
            Conexion.Open();
            IDataReader lector = Comando.ExecuteReader();
            return lector;
        }
        public static IDataReader VerificaDescripcionDeTabPar(int codpar, string descripcion, string CadenaConexion)
        {
            string Cadena = CadenaConexion;
            SqlConnection Conexion = new SqlConnection();
            Conexion.ConnectionString = Cadena;
            SqlCommand Comando = new SqlCommand();
            Comando.CommandText = "CE_Verifica_Parametro_TabPar";
            Comando.Parameters.AddWithValue("@CodTabPar", codpar);
            Comando.Parameters.AddWithValue("@Descripcion", descripcion);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Connection = Conexion;
            Conexion.Open();
            IDataReader lector = Comando.ExecuteReader();
            return lector;
        }
        public static SqlCommand ActualizarParametros(int codPar, int codigo, string CodDescrip, int CdoEstado, int cod_sis, string CodAux, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Modifica_parametros", _conexion);
            _comando.Parameters.AddWithValue("@CodPar", codPar);
            _comando.Parameters.AddWithValue("@codigo", codigo);
            _comando.Parameters.AddWithValue("@CodDescrip", CodDescrip);
            _comando.Parameters.AddWithValue("@CodEstado", CdoEstado);
            _comando.Parameters.AddWithValue("@CodSis", cod_sis);
            _comando.Parameters.AddWithValue("@CodAux", CodAux);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand CrearComandoTablaPar(string Descripcion, int estado, int cod_sis, string cod_aux, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Agrega_Par", _conexion);
            _comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            _comando.Parameters.AddWithValue("@Estado", estado);
            _comando.Parameters.AddWithValue("@CodSis", cod_sis);
            _comando.Parameters.AddWithValue("@Cod_aux", cod_aux);
            _comando.Connection.Close();
            return _comando;
        }

        public static SqlCommand CrearComandoModificaTabla(int codigo, string Descripcion, int estado, int cod_sis, string cod_aux, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Modifica_parametros_tabla", _conexion);
            _comando.Parameters.AddWithValue("@codigo", codigo);
            _comando.Parameters.AddWithValue("@CodDescrip", Descripcion);
            _comando.Parameters.AddWithValue("@CdoEstado", estado);
            _comando.Parameters.AddWithValue("@CodSis", cod_sis);
            _comando.Parameters.AddWithValue("@CodAux", cod_aux);
            _comando.Connection.Close();
            return _comando;
        }


        public static SqlCommand CrearComParametroNuevo(int codTab, string CodDescrip, int CdoEstado, int cod_sis, string CodAux, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Nuevo_parametro", _conexion);
            _comando.Parameters.AddWithValue("@CodTab", codTab);
            _comando.Parameters.AddWithValue("@CodDescrip", CodDescrip);
            _comando.Parameters.AddWithValue("@CodEstado", CdoEstado);
            _comando.Parameters.AddWithValue("@CodSis", cod_sis);
            _comando.Parameters.AddWithValue("@CodAux", CodAux);

            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand GenerarNumGuia(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Genera_Numero_GCE", _conexion);
            _comando.Connection.Close();
            return _comando;
        }

        public static SqlCommand ObtenerDatosGuiasGrid(string CadenaConexion, int numguia, int rutcliente, int sucursal, int estado)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Obtener_Guias", _conexion);
            _comando.Parameters.AddWithValue("@numguia", numguia);
            _comando.Parameters.AddWithValue("@rutcliente", rutcliente);
            _comando.Parameters.AddWithValue("@sucursal", sucursal);
            _comando.Parameters.AddWithValue("@estado", estado);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand ObtenerGuiaPorNro(int NroGuia, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_GuiaDetalle", _conexion);
            _comando.Parameters.AddWithValue("@nroguia", NroGuia);

            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand IngresarNuevaGuia(Decimal nroGuia, int rutcliente, string nomusuario, string CueServidor, string passServidor, string numserie, string sisasignado, int sucursal, string nomequipo, string descripcion, string dirrecionip, string sisoperativo, string antivirus, string office, string idteamviewer, string passteamviewer, DateTime fecha, string observaciones, int estado, string usuresponsable, int TipoEquipo, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Ingresa_Guia", _conexion);
            _comando.Parameters.AddWithValue("@nrogce", nroGuia);
            _comando.Parameters.AddWithValue("@rutcli", rutcliente);
            _comando.Parameters.AddWithValue("@nomusu", nomusuario);
            _comando.Parameters.AddWithValue("@ctaser", CueServidor);
            _comando.Parameters.AddWithValue("@passer", passServidor);
            _comando.Parameters.AddWithValue("@nrsgce", numserie);
            _comando.Parameters.AddWithValue("@sisgce", sisasignado);
            _comando.Parameters.AddWithValue("@codsuc", sucursal);
            _comando.Parameters.AddWithValue("@nomeqp", nomequipo);
            _comando.Parameters.AddWithValue("@deseqp", descripcion);
            _comando.Parameters.AddWithValue("@diripe", dirrecionip);
            _comando.Parameters.AddWithValue("@sisope", sisoperativo);
            _comando.Parameters.AddWithValue("@antgce", antivirus);
            _comando.Parameters.AddWithValue("@ofcgce", office);
            _comando.Parameters.AddWithValue("@idetvw", idteamviewer);
            _comando.Parameters.AddWithValue("@pastvw", passteamviewer);
            _comando.Parameters.AddWithValue("@fecgce", fecha);
            _comando.Parameters.AddWithValue("@obsgce", observaciones);
            _comando.Parameters.AddWithValue("@codest", estado);
            _comando.Parameters.AddWithValue("@usrgce", usuresponsable);
            _comando.Parameters.AddWithValue("@TipoEquipo", TipoEquipo);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand actualizarGuia(int nroGuia, string nomusuario, string CueServidor, string passServidor, string numserie, string sisasignado, int sucursal, string nomequipo, string descripcion, string dirrecionip, string sisoperativo, string antivirus, string office, string idteamviewer, string passteamviewer, DateTime fecha, string observaciones, int estado, string usuresponsable, int TipoEquipo, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Actualizar_Guia", _conexion);
            _comando.Parameters.AddWithValue("@nrogce", nroGuia);
            //_comando.Parameters.AddWithValue("@rutcli", rutcliente);
            _comando.Parameters.AddWithValue("@nomusu", nomusuario);
            _comando.Parameters.AddWithValue("@ctaser", CueServidor);
            _comando.Parameters.AddWithValue("@passer", passServidor);
            _comando.Parameters.AddWithValue("@nrsgce", numserie);
            _comando.Parameters.AddWithValue("@sisgce", sisasignado);
            _comando.Parameters.AddWithValue("@codsuc", sucursal);
            _comando.Parameters.AddWithValue("@nomeqp", nomequipo);
            _comando.Parameters.AddWithValue("@deseqp", descripcion);
            _comando.Parameters.AddWithValue("@diripe", dirrecionip);
            _comando.Parameters.AddWithValue("@sisope", sisoperativo);
            _comando.Parameters.AddWithValue("@antgce", antivirus);
            _comando.Parameters.AddWithValue("@ofcgce", office);
            _comando.Parameters.AddWithValue("@idetvw", idteamviewer);
            _comando.Parameters.AddWithValue("@pastvw", passteamviewer);
            _comando.Parameters.AddWithValue("@fecgce", fecha);
            _comando.Parameters.AddWithValue("@obsgce", observaciones);
            _comando.Parameters.AddWithValue("@codest", estado);
            _comando.Parameters.AddWithValue("@usrgce", usuresponsable);
            _comando.Parameters.AddWithValue("@TipoEquipo", TipoEquipo);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand EliminarGuia(int NroGuia, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Eliminar_Guia", _conexion);
            _comando.Parameters.AddWithValue("@nrogce", NroGuia);

            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand ObtenerRutNomClientes(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_RutNom_Cliente ", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand ObtenerDatosTabPar_Cod(int codigo, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Busca_DatosTabPar_Cod ", _conexion);
            _comando.Parameters.AddWithValue("@cod", codigo);
            _comando.Connection.Close();
            return _comando;
        }

        //************************* Fin RGajardo **************************************************
        //************************* FDiaz*****************************************************
        public static SqlCommand LLenar_Lista_Cliente(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Mostrar_Clientes", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Buscar_Cliente(Decimal Rut, string Nombre, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Cliente", _conexion);
            _comando.Parameters.AddWithValue("@Rut", Rut);
            _comando.Parameters.AddWithValue("@Nombre", Nombre);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Agrega_Cliente(Decimal Rut, string Digito, string Nombre, string Direccion, int Comuna, int Ciudad, string TelFijo, string TelMovil, string Correo, DateTime Fecha, int Estado, string Usuario, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Agrega_Cliente", _conexion);
            _comando.Parameters.AddWithValue("@Rut", Rut);
            _comando.Parameters.AddWithValue("@Digito", Digito);
            _comando.Parameters.AddWithValue("@Nombre", Nombre);
            _comando.Parameters.AddWithValue("@Direccion", Direccion);
            _comando.Parameters.AddWithValue("@Comuna", Comuna);
            _comando.Parameters.AddWithValue("@Ciudad", Ciudad);
            _comando.Parameters.AddWithValue("@Fijo", TelFijo);
            _comando.Parameters.AddWithValue("@Movil", TelMovil);
            _comando.Parameters.AddWithValue("@Correo", Correo);
            _comando.Parameters.AddWithValue("@Fecha", Fecha);
            _comando.Parameters.AddWithValue("@Estado", Estado);
            _comando.Parameters.AddWithValue("@Usuario", Usuario);

            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Buscar_Cliente_Por_Id(Decimal Rut, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Cliente_Por_Id", _conexion);
            _comando.Parameters.AddWithValue("@Rut", Rut);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Actualiza_Cliente(Decimal Rut, string Nombre, string Direccion, int Comuna, int Ciudad, string TelFijo, string TelMovil, string Correo, DateTime Fecha, int Estado, string Usuario, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Actualiza_Cliente", _conexion);
            _comando.Parameters.AddWithValue("@Rut", Rut);
            _comando.Parameters.AddWithValue("@Nombre", Nombre);
            _comando.Parameters.AddWithValue("@Direccion", Direccion);
            _comando.Parameters.AddWithValue("@Comuna", Comuna);
            _comando.Parameters.AddWithValue("@Ciudad", Ciudad);
            _comando.Parameters.AddWithValue("@Fijo", TelFijo);
            _comando.Parameters.AddWithValue("@Movil", TelMovil);
            _comando.Parameters.AddWithValue("@Correo", Correo);
            _comando.Parameters.AddWithValue("@Fecha", Fecha);
            _comando.Parameters.AddWithValue("@Estado", Estado);
            _comando.Parameters.AddWithValue("@Usuario", Usuario);

            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Eliminar_Cliente(Decimal Rut, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Eliminar_Cliente", _conexion);
            _comando.Parameters.AddWithValue("@Rut", Rut);
            _comando.Connection.Close();
            return _comando;
        }

        public static SqlCommand LLenar_Cliente(Decimal Rut, string Nombre, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_LLena_Informe_Cliente", _conexion);
            _comando.Parameters.AddWithValue("@Rut", Rut);
            _comando.Parameters.AddWithValue("@Nombre", Nombre);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Busca_Nombre_Parametro_Padre(int Codigo, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Busca_Nombre_Parametro_padre", _conexion);
            _comando.Parameters.AddWithValue("@Codigo", Codigo);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand LLenar_Lista_Ensamble(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Mostrar_Ensambles", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Ingresa_Ensamble_Cabecera(Decimal NHoja, Decimal RutCliente, DateTime Fecha, int TipoEquipo, string Venta, string Tecnico, int CodEstado, string Usuario, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Nuevo_Ensamble_Cabecera", _conexion);
            _comando.Parameters.AddWithValue("@NroHoja", NHoja);
            _comando.Parameters.AddWithValue("@RutCliente", RutCliente);
            _comando.Parameters.AddWithValue("@Fecha", Fecha);
            _comando.Parameters.AddWithValue("@CodigoTeq", TipoEquipo);
            _comando.Parameters.AddWithValue("@Venta", Venta);
            _comando.Parameters.AddWithValue("@Tecnico", Tecnico);
            _comando.Parameters.AddWithValue("@CodigoEst", CodEstado);
            _comando.Parameters.AddWithValue("@Usuario", Usuario);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Modifica_Ensamble_Cabecera(Decimal NHoja, DateTime Fecha, int TipoEquipo, string Venta, string Tecnico, int CodEstado, string Usuario, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Modifica_Ensamble_Cabecera", _conexion);
            _comando.Parameters.AddWithValue("@NroHoja", NHoja);
            _comando.Parameters.AddWithValue("@Fecha", Fecha);
            _comando.Parameters.AddWithValue("@CodigoTeq", TipoEquipo);
            _comando.Parameters.AddWithValue("@Venta", Venta);
            _comando.Parameters.AddWithValue("@Tecnico", Tecnico);
            _comando.Parameters.AddWithValue("@CodigoEst", CodEstado);
            _comando.Parameters.AddWithValue("@Usuario", Usuario);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Insertar_Ensamble_Detalle(Decimal NHoja, int Cor, int CodigoHrw, string Serie, string Marca, string Modelo, string Observacion, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Nuevo_Ensamble_Detalle", _conexion);
            _comando.Parameters.AddWithValue("@NroHoja", NHoja);
            _comando.Parameters.AddWithValue("@Cor", Cor);
            _comando.Parameters.AddWithValue("@CodigoHrw", CodigoHrw);
            _comando.Parameters.AddWithValue("@Serie", Serie);
            _comando.Parameters.AddWithValue("@Marca", Marca);
            _comando.Parameters.AddWithValue("@Modelo", Modelo);
            _comando.Parameters.AddWithValue("@Observacion", Observacion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Modificar_Ensamble_Detalle(Decimal NHoja, int Cor, int CodigoHrw, string Serie, string Marca, string Modelo, string Observacion, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Modificar_Ensamble_Detalle", _conexion);
            _comando.Parameters.AddWithValue("@NroHoja", NHoja);
            _comando.Parameters.AddWithValue("@Cor", Cor);
            _comando.Parameters.AddWithValue("@CodigoHrw", CodigoHrw);
            _comando.Parameters.AddWithValue("@Serie", Serie);
            _comando.Parameters.AddWithValue("@Marca", Marca);
            _comando.Parameters.AddWithValue("@Modelo", Modelo);
            _comando.Parameters.AddWithValue("@Observacion", Observacion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Buscar_Nro_Ensamble(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Genera_Numero_HEQ", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Cancelar_Nro_Ensamble(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Resta_Numero_HEQ", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand ObtenerIdeNomTecnicos(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_RutNom_Tecnico", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Busca_Codigo_Parametro_Por_Nombre(string Descripcion, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Busca_Codigo_Parametro_Por_Nombre", _conexion);
            _comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Buscar_Cabecera_Por_NroHoja(Decimal NroHoja, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Cabecera_Por_NroHoja", _conexion);
            _comando.Parameters.AddWithValue("@NroHoja", NroHoja);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Buscar_Detalle_Por_NroHoja(Decimal NroHoja, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Detalle_Por_NroHoja", _conexion);
            _comando.Parameters.AddWithValue("@NroHoja", NroHoja);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Buscar_Ensamble_Por_RutFecha(Decimal Rut, string Fecha, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Ensamble_Por_RutFecha", _conexion);
            _comando.Parameters.AddWithValue("@Rut", Rut);
            _comando.Parameters.AddWithValue("@Fecha", Fecha);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand LLenar_Consulta_Guia(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_LLena_Consulta", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand Buscar_LLenar_Consulta(string Fecha, int Estado, int TipoEquipo, string IP, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_LLena_Consulta_GC", _conexion);
            _comando.Parameters.AddWithValue("@Fecha", Fecha);
            _comando.Parameters.AddWithValue("@Estado", Estado);
            _comando.Parameters.AddWithValue("@TipoEquipo", TipoEquipo);
            _comando.Parameters.AddWithValue("@IP", IP);
            _comando.Connection.Close();
            return _comando;
        }
        //************************* Fin FDiaz ************************************************
        //************************* Jvasquez **************************************************
        public static SqlCommand ObtenerParamentrosPorTabla(int CodTab, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Busca_Parametro_Por_Tabla", _conexion);
            _comando.Parameters.AddWithValue("@PCODTAB", CodTab);

            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand ObtenerParamentrosPadre(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Busca_Parametro_Padre", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand ObtenerParamentrosInfComPorCodigo(int CodTab, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_ListaParametroCompletos_PorCodigo", _conexion);
            _comando.Parameters.AddWithValue("@PCODTAB", CodTab);
            _comando.Connection.Close();
            return _comando;
        }
        //************************* Fin JVasquez *********************************************
        //************************* KCandia *********************************************
        public static SqlCommand LlenarGuiasDevueltas(int Cliente, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Guias_Devueltas", _conexion);
            _comando.Parameters.AddWithValue("@cliente", Cliente);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand ModificarEstadoGuia(int NroGuia, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Modificar_Estado_Guia", _conexion);
            _comando.Parameters.AddWithValue("@nroguia", NroGuia);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand LlenarConsultaDevoluciones(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Devoluciones", _conexion);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand BuscarLlenaDevoluciones(string Fecha, int Sucursal, int Cliente, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Llena_Devoluciones", _conexion);
            _comando.Parameters.AddWithValue("@Fecha", Fecha);
            _comando.Parameters.AddWithValue("@Sucursal", Sucursal);
            _comando.Parameters.AddWithValue("@cliente", Cliente);
            _comando.Connection.Close();
            return _comando;
        }
        //************************* Fin KCandia *********************************************
        //*************************Andres****************************************************

        public static SqlCommand BuscarEnsamble(int ruten, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_Buscar_Ensamble", _conexion);
            _comando.Parameters.AddWithValue("@rut", ruten);
            _comando.Connection.Close();
            return _comando;
        }
        //*************************Fin Andres************************************************

        public static SqlCommand BuscarTecnicoPorNombre(string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_BUSCA_LLENA_TECNICOS_GC", _conexion);
            _comando.Connection.Close();
            return _comando;
        }

        public static SqlCommand BuscarTecnicoPorRut(int rutecnico, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("CE_BUSCAR_TECNICOS_POR_RUT_GC", _conexion);
            _comando.Parameters.AddWithValue("@tec_rut_tec", rutecnico);
            _comando.Connection.Close();
            return _comando;
        }
        public static SqlCommand AgregarRegistroEquipos(string rut_per,string nomb_per, string telefono, string departamento, string correo, DateTime ingreso,
            string tipo, string soporte, int licencia_off, int licencia_win, string equipo, string hardware, string marca, string modelo, string serie,
            string comentarios, string CadenaConexion)
        {
            string _cadenaconexion = CadenaConexion;
            SqlConnection _conexion = new SqlConnection(_cadenaconexion);
            SqlCommand _comando = new SqlCommand("AgregarRegistroEquipo", _conexion);
            _comando.Parameters.AddWithValue("@rut", rut_per);
            _comando.Parameters.AddWithValue("@nombre", nomb_per);
            _comando.Parameters.AddWithValue("@telefono",telefono);
            _comando.Parameters.AddWithValue("@departamento", departamento);
            _comando.Parameters.AddWithValue("@correo", correo);
            _comando.Parameters.AddWithValue("@ingreso", ingreso);
            _comando.Parameters.AddWithValue("@tipo", tipo);
            _comando.Parameters.AddWithValue("@soporte", soporte);
            _comando.Parameters.AddWithValue("@licencia_off", licencia_off);
            _comando.Parameters.AddWithValue("@licencia_win", licencia_win);
            _comando.Parameters.AddWithValue("@cod_equipo", equipo);
            _comando.Parameters.AddWithValue("@hardware", hardware);
            _comando.Parameters.AddWithValue("@marca", marca);
            _comando.Parameters.AddWithValue("@modelo", modelo);
            _comando.Parameters.AddWithValue("@serie", serie);
            _comando.Parameters.AddWithValue("@comentario", comentarios);
            _comando.Connection.Close();
            return _comando;
        }
    }
}
