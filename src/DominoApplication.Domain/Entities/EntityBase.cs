using Mongo.Migration.Documents;
using Mongo.Migration.Documents.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace DominoApplication.Domain.Entities
{
    public class EntityBase : IDocument
    {
        [BsonSerializer(typeof(DocumentVersionSerializer))]
        public DocumentVersion Version { get; set; }
    }
}
