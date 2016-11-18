using System.Threading.Tasks;

namespace eXam
{
    public interface IFileHelper
    {
        Task<string> LoadLocalFileAsync(string filename);
        Task<bool> SaveLocalFileAsync(string filename, string data);

        string GetNameWithPath(string filename);
    }
}
