using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApi.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        public JsonResult JsonOk(string message = null, object obj = null)
        {
            return new JsonResult(new JsonResultModel() { Result = true, Data = obj, Message = message });
        }

        public JsonResult JsonError(string error)
        {
            return new JsonResult(new JsonResultModel() { Result = false, Error = error });
        }
    }
}
