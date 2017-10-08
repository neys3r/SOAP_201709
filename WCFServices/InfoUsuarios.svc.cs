using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Dominio;
using WCFServices.Errores;
using WCFServices.Persistencia;

namespace WCFServices
{
    public class InfoUsuarios : IInfoUsuarios
    {
        private UsuarioInfoDAO usuarioInfoDAO = new UsuarioInfoDAO();
        public UsuarioInfo CrearUsuarioInfo(UsuarioInfo usuarioACrear)
        {
            if (usuarioInfoDAO.ObtenerUserInfo(usuarioACrear.NumeroDoc) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El usuario ya existe"
                    }, new FaultReason("Error al intentar creación"));
            }
            return usuarioInfoDAO.CrearUserInfo(usuarioACrear);
        }

        public List<UsuarioInfo> obtenerListaUsuarioInfo()
        {
            return usuarioInfoDAO.obtenerListaUsuarioInfo();
        }

        public UsuarioInfo ObtenerUsuarioInfo(string idusuario)
        {
            return usuarioInfoDAO.ObtenerUserInfo(idusuario);
        }
    }
}
