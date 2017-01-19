namespace Hunting_and_Fishing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Register
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(256)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Compare("Password", ErrorMessage = "Confirm your Password.")]
        public string ConfirmPassword { get; set; }

        //[StringLength(50)]
        //public string FirstName { get; set; }

        //[StringLength(50)]
        //public string MiddleName { get; set; }

        //[StringLength(50)]
        //public string LastName { get; set; }

        //[StringLength(50)]
        //public string City { get; set; }

        //[StringLength(50)]
        //public string Address { get; set; }

        //[StringLength(50)]
        //public string ZIP { get; set; }

        //[StringLength(20)]
        //public int PhoneNumber { get; set; }

        //[StringLength(10)]
        //public int EGN { get; set; }

        //[StringLength(9)]
        //public int IDNO { get; set; }

        //[StringLength(50)]
        //public string IssuedFrom { get; set; }
        
        //public DateTime IssuedOn { get; set; }
    }

    public class LogIn
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
