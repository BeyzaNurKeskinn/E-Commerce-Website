#pragma checksum "C:\Users\beyza\OneDrive\Masaüstü\eticaretb\eticaretb\Areas\Admin\Views\Giris\KullaniciEkle.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb9fc52cbe1f90c3a852603eed08fbed41aa46e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Giris_KullaniciEkle), @"mvc.1.0.view", @"/Areas/Admin/Views/Giris/KullaniciEkle.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb9fc52cbe1f90c3a852603eed08fbed41aa46e9", @"/Areas/Admin/Views/Giris/KullaniciEkle.cshtml")]
    public class Areas_Admin_Views_Giris_KullaniciEkle : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eticaretb.Models.Kullanicilar>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\beyza\OneDrive\Masaüstü\eticaretb\eticaretb\Areas\Admin\Views\Giris\KullaniciEkle.cshtml"
  
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n<!-- RENDER -->\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n");
#nullable restore
#line 12 "C:\Users\beyza\OneDrive\Masaüstü\eticaretb\eticaretb\Areas\Admin\Views\Giris\KullaniciEkle.cshtml"
         using (Html.BeginForm("KullaniciEkle", "Giris", FormMethod.Post, new { enctype = "multipart/form-data" }))
        {
        

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""form-horizontal"">

                    <div class=""panel panel-default"">
                        <div class=""panel-heading"">
                            <h3 class=""panel-title""><strong>Kullanıcı</strong></h3>



                            <ul class=""panel-controls"">
                                <li><a href=""#"" class=""panel-remove""><span class=""fa fa-times""></span></a></li>
                            </ul>
                        </div>

                        <div class=""panel-body"">



                            <div class=""form-group"">
                                <label class=""col-md-3 col-xs-12 control-label"">Ad </label>
                                <div class=""col-md-6 col-xs-12"">
                                <input type=""text"" class=""form-control"" name=""Ad""");
            BeginWriteAttribute("value", " value=\"", 1160, "\"", 1168, 0);
            EndWriteAttribute();
            WriteLiteral(@"/>
                                    <span class=""help-block""></span>
                                </div>
                            </div>

                            <div class=""form-group"">
                                <label class=""col-md-3 col-xs-12 control-label"">Soyad</label>
                                <div class=""col-md-6 col-xs-12"">
                                <input type=""text"" class=""form-control"" name=""Soyad""");
            BeginWriteAttribute("value", " value=\"", 1620, "\"", 1628, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    <span class=""help-block""></span>
                                </div>
                            </div>

                            <div class=""form-group"">
                            <label class=""col-md-3 col-xs-12 control-label"">Kurum</label>
                                <div class=""col-md-6 col-xs-12"">
                                <input type=""text"" class=""form-control"" name=""Kurum""");
            BeginWriteAttribute("value", " value=\"", 2077, "\"", 2085, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    <span class=""help-block""></span>
                                </div>
                            </div>

                            <div class=""form-group"">
                                <label class=""col-md-3 col-xs-12 control-label"">Email</label>
                                <div class=""col-md-6 col-xs-12"">
                                <input type=""text"" class=""form-control"" name=""Email""");
            BeginWriteAttribute("value", " value=\"", 2538, "\"", 2546, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    <span class=""help-block""></span>
                                </div>
                            </div>

                            <div class=""form-group"">
                                <label class=""col-md-3 col-xs-12 control-label"">Rol</label>
                                <div class=""col-md-6 col-xs-12"">
                                <input type=""text"" class=""form-control"" name=""Rol""");
            BeginWriteAttribute("value", " value=\"", 2995, "\"", 3003, 0);
            EndWriteAttribute();
            WriteLiteral(@" />
                                    <span class=""help-block""></span>
                                </div>
                            </div>




                        </div>
                        <div class=""panel-footer"">
                            <button class=""btn btn-default"">Temizle</button>
                            <button class=""btn btn-primary pull-right"">Kaydet</button>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 82 "C:\Users\beyza\OneDrive\Masaüstü\eticaretb\eticaretb\Areas\Admin\Views\Giris\KullaniciEkle.cshtml"



            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n    </div>\r\n\r\n<!-- RENDER -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eticaretb.Models.Kullanicilar> Html { get; private set; }
    }
}
#pragma warning restore 1591
