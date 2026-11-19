_CoffeeTrendViewer — Requirements_

---

## 1. Project Overview

CoffeeTrendViewer is a local web application that collects coffee bean preferences and visualizes regional coffee taste trends across Japan.

The MVP aims to provide a basic workflow for registering coffee bean information, aggregating preferences by region, and displaying the results on a map.

## 2. Project Goals

- Allow users to register coffee bean information and tasting preferences.
- Store submitted data in a local SQLite database.
- Aggregate coffee preferences by geographical region.
- Visualize regional trends on a map of Japan.
- Display statistical information supporting the visualization.

## 3. Target Environment

- Operating System: Windows
- Runtime: .NET 10
- Backend: ASP.NET Core
- Database: SQLite
- Frontend: HTML, CSS, JavaScript
- Access: Local browser via localhost

## 4. MVP Functional Requirements

### FR-01: Coffee Data Registration

Users can register information about purchased coffee beans.

Candidate attributes:
- Coffee name
- Country of origin
- Region of production
- Flavor characteristics
- Roast level
- Purchase date
- Tasting notes

The final attribute list will be determined during database design.

### FR-02: Data Persistence

- Registered data must be stored in SQLite.
- Data must remain available after application restart.
- Basic validation must be performed before saving.

### FR-03: Regional Aggregation

- Aggregate registered coffee preferences by geographical region.
- Calculate the frequency or proportion of flavor characteristics.
- Exclude or suppress regions with insufficient data.

Regional Aggregation Unit

- The MVP uses Japan's 47 prefectures as geographical aggregation units.
- Municipality-level aggregation is out of scope for the MVP.
- The architecture should consider possible future expansion to municipality-level aggregation.

### FR-04: Map Visualization

- Display a map of Japan.
- Visualize regional coffee preferences using color gradients.
- Allow users to identify regional differences.
- Display the underlying statistical information when a region is selected.

### FR-05: Statistical Information

Display, where applicable:
- Number of submissions
- Aggregation period
- Dominant flavor characteristics
- Statistical calculation method

## 5. Privacy Requirements

- Separate user-identifying information from submitted coffee data where practical.
- Do not expose individual submission records through the public statistical view.
- Suppress statistics for regions with insufficient submissions.
- Avoid exposing precise residential addresses or precise personal locations.

The MVP is a local application. These measures do not constitute a guarantee of anonymity.

## 6. Non-Functional Requirements

- The application must run locally on Windows.
- The application must be usable through a modern web browser.
- The database must persist between application sessions.
- The implementation should favor maintainability and clear separation of responsibilities.
- External services should be minimized where practical.

## 7. Out of Scope for MVP

- Public cloud deployment
- Multi-user simultaneous access
- User authentication and account management
- Social networking features
- Real-time nationwide statistical updates
- AI-based flavor analysis
- Commercial analytics dashboards

## 8. Success Criteria

The MVP is considered complete when:

1. The application starts locally.
2. Users can register coffee bean information.
3. Registered information is persisted in SQLite.
4. Regional statistics can be calculated from stored data.
5. Regional preferences can be visualized on a map of Japan.
6. Statistical information can be inspected.
7. Basic validation and privacy-related safeguards are implemented.

## 9. Implementation Progress (2026-11-19)

### Completed

- Created an ASP.NET Core project targeting .NET 10 (SDK 10.0.404).
- Started the ASP.NET Core application and confirmed the `Hello World` HTTP response through localhost.
- Added the NuGet package `Microsoft.Data.Sqlite` (Version 11.0.0).
- Added SQLite connection code to `Program.cs` and confirmed a successful connection through the console log.
- Confirmed that the `Database/coffee.db` file was created.
- Confirmed that the `.gitignore` rule `*.db` excludes the database file from Git tracking.

### Pending / Next Steps

- Create tables in the SQLite database.
- Verify data insertion and retrieval using SQL (so far, only the connection has been verified; the database file was 0 bytes when inspected).
- Design and finalize the data model and table schema.
- Implement Repository, Interface, and DI to separate database-access responsibilities.

This progress section records implementation status and does not change the functional requirements or MVP success criteria.
