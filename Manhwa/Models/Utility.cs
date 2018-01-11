using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Manhwa.Models
{
    public class Utility
    {
        private const string Host = "158.69.255.56";
        
        private static IMongoCollection<BsonDocument> Connect(string database, string collection)
        {
            var client = new MongoClient("mongodb://dba:1kEX2vhm4zisGo0TkP0jSpZpuJjdVdpN@" + Host + ":27017");
            var db = client.GetDatabase(database);
            var seriesDb = db.GetCollection<BsonDocument>(collection);

            return seriesDb;
        }

        public static Home Api()
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Manhwa", "Home");
                var projection = Builders<BsonDocument>.Projection.Exclude("_id");
                var result = Connect("home", "info").Find(filter).Project(projection).ToList();
                var list = JsonConvert.DeserializeObject<Home>(result[0].ToString());
                return list;
            }
            catch (Exception)
            {
                return new Home();
            }
        }

        public static SeriesInfo Api(string series)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Url", series);
                var projection = Builders<BsonDocument>.Projection.Exclude("_id");
                var result = Connect("series", series).Find(filter).Project(projection).ToList();
                var list = JsonConvert.DeserializeObject<SeriesInfo>(result[0].ToString());
                return list;
            }
            catch (Exception)
            {
                return new SeriesInfo();
            }
        }

        public static StaffPage Staff()
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("Page", "Staff");
                var projection = Builders<BsonDocument>.Projection.Exclude("_id");
                var result = Connect("home", "staff").Find(filter).Project(projection).ToList();
                var list = JsonConvert.DeserializeObject<StaffPage>(result[0].ToString());
                return list;
            }
            catch (Exception)
            {
                return new StaffPage();
            }
        }
    }

    public class Information
    {
        public string Series { get; set; }
        public string Author { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
    }

    public class SeriesInfo
    {
        private string Url { get; set; }
        public Information Information { get; set; }
        public List<string> Prologue { get; set; }
        public List<List<string>> Chapter { get; set; }
        public List<string> Dates { get; set; }
    }


    public class Latest
    {
        public List<string> Series { get; set; }
        public List<int> ChapterNumber { get; set; }
        public List<string> Dates { get; set; }
    }

    public class Home
    {
        private string Manhwa { get; set; }
        public Latest Latest { get; set; }
        public List<string> Featured { get; set; }
        public List<string> Images { get; set; }
        public List<string> Colors { get; set; }
    }

    public class StaffPage
    {
        public string Page { get; set; }
        public string Banner { get; set; }
        public List<List<string>> Staff { get; set; }
    }
}