# DA205E (Spring 26) - [Programming in C#, II](https://mau.se/en/study-education/courses/da205e) @ [MAU](https://mau.se/en/)

This is the continuation course of the Programming in C# course (DA204E). In this course we are diving deeper into OOP with C# as well as programming GUI:s, this time using both Windows forms and WPF. The course consists of multiple assignments grouped into two groups as far as grading goes along with three quizzes.


## Structure

This repo contains all the assignments I've worked on along any other relevant files. For all graded work see the "Graded Assignments" folder. For images of the applications created in the different assignments please refer to the "Application Images", or this readme.



## About assignments

### Assignment 1 - Encapsulation and Inheritance
Assignment 1 primarly focuses on applying basic OOP concepts such as encapsulation, inheritance, dynamic binding in a Windows Forms application. The application consisted of a simple form where the user could add a new animal, and then see the animal data in the GUI. Additionally the user was able to load an image into the application. Making a new animal would remove the old one.

![Assignment 1 application, showcasing a form for creating a new animal as well as loading an image of an animal. Additionally shows all the data about the last created animal.](https://github.com/Snicon/DA205E_Programming-in-CSharp-II/blob/main/Application%20Images/Assignment_1.png?raw=true)

### Assignment 2 - Polymorphism, Generics & Collections
Assignmnet 2 builds upon assignment 1, mainly by adding new data structures into the mix (such as lists, dictionaries, and queues), but also introducing polymorphism and generics. Interfaces were introduced and a generic list management class was created. The user could now create multiple animals, as well as edit or delete any one of them. More data would be displayed such as daily food requirements and upcomming events.

![Assignment 2 application, it builids upon the last image now including the ability to choose between different animals in a listbox and showcasing even more data in new data structures.](https://github.com/Snicon/DA205E_Programming-in-CSharp-II/blob/main/Application%20Images/Assignment_2.png?raw=true)

### Assignment 3 - Files, Exceptions and LINQ
Assignment 3 builds upon the last two assignments by adding support for importing data and exporting data from the application in various file formats. Additionally the user may now filter and search for animals as well as calculate some basic statistics. These new features taught the basics of serialization to plain text, json and xml, as well as, the basics of de-serialization from plain text and json. In order to get the filtering and searching to work LINQ was used. Lastly some basics about exceptions (along with custom exceptions) was introduced to complement the file handling tasks.

![Assignment 3 application, it builids upon the last images now including the ability to export and import data from the application as well as searching and filtering among the animals.](https://github.com/Snicon/DA205E_Programming-in-CSharp-II/blob/main/Application%20Images/Assignment_3.png?raw=true)

### Assignment 4 - Delegates, Events, Publisher/Subscriber pattern (and WPF)
Assignmnet 4 brings a completley new application, this time focusing on flight management. The user may add new flights/airplanes and then these would be controlled in the application by making the mtake off or changing destination or flight height. What makes this assignment so interesting is the practical implementation of the publisher/subscriber pattern which introduced delegates and events. Additionally the GUI was ceated in WPF rather than Windows Forms this time introducing interesting mechanics such as bindings, observable collections etc.

![Assignment 4 application, the GUI showcases a form for creating a new flight, a list box for managing flights along with a flight log.](https://github.com/Snicon/DA205E_Programming-in-CSharp-II/blob/main/Application%20Images/Assignment_4.png?raw=true)

### Assignment 5 - Records, Tuples and Data Structures
Assignment 5 brings yet another application, this time focused on records, tuples and even more data structures (like HashSets). In short the user may add transaction categories and transactions. These may then be filtered or searched, aditionally the user may get an overeview of the cash-flow per month and generate a simple .txt report. Just like assignment 3 some basic serialization and deserialization was included as a part of this assignment, though this time only with JSON support.

![Assignment 5 application, the GUI showcases category and transactions creation forms, management of transactions as well as filtering and seraching for transactions along with monthly cas flow calculations.](https://github.com/Snicon/DA205E_Programming-in-CSharp-II/blob/main/Application%20Images/Assignment_5.png?raw=true)

### Assignment 6, pt1
In short a project proposal outlining a project of my own. I decided to write a proposal for an application that keeps tracks of literature for a studnets courses, features listed below:
- Organize literature by specific courses.
- Track the status of each literature (for example, owned, borrowed, lent).
- Track the format of the literature (physical or digital).
- Generate bibliography entry/citation in standard formats (like APA, Harvard, etc).
- Filter and search among the resources based on various criteria (for example author, ISBN, course, status, etc).

The project proposal also includes a UML diagram, see the image below. Any flaws in this diagram are resolved during the next part of assignment 6.
![Assignment 6, UML diagram](https://github.com/Snicon/DA205E_Programming-in-CSharp-II/blob/main/Application%20Images/Assignment_6-UML-diagram.png?raw=true)

### Assignment 6, pt2
For this part the actual application was developed. All the features listed above except for the last one (filtering and search) was implemented. Unfortenatley there were time constraints. In addition to the mentioned features the data for the application is all stored in a SQLite database with the help of Enitity Framework Core.

![Assignment 6 application](https://github.com/Snicon/DA205E_Programming-in-CSharp-II/blob/main/Application%20Images/Assignment_6.png?raw=true)

## Progress \& grades

### Assignments

|Assignment|Handed in|Grade|Best possible grade|
|-|-|-|-|
|Assignment 1|☑|A|A|
|Assignment 2|☑|A|A|
|Quiz 1|☑|A|A|
|Assignment 3|☑|A|A|
|Quiz 2|☑|A|A|
|Assignment 4|☑|A|A|
|Assignment 5|☑|A|A|
|Quiz 3|☑|A|A|
|Assignment 6 pt 1|☑|A|A| (Optional for final grade C, required for final grade B or A)
|Assignment 6 pt 2|☑|A|A| (Optional for final grade C, required for final grade B or A)


### Final grade
A
