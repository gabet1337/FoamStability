using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GUI.SaveOutputStrategies
{
    class CSVSaveOutput : ISaveOutput
    {
        public void SaveOutput(string fileLocation, List<int> data, int interval, double pixelsPerCentimeter)
        {
            StringBuilder sb = new StringBuilder();
            int pos = 0;
            foreach (int i in data)
            {
                double heightInCentimeter = (double)i / pixelsPerCentimeter;
                sb.Append(pos + ";" + heightInCentimeter + "\r\n");
                pos += interval;
            }
            File.WriteAllText(fileLocation, sb.ToString(), Encoding.UTF8);
        }
    }
}
