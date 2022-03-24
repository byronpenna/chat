# chat
Title: Net challenge financial

Description: 
The goal of this exercise is to create a simple browser-based chat application using .NET.
This application should allow several users to talk in a chatroom and also to get stock quotes
from an API using a specific command.

Installer:

At the first time, migration will run and get ready project database for every use that you need 

How to use:

Project current is configured to work with localdb with migrations.
As soon as you build the project migration will run just you need 
to take in count string connections that are located in:

<b>ChatBrowser/Chat.ChatWebBrowser/appsettings.json </b> (ChatDB)<br>
<b>ChatBrowser/Chat.WebApi/appsettings.json</b> (ChatDB)

In case you don't have communication with API you would check 
<b>ChatBrowser/Chat.ChatWebBrowser/appsettings.json</b> (API)

How its work

The solution was made using clean architecture for develop make easier as possible
I used esencial packages like mediatr, signalr, fluent, entity framework, CsvHelper.

Other feature is we have a decoupled system that works together 
and by it self are scalables (Not only system bot are decoupled) 


Database structure
ChatDB
	Tables:
		ChatRooms
		Messages
		Users
User that you can use in system:
	user: byronpenna 	pass: byronpenna123
	user: diana_alfaro 	pass: byronpenna123

but if you preffer you can add your own user.

Aditional notes:
* Because you want to see backend I just print error from API has application received
* To avoid having any errors with the files I prefer not configure .gitignore.
