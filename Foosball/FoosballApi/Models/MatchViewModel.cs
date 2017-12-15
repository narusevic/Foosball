using System;
using System.Collections.Generic;

namespace FoosballApi.Models
{
    public class MatchViewModel
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string Guest { get; set; }
        public int HostScore { get; set; }
        public int GuestScore { get; set; }
        public DateTime MatchDate { get; set; }
        public string Type { get; set; }
    }
}
