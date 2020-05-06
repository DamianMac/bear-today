namespace BearToday.TemplateProcessor
{
    public interface IFileSystem
    {
        bool Exists(string path);
        string Read(string path);
    }
}