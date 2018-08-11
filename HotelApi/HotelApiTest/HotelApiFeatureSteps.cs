using System;
using TechTalk.SpecFlow;
using Demo.Models;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;

namespace HotelApiTest
{
    [Binding]
    public class HotelApiFeatureSteps
    {
        Hotels h1 = new Hotels();
        List<Hotels> hotelResponse = new List<Hotels>();
        [Given(@"User provide valid hotel id '(.*)' and '(.*)' for hotel\.")]
        public void GivenUserProvideValidHotelIdAndForHotel_(int id, string name)
        {
            // ScenarioContext.Current.Pending();
           
            h1.HotelId = id;
            h1.Name = name;
           
        }
        
        [Given(@"User has added required details for the hotel\.")]
        public void GivenUserHasAddedRequiredDetailsForTheHotel_()
        {
            //ScenarioContext.Current.Pending();
            SetHotelBasicDetail();
        }

       

        [When(@"user calls AddHotel api\.")]
        public void WhenUserCallsAddHotelApi_()
        {
            //ScenarioContext.Current.Pending();
            HotelApiCaller.AddHotel(h1);
            hotelResponse = HotelApiCaller.GetHotel();
        }
        [Then(@"Hotel with id '(.*)' should be present in the response\.")]
        public void ThenHotelWithIdShouldBePresentInTheResponse_(int id)
        {
            //ScenarioContext.Current.Pending();
            var hotel = hotelResponse.Find(ht => ht.HotelId==id);
            hotel.Should().NotBeNull(string.Format("Hotel with {0} not found",id));

        }
        //[Given(@"User  provided id '(.*)'of the hotel which he wants to book and '(.*)'\.")]
        //public void GivenUserProvidedIdOfTheHotelWhichHeWantsToBookAnd_(int id, int noOfRooms)
        //{
        //    //ScenarioContext.Current.Pending();
        //    h1.HotelId = id;
        //    h1.NoOfRooms = noOfRooms;
        //}
        //[When(@"the user calls hotel api")]
        //public void WhenTheUserCallsHotelApi()
        //{
        //    //ScenarioContext.Current.Pending();
        //    HotelApiCaller.UpdateHotel(h1);
        //    hotelResponse = HotelApiCaller.GetHotel();
        //}
        //[Then(@"rooms should be booked in the hotel with provided '(.*)'\.")]
        //public void ThenRoomsShouldBeBookedInTheHotelWithProvided_(int id)
        //{
        //    ScenarioContext.Current.Pending();
        //    var hotel = hotelResponse.Find(hd => hd.HotelId == id);
        //    hotel.Should().NotBeNull(string.Format("Hotel with {0} not found", id));



        //}






        public void SetHotelBasicDetail()
        {
            h1.Address = "XYZ";
            h1.AirportCode = 2;
            h1.NoOfRooms = 3;
           
        }
       
    }
}
