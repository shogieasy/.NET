using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zad6
{
    public class Middleware
    {
        private RequestDelegate next;
        public Middleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IBrowserDetector detector)
        {
            var browser = detector.Browser;


            if ((browser.Name == BrowserNames.Edge) || (browser.Name == BrowserNames.EdgeChromium) || (browser.Name == BrowserNames.InternetExplorer))
            {
                await context.Response
                      .WriteAsync("Przeglądarka nie jest obsługiwana");
            }
            else
            {
                await next(context);
            }
        }
    }
}
