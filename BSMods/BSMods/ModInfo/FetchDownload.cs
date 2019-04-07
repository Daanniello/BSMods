using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace BSMods
{
    static class FetchDownload
    {
        public static async Task InsertZipFileFromDownloadLinkToTemp(string url, string destination)
        {            
            var downloadLink = await GetLatestReleaseLink(url);

            Directory.CreateDirectory(destination);
            using (WebClient wc = new WebClient())
            {
                var destinationFile = destination.Split('\\');
                await wc.DownloadFileTaskAsync(
                    new System.Uri(downloadLink),
                    destination + "\\" + destinationFile[destinationFile.Length - 1]
                );
            }
        }

        public static async Task DownloadAndInsertZipFileFromDownloadLink(string downloadLink, string destination)
        {
            Directory.CreateDirectory(destination);
            using (WebClient wc = new WebClient())
            {
                var destinationFile = destination.Split('\\');
                await wc.DownloadFileTaskAsync(
                    new System.Uri(downloadLink),
                    destination + "\\" + destinationFile[destinationFile.Length - 1]
                );
            }
        }

        public static async Task<string> GetLatestReleaseLink(string url)
        {
            var downloadLink = "";
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var downloadLinkNode = doc.DocumentNode.SelectSingleNode("//div[@class='Box Box--condensed mt-3']");
                downloadLink = downloadLinkNode.SelectNodes("//a[@class='d-flex flex-items-center']").Select(x => x.GetAttributeValue("href", "")).First();
            }
            return "https://github.com" + downloadLink;
        }

        public static async Task<string> GetModDescription(string url)
        {
            using (var client = new HttpClient())
            {
                var html = await client.GetStringAsync(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                var downloadLinkNode = doc.DocumentNode.SelectSingleNode("//div[@class='markdown-body']");
                return downloadLinkNode.InnerText;
            }
        }

    }
}
