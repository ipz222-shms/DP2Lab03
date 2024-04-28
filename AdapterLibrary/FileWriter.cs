namespace AdapterLibrary;

public class FileWriter
{
    public void Write(string fileName, string text)
    {
        using StreamWriter sw = File.AppendText(fileName);
        sw.Write(text);
    }

    public void WriteLine(string fileName, string text)
    {
        using StreamWriter sw = File.AppendText(fileName);
        sw.WriteLine(text);
    }
}
