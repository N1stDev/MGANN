using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    static internal class FormsSharedData
    {
        public static Form1 mainForm = new();

        public static string loadedFilePath = "";

        public static bool isFileLoaded = false;
    }
}
