public class TopRank {
    public class Cache
    {
        public string status { get; set; }
        public long cached_at { get; set; }
        public long cached_until { get; set; }
    }

    public class Data
    {
        public List<User> users { get; set; }
    }

    public class League
    {
        public int gamesplayed { get; set; }
        public int gameswon { get; set; }
        public double rating { get; set; }
        public double glicko { get; set; }
        public double rd { get; set; }
        public string rank { get; set; }
        public string bestrank { get; set; }
        public double apm { get; set; }
        public double pps { get; set; }
        public double vs { get; set; }
        public bool decaying { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public Cache cache { get; set; }
    }

    public class User
    {
        public string _id { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public double xp { get; set; }
        public League league { get; set; }
        public bool supporter { get; set; }
        public bool verified { get; set; }
        public string country { get; set; }
    }
}