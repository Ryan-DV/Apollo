using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YXBqSVSFInterop.Interfaces
{
    public interface IInjectionTechnique
    {
        bool Inject(string arguments = "");
    }
}
