using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Paints.Models;

namespace Paints.Services;

public interface IFileService
{
    public Task SavePaintList(PaintList list);
    public Task<PaintList?> LoadPaintList();
}

public class FileService : IFileService
{
    public string FilePath => "~/.local/share/paints.json";

    public async Task SavePaintList(PaintList list)
    {
        await using var fileStream = File.Create(FilePath);
        
        await JsonSerializer.SerializeAsync<PaintList>(fileStream, list);
    }

    public async Task<PaintList?> LoadPaintList()
    {
        await using var fileStream = File.Create(FilePath);
        var value = await JsonSerializer.DeserializeAsync<PaintList>(fileStream);

        return value;
    }
}