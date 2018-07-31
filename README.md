# ASP.NET-SERVICES
Examples of ASP web forms and WSDL Services
Services are made using C#

Assignment 3 showcases services I've created using C#. There is one RESTFUL service and 5 WSDL services. Some of those services use APIs to find locations or make queries and all rely on JSON replies. Further details can be found in the Assignment 3 folder.

Assignment 5 showcases the use of forms authorization. Only authorized users may access certain pages of the web application. The web application keeps track of authorized users by writing and reading to the xml documents login_db.xml and members.xml located in the App_Data folder. In addition, this assignment incorporates services from assignment 3 to create a more realistic web application that could be presented to the end user.

There are 4 types of users. 
  Unregistered users: those who have no login credentials and thus cannot access any of the protected subfolders. 
  Members: Those who have self-registered, meaning they have created an account and that account has been saved to an xml file located in
  the App_Data folder of the web application. They may only access member pages under the /Account subolder.
  Staff: Those who have been pre-registered with staff access may access the staff page under the /Protected folder, but cannot access the 
  admin pages.
  Admin: Those who have been pre-registered with admin access may acess the admin page under the /Protected folder. Both staff and admin's 
  credentials are saved in App_Data under the login_db file.
  
  Please direct any questions to jonreyes4@gmail.com
