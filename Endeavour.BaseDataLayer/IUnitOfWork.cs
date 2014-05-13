﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endeavour.BaseDataLayer
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IContext Context { get; }

    }
}