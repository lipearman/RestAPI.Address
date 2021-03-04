using Google.Maps;
using Google.Maps.Geocoding;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Address.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Address.Controllers
{

    public class Address
    {
        [Required]
        public string address { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        //// GET: api/<AddressController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<AddressController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<AddressController>
        [HttpPost]
        public AddressModel Post([FromBody]Address value)
        {
            var result = new AddressModel();

            //always need to use YOUR_API_KEY for requests.  Do this in App_Start.
            GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyDV-zSK92fcaZnxQvZdcfL0RlMAqhVHKWk"));


            var request = new GeocodingRequest();
            request.Address = value.address;
            request.Language = "TH";
            request.Region = "Thai";
            var response = new GeocodingService().GetResponse(request);

            //The GeocodingService class submits the request to the API web service, and returns the
            //response strongly typed as a GeocodeResponse object which may contain zero, one or more results.

            //Assuming we received at least one result, let's get some of its properties:
            if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
            {
                var data = response.Results.Last();//.First();

                result.FormattedAddress = data.FormattedAddress;

                foreach (var item in data.AddressComponents)
                {
                    foreach (var itemtype in item.Types)
                    {
                        switch (itemtype)
                        {
                            case Google.Maps.Shared.AddressType.Unknown: result.Unknown = item.LongName; break;
                            case Google.Maps.Shared.AddressType.StreetAddress: result.StreetAddress = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Route: result.Route = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Intersection: result.Intersection = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Political: result.Political = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Country: result.Country = item.LongName; break;
                            case Google.Maps.Shared.AddressType.AdministrativeAreaLevel1: result.AdministrativeAreaLevel1 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.AdministrativeAreaLevel2: result.AdministrativeAreaLevel2 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.AdministrativeAreaLevel3: result.AdministrativeAreaLevel3 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.ColloquialArea: result.ColloquialArea = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Locality: result.Locality = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Sublocality: result.Sublocality = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Neighborhood: result.Neighborhood = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Premise: result.Premise = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Subpremise: result.Subpremise = item.LongName; break;
                            case Google.Maps.Shared.AddressType.PostalCode: result.PostalCode = item.LongName; break;
                            case Google.Maps.Shared.AddressType.NaturalFeature: result.NaturalFeature = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Airport: result.Airport = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Park: result.Park = item.LongName; break;
                            case Google.Maps.Shared.AddressType.PointOfInterest: result.PointOfInterest = item.LongName; break;
                            case Google.Maps.Shared.AddressType.PostBox: result.PostBox = item.LongName; break;
                            case Google.Maps.Shared.AddressType.StreetNumber: result.StreetNumber = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Floor: result.Floor = item.LongName; break;
                            case Google.Maps.Shared.AddressType.Room: result.Room = item.LongName; break;
                            case Google.Maps.Shared.AddressType.PostalTown: result.PostalTown = item.LongName; break;
                            case Google.Maps.Shared.AddressType.PostalCodePrefix: result.PostalCodePrefix = item.LongName; break;
                            case Google.Maps.Shared.AddressType.SublocalityLevel1: result.SublocalityLevel1 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.SublocalityLevel2: result.SublocalityLevel2 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.SublocalityLevel3: result.SublocalityLevel3 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.SublocalityLevel4: result.SublocalityLevel4 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.SublocalityLevel5: result.SublocalityLevel5 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.AdministrativeAreaLevel4: result.AdministrativeAreaLevel4 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.AdministrativeAreaLevel5: result.AdministrativeAreaLevel5 = item.LongName; break;
                            case Google.Maps.Shared.AddressType.PostalCodeSuffix: result.PostalCodeSuffix = item.LongName; break;
                        }
                    }

                }

            }
            else
            {
                Console.WriteLine("Unable to geocode.  Status={0} and ErrorMessage={1}", response.Status, response.ErrorMessage);
            }


            //if (!ModelState.IsValid)
            //    return new BadRequestObjectResult(ModelState);

            return result;
        }

        //// PUT api/<AddressController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AddressController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
