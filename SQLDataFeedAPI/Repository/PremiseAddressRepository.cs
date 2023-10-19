using Npgsql;
using SQLDataFeedAPI.Models;
using SQLDataFeedAPI.Models.Dto;
using SQLDataFeedAPI.Repository.IRepository;
using System.Data;

namespace SQLDataFeedAPI.Repository
{
    public class PremiseAddressRepository:IPremiseAddressRepository
    {
        public PremiseAddressRepository()
        {

        }
        public async  Task<List<PrmiseAddress>> GetAllPremiseAdressesSync()
        {
            return await GetAllPremisesHardcoded();//GetAllPremises();
        }
        public async Task<List<PrmiseAddress>> GetPostalCodePremiseAddress(string PostalCode)
        {
            return await GetAllPremisesHardcoded();//GetPostalCodePremises(PostalCode);
        }

        private async Task<List<PrmiseAddress>> GetAllPremises()
        {
            List<PrmiseAddress> premises = new List<PrmiseAddress>();

            var cs = "Host=localhost;Username=postgres;Password=password;Database=dvdrental";
            NpgsqlConnection conn = new NpgsqlConnection(cs);
            conn.Open();
            var sql = "select * from Premises_detail";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            var datareader = cmd.ExecuteReader();
            while (await datareader.ReadAsync())
            {
                var oPremise = new PrmiseAddress
                {
                    Premises_detail_id = datareader.GetInt16("Premises_detail_id"),
                    premise_id = datareader.GetInt16("premise_id"),
                    premise_name = datareader.GetString("premise_name"),
                    postal_code = datareader.GetString("postal_code"),
                    buiolding_no = datareader.GetString("buiolding_no"),
                    building_name = datareader.GetString("building_name"),
                    area_name = datareader.GetString("area_name"),
                    city_name = datareader.GetString("city_name"),
                    state_name = datareader.GetString("state_name"),
                    country_name = datareader.GetString("country_name"),
                    mprn = datareader.GetString("mprn"),
                    mpan = datareader.GetString("mpan"),
                };
                premises.Add(oPremise);
                // DataTable dt= new DataTable();
                // dt.Load(datareader);                           
            }
            conn.Close();
            return  premises;
        }

        private async Task<List<PrmiseAddress>> GetAllPremisesHardcoded()
        {
            List<PrmiseAddress> premises = new List<PrmiseAddress>();

                var oPremise = new PrmiseAddress
                {
                    Premises_detail_id = 1,
                    premise_id = 1,
                    premise_name = "Green Villa Apartment",
                    postal_code = "560100",
                    buiolding_no = "12",
                    building_name = "E  Block",
                    area_name = "Electronic city",
                    city_name = "Bengaluru",
                    state_name = "Karnataka",
                    country_name = "India",
                    mprn = "mpr_123",
                    mpan = "mpa_123"
                };

                premises.Add(oPremise);
            var oPremise1 = new PrmiseAddress
            {
                Premises_detail_id = 2,
                premise_id = 2,
                premise_name = "Green Villa Villa",
                postal_code = "560180",
                buiolding_no = "12",
                building_name = "A  Block",
                area_name = "White field city",
                city_name = "Bengaluru",
                state_name = "Karnataka",
                    country_name = "India",
                mprn = "mpr_123",
                mpan = "mpa_123"
            };
            premises.Add(oPremise1);
            return premises;
            // DataTable dt= new DataTable();
            // dt.Load(datareader);                           
        }                    

        private async Task<List<PrmiseAddress>> GetPostalCodePremises(string postalcode)
        {
            List<PrmiseAddress> premises = new List<PrmiseAddress>();

            var cs = "Host=localhost;Username=postgres;Password=password;Database=dvdrental";
            NpgsqlConnection conn = new NpgsqlConnection(cs);
            conn.Open();
            var sql = @"select * from Premises_detail where postal_code like @postalcode";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@postalcode", string.Format("%{0}%", postalcode));
            var datareader = cmd.ExecuteReader();
            while (await datareader.ReadAsync())
            {
                var oPremise = new PrmiseAddress
                {
                    Premises_detail_id = datareader.GetInt16("Premises_detail_id"),
                    premise_id = datareader.GetInt16("premise_id"),
                    premise_name = datareader.GetString("premise_name"),
                    postal_code = datareader.GetString("postal_code"),
                    buiolding_no = datareader.GetString("buiolding_no"),
                    building_name = datareader.GetString("building_name"),
                    area_name = datareader.GetString("area_name"),
                    city_name = datareader.GetString("city_name"),
                    state_name = datareader.GetString("state_name"),
                    country_name = datareader.GetString("country_name"),
                    mprn = datareader.GetString("mprn"),
                    mpan = datareader.GetString("mpan"),
                };
                premises.Add(oPremise);
                // DataTable dt= new DataTable();
                // dt.Load(datareader);                           
            }
            conn.Close();
            return premises;
        }


    }
}
