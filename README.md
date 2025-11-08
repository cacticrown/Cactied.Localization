# Cactied.Localization

Cactied.Localization is a minimal, dependency-free localization library written in C#. It is designed for speed and simplicity. It was primarily made for games and is used for [A World Below](https://github.com/cacticrown/AWorldBelow-Public).

## Features

- **Lightweight and fast:** no external dependencies
- **File-based:** supports a stripped down version of the TOML format
- **Simple API for loading and retrieving translations**
- **Supports runtime language switching**
- **Optional fallback language support**

## Installation

Add the source files to your project or include it as a submodule. NuGet packaging is planned.

## File Format

Translations are stored in a simple format inspired by toml with the .clf extension:

```toml
# this is a comment

[meta]
language = "en"

[translations]
menu.play = "Play"
menu.quit = "Quit"
dialog.welcome = "Welcome to the game!"
```

## Usage

```csharp
using Cactied.Localization;

LocalizationManager.LoadLocalizationFromFile("Translations/en.clf");
LocalizationManager.LoadLocalizationFromFile("Translations/de.clf");

Console.WriteLine(LocalizationManager.GetLocalizedString("dialog.welcome", "de")); // this will print "Welcome to the game!", because german doesn't implement dialog.welcome and has a fallback to english
Console.ReadKey();
```

## License

MIT License
