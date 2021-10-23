#pragma checksum "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "600acbe75d94147e23ee4d1640818d3fada1e684"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_DauSach_Details), @"mvc.1.0.view", @"/Views/DauSach/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"600acbe75d94147e23ee4d1640818d3fada1e684", @"/Views/DauSach/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e964a4d44f615f132abc3245721e8e9f4c4dd80", @"/Views/_ViewImports.cshtml")]
    public class Views_DauSach_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QLTV.AppMVC.Models.Entities.DauSach>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 5 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
  
    ViewData["Title"] = "Thông tin chi tiết đầu sách";

    var dsSach = _context.Sach.Where(s => s.DauSach_Id == Model.Id).ToList();

    var slConLai = dsSach.Count(s => !s.DangMuon);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>");
#nullable restore
#line 13 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
Write(Model.TenDauSach);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-4\">\r\n        <div class=\"w-100\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 402, "\"", 424, 1);
#nullable restore
#line 18 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
WriteAttributeValue("", 408, Model.ImagePath, 408, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""img-thumbnail"" />
        </div>
        <table class=""table small"">
            <thead>
                <tr>
                    <th>Mã sách</th>
                    <th>Trạng thái</th>
                    <th>Sinh viên</th>
                    <th>Hạn trả</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 30 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                 foreach (var s in dsSach)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 34 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                   Write(s.MaSach);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 36 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                      
                        if (s.DangMuon)
                        {
                            var ctm = _context.ChiTietMuon.FirstOrDefault(ctm => ctm.MaSach == s.MaSach);

                            var sv = _context.PhieuMuon.FirstOrDefault(pm => pm.Id == ctm.PM_Id).MaSV;


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>Đang mượn</td>\r\n                            <td>");
#nullable restore
#line 44 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                           Write(sv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 45 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                           Write(ctm.HanTra.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 46 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td></td>\r\n                            <td></td>\r\n                            <td></td>\r\n");
#nullable restore
#line 52 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 55 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"col-lg-8\">\r\n        <p");
            BeginWriteAttribute("class", " class=\"", 1797, "\"", 1805, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "600acbe75d94147e23ee4d1640818d3fada1e6847581", async() => {
                WriteLiteral("Về danh sách đầu sách");
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
            WriteLiteral("\r\n        </p>\r\n        <table class=\"table table-bordered table-striped\">\r\n            <tr>\r\n                <td>");
#nullable restore
#line 65 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.MaDauSach));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 66 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.MaDauSach);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 69 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.TenDauSach));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 70 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.TenDauSach);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n\r\n            <tr>\r\n                <td>");
#nullable restore
#line 74 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.SL));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 75 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.SL);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (Còn lại: ");
#nullable restore
#line 75 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
                                   Write(slConLai);

#line default
#line hidden
#nullable disable
            WriteLiteral(" quyển)</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 78 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.LoaiSach_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 79 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayFor(m => m.LoaiSach.TenLoaiSach));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 82 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.ChuDe_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 83 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayFor(m => m.ChuDe.MaChuDe));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 86 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.TacGia_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 87 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayFor(m => m.TacGia.TenTG));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 90 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.NXB_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 91 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayFor(m => m.NXB.TenNXB));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 94 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.NamXB));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 95 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.NamXB);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 98 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.Khoa_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 99 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayFor(m => m.Khoa.TenKhoa));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 102 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.HocPhan_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 103 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayFor(m => m.HocPhan.TenHocPhan));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 106 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.KeSach_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 107 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayFor(m => m.KeSach.TenKeSach));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 110 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.NgonNgu_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 111 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayFor(m => m.NgonNgu.TenNN));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 114 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.SoTrang));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 115 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.SoTrang);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 118 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.SoTap));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 119 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.SoTap);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 122 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.TenTap));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 123 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.TenTap);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 126 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.TenKhac));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 127 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.TenKhac);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 130 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.KhoCo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 131 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.KhoCo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 134 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.MinhHoa));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 135 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.MinhHoa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 138 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.GiaBia));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 139 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.GiaBia);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 142 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.Nguon));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 143 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.Nguon);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 146 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.TungThu));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 147 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.TungThu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 150 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.DinhKem));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 151 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.DinhKem);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <td>");
#nullable restore
#line 154 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Html.DisplayNameFor(m => m.ISBN));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 155 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\DauSach\Details.cshtml"
               Write(Model.ISBN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public AppDbContext _context { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QLTV.AppMVC.Models.Entities.DauSach> Html { get; private set; }
    }
}
#pragma warning restore 1591
