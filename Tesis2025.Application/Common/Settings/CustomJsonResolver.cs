﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Tesis2025.Application.Common.Settings
{
    public class CustomJsonResolver : DefaultContractResolver
    {
        public CustomJsonResolver() : base()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }
    }
}
