#pragma checksum "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Shared\Components\ArticleCategorySideBar\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3f59753b640eafff9aa010272fe2a5f45d56251e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.ArticleCategorySideBar.Pages_Shared_Components_ArticleCategorySideBar_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/ArticleCategorySideBar/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.ArticleCategorySideBar
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f59753b640eafff9aa010272fe2a5f45d56251e", @"/Pages/Shared/Components/ArticleCategorySideBar/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_ArticleCategorySideBar_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LampshadeQuery.Contract.ArticleCategory.ArticleCategoryQueryVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "ArticleCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"single-sidebar-widget\">\r\n\r\n    <h4 class=\"single-sidebar-widget__title\">گروه مقالات</h4>\r\n    <ul class=\"single-sidebar-widget__category-list\">\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Shared\Components\ArticleCategorySideBar\Default.cshtml"
         foreach (var category in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3f59753b640eafff9aa010272fe2a5f45d56251e4164", async() => {
                WriteLiteral("\r\n                    ");
#nullable restore
#line 12 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Shared\Components\ArticleCategorySideBar\Default.cshtml"
               Write(category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <span class=\"counter\">");
#nullable restore
#line 12 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Shared\Components\ArticleCategorySideBar\Default.cshtml"
                                                    Write(category.ArticlesCount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Shared\Components\ArticleCategorySideBar\Default.cshtml"
                                                WriteLiteral(category.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 11 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Shared\Components\ArticleCategorySideBar\Default.cshtml"
AddHtmlAttributeValue("", 399, (category.Slug == ViewBag.Slug)? "active" : "", 399, 49, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </li>\r\n");
#nullable restore
#line 15 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Shared\Components\ArticleCategorySideBar\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </ul>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LampshadeQuery.Contract.ArticleCategory.ArticleCategoryQueryVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
