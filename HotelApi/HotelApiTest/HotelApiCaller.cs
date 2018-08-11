using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Models;
using RestSharp;
using Newtonsoft.Json;

namespace HotelApiTest
{
    class HotelApiCaller
    {
        private static RestClient client = new RestClient(" http://localhost:57298/api");

        public static void AddHotel(Hotels hotel)
        {
            var Request = new RestRequest("Hotel",Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            Request.AddParameter("application/json",json,ParameterType.RequestBody);

            IRestResponse response = client.Execute(Request);
           
           
        }

        public static List<Hotels> GetHotel()
        {
            var Request = new RestRequest("Hotel",Method.GET);
            IRestResponse response = client.Execute(Request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotels>>(content);

        }

        public static void UpdateHotel(Hotels hotel)
        {
            var Request = new RestRequest("Hotel",Method.PUT);
            string json = JsonConvert.SerializeObject(hotel);
            Request.AddParameter("application/json",json,ParameterType.RequestBody);
            IRestResponse response = client.Execute(Request);

        }
 
    }
}
