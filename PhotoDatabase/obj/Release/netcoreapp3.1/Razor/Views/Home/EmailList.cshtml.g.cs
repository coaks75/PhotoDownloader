#pragma checksum "C:\Users\Chris\Desktop\PhotoDownloader\PhotoDatabase\Views\Home\EmailList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d22f8e963361b1668ce456f1709a54e56eec0a88"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EmailList), @"mvc.1.0.view", @"/Views/Home/EmailList.cshtml")]
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
#line 1 "C:\Users\Chris\Desktop\PhotoDownloader\PhotoDatabase\Views\_ViewImports.cshtml"
using PhotoDownloader;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Chris\Desktop\PhotoDownloader\PhotoDatabase\Views\_ViewImports.cshtml"
using PhotoDownloader.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d22f8e963361b1668ce456f1709a54e56eec0a88", @"/Views/Home/EmailList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d197d50c71a57f2b92717f89dfb9a0f518bcb05", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EmailList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\Users\Chris\Desktop\PhotoDownloader\PhotoDatabase\Views\Home\EmailList.cshtml"
  
    ViewData["Title"] = "EmailList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Email List</h1>\n<p>If you would like, I can save your email and notify you when my model can transform black and white images into colored images!</p>\n");
#nullable restore
#line 8 "C:\Users\Chris\Desktop\PhotoDownloader\PhotoDatabase\Views\Home\EmailList.cshtml"
 using (Html.BeginForm("EmailList", "Home", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <label for=\"email\">Enter your email:</label>\n    <input type=\"email\" id=\"email\" name=\"email\">\n    <button type=\"submit\">Submit</button>\n");
#nullable restore
#line 13 "C:\Users\Chris\Desktop\PhotoDownloader\PhotoDatabase\Views\Home\EmailList.cshtml"
}

#line default
#line hidden
#nullable disable
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
