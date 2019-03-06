using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please provide Name", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide Lastname", AllowEmptyStrings = false)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
    }
}