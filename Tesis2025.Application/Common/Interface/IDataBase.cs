﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tesis2025.Application.Common.Interface
{
    public interface IDataBase
    {
        IDbConnection GetConnection();
    }
}
