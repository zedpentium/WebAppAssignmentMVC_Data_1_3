using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAppAssignmentMVC_Data_1_3.Models
{
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Please enter name"), MaxLength(50)]
        [Display(Name = "Name")]
        public string PersonName { get; set; }


        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "* Please enter phonenumber"), MaxLength(30)]
        [Display(Name = "PhoneNumber")]
        public string PersonPhoneNumber { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "* Please choose city"), MaxLength(50)]
        [Display(Name = "City")]
        public string PersonCity { get; set; }


    }  
     
}
