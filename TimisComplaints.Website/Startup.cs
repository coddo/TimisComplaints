using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TimisComplaints.Startup))]

namespace TimisComplaints
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
