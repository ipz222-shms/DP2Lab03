using CompositeLibrary;

namespace ConsoleApp.SizeCalculator;

public class ClassicProvider : IProvider
{
    public long Test(string filename)
    {
        var startSize = GC.GetTotalMemory(true);
        
        LightElementNode html = new("html");
        LightElementNode head = new("head");
        html.AppendChild(head);
        LightElementNode title = new("title");
        head.AppendChild(title);
        title.AppendChild(new LightTextNode("Hello World!"));
        LightElementNode body = new("body");
        html.AppendChild(body);

        var firstLine = true;
        foreach (var line in File.ReadLines("../../../MobyDickBook.txt"))
        {
            if (firstLine)
            {
                firstLine = false;
                LightElementNode h1 = new("h1");
                h1.AppendChild(new LightTextNode(line));
                body.AppendChild(h1);
                continue;
            }

            if (line.StartsWith(' '))
            {
                LightElementNode quote = new("blockquote");
                quote.AppendChild(new LightTextNode(line));
                body.AppendChild(quote);
                continue;
            }

            if (line.Length == 0)
            {
                body.AppendChild(new LightElementNode("br")
                {
                    IsSingle = true
                });
            }
            // Chapters are longer than 20 symbols, so I decided to separate them too
            else if (line.Length < 20 || line.StartsWith("CHAPTER"))
            {
                LightElementNode h2 = new("h2");
                h2.AppendChild(new LightTextNode(line));
                body.AppendChild(h2);
            }
            else
            {
                LightElementNode p = new("p");
                p.AppendChild(new LightTextNode(line));
                body.AppendChild(p);
            }
        }
        
        var endSize = GC.GetTotalMemory(true);

        return endSize - startSize;
    }
}
