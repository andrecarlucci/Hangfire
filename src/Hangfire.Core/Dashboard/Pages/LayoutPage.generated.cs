﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\LayoutPage.cshtml"
    using System;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    
    #line 3 "..\..\Dashboard\Pages\LayoutPage.cshtml"
    using System.Diagnostics;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Dashboard\Pages\LayoutPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Dashboard\Pages\LayoutPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\LayoutPage.cshtml"
    using Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class LayoutPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");







WriteLiteral("<!DOCTYPE html>\r\n\r\n<html lang=\"en\">\r\n<head>\r\n    <title>");


            
            #line 12 "..\..\Dashboard\Pages\LayoutPage.cshtml"
      Write(Title);

            
            #line default
            #line hidden
WriteLiteral(" - Hangfire</title>\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n " +
"   <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-wid" +
"th, initial-scale=1.0\">\r\n    <link rel=\"stylesheet\" href=\"");


            
            #line 16 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/css"));

            
            #line default
            #line hidden
WriteLiteral(@""" />
</head>
    <body>
        <!-- Wrap all page content here -->
        <div id=""wrap"">

            <!-- Fixed navbar -->
            <div class=""navbar navbar-default navbar-static-top"">
                <div class=""container"">
                    <div class=""navbar-header"">
                        <button type=""button"" class=""navbar-toggle"" data-toggle=""collapse"" data-target="".navbar-collapse"">
                            <span class=""icon-bar""></span>
                            <span class=""icon-bar""></span>
                            <span class=""icon-bar""></span>
                        </button>
                        <a class=""navbar-brand"" href=""");


            
            #line 31 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                                 Write(Request.LinkTo("/"));

            
            #line default
            #line hidden
WriteLiteral(@""">Hangfire Dashboard</a>
                    </div>
                    <div class=""collapse navbar-collapse"">
                        <ul class=""nav navbar-nav navbar-right"">
                            <li>
                                <a href=""/"">
                                    <span class=""glyphicon glyphicon-log-out""></span>
                                    Back to site
                                </a>
                            </li>
                        </ul>
                    </div>
                    <!--/.nav-collapse -->
                </div>
            </div>

            <!-- Begin page content -->

            <div class=""container"">
                <div class=""col-md-3"">
");


            
            #line 51 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                      
                        var monitor = Storage.GetMonitoringApi();
                        StatisticsDto statistics = monitor.GetStatistics();
                    

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div id=\"stats\" class=\"list-group\">\r\n                      " +
"  <a class=\"list-group-item ");


            
            #line 57 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                              Write(Request.Path.Value.Equals("/") || Request.Path.Value.Length == 0 ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                           href=\"");


            
            #line 58 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span class=\"glyphicon glyphicon-dashboard\"></spa" +
"n>\r\n                            Dashboard\r\n                        </a>\r\n\r\n     " +
"                   <a class=\"list-group-item ");


            
            #line 63 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                              Write(Request.Path.Value.Equals("/servers") ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                           href=\"");


            
            #line 64 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/servers"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span class=\"label label-default pull-right\">");


            
            #line 65 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                                                    Write(statistics.Servers);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <span class=\"glyphicon glyphicon-hdd\"></span" +
">\r\n                            Servers\r\n                        </a>\r\n          " +
"              \r\n                        <a class=\"list-group-item ");


            
            #line 70 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                              Write(Request.Path.Value.Equals("/recurring") ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                           href=\"");


            
            #line 71 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/recurring"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span id=\"stats-recurring\" class=\"label label-def" +
"ault pull-right\">\r\n                                ");


            
            #line 73 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                           Write(statistics.Recurring);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n\r\n                            <span class=" +
"\"glyphicon glyphicon-time\"></span>\r\n                            Recurring jobs\r\n" +
"                        </a>\r\n\r\n                        <a class=\"list-group-ite" +
"m ");


            
            #line 80 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                              Write(Request.Path.Value.StartsWith("/queues") ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\" \r\n                           href=\"");


            
            #line 81 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/queues"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span class=\"label label-default pull-right\">\r\n  " +
"                              <span id=\"stats-enqueued\" title=\"Enqueued jobs cou" +
"nt\">\r\n                                    ");


            
            #line 84 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                               Write(statistics.Enqueued);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                </span>\r\n                                / \r\n  " +
"                              <span id=\"stats-queues\" title=\"Queues count\">\r\n   " +
"                                 ");


            
            #line 88 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                               Write(statistics.Queues);

            
            #line default
            #line hidden
WriteLiteral(@"
                                </span>
                            </span>
                            <span class=""glyphicon glyphicon-inbox""></span>
                            Queues
                        </a>
                        <a class=""list-group-item stats-indent ");


            
            #line 94 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                                           Write(Request.Path.Value.Equals("/scheduled") ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\" \r\n                           href=\"");


            
            #line 95 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/scheduled"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span id=\"stats-scheduled\" class=\"label label-inf" +
"o pull-right\">\r\n                                ");


            
            #line 97 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                           Write(statistics.Scheduled);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            Scheduled\r\n   " +
"                     </a>\r\n                        <a class=\"list-group-item sta" +
"ts-indent ");


            
            #line 101 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                                           Write(Request.Path.Value.Equals("/processing") ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\" \r\n                           href=\"");


            
            #line 102 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/processing"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span id=\"stats-processing\" class=\"label label-wa" +
"rning pull-right\">\r\n                                ");


            
            #line 104 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                           Write(statistics.Processing);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            Processing\r\n  " +
"                      </a>\r\n                        <a class=\"list-group-item st" +
"ats-indent ");


            
            #line 108 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                                           Write(Request.Path.Value.Equals("/succeeded") ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\" \r\n                           href=\"");


            
            #line 109 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/succeeded"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span id=\"stats-succeeded\" class=\"label label-suc" +
"cess pull-right\">\r\n                                ");


            
            #line 111 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                           Write(statistics.Succeeded);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            Succeeded\r\n   " +
"                     </a>\r\n                        <a class=\"list-group-item sta" +
"ts-indent ");


            
            #line 115 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                                           Write(Request.Path.Value.Equals("/failed") ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\" \r\n                           href=\"");


            
            #line 116 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/failed"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span id=\"stats-failed\" class=\"label label-danger" +
" pull-right\">\r\n                                ");


            
            #line 118 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                           Write(statistics.Failed);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            Failed\r\n      " +
"                  </a>\r\n                        <a class=\"list-group-item stats-" +
"indent ");


            
            #line 122 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                                           Write(Request.Path.Value.Equals("/deleted") ? "active" : null);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                           href=\"");


            
            #line 123 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            Write(Request.LinkTo("/deleted"));

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            <span id=\"stats-deleted\" class=\"label label-defau" +
"lt pull-right\">\r\n                                ");


            
            #line 125 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                           Write(statistics.Deleted);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </span>\r\n                            Deleted\r\n     " +
"                   </a>\r\n                    </div>\r\n                </div>\r\n   " +
"             <div class=\"col-md-9\">\r\n");


            
            #line 132 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                     if (Breadcrumbs != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <ol class=\"breadcrumb\">\r\n                            <li>" +
"<a href=\"");


            
            #line 135 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                    Write(Request.LinkTo("/"));

            
            #line default
            #line hidden
WriteLiteral("\"><span class=\"glyphicon glyphicon-home\"></span></a></li>\r\n");


            
            #line 136 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                             foreach (var breadcrumb in Breadcrumbs)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <li><a href=\"");


            
            #line 138 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                        Write(breadcrumb.Value);

            
            #line default
            #line hidden
WriteLiteral("\">");


            
            #line 138 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                                           Write(breadcrumb.Key);

            
            #line default
            #line hidden
WriteLiteral("</a></li>\r\n");


            
            #line 139 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            <li class=\"active\">");


            
            #line 140 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                                           Write(BreadcrumbsTitle ?? Title);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                        </ol>\r\n");


            
            #line 142 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <h1 class=\"page-header\">\r\n                        ");


            
            #line 145 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                   Write(Title);

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 146 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                         if (!String.IsNullOrEmpty(Subtitle))
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <small>");


            
            #line 148 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                              Write(Subtitle);

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n");


            
            #line 149 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </h1>\r\n                    ");


            
            #line 151 "..\..\Dashboard\Pages\LayoutPage.cshtml"
               Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral(@"
                </div>
            </div>
        </div>

        <div id=""footer"">
            <div class=""container"">
                <ul class=""list-inline credit"">
                    <li>
                        <a href=""http://hangfire.io/"" target=""_blank"">Hangfire 
");


            
            #line 161 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                              
                                var version = GetType().Assembly.GetName().Version;
                            

            
            #line default
            #line hidden
WriteLiteral("                            ");


            
            #line 164 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                       Write(String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Build));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </a>\r\n                    </li>\r\n                    <l" +
"i>");


            
            #line 167 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                   Write(Storage);

            
            #line default
            #line hidden
WriteLiteral("</li>\r\n                    <li>Time: ");


            
            #line 168 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                         Write(DateTime.UtcNow);

            
            #line default
            #line hidden
WriteLiteral(@" GMT
                    </li>
                </ul>
            </div>
        </div>
        
        <script>
            (function (hangFire) {
                hangFire.config = {
                    pollInterval: 2000,
                    pollUrl: '");


            
            #line 178 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                          Write(Request.LinkTo("/stats"));

            
            #line default
            #line hidden
WriteLiteral("\'\r\n                };\r\n            })(window.Hangfire = window.Hangfire || {});\r\n" +
"        </script>\r\n        <script src=\"");


            
            #line 182 "..\..\Dashboard\Pages\LayoutPage.cshtml"
                Write(Request.LinkTo("/js"));

            
            #line default
            #line hidden
WriteLiteral("\"></script>\r\n    </body>\r\n</html>\r\n");


        }
    }
}
#pragma warning restore 1591
