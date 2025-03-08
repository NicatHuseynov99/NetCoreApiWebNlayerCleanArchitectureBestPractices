using App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Api.Controllers
{
    public class CustomController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ServiceResult<T> result)
        {
            if (result.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = result.Status.GetHashCode()
                };
            }
            return new ObjectResult(result)
            {
                StatusCode = result.Status.GetHashCode()
            };
        }

        [NonAction]
        public IActionResult CreateActionResult(ServiceResult result)
        {
            if (result.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = result.Status.GetHashCode()
                };
            }
            return new ObjectResult(result)
            {
                StatusCode = result.Status.GetHashCode()
            };
        }


    }

}