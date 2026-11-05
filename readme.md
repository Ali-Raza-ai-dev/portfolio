# Ali Raza — Boring AI That Works for Real Businesses

A high-performance .NET 10 & Blazor Server implementation of [aliraza.codes](https://www.aliraza.codes/), completely redesigned with the luxury editorial aesthetic and architecture inspired by [Cogent Labs](https://cogentlabs.co/).

---

## 🎨 Cogent Labs Editorial Design System

### 1. Palette & Contrast
- **Warm Luxury Cream & Midnight Navy Rhythm**:
  - Backgrounds: Warm luxury cream (`#F9ECE0`) and parchment cream (`#F2E1D0`).
  - Deep Authority Navy: Midnight navy (`#06173A`), rich dark navy (`#12285A`), and deep footer obsidian (`#030B1E`).
  - Accents: Energetic terracotta orange (`#F29E64`) and refined powder blue (`#A8BCD2`).
  - Fine separator lines: Subtle `rgba(6,23,58,0.14)` lines on cream and `rgba(249,236,224,0.16)` on navy.

### 2. Distinctive Typography
- **Editorial Display Serif**:
  - Headings set in *Playfair Display* / *Georgia* with tight negative tracking (`-0.045em`) and line heights down to `0.98`.
  - `.it`: Italic serif styling with warm highlighted underscores (`.ul` marker effect).
  - `.eyebrow`: Warm section intro bar with a terracotta line (`::before { width: 28px; height: 2px; background: var(--orange); }`).
  - Huge typographic watermark slots (`.slot`) in the background (`"boring."`, `"30x"`, `"zero."`, `"4"`, `"bottlenecks."`).
- **Clean Swiss Sans & Monospace**:
  - *Plus Jakarta Sans* for crisp, high-legibility body text.
  - *JetBrains Mono* for credential tags, timestamps, and architectural labels.

### 3. Iconic Cogent Labs Components
- **Pill Buttons (`.pill`, `.pill-navy`, `.pill-orange`, `.pill-line`)**:
  - Rounded pill geometry (`border-radius: 9999px`) with expanding terracotta `:before` hover bloom and animated arrow translation (`.ar`).
- **The Marquee Trust Drum (`.trust .drum`)**:
  - Continuous rolling credential bar highlighting Vanderbilt University, UC Davis, Saylani AI, NVIDIA, EC-Council CHFI, LangGraph, and .NET 10.
- **Cogent Cards Hierarchy (`.card.c1`, `.card.c2`, `.card.c3`)**:
  - `.card.c1`: Midnight Navy (`#06173A`) with cream text and powder accents.
  - `.card.c2`: Powder Blue (`#A8BCD2`) with navy text.
  - `.card.c3`: Cream with dashed navy border (`1.5px dashed var(--navy)`).
- **The 4-Step Engineering Sprint (`.mc`)**:
  - Numbered steps (`01 / DISCOVERY`, `02 / RETRIEVAL`, `03 / STATE GRAPHS`, `04 / PRODUCTION`) with dot indicators.
- **Pain Points Breakdown ("Sound Familiar?")**:
  - Clear operational friction points with highlighted keywords and sticky CTA card.

---

## 🚀 How to Run

### Option 1: Run via VS Code
1. Open the **Run and Debug** view (`Ctrl+Shift+D` or `Cmd+Shift+D`).
2. Select **Run All** and click ▶.

### Option 2: Run via CLI

#### 1. Launch BackEnd API & Scalar Docs:
```bash
dotnet run --project SampleApp/BackEnd/BackEnd.csproj --urls "http://localhost:8080"
```
- Interactive API Explorer: `http://localhost:8080/scalar`

#### 2. Launch Blazor Web App:
```bash
dotnet run --project SampleApp/FrontEnd/FrontEnd.csproj --urls "http://localhost:8081"
```
- Web Application: `http://localhost:8081/`

---

## 🛠️ Stack & Endpoints
- **Framework**: .NET 10 (C#)
- **Frontend**: Blazor Server, HTML5 Canvas API, Web Audio / Video API
- **Backend API**: ASP.NET Core Minimal APIs with OpenAPI & Scalar
- **Key Routes**:
  - `/` (Home: Hero, Trust Marquee, Manifesto, Pain Points, Case Studies, Sprints, Certifications, Tools, Contact)
  - `/about` (Bio, Engineering Philosophy, Career Timeline @ CodeSquad & RankSol, GCUF Education)
  - `/services/{slug}` (`rag-and-llm-agents`, `fastapi-backend-engineering`, `workflow-automation`)
  - `/projects/{slug}` (`campus-connect`, `memora`, `airline-agent`, `chat-with-pdf`, `news-agent`)
  - `/tools` (Developer Utilities Hub)
  - `/tools/video-speed` (HTML5 Video Speed & Pitch Controller)
  - `/tools/collage` (HTML5 Canvas Photo Collage Studio)
