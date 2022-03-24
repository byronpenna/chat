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
ChatDB<br>
&nbsp;&nbsp;Tables:<br>
&nbsp;&nbsp;&nbsp;ChatRooms<br>
&nbsp;&nbsp;&nbsp;Messages<br>
&nbsp;&nbsp;&nbsp;Users<br>

<br><br>
<b>Testing stock</b><br>
APLE.US<br>
aapl.us<br>
User that you can use in system:<br>
&nbsp;&nbsp;user: byronpenna&nbsp;&nbsp; 	pass: byronpenna123<br>
&nbsp;&nbsp;user: diana_alfaro&nbsp;&nbsp; 	pass: byronpenna123<br>
<br>
but if you preffer you can add your own user.<br>
<br>
Aditional notes:<br>
* Because you want to see backend I just print error from API has application received<br>
* To avoid having any errors with the files I prefer not configure .gitignore.<br>
