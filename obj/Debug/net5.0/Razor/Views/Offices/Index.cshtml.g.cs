#pragma checksum "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccf6444cdcc24faaba6a5206c782530d2b4c0d25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Offices_Index), @"mvc.1.0.view", @"/Views/Offices/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccf6444cdcc24faaba6a5206c782530d2b4c0d25", @"/Views/Offices/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c760d82600bd198577a6cb6fddbf4edf7260d8da", @"/Views/_ViewImports.cshtml")]
    public class Views_Offices_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VNPT_Review.Models.UOfficeReview>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1>Danh sách phòng ban VNPT</h1>\r\n</div>\r\n\r\n<input type=\"button\" class=\"btn btn-primary float-end\" value=\"Hiển thị theo danh sách\" id=\"toggleButton\" onclick=\"this.blur()\">\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccf6444cdcc24faaba6a5206c782530d2b4c0d254283", async() => {
                WriteLiteral("Thêm");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table id=\"offices\" class=\"hover\" style=\"width:100%\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 20 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.office.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.office.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.office.Note));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.office.FatherId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\gnoul\Synced Folder\Google Drive\Web\_webapp\VNPT_Review\Views\Offices\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.office.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n");
            WriteLiteral("</table>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function() {
            var table = $('#offices').DataTable({
                processing: true,
                serverSide: true,
                searching: true,
                ordering: true,
                paging: true,
                ""ajax"": {
                    ""url"": ""api/APIOffice"",
                    ""type"": ""POST"",
                    ""datatype"": ""json""
                },
                columns: [
                    { ""data"": ""id"", ""name"": ""Mã phòng ban"", ""autoWidth"": true },
                    { ""data"": ""name"", ""name"": ""Tên phòng ban"", ""autoWidth"": true },
                    { ""data"": ""note"", ""name"": ""Ghi chú"", ""autoWidth"": true },
                    { ""data"": ""fatherId"", ""name"": ""Đơn vị cha"", ""autoWidth"": true },
                    { ""data"": ""active"", ""name"": ""Hoạt động"", ""autoWidth"": true },
                    { ""render"": function(data, type, row) {
                            return ""<div class='d-gri");
                WriteLiteral(@"d gap-2'><a href='Offices/Edit/"" + row.id + ""' class='btn btn-info'>Sửa</a></div>"";
                        }
                    },
                    { ""render"": function(data, type, row) {
                            return ""<div class='d-grid gap-2'><a href='Offices/Delete/"" + row.id + ""' class='btn btn-danger'>Xoá</a></div>"";
                        } 
                    }
                ],
                columnDefs: [
                    { ""targets"": [2,4,5], ""orderable"": false },
                    { ""targets"": [4], ""className"": ""text-center"", ""render"": function(data, type, row) {
                            return (row.active == 1) 
                                ? 
                                    ""<i class='fas fa-circle' style='color:#83eb34'></i>"" 
                                : 
                                    ""<i class='fas fa-circle' style='color:#f03f24'></i>"";
                        }  
                    }
                ],
                language: {
 ");
                WriteLiteral(@"                   ""emptyTable"": ""Không tìm thấy dữ liệu nào :("",
                    ""lengthMenu"": ""Hiện _MENU_ kết quả mỗi trang"",
                    ""info"": ""Đang hiển thị trang <b>_PAGE_</b> trong tổng số <b>_PAGES_</b> trang của <b>_TOTAL_</b> kết quả"",
                    ""infoFiltered"": ""(Liệt kê từ <b>_MAX_</b> kết quả)"",
                    ""infoEmpty"": ""Không tìm thấy dữ liệu"",
                    ""search"": ""Tìm kiếm:"",
                    ""paginate"": {
                        ""first"": ""Trang đầu"",
                        ""last"": ""Trang cuối"",
                        ""next"": ""Tiếp theo"",
                        ""previous"": ""Trở về""
                    },
                    ""processing"": ""Đang tải dữ liệu""
                }
            });

            $('#offices').on('click', 'tbody tr', function() {
                var row = table.row($(this)).data();
                window.location.href = ""Offices/Details/"" + row.id;
            });

            var viewSwitch = 0;

     ");
                WriteLiteral(@"       if(viewSwitch == 0) {
                $('#offices').parents('div.dataTables_wrapper').first().hide();
            }

            $('#toggleButton').click(function(){
                $('#offices').parents('div.dataTables_wrapper').first().toggle();
                $(this).val($(this).val() == 'Hiển thị theo danh sách' ? 'Hiển thị theo bảng' : 'Hiển thị theo danh sách');
            });
        });
    </script>
");
            }
            );
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
