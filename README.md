# Statistik-Tool WPF

Kleine Desktop-App in C# (WPF, .NET 8), die Messwerte als Tabelle und als Balkendiagramm anzeigt.
Man kann Werte mit eigener Balkenfarbe hinzufügen, Werte löschen und die Tabelle per Klick auf die Spaltenköpfe sortieren. Das Diagramm passt sich automatisch an die Fenstergröße und die Anzahl der Werte an.

## Voraussetzungen

- Windows
- Visual Studio 2022 mit „.NET-Desktopentwicklung“ (oder das .NET SDK 8 oder neuer)

## Starten

`StatistikTool.sln` in Visual Studio öffnen und mit F5 starten, oder in der Konsole:

```
dotnet run --project StatistikTool
```

Beim Start sind ein paar Testwerte geladen (aus `Model/Data.cs`). Es wird nichts gespeichert, nach einem Neustart sind wieder die Testwerte da.

## Bedienung

- **Neu** öffnet ein Fenster für Bezeichnung und Wert. Die Farbe des Balkens stellt man mit den drei Schiebereglern für Rot, Grün und Blau ein.
- **Löschen** entfernt den in der Tabelle ausgewählten Eintrag (nach Rückfrage).
- Fährt man mit der Maus über einen Balken, werden Bezeichnung und Wert angezeigt.

## Aufbau

- `Model/Data.cs` – ein Messwert (Bezeichnung, Wert, Farbe) und die Testdaten
- `ViewModel/` – `MainWindowViewModel` hält die Liste für die Tabelle (MVVM mit Databinding)
- `View/` – das Hauptfenster, dessen Diagramm im Code-Behind in `ZeichneDiagramm()` gezeichnet wird, und `NeuWindow` zum Hinzufügen
