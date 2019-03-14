class Result
{
    public Result(int lineStart, int wordCount, double totalQuality, int lineCount)
    {
        this.LineStart = lineStart;
        this.WordCount = wordCount;
        this.TotalQuality = totalQuality;
        this.LineCount = lineCount;
    }

    public int LineStart { get; }

    public int WordCount { get; }

    public double TotalQuality { get; }

    public int LineCount { get; }

    public double AverageQuality()
    {
        return this.TotalQuality / this.LineCount;
    }
}