using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Evolent.Demo.Data.Entity.Master
{
    [Table("ContactMaster")]
    public class ContactMaster 
    {
        [Dapper.Contrib.Extensions.Key]
        public long ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }

}
