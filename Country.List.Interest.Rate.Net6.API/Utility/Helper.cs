using Country.List.Interest.Rate.Net6.API.Model;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Country.List.Interest.Rate.Net6.API.Utility
{
    public static class Helper
    {
        public static string getHtmlSourceAgility(string link)
        {
            HtmlWeb webSite = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = webSite.Load(link);
            return doc.DocumentNode.OuterHtml;
        }

        public static string getHtmlCode(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.Encoding = UTF8Encoding.UTF8;
                string htmlCode = "";

                try
                {
                    htmlCode = client.DownloadString(url);
                }
                catch (Exception)
                {
                }
                return System.Net.WebUtility.HtmlDecode(htmlCode);
            }
        }

        public static HtmlNodeCollection GetNodesToResult(string Url, string Nodes)
        {
            //.SelectNodes(@"div[@id='frmPnlProductGallery']/ul/li/a")
            //.SelectNodes("//div[@id='myID']")
            //.SelectNodes("//table[3]");
            //SelectNodes(".//span[@class='nobr']");
            //"//div[@class='link_row']//a[@href]");   var Link = getiframe[0].Attributes["href"].Value;

            string htmlCode = getHtmlCode(Url);

            if (String.IsNullOrEmpty(htmlCode))
            {
                htmlCode = getHtmlSourceAgility(Url);
            }

            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(htmlCode);
            HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes(Nodes);
            return basliklar;
        }

        public static List<InterestRateModel> getInterestRate()
        {
            HtmlNodeCollection interestrate = Helper.GetNodesToResult("https://tradingeconomics.com/country-list/interest-rate", ".//tr[@class='datatable-row-alternating']");
            List<InterestRateModel> rstModel = new List<InterestRateModel>();

            foreach (var item in interestrate)
            {
                string[] lstInterest = item.InnerText.Split(
        new string[] { Environment.NewLine },
        StringSplitOptions.None
    );

                InterestRateModel InterestRateModel = new InterestRateModel();
                InterestRateModel.Country = lstInterest[3].Trim();
                InterestRateModel.Last = lstInterest[5].Trim();
                InterestRateModel.Previous = lstInterest[6].Trim();
                InterestRateModel.Reference = lstInterest[7].Trim();
                InterestRateModel.Unit = lstInterest[8].Trim();
                rstModel.Add(InterestRateModel);
            }

            return rstModel;
        }
    }
}