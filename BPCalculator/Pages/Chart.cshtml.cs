﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BPCalculator.Pages
{
    public class ChartModel : PageModel
    {
        private readonly ILogger<ChartModel> _logger;

        public ChartModel(ILogger<ChartModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}