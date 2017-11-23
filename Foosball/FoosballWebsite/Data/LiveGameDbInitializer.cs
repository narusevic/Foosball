using System;
using System.Collections.Generic;
using System.Linq;
using FoosballWebsite.Models;

namespace FoosballWebsite.Data
{
    public class LiveGameDbInitializer
    {
        private static LiveGameContext _context;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _context = (LiveGameContext)serviceProvider.GetService(typeof(LiveGameContext));

            InitializeSchedules();
        }

        private static void InitializeSchedules()
        {
            if (!_context.Matches.Any())
            {
                _context.SaveChanges();
            }
        }
    }
}