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
        public Response<InterestRateModel> Get()
        {
            List<InterestRateModel> GetCountryInterestRate = Helper.getInterestRate();

            Response<InterestRateModel> retVal = new Response<InterestRateModel>();

            if (GetCountryInterestRate != null)
            {
                retVal.Result = true;
                retVal.ResultCode = 200;
                retVal.Message = "İşlem Başarılı";
                retVal.Comment = GetCountryInterestRate.Count() + " Ülke Bulundu";
                retVal.Data = GetCountryInterestRate;
            }
            else
            {
                retVal.Result = false;
                retVal.ResultCode = -1;
                retVal.Message = "Hata";
                retVal.Comment = "Veriye Ulaşılamadı.";
            }

            return retVal;
        }
    }
}