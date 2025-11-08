namespace Cactied.Localization;

public static class LocalizationManager
{
    /// <summary>
    /// Represents a collection of localizations, where each entry maps a language code to its corresponding
    /// localization data.
    /// </summary>
    /// <remarks>The dictionary keys should be language codes (e.g., "en-US", "fr-FR"), and the
    /// values are instances of the <see cref="Localization"/> class.</remarks>
    public static Dictionary<string, Localization> Localizations = new();

    public static string DefaultFallbackLanguage = "en";

    #region Loading Localizations

    /// <summary>
    /// Loads localization data from a string.
    /// </summary>
    /// <param name="fileContent"></param>
    public static void LoadLocalizationFromString(string fileContent)
    {
        Localization localization = LocalizationParser.Parse(fileContent);
        Localizations[localization.Language] = localization;
    }

    /// <summary>
    /// Loads localization data from a file.
    /// </summary>
    /// <param name="filePath"></param>
    public static void LoadLocalizationFromFile(string filePath) => LoadLocalizationFromString(File.ReadAllText(filePath));

    /// <summary>
    /// Loads localization data from a stream.
    /// </summary>
    /// <param name="stream"></param>
    public static void LoadLocalizationFromStream(Stream stream)
    {
        var reader = new StreamReader(stream);
        LoadLocalizationFromString(reader.ReadToEnd());
    }

    #endregion

    public static string GetLocalizedString(string key, string languageCode)
    {
        if(Localizations.TryGetValue(languageCode, out var localization))
        {
            var translation = localization.GetTranslation(key);
            if(translation is not null)
            {
                return translation;
            }

            if(!string.IsNullOrEmpty(localization.FallbackLanguage) &&
               Localizations.TryGetValue(localization.FallbackLanguage, out var fallbackLocalization))
            {
                var fallbackTranslation = fallbackLocalization.GetTranslation(key);
                if(fallbackTranslation != null)
                {
                    return fallbackTranslation;
                }
            }
        }

        if (languageCode != DefaultFallbackLanguage && Localizations.ContainsKey(DefaultFallbackLanguage))
        {
            return GetLocalizedString(key, DefaultFallbackLanguage);
        }

        throw new Exception($"Translation for key \"{key}\" not found in \"{languageCode}\" or any fallback.");
    }

    public static bool TryGetLocalizedString(string key, string languageCode, out string? result)
    {
        try
        {
            string translation = GetLocalizedString(key, languageCode);
            result = translation;
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
}
