CREATE DATABASE BANKING_COACH_DB;
GO

USE master;
DROP DATABASE BANKING_COACH_DB;

USE BANKING_COACH_DB;

CREATE TABLE TBL_STUDENT(
Student_ID INT IDENTITY(1,1) NOT NULL, --PK
Banking_Student INT NOT NULL,
User_Active_Status INT NOT NULL, /*True or False*/
Entry_DATE DATE NOT NULL,
First_Name VARCHAR(200) NOT NULL,
Second_Name VARCHAR(200),
Last_Name VARCHAR(200) NOT NULL,
Second_Last_Name VARCHAR(200) NOT NULL,
Id_Type INT NOT NULL,
Id_Number INT NOT NULL, ---MUST BE UNIQUE ---
Birthdate DATE NOT NULL,
Sex INT NOT NULL,
Primary_Phone VARCHAR(200) NOT NULL, ---MUST BE UNIQUE ---
Secondary_Phone VARCHAR(200),
Email VARCHAR(200) NOT NULL,
Laboral_Status INT, /*True or False*/
Work_Address VARCHAR(200) NOT NULL,
Laboral_Experience INT NOT NULL,
Student_User VARCHAR(20) NOT NULL,---MUST BE UNIQUE ---
Student_Password VARCHAR(50) NOT NULL,
Province VARCHAR(200) NOT NULL,
Canton VARCHAR(200) NOT NULL,
District VARCHAR(200) NOT NULL,
PRIMARY KEY(Student_ID),
CONSTRAINT UC_Student UNIQUE (Id_Number,
                               Student_User,
                               Student_Password)
);

CREATE TABLE TBL_SYS_ADMIN_USER(
Sys_Admin_User_ID INT IDENTITY(1,1) NOT NULL, --PK
Admin_Login VARCHAR(20) NOT NULL, 
Admin_Password VARCHAR(50) NOT NULL,
PRIMARY KEY(Sys_Admin_User_ID),
);

CREATE TABLE TBL_RECRUITER_USER(
Recruiter_User_ID INT IDENTITY(1,1) NOT NULL, --PK
Recruiter_Login VARCHAR(20) NOT NULL,
Recruiter_Password VARCHAR(50) NOT NULL, 
PRIMARY KEY(Recruiter_User_ID),
CONSTRAINT UC_Recruiter_User UNIQUE (Recruiter_Login)
);

--DROP TABLE FINANCIAL_USER
CREATE TABLE TBL_FINANCIAL_USER (
Financial_User_ID INT IDENTITY(1,1) NOT NULL, --PK
Financial_User VARCHAR(20) NOT NULL, 
Financial_Password VARCHAR(50) NOT NULL,
PRIMARY KEY(Financial_User_ID),
CONSTRAINT UC_Financial_User UNIQUE (Financial_User)
);

CREATE TABLE TBL_USER_LOG(
Id_Record_Number INT IDENTITY(1,1) Not null, --PK
Event_Logged VARCHAR(200),
DATE_Logged DATE,
FK_Student_ID INT NOT NULL,
FK_Sys_Admin_User_ID INT NOT NULL,  
FK_Recruiter_User_ID INT NOT NULL,
FK_Financial_User_ID INT NOT NULL,
PRIMARY KEY(Id_Record_Number),
CONSTRAINT FK_Student_ID FOREIGN KEY (FK_Student_ID) REFERENCES STUDENT(Student_ID),
CONSTRAINT FK_Sys_Admin_User_ID FOREIGN KEY (FK_Sys_Admin_User_ID) REFERENCES SYS_ADMIN_USER(Sys_Admin_User_ID),
CONSTRAINT FK_Recruiter_User_ID FOREIGN KEY (FK_Recruiter_User_ID) REFERENCES RECRUITER_USER(Recruiter_User_ID),
CONSTRAINT FK_Financial_User_ID FOREIGN KEY (FK_Financial_User_ID) REFERENCES FINANCIAL_USER(Financial_User_ID)
);

GO
----------------------------------------------------------------------------------------------------------------------
---STORAGE PROCEDURES----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------

/**
-START
STORAGE PROCEDURES FOR STUDENT
**/

CREATE PROCEDURE [dbo].[SP_INSERT_TBL_STUDENT] 
        @SP_Insert_Student_ID INT,
        @SP_Insert_Banking_Student INT,
        @SP_Insert_User_Active_Status INT,
        @SP_Insert_Entry_DATE DATE,
        @SP_Insert_First_Name VARCHAR(200),
        @SP_Insert_Second_Name VARCHAR(200),
        @SP_Insert_Last_Name VARCHAR(200),
        @SP_Insert_Second_Last_Name VARCHAR(200),
        @SP_Insert_Id_Type INT,
        @SP_Insert_Id_Number INT,
        @SP_Insert_Birthdate DATE,
        @SP_Insert_Sex INT,
        @SP_Insert_Primary_Phone VARCHAR(200),
        @SP_Insert_Secondary_Phone VARCHAR(200),
        @SP_Insert_Email VARCHAR(200),
        @SP_Insert_Laboral_Status INT,
        @SP_Insert_Work_Address VARCHAR(200),
        @SP_Insert_Laboral_Experience INT,
        @SP_Insert_Student_User VARCHAR(20),
        @SP_Insert_Student_Password VARCHAR(50),
        @SP_Insert_Province VARCHAR(200),
        @SP_Insert_Canton VARCHAR(200),
        @SP_Insert_District VARCHAR(200)
AS
        INSERT INTO [dbo].[TBL_STUDENT] VALUES (@SP_Insert_Student_ID,
                @SP_Insert_Banking_Student,
                @SP_Insert_User_Active_Status,
                @SP_Insert_Entry_DATE,
                @SP_Insert_First_Name,
                @SP_Insert_Second_Name,
                @SP_Insert_Last_Name,
                @SP_Insert_Second_Last_Name,
                @SP_Insert_Id_Type,
                @SP_Insert_Id_Number,
                @SP_Insert_Birthdate,
                @SP_Insert_Sex,
                @SP_Insert_Primary_Phone,
                @SP_Insert_Secondary_Phone,
                @SP_Insert_Email,
                @SP_Insert_Laboral_Status,
                @SP_Insert_Work_Address,
                @SP_Insert_Laboral_Experience,
                @SP_Insert_Student_User,
                @SP_Insert_Student_Password,
                @SP_Insert_Province,
                @SP_Insert_Canton,
                @SP_Insert_District);
GO

/**
-END
STORAGE PROCEDURES FOR STUDENT
**/
