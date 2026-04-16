using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TokenGenerator.Models;

namespace TokenGenerator.Domain.Models
{

    public interface IAuthSettingsProvider
    {
        AppSettings Get();
    }


    public class AuthSettingsProvider : IAuthSettingsProvider

    {
        private static readonly string SettingsPath =
            Path.Combine(AppContext.BaseDirectory, "settings.json");

        public AppSettings Get()
        {
            if (!File.Exists(SettingsPath))
                return new AppSettings();

            try
            {
                var json = File.ReadAllText(SettingsPath);
                if (string.IsNullOrWhiteSpace(json))
                    return new AppSettings();

                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                return new AppSettings
                {
                    UserEmail = root.TryGetProperty("UserEmail", out var email)
                        ? email.GetString()
                        : null,

                    TenantId = root.TryGetProperty("TenantId", out var tenant)
                        ? tenant.GetString()
                        : null,

                    IsDarkTheme = root.TryGetProperty("IsDarkTheme", out var dark)
                        && dark.GetBoolean()
                };
            }
            catch
            {
                return new AppSettings();
            }
        }
    }


    }
