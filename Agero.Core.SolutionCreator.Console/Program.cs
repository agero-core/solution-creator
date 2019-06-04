using System;
using System.IO;
using Agero.Core.Checker;
using CommandLine;
using static System.Console;

namespace Agero.Core.SolutionCreator.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Parser.Default.ParseArguments<Options>(args).WithParsed(Execute);
            }
            catch (Exception ex)
            {
                WriteLine("Unexpected error:");
                WriteLine(ex.ToString());
            }
        }

        private static void Execute(Options options)
        {
            Check.ArgumentIsNull(options, nameof(options));
            Check.ArgumentIsNull(options.CompanyName, nameof(options.CompanyName));
            Check.ArgumentIsNull(options.ApplicationName, nameof(options.ApplicationName));
            Check.ArgumentIsNull(options.TemplateDirectoryPath, nameof(options.TemplateDirectoryPath));
            Check.Argument(Directory.Exists(options.TemplateDirectoryPath), "Template directory does not exist.");
            Check.ArgumentIsNull(options.OutputDestination, nameof(options.OutputDestination));
            Check.ArgumentIsNull(options.ApplicationNamePlaceHolder, nameof(options.ApplicationNamePlaceHolder));
            Check.ArgumentIsNull(options.CompanyNamePlaceHolder, nameof(options.CompanyNamePlaceHolder));

            if (!Directory.Exists(options.OutputDestination))
                Directory.CreateDirectory(options.OutputDestination);

            FileHelper.CopyDirectory(options.TemplateDirectoryPath, options.OutputDestination);
            FileHelper.ReplaceNameAndTextInDirectoriesAndFiles(options.OutputDestination, options.CompanyNamePlaceHolder, options.CompanyName);
            FileHelper.ReplaceNameAndTextInDirectoriesAndFiles(options.OutputDestination, options.ApplicationNamePlaceHolder, options.ApplicationName);

            WriteLine($"Solution created at {options.OutputDestination}.");
        }
    }
}
