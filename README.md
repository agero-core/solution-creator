# Solution Creator

Solution Creator is a tool for creating solutions from templates by replacing placeholders for company and application name in folder/file names and file contents.

## Usage
1. Make sure the lastest version of **.NET Core** or **.NET Framework** runtime is intalled.
2. Pull the latest **Solution Creator** version from [dist](./dist) directory.
3. Create template of directories and files and use placeholder for **company name** and **application name**. Look at example in [template](./template) directory which uses **COMP__NAME** and **APP__NAME** placeholders.
4. Run **Solution Creator** using the following command:
```
SolutionCreator company_name app_name template_dir_path [-d output_destination] [-c comp_name_placeholder] [-a app_name_placeholder]
```

**.NET Core Example:**
```
dotnet SolutionCreator.dll TestCompany TestApplication ../template -d ../test -c COMP__NAME -a APP__NAME  
```

**.NET Framework Example:**
```
SolutionCreator.exe TestCompany TestApplication ../template -d ../test -c COMP__NAME -a APP__NAME  
```

## Help
```
 -d output_destination         Directory to copy output directories and file
                               Default is current directory.

 -a app_name_placeholder       Application name placeholder which is used in
                               template. Default is 'APP__NAME'.

 -c comp_name_placeholder      Company name placeholder which is used in
                               template. Default is 'COMP__NAME'.

 --help                        Display this help screen.

 --version                     Display version information.

 company_name (pos. 0)         Required. Company name, ex. 'Agero'.

 app_name (pos. 1)             Required. Application name, ex. 'TestAPI'.

 template_dir_path (pos. 2)    Required. Solution template directory path.
```
