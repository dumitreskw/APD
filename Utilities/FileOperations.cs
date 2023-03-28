namespace APD.Utilities;

public class FileOperations
{
    public static void WriteArrayToFile(string fileName, int length, int[] array)
    {
        string relativePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));
        string filePath = Path.Combine(relativePath,"DataSets", fileName);

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < length; i++)
            {
                writer.WriteLine(array[i]);
            }
        }
    }

    public static int[] LoadArrayFromFile(string fileName)
    {
        string relativePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));
        string filePath = Path.Combine(relativePath, "DataSets", fileName);

        List<int> list = new List<int>();
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int value = int.Parse(line);
                list.Add(value);
            }
        }

        return list.ToArray();
    }

    public static void WriteResultsToFile(int[] dataSets, List<long> ascending, List<long> descending, List<long> random, List<string> results)
    {
        var timeNow = DateTime.Now.ToString("dd.MM.yyyy");
        string relativePath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.Ordinal));
        string filePath = Path.Combine(relativePath, "Results", $"Results {timeNow}.txt");

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Logs:");
            foreach(var message in results)
            {
                writer.WriteLine(message);
            }

            var i = 0;
            writer.WriteLine("\n\nComparison Table:\nDataSet\tAscending (ms)\tDescending (ms)\tRandom (ms)");
            foreach (var data in dataSets)
            {
                var message = $"{data}\t{ascending[i]}\t{descending[i]}\t{random[i]}";
                writer.WriteLine(message);
                i++;
            }
        }
    }
}
