using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RestSharp;

namespace demo.TestClass
{
    [TestFixture]
    class API_test
    {

        [Test]
        [TestCase(TestName = "wrong password", Category = "login failer", Description = "This test uses a simple input value")]
        public void start()
        {
            string URL = "https://afimilkcrystalball-qa.azurewebsites.net/farms/1032003302/animals/prediction";
            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(URL);
            httpWebReq.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)httpWebReq.GetResponse();
            Stream stream = response.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonActors = reader.ReadToEnd();
            }
            Stream strdeam = response.GetResponseStream();

        }

    }
}
