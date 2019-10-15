using BlueBadge.Models;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueBadge.WebMVC.Controllers
{
    public class SupportGroupController : Controller
    {
        // GET: SupportGroup
        public ActionResult Index()
        {
            var service = new SupportGroupService();
            var model = service.GetSupportGroups();

            return View(model);
        }

        // GET create
        public ActionResult Create()
        {
            return View();
        }

        //POST create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupportGroupCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = new SupportGroupService();

            if (service.CreateSupportGroup(model))
            {
                TempData["SaveResult"] = "Support Group was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Support Group could not be created.");

            return View(model);
        }

        //GET details
        public ActionResult Details(int id)
        {
            var svc = new SupportGroupService();
            var model = svc.GetSupportGroupById(id);

            return View(model);
        }

        //GET edit
        public ActionResult Edit(int id)
        {
            var service = new SupportGroupService();
            var detail = service.GetSupportGroupById(id);
            var model = new SupportGroupEdit
            {
                SupportGroupId = detail.SupportGroupId,
                Name = detail.Name,
                Location = detail.Location,
                PhoneNumber = detail.PhoneNumber,
                Website = detail.Website,
                Details = detail.Details
            };
            return View(model);
        }

        //POST edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SupportGroupEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SupportGroupId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = new SupportGroupService();

            if (service.UpdateSupportGroup(model))
            {
                TempData["SaveResult"] = "Support Group was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Support Group could not be updated.");
            return View(model);
        }

        //GET delete
        public ActionResult Delete(int id)
        {
            var svc = new SupportGroupService();
            var model = svc.GetSupportGroupById(id);

            return View(model);
        }

        //POST delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = new SupportGroupService();

            service.DeleteSupportGroup(id);

            TempData["SaveResult"] = "Support Group was deleted.";

            return RedirectToAction("Index");
        }
    }
}