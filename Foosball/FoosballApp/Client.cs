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
                Headers = { [HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded" }
            };
        }

        public void AddTeams(string team1, string team2)
        {
            if (IsNullOrEmpty(team1) || team2.Contains(" "))
            {
                throw new NameIsIncorrectException(team1);
            }

            if (IsNullOrEmpty(team2) || team2.Contains(" "))
            {
                throw new NameIsIncorrectException(team2);
            }

            var uri = _baseURL + "api/Match/Create/";
            var parameters = SetParams(
                new[]
                {
                    nameof(team1),
                    nameof(team2)
                },
                new[]
                {
                    team1,
                    team2
                });

            string HtmlResult = _webClient.UploadString(uri, parameters);
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
    }
}