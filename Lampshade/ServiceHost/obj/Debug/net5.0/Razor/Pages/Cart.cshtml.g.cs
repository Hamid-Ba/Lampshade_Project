#pragma checksum "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac09884097752888a086b8007ff68fdef6fa08fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_Cart), @"mvc.1.0.razor-page", @"/Pages/Cart.cshtml")]
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
#line 3 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
using _0_Framework.Application;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac09884097752888a086b8007ff68fdef6fa08fe", @"/Pages/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Cart : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "RemoveCartItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("checkout-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 4 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
  
    ViewData["Title"] = "سبد خرید";

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
                        <h2 class=""breadcrumb-content__title"">سبد خرید</h2>
                        <ul class=""breadcrumb-content__page-map"">
                            <li>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac09884097752888a086b8007ff68fdef6fa08fe5481", async() => {
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
                            <li class=""active"">سبد خرید</li>
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
                <!--=======  page wrapper  =======-->
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">

");
#nullable restore
#line 36 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                         foreach (var item in Model.CartItems.Where(c => !c.IsInStock))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"alert alert-warning\">\r\n                                <i class=\"fa fa-warning\"></i> <span>محصول ");
#nullable restore
#line 39 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                                                     Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" به تعداد ");
#nullable restore
#line 39 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                                                                         Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" در انبار موجود نمی باشد!</span>\r\n                            </div>\r\n");
#nullable restore
#line 41 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        <div class=""cart-table table-responsive"">
                            <table class=""table"">
                                <thead>
                                    <tr>
                                        <th class=""pro-thumbnail"">تصویر</th>
                                        <th class=""pro-title"">محصول</th>
                                        <th class=""pro-price"">قیمت واحد</th>
                                        <th class=""pro-quantity"">تعداد</th>
                                        <th class=""pro-subtotal"">قیمت کل</th>
                                        <th class=""pro-remove"">عملیات</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 57 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                     foreach (var product in Model.CartItems)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td class=\"pro-thumbnail\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac09884097752888a086b8007ff68fdef6fa08fe9983", async() => {
                WriteLiteral("\r\n                                                    <img");
                BeginWriteAttribute("src", " src=\"", 2722, "\"", 2754, 2);
                WriteAttributeValue("", 2728, "/Pictures/", 2728, 10, true);
#nullable restore
#line 62 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 2738, product.Picture, 2738, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid\"");
                BeginWriteAttribute("alt", " alt=\"", 2773, "\"", 2792, 1);
#nullable restore
#line 62 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 2779, product.Name, 2779, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                                                        WriteLiteral(product.Slug);

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
            WriteLiteral("\r\n                                            </td>\r\n                                            <td class=\"pro-title\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac09884097752888a086b8007ff68fdef6fa08fe13408", async() => {
#nullable restore
#line 66 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                                                                              Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 66 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                                                        WriteLiteral(product.Slug);

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
            WriteLiteral("\r\n                                            </td>\r\n                                            <td class=\"pro-price\">\r\n                                                <span>");
#nullable restore
#line 69 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                                 Write(product.UnitPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                            </td>
                                            <td class=""pro-quantity"">
                                                <div class=""quantity-selection"">
                                                    <input type=""number""");
            BeginWriteAttribute("value", " value=\"", 3573, "\"", 3595, 1);
#nullable restore
#line 73 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 3581, product.Count, 3581, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" min=\"1\"");
            BeginWriteAttribute("onchange", " onchange=\"", 3604, "\"", 3691, 7);
            WriteAttributeValue("", 3615, "changeCartItemCount(\'", 3615, 21, true);
#nullable restore
#line 73 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 3636, product.Id, 3636, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3647, "\',", 3647, 2, true);
            WriteAttributeValue(" ", 3649, "\'totalItemPrice-", 3650, 17, true);
#nullable restore
#line 73 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 3666, product.Id, 3666, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3677, "\',", 3677, 2, true);
            WriteAttributeValue(" ", 3679, "this.value)", 3680, 12, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                </div>\r\n                                            </td>\r\n                                            <td class=\"pro-subtotal\">\r\n                                                <span");
            BeginWriteAttribute("id", " id=\"", 3926, "\"", 3957, 2);
            WriteAttributeValue("", 3931, "totalItemPrice-", 3931, 15, true);
#nullable restore
#line 77 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 3946, product.Id, 3946, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 77 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                                                                 Write(product.TotalPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </td>\r\n                                            <td class=\"pro-remove\">\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac09884097752888a086b8007ff68fdef6fa08fe19398", async() => {
                WriteLiteral("\r\n                                                    <i class=\"fa fa-trash-o\"></i>\r\n                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 80 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                                                                       WriteLiteral(product.Id);

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
            WriteLiteral("\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 85 "C:\Users\Danesh\Documents\Visual Studio 2019\Projects\Asp Core Pro\Lampshade\Lampshade\ServiceHost\Pages\Cart.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </tbody>
                            </table>
                        </div>

                        <div class=""row"">
                            <div class=""col-lg-6 col-12 d-flex"">
                                <div class=""cart-summary"">
                                    <div class=""cart-summary-button"">
                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ac09884097752888a086b8007ff68fdef6fa08fe22551", async() => {
                WriteLiteral("تسویه حساب");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.CartModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.CartModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.CartModel>)PageContext?.ViewData;
        public ServiceHost.Pages.CartModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591