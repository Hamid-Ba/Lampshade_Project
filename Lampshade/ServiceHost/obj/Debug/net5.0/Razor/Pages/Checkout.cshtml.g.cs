#pragma checksum "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49ae3fb29a5cb95a8bfb44df4c5d5147d5a70f0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_Checkout), @"mvc.1.0.razor-page", @"/Pages/Checkout.cshtml")]
namespace ServiceHost.Pages
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
#nullable restore
#line 3 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
using _0_Framework.Application;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49ae3fb29a5cb95a8bfb44df4c5d5147d5a70f0f", @"/Pages/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Checkout : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Product"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
  
    ViewData["Title"] = "تسویه حساب";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <div class=""breadcrumb-content"">
                        <h2 class=""breadcrumb-content__title"">تسویه حساب</h2>
                        <ul class=""breadcrumb-content__page-map"">
                            <li>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49ae3fb29a5cb95a8bfb44df4c5d5147d5a70f0f6013", async() => {
                WriteLiteral("صفحه اصلی");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </li>
                            <li class=""active"">تسویه حساب</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49ae3fb29a5cb95a8bfb44df4c5d5147d5a70f0f7672", async() => {
                WriteLiteral(@"
                            <div class=""cart-table table-responsive"">
                                <table class=""table"">
                                    <thead>
                                        <tr>
                                            <th class=""pro-thumbnail"">عکس</th>
                                            <th class=""pro-thumbnail"">محصول</th>
                                            <th class=""pro-title"">قیمت واحد</th>
                                            <th class=""pro-price"">تعداد</th>
                                            <th class=""pro-price"">درصد تخفیف</th>
                                            <th class=""pro-quantity"">مبلغ کل بدون تخفیف</th>
                                            <th class=""pro-subtotal"">مبلغ کل تخفیف</th>
                                            <th class=""pro-remove"">مبلغ پس از تخفیف</th>
                                        </tr>
                                    </thead>
                                  ");
                WriteLiteral("  <tbody>\r\n");
#nullable restore
#line 50 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                         foreach (var item in Model.Cart.CartItems)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <tr>\r\n                                                <td class=\"pro-thumbnail\">\r\n                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49ae3fb29a5cb95a8bfb44df4c5d5147d5a70f0f9568", async() => {
                    WriteLiteral("\r\n                                                        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "49ae3fb29a5cb95a8bfb44df4c5d5147d5a70f0f9887", async() => {
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                    BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    AddHtmlAttributeValue("", 2607, "~/Pictures/", 2607, 11, true);
#nullable restore
#line 55 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
AddHtmlAttributeValue("", 2618, item.Picture, 2618, 13, false);

#line default
#line hidden
#nullable disable
                    EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n                                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 54 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                                            WriteLiteral(item.Slug);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                </td>\r\n                                                <td class=\"pro-title\">\r\n                                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49ae3fb29a5cb95a8bfb44df4c5d5147d5a70f0f14018", async() => {
                    WriteLiteral("\r\n                                                        ");
#nullable restore
#line 61 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                                            WriteLiteral(item.Slug);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                </td>\r\n                                                <td class=\"pro-price\">\r\n                                                    <span>");
#nullable restore
#line 65 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                     Write(item.UnitPrice.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                                </td>\r\n                                                <td class=\"pro-price\">\r\n                                                    <span>");
#nullable restore
#line 68 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                     Write(item.Count);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                                </td>\r\n                                                <td class=\"pro-subtotal\">\r\n                                                    <span>");
#nullable restore
#line 71 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                     Write(item.DisocuntRate);

#line default
#line hidden
#nullable disable
                WriteLiteral("%</span>\r\n                                                </td>\r\n                                                <td class=\"pro-subtotal\">\r\n                                                    <span>");
#nullable restore
#line 74 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                     Write(item.TotalPrice.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                                </td>\r\n                                                <td class=\"pro-subtotal\">\r\n                                                    <span>");
#nullable restore
#line 77 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                     Write(item.DiscountPrice.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                                </td>\r\n                                                <td class=\"pro-subtotal\">\r\n                                                    <span>");
#nullable restore
#line 80 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                     Write(item.PayAmount.ToMoney());

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                                </td>\r\n                                            </tr>\r\n");
#nullable restore
#line 83 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </tbody>\r\n                                </table>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                        <div class=""row"">
                            <div class=""col-lg-6 col-12 d-flex"">
                                <div class=""cart-summary"">
                                    <div class=""cart-summary-wrap"">
                                        <h4>خلاصه وضعیت فاکتور</h4>
                                        <p>مبلغ نهایی <span>");
#nullable restore
#line 95 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                       Write(Model.Cart.TotalPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span></p>\r\n                                        <p>مبلغ تخفیف <span>");
#nullable restore
#line 96 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                       Write(Model.Cart.DiscountPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span></p>\r\n                                        <h2>مبلغ قابل پرداخت <span>");
#nullable restore
#line 97 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Checkout.cshtml"
                                                              Write(Model.Cart.PayAmount.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" تومان</span></h2>
                                    </div>
                                    <div class=""cart-summary-button"">
                                        <button class=""checkout-btn"">پرداخت</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.CheckoutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.CheckoutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.CheckoutModel>)PageContext?.ViewData;
        public ServiceHost.Pages.CheckoutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591