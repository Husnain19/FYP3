#pragma checksum "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53f4ddefe14ea4b2e02d418351b4951eba5e307a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AutoPart_GetPart), @"mvc.1.0.view", @"/Areas/Admin/Views/AutoPart/GetPart.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53f4ddefe14ea4b2e02d418351b4951eba5e307a", @"/Areas/Admin/Views/AutoPart/GetPart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df7a0fb8a80ecf2feccfc8776f99286f89926f7e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AutoPart_GetPart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AutomotiveSols.BLL.ViewModels.AutoPartViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block w-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
  
    ViewData["Title"] = "Part Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"

<div class=""container"">
    <h3 class=""display-4"">Spare Part Details</h3>
    <div class=""row"">
        <div class=""col-md-6"">
            <div id=""carouselExampleIndicators"" class=""carousel slide"" data-ride=""carousel"">
                <ol class=""carousel-indicators"">

");
#nullable restore
#line 17 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                     for (int i = 0; i < Model.Gallery.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li data-target=\"#carouselExampleIndicators\" data-slide-to=\"");
#nullable restore
#line 19 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                                                                               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"");
            BeginWriteAttribute("class", " class=\"", 570, "\"", 602, 2);
#nullable restore
#line 19 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
WriteAttributeValue("", 578, i==0 ? "active" : "", 578, 23, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 601, "", 602, 1, true);
            EndWriteAttribute();
            WriteLiteral("></li>\r\n");
#nullable restore
#line 20 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ol>\r\n                <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 23 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                     for (int i = 0; i < Model.Gallery.Count(); i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div");
            BeginWriteAttribute("class", " class=\"", 824, "\"", 883, 2);
#nullable restore
#line 25 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
WriteAttributeValue("", 832, i==0 ? "carousel-item active" : "carousel-item", 832, 50, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 882, "", 883, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "53f4ddefe14ea4b2e02d418351b4951eba5e307a6747", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 947, "~/parts/gallery/", 947, 16, true);
#nullable restore
#line 26 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
AddHtmlAttributeValue("", 963, Model.Gallery[i].Name, 963, 22, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 26 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
AddHtmlAttributeValue("", 992, Model.Gallery[i].Name, 992, 22, false);

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
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 28 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
                <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Previous</span>
                </a>
                <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                    <span class=""sr-only"">Next</span>
                </a>
            </div>
        </div>
        <div class=""col-md-6"">
            <div class=""row"">
                <div class=""col-md-12"">
                    <h1>");
#nullable restore
#line 52 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                   Write(Model.autoPart.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n            </div>\r\n\r\n\r\n            <div class=\"row\">\r\n                <div class=\"col-md-12\">\r\n                    <p class=\"description\">\r\n                        ");
#nullable restore
#line 60 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                   Write(Model.autoPart.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </p>
                </div>
            </div>

            <div class=""row"">
                <div class=""col-md-4"">
                    <a class=""btn btn-outline-primary"" data-toggle=""modal"" data-target=""#exampleModal"">
                        Read now
                    </a>
                </div>
            </div>

            <hr />

            <ul class=""list-group"">
                <li class=""list-group-item""><span class=""font-weight-bold"">Category - </span> ");
#nullable restore
#line 76 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                                                                                         Write(Model.autoPart.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\"><span class=\"font-weight-bold\">Total pages - </span> ");
#nullable restore
#line 77 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                                                                                            Write(Model.autoPart.SubCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
            </ul>
        </div>
    </div>

    <div class=""modal fade"" id=""exampleModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>

                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                </div>
            </div>
        </div>
    </div>

    <hr />

    <div class=""py-5 bg-light"" id=""similarBooks"">
        <h3 class=""h3"">Similar books</h3>
        <div class=""row"">
");
#nullable restore
#line 103 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
             for (int i = 0; i < 5; i++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""col-md-4"">
                    <div class=""card mb-4 shadow-sm"">
                        <svg class=""bd-placeholder-img card-img-top"" width=""100%"" height=""225"" xmlns=""http://www.w3.org/2000/svg"" preserveAspectRatio=""xMidYMid slice"" focusable=""false"" role=""img"" aria-label=""Placeholder: Thumbnail""><title>Placeholder</title><rect width=""100%"" height=""100%"" fill=""#55595c""></rect><text x=""50%"" y=""50%"" fill=""#eceeef"" dy="".3em"">Thumbnail</text></svg>
                        <div class=""card-body"">
                            <h3 class=""card-title"">");
#nullable restore
#line 109 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                                              Write(Model.autoPart.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                            <p class=\"card-text\">");
#nullable restore
#line 110 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                                            Write(Model.autoPart.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            <div class=""d-flex justify-content-between align-items-center"">
                                <div class=""btn-group"">
                                    <a href=""#"" class=""btn btn-sm btn-outline-secondary"">View details</a>
                                </div>
                                <small class=""text-muted"">");
#nullable restore
#line 115 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                                                     Write(Model.autoPart.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n\r\n                                <small class=\"text-muted\">");
#nullable restore
#line 117 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
                                                     Write(Model.autoPart.SubCategory);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 122 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\AutoPart\GetPart.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AutomotiveSols.BLL.ViewModels.AutoPartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
