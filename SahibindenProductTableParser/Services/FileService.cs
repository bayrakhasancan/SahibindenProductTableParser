namespace SahibindenProductTableParser.Services;

public static class FileService
{
    public static string GetInputFilePath(string[] args)
    {
        if (args.Length > 0) return args[0];

        Console.Write("Lütfen dosya yolunu girin: ");
        var path = Console.ReadLine()?.Trim() ?? "";

        return File.Exists(path)
            ? path
            : throw new FileNotFoundException("Geçersiz dosya yolu");
    }

    public static async Task<string> ReadFileAsync(string path) =>
        await File.ReadAllTextAsync(path);
}