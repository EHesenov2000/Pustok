#pragma checksum "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f793dd17583dc7d999fcca96e97ad98ebc32051"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BasketItems), @"mvc.1.0.view", @"/Views/Shared/_BasketItems.cshtml")]
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
#line 1 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml"
using PustokHomework.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f793dd17583dc7d999fcca96e97ad98ebc32051", @"/Views/Shared/_BasketItems.cshtml")]
    public class Views_Shared__BasketItems : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<BasketItemViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\" single-cart-block \">\r\n        <div class=\"cart-product\">\r\n            <a href=\"product-details.html\" class=\"image\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8f793dd17583dc7d999fcca96e97ad98ebc320513735", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 386, "~/uploads/", 386, 10, true);
#nullable restore
#line 12 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml"
AddHtmlAttributeValue("", 396, item.Poster, 396, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </a>\r\n            <div class=\"content\">\r\n                <h3 class=\"title\">\r\n                    <a href=\"product-details.html\">\r\n                        ");
#nullable restore
#line 17 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("  <br /> ");
#nullable restore
#line 17 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml"
                                      Write(item.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </h3>\r\n                <p class=\"price\"><span class=\"qty\">");
#nullable restore
#line 20 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml"
                                              Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ×</span> £");
#nullable restore
#line 20 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml"
                                                                    Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <button class=\"cross-btn\"><i class=\"fas fa-times\"></i></button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 25 "C:\Users\elman\Desktop\BACKEND  DERSDE\p219_be_end_03-06-2021-EHesenov2000\Homework\PustokHomework\PustokHomework\Views\Shared\_BasketItems.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<BasketItemViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
