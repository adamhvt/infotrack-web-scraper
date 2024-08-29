# info-track-web-scraper
Solution for the web scraper take home exercise using .Net, Angular and SQLLite.

[TOC]

# Requirements
This application requires the following to be able to run:
- .Net 8
- Entity Framework Core tools to run migrations and update the database [(link)](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
- NodeJS (v20+)

# Setup
1. Clone this repository:
`https://github.com/adamhvt/info-track-web-scraper.git`

2. Update database by running the following command from within the solution's root folder:

    `dotnet ef database update -p .\WebScraper.Infrastructure\ -s .\WebScraper.Api\`

    This will create the database. Note: Migrations will pre-populate the database with seed data.

3. Start the application through Visual Studio.

4. Swagger will open automatically on start, but there is also a simple UI available, built using Angular. To access that UI, open `https://localhost:4200/`


# Domain
There are two main domain entities within the application:
### Web Search
Represents a search that can be repeated multiple times. A Web Search contains the search term and the search engine used.

### Web Search Result
Represents the result of a processed search request. It references the Web Search, allowing for trend analysis for a search expression.

# Design Decisions
### Clean Architecture
Clean architecture is ideal because it promotes separation of concerns, making the system more maintainable, testable, and scalable. By decoupling the core business logic from external dependencies, it ensures flexibility in adapting to changes and enhances code reusability across different platforms and contexts.

Given that, in theory, the application could support multiple search providers, hexagonal architecture would also be a good fit for this task.

### Unit of Work
The unit of work pattern simplify transaction handling by treating multiple repository operations as a single unit, ensuring that changes to multiple repositories are either committed or rolled back together.


# Use Cases
- A user should be able to see all previous searches.
\
`[GET] /api/WebSearch`

- A user should be able to initiate a new search that returns the ranking results of the scraped HTML response.
\
`[POST] /api/WebSearch`

- A user should be able to re-run a previously created search.
\
`[PUT] /api/WebSearch`

- A user should be able to see all previous search responses and filter them by web search Id.
\
`[GET] /api/WebSearchResults`
\
`[GET] /api/WebSearchResults?webSearchId={value}`

# Limitations
As cookie consent banners often defer loading the search results, scraping results were not always reliable, therefore the current solution is using mock HTML responses based on real search results.

The components and logic for sending a real request to the search providers are still in place for demonstration purposes.

# Improvements
- Use FulentValidation for validation requests
- Add global error handling
- Add more tests
- Add caching