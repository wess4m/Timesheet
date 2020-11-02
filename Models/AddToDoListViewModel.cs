using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineUserToDoList.Models
{
    public class AddToDoListViewModel
    {
        [Required]
        [Display(Name = "To do title")]
        public string TodoTitle { get; set; }
        [Required]
        [Display(Name = "Due date")]
        [DisplayFormat(ApplyFormatInEditMode = true,
               DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DueDate { get; set; }

    }
}