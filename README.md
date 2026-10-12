# Aveniq ASP.NET Core MVC

Complete C# / ASP.NET Core MVC conversion targeting .NET 10 LTS. All 53 website pages are Razor `.cshtml` views, with a shared layout and a C# controller that permits only known routes. The logo, images, grouped menus, original page content, and browser chatbot are retained.

## Run locally

Install the .NET 10 SDK. Open a terminal in this folder:

```bash
dotnet restore
dotnet build
dotnet run --urls http://localhost:5000
```

Open http://localhost:5000. Do not open `.cshtml` files directly. Clean routes include `/services`, `/industries`, `/hardware`, and `/contact`. Legacy `.html` links redirect to clean routes.

## Hostinger Linux deployment

Use a Linux VPS with SSH/root access. Standard shared PHP hosting cannot run this ASP.NET Core application by extracting a ZIP into public_html. The recommended setup is Ubuntu with Docker Engine and the Compose plugin installed.

1. Point your real domain's A record to the VPS IPv4 address. Configure any AAAA record to the correct VPS IPv6 address, or remove a stale one.
2. Allow inbound TCP 80 and 443 in the server/provider firewall; keep SSH available for administration.
3. Extract this source project onto the VPS and enter its directory.
4. Copy `.env.example` to `.env`. Set `DOMAIN` to your actual hostname without `https://`, a path, or a trailing slash.
5. Run:

```bash
docker compose up -d --build
docker compose ps
docker compose logs --tail=100 web proxy
```

The build uses the official .NET SDK container. The runtime uses the official ASP.NET container. Caddy proxies the public domain to the private application and requests HTTPS certificates automatically once DNS resolves and ports 80/443 are reachable. The application is not published directly to a host port.

Open https://YOUR-DOMAIN/ and https://YOUR-DOMAIN/health. Test menus, individual service and industry pages, logo display, enquiry review, and chat.

For future updates, replace the project files and run `docker compose up -d --build`. Do not delete the certificate volumes. Change the supplied network subnet if it conflicts with an existing server network; also update the trusted proxy IP in Program.cs to match.

## Alternative: publish without Docker

On a machine with the .NET 10 SDK, run `bash deployment/publish-linux.sh`. This produces a self-contained linux-x64 build. Transfer the publish folder to your Linux x64 VPS, run the executable under a dedicated systemd service, and place Nginx or another HTTPS reverse proxy in front. ARM servers require a linux-arm64 publish instead. OS dependencies must be available even for self-contained publishing.

## Current functionality

The enquiry form prepares a downloadable brief in the visitor's browser; it does not email or store leads on a server. The chatbot provides predefined instant responses and navigation, rather than live-agent or AI responses. MVC conversion preserves these behaviors. No database, mail credentials, or AI keys are required.

## Verification

The source conversion, page route allowlist, static asset references, and JavaScript syntax were checked. The conversion environment has no .NET SDK, so compilation and a runtime smoke test could not be executed here. Run the build commands above before production deployment. This archive contains source, not precompiled Linux binaries.
