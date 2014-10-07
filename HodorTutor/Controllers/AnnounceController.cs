using HodorTutor.Models.ViewModels.Announces;
using HodorTutor.Services.Interfaces;
using HodorTutor.Services.Messaging.AnnounceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace HodorTutor.Controllers
{
    public class AnnounceController : Controller
    {
        private IAnnounceService _announceService;

        public AnnounceController(
            IAnnounceService announceService)
        {
            _announceService = announceService;
        }

        public ActionResult Index()
        {
            AnnounceView view = new AnnounceView();
            view.AnnouneList = _announceService.GetAllAnnounce().ToList();
            return View(view);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AnnounceView request)
        {
            var createAnnounce = new CreateAnnounceRequest();
            createAnnounce.CreateDate = DateTime.Now;
            createAnnounce.Detail = request.Detail;
            createAnnounce.Title = request.Title;
            createAnnounce.UserId = WebSecurity.CurrentUserId;

            try
            {
                _announceService.CreateAnnounce(createAnnounce);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
