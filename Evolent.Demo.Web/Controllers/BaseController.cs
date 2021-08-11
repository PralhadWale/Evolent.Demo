using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Evolent.Demo.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        public string FormatReportFromDate(DateTime fromDate)
        {
            return fromDate.Date.ToString("yyyy-MM-dd");
        }

        public string FormatReportToDate(DateTime toDate)
        {
            return toDate.Date.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm");
        }
    }
}
