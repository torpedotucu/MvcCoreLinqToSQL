using Microsoft.Data.SqlClient;
using MvcCoreLinqToSQL.Models;
using System.Data;

namespace MvcCoreLinqToSQL.Repositories
{
    public class RepositoryEnfermos
    {
        private DataTable tablaEnfermos;

        public RepositoryEnfermos()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            string sql = "select * from ENFERMO";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString);
            this.tablaEnfermos=new DataTable();
            //Recuperamos los datos;
            adapter.Fill(this.tablaEnfermos);

            
        }

        public List<Enfermo> GetEnfermos()
        {
            var consulta = from datos in this.tablaEnfermos.AsEnumerable()
                           select datos;
            List<Enfermo> enfermos = new List<Enfermo>();
            foreach(var row in consulta)
            {
                Enfermo enfermo = new Enfermo();
                enfermo.Inscripcion=row.Field<string>("INSCRIPCION");
                enfermo.Apellido=row.Field<string>("APELLIDO");
                enfermo.Direccion=row.Field<string>("DIRECCION");
                enfermo.Fecha_Nac=row.Field<DateTime>("FECHA_NAC").ToString();
                enfermo.Sexo=row.Field<string>("S");
                enfermo.NSegSocial=row.Field<string>("NSS");
                enfermos.Add(enfermo);
            }
            return enfermos;
        }
        public Enfermo GetEnfermo(string idEnfermo)
        {
            var consulta = from datos in this.tablaEnfermos.AsEnumerable()
                           where datos.Field<string>("INSCRIPCION")==idEnfermo
                           select datos;
            var row = consulta.First();
            Enfermo enfermo = new Enfermo();
            enfermo.Inscripcion=row.Field<string>("INSCRIPCION");
            enfermo.Apellido=row.Field<string>("APELLIDO");
            enfermo.Direccion=row.Field<string>("DIRECCION");
            enfermo.Fecha_Nac=row.Field<DateTime>("FECHA_NAC").ToString();
            enfermo.Sexo=row.Field<string>("S");
            enfermo.NSegSocial=row.Field<string>("NSS");

            return enfermo;
        }

        public async Task DeleteEnfermoAsync(string idEnfermo)
        {
            string sql = "delete from ENFERMO WHERE INSCRIPCION=@idEnfermo";
            
        }
    }
}
