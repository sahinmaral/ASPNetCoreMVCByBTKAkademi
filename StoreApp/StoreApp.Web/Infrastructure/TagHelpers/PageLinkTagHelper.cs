using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Web.Models;

namespace StoreApp.Web.Infrastructure.TagHelpers;

[HtmlTargetElement("div",Attributes = "page-model")]
public class PageLinkTagHelper : TagHelper
{
    [ViewContext]
    [HtmlAttributeNotBound]
    public ViewContext? ViewContext {get;set;}
    public Pagination PageModel { get; set; }
    public string? PageAction { get; set; }
    private readonly IUrlHelperFactory _urlHelperFactory;
    public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
    {
        _urlHelperFactory = urlHelperFactory;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if(ViewContext is not null & PageModel is not null)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder row = new TagBuilder("div");
            row.AddCssClass("row");

            TagBuilder rowContainer = new TagBuilder("div");
            rowContainer.AddCssClass("d-flex justify-content-center my-2");

            TagBuilder nav = new TagBuilder("nav");

            TagBuilder nav_ul = new TagBuilder("ul");
            nav_ul.AddCssClass("pagination");

            if(PageModel.TotalPages >= 2)
            {
                if(PageModel.CurrentPage != 1)
                {
                    TagBuilder previousButton = new TagBuilder("li");
                    previousButton.AddCssClass("page-item");

                    TagBuilder previousButton_link = new TagBuilder("a");
                    previousButton_link.AddCssClass("page-link");

                    previousButton_link.Attributes.Add("href",urlHelper.Action(PageAction,new {PageNumber = PageModel.CurrentPage-1}));

                    previousButton_link.InnerHtml.Append("Previous");

                    previousButton.InnerHtml.AppendHtml(previousButton_link);
                    nav_ul.InnerHtml.AppendHtml(previousButton);
                }
            }

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {


                TagBuilder nav_ul_li = new TagBuilder("li");
                nav_ul_li.AddCssClass("page-item");

                TagBuilder nav_ul_li_link = new TagBuilder("a");
                if(i == PageModel.CurrentPage)
                {
                    nav_ul_li_link.AddCssClass("page-link active");
                }
                else
                {
                    nav_ul_li_link.AddCssClass("page-link");
                }
                nav_ul_li_link.Attributes.Add("href",urlHelper.Action(PageAction,new {PageNumber = i}));
                nav_ul_li_link.InnerHtml.Append(i.ToString());

                nav_ul_li.InnerHtml.AppendHtml(nav_ul_li_link);
                nav_ul.InnerHtml.AppendHtml(nav_ul_li);
            }

            if(PageModel.TotalPages >= 2)
            {
                if(PageModel.CurrentPage != PageModel.TotalPages)
                {
                    TagBuilder nextButton = new TagBuilder("li");
                    nextButton.AddCssClass("page-item");

                    TagBuilder nextButton_link = new TagBuilder("a");
                    nextButton_link.AddCssClass("page-link");

                    nextButton_link.Attributes.Add("href",urlHelper.Action(PageAction,new {PageNumber = PageModel.CurrentPage+1}));
                    nextButton_link.InnerHtml.Append("Next");

                    nextButton.InnerHtml.AppendHtml(nextButton_link);
                    nav_ul.InnerHtml.AppendHtml(nextButton);
                }
            }

            nav.InnerHtml.AppendHtml(nav_ul);
            rowContainer.InnerHtml.AppendHtml(nav);
            row.InnerHtml.AppendHtml(rowContainer);

            output.Content.AppendHtml(row.InnerHtml);
        }
    }
}