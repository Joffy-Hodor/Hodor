using HodorTutor.Model.Provinces;
using HodorTutor.Model.Tutors;
using HodorTutor.Models.ViewModels.Tutors;
using HodorTutor.Services.Interfaces;
using HodorTutor.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace HodorTutor.Controllers
{
    public class TutorController : Controller
    {
        private ITutorService _tutorService;
        private IProvinceService _provinceService;

        public TutorController(
            ITutorService tutorService,
            IProvinceService provinceService)
        {
            _tutorService = tutorService;
            _provinceService = provinceService;
        }

        public ActionResult Index(string Name)
        {
            TutorView tutorView = new TutorView();
            var tutors = _tutorService.GetAllTutors();
            if (!string.IsNullOrEmpty(Name))
                tutorView.TutorList = tutors.Where(e => e.City == Name).ToList();
            else
                tutorView.TutorList = tutors;
            return View(tutorView);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize]
        public ActionResult Register()
        {
            var provinceList = _provinceService.GetListProvince();
            SelectList li = new SelectList(provinceList.Select(e => e.Name));
            var existTutor = _tutorService.GetTutorByUserId(WebSecurity.CurrentUserId);
            var tutor = new TutorView();
            if (existTutor != null)
            {
                tutor.FirstName = existTutor.FirstName;
                tutor.LastName = existTutor.LastName;
                tutor.TelephoneNumber = existTutor.TelephoneNumber;
                tutor.Address = existTutor.Address;
                tutor.SelectedCity = existTutor.City;
            }
            else
                tutor.SelectedCity = "- กรุณาเลือกจังหวัด -";

            tutor.CityList = li;
            return View(tutor);
        }

        [HttpPost]
        public ActionResult Register(TutorView request)
        {
            int UserId = WebSecurity.CurrentUserId;

            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            else
            {
                try
                {
                    TutorRequest tutorRequest = new TutorRequest();
                    tutorRequest.UserId = UserId;
                    tutorRequest.FirstName = request.FirstName;
                    tutorRequest.LastName = request.LastName;
                    tutorRequest.TelephoneNumber = request.TelephoneNumber;
                    tutorRequest.Address = request.Address;
                    tutorRequest.City = request.SelectedCity;

                    _tutorService.Register(tutorRequest);
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View();
                }
            }
        }

        [Authorize]
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

        [Authorize]
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

        public ActionResult Province()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Province(Province request)
        {
            _provinceService.Add(request);
            return View();
        }
    }
}
