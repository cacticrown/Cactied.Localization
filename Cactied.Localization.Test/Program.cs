namespace Cactied.Localization.Test;

internal class Program
{
    static void Main(string[] args)
    {
        LocalizationManager.LoadLocalizationFromFile("Translations/en.clf");
        LocalizationManager.LoadLocalizationFromFile("Translations/de.clf");

        Console.WriteLine(LocalizationManager.GetLocalizedString("dialog.welcome", "de")); // this will print "Welcome to the game!", because german doesn't implement dialog.welcome and has a fallback to english
        Console.ReadKey();
    }
}
