using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Core.Utilities.IOC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
