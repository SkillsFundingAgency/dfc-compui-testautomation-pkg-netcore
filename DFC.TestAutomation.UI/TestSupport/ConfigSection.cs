using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class ConfigSection : IConfigSection
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigSection(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public T GetConfigSection<T>()
        {
            return _configurationRoot.GetSection(typeof(T).Name).Get<T>();
        }
    }
}
