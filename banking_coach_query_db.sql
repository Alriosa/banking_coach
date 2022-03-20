CREATE DATABASE BANKING_COACH_DB;
GO

USE BANKING_COACH_DB;


CREATE TABLE USER_LOG(
Id_Record_Number int IDENTITY(1,1) Not null,
Event_Logged varchar(200),
Date_Logged date,
FK_Student_ID INT NOT NULL,
FK_Sys_Admin_User_ID INT NOT NULL,  
FK_Recruiter_User_ID INT NOT NULL,
FK_Financial_User_ID INT NOT NULL,
PRIMARY KEY(Id_Record_Number),
);

CREATE TABLE STUDENT(
Student_ID int IDENTITY(1,1) NOT NULL,
Banking_Student int NOT NULL,
User_Active_Status int NOT NULL, /*True or False*/
Entry_Date date NOT NULL,
First_Name varchar(200) NOT NULL,
Second_Name varchar(200),
Last_Name varchar(200) NOT NULL,
Second_Last_Name varchar(200) NOT NULL,
Id_Type int NOT NULL,
Id_Number int NOT NULL, ---MUST BE UNIQUE ---
Birth_Date date NOT NULL,
Sex int NOT NULL,
Primary_Phone varchar(200) NOT NULL, ---MUST BE UNIQUE ---
Secondary_Phone varchar(200),
Email varchar(200) NOT NULL,
Laboral_Status int, /*True or False*/
Work_Address varchar(200) NOT NULL,
Laboral_Experience int NOT NULL,
Student_User varchar(20) NOT NULL,---MUST BE UNIQUE ---
Student_Password varchar(50) NOT NULL,
PRIMARY KEY(Student_ID),
Province varchar(200) NOT NULL,
Canton varchar(200) NOT NULL,
District varchar(200) NOT NULL,
FK_Id_Record_Number INT NOT NULL,
CONSTRAINT UC_Student UNIQUE (Id_Number,
                               Student_User,
                               Student_Password),
CONSTRAINT FK_Student_ID_LOG FOREIGN KEY (FK_Id_Record_Number) REFERENCES USER_LOG(Id_Record_Number),
);

CREATE TABLE SYS_ADMIN_USER(
Sys_Admin_User_ID int IDENTITY(1,1) NOT NULL,
Admin_Login varchar(20) NOT NULL, 
Admin_Password varchar(50) NOT NULL,
FK_Sys_Admin_User_ID INT IDENTITY(1,1) NOT NULL,
PRIMARY KEY(Sys_Admin_User_ID),
);

CREATE TABLE RECRUITER_USER(
Recruiter_User_ID int IDENTITY(1,1) NOT NULL,
Recruiter_Login varchar(20) NOT NULL,
Recruiter_Password varchar(50) NOT NULL, 
PRIMARY KEY(Recruiter_User_ID),
CONSTRAINT UC_Recruiter_User UNIQUE (Recruiter_Login)
);

CREATE TABLE FINANCIAL_USER (
Financial_User_ID int IDENTITY(1,1) NOT NULL, 
Financial_User varchar(20) NOT NULL, 
Financial_Password varchar(50) NOT NULL,
CONSTRAINT UC_Financial_User UNIQUE (Financial_User)
);