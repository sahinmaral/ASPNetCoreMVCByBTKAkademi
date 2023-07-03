using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Entities;
using StoreApp.Services.Abstract;

namespace StoreApp.Web.Infrastructure.TagHelpers;

[HtmlTargetElement("div", Attributes = "latest-products")]
public class LatestProductTagHelper : TagHelper
{
    private readonly IServiceManager _serviceManager;
    [HtmlAttributeName("number")]
    public int Number { get; set; }

    public LatestProductTagHelper(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        TagBuilder div = new TagBuilder("div");
        div.Attributes.Add("class", "my-3");

        TagBuilder h6 = new TagBuilder("h6");
        h6.Attributes.Add("class", "lead");

        TagBuilder h6_icon = new TagBuilder("i");
        h6_icon.Attributes.Add("class", "fa fa-box text-secondary");

        h6.InnerHtml.AppendHtml(h6_icon);
        h6.InnerHtml.AppendHtml("&nbsp;Latest Products");

        TagBuilder ul = new TagBuilder("ul");
        foreach (Product product in _serviceManager.ProductService.GetAllProductsDetailed().OrderByDescending(p => p.Id).Take(Number))
        {
            TagBuilder li = new TagBuilder("li");

            TagBuilder li_link = new TagBuilder("a");
            li_link.Attributes.Add("href", $"/product/get/{product.Id}");
            li_link.InnerHtml.AppendHtml(product.Name);

            li.InnerHtml.AppendHtml(li_link);
            ul.InnerHtml.AppendHtml(li);
        }


        div.InnerHtml.AppendHtml(h6);
        div.InnerHtml.AppendHtml(ul);

        output.Content.AppendHtml(div);
    }
}