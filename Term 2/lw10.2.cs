using System;
using System.Text.RegularExpressions;

public class FileOddNumberFilter {
    public void FilterLinesWithOddNumbers(string inputFilePath, string outputFilePath) {
        string[] lines = File.ReadAllLines(inputFilePath);
        var filteredLines = lines.Where(ContainsOddNumber).ToArray();
        File.WriteAllLines(outputFilePath, filteredLines);
    }

    private bool ContainsOddNumber(string line) {
        foreach (Match match in Regex.Matches(line, @"\d+")) {
            if (long.TryParse(match.Value, out long number) && number % 2 != 0) {
                return true;
            }
        }
        return false;
    }
}

class Peogram {
    static void Main() {
        var filter = new FileOddNumberFilter();
        filter.FilterLinesWithOddNumbers("input.txt", "output.txt");
    }
}