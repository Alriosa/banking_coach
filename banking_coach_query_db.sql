USE master;
DROP DATABASE BANKING_COACH_DB;
GO
CREATE DATABASE BANKING_COACH_DB;
GO

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
Identification_Number INT NOT NULL, ---MUST BE UNIQUE ---
Birthdate DATE NOT NULL,
Gender INT NOT NULL,
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
CONSTRAINT UC_Student UNIQUE (Identification_Number,
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
Recruiter_Status INT NOT NULL, /*True or False*/
PRIMARY KEY(Recruiter_User_ID),
CONSTRAINT UC_Recruiter_User UNIQUE (Recruiter_Login)
);

--DROP TABLE FINANCIAL_USER
CREATE TABLE TBL_FINANCIAL_USER (
Financial_User_ID INT IDENTITY(1,1) NOT NULL, --PK
Financial_User VARCHAR(20) NOT NULL, 
Financial_Password VARCHAR(50) NOT NULL,
Financial_Status INT NOT NULL, /*True or False*/
PRIMARY KEY(Financial_User_ID),
CONSTRAINT UC_Financial_User UNIQUE (Financial_User)
);

CREATE TABLE TBL_USER_LOG(
Id_Record_Number INT IDENTITY(1,1) Not null, --PK
Event_Logged VARCHAR(200),
Date_Logged DATETIME,
FK_Student_ID INT NOT NULL,
FK_Sys_Admin_User_ID INT NOT NULL,  
FK_Recruiter_User_ID INT NOT NULL,
FK_Financial_User_ID INT NOT NULL,
PRIMARY KEY(Id_Record_Number),
CONSTRAINT FK_Student_ID FOREIGN KEY (FK_Student_ID) REFERENCES TBL_STUDENT(Student_ID),
CONSTRAINT FK_Sys_Admin_User_ID FOREIGN KEY (FK_Sys_Admin_User_ID) REFERENCES TBL_SYS_ADMIN_USER(Sys_Admin_User_ID),
CONSTRAINT FK_Recruiter_User_ID FOREIGN KEY (FK_Recruiter_User_ID) REFERENCES TBL_RECRUITER_USER(Recruiter_User_ID),
CONSTRAINT FK_Financial_User_ID FOREIGN KEY (FK_Financial_User_ID) REFERENCES TBL_FINANCIAL_USER(Financial_User_ID)
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
       
        @SP_Insert_Banking_Student INT,
        @SP_Insert_User_Active_Status INT,
        @SP_Insert_Entry_DATE DATE,
        @SP_Insert_First_Name VARCHAR(200),
        @SP_Insert_Second_Name VARCHAR(200),
        @SP_Insert_Last_Name VARCHAR(200),
        @SP_Insert_Second_Last_Name VARCHAR(200),
        @SP_Insert_Id_Type INT,
        @SP_Insert_Identification_Number INT,
        @SP_Insert_Birthdate DATE,
        @SP_Insert_Gender INT,
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
        INSERT INTO [dbo].[TBL_STUDENT] VALUES (
                @SP_Insert_Banking_Student,
                @SP_Insert_User_Active_Status,
                @SP_Insert_Entry_DATE,
                @SP_Insert_First_Name,
                @SP_Insert_Second_Name,
                @SP_Insert_Last_Name,
                @SP_Insert_Second_Last_Name,
                @SP_Insert_Id_Type,
                @SP_Insert_Identification_Number,
                @SP_Insert_Birthdate,
                @SP_Insert_Gender,
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

---SELECT ALL
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_STUDENT]
AS
        SELECT * FROM [dbo].[TBL_STUDENT];
GO

---BY IDENTIFICATION NUMBER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_IDENTIFICATION]
        @SP_SELECT_STUDENT_BY_IDENTIFICATION INT
AS
        SELECT * FROM [dbo].[TBL_STUDENT] WHERE Identification_Number = @SP_SELECT_STUDENT_BY_IDENTIFICATION;
GO

---BY EMAIL
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_EMAIL]
        @SP_Select_Student_Email VARCHAR(200)
AS
        SELECT * FROM [dbo].[TBL_STUDENT] WHERE Email = @SP_Select_Student_Email;
GO


---BY USER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_USER]
        @SP_Select_Student_User VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_STUDENT] WHERE Student_User = @SP_Select_Student_User;
GO


---BY FIRSTNAME AND LASTNAME
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_FIRST_NAME_AND_LAST_NAME]
        @SP_Select_First_Name VARCHAR(200),
        @SP_Select_Last_Name VARCHAR(200)
AS
        SELECT * FROM [dbo].[TBL_STUDENT] WHERE First_Name = @SP_Select_First_Name AND Last_Name = @SP_Select_Last_Name;
GO

--- UPDATE STUDENT
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_STUDENT]
        @SP_Insert_Student_ID INT,
        @SP_Insert_Banking_Student INT,
        @SP_Insert_User_Active_Status INT,
        @SP_Insert_Entry_DATE DATE,
        @SP_Insert_First_Name VARCHAR(200),
        @SP_Insert_Second_Name VARCHAR(200),
        @SP_Insert_Last_Name VARCHAR(200),
        @SP_Insert_Second_Last_Name VARCHAR(200),
        @SP_Insert_Id_Type INT,
        @SP_Insert_Identification_Number INT,
        @SP_Insert_Birthdate DATE,
        @SP_Insert_Gender INT,
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
        UPDATE [dbo].[TBL_STUDENT] SET
                Banking_Student=@SP_Insert_Banking_Student,
                User_Active_Status=@SP_Insert_User_Active_Status,
                Entry_Date=@SP_Insert_Entry_Date,
                First_Name=@SP_Insert_First_Name,
                Second_Name=@SP_Insert_Second_Name,
                Last_Name=@SP_Insert_Last_Name,
                Second_Last_Name=@SP_Insert_Second_Last_Name,
                Id_Type=@SP_Insert_Id_Type,
                Identification_Number=@SP_Insert_Identification_Number,
                Birthdate=@SP_Insert_Birthdate,
                Gender=@SP_Insert_Gender,
                Primary_Phone=@SP_Insert_Primary_Phone,
                Secondary_Phone=@SP_Insert_Secondary_Phone,
                Email=@SP_Insert_Email,
                Laboral_Status=@SP_Insert_Laboral_Status,
                Work_Address=@SP_Insert_Work_Address,
                Laboral_Experience=@SP_Insert_Laboral_Experience,
                Student_User=@SP_Insert_Student_User,
                Student_Password=@SP_Insert_Student_Password,
                Province=@SP_Insert_Province,
                Canton=@SP_Insert_Canton,
                District=@SP_Insert_District
                WHERE Student_ID = @SP_Insert_Student_ID;
GO

---DELETE STUDENT
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_STUDENT]
        @SP_Delete_Student_ID INT
AS
        DELETE FROM [dbo].[TBL_STUDENT] WHERE Student_ID = @SP_Delete_Student_ID;
GO


/**
-END
STORAGE PROCEDURES FOR STUDENT
**/



/**
-START
STORAGE PROCEDURES FOR ADMIN USER
**/

CREATE PROCEDURE [dbo].[SP_INSERT_TBL_ADMIN_USER]
        @SP_Insert_Admin_User VARCHAR(20),
        @SP_Insert_Admin_Password VARCHAR(50),
        @SP_Insert_Admin_Status INT
AS
        INSERT INTO [dbo].[TBL_ADMIN_USER]
        VALUES
                (@SP_Insert_Admin_User,
                @SP_Insert_Admin_Password,
                @SP_Insert_Admin_Status);
GO

---SELECT ALL ADMINS
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_ADMIN_USER]
        @SP_Select_Admin_User VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_ADMIN_USER];
GO

---UPDATE ADMIN STATUS
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_ADMIN_USER_STATUS]
        @SP_Insert_Admin_User VARCHAR(20),
        @SP_Insert_Admin_Status INT
AS
        UPDATE [dbo].[TBL_ADMIN_USER] SET
                Admin_User=@SP_Insert_Admin_User,
                Admin_Status=@SP_Insert_Admin_Status
                WHERE Admin_User = @SP_Insert_Admin_User;
GO

---UPDATE ADMIN PASSWORD
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_ADMIN_USER_PASSWORD]
        @SP_Insert_Admin_User VARCHAR(20),
        @SP_Insert_Admin_Password VARCHAR(50)
AS
        UPDATE [dbo].[TBL_ADMIN_USER] SET
                Admin_User=@SP_Insert_Admin_User,
                Admin_Password=@SP_Insert_Admin_Password
                WHERE Admin_User = @SP_Insert_Admin_User;                
GO

---DELETE ADMIN
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_ADMIN_USER]
        @SP_Delete_Admin_User VARCHAR(20)
AS
        DELETE FROM [dbo].[TBL_ADMIN_USER] WHERE Admin_User = @SP_Delete_Admin_User;
GO

/**
-END
STORAGE PROCEDURES FOR ADMIN USER
**/

/**
-START
STORAGE PROCEDURES FOR RECRUITER USER
**/

CREATE PROCEDURE [dbo].[SP_INSERT_TBL_RECRUITER_USER]
        @SP_Insert_Recruiter_Login VARCHAR(20),
        @SP_Insert_Recruiter_Password VARCHAR(50),
        @SP_Insert_Recruiter_Status INT
AS
        INSERT INTO [dbo].[TBL_RECRUITER_USER]
        VALUES
                (@SP_Insert_Recruiter_Login,
                @SP_Insert_Recruiter_Password,
                @SP_Insert_Recruiter_Status);
GO


--- SELECT BY USER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_RECRUITER_USER]
        @SP_Select_Recruiter_Login VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_RECRUITER_USER] WHERE Recruiter_Login = @SP_Select_Recruiter_Login;
GO


--- UPDATE RECRUITER STATUS
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_RECRUITER_USER_STATUS]
        @SP_Insert_Recruiter_Login VARCHAR(20),
        @SP_Insert_Recruiter_Status INT
AS
        UPDATE [dbo].[TBL_RECRUITER_USER] SET
                Recruiter_Login=@SP_Insert_Recruiter_Login,
                Recruiter_Status=@SP_Insert_Recruiter_Status
                WHERE Recruiter_Login = @SP_Insert_Recruiter_Login;
GO

CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_RECRUITER_USER_PASSWORD]
        @SP_Insert_Recruiter_Login VARCHAR(20),
        @SP_Insert_Recruiter_Password VARCHAR(50)
AS
        UPDATE [dbo].[TBL_RECRUITER_USER] SET
                Recruiter_Login=@SP_Insert_Recruiter_Login,
                Recruiter_Password=@SP_Insert_Recruiter_Password
                WHERE Recruiter_Login = @SP_Insert_Recruiter_Login;
GO

---DELETE RECRUITER
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_RECRUITER_USER]
        @SP_Delete_Recruiter_Login VARCHAR(20)
AS
        DELETE FROM [dbo].[TBL_RECRUITER_USER] WHERE Recruiter_Login = @SP_Delete_Recruiter_Login;
GO

/**
-END
STORAGE PROCEDURES FOR RECRUITER USER
**/



/**
-START
STORAGE PROCEDURES FOR FINANCIAL USER
**/

CREATE PROCEDURE [dbo].[SP_INSERT_TBL_FINANCIAL_USER]
        @SP_Insert_Financial_User VARCHAR(20),
        @SP_Insert_Financial_Password VARCHAR(50),
        @SP_Insert_Financial_Status INT
AS
        INSERT INTO [dbo].[TBL_FINANCIAL_USER]
        VALUES
                (@SP_Insert_Financial_User,
                @SP_Insert_Financial_Password,
                @SP_Insert_Financial_Status);
GO


CREATE PROCEDURE [dbo].[SP_SELECT_TBL_FINANCIAL_USER]
        @SP_Select_Financial_User VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User = @SP_Select_Financial_User;
GO


CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_FINANCIAL_USER_STATUS]
        @SP_Insert_Financial_User VARCHAR(20),
        @SP_Insert_Financial_Status INT
AS
        UPDATE [dbo].[TBL_FINANCIAL_USER] SET
                Financial_User=@SP_Insert_Financial_User,
                Financial_Status=@SP_Insert_Financial_Status
                WHERE Financial_User = @SP_Insert_Financial_User;
GO

/**
-END
STORAGE PROCEDURES FOR FINANCIAL USER
**/

/**
-START
STORAGE PROCEDURES FOR USER LOG
**/

CREATE PROCEDURE [dbo].[SP_INSERT_TBL_USER_LOG]
        @SP_Insert_User_Log_Event_Logged VARCHAR(200),
        @SP_Insert_User_Log_Event_Date DATETIME,
        @SP_Insert_User_Log_Event_Type INT
AS
        INSERT INTO [dbo].[TBL_USER_LOG]
        VALUES
        (@SP_Insert_User_Log_Event_Logged,
        @SP_Insert_User_Log_Event_Date,
        @SP_Insert_User_Log_Event_Type);
GO


/**
-END
STORAGE PROCEDURES FOR USER LOG
**/