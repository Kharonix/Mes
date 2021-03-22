using Mes.Models.WebUi;
using System.Net;
using System.Web.Http;

namespace Mes.Controllers.Api.V1
{
    public class WebApiErrorController : ApiController
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        public BaseResponse Handle404()
        {
            return new BaseResponse
            {
                success = false,
                error = new Error()
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = "Ресурс не найден"
                }
            };

        }
    }
}