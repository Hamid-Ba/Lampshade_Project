#pragma checksum "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Customer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "734f9215fd4e0bd3f7a73ffa8e6e481dd45e7284"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shop.Order.Areas_Administration_Pages_Shop_Order_Customer), @"mvc.1.0.view", @"/Areas/Administration/Pages/Shop/Order/Customer.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"734f9215fd4e0bd3f7a73ffa8e6e481dd45e7284", @"/Areas/Administration/Pages/Shop/Order/Customer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acc3a25a70463439832f0ed26af6566326979550", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Shop_Order_Customer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopManagement.Application.Contracts.OrderAgg.DetailCustomerOrderVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Customer.cshtml"
  
    ViewData["Title"] = "??????????";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">??</button>
    <h4 class=""modal-title"">???????????? ??????????</h4>
</div>

<div class=""modal-body"">
    <table class=""table table-bordered"">
        <thead>
            <tr>
                <th>#</th>
                <th>??????</th>
                <th>????????</th>
                <th>?????????? ????????????</th>
        </thead>
        <tbody>
            
                <tr class=""text-center"">
                    <td>");
#nullable restore
#line 24 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Customer.cshtml"
                   Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Customer.cshtml"
                   Write(Model.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Customer.cshtml"
                   Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Areas\Administration\Pages\Shop\Order\Customer.cshtml"
                   Write(Model.MobilePhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n            \r\n        </tbody>\r\n    </table>\r\n</div>\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">????????</button>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopManagement.Application.Contracts.OrderAgg.DetailCustomerOrderVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
