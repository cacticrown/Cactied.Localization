namespace Cactied.Localization;

public static class LocalizationParser
{
    /// <summary>
    /// Returns a <see cref="Localization"/> from a toml-like string.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static Localization Parse(string content)
    {
        string lang = string.Empty;
        string ?fallbackLang = null;
        Dictionary<string, string> translations = new();

        string? section = null;

        using (var reader = new StringReader(content))
        {
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                line = line.Trim();
                if (line.Length == 0) continue;

                // skip comments
                if (line.StartsWith("#"))
                {
                    continue;
                }

                // sections
                if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    section = line[1..^1].ToLowerInvariant();
                    continue;
                }

                var sep = line.IndexOf('=');
                if (sep == -1) continue;

                var key = line[..sep].Trim();
                var val = line[(sep + 1)..].Trim().Trim('"');

                if (section == "meta" && key == "language")
                    lang = val;
                else if (section == "meta" && key == "fallback_language")
                    fallbackLang = val;
                else if (section == "translations")
                    translations[key] = val;
            }
        }


        return new Localization(lang, fallbackLang, translations);
    }
}