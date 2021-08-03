using System;
using System.Collections.Generic;

namespace SamuraiWarehouse
{
    public class Samurai
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Quote> Quotes { get; set; }

        public List<SamuraiBattle> SamuraiBattles { get; set; }

        public SecretIdentity SecretIdentity { get; set; }

        public Samurai(List<Quote> quotes)
        {
            Quotes = quotes;
        }
    }

    public class Battle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<SamuraiBattle> SamuraiBattles { get; set; }
    }

    public class SamuraiBattle
    {
        public Battle Battle { get; set; }

        public Samurai Samurai { get; set; }
    }

    public class SecretIdentity
    {
        public int Id { get; set; }

        public string RealName { get; set; }

        public int SamuraiId { get; set; } // why not Samurai?
    }

    public class Quote
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public Samurai Samurai { get; set; }

        public int SamuraiId { get; set; }
    }
}
