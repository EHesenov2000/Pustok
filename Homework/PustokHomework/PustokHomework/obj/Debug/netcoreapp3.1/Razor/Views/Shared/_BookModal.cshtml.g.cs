#pragma checksum "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a85c138d9b2c1499d6657e7f0f63c10ae9ad71b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BookModal), @"mvc.1.0.view", @"/Views/Shared/_BookModal.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
using PustokHomework.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a85c138d9b2c1499d6657e7f0f63c10ae9ad71b5", @"/Views/Shared/_BookModal.cshtml")]
    public class Views_Shared__BookModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Book>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("book-poster"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal-content"">
    <button type=""button"" class=""close modal-close-btn ml-auto"" data-dismiss=""modal"" aria-label=""Close"">
        <span aria-hidden=""true"">&times;</span>
    </button>
    <div class=""product-details-modal"">
        <div class=""row"">
            <div class=""col-lg-5"">
                <!-- Product Details Slider Big Image-->
                <div class=""product-details-slider sb-slick-slider arrow-type-two"">
                    <div class=""single-slide"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a85c138d9b2c1499d6657e7f0f63c10ae9ad71b54133", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 593, "~/image/products/", 593, 17, true);
#nullable restore
#line 14 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
AddHtmlAttributeValue("", 610, Model.BookImages.FirstOrDefault(x=>x.IsPoster == true).Image, 610, 61, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
            <div class=""col-lg-7 mt--30 mt-lg--30"">
                <div class=""product-details-info pl-lg--30 "">
                    <p class=""tag-block"">Tags: <a href=""#"">Movado</a>, <a href=""#"">Omega</a></p>
                    <h3 class=""product-title"">");
#nullable restore
#line 21 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                                         Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <ul class=\"list-unstyled\">\r\n                        <li>Genre: <a href=\"#\" class=\"list-value font-weight-bold book-genre\"> ");
#nullable restore
#line 23 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                                                                                          Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n                        <li>Product Code: <span class=\"list-value book-code\"> ");
#nullable restore
#line 24 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                                                                         Write(Model.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                        <li>Author name: <span class=\"list-value book-code\"> ");
#nullable restore
#line 25 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                                                                        Write(Model.Author.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                        <li>Availability: <span class=\"list-value book-stock-status\"> ");
#nullable restore
#line 26 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                                                                                  Write(Model.IsAvailable?"In Stock":"Out Stock");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></li>\r\n                    </ul>\r\n                    <div class=\"price-block book-price\">\r\n");
#nullable restore
#line 29 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                         if (Model.DiscountPercent > 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"price-new\">??");
#nullable restore
#line 31 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                                                Write(Model.DicountedPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <del class=\"price-old\">??");
#nullable restore
#line 32 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                                               Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</del>\r\n");
#nullable restore
#line 33 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"price-new\">??");
#nullable restore
#line 36 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                                                Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 37 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BookModal.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                    <div class=""rating-widget"">
                        <div class=""rating-block"">
                            <span class=""fas fa-star star_on""></span>
                            <span class=""fas fa-star star_on""></span>
                            <span class=""fas fa-star star_on""></span>
                            <span class=""fas fa-star star_on""></span>
                            <span class=""fas fa-star ""></span>
                        </div>
                        <div class=""review-widget"">
                            <a href=""#"">(1 Reviews)</a> <span>|</span>
                            <a href=""#"">Write a review</a>
                        </div>
                    </div>
                    <article class=""product-details-article"">
                        <h4 class=""sr-only"">Product Summery</h4>
                        <p class=""book-subtitle"">
                            Long printed dress with thin adjustable straps. V-neckline a");
            WriteLiteral(@"nd wiring under
                            the Dust with ruffles
                            at the bottom
                            of the
                            dress.
                        </p>
                    </article>
                    <div class=""add-to-cart-row"">
                        <div class=""count-input-block"">
                            <span class=""widget-label"">Qty</span>
                            <input type=""number"" class=""form-control text-center"" value=""1"">
                        </div>
                        <div class=""add-cart-btn"">
                            <a href=""#"" class=""btn btn-outlined--primary"">
                                <span class=""plus-icon"">+</span>Add to Cart
                            </a>
                        </div>
                    </div>
                    <div class=""compare-wishlist-row"">
                        <a href=""#"" class=""add-link""><i class=""fas fa-heart""></i>Add to Wish List</a>
                    ");
            WriteLiteral(@"    <a href=""#"" class=""add-link""><i class=""fas fa-random""></i>Add to Compare</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""modal-footer"">
        <div class=""widget-social-share"">
            <span class=""widget-label"">Share:</span>
            <div class=""modal-social-share"">
                <a href=""#"" class=""single-icon""><i class=""fab fa-facebook-f""></i></a>
                <a href=""#"" class=""single-icon""><i class=""fab fa-twitter""></i></a>
                <a href=""#"" class=""single-icon""><i class=""fab fa-youtube""></i></a>
                <a href=""#"" class=""single-icon""><i class=""fab fa-google-plus-g""></i></a>
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
