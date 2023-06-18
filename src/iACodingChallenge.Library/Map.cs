namespace iACodingChallenge.Library
{
    public class Map
    {
        private Dictionary<Coordinate, Location> Locations { get; } = new Dictionary<Coordinate, Location>();
        public ushort QuadrantSizeX { get; }
        public ushort QuadrantSizeY { get; }

        public Map(ushort quadrantSize) : this(quadrantSize, quadrantSize)
        {
        }
        public Map(ushort quadrantSizeX, ushort quadrantSizeY)
        {
            QuadrantSizeX = quadrantSizeX;
            QuadrantSizeY = quadrantSizeY;
        }

        public void AddLocation(Facility facility, Coordinate coordinate)
        {
            if (Locations.ContainsKey(coordinate))
            {
                throw new ArgumentException("Duplicate coordinate");
            }
            if (Math.Abs(coordinate.X) > QuadrantSizeX || Math.Abs(coordinate.Y) > QuadrantSizeY)
            {
                throw new ArgumentException("Coordinate out of bounds");
            }

            Locations.Add(coordinate, new Location(coordinate, facility));
        }

        public List<Tuple<ushort,Facility>> GetNearestFacilites(Coordinate coordinate, ushort count)
        {
            return Locations
                .Select((kvp)=> new {distance = kvp.Key.ManhattanDistance(coordinate), Location= kvp.Value})
                .OrderBy(x=> x.distance)
                .Select(x=> new Tuple<ushort, Facility>((ushort)x.distance, x.Location.Facility))
                .Take(count)
                .ToList();
        }
    }
}