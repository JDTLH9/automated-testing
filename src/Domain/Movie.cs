using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public class Movie : IDomainEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public TimeSpan Runtime { get; set; }
        public StarRating Rating { get; set; }
    }

    public enum StarRating
    {
        NoScore,
        Awful,
        Poor,
        Average,
        Good,
        Excellent
    }
}
