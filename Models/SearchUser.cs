public class SearchUser {
    public class Cache
    {
        public string status { get; set; }
        public long cached_at { get; set; }
        public long cached_until { get; set; }
    }

    public class Connections
    {
    }

    public class Data
    {
        public User user { get; set; }
    }

    public class League
    {
        public int gamesplayed { get; set; }
        public int gameswon { get; set; }
        public double? rating { get; set; }
        public string rank { get; set; }
        public double? apm { get; set; }
        public double? pps { get; set; }
        public double? vs { get; set; }
        public bool decaying { get; set; }
        public int standing { get; set; }
        public int standing_local { get; set; }
        public object prev_rank { get; set; }
        public int prev_at { get; set; }
        public object next_rank { get; set; }
        public int next_at { get; set; }
        public double? percentile { get; set; }
        public string percentile_rank { get; set; }
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
        public DateTime ts { get; set; }
        public List<object> badges { get; set; }
        public int xp { get; set; }
        public int gamesplayed { get; set; }
        public int gameswon { get; set; }
        public double gametime { get; set; }
        public string country { get; set; }
        public int supporter_tier { get; set; }
        public bool verified { get; set; }
        public League league { get; set; }
        public long avatar_revision { get; set; }
        public Connections connections { get; set; }
        public int friend_count { get; set; }
    }

}