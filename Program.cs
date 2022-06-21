using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace tp10_2022_TCassas {
    class Program {
        static void Main(string[] args) {
            var request = (HttpWebRequest)WebRequest.Create("https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try {
                using (WebResponse response = request.GetResponse()) {
                    using (Stream strReader = response.GetResponseStream()) {
                        using (StreamReader objReader = new StreamReader(strReader)) {
                            string responseBody = objReader.ReadToEnd();

                            var civilizationsList = JsonSerializer.Deserialize<CivilizationsList>(responseBody);

                            foreach(Civilization civilization in civilizationsList.Civilizations) {
                                Console.WriteLine(civilization.Id);
                            }
                        }
                    }
                }
            } catch (WebException ex) {
                Console.WriteLine("alto error");
            }
        }
    }
}