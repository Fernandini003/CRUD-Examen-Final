﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PREGUNTA1.Models
{
    public class productPreview
    {
        public int ProductReviewID { get; set; }
        public int ProductID { get; set; }
        public string ReviewerName { get; set; }
        public DateTime ReviewDate { get; set; }
        public string EmailAddress { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}