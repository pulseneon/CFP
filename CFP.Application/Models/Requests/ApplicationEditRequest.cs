﻿namespace CFP.Application.Models.Requests
{
    public class ApplicationEditRequest
    {
        public string Activity { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Outline { get; set; }
    }
}
