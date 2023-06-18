using System.Diagnostics.CodeAnalysis;

namespace iACodingChallenge.Library
{
    public struct Coordinate
    {
        public short X { get; }
        public short Y { get; }

        public Coordinate(short x, short y)
        {
            X = x; 
            Y = y;
        }

        public double Distance(Coordinate coordinate)
        {
            int dx = coordinate.X - X;
            int dy = coordinate.Y - Y;

            return Math.Sqrt(dx ^ 2 + dy ^ 2);
        }

        public int ManhattanDistance(Coordinate coordinate)
        {
            return Math.Abs(coordinate.X - X) + Math.Abs(coordinate.Y - Y);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            var c = obj as Coordinate?;
            if (c != null)
            {
                return c.Value.X == X && c.Value.Y == Y;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }

        public override string ToString() { return $"({X}, {Y})"; }
    }
}
