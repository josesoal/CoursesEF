--Open this file with AzureData Studio
USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'CoursesDB')
BEGIN
  DROP DATABASE CoursesDB
END
CREATE DATABASE CoursesDB
GO

USE CoursesDB
GO

CREATE TABLE Course (
    CourseId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200),
    Description NVARCHAR(500),
    PublicationDate DATETIME,
    Photo VARBINARY(MAX)
)

INSERT INTO Course VALUES (
    'The Ultimate MySQL Bootcamp: Go from SQL Beginner to Expert', 
    'Become an In-demand SQL Master by creating complex databases and building reports through real-world projects',
    '2020-12-23',
    NULL)
INSERT INTO Course VALUES (
    'SQL - MySQL for Data Analytics and Business Intelligence',
    'SQL that will get you hired – SQL for Business Analysis, Marketing, and Data Management',
    '2021-02-15',
    NULL)
--SELECT * FROM  Course

--Table and Price have a relation one to one
CREATE TABLE Price (
    PriceId INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    CurrentPrice MONEY,
    Promotion MONEY,
    CourseId INT,
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId) 
)

INSERT INTO Price VALUES (150, 20, 1)
INSERT INTO Price VALUES (350, 40, 2)

--SELECT * FROM Price

--Course and Comment have a relation one to many
CREATE TABLE Comment (
    CommentId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Student NVARCHAR(200),
    Score INT,
    Text NVARCHAR(MAX),
    CourseId INT
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
)

INSERT INTO Comment VALUES ('Christian Sasig', 2, 'Great to learn all the new things that we can do in using Arduino!!', 1)
INSERT INTO Comment VALUES ('Edison Olmedo', 5, 'Material is easy to understand as presented. I am lookng forward to te advance courses for this subject from this instructor.', 1)
INSERT INTO Comment VALUES ('Javier Torrens', 3, 'The lecture is very clear and describes the activities in full.', 1)
INSERT INTO Comment VALUES ('Jeff Rhodes', 3, 'At times it was a bit over my head, but when I got lost Stephen was very good about answering my questions in a prompt manner which was very appreciated.', 2)
INSERT INTO Comment VALUES ('Dave Mueller', 5, 'Poor video quality while connecting the devices. ', 2)

--SELECT * FROM Comment

CREATE TABLE Instructor (
    InstructorId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200),
    LastName NVARCHAR(200),
    Category NVARCHAR(200),
    Photo VARBINARY(MAX)
)

INSERT INTO Instructor VALUES ('Oscar','Sanchez','Engineer',NULL)
INSERT INTO Instructor VALUES ('Jesus','Diaz','Developer',NULL)
INSERT INTO Instructor VALUES ('Javier','Fernandez','Engineer',NULL)
INSERT INTO Instructor VALUES ('Sara','Muñoz','Engineer',NULL)

--SELECT * FROM Instructor

--Course and Instructor have a relation many to many
CREATE TABLE CourseInstructor (
    CourseId INT NOT NULL,
    InstructorId INT NOT NULL,
    PRIMARY KEY(CourseId, InstructorId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId),
    FOREIGN KEY (InstructorId) REFERENCES Instructor(InstructorId) 
)

INSERT INTO CourseInstructor VALUES (1,1)
INSERT INTO CourseInstructor VALUES (1,2)
INSERT INTO CourseInstructor VALUES (1,3)
INSERT INTO CourseInstructor VALUES (2,1)
INSERT INTO CourseInstructor VALUES (2,3)

SELECT * FROM CourseInstructor