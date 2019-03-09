class Position
{
    public Position(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }

    public int Row { get; }

    public int Col { get; }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as Position);
    }

    private bool Equals(Position other)
    {
        return other != null &&
            this.Row == other.Row &&
            this.Col == other.Col;
    }

    public override int GetHashCode()
    {
        return this.Row ^ this.Col;
    }
}