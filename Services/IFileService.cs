using System;
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
    private static string FilePath => Path.Combine(DataDirectory, "stock.json");

    private static string DataDirectory =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "paints");
    
    public async Task SavePaintList(PaintList list)
    {
        EnsureDirectoryExists();
        
        await using var fileStream = File.Create(FilePath);
        
        await JsonSerializer.SerializeAsync<PaintList>(fileStream, list);
    }

    public async Task<PaintList?> LoadPaintList()
    {
        EnsureDirectoryExists();

        if (!File.Exists(FilePath))
            return null;
        
        await using var fileStream = File.Create(FilePath);
        var value = await JsonSerializer.DeserializeAsync<PaintList>(fileStream);

        return value;
    }

    private static void EnsureDirectoryExists()
    {
        if (!Directory.Exists(DataDirectory))
            Directory.CreateDirectory(DataDirectory);
    }
}