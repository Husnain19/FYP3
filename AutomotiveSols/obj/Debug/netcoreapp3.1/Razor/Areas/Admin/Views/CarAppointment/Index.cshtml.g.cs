#pragma checksum "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ca8ccaa79e07e0c7f421939648d59879dabf2b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_CarAppointment_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/CarAppointment/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ca8ccaa79e07e0c7f421939648d59879dabf2b3", @"/Areas/Admin/Views/CarAppointment/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df7a0fb8a80ecf2feccfc8776f99286f89926f7e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_CarAppointment_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AutomotiveSols.BLL.ViewModels.AppointmentVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ca8ccaa79e07e0c7f421939648d59879dabf2b35083", async() => {
                WriteLiteral(@"
    <br />
    <br />
    <h2 class=""text-success""> Appointments of Cars</h2>

    <br />
    <div style=""height:150px; background-color:aliceblue "" class=""container"">

        <div class=""col-12"">
            <div class=""row"" style=""padding-top:10px;"">
                <div class=""col-2"">
                    Customer Name
                </div>
                <div class=""col-3"">
                    ");
#nullable restore
#line 17 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.Editor("searchName", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-2\">\r\n\r\n                </div>\r\n                <div class=\"col-2\">\r\n                    Email\r\n                </div>\r\n                <div class=\"col-3\">\r\n                    ");
#nullable restore
#line 26 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.Editor("searchEmail", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>

            </div>
            <div class=""row"" style=""padding-top:10px;"">
                <div class=""col-2"">
                    Phone Number
                </div>
                <div class=""col-3"">
                    ");
#nullable restore
#line 35 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.Editor("searchPhone", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-2\">\r\n\r\n                </div>\r\n                <div class=\"col-2\">\r\n                    Appointment Date\r\n                </div>\r\n                <div class=\"col-3\">\r\n                    ");
#nullable restore
#line 44 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.Editor("searchDate", new { htmlAttributes = new { @class = "form-control", @id = "datepicker" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>

            </div>
            <div class=""row"" style=""padding-top:10px;"">
                <div class=""col-2"">
                </div>
                <div class=""col-3"">
                </div>
                <div class=""col-2"">

                </div>
                <div class=""col-2"">
                </div>
                <div class=""col-3"">
                    <button type=""submit"" name=""submit"" value=""Search"" class=""btn btn-primary form-control"">
                        <i class=""fas fa-search""></i> Search
                    </button>
                </div>

            </div>
        </div>

    </div>

    <br />
    <br />
    <div>
        <table class=""table table-striped border"">
            <tr class=""table-info"">
                <th>
                    ");
#nullable restore
#line 75 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Appointments.FirstOrDefault().SalesPerson.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 78 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Appointments.FirstOrDefault().AppointmentDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 82 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Appointments.FirstOrDefault().CustomerName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 86 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Appointments.FirstOrDefault().CustomerPhoneNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 90 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Appointments.FirstOrDefault().CustomerEmail));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 94 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Appointments.FirstOrDefault().isConfirmed));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n\r\n                </th>\r\n                <th>\r\n\r\n                </th>\r\n            </tr>\r\n");
#nullable restore
#line 103 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
             foreach (var item in Model.Appointments)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 107 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                   Write(Html.DisplayFor(m => item.SalesPerson.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 110 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                   Write(Html.DisplayFor(m => item.AppointmentDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 114 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 118 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerEmail));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 122 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerPhoneNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 126 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                   Write(Html.DisplayFor(m => item.isConfirmed));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ca8ccaa79e07e0c7f421939648d59879dabf2b313539", async() => {
                    WriteLiteral("Edit");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 129 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                                               WriteLiteral(item.Id);

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
                WriteLiteral(" |\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ca8ccaa79e07e0c7f421939648d59879dabf2b315824", async() => {
                    WriteLiteral("Details");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 130 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                                                  WriteLiteral(item.Id);

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
                WriteLiteral(" |\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ca8ccaa79e07e0c7f421939648d59879dabf2b318115", async() => {
                    WriteLiteral("Delete");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 131 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
                                                 WriteLiteral(item.Id);

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
                WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 135 "F:\dotnet\AutomotiveSols\AutomotiveSols\Areas\Admin\Views\CarAppointment\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AutomotiveSols.BLL.ViewModels.AppointmentVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
