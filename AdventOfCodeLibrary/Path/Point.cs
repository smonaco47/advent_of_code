namespace AdventOfCodeLibrary.Path
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            var point = (Point) obj;
            if (point == null) return false;
            return this.X== point.X && this.Y== point.Y;
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode();
        }
    }
}
