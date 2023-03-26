using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class EmpleadoRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Empleado> personas;
        public EmpleadoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
            personas = new List<Empleado>();
        }
        public void Guardar(Empleado empleado)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Persona(Identificacion,Nombre,Apellido,Tipo,Telefono,Direccion,Correo) 
                                        values (@Identificacion,@Nombre,@Apellido,@Tipo,@Telefono,@Direccion,@Correo)";
                command.Parameters.AddWithValue("@Identificacion", empleado.IdEmpleado);
                command.Parameters.AddWithValue("@Usuario", empleado.administrador.Usuario);
                command.Parameters.AddWithValue("@Contraseña", empleado.administrador.Contraseña);
                command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                command.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                command.Parameters.AddWithValue("@Correo", empleado.Correo);
                command.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Persona> ConsultarTodos()
        {
            personas.Clear();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Persona";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Persona persona = DataReaderMapToPerson(dataReader);
                        personas.Add(persona);
                    }
                }
            }
            return personas;
        }

        private Persona DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Persona persona;
            string tipo = (string)dataReader["Tipo"];
            if (tipo == "CLIENTE")
            {
                persona = new Cliente();
            }
            else if (tipo == "EMPLEADO")
            {
                persona = new Empleado();
            }
            else
            {
                persona = new Proveedor();
            }
            persona.Identificacion = (string)dataReader["Identificacion"];
            persona.Nombre = (string)dataReader["Nombre"];
            persona.Apellido = (string)dataReader["Apellido"];
            persona.Tipo = (string)dataReader["Tipo"];
            persona.Telefono = (string)dataReader["Telefono"];
            persona.Direccion = (string)dataReader["Direccion"];
            persona.Correo = (string)dataReader["Correo"];

            return persona;
        }
    }
}
