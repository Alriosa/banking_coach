USE master
GO

DROP DATABASE BANKING_COACH_DB;
GO

CREATE DATABASE BANKING_COACH_DB;
GO

USE BANKING_COACH_DB;

CREATE TABLE TBL_STUDENT(
Student_ID INT IDENTITY(1,1) NOT NULL, --PK
Banking_Student VARCHAR(1) NOT NULL DEFAULT '1',
User_Active_Status VARCHAR(1) NOT NULL DEFAULT '1', /*True or False*/
Entry_Date DATE NOT NULL,
First_Name VARCHAR(200) NOT NULL,
Second_Name VARCHAR(200),
Last_Name VARCHAR(200) NOT NULL,
Second_Last_Name VARCHAR(200) NOT NULL,
Id_Type VARCHAR(1) NOT NULL,
Identification_Number VARCHAR(20) NOT NULL, ---MUST BE UNIQUE ---
Birthdate DATE NOT NULL,
Gender VARCHAR(1) NOT NULL,
Primary_Phone VARCHAR(200) NOT NULL, ---MUST BE UNIQUE ---
Secondary_Phone VARCHAR(200),
Email VARCHAR(200) NOT NULL,
Laboral_Status VARCHAR(1) NOT NULL, /*True or False*/
Work_Address VARCHAR(200) NOT NULL,
Laboral_Experience VARCHAR(1) NOT NULL,
Student_User VARCHAR(20) NOT NULL,---MUST BE UNIQUE ---
Student_Password VARCHAR(50) NOT NULL,
Province VARCHAR(200) NOT NULL,
Canton VARCHAR(200) NOT NULL,
District VARCHAR(200) NOT NULL,
User_Type VARCHAR(1)  NOT NULL DEFAULT '2',
PRIMARY KEY(Student_ID),
CONSTRAINT UC_Student UNIQUE (Identification_Number,
                               Student_User,
                               Student_Password)
);

CREATE TABLE TBL_SYS_ADMIN_USER(
Sys_Admin_User_ID INT IDENTITY(1,1) NOT NULL, --PK
Admin_Login VARCHAR(20) NOT NULL, 
Admin_Password VARCHAR(50) NOT NULL,
User_Active_Status VARCHAR(1) NOT NULL DEFAULT '1', /*True or False*/
User_Type VARCHAR(1) NOT NULL  DEFAULT '1',
PRIMARY KEY(Sys_Admin_User_ID),
);

--CREATE TABLE FINANCIAL_USER
CREATE TABLE TBL_FINANCIAL_USER (
Financial_User_ID INT IDENTITY(1,1) NOT NULL, --PK
Financial_User VARCHAR(20) NOT NULL, 
Financial_Password VARCHAR(50) NOT NULL,
User_Active_Status VARCHAR(1) NOT NULL DEFAULT '1', /*True or False*/
User_Type VARCHAR(1) NOT NULL DEFAULT '4',
PRIMARY KEY(Financial_User_ID),
CONSTRAINT UC_Financial_User UNIQUE (Financial_User)
);

CREATE TABLE TBL_RECRUITER_USER(
Recruiter_User_ID INT IDENTITY(1,1) NOT NULL, --PK
Recruiter_Login VARCHAR(20) NOT NULL,
Recruiter_Password VARCHAR(50) NOT NULL, 
User_Active_Status VARCHAR(1) NOT NULL DEFAULT '1', /*True or False*/
User_Type VARCHAR(1) NOT NULL DEFAULT '3',
Finantial_Association INT NOT NULL,
PRIMARY KEY(Recruiter_User_ID),
CONSTRAINT UC_Recruiter_User UNIQUE (Recruiter_Login),
CONSTRAINT FK_Financial_Association_ID FOREIGN KEY (Finantial_Association) REFERENCES TBL_FINANCIAL_USER(Financial_User_ID)
);

CREATE TABLE TBL_USER_LOG(
Id_Record_Number INT IDENTITY(1,1) Not null, --PK
Event_Logged VARCHAR(200),
Date_Logged DATETIME,
Student_ID INT NOT NULL,
Sys_Admin_User_ID INT NOT NULL,  
Recruiter_User_ID INT NOT NULL,
Financial_User_ID INT NOT NULL,
PRIMARY KEY(Id_Record_Number),
CONSTRAINT FK_Student_ID FOREIGN KEY (Student_ID) REFERENCES TBL_STUDENT(Student_ID),
CONSTRAINT FK_Sys_Admin_ID FOREIGN KEY (Sys_Admin_User_ID) REFERENCES TBL_SYS_ADMIN_USER(Sys_Admin_User_ID),
CONSTRAINT FK_Recruiter_ID FOREIGN KEY (Recruiter_User_ID) REFERENCES TBL_RECRUITER_USER(Recruiter_User_ID),
CONSTRAINT FK_Financial_ID FOREIGN KEY (Financial_User_ID) REFERENCES TBL_FINANCIAL_USER(Financial_User_ID)
);

GO

----------------------------------------------------------------------------------------------------------------------
---INSERTS EMPTYS----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT TBL_STUDENT ON

INSERT INTO TBL_STUDENT (Student_ID, Banking_Student,User_Active_Status, Entry_Date,First_Name,Second_Name,
Last_Name,Second_Last_Name,Id_Type,Identification_Number, Birthdate,Gender,Primary_Phone, Secondary_Phone,
Email,Laboral_Status,Work_Address,Laboral_Experience,Student_User,Student_Password,Province,Canton,District) VALUES (
	0,'','0','2022-03-27','DEFAULT','','','','0',0,'2022-03-27','O','0','','DEFAULT','','','','S_DEFAULT','DEFAULT', 'DEFAULT','DEFAULT','DEFAULT');

SET IDENTITY_INSERT TBL_STUDENT OFF

SET IDENTITY_INSERT TBL_SYS_ADMIN_USER ON

INSERT INTO TBL_SYS_ADMIN_USER(Sys_Admin_User_ID, Admin_Login,Admin_Password, User_Active_Status) VALUES (
	0,'A_DEFAULT','DEFAULT','0');
GO

SET IDENTITY_INSERT TBL_SYS_ADMIN_USER OFF
GO

SET IDENTITY_INSERT TBL_FINANCIAL_USER ON

INSERT INTO TBL_FINANCIAL_USER (Financial_User_ID, Financial_User,Financial_Password, User_Active_Status) VALUES ( 0, 'F_DEFAULT', 'DEFAULT', '0');
GO

SET IDENTITY_INSERT TBL_FINANCIAL_USER OFF
GO

SET IDENTITY_INSERT TBL_RECRUITER_USER ON

INSERT INTO TBL_RECRUITER_USER (Recruiter_User_ID, Recruiter_Login,Recruiter_Password, User_Active_Status,Finantial_Association ) VALUES ( 0, 'R_DEFAULT', 'DEFAULT', '0', 0);
GO 

SET IDENTITY_INSERT TBL_RECRUITER_USER OFF

------------------------------------------------------------------------------------------------------------------------
--- VIEWS ----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------
GO 

CREATE VIEW VW_ALL_USER_LOGIN
AS 
	SELECT TB_USER_LOGIN.User_Login, TB_USER_LOGIN.User_Password, TB_USER_LOGIN.User_Type, TB_USER_LOGIN.User_Active_Status FROM (
			SELECT Student_User AS 'User_Login', Student_Password AS 'User_Password', User_Type, User_Active_Status FROM dbo.TBL_STUDENT
			UNION ALL
			SELECT Admin_Login AS 'User_Login', Admin_Password AS 'User_Password', User_Type, User_Active_Status FROM dbo.TBL_SYS_ADMIN_USER
			UNION ALL
			SELECT Recruiter_Login AS 'User_Login', Recruiter_Password AS 'User_Password', User_Type, User_Active_Status FROM dbo.TBL_RECRUITER_USER
			UNION ALL
			SELECT Financial_User AS 'User_Login', Financial_Password AS 'User_Password', User_Type, User_Active_Status FROM dbo.TBL_FINANCIAL_USER
		) AS TB_USER_LOGIN
GO

----------------------------------------------------------------------------------------------------------------------
---STORAGE PROCEDURES----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------

/**
-START
STORAGE PROCEDURES FOR STUDENT
**/

CREATE PROCEDURE [dbo].[SP_INSERT_TBL_STUDENT] 
       
        @SP_Banking_Student VARCHAR(1),
        @SP_User_Active_Status VARCHAR(1),
        @SP_Entry_DATE DATE,
        @SP_First_Name VARCHAR(200),
        @SP_Second_Name VARCHAR(200),
        @SP_Last_Name VARCHAR(200),
        @SP_Second_Last_Name VARCHAR(200),
        @SP_Id_Type VARCHAR(1),
        @SP_Identification_Number VARCHAR(20),
        @SP_Birthdate DATE,
        @SP_Gender VARCHAR(1),
        @SP_Primary_Phone VARCHAR(200),
        @SP_Secondary_Phone VARCHAR(200),
        @SP_Email VARCHAR(200),
        @SP_Laboral_Status VARCHAR(1),
        @SP_Work_Address VARCHAR(200),
        @SP_Laboral_Experience VARCHAR(1),
        @SP_Student_User VARCHAR(20),
        @SP_Student_Password VARCHAR(50),
        @SP_Province VARCHAR(200),
        @SP_Canton VARCHAR(200),
        @SP_District VARCHAR(200)
AS
        INSERT INTO [dbo].[TBL_STUDENT] VALUES (
                @SP_Banking_Student,
                @SP_User_Active_Status,
                @SP_Entry_DATE,
                @SP_First_Name,
                @SP_Second_Name,
                @SP_Last_Name,
                @SP_Second_Last_Name,
                @SP_Id_Type,
                @SP_Identification_Number,
                @SP_Birthdate,
                @SP_Gender,
                @SP_Primary_Phone,
                @SP_Secondary_Phone,
                @SP_Email,
                @SP_Laboral_Status,
                @SP_Work_Address,
                @SP_Laboral_Experience,
                @SP_Student_User,
                @SP_Student_Password,
                @SP_Province,
                @SP_Canton,
                @SP_District,
				2);
GO

---SELECT ALL
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_STUDENT]
AS
        SELECT * FROM [dbo].[TBL_STUDENT];
GO

---BY IDENTIFICATION NUMBER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_IDENTIFICATION]
        @SP_Identification_Number VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_STUDENT] WHERE Identification_Number = @SP_Identification_Number;
GO

---BY EMAIL
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_EMAIL]
        @SP_Student_Email VARCHAR(200)
AS
        SELECT * FROM [dbo].[TBL_STUDENT] WHERE Email = @SP_Student_Email;
GO

---BY USER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_USER]
        @SP_Student_User VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_STUDENT] WHERE Student_User = @SP_Student_User;
GO

---BY FIRSTNAME AND LASTNAME
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_FIRST_NAME_AND_LAST_NAME]
        @SP_First_Name VARCHAR(200),
        @SP_Last_Name VARCHAR(200)
AS
        SELECT * FROM [dbo].[TBL_STUDENT] WHERE First_Name = @SP_First_Name AND Last_Name = @SP_Last_Name;
GO

--- UPDATE STUDENT
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_STUDENT]
        @SP_Student_ID INT,
        @SP_Banking_Student VARCHAR(1),
        @SP_User_Active_Status VARCHAR(1),
        @SP_Entry_DATE DATE,
        @SP_First_Name VARCHAR(200),
        @SP_Second_Name VARCHAR(200),
        @SP_Last_Name VARCHAR(200),
        @SP_Second_Last_Name VARCHAR(200),
        @SP_Id_Type VARCHAR(1),
        @SP_Identification_Number INT,
        @SP_Birthdate DATE,
        @SP_Gender VARCHAR(1),
        @SP_Primary_Phone VARCHAR(200),
        @SP_Secondary_Phone VARCHAR(200),
        @SP_Email VARCHAR(200),
        @SP_Laboral_Status VARCHAR(1),
        @SP_Work_Address VARCHAR(200),
        @SP_Laboral_Experience VARCHAR(1),
        @SP_Student_User VARCHAR(20),
        @SP_Student_Password VARCHAR(50),
        @SP_Province VARCHAR(200),
        @SP_Canton VARCHAR(200),
        @SP_District VARCHAR(200)
AS
        UPDATE [dbo].[TBL_STUDENT] SET
                Banking_Student=@SP_Banking_Student,
                User_Active_Status=@SP_User_Active_Status,
                Entry_Date=@SP_Entry_Date,
                First_Name=@SP_First_Name,
                Second_Name=@SP_Second_Name,
                Last_Name=@SP_Last_Name,
                Second_Last_Name=@SP_Second_Last_Name,
                Id_Type=@SP_Id_Type,
                Identification_Number=@SP_Identification_Number,
                Birthdate=@SP_Birthdate,
                Gender=@SP_Gender,
                Primary_Phone=@SP_Primary_Phone,
                Secondary_Phone=@SP_Secondary_Phone,
                Email=@SP_Email,
                Laboral_Status=@SP_Laboral_Status,
                Work_Address=@SP_Work_Address,
                Laboral_Experience=@SP_Laboral_Experience,
                Student_User=@SP_Student_User,
                Student_Password=@SP_Student_Password,
                Province=@SP_Province,
                Canton=@SP_Canton,
                District=@SP_District
                WHERE Student_ID = @SP_Student_ID;
GO

---DELETE STUDENT
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_STUDENT]
        @SP_Student_ID INT
AS
        DELETE FROM [dbo].[TBL_STUDENT] WHERE Student_ID = @SP_Student_ID;
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
        @SP_Admin_Login VARCHAR(20),
        @SP_Admin_Password VARCHAR(50),
        @SP_User_Active_Status VARCHAR(1)
AS
        INSERT INTO [dbo].[TBL_SYS_ADMIN_USER]
        VALUES
                (@SP_Admin_Login,
                @SP_Admin_Password,
                @SP_User_Active_Status,
				'1');
GO


---SELECT ADMIN BY ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_ADMIN_USER_BY_ID]
        @SP_Admin_ID INT
AS
        SELECT * FROM [dbo].[TBL_SYS_ADMIN_USER] WHERE Sys_Admin_User_ID = @SP_Admin_ID;
GO


---SELECT ADMIN BY ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_ADMIN_USER]
        @SP_Admin_Login VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_SYS_ADMIN_USER] WHERE Admin_Login = @SP_Admin_Login;
GO

---SELECT ALL ADMINS
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_ADMIN_USER]
AS
        SELECT * FROM [dbo].[TBL_SYS_ADMIN_USER];
GO

---UPDATE ADMIN STATUS
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_ADMIN_USER_STATUS]
        @SP_Admin_Login VARCHAR(20),
        @SP_Admin_Status VARCHAR(1)
AS
        UPDATE [dbo].[TBL_SYS_ADMIN_USER] SET
                User_Active_Status=@SP_Admin_Status
                WHERE Admin_Login = @SP_Admin_Login;
GO

---UPDATE ADMIN PASSWORD
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_ADMIN_USER_PASSWORD]
        @SP_Admin_Login VARCHAR(20),
        @SP_Admin_Password VARCHAR(50)
AS
        UPDATE [dbo].[TBL_SYS_ADMIN_USER] SET
                Admin_Password=@SP_Admin_Password
                WHERE Admin_Login = @SP_Admin_Login;                
GO

---DELETE ADMIN
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_ADMIN_USER]
        @SP_Admin_Login VARCHAR(20)
AS	
        DELETE FROM [dbo].[TBL_SYS_ADMIN_USER] WHERE Admin_Login = @SP_Admin_Login;
GO

--SOFT DELETE ADMIN
CREATE PROCEDURE [dbo].[SP_SOFT_DELETE_TBL_ADMIN_USER]
        @SP_Admin_Login VARCHAR(20)
AS	
		UPDATE [dbo].[TBL_SYS_ADMIN_USER] SET
				 User_Active_Status ='0'
				 WHERE Admin_Login = @SP_Admin_Login; 
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
        @SP_Recruiter_Login VARCHAR(20),
        @SP_Recruiter_Password VARCHAR(50),
        @SP_User_Active_Status VARCHAR(1),
        @SP_Finantial_Association INT
AS
        INSERT INTO [dbo].[TBL_RECRUITER_USER]
        VALUES
                (@SP_Recruiter_Login,
                @SP_Recruiter_Password,
                @SP_User_Active_Status,
				'3',
				@SP_Finantial_Association
				);
GO

--- SELECT BY USER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_RECRUITER_USER]
        @SP_Recruiter_Login VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_RECRUITER_USER] WHERE Recruiter_Login = @SP_Recruiter_Login;
GO

CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_RECRUITER_USER]
AS
        SELECT * FROM [dbo].[TBL_RECRUITER_USER];
GO


--- UPDATE RECRUITER STATUS
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_RECRUITER_USER_STATUS]
        @SP_Recruiter_Login VARCHAR(20),
        @SP_User_Active_Status VARCHAR(1)
AS
        UPDATE [dbo].[TBL_RECRUITER_USER] SET
                Recruiter_Login=@SP_Recruiter_Login,
                User_Active_Status=@SP_User_Active_Status
                WHERE Recruiter_Login = @SP_Recruiter_Login;
GO

CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_RECRUITER_USER_PASSWORD]
        @SP_Recruiter_Login VARCHAR(20),
        @SP_Recruiter_Password VARCHAR(50)
AS
        UPDATE [dbo].[TBL_RECRUITER_USER] SET
                Recruiter_Login=@SP_Recruiter_Login,
                Recruiter_Password=@SP_Recruiter_Password
                WHERE Recruiter_Login = @SP_Recruiter_Login;
GO

---DELETE RECRUITER
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_RECRUITER_USER]
        @SP_Recruiter_Login VARCHAR(20)
AS
        DELETE FROM [dbo].[TBL_RECRUITER_USER] WHERE Recruiter_Login = @SP_Recruiter_Login;
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
        @SP_Financial_User VARCHAR(20),
        @SP_Financial_Password VARCHAR(50),
        @SP_User_Active_Status VARCHAR(1)
AS
        INSERT INTO [dbo].[TBL_FINANCIAL_USER]
        VALUES
                (@SP_Financial_User,
                @SP_Financial_Password,
                @SP_User_Active_Status,
				'4');
GO

--- SELECT BY FINANCIAL USER ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_FINANCIAL_USER_BY_ID]
        @SP_Financial_User_ID INT
AS
        SELECT * FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User_ID = @SP_Financial_User_ID;
GO


--- SELECT BY FINANCIAL USER LOGIN
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_FINANCIAL_USER]
        @SP_Financial_User VARCHAR(20)
AS
        SELECT * FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User = @SP_Financial_User;
GO

CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_FINANCIAL_USER]
AS
        SELECT * FROM [dbo].[TBL_FINANCIAL_USER]
GO

CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_FINANCIAL_USER_STATUS]
        @SP_Financial_User VARCHAR(20),
        @SP_User_Active_Status VARCHAR(1)
AS
        UPDATE [dbo].[TBL_FINANCIAL_USER] SET
                Financial_User=@SP_Financial_User,
                User_Active_Status=@SP_User_Active_Status
                WHERE Financial_User = @SP_Financial_User;
GO


---DELETE FINANCIAL
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_FINANCIAL_USER]
        @SP_Financial_User VARCHAR(20)
AS
        DELETE FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User = @SP_Financial_User;
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
        @SP_User_Log_Event_Logged VARCHAR(200),
        @SP_User_Log_Event_Date DATETIME,
		@SP_User_Log_Event_User_ID INT,
        @SP_User_Log_Event_Type VARCHAR(1) -- 1-SYS ADMIN; 2-STUDENT; 3-RECRUITER; 4-FINANCIAL
AS
		BEGIN
			DECLARE @ID_SYS_ADMIN VARCHAR(1) --TYPE 1
			DECLARE @ID_STUDENT VARCHAR(1) --TYPE 2
			DECLARE @ID_RECRUITER VARCHAR(1) --TYPE 3
			DECLARE @ID_FINANCIAL VARCHAR(1) --TYPE 4

			SET @ID_SYS_ADMIN = CASE @SP_User_Log_Event_Type
					WHEN '1' THEN @SP_User_Log_Event_User_ID
					ELSE '0'
				END
				
			SET @ID_STUDENT = CASE @SP_User_Log_Event_Type
					WHEN '2' THEN @SP_User_Log_Event_User_ID
					ELSE '0'
				END

			SET @ID_RECRUITER = CASE @SP_User_Log_Event_Type
					WHEN '3' THEN @SP_User_Log_Event_User_ID
					ELSE '0'
				END
				
			SET @ID_FINANCIAL = CASE @SP_User_Log_Event_Type
					WHEN '4' THEN @SP_User_Log_Event_User_ID
					ELSE '0'
				END

			INSERT INTO [dbo].[TBL_USER_LOG]
			VALUES
			(@SP_User_Log_Event_Logged,
			@SP_User_Log_Event_Date,
			@ID_STUDENT,
			@ID_SYS_ADMIN,
			@ID_RECRUITER,
			@ID_FINANCIAL);
		END	
GO

---SELECT USER LOG BY ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_USER_LOG_BY_ID]
        @SP_User_Log_ID INT
AS
        SELECT * FROM [dbo].[TBL_USER_LOG] WHERE Id_Record_Number = @SP_User_Log_ID;
GO

---SELECT ALL USER LOGS
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_USER_LOG]
AS
        SELECT * FROM [dbo].[TBL_USER_LOG];
GO

---SELECT USER LOGS BY STUDENT
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_USER_LOG_BY_STUDENT]
			@SP_User_Log_Event_User_ID INT
AS
        SELECT * FROM [dbo].[TBL_USER_LOG] WHERE Student_ID = @SP_User_Log_Event_User_ID;
GO


---SELECT USER LOGS BY SYS ADMIN
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_USER_LOG_BY_SYS_ADMIN]
			@SP_User_Log_Event_User_ID INT 
AS
        SELECT * FROM [dbo].[TBL_USER_LOG] WHERE Sys_Admin_User_ID = @SP_User_Log_Event_User_ID;
GO

---SELECT USER LOGS BY RECRUITER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_USER_LOG_BY_RECRUITER]
			@SP_User_Log_Event_User_ID INT 
AS

        SELECT * FROM [dbo].[TBL_USER_LOG] WHERE Recruiter_User_ID = @SP_User_Log_Event_User_ID;
GO

---SELECT USER LOGS BY FINANCIAL
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_USER_LOG_BY_FINANCIAL]
			@SP_User_Log_Event_User_ID INT 
AS

        SELECT * FROM [dbo].[TBL_USER_LOG] WHERE Financial_User_ID = @SP_User_Log_Event_User_ID;
GO

/**
-END
STORAGE PROCEDURES FOR USER LOG
**/

/**
-START
STORAGE PROCEDURES FOR LOGIN
**/

--verify user name existence
--RETURN 0 IF DONT EXIST OR 1 IF EXIST

CREATE PROCEDURE [dbo].[SP_VERIFY_USERNAME]
        @SP_User_Login VARCHAR(20)
AS
	BEGIN
		DECLARE @COUNT_LOGIN_USERNAME INT 
		DECLARE @USER_EXIST VARCHAR(1) = '0'

		SELECT @COUNT_LOGIN_USERNAME =  COUNT(User_Login) FROM VW_ALL_USER_LOGIN WHERE User_Login = @SP_User_Login

		IF @COUNT_LOGIN_USERNAME > 0 
		BEGIN 
			SET @USER_EXIST = '1'
		END 

		SELECT @USER_EXIST AS 'Login'
	END
GO

-- USER LOGIN PROCEDURE:
--- RETURN:
-------- 0 IF NOT USER EXISTS
-------- 1 IF PASSWORD INCORRECT
-------- 2 IF STATUS INACTIVE
-------- 3 IF STATUS ACTIVE

CREATE PROCEDURE [dbo].[SP_LOGIN]
	    @SP_User_Login VARCHAR(20),
        @SP_User_Password VARCHAR(20)
AS
BEGIN
	DECLARE @RESULT VARCHAR(1) = '0'
	DECLARE @GET_LOGIN VARCHAR(20) = 'NO'
	DECLARE @GET_PASS VARCHAR(20) = 'NO'
	DECLARE @GET_USER_TYPE VARCHAR(1) = '0'
	DECLARE @GET_STATUS VARCHAR(1) = '0'

	SELECT @GET_LOGIN = VW_USER.User_Login FROM VW_ALL_USER_LOGIN AS VW_USER
	WHERE VW_USER.User_Login = @SP_User_Login

	SELECT @GET_PASS= VW_USER.User_Password FROM VW_ALL_USER_LOGIN AS VW_USER
	WHERE VW_USER.User_Login = @SP_User_Login

	SELECT @GET_USER_TYPE = VW_USER.User_Type FROM VW_ALL_USER_LOGIN AS VW_USER
	WHERE VW_USER.User_Login = @SP_User_Login

	SELECT @GET_STATUS = VW_USER.User_Active_Status FROM VW_ALL_USER_LOGIN AS VW_USER
	WHERE VW_USER.User_Login = @SP_User_Login

	SELECT @RESULT = CASE 
		WHEN @GET_LOGIN = 'NO' THEN '0' -- IF NOT USER EXISTS
		WHEN @GET_PASS != @SP_User_Password THEN '1' -- PASSWORD IS INCORRECT
		WHEN @GET_STATUS = '0' THEN '2' -- STATUS INACTIVE
		WHEN @GET_STATUS = '1' THEN '3' -- STATUS ACTIVE
	END 
	SELECT @RESULT AS 'Result', @GET_LOGIN AS 'User_Login', @GET_USER_TYPE AS 'User_Type', @GET_STATUS AS 'User_Active_Status';
END
GO
/**
-END 
STORAGE PROCEDURES FOR USER LOG
**/