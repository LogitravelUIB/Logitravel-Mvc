using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Uib.Mvc.Controllers
{
    public class HotelController : ApiController
    {

        // GET api/hotel/5
        public IEnumerable<Models.Hotel> Get(int city, string lang = "es")
        {
            var ret = new List<Models.Hotel>();
            var dt = GetData(city, lang);

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                ret.Add(ParseHotel(dt.Rows[i]));
            }



            return ret;
        }

        private Models.Hotel ParseHotel(System.Data.DataRow row)
        {
            var hot = new Models.Hotel();
            hot.Category = row["hot_categoria"].ToString();
            hot.Code = int.Parse(row["hot_codigo"].ToString());
            hot.Description = row["hot_descripcion"].ToString();
            hot.Latitude = row["hot_latitud"].ToString();
            hot.Longitude = row["hot_longitud"].ToString();
            hot.Image = row["hot_imagen"].ToString();
            hot.Name = row["hot_nombre"].ToString();
            hot.Price = new Models.Price();
            hot.Price.Board = row["hpm_regimen"].ToString();
            hot.Price.CheckIn = DateTime.Parse(row["hpm_fechaEntrada"].ToString());
            hot.Price.Nigths = int.Parse(row["HPM_noches"].ToString());
            hot.Price.Pvp = decimal.Parse(row["HPM_pvp"].ToString());

            return hot;
        }

        private System.Data.DataTable GetData(int city, string lang)
        {

            try
            {
                SqlConnection myConnection = new SqlConnection("user id=Uib;" +
                                     "password=Uib;server=localhost;" +
                                     "Trusted_Connection=yes;" +
                                     "database=Uib; " +
                                     "connection timeout=30");
                myConnection.Open();
                var command = new SqlCommand("GET_HOTELS_BY_CITY", myConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@city", city);
                command.Parameters.AddWithValue("@lang", lang);
                SqlDataReader reader = command.ExecuteReader();
                var dataTable = new System.Data.DataTable();

                dataTable.Load(reader);
                reader.Close();
                myConnection.Close();
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
    }
}
