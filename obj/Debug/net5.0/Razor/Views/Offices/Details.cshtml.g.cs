#pragma checksum "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2eac1727ea9d14edc66949f08e9a33583f55c46d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Offices_Details), @"mvc.1.0.view", @"/Views/Offices/Details.cshtml")]
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
#line 1 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\_ViewImports.cshtml"
using VNPT_Review;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\_ViewImports.cshtml"
using VNPT_Review.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2eac1727ea9d14edc66949f08e9a33583f55c46d", @"/Views/Offices/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c760d82600bd198577a6cb6fddbf4edf7260d8da", @"/Views/_ViewImports.cshtml")]
    public class Views_Offices_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VNPT_Review.Models.UOfficeReview>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Review", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h1>");
#nullable restore
#line 8 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
   Write(Html.DisplayFor(model => model.office.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 12 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.office.Note));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 15 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
       Write(Html.DisplayFor(model => model.office.Note));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 18 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.office.FatherId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 21 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
       Write(Html.DisplayFor(model => model.office.FatherId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 24 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.office.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 27 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
       Write(Html.DisplayFor(model => model.office.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            Rating\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 33 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
       Write(Model.office.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 34 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
              
                var max = 5;
                if(Model.office.Rating == 0)
                {
                    for(int i=0; i<max; i++)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i class=\"fas fa-star\" style=\"color:#ffffff; text-shadow: 0 0 2px #000000\"></i>\r\n");
#nullable restore
#line 41 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
                    }
                }
                else 
                {
                    int i;
                    for(i=0; i<Model.office.Rating; i++)
                    {
                        if(i >= Model.office.Rating - 1 && Model.office.Rating % 1 != 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fas fa-star-half\" style=\"color:#fffc3d; text-shadow: 0 0 2px #000000\"></i>\r\n");
#nullable restore
#line 51 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <i class=\"fas fa-star\" style=\"color:#fffc3d; text-shadow: 0 0 2px #000000\"></i>\r\n");
#nullable restore
#line 55 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
                        }
                    }
                    while(i < max) 
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <i class=\"fas fa-star\" style=\"color:#ffffff; text-shadow: 0 0 2px #000000\"></i>\r\n");
#nullable restore
#line 60 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
                        i++;
                    }
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n    </dl>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2eac1727ea9d14edc66949f08e9a33583f55c46d9650", async() => {
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
#line 66 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
                           WriteLiteral(Model.office.Id);

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
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2eac1727ea9d14edc66949f08e9a33583f55c46d11814", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<div>\r\n");
#nullable restore
#line 70 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
     if(Model.reviews.Count() > 0)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
         foreach (var item in Model.reviews)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"container\">\r\n                ");
#nullable restore
#line 75 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
           Write(Html.DisplayNameFor(model => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 76 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
           Write(Html.DisplayFor(model => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                ");
#nullable restore
#line 78 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
           Write(Html.DisplayNameFor(model => item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 79 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
           Write(Html.DisplayFor(model => item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                ");
#nullable restore
#line 81 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
           Write(Html.DisplayNameFor(model => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 82 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
           Write(Html.DisplayFor(model => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                ");
#nullable restore
#line 84 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
           Write(Html.DisplayNameFor(model => item.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 85 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
           Write(Html.DisplayFor(model => item.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2eac1727ea9d14edc66949f08e9a33583f55c46d15843", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
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
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2eac1727ea9d14edc66949f08e9a33583f55c46d18252", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 90 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
         
    }
    else 
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>Hiện tại chưa có đánh giá nào.</p>\r\n");
#nullable restore
#line 95 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VNPT_Review.Models.UOfficeReview> Html { get; private set; }
    }
}
#pragma warning restore 1591
