using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace MyLibrary
{
    public class Connexion : IConnexion
    {
        public String ConnectApi(String url)
        {
            // ------------------- Create a request for the URL.---------------		
            WebRequest request = WebRequest.Create(url);

            // ----------------- If required by the server, set the credentials.-----------------
            request.Credentials = CredentialCache.DefaultCredentials;

            // ---------------- Get the response.-------------------------
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // -------------- Display the status.---------------------------
            //Console.WriteLine(response.StatusDescription);

            // ---------- Get the stream containing content returned by the server.----------------
            Stream dataStream = response.GetResponseStream();

            // -------------Open the stream using a StreamReader for easy access.--------------
            StreamReader reader = new StreamReader(dataStream);

            // --------------Read the content.----------------
            string responseFromServer = reader.ReadToEnd();

            //------------- Display the content.-----------------
            //Console.WriteLine(responseFromServer);

            // ------------- Cleanup the streams and the response -----------------
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
