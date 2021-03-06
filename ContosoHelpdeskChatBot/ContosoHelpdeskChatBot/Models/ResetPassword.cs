﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoHelpdeskChatBot.Models
{
    [Table("ResetPassword")]
    public partial class ResetPassword
    {
        [Key]
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public Int64? MobileNumber { get; set; }

        public int? PassCode { get; set; }

        public string TempPassword { get; set; }
    }
}
