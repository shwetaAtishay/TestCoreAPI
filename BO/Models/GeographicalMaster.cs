using System;
using System.Collections.Generic;

namespace BO.Models
{
    public partial class GeographicalMaster : AddType
    {
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? CityId { get; set; }
        public int? AreaId { get; set; }
        public string Name { get; set; }
        public string PinCode { get; set; }
        public bool? IsActive { get; set; }
    }
    public partial class AddType
    {
        public string Type { get; set; }
    }
    public class GeoLocationMaster
    {
        public string Type { get; set; }
        public int? Id { get; set; }
    }
}
