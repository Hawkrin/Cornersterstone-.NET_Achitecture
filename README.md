# Projektarkitektur och Valda Bibliotek

## Översikt

Detta projekt är en modern Blazor-applikation för hantering av skadeärenden (claims). Applikationen är uppdelad i tydliga lager enligt best practices för skalbarhet, testbarhet och vidareutveckling.

---

## Arkitektur

```text
MyClaimApp/
├── Application/
│   ├── Interfaces/            # Tjänste- och repositorygränssnitt
│   └── Services/              # Implementering av tjänster (affärslogik)
├── Domain/
│   ├── Enums/                 # Enum-typer för domänen
│   ├── Models/                # Domänmodeller
│   └── Validation/            # Valideringsklasser
├── Infrastructures/
│   └── Repositories/          # Implementering av datalager
├── Pages/
│   ├── Components/            # Återanvändbara Blazor-komponenter
│   ├── Utils/                 # Hjälpklasser för UI
│   ├── ClaimDetail.razor      # Detaljsida för skadeärende
│   ├── ClaimList.razor        # Lista över skadeärenden
│   ├── CreateClaim.razor      # Skapa nytt skadeärende
│   └── Index.razor            # Startsida
├── Resources/
│   ├── Countries.resx         # Länder (lokalisering)
│   ├── ErrorMessages.resx     # Felmeddelanden (lokalisering)
│   └── ResourceStrings.resx   # Övriga strängar (lokalisering)
├── Shared/
│   ├── MainLayout.razor       # Huvudlayout för Blazor
│   ├── NavMenu.razor          # Navigationsmeny
│   └── _Imports.razor         # Globala using-satser för Razor
├── wwwroot/                   # Statiska filer (CSS, JS, bilder)
├── appsettings.json           # Konfigurationsfil
└── Program.cs                 # Applikationens startpunkt
```

Projektet är organiserat enligt följande lager och mappar:

- **Application**
  - *Interfaces*: Definitioner för tjänster och repositorys (t.ex. `IClaimService`, `IClaimRepository`)
  - *Services*: Implementering av affärslogik och tjänster (t.ex. `ClaimService`)
- **Domain**
  - *Enums, Models, Validation*: Domänmodeller, enum-typer och valideringsregler
- **Infrastructures**
  - *Repositories*: Implementering av datalager, t.ex. in-memory repository
- **Pages/Components**
  - Blazor-komponenter för användargränssnittet
- **Resources**
  - Resursfiler för lokalisering och felmeddelanden
- **Shared**
  - Delade komponenter/layouts

### Flöde

1. **UI (Blazor-komponenter)** anropar tjänster via dependency injection.
2. **Services** hanterar affärslogik och validering.
3. **Repositories** sköter dataåtkomst.
4. **Domänmodeller och validering** ligger i Domain-lagret.

---

## Valda Bibliotek

### FluentValidation

**Syfte:**  
Definiera och applicera valideringsregler på domänmodeller på ett tydligt och återanvändbart sätt.

**Varför:**  
- Separera valideringslogik från modeller och UI.
- Stöd för komplexa regler och cross-property validering.
- Lätt att testa och underhålla.

---

### FluentValidation.Blazored

**Syfte:**  
Integrera FluentValidation med Blazors formulärhantering.

**Varför:**  
- Automatisk validering i Blazor EditForms.
- Visar valideringsfel direkt i UI:t utan extra kod.

---

### FluentResults

**Syfte:**  
Standardisera hanteringen av resultat och fel från tjänster och repositorys.

**Varför:**  
- Tydlig separation mellan lyckade och misslyckade operationer utan undantag för kontrollflöde.
- Underlättar felhantering och presentation av felmeddelanden i UI:t.
- Stöd för att skicka med felkoder, meddelanden och orsaker.

---

## Sammanfattning

Denna arkitektur möjliggör:

- Tydlig separation av ansvar (UI, affärslogik, data, validering)
- Enhetlig och testbar felhantering med FluentResults
- Effektiv och återanvändbar validering med FluentValidation och Blazored
- Enkel lokalisering via resursfiler

Detta ger en robust, skalbar och underhållbar grund för vidareutveckling av applikationen.
