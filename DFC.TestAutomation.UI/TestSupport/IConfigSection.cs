using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.TestSupport
{
    public interface IConfigSection
    {
        T GetConfigSection<T>();
    }
}
