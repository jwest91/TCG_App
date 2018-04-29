using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TCG_App.Models
{
    public class CommunityViewModels
    {
    }
    
    public class CreateCommunityViewModel
    {
        [Required]
        [Display(Name ="Community Name")]
        public string CommunityName { get; set; }

        [Required]
        [Display(Name = "Community Description")]
        public string CommunityDesc { get; set; }

        [Display(Name = "Community Location")]
        public string CommunityLoc { get; set; }
    }
}