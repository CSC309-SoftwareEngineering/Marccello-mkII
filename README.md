Documentation for CSC 309 – Software Engineering

Software Requirements:

•	Microsoft Visual Studio 2012
?	Professional version is ideal
•	NUnit
?	Installed through Visual Studio's “Extensions and Updates” manager
?	Tools ? Extensions and Updates
•	Git
?	Clone CSC 309 repository
?	https://github.com/CSC309-SoftwareEngineering/Marccello-mkII.git 
•	Microsoft SQL Server 2012 Express
?	Database Server URL: ruh0lst2bh.database.windows.net
?	ID: csc309
?	Password: Dumblyadorable!
































MMFs: 

•	MMF1: As a student, I want to see all courses listed for my major, and add them to a given semester.
o	Epic1: As a student, I want to be able to select a major and have it list my courses.
?	Story1: Store a list of courses in a database
?	Story2: Store a list of majors in a database
?	Story3: Associate courses with a major
?	Story4: Display the majors on a page (drop down menu?)
?	Story5: Allow user to select major in drop down
?	Story6: Display courses associated with the selected major (Selection Box?)
o	Epic 2: As a student, I want to be able to add courses to a given semester. 
?	Story1: Display a semester (Panel or other such thing...)
?	Story2: Select a course and add by clicking “Add”
?	Story3: Add course to semester list and displays under semester 
•	MMF2: As a student, I want to be able to build out all the semesters in my major so that I can plan out my college days appropriately
o	Epic 1:    As a student, I only want to see courses I have not yet taken in the available classes, so that I do not take a class more than once
o	Epic 2:    As a student, I want to see where I stand relative to the major's requirements so that I can be sure to graduate

•	MMF3: As a student, I want to account for transferred credits so that I can discount certain classes/requirements. 
o	Epic 1: As a student I can select classes from that I have transferred in so that those classes don’t show up in my list.
o	Epic 2: As a student I can select classes that I WILL transfer for a certain semester so that I don’t plan for those classes in my schedule.

•	MMF4: I want to be able to save my schedule, so that I can return to look/edit/maintain it.
o	Epic 1: I want to be able to save my schedule.
o	Epic 2: I should be able to reopen my schedule.
o	Epic 3: I want to be able to edit my schedule.

•	MMF5:  The program should be able to account for course prerequisites and co-requisites so that the student is aware of the recommended order of classes.
o	Epic 1: The system should alert me upon scheduling classes before taking the necessary prerequisites so that I am aware that my schedule deviates from the recommended order.
o	Epic 2: The system should alert me upon scheduling classes without taking, or having not scheduled, the necessary co-requisites so that I am aware that my schedule deviates from the recommended order.








Database Information:
Queries will work if run using Microsoft SQL Server.
If using a different infrastructure adjust the syntax accordingly. 
We named the database Marcello, which is what we’re calling the academic planner.
Queries to use:
USE marccello
CREATE TABLE Course
(
	course_id int NOT NULL PRIMARY KEY,
	name varchar(50) NOT NULL,
	course_number varchar(50) NOT NULL
)

CREATE TABLE Major
(
	major_id int NOT NULL PRIMARY KEY,
	name varchar(50) NOT NULL
)

CREATE TABLE Semester
(
	semester_id int NOT NULL PRIMARY KEY,
	term varchar(15) NOT NULL,
	semester_year int NOT NULL
)

CREATE TABLE MajorCourse
(
	major_id int NULL,
	course_id int NULL,
	p_key int NOT NULL PRIMARY KEY
)

CREATE TABLE SemesterCourse
(
	semester_id int NOT NULL,
	course_id int NOT NULL,
	p_key int IDENTITY(1,1) NOT NULL PRIMARY KEY
)
