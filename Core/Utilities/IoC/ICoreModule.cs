﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.IoC
{
   public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
