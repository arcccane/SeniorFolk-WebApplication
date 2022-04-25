using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;

namespace Seniorfolk.Pages
{
    public class NewsModel : PageModel
    {
        [BindProperty]
        public List<Article> articleList { get; set; }

        public async Task<IActionResult> OnGet(string q)
        {
            var newsApiClient = new NewsApiClient("c286e565bb624155afd0e38d3d970072");
            var articlesResponse = await newsApiClient.GetTopHeadlinesAsync(new TopHeadlinesRequest
            {
                Q = q
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                articleList = articlesResponse.Articles;
                return Page();
            }
            return Page();
        }
    }
}
