#pragma checksum "C:\Users\Mohammed Ahmed Zaki\source\repos\Survey Analysis\SurveyAnalysis\Pages\Contact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a30616ed1becdc0f57e00367667669c190eb69c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SurveyAnalysis.Pages.Pages_Contact), @"mvc.1.0.razor-page", @"/Pages/Contact.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Contact.cshtml", typeof(SurveyAnalysis.Pages.Pages_Contact), null)]
namespace SurveyAnalysis.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Mohammed Ahmed Zaki\source\repos\Survey Analysis\SurveyAnalysis\Pages\_ViewImports.cshtml"
using SurveyAnalysis;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a30616ed1becdc0f57e00367667669c190eb69c1", @"/Pages/Contact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"118b5c4878f20405a5adba0376d1a59d27b2a8ef", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Contact : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Mohammed Ahmed Zaki\source\repos\Survey Analysis\SurveyAnalysis\Pages\Contact.cshtml"
  
    ViewData["Title"] = "Contact Us";

#line default
#line hidden
            BeginContext(107, 1557, true);
            WriteLiteral(@"

</br>
<style>
    body, html {
        height: 100%;
        margin: 0;
        font-family: Arial, Helvetica, sans-serif;
    }

    * {
        box-sizing: border-box;
    }

    /* Position text in the middle of the page/image */
    .bg-text {
        background: rgba(0, 0, 0, 0.5);
        color: #fff;
        font-weight: bold;
        border: 3px solid #f1f1f1;
        width: 206%;
        padding: 20px;
        text-align: center;
    }
</style>
<div class=""row"">
    <div class=""col-md-6"">
        <div class=""bg-text"">
            <h2 style=""font-size:35px"">Contact Us</h2>
            <p>We serve our clients from multiple locations in Saudi Arabia. In case of inquiries, complaints or suggestions please contact us through one of the beneath listed channels.</p>
            <address>
                DAR AL RIYADH
                <br />
                Building No.8616, Salah Al Din Al Ayoubi Road
                <br />
                PO Box - 5364
                <");
            WriteLiteral(@"br />
                Riyadh - 12623, Saudi Arabia
                <br />
                <a href=""Phone Number: 682-246-0581"">
                    Call us at 682-246-0581
                </a>
            </address>
            <address>
                <strong>Support:</strong> <a href=""mailto:Support@example.com"">info@daralriyadh.com</a><br />
                <strong>Marketing:</strong> <a href=""mailto:Marketing@example.com"">ahmedzaki3721@gmail.com</a>
            </address>

        </div>
    </div>
</div>

");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContactModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContactModel>)PageContext?.ViewData;
        public ContactModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591