using System;
using System.Collections.Generic;
using System.Text;

namespace DFC.TestAutomation.UI.TestSupport
{
    public class ScreenShotTitleGenerator
    {
        private int count;

        public ScreenShotTitleGenerator(int start)
        {
            count = start;
        }

        public string GetNextCount()
        {
            return (++count).ToString("D2");
        }
    }
}
