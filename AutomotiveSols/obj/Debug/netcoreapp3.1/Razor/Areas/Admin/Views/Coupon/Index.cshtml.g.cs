#pragma checksum "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6334f14f8beed71ae22c1a63f2da450245f9ce84"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Coupon_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Coupon/Index.cshtml")]
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
#line 1 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\_ViewImports.cshtml"
using AutomotiveSols;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\_ViewImports.cshtml"
using AutomotiveSols.BLL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\_ViewImports.cshtml"
using AutomotiveSols.BLL.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6334f14f8beed71ae22c1a63f2da450245f9ce84", @"/Areas/Admin/Views/Coupon/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df7a0fb8a80ecf2feccfc8776f99286f89926f7e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Coupon_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AutomotiveSols.BLL.Models.Coupon>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CreateButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
   ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\n<br />\n<div class=\"border backgroundWhite\">\n    <div class=\"row\">\n        <div class=\"col-6\">\n            <h2 class=\"text-info\"> Coupon List</h2>\n        </div>\n        <div class=\"col-6 text-right\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6334f14f8beed71ae22c1a63f2da450245f9ce844642", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n    </div>\n    <br />\n    <div>\n");
#nullable restore
#line 18 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table table-striped border\">\n    <tr class=\"table-secondary\">\n        <th>\n            ");
#nullable restore
#line 23 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
       Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </th>\n        <th>\n            ");
#nullable restore
#line 26 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
       Write(Html.DisplayNameFor(m => m.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </th>\n        <th>\n            ");
#nullable restore
#line 29 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
       Write(Html.DisplayNameFor(m => m.MinimumAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </th>\n        <th>\n            ");
#nullable restore
#line 32 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
       Write(Html.DisplayNameFor(m => m.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </th>\n        <th></th>\n        <th></th>\n    </tr>\n");
#nullable restore
#line 37 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>\n        ");
#nullable restore
#line 41 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
   Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
#nullable restore
#line 44 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
   Write(Html.DisplayFor(m => item.Discount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
#nullable restore
#line 47 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
   Write(Html.DisplayFor(m => item.MinimumAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
#nullable restore
#line 50 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
   Write(Html.DisplayFor(m => item.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6334f14f8beed71ae22c1a63f2da450245f9ce848645", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 53 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </td>\n</tr>");
#nullable restore
#line 55 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table> ");
#nullable restore
#line 56 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
         }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>No coupons exists...</p>            ");
#nullable restore
#line 59 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\Coupon\Index.cshtml"
                                       }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AutomotiveSols.BLL.Models.Coupon>> Html { get; private set; }
    }
}
#pragma warning restore 1591
