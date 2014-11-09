using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GUI.SaveOutputStrategies
{
    class CSVSaveOutput : ISaveOutput
    {
        public void SaveOutput(string fileLocation, List<int> data, int interval)
        {
            StringBuilder sb = new StringBuilder();
            int pos = 0;
            foreach (int i in data)
            {
                sb.Append(pos + ";" + i + "\r\n");
                pos += interval;
            }
            File.WriteAllText(fileLocation, sb.ToString(), Encoding.UTF8);
        }
    }
}
