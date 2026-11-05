using System.Collections.Concurrent;
using BackEnd.Models;

namespace BackEnd.Services;

public class PortfolioDataService
{
    private readonly ConcurrentBag<ContactMessageRequest> _submissions = new();

    public ProfileInfo GetProfile() => new(
        Name: "Ali Raza",
        JobTitle: "Agentic AI & Automation Developer",
        Headline: "Hi, my name is Ali Raza",
        Bio: "I build RAG systems, LLM-powered agents, and automated workflows that eliminate manual bottlenecks and help businesses work smarter.",
        Email: "167aliraza@gmail.com",
        Location: "Pakistan",
        AvailabilityStatus: "Available for new projects",
        GitHubUrl: "https://github.com/167AliRaza",
        LinkedInUrl: "https://www.linkedin.com/in/167aliraza",
        Stats: new Dictionary<string, string>
        {
            ["Projects & Agents"] = "10+",
            ["Certificates"] = "10",
            ["Specialization"] = "RAG & LLM Agents",
            ["Backend Core"] = "FastAPI & .NET"
        }
    );

    public List<ProjectItem> GetProjects() => new()
    {
        new(
            Id: "campus-connect",
            Slug: "campus-connect",
            Title: "Campus Connect — SaaS RAG Chatbot Platform",
            Tagline: "Multi-tenant SaaS RAG chatbot with tenant-isolated vector search",
            Description: "A multi-tenant SaaS RAG chatbot platform with role-based access control, JWT authentication, and tenant-isolated vector storage. Built as a React/FastAPI AI platform using LangGraph and Gemini embeddings with real-time streaming, document ingestion, analytics, conversation persistence, and cloud deployment.",
            Category: "RAG & Multi-Agent",
            Featured: true,
            TechStack: new() { "FastAPI", "React", "LangGraph", "Gemini", "JWT", "Vector DB", "Docker" },
            GithubUrl: "https://github.com/167AliRaza/Campus-Connect-Backend",
            DemoUrl: "https://campus-connect-frontend-kohl.vercel.app",
            ArchitectureSummary: "Tenant-isolated vector indexing using dense Google Gemini embeddings and partitioned vector stores. Session state and chat history checkpoints are orchestrated through LangGraph state graphs with real-time SSE streaming.",
            KeyFeatures: new()
            {
                "Multi-tenant isolation ensuring individual organisation data privacy",
                "Automated ingestion pipeline supporting PDFs, documents, and markdown with recursive chunking",
                "Real-time streaming responses with Server-Sent Events (SSE)",
                "Role-based access control (RBAC) with JWT auth and session revocation",
                "Admin dashboard for usage analytics, document management, and conversation monitoring"
            },
            Highlights: new()
            {
                "Grounded retrieval eliminates hallucinations via citation links",
                "Sub-second vector retrieval with hybrid search ranking",
                "Fully containerised with Docker for scalable cloud deployments"
            }
        ),
        new(
            Id: "memora",
            Slug: "memora",
            Title: "Memora — Persistent AI Chat API",
            Tagline: "Authenticated chat API with LangGraph checkpoints & Pinecone RAG",
            Description: "An authenticated chat API with threaded, persistent conversations backed by LangGraph checkpoints. Supports PDF/TXT/Markdown upload with background processing into Pinecone for RAG retrieval, real-time streaming over Server-Sent Events, JWT auth, and email verification.",
            Category: "RAG & Multi-Agent",
            Featured: true,
            TechStack: new() { "Python", "FastAPI", "MongoDB", "LangGraph", "Pinecone", "Docker" },
            GithubUrl: "https://github.com/167AliRaza/Memora",
            DemoUrl: "https://memora-by-ali.vercel.app/",
            ArchitectureSummary: "LangGraph checkpointing engine coupled with Pinecone vector indices for persistent cross-session memory. Asynchronous FastAPI background tasks parse and embed incoming files without blocking client threads.",
            KeyFeatures: new()
            {
                "Threaded conversational memory with branchable LangGraph checkpoints",
                "Background document ingestion into Pinecone vector index",
                "JWT authentication with email verification workflows",
                "High-throughput async FastAPI backend with MongoDB persistence",
                "Server-Sent Events (SSE) streaming for immediate token rendering"
            },
            Highlights: new()
            {
                "Persistent conversations preserved across browser refreshes and sessions",
                "Low-latency document similarity search via Pinecone serverless",
                "Production-ready error handling and API rate limiting"
            }
        ),
        new(
            Id: "airline-agent",
            Slug: "airline-agent",
            Title: "Airline Agent — AI Seat Booking Assistant",
            Tagline: "Multi-agent booking API with Triage, Booking, and FAQ specialists",
            Description: "A multi-agent airline booking API where Triage, Booking, and FAQ agents intelligently route user requests. Handles booking, updating, cancelling, and reviewing reservations with full passenger details, persisted in MongoDB, powered by Gemini through OpenAI-compatible APIs.",
            Category: "Multi-Agent Systems",
            Featured: true,
            TechStack: new() { "Python", "FastAPI", "Multi-Agent", "Gemini", "MongoDB" },
            GithubUrl: "https://github.com/167AliRaza/Airline-agent",
            DemoUrl: null,
            ArchitectureSummary: "Orchestrated multi-agent architecture utilizing a supervisor/triage routing pattern. The triage agent assesses customer intent and seamlessly hands off execution context to specialized booking and customer support sub-agents.",
            KeyFeatures: new()
            {
                "Supervisor triage routing agent for zero-confusion customer handoffs",
                "Full transactional booking lifecycle: reservation, seat selection, cancellation, and updates",
                "Real-time FAQ agent referencing airline policy documents and luggage rules",
                "Structured schema validation and tool calling for reliable database operations",
                "MongoDB persistence for flight inventory, passenger records, and ticket state"
            },
            Highlights: new()
            {
                "Complex tool calling handles multi-step passenger verification and booking commits",
                "Zero hallucination guarantee on ticket availability and flight numbers",
                "Extensible agent routing enables trivial addition of loyalty or baggage agents"
            }
        ),
        new(
            Id: "chat-with-pdf",
            Slug: "chat-with-pdf",
            Title: "Chat with PDF",
            Tagline: "Session-based RAG assistant with in-memory semantic indexing",
            Description: "A RAG document assistant that lets users upload a PDF and query its content in natural language. Features session-based conversations with history, in-memory semantic indexing, per-IP rate limiting, and upload guardrails — built on FastAPI and Google Generative AI.",
            Category: "RAG & Multi-Agent",
            Featured: false,
            TechStack: new() { "Python", "FastAPI", "RAG", "Google GenAI", "Docker" },
            GithubUrl: "https://github.com/167AliRaza/chat_with_pdf",
            DemoUrl: "https://chatwithpdf-aliraza.netlify.app",
            ArchitectureSummary: "Lightweight, memory-efficient vector pipeline performing client-side session vectorization. Implements semantic chunking with overlap and contextual citation generation using Gemini models.",
            KeyFeatures: new()
            {
                "Instant drag-and-drop PDF parsing with semantic chunking",
                "Interactive chat with contextual citations pointing directly to source pages",
                "Per-IP rate limiting and payload validation to prevent abuse",
                "Ephemeral in-memory vector storage for maximum privacy and zero data leakage",
                "Clean responsive UI with one-click clear and sample document test"
            },
            Highlights: new()
            {
                "Rapid document understanding without requiring third-party database credentials",
                "Accurate retrieval even on multi-column complex PDF layouts",
                "Lightweight Docker deployment suitable for serverless platforms"
            }
        ),
        new(
            Id: "news-agent",
            Slug: "news-agent",
            Title: "News Agent — AI News Summarizer",
            Tagline: "Autonomous multi-source news fetcher, analyzer & summarizer",
            Description: "An AI-powered news summarizer that fetches articles from various sources, analyses them, and generates concise summaries. Built with FastAPI and LangGraph for seamless integration with Gemini's language model.",
            Category: "AI Automation",
            Featured: false,
            TechStack: new() { "Python", "FastAPI", "LangChain", "LangGraph", "Gemini" },
            GithubUrl: "https://github.com/167AliRaza/News-Agent-BackEnd",
            DemoUrl: "https://news-agent-by-aliraza.vercel.app/",
            ArchitectureSummary: "Autonomous data harvesting pipeline coupled with a LangGraph synthesis agent. Articles are gathered via news APIs, parsed for clean readability, deduped, and passed through an LLM synthesis node to produce objective digests.",
            KeyFeatures: new()
            {
                "Multi-source news aggregator querying global news topics",
                "Automated article cleansing and boilerplate removal",
                "Executive bullet-point synthesis highlighting key takeaways and source links",
                "Sentiment and category classification tagging",
                "Clean web interface for real-time digest generation"
            },
            Highlights: new()
            {
                "Cuts news reading time by 80% through concise factual distillation",
                "Scheduled pipeline triggers for recurring daily digests",
                "Robust error handling for resilient external scraping and API calls"
            }
        )
    };

    public List<ServiceItem> GetServices() => new()
    {
        new(
            Id: "rag-and-llm-agents",
            Slug: "rag-and-llm-agents",
            Title: "RAG System & LangGraph Agents",
            Tagline: "Production-grade Retrieval-Augmented Generation & autonomous agents",
            Description: "I design and ship production-grade Retrieval-Augmented Generation pipelines and LangGraph-powered LLM agents that give businesses accurate, grounded AI responses backed by their own data.",
            Deliverables: new()
            {
                "Custom RAG pipelines grounded in your documents and internal data",
                "Multi-tenant vector storage with tenant-isolated retrieval",
                "LangGraph agentic workflows — tool use, memory, and checkpointing",
                "Real-time streaming responses over SSE or WebSockets",
                "Structured retrieval with re-ranking and hybrid search (BM25 + Dense)",
                "REST API layer (FastAPI / ASP.NET) for seamless drop-in integration"
            },
            RelatedProjectSlugs: new() { "campus-connect", "memora", "news-agent" }
        ),
        new(
            Id: "fastapi-backend-engineering",
            Slug: "fastapi-backend-engineering",
            Title: "FastAPI Backend Engineering",
            Tagline: "Scalable async APIs, secure authentication & cloud architecture",
            Description: "I build async, scalable REST APIs with Python and FastAPI — from lightweight microservices to multi-service platforms with authentication, background tasks, and cloud deployment baked in from day one.",
            Deliverables: new()
            {
                "Async FastAPI services with comprehensive OpenAPI / Swagger documentation",
                "JWT-based authentication and role-based access control (RBAC)",
                "MongoDB and PostgreSQL data layers with efficient query patterns",
                "Background task processing and server-sent event (SSE) streaming",
                "Docker containerisation and cloud deployment (Vercel, Railway, Render, AWS)",
                "Rate limiting, input validation, and production error handling"
            },
            RelatedProjectSlugs: new() { "campus-connect", "memora", "airline-agent" }
        ),
        new(
            Id: "workflow-automation",
            Slug: "workflow-automation",
            Title: "Workflow Automation — n8n & Make.com",
            Tagline: "Connect tools, eliminate manual bottlenecks & automate operations",
            Description: "I automate the manual, repetitive work that slows your team down — connecting your tools, syncing your data, and triggering actions in real time using n8n and Make.com, with custom code where off-the-shelf nodes fall short.",
            Deliverables: new()
            {
                "End-to-end workflow design in n8n and Make.com",
                "CRM and third-party API integrations (Airtable, Notion, HubSpot, Slack, WhatsApp)",
                "Automated data pipelines and cross-system sync between business tools",
                "Webhook-triggered workflows for real-time event processing",
                "Error handling, logging, alerting, and retry logic for 99.9% reliability",
                "Custom code nodes in Python / JavaScript for complex logic and transformations"
            },
            RelatedProjectSlugs: new() { "campus-connect", "news-agent" }
        )
    };

    public List<CertificateItem> GetCertificates() => new()
    {
        new(
            Title: "AI Agent Developer Specialization",
            Issuer: "Vanderbilt University (via Coursera)",
            Date: "Nov 2, 2025",
            ImagePath: "/images/certs/AI-Agent-Developer-Coursera-1SAZ0QCQFMT0.webp",
            CredentialUrl: "https://coursera.org/verify/specialization/1SAZ0QCQFMT0"
        ),
        new(
            Title: "Artificial Intelligence and Data Science (Batch-2)",
            Issuer: "Saylani Mass Training Programme",
            Date: "Nov-2024 to Aug-2025",
            ImagePath: "/images/certs/Artificial Intelligence and Data Science.webp",
            CredentialUrl: null
        ),
        new(
            Title: "AI Agents: From Prompts to Multi-Agent Systems",
            Issuer: "University of California, Davis (via Coursera)",
            Date: "Aug 15, 2025",
            ImagePath: "/images/certs/AI-Agents-From-Prompts-to-Multi-Agent-Systems-Coursera-DT2IKOE9HA0G.webp",
            CredentialUrl: "https://coursera.org/verify/DT2IKOE9HA0G"
        ),
        new(
            Title: "CWA Prompt-a-thon 2026",
            Issuer: "Code With Ahsan",
            Date: "2026",
            ImagePath: "/images/certs/1776697370045.jpg",
            CredentialUrl: null
        ),
        new(
            Title: "Building LLM Applications With Prompt Engineering",
            Issuer: "NVIDIA",
            Date: "April 12, 2025",
            ImagePath: "/images/certs/My Learning _ NVIDIA.jpg",
            CredentialUrl: "https://learn.nvidia.com/certificates?id=Wa4ZaBP3SN2tuVnSiQ799Q"
        ),
        new(
            Title: "Agentic AI and AI Agents: A Primer for Leaders",
            Issuer: "Vanderbilt University (via Coursera)",
            Date: "Aug 16, 2025",
            ImagePath: "/images/certs/Agentic-AI-and-AI-Agents-Coursera-YSMZQSXBG2N9.webp",
            CredentialUrl: "https://coursera.org/verify/YSMZQSXBG2N9"
        ),
        new(
            Title: "Generative AI Application Developer Certificate",
            Issuer: "PakAngels in collaboration with iCode Guru & Spire Pakistan",
            Date: "August 28, 2025",
            ImagePath: "/images/certs/Generative-AI-Application-Developer-certificate.webp",
            CredentialUrl: "https://quiz.ideagist.com/ideagist-certificate?cert_hash=784cbd476e1675ab"
        ),
        new(
            Title: "Computer Hacking Forensic Investigator",
            Issuer: "EC-Council",
            Date: "07 February, 2025",
            ImagePath: "/images/certs/ECC-CHFI-Certificate-ANSI.webp",
            CredentialUrl: "https://aspen.eccouncil.org/Certificate/DownloadDigitalCert?Serial=4it7SNLeHwUbjJ/v5/PfUvMyoszDaolQxJE6B9G28oY="
        ),
        new(
            Title: "Crash Course on Python",
            Issuer: "Google (via Coursera)",
            Date: "Mar 2, 2025",
            ImagePath: "/images/certs/Python Crash Course Google.webp",
            CredentialUrl: "https://coursera.org/verify/XN4XYW876CTL"
        ),
        new(
            Title: "Google AI Essentials",
            Issuer: "Google (via Coursera)",
            Date: "Feb 22, 2025",
            ImagePath: "/images/certs/Google AI Essentials.webp",
            CredentialUrl: "https://coursera.org/verify/3NGYRLF2AHH7"
        )
    };

    public List<ExperienceItem> GetExperience() => new()
    {
        new(
            Role: "Automation Developer",
            Company: "CodeSquad",
            Period: "May 2026 — Present",
            Location: "Lahore, Pakistan",
            Responsibilities: new()
            {
                "Built automation workflows for business operations and cross-functional teams",
                "Integrated third-party APIs for seamless automated data exchange and webhook processing",
                "Automated manual processes to eliminate operational bottlenecks and improve company efficiency",
                "Optimized existing automated pipelines for high reliability, fault tolerance, and performance"
            }
        ),
        new(
            Role: "AI Software Developer",
            Company: "RankSol",
            Period: "Sep 2025 — Mar 2026",
            Location: "Faisalabad, Pakistan",
            Responsibilities: new()
            {
                "Built RAG-based agentic chatbots using vector databases and custom retrieval pipelines with LangChain and LangGraph",
                "Developed REST APIs using Python and FastAPI for production AI services and client applications",
                "Improved response accuracy and grounded LLM outputs with structured retrieval and re-ranking"
            }
        )
    };

    public EducationItem GetEducation() => new(
        Degree: "BS Information Technology",
        Institution: "Government College University Faisalabad",
        Period: "2021 — 2025",
        Location: "Faisalabad, Pakistan"
    );

    public List<SkillCategory> GetSkills() => new()
    {
        new(
            CategoryName: "Python & Backend Engineering",
            Skills: new() { "Python", "FastAPI", "REST APIs", "Pandas", "NumPy", "Scikit-Learn", "C# / ASP.NET Core" }
        ),
        new(
            CategoryName: "Agentic AI & LLMs",
            Skills: new() { "LangGraph", "LangChain", "OpenAI Agent SDK", "Google ADK / Gemini", "RAG Pipelines", "Prompt Engineering" }
        ),
        new(
            CategoryName: "Databases & Vector Stores",
            Skills: new() { "Pinecone", "Qdrant", "PostgreSQL", "MongoDB", "Vector Embeddings", "In-Memory Indexing" }
        ),
        new(
            CategoryName: "Automation, Tools & Cloud",
            Skills: new() { "n8n", "Make.com", "Docker", "Git / GitHub", "Vercel / Railway", "SSE / WebSockets" }
        )
    };

    public ContactMessageResponse RecordContactMessage(ContactMessageRequest request)
    {
        _submissions.Add(request);
        return new ContactMessageResponse(
            Success: true,
            Message: "Thank you for reaching out! Ali Raza has received your message and will get back to you shortly.",
            ReceivedAtUtc: DateTime.UtcNow
        );
    }

    public List<ContactMessageRequest> GetSubmissions() => _submissions.ToList();
}
