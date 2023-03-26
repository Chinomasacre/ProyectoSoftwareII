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
       
    }
}
