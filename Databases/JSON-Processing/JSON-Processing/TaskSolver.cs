namespace JSON_Processing
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class TaskSolver
    {
        public IEnumerable<Video> GetVideos(JObject json)
        {
            var videos = json["feed"]["entry"]
                .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()));

            return videos;
        }

        public string GetHtmlString(IEnumerable<Video> videos)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<!DOCTYPE html><html><body>");
            foreach (var video in videos)
            {
                html.AppendFormat("<div style=\"float:left; width: 500px; height: 360px; padding:10px; " +
                                  "margin:5px; background-color:#DDDDDD; border-radius:5px; border: 2px solid black;\"><h3 style=\"text-align: center;\">{2}</h3>" +
                                  "<iframe style=\"display:block; margin: 0 auto;\"width=\"440\" height=\"260\" " +
                                  "src=\"http://www.youtube.com/embed/{1}?autoplay=0\" " +
                                  "frameborder=\"0\" allowfullscreen></iframe>" +
                                  "<a href=\"{0}\" style=\"display:block; text-align: center; color:black; text-decoration:none; margin-top: 15px;\">Watch in YouTube</a></div>", 
                                  video.Link.Href, video.Id, video.Title);
            }
            html.Append("</body></html>");

            return html.ToString();
        }

        public void DownloadRss(string url, string fileName)
        {
            WebClient myWebClient = new WebClient { Encoding = Encoding.UTF8 };
            myWebClient.DownloadFile(url, fileName);
        }

        public XmlDocument GetXml(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            return xmlDoc;
        }

        public JObject GetJsonObject(XmlDocument xmlDoc)
        {
            string jsonString = JsonConvert.SerializeXmlNode(xmlDoc);
            var jsonObject = JObject.Parse(jsonString);

            return jsonObject;
        }

        public IEnumerable<JToken> GetVideosTitles(JObject jsonObj)
        {
            return jsonObj["feed"]["entry"]
                .Select(entry => entry["title"]);
        }

        public void PrintVideoTitles(IEnumerable<JToken> titles)
        {
            Console.WriteLine(String.Join(Environment.NewLine, titles));
        }

        public void SaveHtml(string html, string htmlName)
        {
            using (StreamWriter writer = new StreamWriter("../../" + htmlName, false, Encoding.UTF8))
            {
                writer.Write(html);
            }

            var currentDir = Directory.GetCurrentDirectory();
            var htmlDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug")) + htmlName;

            Console.WriteLine("Html saved in directory: {0}", htmlDir);
        }
    }
}
