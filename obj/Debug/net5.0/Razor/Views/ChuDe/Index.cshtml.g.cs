#pragma checksum "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\ChuDe\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "128bf4ecc9ca348c6566623bdf9e89dcf12a35af"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ChuDe_Index), @"mvc.1.0.view", @"/Views/ChuDe/Index.cshtml")]
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
#line 1 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\_ViewImports.cshtml"
using QLTV.AppMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\_ViewImports.cshtml"
using QLTV.AppMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"128bf4ecc9ca348c6566623bdf9e89dcf12a35af", @"/Views/ChuDe/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e964a4d44f615f132abc3245721e8e9f4c4dd80", @"/Views/_ViewImports.cshtml")]
    public class Views_ChuDe_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QLTV.AppMVC.Models.Entities.ChuDe>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\ChuDe\Index.cshtml"
  
    ViewData["Title"] = "Danh sách chủ đề";
    ViewData["page"] = "Chủ đề";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\ChuDe\Index.cshtml"
   
    if (TempData.ContainsKey("StatusMessage"))
    {
        var model = TempData["StatusMessage"].ToString();
        await Html.RenderPartialAsync("_StatusMessage", model);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>");
#nullable restore
#line 16 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\ChuDe\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "128bf4ecc9ca348c6566623bdf9e89dcf12a35af4217", async() => {
                WriteLiteral("Tạo mới");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<hr />\r\n\r\n<div class=\"row\">\r\n    <div class=\"container-fluid col-md-10 offset-md-1\">\r\n        <table id=\"myTable\" class=\"table table-sm\">\r\n            <thead");
            BeginWriteAttribute("class", " class=\"", 563, "\"", 571, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <tr>\r\n                    <th>Mã chủ đề</th>\r\n                    <th>Tên chủ đề</th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody></tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"    <link href=""https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css"" rel=""stylesheet"" />
    <script src=""https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.0.1/js/dataTables.buttons.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
    <script src=""https://cdn.datatables.net/buttons/2.0.1/js/buttons.html5.min.js""></script>
    <link href=""https://cdn.datatables.net/buttons/2.0.1/css/buttons.dataTables.min.css"" rel=""stylesheet"" />
    <script>
        $(document).ready(function () {
            $.ajax({
                url: '/api/chude/getall',
                type: 'get',
                data: {},
            }).done(function (res) {
                const modi");
                WriteLiteral(@"fierData = res.map(r => {
                    return {
                        ...r, tenChuDe: `<a href=""ChuDe/Edit/${r.id}"">${r.tenChuDe}</a>`,
                        tacvu: `<a href=""ChuDe/Delete/${r.id}"" class=""btn btn-sm btn-danger"">Xóa</a>`
                    }
                })
                console.log(res)
                $('#myTable').DataTable({
                    dom: 'Bfrtip',
                    buttons: [
                        {
                            extend: 'excelHtml5',
                            title: 'Data export'
                        },
                        
                    ],
                    'processing': true,
                    'info': false,
                    data: modifierData,
                    columns: [
                        { data: 'maChuDe' },
                        { data: 'tenChuDe' },
                        {data: 'tacvu'}
                    ],
                    language: {
                        ""lengthMenu"": ");
                WriteLiteral(@"""Hiển thị _MENU_ dòng"",
                        ""search"": ""Tìm kiếm:"",
                        ""zeroRecords"": ""Không tìm thấy dòng nào phù hợp"",
                        paginate: {
                            previous: 'Trước',
                            next: 'Sau'
                        },
                        aria: {
                            paginate: {
                                previous: 'Previous',
                                next: 'Next'
                            }
                        }
                    }
                });
            })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QLTV.AppMVC.Models.Entities.ChuDe>> Html { get; private set; }
    }
}
#pragma warning restore 1591
