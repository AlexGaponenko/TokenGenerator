using System.IO;
using System.Text.Json;
using TokenGenerator.Models;

public class SettingsService
{
    private const string FilePath = "settings.json";

    public void Save(AppSettings settings)
    {
        var json = JsonSerializer.Serialize(settings);
        File.WriteAllText(FilePath, json);
    }

    public AppSettings Load()
    {
        if (!File.Exists(FilePath))
            return new AppSettings();

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<AppSettings>(json);
    }
}
