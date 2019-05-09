using System.Text;

namespace Agero.Core.SolutionCreator.Console
{
    public static class InfoHelper
    {
        public static string GetApplicationInfo()
        {
            var sb = new StringBuilder();

            const string APPLICATION_NAME = "SolutionCreator";

            sb.AppendLine();
            sb.Append("***** ");
            sb.Append(APPLICATION_NAME);
            sb.AppendLine(" *****");

            const int PARAGRAPH_RIGHT_PADDING = 2;
            var emptySpacesForParagraph = new string(' ', PARAGRAPH_RIGHT_PADDING);

            sb.AppendLine();
            sb.AppendLine("Description:");
            sb.Append(emptySpacesForParagraph);
            sb.AppendLine("Tool for creating initial solution from template by replacing company and");
            sb.Append(emptySpacesForParagraph);
            sb.AppendLine("application names in template files and directories.");

            sb.AppendLine();
            sb.AppendLine("Usage:");
            sb.Append(emptySpacesForParagraph);
            sb.Append(APPLICATION_NAME);
            sb.AppendLine(" company_name app_name template_dir_path [-d destination]");
            sb.Append(emptySpacesForParagraph);
            sb.AppendLine("                [-a app_name_placeholder] [-c company_name_placeholder]");

            sb.AppendLine();
            sb.AppendLine("Parameters:");

            const int FIRST_COLUMN_RIGHT_PADDING = 26;
            const int SECOND_COLUMN_RIGHT_PADDING = 10;

            var required = "Required".PadRight(SECOND_COLUMN_RIGHT_PADDING);
            var optional = "Optional".PadRight(SECOND_COLUMN_RIGHT_PADDING);

            var emptyStringBeforeThirdColumn = new string(' ', PARAGRAPH_RIGHT_PADDING + FIRST_COLUMN_RIGHT_PADDING + SECOND_COLUMN_RIGHT_PADDING);

            sb.Append(emptySpacesForParagraph);
            sb.Append("company_name".PadRight(FIRST_COLUMN_RIGHT_PADDING));
            sb.Append(required);
            sb.AppendLine("Company name, ex. 'Agero'.");

            sb.Append(emptySpacesForParagraph);
            sb.Append("app_name".PadRight(FIRST_COLUMN_RIGHT_PADDING));
            sb.Append(required);
            sb.AppendLine("Application name, ex. 'CaseAPI'.");

            sb.Append(emptySpacesForParagraph);
            sb.Append("template_dir_path".PadRight(FIRST_COLUMN_RIGHT_PADDING));
            sb.Append(required);
            sb.AppendLine("Solution template directory path.");

            sb.Append(emptySpacesForParagraph);
            sb.Append("destination".PadRight(FIRST_COLUMN_RIGHT_PADDING));
            sb.Append(optional);
            sb.AppendLine("Directory to copy output files and");
            sb.Append(emptyStringBeforeThirdColumn);
            sb.AppendLine("directories. Default is current directory.");

            sb.Append(emptySpacesForParagraph);
            sb.Append("app_name_placeholder".PadRight(FIRST_COLUMN_RIGHT_PADDING));
            sb.Append(optional);
            sb.AppendLine("Application name placeholder to be used in");
            sb.Append(emptyStringBeforeThirdColumn);
            sb.AppendLine("template. Default is 'APP__NAME'.");

            sb.Append(emptySpacesForParagraph);
            sb.Append("company_name_placeholder".PadRight(FIRST_COLUMN_RIGHT_PADDING));
            sb.Append(optional);
            sb.AppendLine("Company name placeholder to be used in");
            sb.Append(emptyStringBeforeThirdColumn);
            sb.AppendLine("template. Default is 'COM__NAME'.");

            return sb.ToString();
        }
    }
}
