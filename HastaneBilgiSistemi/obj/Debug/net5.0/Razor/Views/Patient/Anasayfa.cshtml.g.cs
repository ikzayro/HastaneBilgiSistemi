#pragma checksum "C:\Users\Admin\source\repos\HastaneBilgiSistemi\Views\Patient\Anasayfa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebfdca11c8c64c14bc05525d94fa31a841a0a6c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Patient_Anasayfa), @"mvc.1.0.view", @"/Views/Patient/Anasayfa.cshtml")]
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
#line 1 "C:\Users\Admin\source\repos\HastaneBilgiSistemi\Views\_ViewImports.cshtml"
using HastaneBilgiSistemi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\HastaneBilgiSistemi\Views\_ViewImports.cshtml"
using HastaneBilgiSistemi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Admin\source\repos\HastaneBilgiSistemi\Views\Patient\Anasayfa.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebfdca11c8c64c14bc05525d94fa31a841a0a6c3", @"/Views/Patient/Anasayfa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95fd8189458f10afa7c0694f803227554d974ec3", @"/Views/_ViewImports.cshtml")]
    public class Views_Patient_Anasayfa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\source\repos\HastaneBilgiSistemi\Views\Patient\Anasayfa.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_Layout3.cshtml";
    string name = Context.Session.GetString("name");
    string surname = Context.Session.GetString("surname");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <h2>Hoşgeldiniz Sayın ");
#nullable restore
#line 10 "C:\Users\Admin\source\repos\HastaneBilgiSistemi\Views\Patient\Anasayfa.cshtml"
                     Write(name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 10 "C:\Users\Admin\source\repos\HastaneBilgiSistemi\Views\Patient\Anasayfa.cshtml"
                           Write(surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2><br>\r\n    <h4>Yukaridaki menülerden istediginiz işlemi seçebilirsiniz.</h2>\r\n</div>\r\n");
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
