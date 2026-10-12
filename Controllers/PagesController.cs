using Microsoft.AspNetCore.Mvc;

namespace AveniqMvc.Controllers;

public sealed class PagesController : Controller
{
    private static readonly HashSet<string> Pages = new(StringComparer.OrdinalIgnoreCase)
    {
        "about",
        "ai-automation",
        "application-support",
        "business-operations",
        "cloud-infrastructure",
        "consulting",
        "contact",
        "cybersecurity",
        "data-analytics",
        "devops-platform",
        "digital-experience",
        "engagement-models",
        "engineering-iot",
        "enquiry",
        "enterprise-applications",
        "enterprise-services",
        "hardware-accessories",
        "hardware-desktops",
        "hardware-laptops",
        "hardware-lifecycle",
        "hardware-networking",
        "hardware-servers",
        "hardware",
        "index",
        "industries",
        "industry-aerospace",
        "industry-agriculture",
        "industry-automotive",
        "industry-banking",
        "industry-capital-markets",
        "industry-construction",
        "industry-education",
        "industry-energy",
        "industry-healthcare",
        "industry-insurance",
        "industry-life-sciences",
        "industry-logistics",
        "industry-manufacturing",
        "industry-media",
        "industry-professional-services",
        "industry-public-services",
        "industry-retail",
        "industry-technology",
        "industry-telecom",
        "industry-travel",
        "managed-it",
        "privacy",
        "quality-engineering",
        "service-directory",
        "services",
        "software-development",
        "software-services",
        "technology-solutions",
    };

    [HttpGet("/")]
    public IActionResult Home() => View("~/Views/Pages/index.cshtml");

    [HttpGet("/{slug}")]
    public IActionResult Page(string slug)
    {
        if (!Pages.Contains(slug)) return NotFound();
        if (slug.Equals("index", StringComparison.OrdinalIgnoreCase)) return RedirectPermanent("/");
        return View($"~/Views/Pages/{slug.ToLowerInvariant()}.cshtml");
    }

    [HttpGet("/{slug}.html")]
    public IActionResult Legacy(string slug)
    {
        if (!Pages.Contains(slug)) return NotFound();
        return RedirectPermanent(slug.Equals("index", StringComparison.OrdinalIgnoreCase) ? "/" : $"/{slug.ToLowerInvariant()}");
    }

    [Route("/error")]
    public IActionResult Error()
    {
        Response.StatusCode = 500;
        return View("~/Views/Shared/Error.cshtml");
    }
}
