using _19T1021067.DomainModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19T1021067.DataLayers.SQLServer
{
    public class CountryDAL : _BaseDAL, ICountryDAL
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="connectionString"></param>
        public CountryDAL(string connectionString) : base(connectionString)
        {
        }

        public IList<Country> List()
        {
            throw new NotImplementedException();
        }

        IList<Country> ICountryDAL.List()
        {
            List<Country> data = new List<Country>();
            using (SqlConnection cn = OpenConnection())
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "select * from Countries";
                cmd.CommandType = CommandType.Text;
                SqlDataReader dbReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dbReader.Read())
                {
                    data.Add(new Country()
                    {
                        CountryName = Convert.ToString(dbReader["CountryName"])
                    });
                }
                dbReader.Close();
                cn.Close();
            }
            return data;
        }
    }
}
