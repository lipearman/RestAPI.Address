using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RestAPI.Address.Model
{



    public class AddressModel
    {
        //[MaxLength(50)]
        //public string ClaimStatus { get; set; }
        //[MaxLength(100)]
        //public string TempPolicy { get; set; }
        //[MaxLength(100)]
        //public string RefNo { get; set; }



        public string Unknown { get; set; }
        public string StreetAddress { get; set; }
        public string Route { get; set; }
        public string Intersection { get; set; }
        public string Political { get; set; }
        public string Country { get; set; }
        public string AdministrativeAreaLevel1 { get; set; }
        public string AdministrativeAreaLevel2 { get; set; }
        public string AdministrativeAreaLevel3 { get; set; }
        public string ColloquialArea { get; set; }
        public string Locality { get; set; }
        public string Sublocality { get; set; }
        public string Neighborhood { get; set; }
        public string Premise { get; set; }
        public string Subpremise { get; set; }
        public string PostalCode { get; set; }
        public string NaturalFeature { get; set; }
        public string Airport { get; set; }
        public string Park { get; set; }
        public string PointOfInterest { get; set; }
        public string PostBox { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public string PostalTown { get; set; }
        public string PostalCodePrefix { get; set; }
        public string SublocalityLevel1 { get; set; }
        public string SublocalityLevel2 { get; set; }
        public string SublocalityLevel3 { get; set; }
        public string SublocalityLevel4 { get; set; }
        public string SublocalityLevel5 { get; set; }
        public string AdministrativeAreaLevel4 { get; set; }
        public string AdministrativeAreaLevel5 { get; set; }
        public string PostalCodeSuffix { get; set; }
        public string FormattedAddress { get; set; }


    }
}
