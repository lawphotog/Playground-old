using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MyViewModel
    {
        [DisplayName("Assigned Date :")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Assigned Date is required")]
        [DataType(DataType.Date)]
        [FutureDate("12/31/1899", ErrorMessage = "'{0}' must be a date between {1:d} and current date.")]
        public DateTime? AssignedDate { get; set; }
    }
}