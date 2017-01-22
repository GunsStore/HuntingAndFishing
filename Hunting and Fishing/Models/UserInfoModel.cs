using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hunting_and_Fishing.Models
{
    public class UserInfoModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string ZIP { get; set; }

        [Required]
        [MaxLength(20)]
        public int PhoneNumber { get; set; }

        [Required]
        [MaxLength(10)]
        public int EGN { get; set; }

        [Required]
        [MaxLength(9)]
        public int IDNO { get; set; }

        [Required]
        [StringLength(50)]
        public string IssuedFrom { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }

        public int UserId { get; set; }
    }
}