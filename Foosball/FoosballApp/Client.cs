using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoosballApp.Exceptions;
using static System.String;

namespace FoosballApp
{
    public class Client
    {
        private string _baseURL;
        private WebClient _webClient;

        public Client()
        {
            _baseURL = "http://192.168.1.242:4860/";
            _webClient = new WebClient
            {
                //Headers = { [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded" }
            };
        }

        public int AddTeams(string teamName1, string temaName2)
        {
            if (IsNullOrEmpty(teamName1) || temaName2.Contains(" "))
            {
                throw new NameIsIncorrectException(teamName1);
            }

            if (IsNullOrEmpty(temaName2) || temaName2.Contains(" "))
            {
                throw new NameIsIncorrectException(temaName2);
            }

            var uri = _baseURL + "api/CreateMatch/";
            var parameters = SetParams(
                new[]
                {
                    teamName1,
                    temaName2
                });

            string HtmlResult = _webClient.UploadString(uri, parameters);

            return int.TryParse(HtmlResult, out int id) ? id : 0;
        }

        private string SetParams(string[] parameters, string[] values)
        {
            string result = string.Empty;

            for (int i = 0; i < parameters.Length; i++)
            {
                if (result != string.Empty)
                    result += "&";

                result += $"{parameters[i]}={values[i]}";
            }

            return result;
        }

        private string SetParams(string[] values)
        {
            string result = string.Empty;

            for (int i = 0; i < values.Length; i++)
            {
                if (result != string.Empty)
                    result += "&";

                result += $"{values[i]}";
            }

            return result;
        }

        public void UpdateScore(bool isHost, int scoreHost, int scoreGuest, int matchId)
        {
            var uri = _baseURL + "api/UpdateScores/" + matchId;
            var parameters = SetParams(
                new[]
                {
                    scoreHost.ToString(),
                    scoreGuest.ToString()
                });

            string HtmlResult = _webClient.UploadString(uri, parameters);
        }
    }
}