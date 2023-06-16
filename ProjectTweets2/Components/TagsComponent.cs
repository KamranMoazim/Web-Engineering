using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTweets2.Models.DB;

namespace ProjectTweets2.Components
{
    public class TagsComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Tags tags)
        {
            // Console.WriteLine("TagsComponent");

            // Console.WriteLine(tags.Tag1);
            // Console.WriteLine(tags.Tag2);
            // Console.WriteLine(tags.Tag3);

            return await Task.FromResult((IViewComponentResult)View("TagsComponent", tags));
        }
    }
}