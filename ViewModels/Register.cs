using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Identity_Demo1.ViewModels
{
    public class Register
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
       
        
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Password doesn't match")]
        public string ConfirmPassword { get; set; }

    } 
}