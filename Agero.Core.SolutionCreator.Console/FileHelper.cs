using System.IO;
using Agero.Core.Checker;

namespace Agero.Core.SolutionCreator.Console
{
    public static class FileHelper
    {
        public static void CopyDirectory(string source, string destination)
        {
            Check.ArgumentIsNullOrWhiteSpace(source, nameof(source));
            Check.Argument(Directory.Exists(source), "Directory.Exists(source)");
            Check.ArgumentIsNullOrWhiteSpace(destination, nameof(destination));
            Check.Argument(Directory.Exists(destination), "Directory.Exists(destination)");

            foreach (var directory in Directory.GetDirectories(source))
            {
                var directoryName = Path.GetFileName(directory);
                var destinationPath = Path.Combine(destination, directoryName);
                if (!Directory.Exists(destinationPath))
                    Directory.CreateDirectory(destinationPath);

                CopyDirectory(directory, destinationPath);
            }

            foreach (var file in Directory.GetFiles(source))
            {
                File.Copy(file, Path.Combine(destination, Path.GetFileName(file)));
            }
        }

        public static void ReplaceNameAndTextInDirectoriesAndFiles(string directoryPath, string oldValue, string newValue)
        {
            Check.ArgumentIsNullOrWhiteSpace(directoryPath, nameof(directoryPath));
            Check.Argument(Directory.Exists(directoryPath), "Directory.Exists(directoryPath)");
            Check.ArgumentIsNullOrWhiteSpace(oldValue, nameof(oldValue));
            Check.ArgumentIsNullOrWhiteSpace(newValue, nameof(newValue));

            RenameAllDirectoriesAndFiles(directoryPath, oldValue, newValue);
            UpdateTextInAllFiles(directoryPath, oldValue, newValue);
        }

        private static void RenameAllDirectoriesAndFiles(string directoryPath, string oldName, string newName)
        {
            Check.ArgumentIsNullOrWhiteSpace(directoryPath, nameof(directoryPath));
            Check.Argument(Directory.Exists(directoryPath), "Directory.Exists(directoryPath)");
            Check.ArgumentIsNullOrWhiteSpace(oldName, nameof(oldName));
            Check.ArgumentIsNullOrWhiteSpace(newName, nameof(newName));

            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                RenameAllDirectoriesAndFiles(directory, oldName, newName);

                RenameFiles(directory, oldName, newName);

                var oldDirectoryName = Path.GetFileName(directory);
                var newDirectoryName = oldDirectoryName.Replace(oldName, newName);
                if (oldDirectoryName != newDirectoryName)
                    Directory.Move(directory, Path.Combine(directoryPath, newDirectoryName));
            }

            RenameFiles(directoryPath, oldName, newName);
        }

        private static void RenameFiles(string directoryPath, string oldName, string newName)
        {
            Check.ArgumentIsNullOrWhiteSpace(directoryPath, nameof(directoryPath));
            Check.Argument(Directory.Exists(directoryPath), "Directory.Exists(directoryPath)");
            Check.ArgumentIsNullOrWhiteSpace(oldName, nameof(oldName));
            Check.ArgumentIsNullOrWhiteSpace(newName, nameof(newName));

            foreach (var file in Directory.GetFiles(directoryPath))
            {
                var oldFileName = Path.GetFileName(file);
                var newFileName = oldFileName.Replace(oldName, newName);
                if (oldFileName != newFileName)
                    File.Move(file, Path.Combine(directoryPath, newFileName));
            }
        }

        private static void UpdateTextInAllFiles(string directoryPath, string oldText, string newText)
        {
            Check.ArgumentIsNullOrWhiteSpace(directoryPath, nameof(directoryPath));
            Check.Argument(Directory.Exists(directoryPath), "Directory.Exists(directoryPath)");
            Check.ArgumentIsNullOrWhiteSpace(oldText, nameof(oldText));
            Check.ArgumentIsNullOrWhiteSpace(newText, nameof(newText));

            foreach (var directory in Directory.GetDirectories(directoryPath))
            {
                UpdateTextInAllFiles(directory, oldText, newText);

                ReplaceTextInFiles(directory, oldText, newText);
            }

            ReplaceTextInFiles(directoryPath, oldText, newText);
        }

        private static void ReplaceTextInFiles(string directoryPath, string oldText, string newText)
        {
            Check.ArgumentIsNullOrWhiteSpace(directoryPath, nameof(directoryPath));
            Check.Argument(Directory.Exists(directoryPath), "Directory.Exists(directoryPath)");
            Check.ArgumentIsNullOrWhiteSpace(oldText, nameof(oldText));
            Check.ArgumentIsNullOrWhiteSpace(newText, nameof(newText));

            foreach (var file in Directory.GetFiles(directoryPath))
            {
                var oldFileText = File.ReadAllText(file);
                var newFileText = oldFileText.Replace(oldText, newText);
                if (oldFileText != newFileText)
                    File.WriteAllText(file, newFileText);
            }
        }
    }
}
