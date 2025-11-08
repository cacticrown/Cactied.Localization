namespace Cactied.Localization;

public class Localization
{
    /// <summary>
    /// Stores the language code (e.g., "en-US", "de").
    /// </summary>
    public string Language;

    public string? FallbackLanguage;

    /// <summary>
    /// Stores the translations as key-value pairs.
    /// </summary>
    public Dictionary<string, string> Translations;

    public Localization(string language, string? fallbackLanguage, Dictionary<string, string> translations)
    {
        Language = language;
        FallbackLanguage = fallbackLanguage;
        Translations = translations;
    }

    /// <summary>
    /// Returns the translation for the given key, or null if not found. This does not support fallback to other languages. For that, use <see cref="LocalizationManager" /> instead.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string? GetTranslation(string key) => Translations.GetValueOrDefault(key, null);
}
