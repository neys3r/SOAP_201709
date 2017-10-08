using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServices.Dominio;

namespace WCFServices.Persistencia
{
    public class UsuarioDAO
    {

        private string CadenaConexion = "Data Source=(local);Initial Catalog=VWallet;Integrated Security=True;";

        public Usuario Crear(Usuario usuarioACrear)
        {
            Usuario usuarioCreado = null;
            string sql = "INSERT INTO usuario(num_doc,username,password,estado,cod_tipo) values(@num_doc, @username,@password,@estado,@cod_tipo)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@num_doc", usuarioACrear.NumeroDoc));
                    comando.Parameters.Add(new SqlParameter("@username", usuarioACrear.NomUsuario));
                    comando.Parameters.Add(new SqlParameter("@password", usuarioACrear.Contrasena));
                    comando.Parameters.Add(new SqlParameter("@estado", usuarioACrear.Estado));
                    comando.Parameters.Add(new SqlParameter("@cod_tipo", usuarioACrear.Tipo));
                    comando.ExecuteNonQuery();
                }
            }
            usuarioCreado = Obtener(usuarioACrear.NumeroDoc);
            return usuarioCreado;
        }

        public Usuario Obtener(string num_doc)
        {

            Usuario usuarioEncontrado = null;
            string sql = "SELECT * FROM usuario WHERE num_doc=@num_doc";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@num_doc", num_doc));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            usuarioEncontrado = new Usuario()
                            {
                                NumeroDoc = (string)resultado["num_doc"],
                                NomUsuario = (string)resultado["username"],
                                Contrasena = (string)resultado["password"],
                                Estado = (Boolean)resultado["estado"],
                                Tipo = (string)resultado["cod_tipo"]
                            };
                        }
                    }
                }
            }
            return usuarioEncontrado;
        }

        public UsuarioInfo accesoAccountLogin(Usuario user)
        {
            UsuarioInfo usuario = null;
            using (SqlConnection conn = new SqlConnection(CadenaConexion))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_acceder_cuenta",conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@user",user.NomUsuario));
                    cmd.Parameters.Add(new SqlParameter("@pass", user.Contrasena));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new UsuarioInfo()
                            {
                                Nombres = (string)reader["nombres"],
                                ApellidoMat = (string)reader["ape_materno"],
                                ApellidoPat = (string)reader["ape_paterno"],
                                Email =(string)reader["email"],
                                Direccion = (string)reader["direccion"],
                                NumeroDoc=(string)reader["num_doc"],
                                estado =(bool)reader["estado"],
                                tipoDocumento=(string)reader["cod_tipodoc"],
                                tipo=(string)reader["cod_tipo"]

                            };
                        }
                    }
                }
            }

            return usuario;
        }

        

    }
}