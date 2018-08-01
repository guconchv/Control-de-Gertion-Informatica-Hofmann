﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentacion
{
    public class DetalleParametros
    {

    }

    public class variables
    {
        public string nom_archivo { get; set; }
        public int cargos { get; set; }
    }

    public class Correo
    {
        public string mail { get; set; }
        public string host { get; set; }
        public string port { get; set; }
        public string username { get; set; }
    }

    public class Parametros
    {
        public int codigo { get; set; }
        public int cod_orden { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
    }

    public class Tabla_parametros {

        public int CodPar { get; set; }
        public int codigo { get; set; }
        public string CodDescrip { get; set; }
        public string CodAux { get; set; }
        public int CodSis { get; set; }
        public int CdoEstado { get; set; }
        
     
    }

    public class Codigo_TablasPadres
    {
        public static int codEstados = 1 ;
        public static int CodComunas = 2 ;
        public static int CodTipoHardware = 3 ;
        public static int CodCiudades = 4 ;
        public static int CodMeses = 5 ;
        public static int CodPerfilesUsuario = 6 ;
        public static int CodEstadosGuias = 7;
        public static int CodTipoEquipo = 8;
        public static int CodSucursales = 9;
    }

    public class Tabla_Detalle
    {

        public Decimal NroHoja { get; set; }
        public int Cor { get; set; }
        public int CodigoHrw { get; set; }
        public string Serie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Observacion { get; set; }

    }
}
     
