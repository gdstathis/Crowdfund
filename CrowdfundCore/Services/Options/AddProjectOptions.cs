﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CrowdfundCore.Services.Options
{
    public class AddProjectOptions
    {
        public string title { get; set; }
        public string Description { get; set; }
        public decimal budget { get; set; }
        public string nameCreator { get; set; }
        public DateTime deadline { get; set; }
    }
}
