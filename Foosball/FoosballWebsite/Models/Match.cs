using System;
using System.Collections.Generic;

namespace FoosballWebsite.Models
{
    public class Match : IEntityBase
    {
        private bool _IsChangedHost;
        private bool _IsChangedGuest;

        private int _GuestScore;
        private int _HostScore;
        public Match()
        {
            Feeds = new List<Feed>();
        }
        public int Id { get; set; }
        public string Host { get; set; }
        public string Guest { get; set; }
        public int HostScore
        {
            get { return _HostScore; }
            set
            {
                if (_HostScore != value)
                    _IsChangedHost = true;

                _HostScore = value;
            }
        }
        public int GuestScore
        {
            get{ return _GuestScore; }
            set
            {
                if (_GuestScore != value)
                    _IsChangedGuest = true;

                _GuestScore = value;
            }
        }
        public bool IsChangedHost
        {
            get { return _IsChangedHost; }
        }
        public bool IsChangedGuest
        {
            get { return _IsChangedGuest; }
        }
        public DateTime MatchDate { get; set; }
        public MatchTypeEnums Type { get; set; }

        public ICollection<Feed> Feeds { get; set; }
    }
}
