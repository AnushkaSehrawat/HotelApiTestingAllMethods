using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demo.Models;
using HotelApi.Models;
using System.Net;
using System.IO;
using System.Xml;

namespace Demo.Controllers
{
    public class HotelController : ApiController
    {
        //        private static int _counter = 5;
        //        string line = "";
        //        List<string> hotelList = new List<string>();

        //        public List<string> Gethotels(double lat, double longi)
        //        {
        //            string latString = lat.ToString();
        //            string longiString = longi.ToString();

        //            string Url = "https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location=" + latString + "," + longiString + "&radius=15000&type=hotel&keyword=cruise&key=AIzaSyCEYBTJaRPGz2e-wq-u3aoEOTI6w-DtQ7A";
        //            XmlDocument xmldoc = new XmlDocument();
        //            xmldoc.Load(Url);
        //            XmlNodeList elementList = xmldoc.GetElementsByTagName("name");
        //            for (int i = 0; i < elementList.Count; i++)
        //            {
        //                hotelList.Add(elementList[i].InnerXml);
        //            }
        //            return hotelList;
        //        }


        //    }
        //}
        private int _counter = 5;

        public static List<Hotels> Hotel_list = new List<Hotels>()
        {
            new Hotels
            {
                Name="ABC",
                Address="XYZ",
                NoOfRooms=30,
                AirportCode=3,
                HotelId=1,
            },
            new Hotels
            {
                Name="XYZ",
                Address="LMN",
                HotelId=20,
                NoOfRooms=3,
                AirportCode=23,


            }
        };

        [HttpGet]

        public List<Hotels> ListOfHotels()
        {
            return Hotel_list;
        }

        [HttpGet]
        public Response SearchHotelById(int id)
        {
            Hotels h1 = new Hotels();




            var HotelObj = Hotel_list.Find((p) => p.HotelId == id);

            if (HotelObj != null)
            {
                return new Response
                {
                    hotel = HotelObj,
                    status = new Status()
                    {
                        RespMessage = "Success",
                        ErrorCode = 200,
                    }

                };
            }



            else
            {


                return new Response
                {
                    hotel = null,
                    status = new Status()
                    {
                        RespMessage = "Hotel Of Specified Id  does not exists.",
                        ErrorCode = 404,
                    }

                };
            }

        }

        [HttpGet]
        [ActionName("LAT")]
        public static Latitude GetDetails(Latitude ld)
        {
            return ld;
        }

        [HttpPost]

        public Response AddHotel(Hotels h1)
        {
           // h1.HotelId = ++_counter;
            Hotels HotelObj = null;
            HotelObj = Hotel_list.Find((p) => p.HotelId == h1.HotelId);

            if (HotelObj == null)
            {
                Hotel_list.Add(h1);
                return new Response()
                {
                    hotel = h1,
                    status = new Status()
                    {
                        RespMessage = "Hotel Successfully Added.",
                        ErrorCode = 200,
                    }
                };
            }
            else
            {
                return new Response()
                {
                    hotel = null,
                    status = new Status()
                    {
                        RespMessage = "Hotel with provided HotelId already exists.",
                        ErrorCode = 404,
                    }
                };
            }
        }
        [HttpPut]
        public Response BookHotel(int id, [FromBody]int NoOfRooms)
        {
            var HotelObj = Hotel_list.Find((p) => p.HotelId == id);
            if (HotelObj != null)
            {
                if (HotelObj.NoOfRooms > 0)
                {
                    HotelObj.NoOfRooms -= NoOfRooms;
                }
                if (HotelObj.NoOfRooms <= 0)
                {
                    return new Response()
                    {
                        hotel = null,
                        status = new Status()
                        {
                            RespMessage = "Rooms not avialable"
                        }
                    };

                }
                else
                {
                    return new Response()
                    {
                        hotel = null,
                        status = new Status()
                        {
                            RespMessage = "Hotel successfully booked",
                            ErrorCode = 200,
                        }
                    };
                }
            }
            else
            {
                return new Response()
                {
                    hotel = null,
                    status = new Status()
                    {
                        RespMessage = "Hotel with provided Id does not exists.",
                        ErrorCode = 404,

                    }
                };

            }

        }
        [HttpDelete]

        public Response DeleteHotel(int id)
        {
            var HotelObj = Hotel_list.Find(p => p.HotelId == id);
            if (HotelObj != null)
            {
                Hotel_list.Remove(HotelObj);
                return new Response()
                {
                    hotel = null,
                    status = new Status()
                    {
                        RespMessage = "Hotel Entry Successfully deleted.",
                        ErrorCode = 200,
                    }
                };
            }
            else
            {
                return new Response()
                {
                    hotel = null,
                    status = new Status()
                    {
                        RespMessage = "Hotel with provided Id does not exists. ",
                        ErrorCode = 404,
                    }
                };
            }
        }
    }
}
















