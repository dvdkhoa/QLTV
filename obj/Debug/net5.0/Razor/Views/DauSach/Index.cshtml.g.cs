#pragma checksum "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "203652a4b8952feaa3d98111a93cee6881f44c70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DauSach_Index), @"mvc.1.0.view", @"/Views/DauSach/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
#nullable restore
#line 3 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Index.cshtml"
using Microsoft.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"203652a4b8952feaa3d98111a93cee6881f44c70", @"/Views/DauSach/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e964a4d44f615f132abc3245721e8e9f4c4dd80", @"/Views/_ViewImports.cshtml")]
    public class Views_DauSach_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QLTV.AppMVC.Models.Entities.DauSach>>
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Index.cshtml"
  
    ViewData["Title"] = "Danh sách các đầu sách";

    var KhoaId = Context.Request.Query["KhoaId"].ToString();
    var tacGiaId = Context.Request.Query["tacGiaId"].ToString();
    var chuDeId = Context.Request.Query["chuDeId"].ToString();


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 16 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "203652a4b8952feaa3d98111a93cee6881f44c704243", async() => {
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
            WriteLiteral("\r\n<hr />\r\n\r\n");
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"

<div class=""container-fluid"">
    <table id=""myTable"" class=""table table-striped"">
        <thead>
            <tr>
                <th>Mã đầu sách</th>
                <th>Tên đầu sách</th>
                <th>Tác giả</th>
                <th>Kệ sách</th>
                <th>Tác vụ</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"    <link href=""https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css"" rel=""stylesheet"" />
    <script src=""https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js""></script>

    <script>
        $(document).ready(function () {
            $.ajax({
                url: '/api/dausach',
                type: 'get',
                data: {},
            }).done(function (res) {
                let modifierData = res.map(r => {
                    return {
                        maDauSach: r.maDauSach,
                        tenDauSach: `<a href=""DauSach/Details/${r.id}"">${r.tenDauSach}</a>`,
                        tenTG: r.tenTG,
                        tenKeSach: r.tenKeSach,
                        tacVu: `<a href=""DauSach/Edit/${r.id}"" class=""btn btn-sm btn-outline-secondary"">Sửa</a>
                                <a href=""DauSach/Delete/${r.id}"" class=""btn btn-sm btn-outline-danger"">Xóa</a>`,
                    }
                })
                $('#myTable').DataT");
                WriteLiteral(@"able({
                    processing: true,
                    'info': false,
                    data: modifierData,
                    columns: [
                        { data: 'maDauSach' },
                        { data: 'tenDauSach' },
                        { data: 'tenTG' },
                        { data: 'tenKeSach' },
                        { data: 'tacVu' },
                    ],
                    language: {
                        ""lengthMenu"": ""Hiển thị _MENU_ dòng"",
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
     ");
                WriteLiteral("               }\r\n                });\r\n            })\r\n        });\r\n    </script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public QLTV.AppMVC.Models.AppDbContext _context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QLTV.AppMVC.Models.Entities.DauSach>> Html { get; private set; }
    }
}
#pragma warning restore 1591
