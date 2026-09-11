# Aplikacja działa pod linkiem:
http://localhost:5268/

Frontend (HTML/JS/CSS) dostępny pod `/`, API pod `/api/facts`.

## Opis
Prosta aplikacja web (.NET 10 Web API) pobierająca losowe fakty o kotach z `https://catfact.ninja/fact` i zapisująca je lokalnie do pliku `catfacts.txt` (1 linijka = 1 fakt w formacie JSON).

## Uruchomienie
```bash
dotnet run --project NetwiseApp/NetwiseApp.csproj
```

## Endpointy
- GET /api/facts - zwraca listę faktów zapisanych w pliku
- POST /api/facts - pobiera nowy fakt z catfact.ninja, dopisuje go do catfacts.txt w nowej linijce i zwraca go

## Technologie
- .NET 10, C#, ASP.NET Core Web API
- Dependency Injection (AddHttpClient<ICatFactService>, AddScoped<IFileService>)
- HTML / JS / CSS w wwwroot (serwowane przez UseDefaultFiles + UseStaticFiles)
