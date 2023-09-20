public class Item
{


    public string ID { get; set; } = "NULL";
    public string name { get; set; } = "NULL";
    public string producer { get; set; } = "NULL";
    public double price { get; set; } = 0.0f;
    public string note { get; set; } = "NULL";

    public Item()
    {
        
    }
    public Item(string ID, string name, string producer, double price, string note)
    {
        this.ID = ID;
        this.name = name;
        this.producer = producer;
        this.price = price;
        this.note = note;
    }

    public void GetDataFormBinaryFile(BinaryReader reader){
        this.ID = reader.ReadString();
        this.name = reader.ReadString();
        this.producer = reader.ReadString();
        this.price = reader.ReadDouble();
        this.note = reader.ReadString();
    }

    public override string ToString()
    {
        return $"ID: {ID} | name: {name} | producer: {producer} | price: {price} | note: {note}";
    }
}