﻿using System;

namespace challenge.Models
{
    public class Compensation
    {
        public string CompensationId { get; set; }
        public Employee Employee { get; set; }
        public int Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
