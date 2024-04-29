using FlyweightLibrary;

namespace ConsoleApp.SizeCalculator;

public class FlyweightProvider : IProvider
{
    public long Test(string filename)
    {
        var startSize = GC.GetTotalMemory(true);

        NodesFlyweightFactory factory = new();
        
        LightElementNode html = new(factory.GetFlyweight("html"));
        LightElementNode head = new(factory.GetFlyweight("head"));
        html.AppendChild(head);
        LightElementNode title = new(factory.GetFlyweight("title"));
        head.AppendChild(title);
        title.AppendChild(new LightTextNode("Hello World!"));
        LightElementNode body = new(factory.GetFlyweight("body"));
        html.AppendChild(body);

        var firstLine = true;
        foreach (var line in File.ReadLines("../../../MobyDickBook.txt"))
        {
            if (firstLine)
            {
                firstLine = false;
                LightElementNode h1 = new(factory.GetFlyweight("h1"));
                h1.AppendChild(new LightTextNode(line));
                body.AppendChild(h1);
                continue;
            }

            if (line.StartsWith(' '))
            {
                LightElementNode quote = new(factory.GetFlyweight("blockquote"));
                quote.AppendChild(new LightTextNode(line));
                body.AppendChild(quote);
                continue;
            }

            if (line.Length == 0)
            {
                body.AppendChild(new LightElementNode(factory.GetFlyweight("br", true)));
            }
            // Chapters are longer than 20 symbols, so I decided to separate them too
            else if (line.Length < 20 || line.StartsWith("CHAPTER"))
            {
                LightElementNode h2 = new(factory.GetFlyweight("h2"));
                h2.AppendChild(new LightTextNode(line));
                body.AppendChild(h2);
            }
            else
            {
                LightElementNode p = new(factory.GetFlyweight("p"));
                p.AppendChild(new LightTextNode(line));
                body.AppendChild(p);
            }
        }
        
        var endSize = GC.GetTotalMemory(true);

        return endSize - startSize;
    }
}
