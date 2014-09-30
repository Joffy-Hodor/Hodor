using HodorTutor.Model.Announces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HodorTutor.Models.ViewModels.Announces
{
    public class AnnounceView
    {
        public int UserId { get; set; }

        [Display(Name = "หัวข้อประกาศ")]
        [Required(ErrorMessage = "กรุณากรอกหัวข้อประกาศ")]
        public string Title { get; set; }

        [Display(Name = "รายละเอียด")]
        [Required(ErrorMessage = "กรุณากรอกรายละเอียด")]
        public string Detail { get; set; }

        public int TagsId { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsLocked { get; set; }

        public IEnumerable<Announce> AnnouneList { get; set; }
    }
}