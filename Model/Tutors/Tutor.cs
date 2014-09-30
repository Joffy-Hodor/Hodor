using HodorTutor.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HodorTutor.Model.Helpers;

namespace HodorTutor.Model.Tutors
{
    public class Tutor : Entity<Guid>
    {
        public Tutor()
            : base()
        {
            Id = Guid.NewGuid();
        }

        public virtual int UserId { get; set; }

        [Display(Name = "ชื่อ")]
        [Required(ErrorMessage = "กรุณากรอกชื่อ")]
        public virtual string FirstName { get; set; }

        [Display(Name = "นามสกุล")]
        [Required(ErrorMessage = "กรุณากรอกนามสกุล")]
        public virtual string LastName { get; set; }

        [Display(Name = "เบอร์โทรศัพท์")]
        [Required(ErrorMessage = "กรุณากรอกเบอร์โทรศัพท์")]
        public virtual string TelephoneNumber { get; set; }

        [Display(Name = "ที่อยู่")]
        public virtual string Address { get; set; }

        [Display(Name = "จังหวัด")]
        public virtual string City { get; set; }
    }
}
