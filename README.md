## Mediabazaar Management Software

This is a .NET fullstack application designed as management software for a fictional tech store called Mediabazaar, similar to MediaMarkt. The store offers a wide range of products categorized under various departments.

### Overview
- The application manages a large number of products and employees, with three possible workshift periods per day.

### Technologies
- **C# .NET 6**: Used for the development of the desktop app and backend.
- **ASP.NET RazorPages**: Employed for the web application.
- **Microsoft SQL**: Chosen as the database system.
- **SMTP client**: Utilized for the emailing service.

### Account Types
- **Administrator**: Responsible for account and department control.
- **Manager**: In charge of their respective department and employee workshifts.
- **Employee**: Able to view schedule, set availability, modify personal details, and receive notifications.

### Desktop Application Features
- Employee and department control with specific permissions for each account type.
- Employee availability and shift view with a calendar.
- Automatic scheduling for up to 3 weeks in advance for managers.
- Email notifications for workshift changes (e.g., addition or removal of workshifts).

### Web Application Features
- Admin announcements.
- Employee and manager personal detail changes.
- Intuitive workshift visual representation with a calendar and color coding.
- Email-based password resetting.

### Development
- The application's architectural choices are documented in the project plan.
- Utilizes a 3-layer model and class structure aligned with OOP and SOLID principles.
- Database modeled using the table-per-type approach.
- Development process follows a branching model using feature branches, with reference available at nvie.com (post by Vincent Driessen).

### Documentation
- The application development was planned in the project plan, along with the User Requirements Specification (URS) document.
- Quality is assured and documented in the Test Plan and Test Report, which reference every use case present in the URS.
- Entity Relationship Diagrams for the database were made for every change
- UML class diagram is present for the entire application as a whole, as well as for each individual library
