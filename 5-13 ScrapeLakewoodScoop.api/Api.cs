using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace _5_13_ScrapeLakewoodScoop.api
{
    public static class Api
    {
        private static string GetLSHtml()
        {
            var handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("user-agent", "whatever");
                var html = client.GetStringAsync("https://www.thelakewoodscoop.com/").Result;
                return html;
            }
        }

        public static IEnumerable<Article> GetArticles()
        {
            string html = GetLSHtml();
            var parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(html);
            var articleDivs = document.QuerySelectorAll(".post");
            List<Article> articles = new List<Article>();
            foreach (var div in articleDivs)
            {
                Article article = new Article();

                var title = div.QuerySelector("a");
                article.Title = title.Attributes["title"].Value.Substring(18);
                article.Url = title.Attributes["href"].Value;

                var img = div.QuerySelector("img");
                article.ImgUrl = img.Attributes["src"].Value;

                article.Date = div.QuerySelector("small").TextContent;

                articles.Add(article);
            }
            return articles;
        }
    }
}
