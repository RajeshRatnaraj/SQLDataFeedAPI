namespace SQLDataFeedAPI.Models
{
    public class PrmiseAddress
    {
        public int Premises_detail_id { get; set; }
        public int premise_id { get; set; }
        public string? premise_name { get; set; }
        public string? postal_code { get; set; }
        public string? buiolding_no { get; set; }
        public string? building_name { get; set; }
        public string? area_name { get; set; }
        public string? city_name { get; set; }
        public string? state_name { get; set; }
        public string? country_name { get; set; }
        public string? mprn { get; set; }
        public string? mpan { get; set; }

    }
}
