# Calendar Mapping

#### .NET Independent Project for Epicodus, 09/09/2016 - 10/07/2016

#### By Shradha Pulla

## Description

Web app to view events near user by date using Google Maps & Calendar API.

## Setup/Installation Requirements

This program can only be accessed on a PC with Windows 10, and with Git, Visual Studio, and Sql Server Management Studio (SSMS) installed.

* Clone this repository
* Import the database:
  * Open SSMS
  * Select the following buttons from the top nav bar to open the database scripts file: File>Open>File>"Desktop\CalendarMapping\src\CalendarMapping\SqlScripts\CalendarMappingDB.sql"
  * Save the CalendarMappingDB.sql file to create the database
  * Refresh SSMS
* View the web page: 
  * Open the project solution in Visual Studio
  * Click the IIS Express play button on the top navbar in Visual Studio. The web page will automatically launch in Google Chrome

##IMPORTANT Notes

* Do not delete SiteBoss & AccountHolder roles
* Do not delete EpicodusAdmin user

## Testing Authentication/Authorization

Sample users have been created by the developer for program testing use.

Role(s) | Username | Password
----- | ----- | -----
SiteBoss, AccountHolder | EpicodusAdmin | Epicodus1234!
AccountHolder | TestUser | Test1234!

## Known Bugs

* Need to fill in all information in edit event form otherwise will be null

## Specifications

The program should... | Example Input | Example Output
----- | ----- | -----
Have CRUD functionality for a user account | --- | ---
Prevent users from registering an account with an already in use username &/or email | --- | ---
Add user to AccountHolder role upon initial registration | --- | ---
Create a new private calendar for user upon registration | --- | ---
Log in new user automatically upon registration | --- | ---
Allow SiteBoss to delete any account | --- | ---
Have CRUD functionality for a role (only accessible by SiteBoss) | --- | ---
Add user to a role (many-to-many relationship) | --- | ---
Remove user from a role | --- | ---
**View all users by role | --- | ---
Have CRUD functionality for an event | --- | ---
Allow users to CRUD events (one-to-many-relationship) | --- | ---
View details for one event on separate page | --- | ---
Have CRUD functionality for a calendar | --- | ---
View all events in a calendar on calendar details page | --- | ---
View all user's event locations on Event Manager | --- | ---
Center map on user's location | --- | ---
Restrict site access through authorization | --- | ---

** = specs yet to be finished

## Future Features

HTML | CSS | AJAX | JavaScript | C#
----- | ----- | ----- | ----- | -----
Change time output on events list from military time to standard time format | Design site (fancy, not just basic) | Set up alerts after user completes a CRUD function | --- | Email confirmation for new accounts
--- | --- | --- | --- | ---

## Support and Contact Details

Contact Epicodus for support in running this program.

## Technologies Used

* HTML
* CSS
* Bootstrap
* AJAX
* jQuery
* JavaScript
* Visual Studio
* Google Maps API

## Links

Git Hub Repository: https://github.com/pullashradha/CalendarMapping

## License

*This software is licensed under the Microsoft ASP.NET license.*

Copyright (c) 2016 Shradha Pulla