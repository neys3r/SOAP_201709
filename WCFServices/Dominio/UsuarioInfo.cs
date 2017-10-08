using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServices.Dominio
{
    [DataContract]
    public class UsuarioInfo
    {
        [DataMember]
        public string NumeroDoc { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string ApellidoMat { get; set; }
        [DataMember]
        public string ApellidoPat { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string Sexo { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Cuenta { get; set; }
        [DataMember]
        public decimal Saldo { get; set; }
        [DataMember]
        public string tipoDocumento { get; set; }
        [DataMember]
        public string TipoDoc { get; set; }
        [DataMember]
        public string tipo { get; set; }

        [DataMember]
        public bool estado { get; set; }



    }
}