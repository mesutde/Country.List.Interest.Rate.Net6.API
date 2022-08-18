using Country.List.Interest.Rate.Net6.API.Model;
using Country.List.Interest.Rate.Net6.API.Utility;
using Microsoft.AspNetCore.Mvc;

namespace Country.List.Interest.Rate.Net6.API.Controllers
{
    [Route("GetCountryInterestRate")]
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        [HttpGet(Name = "GetCountryInterestRate")]
        public IEnumerable<InterestRateModel> Get()
        {
            List<InterestRateModel> GetCountryInterestRate = Helper.getInterestRate();

            return GetCountryInterestRate;
        }
    }
}