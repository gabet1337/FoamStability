using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GUI.SaveOutputStrategies
{
    interface ISaveOutput
    {
        void SaveOutput(string fileLocation, List<int> data, int interval, double pixelsPerCentimeter);
    }
}
