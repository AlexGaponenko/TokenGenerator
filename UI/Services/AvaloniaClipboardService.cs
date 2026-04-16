
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using System.Threading.Tasks;
using TokenGenerator.Domain.Interfaces;

namespace TokenGenerator.UI.Services
{
    public class AvaloniaClipboardService : IClipboardService
    {
        public async Task SetTextAsync(string text)
        {
            if (Application.Current?.ApplicationLifetime
                is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var clipboard = desktop.MainWindow?.Clipboard;
                if (clipboard != null)
                {
                    await clipboard.SetTextAsync(text);
                }
            }
        }
    }
}
