using Laboratorium2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Laboratorium2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult BirthForm()
        {
            return View();
        }

        public IActionResult BirthResult([FromForm] Birth model)
        {
            if (!model.IsValid())
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return View(model);
        }
    }
}
