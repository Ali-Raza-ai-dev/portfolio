namespace BackEnd.Models;

public record ProfileInfo(
    string Name,
    string JobTitle,
    string Headline,
    string Bio,
    string Email,
    string Location,
    string AvailabilityStatus,
    string GitHubUrl,
    string LinkedInUrl,
    Dictionary<string, string> Stats
);

public record ProjectItem(
    string Id,
    string Slug,
    string Title,
    string Tagline,
    string Description,
    string Category,
    bool Featured,
    List<string> TechStack,
    string? GithubUrl,
    string? DemoUrl,
    string? ArchitectureSummary,
    List<string> KeyFeatures,
    List<string> Highlights
);

public record ServiceItem(
    string Id,
    string Slug,
    string Title,
    string Tagline,
    string Description,
    List<string> Deliverables,
    List<string> RelatedProjectSlugs
);

public record CertificateItem(
    string Title,
    string Issuer,
    string Date,
    string ImagePath,
    string? CredentialUrl
);

public record ExperienceItem(
    string Role,
    string Company,
    string Period,
    string Location,
    List<string> Responsibilities
);

public record EducationItem(
    string Degree,
    string Institution,
    string Period,
    string Location
);

public record SkillCategory(
    string CategoryName,
    List<string> Skills
);

public record ContactMessageRequest(
    string Name,
    string Email,
    string Subject,
    string Message
);

public record ContactMessageResponse(
    bool Success,
    string Message,
    DateTime ReceivedAtUtc
);
