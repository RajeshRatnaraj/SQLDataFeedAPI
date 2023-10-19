using SQLDataFeedAPI.Models;
using SQLDataFeedAPI.Models.Dto;

namespace SQLDataFeedAPI.Repository.IRepository
{
    public interface IPremiseAddressRepository
    {
        public  Task<List<PrmiseAddress>> GetAllPremiseAdressesSync();
        public Task<List<PrmiseAddress>> GetPostalCodePremiseAddress(string PostalCode);

    }
}
