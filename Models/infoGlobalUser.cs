public class InfoGlobal{
    public class Cache
    {
        public string status { get; set; }
        public long cached_at { get; set; }
        public long cached_until { get; set; }
    }

    public class Data
    {
        public int usercount { get; set; }
        public double usercount_delta { get; set; }
        public int anoncount { get; set; }
        public int totalaccounts { get; set; }
        public int rankedcount { get; set; }
        public int replaycount { get; set; }
        public int gamesplayed { get; set; }
        public double gamesplayed_delta { get; set; }
        public int gamesfinished { get; set; }
        public double gametime { get; set; }
        public long inputs { get; set; }
        public long piecesplaced { get; set; }
    }

    public class Root
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public Cache cache { get; set; }
    }

}
