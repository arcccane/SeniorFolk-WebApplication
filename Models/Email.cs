﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seniorfolk.Models
{
    public class Email
    {
        public string To { get; set; }
        //public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        //public bool IsHtml { get; set; }
    }
}
