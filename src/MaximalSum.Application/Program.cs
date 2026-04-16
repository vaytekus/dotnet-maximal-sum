using MaximalSum.Application.Models;

namespace MaximalSum.Application;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter file name:");
        string fileName = Console.ReadLine();
        
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string pathToFile = Path.Combine(documentsPath, fileName); 
        Console.WriteLine($"The file path is: {pathToFile}");

        if (!File.Exists(pathToFile))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var result = new MaximalSumProcessor<int>(pathToFile).Process();
        Console.WriteLine($"Maximum sum row (index {result.MaxSum.RowIndex}): {result.MaxSum.Row}  →  sum = {result.MaxSum.Sum}");
        Console.WriteLine($"Wrong lines quantity: {result.WrongLinesCount}");
    }
}