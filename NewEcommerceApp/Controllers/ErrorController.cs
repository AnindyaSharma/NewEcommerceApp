using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace NewEcommerceApp.Controllers
{
    public class ErrorController : Controller
    {
        // GET: /<controller>/
        [Route("Error/{statusCode}")]
        public IActionResult HttpRequest(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "404 Page not found";
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    ViewBag.QS = statusCodeResult.OriginalQueryString;
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Content Not Found";
                    break;
            }
            return View("NotFound");
        }

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            // Retrieve the exception Details
            var exceptionHandlerPathFeature =
                HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            // LogError() method logs the exception under Error category in the log
            logger.LogError($"The path {exceptionHandlerPathFeature.Path} " +
                $"threw an exception {exceptionHandlerPathFeature.Error}");

            return View("Error");
        }
    }
}