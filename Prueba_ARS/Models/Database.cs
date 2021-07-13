using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Prueba_ARS.Models
{
    public class Database
    {
        public SqlConnection conexion = new SqlConnection("Data source=localhost;" +
            " initial catalog = AFILIADOS_CARLOS_ELIEZEL_SANTOS_AYBAR; integrated security = true ");

       

       public List<Afiliado> ObtenerAfiliados()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM AFILIADOS", conexion);
            conexion.Open();

            List<Afiliado> Afiliados = new List<Afiliado>();
            SqlDataReader registro = comando.ExecuteReader();

            while (registro.Read()){
                Afiliado nuevo = new Afiliado()
                {
                    Id = int.Parse(registro[0].ToString()),
                    Nombres = registro[1].ToString(),
                    Apellidos = registro[2].ToString(),
                    Fecha_Nacimiento = DateTime.Parse(registro[3].ToString()),
                    Sexo = char.Parse(registro[4].ToString()),
                    Cedula = registro[5].ToString(),
                    Numero_Seguridad_Social = registro[6].ToString(),
                    Fecha_Registro = DateTime.Parse(registro[7].ToString()),
                    Monto_Consumido = decimal.Parse(registro[8].ToString()),
                    Id_Estatus = int.Parse(registro[9].ToString()),
                    Id_Plan = int.Parse(registro[10].ToString()),

                };

                Afiliados.Add(nuevo);
            }

            conexion.Close();

            return Afiliados;
        }


        public List<Afiliado> BuscarAfiliadosPorNombre(string Nombres)
        {
            SqlCommand comando = new SqlCommand($"SELECT * FROM AFILIADOS WHERE Nombres like '%{Nombres}%' ", conexion);
            conexion.Open();

            List<Afiliado> Afiliados = new List<Afiliado>();
            try
            {
                SqlDataReader registro = comando.ExecuteReader();

                while (registro.Read())
                {
                    Afiliado nuevo = new Afiliado()
                    {
                        Id = int.Parse(registro[0].ToString()),
                        Nombres = registro[1].ToString(),
                        Apellidos = registro[2].ToString(),
                        Fecha_Nacimiento = DateTime.Parse(registro[3].ToString()),
                        Sexo = char.Parse(registro[4].ToString()),
                        Cedula = registro[5].ToString(),
                        Numero_Seguridad_Social = registro[6].ToString(),
                        Fecha_Registro = DateTime.Parse(registro[7].ToString()),
                        Monto_Consumido = decimal.Parse(registro[8].ToString()),
                        Id_Estatus = int.Parse(registro[9].ToString()),
                        Id_Plan = int.Parse(registro[10].ToString()),

                    };

                    Afiliados.Add(nuevo);
                }
            }
            catch (Exception) { }

            conexion.Close();

            return Afiliados;
        }

        public bool GuardarAfiliado(Afiliado afiliado)
        {
            bool confirmacion = false;

            SqlCommand comando = new SqlCommand($"INSERT INTO AFILIADOS VALUES ('{afiliado.Nombres}', '{afiliado.Apellidos}', " +
                $"'{afiliado.Fecha_Nacimiento}', '{afiliado.Sexo}', '{afiliado.Cedula}', '{afiliado.Numero_Seguridad_Social}', " +
                $"'{afiliado.Fecha_Registro}', {afiliado.Monto_Consumido}, {afiliado.Id_Estatus}, {afiliado.Id_Plan})", conexion);
            conexion.Open();

            try
            {
                comando.ExecuteNonQuery();
                confirmacion = true;
            }
            catch { }
            finally
            {
                conexion.Close();
            }
            return confirmacion;
        }

        public Afiliado BuscarAfiliadosPorId(int Id)
        {
            SqlCommand comando = new SqlCommand($"SELECT * FROM AFILIADOS WHERE Id ={Id} ", conexion);
            conexion.Open();

            Afiliado afiliado = new Afiliado();
            try
            {
                SqlDataReader registro = comando.ExecuteReader();

                while (registro.Read())
                {
                     afiliado = new Afiliado()
                    {
                        Id = int.Parse(registro[0].ToString()),
                        Nombres = registro[1].ToString(),
                        Apellidos = registro[2].ToString(),
                        Fecha_Nacimiento = DateTime.Parse(registro[3].ToString()),
                        Sexo = char.Parse(registro[4].ToString()),
                        Cedula = registro[5].ToString(),
                        Numero_Seguridad_Social = registro[6].ToString(),
                        Fecha_Registro = DateTime.Parse(registro[7].ToString()),
                        Monto_Consumido = decimal.Parse(registro[8].ToString()),
                        Id_Estatus = int.Parse(registro[9].ToString()),
                        Id_Plan = int.Parse(registro[10].ToString()),

                    };

                }
            }
            catch (Exception) { }

            conexion.Close();

            return afiliado;
        }

        public List<Afiliado> BuscarAfiliadosMasivo(string Nombre, string Apellido, string cedula)
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM AFILIADOS", conexion);
            conexion.Open();

            List<Afiliado> Afiliados = new List<Afiliado>();
            try
            {
                SqlDataReader registro = comando.ExecuteReader();

                while (registro.Read())
                {
                    Afiliado nuevo = new Afiliado()
                    {
                        Id = int.Parse(registro[0].ToString()),
                        Nombres = registro[1].ToString(),
                        Apellidos = registro[2].ToString(),
                        Fecha_Nacimiento = DateTime.Parse(registro[3].ToString()),
                        Sexo = char.Parse(registro[4].ToString()),
                        Cedula = registro[5].ToString(),
                        Numero_Seguridad_Social = registro[6].ToString(),
                        Fecha_Registro = DateTime.Parse(registro[7].ToString()),
                        Monto_Consumido = decimal.Parse(registro[8].ToString()),
                        Id_Estatus = int.Parse(registro[9].ToString()),
                        Id_Plan = int.Parse(registro[10].ToString()),

                    };

                    Afiliados.Add(nuevo);
                }
            }
            catch (Exception) { }

            if(Nombre is not null)
            {
                Afiliados = Afiliados.Where(x => x.Nombres == Nombre).ToList();
            }
            if (Apellido is not null )
            {
                Afiliados = Afiliados.Where(x => x.Apellidos == Apellido).ToList();
            }
            if (cedula is not null)
            {
                Afiliados = Afiliados.Where(x => x.Cedula == cedula).ToList();
            }

            conexion.Close();

            return Afiliados;
        }

        public bool ActualizarAfiliado(Afiliado afiliado)
        {
            bool confirmacion = false;

            SqlCommand comando = new SqlCommand($"UPDATE AFILIADOS SET Nombres='{afiliado.Nombres}', Apellidos='{afiliado.Apellidos}', " +
                $"Fecha_Nacimiento='{afiliado.Fecha_Nacimiento}', Sexo='{afiliado.Sexo}', Cedula='{afiliado.Cedula}', Numero_Seguridad_Social='{afiliado.Numero_Seguridad_Social}', " +
                $"Fecha_Registro='{afiliado.Fecha_Registro}', Monto_Consumido={afiliado.Monto_Consumido}, Id_Estatus={afiliado.Id_Estatus}, Id_Plan={afiliado.Id_Plan} " +
                $" where Id = {afiliado.Id}", conexion);
            conexion.Open();

            try
            {
                comando.ExecuteNonQuery();
                confirmacion = true;
            }
            catch { }
            finally
            {
                conexion.Close();
            }
            return confirmacion;
        }

        public bool InactivarAfiliado(int Id)
        {
            bool confirmacion = false;

            SqlCommand comando = new SqlCommand($"UPDATE AFILIADOS SET Id_Estatus=2 where Id = {Id}", conexion);
            conexion.Open();

            try
            {
                comando.ExecuteNonQuery();
                confirmacion = true;
            }
            catch { }
            finally
            {
                conexion.Close();
            }
            return confirmacion;
        }

        public List<Plan> ObtenerPlanes()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM PLANES", conexion);
            conexion.Open();

            List<Plan> Planes = new List<Plan>();
            SqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                Plan nuevo = new Plan()
                {
                    Id = int.Parse(registro[0].ToString()),
                    Nombre_Plan = registro[1].ToString(),
                    Monto_Cobertura = decimal.Parse(registro[2].ToString()),
                    Fecha_Registro = DateTime.Parse(registro[3].ToString()),
                    Estatus = registro[4].ToString()
              
                  
                };

                Planes.Add(nuevo);
            }

            conexion.Close();

            return Planes;
        }

        public List<Estatus> ObtenerEstatus()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM ESTATUS", conexion);
            conexion.Open();

            List<Estatus> Estatuses = new List<Estatus>();
            SqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                Estatus nuevo = new Estatus()
                {
                    Id = int.Parse(registro[0].ToString()),        
                    Nombre_estatus = registro[1].ToString()


                };

                Estatuses.Add(nuevo);
            }

            conexion.Close();

            return Estatuses;
        }

        public void ActualizarMontoConsumido(int IdAfiliado, Decimal Monto_Consumido)
        {
            Afiliado afiliado = this.BuscarAfiliadosPorId(IdAfiliado);
            afiliado.Monto_Consumido += Monto_Consumido;
            this.ActualizarAfiliado(afiliado);

        }
    }
}
