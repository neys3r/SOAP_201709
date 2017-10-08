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
    public class Usuarios : IUsuarios
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();

        public UsuarioInfo accesoAccountLogin(Usuario usuario)
        {
            return usuarioDAO.accesoAccountLogin(usuario);
        }

        public Usuario CrearUsuario(Usuario usuarioACrear)
        {
            if (usuarioDAO.Obtener(usuarioACrear.NumeroDoc) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El usuario ya existe"
                    }, new FaultReason("Error al intentar creación"));
            }
            return usuarioDAO.Crear(usuarioACrear);
        }

        public Usuario ObtenerUsuario(string idusuario)
        {
            return usuarioDAO.Obtener(idusuario);
        }


        // Usuario Info

        


        //public Usuario ModificarUsuario(Usuario usuarioAModificar)
        //{
        //    return usuarioDAO.Modificar(usuarioAModificar);
        //}

        //public void EliminarUsuario(int dni)
        //{
        //    usuarioDAO.Eliminar(dni);
        //}

        //public List<Usuario> ListarUsuarios()
        //{
        //    return usuarioDAO.Listar();
        //}

        //public string Americo(string nombre)
        //{
        //    return nombre;
        //}


    }
}
