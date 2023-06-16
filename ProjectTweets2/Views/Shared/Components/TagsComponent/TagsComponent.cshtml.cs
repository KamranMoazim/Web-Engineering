using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProjectTweets2.Views.Shared.Components.TagsComponent
{
    public class TagsComponent : PageModel
    {
        private readonly ILogger<TagsComponent> _logger;

        public TagsComponent(ILogger<TagsComponent> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}