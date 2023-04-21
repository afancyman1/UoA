// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Linq;
using System.Text;
Console.WriteLine("Hello, World!");


string folderPath = @"C:\Users\hliu825\Downloads\test";
string outputFilePath = Path.Combine(folderPath, "output.txt");

if (Directory.Exists(folderPath))
{
    try
    {
        string[] inputFiles = Directory.GetFiles(folderPath)
                                        .Select(file => new
                                        {
                                            FileName = file,
                                            FileNumber = int.Parse(Path.GetFileNameWithoutExtension(file).Split('_')[1])
                                        })
                                        .OrderBy(file => file.FileNumber)
                                        .Select(file => file.FileName)
                                        .ToArray();

        StringBuilder fileContentBuilder = new StringBuilder();

        foreach (string inputFile in inputFiles)
        {
            string fileContent = File.ReadAllText(inputFile);
            fileContentBuilder.Append(fileContent);
        }

        File.WriteAllText(outputFilePath, fileContentBuilder.ToString());
        Console.WriteLine("Files have been combined and saved to output.txt.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
else
{
    Console.WriteLine("Error: Folder not found.");
}