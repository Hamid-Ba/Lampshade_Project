#pragma checksum "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7e9458ab1ec84e26501fca2b284d634bf9ce05f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shop.Order.Areas_Administration_Pages_Shop_Order_Items), @"mvc.1.0.view", @"/Areas/Administration/Pages/Shop/Order/Items.cshtml")]
namespace ServiceHost.Pages.Shop.Order
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
#line 1 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\_ViewImports.cshtml"
using ServiceHost.Tools;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\_ViewImports.cshtml"
using ShopManagement.Infrastructure.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
using _0_Framework.Application;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7e9458ab1ec84e26501fca2b284d634bf9ce05f", @"/Areas/Administration/Pages/Shop/Order/Items.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc3a25a70463439832f0ed26af6566326979550", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Shop_Order_Items : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShopManagement.Application.Contracts.OrderAgg.AdminOrderItemVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
  
    ViewData["Title"] = "???????? ????";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">??</button>
    <h4 class=""modal-title"">???????? ??????????????</h4>
</div>

<div class=""modal-body"">
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th>#</th>
                <th>??????????</th>
                <th>??????????</th>
                <th>???????? ????????</th>
                <th>???????? ??????????</th>
        </thead>
        <tbody>
");
#nullable restore
#line 23 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"text-center\">\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.ProductId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 29 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.UnitPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
                   Write(item.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</td>\r\n                </tr>\r\n");
#nullable restore
#line 32 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Items.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">????????</button>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShopManagement.Application.Contracts.OrderAgg.AdminOrderItemVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
