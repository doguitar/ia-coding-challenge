namespace iACodingChallenge.Library
{
    public class Location
    {
        public Coordinate Coordinate { get; }

        public Facility Facility{ get; }

        public Location(Coordinate coordinate, Facility facility)
        {
            Coordinate = coordinate;
            Facility = facility;
        }
    }
}
