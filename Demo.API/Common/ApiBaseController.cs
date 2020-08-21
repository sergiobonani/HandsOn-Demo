using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Application.ViewModels.Notifications;

namespace Demo.API.Common
{
    [ApiExceptionFilterAttribute]
    public class ApiBaseController : Controller
    {
        public IActionResult JsonOrError<T>(ResultWrap<T> result)
        {
            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return Json(result.Data);
                }
                return Json(result);
            }
            else
            {
                var resultJson = Json(result.Errors);
                //Error Status 512 - Erro referente a negócio
                //
                switch (result.Error)
                {
                    case EKnowErrors.BusinessError:
                        resultJson.StatusCode = 512;
                        break;
                    case EKnowErrors.NotFoundError:
                        resultJson.StatusCode = 404;
                        break;
                    case EKnowErrors.PermissionError:
                        resultJson.StatusCode = 401;
                        break;
                    default:
                        resultJson.StatusCode = 501;
                        break;
                }

                return resultJson;
            }
        }

    }
}