using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;
using System;

using ComuncactionComponents.Model.Config;
using Newtonsoft.Json;
using ComunicactionComponents.Model;

namespace ApiOdoo.Controllers
{
    public class BaseController : ControllerBase
    {
        public IOptions<RpcConnectionSettings> RpConnSettings;
        public BaseController()
        {
        }

        public BaseController(IOptions<RpcConnectionSettings> _RpConnSettings)
        {
            if (_RpConnSettings != null)
            {
                this.RpConnSettings = _RpConnSettings;
            }

            
        }

        [NonAction]
        public DataResponse FormatResponse(object Result)
        {
            DataResponse dtResponse = new DataResponse();

            if (Result == null)
            {
                dtResponse.Head.Status = false.ToString();
                dtResponse.Status = HttpStatusCode.NoContent;
            }
            else
            {
                dtResponse.Head.Status = true.ToString();
                dtResponse.Status = HttpStatusCode.OK;
            }

            dtResponse.Body.Response = JsonConvert.SerializeObject(Result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                MaxDepth = 20000
            });

            return dtResponse;
        }
        [NonAction]
        public DataResponse FormatException(Exception ex)
        {
            DataResponse dtException = new DataResponse();

            dtException.Head.error.Description = ex.Message.ToString();
            dtException.Head.Status = false.ToString();
            dtException.Head.error.Code = HttpStatusCode.ExpectationFailed.ToString();
            dtException.Head.StackError = JsonConvert.SerializeObject(ex, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            dtException.Status = HttpStatusCode.NoContent;
            dtException.Body.Response = "Error Capturando data Validar Servicio";

            return dtException;
        }
    }
}
