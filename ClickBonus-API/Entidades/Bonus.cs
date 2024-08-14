using MongoDB.Bson;

namespace ClickBonus_API.Entidades;

public class Bonus
{

    public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
    public int OfertaId { get; set; }
    public DateTime DataBonus { get; set; } = DateTime.Now;
}
