using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexSearch
{
    class Apex
    {
        public Apex(string id, string ship, string rank, string name, string type, string description, string cost, string aura, string zen, string video)
        {
            Id = id;
            Ship = ship;
            Rank = rank;
            Name = name;
            Type = type;
            Description = description;
            Cost = cost;
            Aura = aura;
            Zen = zen;
            Video = video;
        }

        public string Id { get; set; }
        public string Ship { get; set; }
        public string Rank { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public string Aura { get; set; }
        public string Zen { get; set; }
        public string Video { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {9}    Ship: {0}    Rank: {1}\r\nApex Name: {2}    Type: {3}\r\nDescription: {4}\r\nCost: {5}\r\nAura: {6}    Zen: {7}\r\nVideo Link: {8}", Ship, Rank, Name, Type, Description, Cost, Aura, Zen, String.IsNullOrEmpty(Video) ? "Unavailable" : Video, Id);
        }
    }
}
