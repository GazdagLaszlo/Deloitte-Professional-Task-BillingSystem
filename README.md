# Egyszerű Számlázó Rendszer (Deloitte tesztfeladat)

Ez a repository egy egyszerű számlázó rendszer backend megvalósítását tartalmazza. A rendszer célja termékek, ügyfelek és rendelések tárolása, kezelése, valamint ezek alapján számladokumentumok előállítása.

A projekt a feladatkiírásnak megfelelően nyitott végű problémákra is saját, indokolt megoldásokat alkalmaz a karbantarthatóság és a skálázhatóság érdekében.

## Alkalmazott technológiák

*   **.NET (C#)**
*   **Entity Framework Core**
*   **MS SQL Server**
*   **AutoMapper**
*   **Swagger (OpenAPI)**

## Architektúra és főbb döntések

A rendszer tervezése során a Clean Architecture elveit követtem:

*   **Rétegek szétválasztása:** A projekt logikailag elkülönül adatelérési (`DataContext`) és üzleti logikai (`Services`) modulokra.
*	**DTO (Data Transfer Object):** Az adatbázis-entitások és az API kommunikáció szétválasztására, a belső adatszerkezet elrejtésére a kliensek elől.
*   **Termékek árazása:** A rendelés leadásakor a rendszer az adott pillanatban érvényes termékárat menti el az `OrderItems` táblába. Így egy jövőbeni árváltozás nem módosítja visszamenőleg a már kiállított számlák végösszegét.
*   **Végösszeg automatikus számítása:** A számla végösszegét (`TotalAmount`) a rendszer az üzleti logikában dinamikusan számítja a megrendelt tételek és az elmentett egységárak alapján.
*	**Adatkezelési végpontok:** Mivel a rendelések leadásához szükséges termék és ügyfél megléte a rendszerben, ezek létrehozására végpontokat implementáltam.

## Telepítés és Futtatás

Első indításkor a migrációk automatikusan létrehozzák az adatbázist. 

### 1. Opció: Visual Studio / IDE
1. Nyisd meg a `Deloitte_prof_task_Laszlo_Gazdag.slnx` fájlt Visual Studio-ban.
2. Nyisd meg a **Package Manager Console** ablakot (`Tools` -> `NuGet Package Manager` -> `Package Manager Console`).
3. Válaszd ki a `Default project` legördülőben a DataContext réteget.
4. Futtasd az alábbi parancsot:
   ```powershell
   update-database
   ```
5. Indítsd el az alkalmazást a Visual Studioban (F5). 
   
### 2. Opció: Entity Framework parancssori eszköz
Nyiss egy parancssort a repository gyökerében, majd futtasd az alábbi parancsokat:

```bash
cd Deloitte_prof_task_Laszlo_Gazdag
dotnet restore
dotnet ef database update --project Deloitte_prof_task_Laszlo_Gazdag.DataContext
dotnet run
```

## Tesztelés:
A böngészőben automatikusan megnyílik a Swagger UI, ahol a létrehozott végpontok azonnal tesztelhetők.

## Kapcsolódó SQL Szkriptek

A feladatleírásban kért egyedi adatbázis-lekérdezések és az adatbázis-sémát legeneráló SQL szkript a repository gyökerében található a `Scripts` mappában.

---
*Köszönöm a kód átnézésére szánt időt!*