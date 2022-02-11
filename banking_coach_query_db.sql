CREATE DATABASE BANKING_COACH_DB;

CREATE TABLE STUDENT(

Student_ID int NOT NULL,
Banking_Student int NOT NULL,
User_Active_Status int NOT NULL, /*True or False*/
Entry_Date date NOT NULL,
First_Name varchar(200) NOT NULL,
Second_Name varchar(200),
Last_Name varchar(200) NOT NULL,
Second_Last_Name varchar(200) NOT NULL,
Id_Type int NOT NULL,
Id_Number int NOT NULL,
Birth_Date date NOT NULL,
Sex int NOT NULL,
Primary_Phone varchar(200) NOT NULL,
Secondary_Phone varchar(200),
Email varchar(200) NOT NULL,
Laboral_Status int, /*True or False*/
Work_Address varchar(200) NOT NULL,
Laboral_Experience int NOT NULL,

);

CREATE TABLE USER_ADDRESS(
Student_ID_Address int NOT NULL,
Province varchar(200) NOT NULL,
Canton varchar(200) NOT NULL,
District varchar(200) NOT NULL,
);

CREATE TABLE USER_LOG(

Log_Record_Number int Not null,
Event_Logged varchar(200),
Date_Logged date
);

CREATE TABLE SYS_ADMIN_USER(

);

CREATE TABLE RECRUITER_USER(

);

CREATE TABLE FINANTIAL_USER (

);