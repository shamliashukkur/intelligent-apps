﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoHelpdeskChatBot.Models
{
    [Table("AppMsi")]
    public partial class AppMsi
    {
        [Key]
        public int Id { get; set; }

        public string AppName { get; set; }

        public string MsiPackage { get; set; }
    }
}
