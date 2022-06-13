﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RageServer.Data.Models
{
    public class AccountModel
    {
        [Key]
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public int Money { get; set; }
    }
}