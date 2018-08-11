using Demo.Controllers;
using GoogleMaps.LocationServices;
using HotelApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace HotelApi.Controllers
{
    public class GoogleApiController : ApiController
    {




        [Route("api/GoogleApi/{add}")]
        public List<Latitude> Get([FromUri]string add)
        {
            Latitude HD = new Latitude();
            List<Latitude> latLongList = new List<Latitude>();
            string sURL = "https://maps.googleapis.com/maps/api/place/autocomplete/xml?input="+add+"&types=geocode&language=en&key=AIzaSyAFAfIYYn-j8qsBgk8j4f3RWXEvlJZIhvI";
            // var address = "pune";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(sURL);
            XmlNodeList elementList = xmldoc.GetElementsByTagName("description");
            for (int i = 0; i < 4; i++)
            {
                HD.address = elementList[i].InnerXml;
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(HD.address);

                HD.latitude = point.Latitude;
                HD.longitude = point.Longitude;
                double lat = Convert.ToDouble(HD.latitude);
                double longi = Convert.ToDouble(HD.longitude);
                latLongList.Add(HD);
            }
            // HotelController h1 = new HotelController();
            // return h1.Gethotels(lat,longi);

            //   HotelController.GetDetails(HD);
            return latLongList;
            
        }

        //[HttpPost]

        //public List<string> HotelList(Latitude ld)
        //{
        //    HotelController h1 = new HotelController();
        //    double lat = Convert.ToDouble(ld.latitude);
        //    double longi = Convert.ToDouble(ld.longitude);
        //    return h1.Gethotels(lat, longi);

        //}


        //[HttpPost]
        //public Latitude Post(Latitude ld)
        //{
        //    //Latitude Hd = new Latitude();
        //    //Hd.address = ld.address;


        //    var locationService = new GoogleLocationService();
        //    var point = locationService.GetLatLongFromAddress(ld.address);

        //    ld.latitude = point.Latitude;
        //    ld.longitude = point.Longitude;

        //    HotelController.GetDetails(ld);
        //    return ld;
        //}

    }
}
