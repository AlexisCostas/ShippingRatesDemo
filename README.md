# Shipping Rates Demo 📦💸  
_🚀 .NET MAUI • C# 12 • Shippo API (Test Mode) • EN / ES i18n_

Shipping Rates Demo is a **cross-platform mobile app** (Android · iOS · Windows · macOS) that showcases clean **MVVM architecture** and a production-ready integration with the **Shippo** shipping API.

| Feature | Status |
|---------|--------|
| 🔑 Setup screen — save your `SHIPPO_API_KEY` | ✅ |
| 🌐 Localization (English / Spanish) | ✅ |
| 🎨 Light / Dark theme switcher | ✅ |
| 📝 Create addresses (sample autofill) | ✅ |
| 📬 List addresses & quote rates | ✅ |

---

## ▶️ Quick Start

# 1) Launch the app → Setup Screen → paste your Shippo **test** key
dotnet build -t:Run -f net9.0-android

🧩 Stack & Architecture
.NET MAUI single-project solution

MVVM powered by CommunityToolkit.Mvvm

DI via MauiProgram (Microsoft Extensions)

Shippo .NET SDK 2025 – fully async

Syncfusion Toolkit (segmented theme switcher)

RESX Localization (Resources/Translates)

ShippingRatesDemo/
 ├─ ViewModels/    business & UI logic (MVVM)
 ├─ Views/         XAML pages (Setup, Main, CreateAddress, QuoteRates)
 ├─ Services/      abstraction over Shippo SDK (IShippoService)
 ├─ Resources/
 │   └─ Translates/  AppResources.resx · AppResources.es.resx
 └─ AppShell.xaml  navigation & theming

---

🛣️ Short Roadmap
Planned item	Notes
❓ FAQ Page	Quick answers, link to Shippo docs
⚙️ Settings Page	Reset / change stored API key, toggle language
📬 Complete rate-quoting flow	Enable address pickers → shipment creation
📝 Improve README	Add demo GIF & step-by-step video

<details> <summary><strong>🇪🇸 Versión en español</strong></summary>

# Demo de Tarifas de Envío 📦💸
🚀 .NET MAUI • C# 12 • Shippo API (Modo Test) • ES / EN i18n

Shipping Rates Demo es una aplicación móvil multiplataforma (Android · iOS · Windows · macOS) que demuestra una arquitectura MVVM limpia e integración lista para producción con la API de envíos Shippo.

Funcionalidad	Estado
🔑 Pantalla de Setup — guarda tu SHIPPO_API_KEY	✅
🌐 Localización (español / inglés)	✅
🎨 Selector de tema claro/oscuro	✅
📝 Crear direcciones (autocompletar de muestra)	✅
📬 Listar direcciones y cotizar envíos	✅

▶️ Prueba rápida
# 1) Abre la app → pantalla Setup → pega tu Shippo **test** key
dotnet build -t:Run -f net9.0-android

🧩 Stack y arquitectura
Proyecto único .NET MAUI

MVVM con CommunityToolkit.Mvvm

Inyección de dependencias en MauiProgram

Shippo .NET SDK 2025 — llamadas async

Syncfusion Toolkit (selector de tema)

Localización RESX (Resources/Translates)

ShippingRatesDemo/
 ├─ ViewModels/          lógica de presentación
 ├─ Views/               páginas XAML (Setup, Main, CreateAddress, QuoteRates)
 ├─ Services/            abstracción Shippo (IShippoService)
 ├─ Resources/
 │   └─ Translates/      AppResources.resx · AppResources.es.resx
 └─ AppShell.xaml        navegación & temas

🛣️ Hoja de ruta
Elemento	Nota
❓ Página FAQ	Preguntas frecuentes, enlace a docs de Shippo
⚙️ Página de ajustes	Reiniciar / cambiar API key, cambiar idioma
📬 Completar flujo de cotización	Picker de direcciones → creación de envío
📝 Mejorar README	Añadir GIF demo y video paso a paso
