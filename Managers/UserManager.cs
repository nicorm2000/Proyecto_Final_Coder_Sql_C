using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Proyecto_Final_Coder2023.Data;
using Proyecto_Final_Coder2023.Models;

namespace Proyecto_Final_Coder2023.Managers
{
    public class UserManager : DBConnection
    {
        public List<Usuario> GetUsers()
        {
            List<Usuario> usuarios = new List<Usuario>();

            query = "SELECT * FROM Usuario";

            try
            {
                command.CommandText = query;

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuario UsuarioTemporal = new Usuario();

                        UsuarioTemporal.Id = reader.GetInt64(0);
                        UsuarioTemporal.Nombre = reader.GetString(1);
                        UsuarioTemporal.Apellido = reader.GetString(2);
                        UsuarioTemporal.Username = reader.GetString(3);
                        UsuarioTemporal.Contrasena = reader.GetString(4);
                        UsuarioTemporal.Email = reader.GetString(5);

                        usuarios.Add(UsuarioTemporal);
                    }
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public Usuario GetUserById(int id)
        {
            Usuario UsuarioTemporal = new Usuario();

            query = "SELECT * FROM Usuario WHERE Id = @id";

            try
            {
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    UsuarioTemporal.Id = reader.GetInt64(0);
                    UsuarioTemporal.Nombre = reader.GetString(1);
                    UsuarioTemporal.Apellido = reader.GetString(2);
                    UsuarioTemporal.Username = reader.GetString(3);
                    UsuarioTemporal.Contrasena = reader.GetString(4);
                    UsuarioTemporal.Email = reader.GetString(5);
                }
                return UsuarioTemporal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public Usuario Login(string user, string password)
        {
            Usuario UsuarioTemporal = new Usuario();

            query = "SELECT * FROM Usuario WHERE NombreUsuario = @user AND Contraseña = @password";

            try
            {
                command.CommandText = query;
                command.Parameters.AddWithValue("@user", user);
                command.Parameters.AddWithValue("@password", password);

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    UsuarioTemporal.Id = reader.GetInt64(0);
                    UsuarioTemporal.Nombre = reader.GetString(1);
                    UsuarioTemporal.Apellido = reader.GetString(2);
                    UsuarioTemporal.Username = reader.GetString(3);
                    UsuarioTemporal.Contrasena = reader.GetString(4);
                    UsuarioTemporal.Email = reader.GetString(5);
                }
                return UsuarioTemporal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

    }
}
