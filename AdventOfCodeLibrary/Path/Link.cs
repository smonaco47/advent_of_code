namespace AdventOfCodeLibrary.Path
{
    public class Link
    { 

        public Point Start { get; }
        public Point End { get; }
        public int Length { get; set; }

        public Link(Point start, Point end, int length)
        {
            this.Start = start;
            this.End = end;
            this.Length = length;
        }


        public override bool Equals(object obj)
        {
            var link = (Link)obj;
            if (link == null) return false;
            return this.Start == link.Start && this.End == link.End;
        }

        public override int GetHashCode()
        {
            return this.Start.GetHashCode() + this.End.GetHashCode();
        }
    }
}
