#pragma checksum "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77c434965bde126619abf74cbece9bf65b92089b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"77c434965bde126619abf74cbece9bf65b92089b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e964a4d44f615f132abc3245721e8e9f4c4dd80", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Thư viện đại học kỹ thuật - công nghệ Cần Thơ";
    Layout = "_Layout2";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"greeting\" class=\"text-center\">\r\n    <h1>");
#nullable restore
#line 7 "C:\Users\dvdkh\Desktop\QLTV\QLTV.AppMVC\Views\Home\Index.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p>Xin chào bạn đến với phần mềm quản lý thư viện !</p>\r\n</div>\r\n<div class=\"form-group\">\r\n    <label>Tìm nhanh:</label>\r\n    <input id=\"tukhoa\" type=\"text\" name=\"input\" placeholder=\"Nhập tên sách\"");
            BeginWriteAttribute("value", " value=\"", 384, "\"", 392, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" />\r\n</div>\r\n<div id=\"ketqua\" class=\"mt-2\"></div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $(""#tukhoa"").keyup(function () {
                $.ajax({
                    url: ""/DauSach/TimAjax"",
                    data: {
                        keyword: $(""#tukhoa"").val().trim()
                    },
                    type: ""POST"",
                    success: function (data) {
                        $(""#ketqua"").html(data)
                    },
                    error: function (err) {
                        console.log(err)
                    }
                })
            })
        })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
