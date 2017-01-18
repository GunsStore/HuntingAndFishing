namespace Hunting_and_Fishing.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
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
    }
}
