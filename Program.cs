using APD.Algorithms;
using APD.Utilities;
using System.Diagnostics;

int[] dataSets = { 1000, 5000, 10000, 50000, 100000 };

List<long> arrayAscendingDurations = new List<long>();
List<long> arrayDescendingDurations = new List<long>();
List<long> arrayRandomDurations = new List<long>();
List<string> resultsMessages = new List<string>();

string message;
Stopwatch stopwatch = new Stopwatch();

GenerateDataSet.GenerateAll(dataSets);

foreach (var i in dataSets)
{
    int[] arrayAscending = FileOperations.LoadArrayFromFile($"{i}-ascending.txt");
    int[] arrayDescending = FileOperations.LoadArrayFromFile($"{i}-descending.txt");
    int[] arrayRandom = FileOperations.LoadArrayFromFile($"{i}-random.txt");

    // ASCENDING

    stopwatch.Start();
    MergeSort.Sort(arrayAscending);
    stopwatch.Stop();

    message = $"Order: Ascending | Data Set: {i} numbers | Duration: {stopwatch.ElapsedMilliseconds}ms";
    resultsMessages.Add(message);
    Console.WriteLine(message);
    arrayAscendingDurations.Add(stopwatch.ElapsedMilliseconds);

    // DESCENDING

    stopwatch.Start();
    MergeSort.Sort(arrayDescending);
    stopwatch.Stop();

    message = $"Order: Descending | Data Set: {i} numbers | Duration: {stopwatch.ElapsedMilliseconds}ms";
    resultsMessages.Add(message);
    Console.WriteLine(message);
    arrayDescendingDurations.Add(stopwatch.ElapsedMilliseconds);

    // RANDOM

    stopwatch.Start();
    MergeSort.Sort(arrayRandom);
    stopwatch.Stop();

    message = $"Order: Random | Data Set: {i} numbers | Duration: {stopwatch.ElapsedMilliseconds}ms";
    resultsMessages.Add(message);
    Console.WriteLine(message);
    arrayRandomDurations.Add(stopwatch.ElapsedMilliseconds);
}

FileOperations.WriteResultsToFile(dataSets, arrayAscendingDurations, arrayDescendingDurations, arrayRandomDurations, resultsMessages);