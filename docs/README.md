# Shipping Rates Demo 📦💸  <a id="#shipping-rates-demo-📦💸"></a>
_🚀 .NET MAUI • C# 12 • Shippo API (Test Mode) • EN / ES i18n_

Shipping Rates Demo is a **cross‑platform mobile app** (Android · iOS · Windows · macOS) that illustrates a clean **MVVM architecture** and a production‑ready integration with the **Shippo** shipping API.

| Feature | Status |
|---------|:------:|
| 🔑 Setup screen — save your `SHIPPO_API_KEY` | ✅ |
| 🌐 Localization (English / Spanish) | ✅ |
| 🎨 Light / Dark theme switcher | ✅ |
| 📝 Create addresses (sample autofill) | ✅ |
| 📬 List addresses & quote rates | ✅ |

---

## 📚 Table of Contents
1. [Quick Start](#quick-start)
2. [Stack & Architecture](#stack--architecture)
3. [Short Roadmap](#short-roadmap)
4. [Resources](#resources)
5. [Versión en español](#versión-en-español)

---

## ▶️ Quick Start <a id="quick-start"></a>

0. **Get a Shippo test API key** — sign up free and copy your *test* token from the dashboard.  
   [Getting started & authentication →](https://docs.goshippo.com/docs/guides_general/authentication/)
   
```bash
# 1) Build & run the app    ──► choose the target you need
#
#    Android example
dotnet build -t:Run -f net9.0-android

#    iOS (simulator) example
dotnet build -t:Run -f net9.0-ios

#    Windows example
dotnet build -t:Run -f net9.0-windows10.0.19041.0

```     

2. **Launch the app** – you’ll land on the Setup screen.

3. **Paste your Shippo test API** key and **tap Save**.

4. If you use a shared test key it may already contain addresses**; on each device **you can still create up to 5 additional addresses** (remove & reinstall the app to reset the limit).

5. After at least two addresses exist, **open Quote Rates**:

6. **Select** “From” / “To” in the pickers,

7. **Press Get Rates** to retrieve live shipping **prices in test mode**.

8. (Optional) **Change the theme** switcher in Main page’s bottom-right corner.

---

## 🧩 Stack & Architecture <a id="stack--architecture"></a>

* **.NET MAUI** single‑project solution  
* **MVVM** powered by `CommunityToolkit.Mvvm`  
* Dependency Injection via **MauiProgram** (`Microsoft.Extensions.*`)  
* **Shippo .NET SDK 2025** – fully `async`  
* **Syncfusion Toolkit** – segmented theme switcher  
* **RESX** localization under `Resources/Translates`

```
ShippingRatesDemo/
 ├─ ViewModels/          business & UI logic (MVVM)
 ├─ Views/               XAML pages (Setup, Main, CreateAddress, QuoteRates)
 ├─ Services/            abstraction over Shippo SDK (IShippoService)
 ├─ Resources/
 │   └─ Translates/      AppResources.resx · AppResources.es.resx
 └─ AppShell.xaml        navigation & theming
```

---

## 📚 Resources <a id="resources"></a>
- 📖 **Shippo Docs** — Official API reference  
  <https://docs.goshippo.com/>

---

## 🛣️ Short Roadmap <a id="short-roadmap"></a>

| Planned Item | Notes |
|--------------|-------|
| ❓ **FAQ Page** | Quick answers, link to Shippo docs |
| ⚙️ **Settings Page** | Reset / change stored API key, toggle language |
| 📬 Complete rate‑quoting flow | Enable address pickers → shipment creation |
| 🎞️ Improve README | Add demo GIF & step‑by‑step video |
| 🛠️ **CI / CD & DevOps** | GitHub Actions build pipeline → automatic MAUI builds & APK / IPA artifacts |

---

## 🇪🇸 Versión en español <a id="versión-en-español"></a>
<details>
<summary><strong>Mostrar / Ocultar</strong></summary>

### Demo de Tarifas de Envío 📦💸  
_🚀 .NET MAUI • C# 12 • Shippo API (Modo Test) • ES / EN i18n_

Shipping Rates Demo es una **app móvil multiplataforma** (Android · iOS · Windows · macOS) que muestra una arquitectura **MVVM** limpia e integración lista para producción con la API de envíos **Shippo**.

| Funcionalidad | Estado |
|---------------|:------:|
| 🔑 Pantalla de Setup — guarda tu `SHIPPO_API_KEY` | ✅ |
| 🌐 Localización (español / inglés) | ✅ |
| 🎨 Selector de tema claro / oscuro | ✅ |
| 📝 Crear direcciones (autocompletado de muestra) | ✅ |
| 📬 Listar direcciones y cotizar envíos | ✅ |

---

## 📚 Índice
1. [Prueba rápida](#prueba-rápida)
2. [Stack y arquitectura](#stack-y-arquitectura)
3. [Hoja de ruta](#hoja-de-ruta-breve)
4. [Recursos](#recursos)
5. [Versión en inglés](#shipping-rates-demo-📦💸)

---

### ▶️ Prueba rápida <a id="#prueba-rápida"></a>

0. **Obtén tu clave API de pruebas de Shippo** — regístrate gratis y copia tu token *test* desde el panel.  
   [Guía de autenticación →](https://docs.goshippo.com/docs/guides_general/authentication/)

```bash
# 1) Compila y ejecuta la app  ──► elige la plataforma
#
#    Ejemplo Android
dotnet build -t:Run -f net9.0-android

#    Ejemplo iOS (simulador)
dotnet build -t:Run -f net9.0-ios

#    Ejemplo Windows
dotnet build -t:Run -f net9.0-windows10.0.19041.0

```

2. **Inicia la aplicación** – llegarás a la pantalla **Setup**.  
3. **Pega tu clave API de pruebas de Shippo** y pulsa **Save**.  
4. Si utilizas una clave de prueba compartida es posible que ya contenga direcciones; en cada dispositivo **aún puedes crear hasta 5 direcciones adicionales** (desinstala y vuelve a instalar la app para restablecer el límite).  
5. Cuando existan al menos dos direcciones, **abre _Quote Rates_**:  
6. **Selecciona** “From” / “To” en los pickers.  
7. Pulsa **Get Rates** para obtener precios de envío en **modo test** en tiempo real.  
8. _(Opcional)_ **Cambia el tema** claro/oscuro con el selector en la esquina inferior derecha de la página **Main**.  

---

### 🧩 Stack y arquitectura <a id="#stack-y-arquitectura"></a>

* Proyecto único **.NET MAUI**  
* Patrón **MVVM** con `CommunityToolkit.Mvvm`  
* Inyección de dependencias en **MauiProgram**  
* **Shippo .NET SDK 2025** — llamadas `async`  
* **Syncfusion Toolkit** (selector de tema)  
* Localización **RESX** (`Resources/Translates`)

```
ShippingRatesDemo/
 ├─ ViewModels/          lógica de presentación
 ├─ Views/               páginas XAML (Setup, Main, CreateAddress, QuoteRates)
 ├─ Services/            abstracción Shippo (IShippoService)
 ├─ Resources/
 │   └─ Translates/      AppResources.resx · AppResources.es.resx
 └─ AppShell.xaml        navegación & temas
```

---

## 📚 Recursos <a id="recursos"></a>
- 📖 **Documentación de Shippo** — Referencia oficial de la API  
  <https://docs.goshippo.com/>

---

### 🛣️ Hoja de ruta breve <a id="#hoja-de-ruta-breve"></a>

| Elemento | Nota |
|----------|------|
| ❓ **Página FAQ** | Preguntas frecuentes + enlace a docs de Shippo |
| ⚙️ **Página de ajustes** | Reiniciar / cambiar API key, cambiar idioma |
| 📬 Completar flujo de cotización | Picker de direcciones → creación de envío |
| 📝 Mejorar README | Añadir GIF demo y video paso a paso |
| 🛠️ **CI / CD & DevOps** | Pipeline con GitHub Actions → compilación automática MAUI y generación de APK / IPA |

</details>
