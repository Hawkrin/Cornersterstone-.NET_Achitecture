# Reflektion: Modulär Skadeanmälningsapplikation

**Namn: Malcolm Liljedahl**  
**Datum: 25-10-29**  
**GitHub-repo: https://github.com/Hawkrin/Cornersterstone-.NET_Achitecture**

---

## Syfte med denna reflektion

Vi går igenom alla lösningar tillsammans under uppföljningen, men den djupaste lärdomen sker när du själv artikulerar dina tankar. Dessa frågor är tänkta som förberedelse för diskussionen - och för din egen förståelse.

---

## 1. Arkitektoniska val

**Hur designade du domain-modellerna och varför?**

_Arv? Composition? Rich models eller anemic? Ge ett konkret exempel och resonera kring trade-offs._

Jag använde arv för att skapa en gemensam basmodell (Claim) och lät specifika skadetyper (VehicleClaim, PropertyClaim, TravelClaim) ärva från denna. Modellerna är relativt "anemiska" – de innehåller endast data, medan affärslogik ligger i services. Trade-off: Arv ger enkelhet och gemensamma fält, men kan bli stelt vid komplexa domänregler. Komposition hade gett mer flexibilitet vid t.ex. delade egenskaper mellan skadetyper.

---

**Var placerade du affärsreglerna?**

_I domain entities? I service? Båda? Beskriv en affärsregel och motivera var den ligger._

Affärsreglerna ligger i services, t.ex. VehicleClaimService och TravelClaimService. Exempel: "Reseskador måste rapporteras inom 14 dagar efter hemkomst" hanteras i TravelClaimService.ApplyBusinessRules. Motivering: Det ger separation av concerns och gör reglerna testbara och enkla att ändra utan att röra domänmodellerna.

---

**Beskriv ett arkitektoniskt beslut du är nöjd med - och ett du skulle ändra.**

_Vad funkade bra? Vad blev "code smell"? Vad lärde du dig?_

**Nöjd med:**  
Att affärsreglerna ligger i services och att domänmodellerna är rena och enkla.

**Skulle ändra:**  
Jag skulle införa mer komposition i modellerna och använda mer interfaces för att undvika tight coupling. Vissa valideringsattribut är svåra att återanvända och kan bli svåra att underhålla.

---

## 2. SOLID & Design Patterns

**Välj 2-3 SOLID-principer och ge konkreta exempel från din kod.**

_Följer du principen? Bryter du mot den? Varför blev det så? Inget svar är "fel" - vi vill höra ditt resonemang._

[ Ditt svar här ]

•	Single Responsibility: Services har ansvar för affärsregler, modeller för data.
•	Open/Closed: Det är enkelt att lägga till nya skadetyper utan att ändra befintlig kod, tack vare arv och interface.
•	Dependency Inversion: DI används konsekvent, t.ex. IClaimService, vilket gör det enkelt att byta implementation.

---

**Hur enkelt är det att lägga till en 4:e skadetyp?**

_Vilka filer behöver ändras? Vilka kan förbli oförändrade? Är systemet "open for extension"?_

[ Ditt svar här ]

Det är enkelt – skapa en ny klass som ärver från Claim, lägg till en ny service och uppdatera enum och UI-komponenter. Övriga delar kan förbli oförändrade. Systemet är "open for extension".

---

## 3. Dependency Injection & Interfaces

**Motivera dina DI lifestyle-val (Scoped/Singleton/Transient).**

[ Din motivering här ]

Services är Scoped för att hantera per-request state, repository är Singleton för in-memory data. Det ger enkelhet och prestanda i en demo-app.

---

**Hur många interfaces skapade du? Varför just det antalet?**

_Generisk IRepository<T>? Specifika per entity? Inget interface alls? Resonera kring för mycket vs för lite abstraktion._

[ Ditt svar här ]

Jag skapade ett interface per service och repository. Det ger lagom abstraktion och gör det enkelt att byta implementation eller mocka vid testning. För mycket abstraktion kan bli överdrivet, men här är det balanserat.

---

## 4. Blazor & UI

**Hur löste du conditional rendering och state management?**

_Beskriv din approach. Vad funkade bra? Vad blev krångligt?_

[ Ditt svar här ]

Jag använde Blazors inbyggda conditional rendering (if-satser) och enkla booleans för state, t.ex. isEditMode. Det fungerar bra för mindre appar, men kan bli krångligt vid komplexa flöden.

---

## 5. Lärdomar & Transferability

**Vad är den viktigaste insikten från denna övning?**

_Något som utmanade dina tidigare antaganden? Något du kommer tänka på annorlunda framöver?_

[ Ditt svar här ]

Vikten av att separera affärsregler från domänmodeller och att använda DI och interfaces för testbarhet och flexibilitet.

**Om du började om från scratch imorgon - vad skulle du göra annorlunda?**

_Arkitektur? Approach? Något du lärde dig för sent?_

[ Ditt svar här ]

Jag skulle införa mer komposition, kanske för ett objekt "ClaimDetails" eller liknande och eventuellt använda ett mer avancerat state management-bibliotek för UI.

---

## 6. Testbarhet & Underhållbarhet

**Hur testbar är din lösning?**

_Teoretiskt - hur enkelt skulle det vara att skriva unit tests för affärsreglerna? Vad är enkelt? Vad är svårt?_

[ Ditt svar här ]

Affärsreglerna i services är enkla att unit-testa tack vare interfaces och ren separation. Valideringsattribut är svårare att testa isolerat, men det är möjligt.

---

**Future-proofing: Hur enkelt är det att byta till SQL?**

_Testa din hypotes: vilka filer behöver ändras? Är din arkitektur flexibel eller tight coupled till in-memory?_

[ Ditt svar här ]

Det är enkelt – byt ut InMemoryClaimRepository mot en SQL-baserad implementation. Övriga lager påverkas inte tack vare interface och DI.

---

## 7. En sista reflektion

**Om du bara skulle ta med dig EN sak från denna övning till ditt nästa projekt - vad skulle det vara?**

[ Ditt svar här ]

Separation av affärsregler och data, och att alltid använda interfaces och DI för testbarhet och flexibilitet.

---