## Lottery Application 

*Description*

This application simulates a lottery draw. It draws 5 numbers from 1 to 50 and displays the result to the user. The numbers in the draw are unique. Historical data can be stored in a database.

Technologies:

•	Backend: .NET Core, C#

•	Database: MSSQL

•	IDE (optional): Rider

*Installation*

1.	Download or clone the repository.
2.	In Rider, make sure you have the .NET Core plugin installed.
3.	Restore the NuGet packages if necessary.
4.	Otherwise, in other editors plugins will be initiazed when opening the application

*Database*

Be sure if missing to install package: Microsoft.EntityFrameworkCore.SqlServer for the application to be able to run properly. Database will be created on Application start. Be sure to have MSSQL Sever installed and running. 

*Running the application*

1. Run the application by pressing shift+F10 in Rider. 
2. After running, the application will simulate drawing numbers for the lottery.
3. You can use the following commands in the console:

    • `Run` : Initiates a new drawing of numbers.

    • `History` : Displays the history of drawn numbers.

    • `Exit` : Terminates and exits the application. 
