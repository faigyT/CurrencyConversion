﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConversionEntities
{
    public class ConversionRequest
    {
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public double Amount { get; set; }
    }
}
