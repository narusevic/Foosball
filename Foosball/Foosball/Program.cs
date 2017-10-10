using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Foosball.DataAccess;
using Foosball.Repositories;
using Unity;

namespace Foosball
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetupRepositories();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BallTracker());
        }

        private static void SetupRepositories()
        {
            var dataContext = new DataContext();

            var matchRepository = new MatchRepository(dataContext);
            var playersRepo = new PlayerRepository(dataContext);
        }
    }
}
