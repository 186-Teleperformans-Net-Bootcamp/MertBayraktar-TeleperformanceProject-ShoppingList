﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleperformanceProject.ShoppingList.Application.DTOs
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expration { get; set; }
    }
}
