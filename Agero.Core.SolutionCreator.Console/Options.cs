using System;
using System.IO;
using CommandLine;

namespace Agero.Core.SolutionCreator.Console
{
    internal class Options
    {
        public Options(string companyName, string applicationName, string templateDirectoryPath, 
            string outputDestination, string applicationNamePlaceHolder, string companyNamePlaceHolder)
        {
            CompanyName = companyName;
            ApplicationName = applicationName;
            TemplateDirectoryPath = templateDirectoryPath;
            OutputDestination = outputDestination ?? Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToString("yyyyMMddhhmmss"));
            ApplicationNamePlaceHolder = applicationNamePlaceHolder ?? DEFAULT_APPLICATION_NAME_PLACEHOLDER;
            CompanyNamePlaceHolder = companyNamePlaceHolder ?? DEFAULT_COMPANY_NAME_PLACEHOLDER;
        }

        [Value(0, MetaName = "company_name", 
            HelpText = "Company name, ex. 'Agero'.", 
            Hidden = false, Required = true)]
        public string CompanyName { get; }

        [Value(1, MetaName = "app_name", 
            HelpText = "Application name, ex. 'TestAPI'.",
            Hidden = false, Required = true)]
        public string ApplicationName { get; }

        [Value(2, MetaName = "template_dir_path", 
            HelpText = "Solution template directory path.",
            Hidden = false, Required = true)]
        public string TemplateDirectoryPath { get; }

        [Option('d', MetaValue = "output_destination", 
            HelpText = "Directory to copy output directories and files. Default is current directory.",
            Hidden = false, Required = false)]
        public string OutputDestination { get; }

        public const string DEFAULT_APPLICATION_NAME_PLACEHOLDER = "APP__NAME";

        [Option('a', MetaValue = "app_name_placeholder", 
            HelpText = "Application name placeholder which is used in template. Default is '" + DEFAULT_APPLICATION_NAME_PLACEHOLDER + "'.",
            Hidden = false, Required = false)]
        public string ApplicationNamePlaceHolder { get; }

        public const string DEFAULT_COMPANY_NAME_PLACEHOLDER = "COMP__NAME";

        [Option('c', MetaValue = "comp_name_placeholder", 
            HelpText = "Company name placeholder which is used in template. Default is '" + DEFAULT_COMPANY_NAME_PLACEHOLDER + "'.",
            Hidden = false, Required = false)]
        public string CompanyNamePlaceHolder { get; }
    }
}
