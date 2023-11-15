using Microsoft.AspNetCore.Mvc;
using Laboratorium_3.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Migrations;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace Laboratorium_3.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        private List<SelectListItem> CreateOrganizationItemList()
        {
            var gr = new SelectListGroup()
            {
                Name = "Organizacje",
            };
            var group = new SelectListGroup()
            {
                Name = "Brak",
            };
            return _contactService.FindAllOrganizations().Select(e => new SelectListItem()
            {
                Text = e.Name,
                Value = e.Id.ToString(),
                Group = gr,
            }).Append(new SelectListItem()
                {
                Text = "Brak organizacji",
                Value = "",
                Selected = true,
                Group = group,
            }).ToList();
        }
        [HttpGet]
        public IActionResult Create()
        {
            Contact model = new Contact();
            model.OrganizationList = CreateOrganizationItemList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
           if (ModelState.IsValid)
           {
               _contactService.Add(model);
               return RedirectToAction("Index");
           }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var contact = _contactService.FindById(id);
            if (contact != null)
                contact.OrganizationList = CreateOrganizationItemList();
            return View(contact);
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.DeleteById(model.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }
    }
}
 