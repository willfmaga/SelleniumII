using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Test.Helpers
{
    public class TestHelper
    {

        public static string PastaDoExecutavelDoDriver() =>
             Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
