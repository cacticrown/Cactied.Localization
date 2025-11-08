namespace Cactied.Localization.Test;

internal class Program
{
    static void Main(string[] args)
    {
        LocalizationManager.LoadLocalizationFromFile("Translations/en.clf");
        LocalizationManager.LoadLocalizationFromFile("Translations/de.clf");

        // Localizations can also be loading in code
        LocalizationManager.AddLocalization("en-uk", new Localization("en-uk", "en", new Dictionary<string, string>
        {
            {"menu.play", "Wanna play mate?" },
            {"menu.quit", "Why you wanna quit mate?" },
            {"dialog.welcome", "Welcome to great britain mate!" },
        }));

        Console.WriteLine("en: " + LocalizationManager.GetLocalizedString("dialog.welcome", "en"));
        Console.WriteLine("en-uk: " + LocalizationManager.GetLocalizedString("dialog.welcome", "en-uk")); 
        Console.WriteLine("de: " + LocalizationManager.GetLocalizedString("dialog.welcome", "de")); // this will print "Welcome to the game!", because german doesn't implement dialog.welcome and has a fallback to english
        Console.ReadKey();
    }
}