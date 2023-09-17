using System.Xml;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Book[] books = new Book[3];

        Book b0 = new Book();
        b0.title = "Sach nau an";
        b0.price = 500.0f;
        books[0] = b0;

        Book b1 = new Book();
        b1.title = "Sach the thao";
        b1.price = 250.0f;
        books[1] = b1;

        Book b2 = new Book();
        b2.title = "Tap chi";
        b2.price = 120.0f;
        books[2] = b2;

        foreach (Book book in books)
        {
            WriteToFile(book);
        }
        ReadFromFile("book.xml");
    }

    static void ReadFromFile(string path)
    {
        XmlTextReader reader = new XmlTextReader(path);

        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case XmlNodeType.Element:
                    Console.Write("<" + reader.Name);
                    Console.WriteLine(">");
                    break;
                case XmlNodeType.Text:
                    Console.WriteLine(reader.Value);
                    break;
                case XmlNodeType.EndElement:
                    Console.Write("</" + reader.Name);
                    Console.WriteLine(">");
                    break;
            }
        }
    }

    static void WriteToFile(Book book)
    {
        XDocument xDoc = XDocument.Load("book.xml");

        XElement newBook = new XElement("book",
                new XElement("title", book.title),
                new XElement("price", book.price.ToString()));

        xDoc.Element("bookstore").Add(newBook);
        xDoc.Save("book.xml");
    }
}
