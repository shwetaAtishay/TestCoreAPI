﻿using BO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    public class StaffBO : ErrorBO
    {
        public class Staff : ErrorBO
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }
            public string Qualification { get; set; }
            public string Aadhaar { get; set; }
            public string Pan { get; set; }
            public string Profile { get; set; }
            public string Experience { get; set; }
            public string Type { get; set; }
            public string AadhaarExtension { get; set; }
            public string AadhaarContentType { get; set; }
            public string PanExtension { get; set; }
            public string PanContentType { get; set; }
            public string ProfileExtension { get; set; }
            public string ProfileContentType { get; set; }

            public string ExperienceExtension { get; set; }
            public string ExperienceContentType { get; set; }
        }
    }
}
