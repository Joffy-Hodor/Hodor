using HodorTutor.Model.Tutors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HodorTutor.Models.ViewModels.Tutors
{
    public class TutorView
    {
        public virtual int UserId { get; set; }

        [Display(Name = "ชื่อ")]
        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        public string FirstName { get; set; }

        [Display(Name = "นามสกุล")]
        [Required(ErrorMessage = "กรุณากรอกนามสกุล")]
        public string LastName { get; set; }

        [Display(Name = "เบอร์โทรศัพท์")]
        [Required(ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "ที่อยู่")]
        public string Address { get; set; }

        [Display(Name = "จังหวัด")]
        public string SelectedCity { get; set; }

        public SelectList CityList { get; set; }

        public IEnumerable<Tutor> TutorList { get; set; }
    }
}