using System.Collections.Generic;

//TODO this whole class may be pointless
namespace Day24
{
    class Link
    {
        //private readonly Queue<Point> _path;

        //public Link()
        //{
        //    _path = new Queue<Point>();
        //}

        //public Point Start => _path.Peek();
        //public Point End { get; private set; }
        //public double Length => _path.Count;

        //public void Push(Point p)
        //{
        //    _path.Enqueue(p);
        //    End = p;
        //}

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
