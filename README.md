# MongoDB-Klassenprojekt (Python / C#)

Dieses Projekt ist für den Informatikunterricht konzipiert und ermöglicht Schülern, praxisnah mit **MongoDB** zu arbeiten.  
Ziel ist es, schrittweise eine **konsolenbasierte CRUD-Anwendung** zu entwickeln – in **Python** oder **C#**.

---

## Lernziele

- Grundlagen von **MongoDB** verstehen (NoSQL, dokumentbasiert)
- CRUD-Operationen (Create, Read, Update, Delete) anwenden
- JSON-Dokumente lesen, schreiben und verwalten
- Eigenständiges Arbeiten mit Datenbanken aus Programmiersprachen
- Strukturierte Projektentwicklung mit wachsendem Funktionsumfang

---

## Technologien

- **MongoDB** (lokal oder über Atlas)
- Programmiersprache:  
  - **Python** (mit `pymongo`)  
  - **C#** (mit `MongoDB.Driver`)

---

## Voraussetzungen

### Python:
- Python 3.x
- Modul: `pymongo`  
  Installation:  
  ```bash
  pip install pymongo
  ```

### C#:
- .NET 6 oder höher
- NuGet-Paket: `MongoDB.Driver`

### MongoDB:
- Lokaler Server (empfohlen) oder kostenloser Account bei [MongoDB Atlas](https://www.mongodb.com/cloud/atlas)
- Optional: [MongoDB Compass](https://www.mongodb.com/try/download/compass) (GUI-Client)

---

## 🛠 Installation & Start

1. **MongoDB starten**
   - Lokal: MongoDB-Dienst aktivieren
   - Alternativ: Verbindung zu MongoDB Atlas herstellen

2. **Projektdateien klonen oder erstellen**

3. **In der Sprache deiner Wahl starten:**
   - Python:  
     ```bash
     python main.py
     ```
   - C#:  
     ```bash
     dotnet run
     ```

---

## Projektstruktur in Phasen

| Phase | Thema | Ziel |
|:-----:|:------|:-----|
| 1 | Verbindung herstellen | Verbindung zur MongoDB aufbauen |
| 2 | DB & Collection verwalten | Datenbank und Collection anlegen/auswählen |
| 3 | Dokumente einfügen | Benutzerdefinierte Daten (z. B. Name, Alter) speichern |
| 4 | Dokumente anzeigen | Alle Einträge ausgeben |
| 5 | Dokument löschen | Eintrag gezielt entfernen |
| 6 | Bonus: Menüsystem | Vollständige CRUD-App per Konsolenmenü steuern |

---
