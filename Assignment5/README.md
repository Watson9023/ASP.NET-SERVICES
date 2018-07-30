# Assignment 5: Services Deployment, Security Authentication 

The assignment incorporates the services from Assignment 3 along with authorization management features. The assignment contains the following pages.

Default.aspx
About.aspx
ImageVerifier.aspx
Login.aspx
MemberLogin.aspx
Register.aspx
/Account/Members.aspx
/Protected/Admin.aspx
/Protected/Staff.aspx

Default: Contains the main page of the webapp. Provides links to other pages and information.

About: Contains details about the services used in the creation of the web app.

ImageVerifier: Used to implement an image verification user-control for registering members.

Login: The main login page for staff/admin. Forms authentication redirects to this page by default. Each staff or admin's credentials are checked against an internal xml document login_db.

MemberLogin: Is the main portal from which registered member may login to the members only area (Account). Each login is checked against the xml document members located in App_Data.

Register: The main page from which aspiring members can self-register. Each succesful registration writes to an xml document called 'members' that is used for returning members and to ensure there are no double-registrations. 

/Account/Members: Members page from which a member may use flight search services.

/Protected/Admin: Administrators page, only (user: Jon pass: 123) may access the admin page. The admin page displays the information for all staff registered in the xml document login_db. 

/Protected/Staff: The staff page, displays only self-registered members. Access to this page is controlled by the xml document login_db. 

The application is deployed @ http://webstrar56.fulton.asu.edu/page7/default.aspx

However it can be unstable. Recommended viewing through Visual Studio.

For questions contact jonreyes4@gmail.com
