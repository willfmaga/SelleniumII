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
          Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        public static string PastaDoExecutavelDoGoogleDriver87() =>
         Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"GoogleDrive\87");

        public static string PastaDeExecucaoTeste() =>
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string CaminhoCompletoArquivo(string pastaENomeArquivoJuntos) =>
            Path.Combine(PastaDeExecucaoTeste(), pastaENomeArquivoJuntos);
    }
}
