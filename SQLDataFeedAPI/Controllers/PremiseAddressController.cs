using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLDataFeedAPI.Models;
using SQLDataFeedAPI.Models.Dto;
using SQLDataFeedAPI.Repository.IRepository;
using System.Net;

namespace SQLDataFeedAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiseAddressController : ControllerBase
    {
        private readonly IPremiseAddressRepository _repository;
        private readonly IMapper _mapper;
        protected APIResponse _APIResponse;
        public PremiseAddressController(IMapper mapper,IPremiseAddressRepository PremiseAddressRepository) { 
            _mapper = mapper;
            _repository = PremiseAddressRepository;
            _APIResponse = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetAllPremiseAddresses()
        {
            try
            {
                List<PrmiseAddress> premiseaddress = await _repository.GetAllPremiseAdressesSync();
                _APIResponse.StatusCode = HttpStatusCode.OK;
                _APIResponse.IsSuccess = true;
                _APIResponse.Result = _mapper.Map<List<PrmiseAddressDto>>(premiseaddress);
                return Ok(_APIResponse);
            }
            catch (Exception ex)
            {
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                _APIResponse.ErrorMessages.Add(ex.Message);
                return BadRequest(_APIResponse);
            }
        }
        [HttpGet("postalcode:string", Name = "GetPostalCodePremisses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> GetPostalCodePremisses(string postalcode)
        {
            try
            {
                if (string.IsNullOrEmpty(postalcode))
                {
                    _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                    _APIResponse.IsSuccess = false;
                    return BadRequest(_APIResponse);

                }
                
                List<PrmiseAddress> postalcodepremises = await _repository.GetPostalCodePremiseAddress(postalcode);
                if (postalcodepremises.Count==0)
                {
                    _APIResponse.StatusCode = HttpStatusCode.NotFound;
                    _APIResponse.IsSuccess = false;
                    return NotFound(_APIResponse);

                }                
                _APIResponse.StatusCode = HttpStatusCode.OK;
                _APIResponse.IsSuccess = true;
                _APIResponse.Result = _mapper.Map<List<PrmiseAddressDto>>(postalcodepremises);
                return Ok(_APIResponse);
            }
            catch (Exception ex)
            {
                _APIResponse.IsSuccess = false;
                _APIResponse.StatusCode = HttpStatusCode.BadRequest;
                _APIResponse.ErrorMessages.Add(ex.Message);
                return BadRequest(_APIResponse);
            }            
        }


    }
}
