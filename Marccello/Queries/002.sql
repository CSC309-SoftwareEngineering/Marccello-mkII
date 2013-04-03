USE Marccello
CREATE TABLE Majors 
(
name varchar(50) NOT NULL PRIMARY KEY,
department varchar(50) NOT NULL,
)
CREATE TABLE Courses
(
name varchar(50) NOT NULL PRIMARY KEY,
department varchar(50) NOT NULL,
course_number int NOT NULL,
)