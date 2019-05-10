using System.Text;

namespace Agero.Core.SolutionCreator.Console
{
    public static class InfoHelper
    {
        public static string GetApplicationInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("***** Solution Creator *****");
            sb.AppendLine();
            sb.AppendLine("Description:");
            sb.AppendLine("  Tool for creating initial solution from template by replacing company and");
            sb.AppendLine("  application names in template files and directories.");
            sb.AppendLine();
            sb.AppendLine("Usage:");
            sb.AppendLine("  SolutionCreator company_name app_name template_dir_path [-d destination]");
            sb.AppendLine("                  [-a app_name_placeholder] [-c comp_name_placeholder]");
            sb.AppendLine();
            sb.AppendLine("Parameters:");
            sb.AppendLine("  company_name          Required  Company name, ex. 'Agero'.");
            sb.AppendLine("  app_name              Required  Application name, ex. 'CaseAPI'.");
            sb.AppendLine("  template_dir_path     Required  Solution template directory path.");
            sb.AppendLine("  destination           Optional  Directory to copy output directories and");
            sb.AppendLine("                                  files. Default is current directory.");
            sb.AppendLine("  app_name_placeholder  Optional  Application name placeholder which is");
            sb.AppendLine("                                  used in template. Default is 'APP__NAME'.");
            sb.AppendLine("  comp_name_placeholder Optional  Company name placeholder which is");
            sb.AppendLine("                                  template. Default is 'COM__NAME'.");
            
            return sb.ToString();
        }
    }
}
