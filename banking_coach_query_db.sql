USE master
GO

DROP DATABASE BANKING_COACH_DB;
GO

CREATE DATABASE BANKING_COACH_DB;
GO

USE BANKING_COACH_DB;

CREATE TABLE TBL_STUDENT(
Student_ID INT IDENTITY(1,1) NOT NULL, --PK
Banking_Student VARCHAR(10) NOT NULL DEFAULT '1',
User_Active_Status VARCHAR(1) NOT NULL DEFAULT '1', /*True or False*/
Complete_Name VARCHAR(200) NOT NULL,
Id_Type VARCHAR(10) NOT NULL,
Identification_Number VARCHAR(20) NOT NULL, ---MUST BE UNIQUE ---
Birthdate DATETIME NOT NULL,
Age INT NOT NULL,
Email VARCHAR(200) NOT NULL UNIQUE,
Phone_Number VARCHAR(200) NOT NULL, ---MUST BE UNIQUE ---
Province VARCHAR(3) NOT NULL,
Canton VARCHAR(3) NOT NULL,
District VARCHAR(3) NOT NULL,
Laboral_Status VARCHAR(10) NOT NULL, /*True or False*/
Workstation VARCHAR(200) NOT NULL,
Experience VARCHAR(200) NOT NULL,
Laboral_Experience VARCHAR(200) NOT NULL,
Education_Status VARCHAR(10) NOT NULL,
Institution_Academic_Type VARCHAR(200) NOT NULL,
Institution_Academic_Name VARCHAR(200) NOT NULL,
Academic_Preparation VARCHAR(200) NOT NULL,
University_Level VARCHAR(200) NOT NULL,
University_Degree VARCHAR(200) NOT NULL,
Excel_Level VARCHAR(200) NOT NULL,
Job_Availability VARCHAR(10) NOT NULL,
Transport_Availability VARCHAR(200) NOT NULL,
Vehicle VARCHAR(10) NOT NULL,
Driver_Licenses VARCHAR(200) NOT NULL,
Courses_Banking_Coach VARCHAR(200) NOT NULL,
Teachers_Banking_Coach VARCHAR(200) NOT NULL,
Languages VARCHAR(200) NOT NULL,
Course_Date_Finish DATETIME NOT NULL,
Course_Day VARCHAR(200) NOT NULL,
Course_Schedule VARCHAR(200) NOT NULL,
Course_Place VARCHAR(200) NOT NULL,
Banking_Coach_Certificate VARCHAR(200) NOT NULL,
Curriculum VARCHAR(200) NOT NULL,
Agree_Job_Exchange VARCHAR(200) NOT NULL,
Student_User VARCHAR(20) NOT NULL,---MUST BE UNIQUE ---
Student_Password VARCHAR(50) NOT NULL,
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

CREATE TABLE LST_PROVINCES (
  Id int NOT NULL,
  Code VARCHAR(3) DEFAULT NULL,
  Name_Value varchar(45) DEFAULT NULL,
  PRIMARY KEY (Id)
) 

CREATE TABLE LST_CANTONS (
  Id int NOT NULL,
  P_Code VARCHAR(3) NOT NULL,
  Code VARCHAR(3) NOT NULL,
  Name_Value varchar(45) DEFAULT NULL,
  PRIMARY KEY (Id)
)

CREATE TABLE LST_DISTRICTS (
  Id int NOT NULL,
  P_Code VARCHAR(3) DEFAULT NULL,
  Code VARCHAR(3) DEFAULT NULL,
  Name_Value varchar(70) DEFAULT NULL,
  PRIMARY KEY (Id)
)

CREATE TABLE TBL_VIEWS (
	View_ID	INT IDENTITY(1,1) PRIMARY KEY NOT NULL, --PK
	Controller_Name VARCHAR(50) NOT NULL, 
	View_Name VARCHAR(50) NOT NULL,
	View_Description VARCHAR(50) NOT NULL,
	Group_View VARCHAR(50) NOT NULL
);


CREATE TABLE TBL_PERMISSIONS (
	Id_User_Type VARCHAR(1) NOT NULL, 
	Id_View INT NOT NULL,
	PRIMARY KEY NONCLUSTERED (Id_User_Type, Id_View),
	CONSTRAINT FK_VIEW_PERMISSION FOREIGN KEY (Id_View) REFERENCES TBL_VIEWS (View_ID)
);



----------------------------------------------------------------------------------------------------------------------
---INSERTS EMPTYS----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------

SET IDENTITY_INSERT TBL_STUDENT ON

INSERT INTO dbo.TBL_STUDENT
           (Student_ID, Banking_Student,User_Active_Status ,Complete_Name,Id_Type ,Identification_Number ,Birthdate ,Age ,Email ,Phone_Number ,Province ,Canton ,District ,Laboral_Status ,Workstation  ,Experience  ,Laboral_Experience ,Education_Status  ,Institution_Academic_Type  ,Institution_Academic_Name ,Academic_Preparation ,University_Level ,University_Degree  ,Excel_Level ,Job_Availability ,Transport_Availability,Vehicle ,Driver_Licenses ,Courses_Banking_Coach ,Teachers_Banking_Coach ,Languages ,Course_Date_Finish ,Course_Day ,Course_Schedule ,Course_Place ,Banking_Coach_Certificate ,Curriculum ,Agree_Job_Exchange ,Student_User ,Student_Password, User_Type)
     VALUES
           (0, '','0','DEFAULT','0' ,'0'  ,'2000-03-27',0 ,'' ,'' ,'1','01','01' ,'' ,'' ,'','','' ,'',''  ,''  ,'' ,'','' ,'' ,''  ,'' ,'' ,'' ,'' ,''  ,''  ,'' ,'' ,'' ,'','','','S_DEFAULT','DEFAULT','2')
GO



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




INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('1', '1', 'San José');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('2', '2', 'Alajuela');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('3', '3', 'Cartago');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('4', '4', 'Heredia');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('5', '5', 'Guanacaste');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('6', '6', 'Puntarenas');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('7', '7', 'Limón');

INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('1', '1', '01', 'San José');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('2', '1', '02', 'Escazú');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('3', '1', '03', 'Desamparados');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('4', '1', '04', 'Puriscal');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('5', '1', '05', 'Tarrazú');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('6', '1', '06', 'Aserrí');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('7', '1', '07', 'Mora');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('8', '1', '08', 'Goicoechea');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('9', '1', '09', 'Santa Ana');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('10', '1', '10', 'Alajuelita');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('11', '1', '11', 'Vásquez de Coronado');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('12', '1', '12', 'Acosta');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('13', '1', '13', 'Tibás');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('14', '1', '14', 'Moravia');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('15', '1', '15', 'Montes de Oca');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('16', '1', '16', 'Turrubares');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('17', '1', '17', 'Dota');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('18', '1', '18', 'Curridabat');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('19', '1', '19', 'Pérez Zeledón');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('20', '1', '20', 'León Cortéz Castro');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('21', '2', '01', 'Alajuela');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('22', '2', '02', 'San Ramón');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('23', '2', '03', 'Grecia');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('24', '2', '04', 'San Mateo');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('25', '2', '05', 'Atenas');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('26', '2', '06', 'Naranjo');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('27', '2', '07', 'Palmares');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('28', '2', '08', 'Poás');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('29', '2', '09', 'Orotina');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('30', '2', '10', 'San Carlos');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('31', '2', '11', 'Zarcero');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('32', '2', '12', 'Valverde Vega');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('33', '2', '13', 'Upala');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('34', '2', '14', 'Los Chiles');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('35', '2', '15', 'Guatuso');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('36', '3', '01', 'Cartago');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('37', '3', '02', 'Paraíso');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('38', '3', '03', 'La Unión');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('39', '3', '04', 'Jiménez');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('40', '3', '05', 'Turrialba');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('41', '3', '06', 'Alvarado');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('42', '3', '07', 'Oreamuno');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('43', '3', '08', 'El Guarco');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('44', '4', '01', 'Heredia');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('45', '4', '02', 'Barva');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('46', '4', '03', 'Santo Domingo');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('47', '4', '04', 'Santa Bárbara');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('48', '4', '05', 'San Rafaél');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('49', '4', '06', 'San Isidro');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('50', '4', '07', 'Belén');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('51', '4', '08', 'Flores');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('52', '4', '09', 'San Pablo');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('53', '4', '10', 'Sarapiquí');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('54', '5', '01', 'Liberia');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('55', '5', '02', 'Nicoya');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('56', '5', '03', 'Santa Cruz');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('57', '5', '04', 'Bagaces');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('58', '5', '05', 'Carrillo');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('59', '5', '06', 'Cañas');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('60', '5', '07', 'Abangáres');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('61', '5', '08', 'Tilarán');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('62', '5', '09', 'Nandayure');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('63', '5', '10', 'La Cruz');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('64', '5', '11', 'Hojancha');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('65', '6', '01', 'Puntarenas');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('66', '6', '02', 'Esparza');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('67', '6', '03', 'Buenos Aires');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('68', '6', '04', 'Montes de Oro');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('69', '6', '05', 'Osa');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('70', '6', '06', 'Aguirre');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('71', '6', '07', 'Golfito');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('72', '6', '08', 'Coto Brus');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('73', '6', '09', 'Parrita');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('74', '6', '10', 'Corredores');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('75', '6', '11', 'Garabito');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('76', '7', '01', 'Limón');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('77', '7', '02', 'Pococí');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('78', '7', '03', 'Siquirres');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('79', '7', '04', 'Talamanca');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('80', '7', '05', 'Matina');
INSERT INTO LST_CANTONS (id, p_code, code, name_value) VALUES ('81', '7', '06', 'Guácimo');



INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('1',  '01', '01', 'CARMEN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('2',  '01', '02', 'MERCED');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('3',  '01', '03', 'HOSPITAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('4',  '01', '04', 'CATEDRAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('5',  '01', '05', 'ZAPOTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('6',  '01', '06', 'SAN FRANCISCO DE DOS RÍOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('7',  '01', '07', 'URUCA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('8',  '01', '08', 'MATA REDONDA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('9',  '01', '09', 'PAVAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('10',  '01', '10', 'HATILLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('11',  '01', '11', 'SAN SEBASTIÁN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('12',  '02', '01', 'ESCAZÚ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('13',  '02', '02', 'SAN ANTONIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('14',  '02', '03', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('15',  '03', '01', 'DESAMPARADOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('16',  '03', '02', 'SAN MIGUEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('17',  '03', '03', 'SAN JUAN DE DIOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('18',  '03', '04', 'SAN RAFAEL ARRIBA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('19',  '03', '05', 'SAN ANTONIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('20',  '03', '06', 'FRAILES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('21',  '03', '07', 'PATARRÁ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('22',  '03', '08', 'SAN CRISTÓBAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('23',  '03', '09', 'ROSARIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('24',  '03', '10', 'DAMAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('25',  '03', '11', 'SAN RAFAEL ABAJO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('26',  '03', '12', 'GRAVILIAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('27',  '03', '13', 'LOS GUIDO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('28',  '04', '01', 'SANTIAGO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('29',  '04', '02', 'MERCEDES SUR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('30',  '04', '03', 'BARBACOAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('31',  '04', '04', 'GRIFO ALTO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('32',  '04', '05', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('33',  '04', '06', 'CANDELARITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('34',  '04', '07', 'DESAMPARADITOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('35',  '04', '08', 'SAN ANTONIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('36',  '04', '09', 'CHIRES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('37',  '05', '01', 'SAN MARCOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('38',  '05', '02', 'SAN LORENZO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('39',  '05', '03', 'SAN CARLOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('40',  '06', '01', 'ASERRI');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('41',  '06', '02', 'TARBACA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('42',  '06', '03', 'VUELTA DE JORCO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('43',  '06', '04', 'SAN GABRIEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('44',  '06', '05', 'LEGUA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('45',  '06', '06', 'MONTERREY');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('46',  '06', '07', 'SALITRILLOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('47',  '07', '01', 'COLÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('48',  '07', '02', 'GUAYABO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('49',  '07', '03', 'TABARCIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('50',  '07', '04', 'PIEDRAS NEGRAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('51',  '07', '05', 'PICAGRES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('52',  '07', '06', 'JARIS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('53',  '07', '07', 'QUITIRRISI');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('54',  '08', '01', 'GUADALUPE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('55',  '08', '02', 'SAN FRANCISCO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('56',  '08', '03', 'CALLE BLANCOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('57',  '08', '04', 'MATA DE PLÁTANO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('58',  '08', '05', 'IPÍS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('59',  '08', '06', 'RANCHO REDONDO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('60',  '08', '07', 'PURRAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('61',  '09', '01', 'SANTA ANA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('62',  '09', '02', 'SALITRAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('63',  '09', '03', 'POZOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('64',  '09', '04', 'URUCA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('65',  '09', '05', 'PIEDADES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('66',  '09', '06', 'BRASIL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('67',  '10', '01', 'ALAJUELITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('68',  '10', '02', 'SAN JOSECITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('69',  '10', '03', 'SAN ANTONIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('70',  '10', '04', 'CONCEPCIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('71',  '10', '05', 'SAN FELIPE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('72',  '11', '01', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('73',  '11', '02', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('74',  '11', '03', 'DULCE NOMBRE DE JESÚS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('75',  '11', '04', 'PATALILLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('76',  '11', '05', 'CASCAJAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('77',  '12', '01', 'SAN IGNACIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('78',  '12', '02', 'GUAITIL Villa');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('79',  '12', '03', 'PALMICHAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('80',  '12', '04', 'CANGREJAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('81',  '12', '05', 'SABANILLAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('82',  '13', '01', 'SAN JUAN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('83',  '13', '02', 'CINCO ESQUINAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('84',  '13', '03', 'ANSELMO LLORENTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('85',  '13', '04', 'LEON XIII');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('86',  '13', '05', 'COLIMA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('87',  '14', '01', 'SAN VICENTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('88',  '14', '02', 'SAN JERÓNIMO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('89',  '14', '03', 'LA TRINIDAD');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('90',  '15', '01', 'SAN PEDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('91',  '15', '02', 'SABANILLA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('92',  '15', '03', 'MERCEDES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('93',  '15', '04', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('94',  '16', '01', 'SAN PABLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('95',  '16', '02', 'SAN PEDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('96',  '16', '03', 'SAN JUAN DE MATA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('97',  '16', '04', 'SAN LUIS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('98',  '16', '05', 'CARARA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('99',  '17', '01', 'SANTA MARÍA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('100',  '17', '02', 'JARDÍN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('101',  '17', '03', 'COPEY');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('102',  '18', '01', 'CURRIDABAT');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('103',  '18', '02', 'GRANADILLA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('104',  '18', '03', 'SÁNCHEZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('105',  '18', '04', 'TIRRASES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('106',  '19', '01', 'SAN ISIDRO DE EL GENERAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('107',  '19', '02', 'EL GENERAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('108',  '19', '03', 'DANIEL FLORES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('109',  '19', '04', 'RIVAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('110',  '19', '05', 'SAN PEDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('111',  '19', '06', 'PLATANARES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('112',  '19', '07', 'PEJIBAYE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('113',  '19', '08', 'CAJÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('114',  '19', '09', 'BARÚ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('115',  '19', '10', 'RÍO NUEVO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('116',  '19', '11', 'PÁRAMO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('117',  '20', '01', 'SAN PABLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('118',  '20', '02', 'SAN ANDRÉS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('119',  '20', '03', 'LLANO BONITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('120',  '20', '04', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('121',  '20', '05', 'SANTA CRUZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('122',  '20', '06', 'SAN ANTONIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('123',  '21', '01', 'ALAJUELA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('124',  '21', '02', 'SAN JOSÉ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('125',  '21', '03', 'CARRIZAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('126',  '21', '04', 'SAN ANTONIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('127',  '21', '05', 'GUÁCIMA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('128',  '21', '06', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('129',  '21', '07', 'SABANILLA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('130',  '21', '08', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('131',  '21', '09', 'RÍO SEGUNDO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('132',  '21', '10', 'DESAMPARADOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('133',  '21', '11', 'TURRÚCARES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('134',  '21', '12', 'TAMBOR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('135',  '21', '13', 'GARITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('136',  '21', '14', 'SARAPIQUÍ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('137',  '22', '01', 'SAN RAMÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('138',  '22', '02', 'SANTIAGO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('139',  '22', '03', 'SAN JUAN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('140',  '22', '04', 'PIEDADES NORTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('141',  '22', '05', 'PIEDADES SUR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('142',  '22', '06', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('143',  '22', '07', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('144',  '22', '08', 'ÁNGELES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('145',  '22', '09', 'ALFARO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('146',  '22', '10', 'VOLIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('147',  '22', '11', 'CONCEPCIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('148',  '22', '12', 'ZAPOTAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('149',  '22', '13', 'PEÑAS BLANCAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('150',  '23', '01', 'GRECIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('151',  '23', '02', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('152',  '23', '03', 'SAN JOSÉ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('153',  '23', '04', 'SAN ROQUE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('154',  '23', '05', 'TACARES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('155',  '23', '06', 'RÍO CUARTO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('156',  '23', '07', 'PUENTE DE PIEDRA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('157',  '23', '08', 'BOLÍVAR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('158',  '24', '01', 'SAN MATEO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('159',  '24', '02', 'DESMONTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('160',  '24', '03', 'JESÚS MARÍA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('161',  '24', '04', 'LABRADOR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('162',  '25', '01', 'ATENAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('163',  '25', '02', 'JESÚS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('164',  '25', '03', 'MERCEDES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('165',  '25', '04', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('166',  '25', '05', 'CONCEPCIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('167',  '25', '06', 'SAN JOSE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('168',  '25', '07', 'SANTA EULALIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('169',  '25', '08', 'ESCOBAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('170',  '26', '01', 'NARANJO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('171',  '26', '02', 'SAN MIGUEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('172',  '26', '03', 'SAN JOSÉ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('173',  '26', '04', 'CIRRÍ SUR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('174',  '26', '05', 'SAN JERÓNIMO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('175',  '26', '06', 'SAN JUAN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('176',  '26', '07', 'EL ROSARIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('177',  '26', '08', 'PALMITOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('178',  '27', '01', 'PALMARES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('179',  '27', '02', 'ZARAGOZA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('180',  '27', '03', 'BUENOS AIRES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('181',  '27', '04', 'SANTIAGO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('182',  '27', '05', 'CANDELARIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('183',  '27', '06', 'ESQUÍPULAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('184',  '27', '07', 'LA GRANJA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('185',  '28', '01', 'SAN PEDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('186',  '28', '02', 'SAN JUAN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('187',  '28', '03', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('188',  '28', '04', 'CARRILLOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('189',  '28', '05', 'SABANA REDONDA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('190',  '29', '01', 'OROTINA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('191',  '29', '02', 'EL MASTATE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('192',  '29', '03', 'HACIENDA VIEJA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('193',  '29', '04', 'COYOLAR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('194',  '29', '05', 'LA CEIBA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('195',  '30', '01', 'QUESADA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('196',  '30', '02', 'FLORENCIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('197',  '30', '03', 'BUENAVISTA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('198',  '30', '04', 'AGUAS ZARCAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('199',  '30', '05', 'VENECIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('200',  '30', '06', 'PITAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('201',  '30', '07', 'LA FORTUNA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('202',  '30', '08', 'LA TIGRA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('203',  '30', '09', 'LA PALMERA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('204',  '30', '10', 'VENADO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('205',  '30', '11', 'CUTRIS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('206',  '30', '12', 'MONTERREY');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('207',  '30', '13', 'POCOSOL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('208',  '31', '01', 'ZARCERO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('209',  '31', '02', 'LAGUNA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('210',  '31', '04', 'GUADALUPE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('211',  '31', '05', 'PALMIRA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('212',  '31', '06', 'ZAPOTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('213',  '31', '07', 'BRISAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('214',  '32', '01', 'SARCHÍ NORTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('215',  '32', '02', 'SARCHÍ SUR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('216',  '32', '03', 'TORO AMARILLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('217',  '32', '04', 'SAN PEDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('218',  '32', '05', 'RODRÍGUEZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('219',  '33', '01', 'UPALA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('220',  '33', '02', 'AGUAS CLARAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('221',  '33', '03', 'SAN JOSÉ o PIZOTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('222',  '33', '04', 'BIJAGUA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('223',  '33', '05', 'DELICIAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('224',  '33', '06', 'DOS RÍOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('225',  '33', '07', 'YOLILLAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('226',  '33', '08', 'CANALETE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('227',  '34', '01', 'LOS CHILES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('228',  '34', '02', 'CAÑO NEGRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('229',  '34', '03', 'EL AMPARO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('230',  '34', '04', 'SAN JORGE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('231',  '35', '02', 'BUENAVISTA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('232',  '35', '03', 'COTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('233',  '35', '04', 'KATIRA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('234',  '36', '01', 'ORIENTAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('235',  '36', '02', 'OCCIDENTAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('236',  '36', '03', 'CARMEN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('237',  '36', '04', 'SAN NICOLÁS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('238',  '36', '05', 'AGUACALIENTE o SAN FRANCISCO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('239',  '36', '06', 'GUADALUPE o ARENILLA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('240',  '36', '07', 'CORRALILLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('241',  '36', '08', 'TIERRA BLANCA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('242',  '36', '09', 'DULCE NOMBRE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('243',  '36', '10', 'LLANO GRANDE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('244',  '36', '11', 'QUEBRADILLA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('245',  '37', '01', 'PARAÍSO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('246',  '37', '02', 'SANTIAGO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('247',  '37', '03', 'OROSI');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('248',  '37', '04', 'CACHÍ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('249',  '37', '05', 'LLANOS DE SANTA LUCÍA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('250',  '38', '01', 'TRES RÍOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('251',  '38', '02', 'SAN DIEGO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('252',  '38', '03', 'SAN JUAN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('253',  '38', '04', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('254',  '38', '05', 'CONCEPCIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('255',  '38', '06', 'DULCE NOMBRE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('256',  '38', '07', 'SAN RAMÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('257',  '38', '08', 'RÍO AZUL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('258',  '39', '01', 'JUAN VIÑAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('259',  '39', '02', 'TUCURRIQUE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('260',  '39', '03', 'PEJIBAYE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('261',  '40', '01', 'TURRIALBA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('262',  '40', '02', 'LA SUIZA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('263',  '40', '03', 'PERALTA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('264',  '40', '04', 'SANTA CRUZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('265',  '40', '05', 'SANTA TERESITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('266',  '40', '06', 'PAVONES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('267',  '40', '07', 'TUIS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('268',  '40', '08', 'TAYUTIC');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('269',  '40', '09', 'SANTA ROSA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('270',  '40', '10', 'TRES EQUIS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('271',  '40', '11', 'LA ISABEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('272',  '40', '12', 'CHIRRIPÓ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('273',  '41', '01', 'PACAYAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('274',  '41', '02', 'CERVANTES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('275',  '41', '03', 'CAPELLADES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('276',  '42', '01', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('277',  '42', '02', 'COT');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('278',  '42', '03', 'POTRERO CERRADO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('279',  '42', '04', 'CIPRESES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('280',  '42', '05', 'SANTA ROSA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('281',  '43', '01', 'EL TEJAR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('282',  '43', '02', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('283',  '43', '03', 'TOBOSI');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('284',  '43', '04', 'PATIO DE AGUA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('285',  '44', '01', 'HEREDIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('286',  '44', '02', 'MERCEDES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('287',  '44', '03', 'SAN FRANCISCO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('288',  '44', '04', 'ULLOA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('289',  '44', '05', 'VARABLANCA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('290',  '45', '01', 'BARVA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('291',  '45', '02', 'SAN PEDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('292',  '45', '03', 'SAN PABLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('293',  '45', '04', 'SAN ROQUE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('294',  '45', '05', 'SANTA LUCÍA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('295',  '45', '06', 'SAN JOSÉ DE LA MONTAÑA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('296',  '46', '02', 'SAN VICENTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('297',  '46', '03', 'SAN MIGUEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('298',  '46', '04', 'PARACITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('299',  '46', '05', 'SANTO TOMÁS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('300',  '46', '06', 'SANTA ROSA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('301',  '46', '07', 'TURES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('302',  '46', '08', 'PARÁ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('303',  '47', '01', 'SANTA BÁRBARA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('304',  '47', '02', 'SAN PEDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('305',  '47', '03', 'SAN JUAN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('306',  '47', '04', 'JESÚS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('307',  '47', '05', 'SANTO DOMINGO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('308',  '47', '06', 'PURABÁ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('309',  '48', '01', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('310',  '48', '02', 'SAN JOSECITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('311',  '48', '03', 'SANTIAGO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('312',  '48', '04', 'ÁNGELES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('313',  '48', '05', 'CONCEPCIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('314',  '49', '01', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('315',  '49', '02', 'SAN JOSÉ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('316',  '49', '03', 'CONCEPCIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('317',  '49', '04', 'SAN FRANCISCO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('318',  '50', '01', 'SAN ANTONIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('319',  '50', '02', 'LA RIBERA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('320',  '50', '03', 'LA ASUNCIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('321',  '51', '01', 'SAN JOAQUÍN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('322',  '51', '02', 'BARRANTES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('323',  '51', '03', 'LLORENTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('324',  '52', '01', 'SAN PABLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('325',  '53', '01', 'PUERTO VIEJO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('326',  '53', '02', 'LA VIRGEN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('327',  '53', '03', 'LAS HORQUETAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('328',  '53', '04', 'LLANURAS DEL GASPAR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('329',  '53', '05', 'CUREÑA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('330',  '54', '01', 'LIBERIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('331',  '54', '02', 'CAÑAS DULCES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('332',  '54', '03', 'MAYORGA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('333',  '54', '04', 'NACASCOLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('334',  '54', '05', 'CURUBANDÉ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('335',  '55', '01', 'NICOYA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('336',  '55', '02', 'MANSIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('337',  '55', '03', 'SAN ANTONIO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('338',  '55', '04', 'QUEBRADA HONDA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('339',  '55', '05', 'SÁMARA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('340',  '55', '06', 'NOSARA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('341',  '55', '07', 'BELÉN DE NOSARITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('342',  '56', '01', 'SANTA CRUZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('343',  '56', '02', 'BOLSÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('344',  '56', '03', 'VEINTISIETE DE ABRIL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('345',  '56', '04', 'TEMPATE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('346',  '56', '05', 'CARTAGENA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('347',  '56', '06', 'CUAJINIQUIL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('348',  '56', '07', 'DIRIÁ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('349',  '56', '08', 'CABO VELAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('350',  '56', '09', 'TAMARINDO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('351',  '57', '01', 'BAGACES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('352',  '57', '02', 'LA FORTUNA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('353',  '57', '03', 'MOGOTE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('354',  '57', '04', 'RÍO NARANJO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('355',  '58', '01', 'FILADELFIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('356',  '58', '02', 'PALMIRA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('357',  '58', '03', 'SARDINAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('358',  '58', '04', 'BELÉN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('359',  '59', '01', 'CAÑAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('360',  '59', '02', 'PALMIRA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('361',  '59', '03', 'SAN MIGUEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('362',  '59', '04', 'BEBEDERO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('363',  '59', '05', 'POROZAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('364',  '60', '01', 'LAS JUNTAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('365',  '60', '02', 'SIERRA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('366',  '60', '03', 'SAN JUAN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('367',  '60', '04', 'COLORADO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('368',  '61', '01', 'TILARÁN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('369',  '61', '02', 'QUEBRADA GRANDE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('370',  '61', '03', 'TRONADORA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('371',  '61', '04', 'SANTA ROSA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('372',  '61', '05', 'LÍBANO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('373',  '61', '06', 'TIERRAS MORENAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('374',  '61', '07', 'ARENAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('375',  '62', '01', 'CARMONA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('376',  '62', '02', 'SANTA RITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('377',  '62', '03', 'ZAPOTAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('378',  '62', '04', 'SAN PABLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('379',  '62', '05', 'PORVENIR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('380',  '62', '06', 'BEJUCO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('381',  '63', '01', 'LA CRUZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('382',  '63', '02', 'SANTA CECILIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('383',  '63', '03', 'LA GARITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('384',  '63', '04', 'SANTA ELENA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('385',  '64', '01', 'HOJANCHA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('386',  '64', '02', 'MONTE ROMO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('387',  '64', '03', 'PUERTO CARRILLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('388',  '64', '04', 'HUACAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('389',  '65', '01', 'PUNTARENAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('390',  '65', '02', 'PITAHAYA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('391',  '65', '03', 'CHOMES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('392',  '65', '04', 'LEPANTO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('393',  '65', '05', 'PAQUERA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('394',  '65', '06', 'MANZANILLO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('395',  '65', '07', 'GUACIMAL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('396',  '65', '08', 'BARRANCA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('397',  '65', '09', 'MONTE VERDE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('398',  '65', '11', 'CÓBANO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('399',  '65', '12', 'CHACARITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('400',  '65', '13', 'CHIRA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('401',  '65', '14', 'ACAPULCO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('402',  '65', '15', 'EL ROBLE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('403',  '65', '16', 'ARANCIBIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('404',  '66', '01', 'ESPÍRITU SANTO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('405',  '66', '02', 'SAN JUAN GRANDE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('406',  '66', '03', 'MACACONA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('407',  '66', '04', 'SAN RAFAEL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('408',  '66', '05', 'SAN JERÓNIMO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('409',  '66', '06', 'CALDERA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('410',  '67', '01', 'BUENOS AIRES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('411',  '67', '02', 'VOLCÁN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('412',  '67', '03', 'POTRERO GRANDE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('413',  '67', '04', 'BORUCA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('414',  '67', '05', 'PILAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('415',  '67', '06', 'COLINAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('416',  '67', '07', 'CHÁNGUENA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('417',  '67', '08', 'BIOLLEY');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('418',  '67', '09', 'BRUNKA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('419',  '68', '01', 'MIRAMAR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('420',  '68', '02', 'LA UNIÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('421',  '68', '03', 'SAN ISIDRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('422',  '69', '01', 'PUERTO CORTÉS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('423',  '69', '02', 'PALMAR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('424',  '69', '03', 'SIERPE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('425',  '69', '04', 'BAHÍA BALLENA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('426',  '69', '05', 'PIEDRAS BLANCAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('427',  '69', '06', 'BAHÍA DRAKE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('428',  '70', '01', 'QUEPOS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('429',  '70', '02', 'SAVEGRE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('430',  '70', '03', 'NARANJITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('431',  '71', '01', 'GOLFITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('432',  '71', '02', 'PUERTO JIMÉNEZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('433',  '71', '03', 'GUAYCARÁ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('434',  '71', '04', 'PAVÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('435',  '72', '01', 'SAN VITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('436',  '72', '02', 'SABALITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('437',  '72', '03', 'AGUABUENA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('438',  '72', '04', 'LIMONCITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('439',  '72', '05', 'PITTIER');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('440',  '72', '06', 'GUTIERREZ BRAUN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('441',  '73', '01', 'PARRITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('442',  '74', '01', 'CORREDOR');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('443',  '74', '02', 'LA CUESTA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('444',  '74', '03', 'CANOAS');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('445',  '74', '04', 'LAUREL');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('446',  '75', '01', 'JACÓ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('447',  '75', '02', 'TÁRCOLES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('448',  '76', '01', 'LIMÓN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('449',  '76', '02', 'VALLE LA ESTRELLA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('450',  '76', '04', 'MATAMA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('451',  '77', '01', 'GUÁPILES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('452',  '77', '02', 'JIMÉNEZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('453',  '77', '03', 'RITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('454',  '77', '04', 'ROXANA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('455',  '77', '05', 'CARIARI');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('456',  '77', '06', 'COLORADO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('457',  '77', '07', 'LA COLONIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('458',  '78', '01', 'SIQUIRRES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('459',  '78', '02', 'PACUARITO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('460',  '78', '03', 'FLORIDA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('461',  '78', '04', 'GERMANIA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('462',  '78', '05', 'EL CAIRO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('463',  '78', '06', 'ALEGRÍA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('464',  '79', '01', 'BRATSI');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('465',  '79', '02', 'SIXAOLA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('466',  '79', '03', 'CAHUITA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('467',  '79', '04', 'TELIRE');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('468',  '80', '01', 'MATINA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('469',  '80', '02', 'BATÁN');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('470',  '80', '03', 'CARRANDI');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('471',  '81', '01', 'GUÁCIMO');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('472',  '81', '02', 'MERCEDES');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('473',  '81', '03', 'POCORA');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('474',  '81', '04', 'RÍO JIMÉNEZ');
INSERT INTO LST_DISTRICTS (id, p_code,  code, name_value) VALUES ('475',  '81', '05', 'DUACARÍ');


INSERT INTO TBL_VIEWS VALUES ('SysAdmin', 'vSysAdminRegistration', 'Registrar Administrador', 'Administradores' )
INSERT INTO TBL_VIEWS VALUES ('SysAdmin', 'vSysAdminList', 'Listar Administradores', 'Administradores')
INSERT INTO TBL_VIEWS VALUES ('SysAdmin', 'vSysAdminAccount', 'Mi Cuenta', 'Administradores')
INSERT INTO TBL_VIEWS VALUES ('SysAdmin', 'vSysAdminUpdate','Actualizar Administrador', 'Administradores')
INSERT INTO TBL_VIEWS VALUES ('Financial', 'vFinancialRegistration', 'Registrar Financiero', 'Entidades Financieras')
INSERT INTO TBL_VIEWS VALUES ('Financial', 'vFinancialList', 'Listar Financieros', 'Entidades Financieras')
INSERT INTO TBL_VIEWS VALUES ('Financial', 'vFinancialAccount', 'Mi Cuenta','Entidades Financieras')
INSERT INTO TBL_VIEWS VALUES ('Financial', 'vFinancialUpdate','Actualizar Financiero','Entidades Financieras')
INSERT INTO TBL_VIEWS VALUES ('Recruiter', 'vRecruiterRegistration', 'Registrar Reclutador','Reclutadores')
INSERT INTO TBL_VIEWS VALUES ('Recruiter', 'vRecruiterList', 'Listar Reclutadores','Reclutadores')
INSERT INTO TBL_VIEWS VALUES ('Recruiter', 'vRecruiterAccount', 'Perfil Reclutador','Reclutadores')
INSERT INTO TBL_VIEWS VALUES ('Recruiter', 'vRecruiterUpdate','Actualizar Reclutador','Reclutadores')
INSERT INTO TBL_VIEWS VALUES ('Student', 'vStudentRegistration', 'Registrar Estudiante','Estudiantes')
INSERT INTO TBL_VIEWS VALUES ('Student', 'vStudentList', 'Listar Estudiantes','Estudiantes')
INSERT INTO TBL_VIEWS VALUES ('Student', 'vStudentAccount', 'Perfil Estudiante','Estudiantes')
INSERT INTO TBL_VIEWS VALUES ('Student', 'vStudentUpdate','Actualizar Estudiante','Estudiantes')


INSERT INTO TBL_PERMISSIONS VALUES ('1', '1')
INSERT INTO TBL_PERMISSIONS VALUES ('1', '2')
INSERT INTO TBL_PERMISSIONS VALUES ('1', '3')
INSERT INTO TBL_PERMISSIONS VALUES ('1', '5')
INSERT INTO TBL_PERMISSIONS VALUES ('1', '6')
INSERT INTO TBL_PERMISSIONS VALUES ('1', '9')
INSERT INTO TBL_PERMISSIONS VALUES ('1', '10')
INSERT INTO TBL_PERMISSIONS VALUES ('1', '13')
INSERT INTO TBL_PERMISSIONS VALUES ('1', '14')



INSERT INTO TBL_PERMISSIONS VALUES ('3', '14')
INSERT INTO TBL_PERMISSIONS VALUES ('3', '15')

INSERT INTO TBL_PERMISSIONS VALUES ('4', '9')
INSERT INTO TBL_PERMISSIONS VALUES ('4', '10')
INSERT INTO TBL_PERMISSIONS VALUES ('4', '13')
INSERT INTO TBL_PERMISSIONS VALUES ('4', '14')

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
        @SP_Complete_Name VARCHAR(200),
        @SP_Id_Type VARCHAR(1),
        @SP_Identification_Number VARCHAR(20),
        @SP_Birthdate DATETIME,
		@SP_Age INT,
        @SP_Email VARCHAR(200),
        @SP_Phone_Number VARCHAR(200),
        @SP_Province VARCHAR(200),
        @SP_Canton VARCHAR(200),
        @SP_District VARCHAR(200),
        @SP_Laboral_Status VARCHAR(10),
        @SP_Workstation VARCHAR(200),
        @SP_Experience VARCHAR(200),
        @SP_Laboral_Experience VARCHAR(200),
        @SP_Education_Status VARCHAR(200),
        @SP_Institution_Academic_Type VARCHAR(200),
        @SP_Institution_Academic_Name VARCHAR(200),
        @SP_Academic_Preparation VARCHAR(200),
        @SP_University_Level VARCHAR(200),
        @SP_University_Degree VARCHAR(200),
        @SP_Excel_Level VARCHAR(200),
        @SP_Job_Availability VARCHAR(200),
        @SP_Transport_Availability VARCHAR(10),
        @SP_Vehicle VARCHAR(10),
        @SP_Driver_Licenses VARCHAR(200),
        @SP_Courses_Banking_Coach VARCHAR(200),
        @SP_Teachers_Banking_Coach VARCHAR(200),
        @SP_Languages VARCHAR(200),
        @SP_Course_Date_Finish DATETIME,
        @SP_Course_Day VARCHAR(200),
        @SP_Course_Schedule VARCHAR(200),
        @SP_Course_Place VARCHAR(200),
        @SP_Banking_Coach_Certificate VARCHAR(200),
        @SP_Curriculum VARCHAR(200),
        @SP_Agree_Job_Exchange VARCHAR(200),
        @SP_Student_User VARCHAR(20),
        @SP_Student_Password VARCHAR(50)
AS
        INSERT INTO [dbo].[TBL_STUDENT] (Banking_Student,User_Active_Status, Complete_Name, Id_Type, Identification_Number, Birthdate, Age, Email,Phone_Number, Province, Canton, District, Laboral_Status, Workstation, Experience, Laboral_Experience, Education_Status, Institution_Academic_Type, Institution_Academic_Name, Academic_Preparation, University_Level, University_Degree, Excel_Level, Job_Availability, Transport_Availability, Vehicle, Driver_Licenses, Courses_Banking_Coach, Teachers_Banking_Coach, Languages, Course_Date_Finish, Course_Day, Course_Schedule, Course_Place, Banking_Coach_Certificate, Curriculum, Agree_Job_Exchange, Student_User, Student_Password,  User_Type) VALUES (
                @SP_Banking_Student,
                @SP_User_Active_Status,
                @SP_Complete_Name,
                @SP_Id_Type,
                @SP_Identification_Number,
                @SP_Birthdate,
				@SP_Age,
                @SP_Email,
				@SP_Phone_Number,
				@SP_Province,
                @SP_Canton,
                @SP_District,
                @SP_Laboral_Status,
                @SP_Workstation,
                @SP_Experience,
                @SP_Laboral_Experience,
                @SP_Education_Status,
                @SP_Institution_Academic_Type,
                @SP_Institution_Academic_Name,
                @SP_Academic_Preparation,
                @SP_University_Level,
                @SP_University_Degree,
                @SP_Excel_Level,
                @SP_Job_Availability,
                @SP_Transport_Availability,
                @SP_Vehicle,
                @SP_Driver_Licenses,
                @SP_Courses_Banking_Coach,
                @SP_Teachers_Banking_Coach,
                @SP_Languages,
                @SP_Course_Date_Finish,
                @SP_Course_Day,
                @SP_Course_Schedule,
                @SP_Course_Place,
                @SP_Banking_Coach_Certificate,
                @SP_Curriculum,
                @SP_Agree_Job_Exchange,
                @SP_Student_User,
                HashBytes('MD5',@SP_Student_Password),
				2);
GO

---SELECT ALL
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_STUDENT]
AS
       SELECT S.Banking_Student, S.Complete_Name, S.Id_Type, S.Identification_Number, S.Birthdate, S.Age, S.Email,S.Phone_Number,S.Laboral_Status, S.Workstation, S.Experience, S.Laboral_Experience, S.Education_Status, S.Institution_Academic_Type, S.Institution_Academic_Name, S.Academic_Preparation, S.University_Level, S.University_Degree, S.Excel_Level, S.Job_Availability, S.Transport_Availability, S.Vehicle, S.Driver_Licenses, S.Courses_Banking_Coach, S.Teachers_Banking_Coach, S.Languages, S.Course_Date_Finish, S.Course_Day, S.Course_Schedule, S.Course_Place, S.Banking_Coach_Certificate, S.Curriculum, S.Agree_Job_Exchange,S.Province, S.Canton, S.District, LP.Name_Value AS 'N_Province', LC.Name_Value AS 'N_Canton', LD.Name_Value AS 'N_District', CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo' 
		END AS 'User_Active_Status', S.User_Type, S.Student_User, S.Student_Password  FROM [dbo].[TBL_STUDENT] AS S
		INNER JOIN 
		LST_PROVINCES AS LP ON S.Province = LP.Code
		INNER JOIN 
		LST_CANTONS AS LC ON S.Canton = LC.Code
		INNER JOIN 
		LST_DISTRICTS AS LD ON S.District = LD.Code
		WHERE S.Student_ID != 0 AND LC.P_Code = LP.Code AND LD.P_Code = LC.Code;
GO

---BY IDENTIFICATION NUMBER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_IDENTIFICATION]
        @SP_Identification_Number VARCHAR(20)
AS
       SELECT S.Banking_Student, S.Complete_Name, S.Id_Type, S.Identification_Number, S.Birthdate, S.Age, S.Email,S.Phone_Number,S.Laboral_Status, S.Workstation, S.Experience, S.Laboral_Experience, S.Education_Status, S.Institution_Academic_Type, S.Institution_Academic_Name, S.Academic_Preparation, S.University_Level, S.University_Degree, S.Excel_Level, S.Job_Availability, S.Transport_Availability, S.Vehicle, S.Driver_Licenses, S.Courses_Banking_Coach, S.Teachers_Banking_Coach, S.Languages, S.Course_Date_Finish, S.Course_Day, S.Course_Schedule, S.Course_Place, S.Banking_Coach_Certificate, S.Curriculum, S.Agree_Job_Exchange,S.Province, S.Canton, S.District, LP.Name_Value AS 'N_Province', LC.Name_Value AS 'N_Canton', LD.Name_Value AS 'N_District', CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo' 
		END AS 'User_Active_Status', S.User_Type, S.Student_User, S.Student_Password  FROM [dbo].[TBL_STUDENT] AS S
		INNER JOIN 
		LST_PROVINCES AS LP ON S.Province = LP.Code
		INNER JOIN 
		LST_CANTONS AS LC ON S.Canton = LC.Code
		INNER JOIN 
		LST_DISTRICTS AS LD ON S.District = LD.Code
		WHERE S.Identification_Number = @SP_Identification_Number AND S.Student_ID != 0 AND LC.P_Code = LP.Code AND LD.P_Code = LC.Code;
GO

---BY EMAIL
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_EMAIL]
        @SP_Student_Email VARCHAR(200)
AS
       SELECT S.Banking_Student, S.Complete_Name, S.Id_Type, S.Identification_Number, S.Birthdate, S.Age, S.Email,S.Phone_Number,S.Laboral_Status, S.Workstation, S.Experience, S.Laboral_Experience, S.Education_Status, S.Institution_Academic_Type, S.Institution_Academic_Name, S.Academic_Preparation, S.University_Level, S.University_Degree, S.Excel_Level, S.Job_Availability, S.Transport_Availability, S.Vehicle, S.Driver_Licenses, S.Courses_Banking_Coach, S.Teachers_Banking_Coach, S.Languages, S.Course_Date_Finish, S.Course_Day, S.Course_Schedule, S.Course_Place, S.Banking_Coach_Certificate, S.Curriculum, S.Agree_Job_Exchange,S.Province, S.Canton, S.District, LP.Name_Value AS 'N_Province', LC.Name_Value AS 'N_Canton', LD.Name_Value AS 'N_District', CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo' 
		END AS 'User_Active_Status', S.User_Type, S.Student_User, S.Student_Password  FROM [dbo].[TBL_STUDENT] AS S
		INNER JOIN 
		LST_PROVINCES AS LP ON S.Province = LP.Code
		INNER JOIN 
		LST_CANTONS AS LC ON S.Canton = LC.Code
		INNER JOIN 
		LST_DISTRICTS AS LD ON S.District = LD.Code
		WHERE S.Email = @SP_Student_Email AND S.Student_ID != 0 AND LC.P_Code = LP.Code AND LD.P_Code = LC.Code;
GO

---BY USER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_USER]
        @SP_Student_User VARCHAR(20)
AS
        SELECT S.Banking_Student, S.Complete_Name, S.Id_Type, S.Identification_Number, S.Birthdate, S.Age, S.Email,S.Phone_Number,S.Laboral_Status, S.Workstation, S.Experience, S.Laboral_Experience, S.Education_Status, S.Institution_Academic_Type, S.Institution_Academic_Name, S.Academic_Preparation, S.University_Level, S.University_Degree, S.Excel_Level, S.Job_Availability, S.Transport_Availability, S.Vehicle, S.Driver_Licenses, S.Courses_Banking_Coach, S.Teachers_Banking_Coach, S.Languages, S.Course_Date_Finish, S.Course_Day, S.Course_Schedule, S.Course_Place, S.Banking_Coach_Certificate, S.Curriculum, S.Agree_Job_Exchange,S.Province, S.Canton, S.District, LP.Name_Value AS 'N_Province', LC.Name_Value AS 'N_Canton', LD.Name_Value AS 'N_District', CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo' 
		END AS 'User_Active_Status', S.User_Type, S.Student_User, S.Student_Password  FROM [dbo].[TBL_STUDENT] AS S
		INNER JOIN 
		LST_PROVINCES AS LP ON S.Province = LP.Code
		INNER JOIN 
		LST_CANTONS AS LC ON S.Canton = LC.Code
		INNER JOIN 
		LST_DISTRICTS AS LD ON S.District = LD.Code
		WHERE S.Student_User = @SP_Student_User AND S.Student_ID != 0 AND LC.P_Code = LP.Code AND LD.P_Code = LC.Code;
GO

---BY ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_ID]
        @SP_Student_ID INT
AS
       SELECT S.Banking_Student, S.Complete_Name, S.Id_Type, S.Identification_Number, S.Birthdate, S.Age, S.Email,S.Phone_Number,S.Laboral_Status, S.Workstation, S.Experience, S.Laboral_Experience, S.Education_Status, S.Institution_Academic_Type, S.Institution_Academic_Name, S.Academic_Preparation, S.University_Level, S.University_Degree, S.Excel_Level, S.Job_Availability, S.Transport_Availability, S.Vehicle, S.Driver_Licenses, S.Courses_Banking_Coach, S.Teachers_Banking_Coach, S.Languages, S.Course_Date_Finish, S.Course_Day, S.Course_Schedule, S.Course_Place, S.Banking_Coach_Certificate, S.Curriculum, S.Agree_Job_Exchange,S.Province, S.Canton, S.District, LP.Name_Value AS 'N_Province', LC.Name_Value AS 'N_Canton', LD.Name_Value AS 'N_District', CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo' 
		END AS 'User_Active_Status', S.User_Type, S.Student_User, S.Student_Password  FROM [dbo].[TBL_STUDENT] AS S
		INNER JOIN 
		LST_PROVINCES AS LP ON S.Province = LP.Code
		INNER JOIN 
		LST_CANTONS AS LC ON S.Canton = LC.Code
		INNER JOIN 
		LST_DISTRICTS AS LD ON S.District = LD.Code
		WHERE S.Student_ID = @SP_Student_ID AND S.Student_ID != 0 AND LC.P_Code = LP.Code AND LD.P_Code = LC.Code;
GO

---BY FIRSTNAME AND LASTNAME
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_STUDENT_BY_FIRST_NAME_AND_LAST_NAME]
        @SP_Complete_Name VARCHAR(200)
AS
       SELECT S.Banking_Student, S.Complete_Name, S.Id_Type, S.Identification_Number, S.Birthdate, S.Age, S.Email,S.Phone_Number,S.Laboral_Status, S.Workstation, S.Experience, S.Laboral_Experience, S.Education_Status, S.Institution_Academic_Type, S.Institution_Academic_Name, S.Academic_Preparation, S.University_Level, S.University_Degree, S.Excel_Level, S.Job_Availability, S.Transport_Availability, S.Vehicle, S.Driver_Licenses, S.Courses_Banking_Coach, S.Teachers_Banking_Coach, S.Languages, S.Course_Date_Finish, S.Course_Day, S.Course_Schedule, S.Course_Place, S.Banking_Coach_Certificate, S.Curriculum, S.Agree_Job_Exchange,S.Province, S.Canton, S.District, LP.Name_Value AS 'N_Province', LC.Name_Value AS 'N_Canton', LD.Name_Value AS 'N_District', CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo' 
		END AS 'User_Active_Status', S.User_Type, S.Student_User, S.Student_Password FROM [dbo].[TBL_STUDENT] AS S
		INNER JOIN 
		LST_PROVINCES AS LP ON S.Province = LP.Code
		INNER JOIN 
		LST_CANTONS AS LC ON S.Canton = LC.Code
		INNER JOIN 
		LST_DISTRICTS AS LD ON S.District = LD.Code
		WHERE S.Complete_Name = @SP_Complete_Name AND Student_ID != 0  AND LC.P_Code = LP.Code AND LD.P_Code = LC.Code;
GO

--- UPDATE STUDENT
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_STUDENT]
        @SP_Banking_Student VARCHAR(1),
        @SP_User_Active_Status VARCHAR(1),
        @SP_Complete_Name VARCHAR(200),
        @SP_Id_Type VARCHAR(1),
        @SP_Identification_Number VARCHAR(20),
        @SP_Birthdate DATETIME,
		@SP_Age INT,
        @SP_Email VARCHAR(200),
        @SP_Phone_Number VARCHAR(200),
        @SP_Laboral_Status VARCHAR(10),
        @SP_Workstation VARCHAR(200),
        @SP_Experience VARCHAR(200),
        @SP_Laboral_Experience VARCHAR(200),
        @SP_Education_Status VARCHAR(200),
        @SP_Institution_Academic_Type VARCHAR(200),
        @SP_Institution_Academic_Name VARCHAR(200),
        @SP_Academic_Preparation VARCHAR(200),
        @SP_University_Level VARCHAR(200),
        @SP_University_Degree VARCHAR(200),
        @SP_Excel_Level VARCHAR(200),
        @SP_Job_Availability VARCHAR(200),
        @SP_Transport_Availability VARCHAR(10),
        @SP_Vehicle VARCHAR(10),
        @SP_Driver_Licenses VARCHAR(200),
        @SP_Courses_Banking_Coach VARCHAR(200),
        @SP_Teachers_Banking_Coach VARCHAR(200),
        @SP_Languages VARCHAR(200),
        @SP_Course_Date_Finish DATETIME,
        @SP_Course_Day VARCHAR(200),
        @SP_Course_Schedule VARCHAR(200),
        @SP_Course_Place VARCHAR(200),
        @SP_Banking_Coach_Certificate VARCHAR(200),
        @SP_Curriculum VARCHAR(200),
        @SP_Agree_Job_Exchange VARCHAR(200),
        @SP_Student_User VARCHAR(20),
        @SP_Student_Password VARCHAR(50),
        @SP_Province VARCHAR(200),
        @SP_Canton VARCHAR(200),
        @SP_District VARCHAR(200)
AS
        UPDATE [dbo].[TBL_STUDENT] SET
                Banking_Student=@SP_Banking_Student,
                Complete_Name=@SP_Complete_Name,
                Id_Type=@SP_Id_Type,
                Identification_Number=@SP_Identification_Number,
                Birthdate=@SP_Birthdate,
                Age=@SP_Age,
                Phone_Number=@SP_Phone_Number,
                Email=@SP_Email,
				Province=@SP_Province,
                Canton=@SP_Canton,
                District=@SP_District,
                Laboral_Status=@SP_Laboral_Status,
                Workstation=@SP_Workstation,
                Experience=@SP_Experience,
                Education_Status=@SP_Laboral_Experience,
                Institution_Academic_Type=@SP_Institution_Academic_Type,
                Institution_Academic_Name=@SP_Institution_Academic_Name,
                Academic_Preparation=@SP_Academic_Preparation,
                University_Level=@SP_University_Level,
                University_Degree=@SP_University_Degree,
                Excel_Level=@SP_Excel_Level,
                Job_Availability=@SP_Job_Availability,
                Transport_Availability=@SP_Transport_Availability,
                Vehicle=@SP_Vehicle,
                Driver_Licenses=@SP_Driver_Licenses,
                Courses_Banking_Coach=@SP_Courses_Banking_Coach,
                Teachers_Banking_Coach=@SP_Teachers_Banking_Coach,
                Languages=@SP_Languages,
                Course_Date_Finish=@SP_Course_Date_Finish,
                Course_Day=@SP_Course_Day,
                Course_Schedule=@SP_Course_Schedule,
				Course_Place=@SP_Course_Place,
				Banking_Coach_Certificate=@SP_Banking_Coach_Certificate,
				Curriculum=@SP_Curriculum,
				Agree_Job_Exchange=@SP_Agree_Job_Exchange,
				Student_User=@SP_Student_User,
				Student_Password=@SP_Student_Password
                WHERE Student_User = @SP_Student_User;
GO


--- UPDATE STUDENT PASSWORD
CREATE PROCEDURE [dbo].[SP_UPDATE_PASSWORD_TBL_STUDENT]
        @SP_Student_User VARCHAR(20),
        @SP_Student_Password VARCHAR(50)
AS
	BEGIN
		
		UPDATE [dbo].[TBL_STUDENT] SET
			Student_Password = HashBytes('MD5',@SP_Student_Password)
			WHERE Student_User = @SP_Student_User;
		
	END
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
                HashBytes('MD5',@SP_Admin_Password),
                @SP_User_Active_Status,
				'1');
GO


---SELECT ADMIN BY ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_ADMIN_USER_BY_ID]
        @SP_Sys_Admin_User_ID INT
AS
        SELECT Sys_Admin_User_ID, Admin_Login, Admin_Password, CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo'
		END AS 'User_Active_Status', User_Type FROM [dbo].[TBL_SYS_ADMIN_USER] WHERE Sys_Admin_User_ID = @SP_Sys_Admin_User_ID AND Sys_Admin_User_ID != 0;
GO


---SELECT ADMIN BY ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_ADMIN_USER]
        @SP_Admin_Login VARCHAR(20)
AS
        SELECT Sys_Admin_User_ID, Admin_Login, Admin_Password, CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo'
		END AS 'User_Active_Status', User_Type FROM [dbo].[TBL_SYS_ADMIN_USER] WHERE Admin_Login = @SP_Admin_Login;
GO

---SELECT ALL ADMINS
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_ADMIN_USER]
AS
        SELECT Sys_Admin_User_ID, Admin_Login, Admin_Password, CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo'
		END AS 'User_Active_Status', User_Type FROM [dbo].[TBL_SYS_ADMIN_USER] WHERE Sys_Admin_User_ID != 0;
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
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_ADMIN_USER]
        @SP_Admin_Login VARCHAR(20),
        @SP_Admin_Password VARCHAR(50)
AS
        UPDATE [dbo].[TBL_SYS_ADMIN_USER] SET
                Admin_Password= HashBytes('MD5', @SP_Admin_Password)
                WHERE Admin_Login = @SP_Admin_Login;                
GO

--- UPDATE SYS_ADMIN_USER PASSWORD
CREATE PROCEDURE [dbo].[SP_UPDATE_PASSWORD_TBL_SYS_ADMIN_USER]
        @SP_Admin_Login VARCHAR(20),
        @SP_Admin_Password VARCHAR(50)
AS
	BEGIN
		
		UPDATE [dbo].[TBL_SYS_ADMIN_USER] SET
			Admin_Password = HashBytes('MD5',@SP_Admin_Password)
			WHERE Admin_Login = @SP_Admin_Login;
		
	END
GO

---DELETE ADMIN
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_ADMIN_USER]
        @SP_Sys_Admin_User_ID INT
AS	
        DELETE FROM [dbo].[TBL_SYS_ADMIN_USER] WHERE Sys_Admin_User_ID = @SP_Sys_Admin_User_ID;
GO

--SOFT DELETE ADMIN
CREATE PROCEDURE [dbo].[SP_SOFT_DELETE_TBL_ADMIN_USER]
        @SP_Sys_Admin_User_ID INT
AS	
		UPDATE [dbo].[TBL_SYS_ADMIN_USER] SET
				 User_Active_Status ='0'
				 WHERE Sys_Admin_User_ID = @SP_Sys_Admin_User_ID;
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
                HashBytes('MD5',@SP_Recruiter_Password),
                @SP_User_Active_Status,
				'3',
				@SP_Finantial_Association
				);
GO


--- SELECT BY ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_RECRUITER_USER_BY_ID]
        @SP_Recruiter_User_ID INT
AS
       SELECT R.Recruiter_User_ID, R.Recruiter_Login, R.Recruiter_Password, R.Finantial_Association, F.Financial_User AS 'Finantial_Association_Name', CASE  
		WHEN R.User_Active_Status= '1' THEN 'Activo'
		WHEN R.User_Active_Status= '0' THEN 'Inactivo'
		END AS 'User_Active_Status', R.User_Type FROM [dbo].[TBL_RECRUITER_USER] AS R
		INNER JOIN 
		TBL_FINANCIAL_USER AS F ON R.Finantial_Association = F.Financial_User_ID
		WHERE Recruiter_User_ID = @SP_Recruiter_User_ID AND Recruiter_User_ID != 0;
GO

--- SELECT BY USER
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_RECRUITER_USER]
        @SP_Recruiter_Login VARCHAR(20)
AS
       SELECT R.Recruiter_User_ID, R.Recruiter_Login, R.Recruiter_Password, R.Finantial_Association, F.Financial_User AS 'Finantial_Association_Name', CASE  
		WHEN R.User_Active_Status= '1' THEN 'Activo'
		WHEN R.User_Active_Status= '0' THEN 'Inactivo'
		END AS 'User_Active_Status', R.User_Type FROM [dbo].[TBL_RECRUITER_USER] AS R
		INNER JOIN 
		TBL_FINANCIAL_USER AS F ON R.Finantial_Association = F.Financial_User_ID
		WHERE Recruiter_Login = @SP_Recruiter_Login AND Recruiter_User_ID != 0;
GO

CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_RECRUITER_USER]
AS
        SELECT R.Recruiter_User_ID, R.Recruiter_Login, R.Recruiter_Password, R.Finantial_Association, F.Financial_User AS 'Finantial_Association_Name', CASE  
		WHEN R.User_Active_Status= '1' THEN 'Activo'
		WHEN R.User_Active_Status= '0' THEN 'Inactivo'
		END AS 'User_Active_Status', R.User_Type FROM [dbo].[TBL_RECRUITER_USER] AS R
		INNER JOIN 
		TBL_FINANCIAL_USER AS F ON R.Finantial_Association = F.Financial_User_ID
		WHERE Recruiter_User_ID != 0;
GO


--- UPDATE RECRUITER STATUS
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_RECRUITER_USER_STATUS]
        @SP_Recruiter_Login VARCHAR(20),
        @SP_User_Active_Status VARCHAR(1)
AS
        UPDATE [dbo].[TBL_RECRUITER_USER] SET
                User_Active_Status=@SP_User_Active_Status
                WHERE Recruiter_Login = @SP_Recruiter_Login;
GO

/*
CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_RECRUITER_USER_STATUS]
        @SP_Recruiter_Login VARCHAR(20),
AS
		DECLARE @GET_STATUS VARCHAR(1)
		DECLARE @NEW_STATUS VARCHAR(1) = '1'
		SELECT @GET_STATUS = User_Active_Status FROM TBL_RECRUITER_USER WHERE Recruiter_Login = @SP_Recruiter_Login

		IF @GET_STATUS = '1' 
		BEGIN
			@NEW_STATUS = '0'
		END

        UPDATE [dbo].[TBL_RECRUITER_USER] SET
                User_Active_Status=@NEW_STATUS
                WHERE Recruiter_Login = @SP_Recruiter_Login;
GO

*/

--- UPDATE RECRUITER PASSWORD
CREATE PROCEDURE [dbo].[SP_UPDATE_PASSWORD_TBL_RECRUITER]
        @SP_Recruiter_Login VARCHAR(20),
        @SP_Recruiter_Password VARCHAR(50)
AS
	BEGIN
		
		UPDATE [dbo].[TBL_RECRUITER] SET
			Recruiter_Password = HashBytes('MD5',@SP_Recruiter_Password)
			WHERE Recruiter_Login = @SP_Recruiter_Login;
		
	END
GO



---DELETE RECRUITER
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_RECRUITER_USER]
        @SP_Recruiter_User_ID INT
AS
        DELETE FROM [dbo].[TBL_RECRUITER_USER] WHERE Recruiter_User_ID = @SP_Recruiter_User_ID;
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
                HashBytes('MD5',@SP_Financial_Password),
                @SP_User_Active_Status,
				'4');
GO

--- SELECT BY FINANCIAL USER ID
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_FINANCIAL_USER_BY_ID]
        @SP_Financial_User_ID INT
AS
        SELECT Financial_User_ID, Financial_User, Financial_Password, CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo'
		END AS 'User_Active_Status', User_Type FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User_ID = @SP_Financial_User_ID AND Financial_User_ID != 0;
GO


--- SELECT BY FINANCIAL USER LOGIN
CREATE PROCEDURE [dbo].[SP_SELECT_TBL_FINANCIAL_USER]
        @SP_Financial_User VARCHAR(20)
AS
        SELECT Financial_User_ID, Financial_User, Financial_Password, CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo'
		END AS 'User_Active_Status', User_Type FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User = @SP_Financial_User AND Financial_User_ID != 0;
GO

CREATE PROCEDURE [dbo].[SP_SELECT_ALL_TBL_FINANCIAL_USER]
AS
        SELECT Financial_User_ID, Financial_User, Financial_Password, CASE  
		WHEN User_Active_Status = '1' THEN 'Activo'
		WHEN User_Active_Status = '0' THEN 'Inactivo'
		END AS 'User_Active_Status', User_Type FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User_ID != 0
GO

CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_FINANCIAL_USER]
        @SP_Financial_User VARCHAR(20),
		 @SP_Financial_Password VARCHAR(50)
AS
        UPDATE [dbo].[TBL_FINANCIAL_USER] SET
                Financial_Password=HashBytes('MD5',@SP_Financial_Password)
                WHERE Financial_User = @SP_Financial_User;
GO


CREATE PROCEDURE [dbo].[SP_UPDATE_TBL_FINANCIAL_USER_STATUS]
        @SP_Financial_User VARCHAR(20),
        @SP_User_Active_Status VARCHAR(1)
AS
        UPDATE [dbo].[TBL_FINANCIAL_USER] SET
                User_Active_Status=@SP_User_Active_Status
                WHERE Financial_User = @SP_Financial_User;
GO


--- UPDATE FINANCIAL PASSWORD
CREATE PROCEDURE [dbo].[SP_UPDATE_PASSWORD_TBL_FINANCIAL]
        @SP_Financial_User VARCHAR(20),
        @SP_Financial_Password VARCHAR(50)
AS
	BEGIN
		
		UPDATE [dbo].[TBL_FINANCIAL] SET
			Financial_Password = HashBytes('MD5',@SP_Financial_Password)
			WHERE Financial_User = @SP_Financial_User;
		
	END
GO


---DELETE FINANCIAL
/*CREATE PROCEDURE [dbo].[SP_DELETE_TBL_FINANCIAL_USER]
        @SP_Financial_User_ID INT
AS
        DELETE FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User_ID = @SP_Financial_User_ID;
GO*/

---DELETE FINANCIAL
CREATE PROCEDURE [dbo].[SP_DELETE_TBL_FINANCIAL_USER]
        @SP_Financial_User_ID INT
AS
		DELETE FROM [dbo].[TBL_RECRUITER_USER]  WHERE Finantial_Association = @SP_Financial_User_ID;
        DELETE FROM [dbo].[TBL_FINANCIAL_USER] WHERE Financial_User_ID = @SP_Financial_User_ID;
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
		WHEN @GET_PASS != HashBytes('MD5',@SP_User_Password) THEN '1' -- PASSWORD IS INCORRECT
		WHEN @GET_STATUS = '0' THEN '2' -- STATUS INACTIVE
		WHEN @GET_STATUS = '1' THEN '3' -- STATUS ACTIVE
	END 
	SELECT @RESULT AS 'Result', @GET_LOGIN AS 'User_Login', @GET_USER_TYPE AS 'User_Type', @GET_STATUS AS 'User_Active_Status';
END
GO


--verify user name existence
--RETURN 0 IF DONT EXIST OR 1 IF EXIST

CREATE PROCEDURE [dbo].[SP_VERIFY_EMAIL]
        @SP_Email VARCHAR(200)
AS
	BEGIN
		DECLARE @COUNT_EMAIL INT 
		DECLARE @EMAIL_EXIST VARCHAR(1) = '0'

		SELECT @COUNT_EMAIL = COUNT(Email) FROM TBL_STUDENT WHERE Email = @SP_Email

		IF @COUNT_EMAIL > 0 
		BEGIN 
			SET @EMAIL_EXIST = '1'
		END 

		SELECT @EMAIL_EXIST AS 'Email'
	END
GO



/**
-END 
STORAGE PROCEDURES FOR USER LOG
**/


/**
-START
STORAGE PROCEDURES FOR PROVINCES, CANTONS AND DISTRICTS
**/


CREATE PROCEDURE RET_LST_PROVINCES
AS
	SELECT code as 'P_Code', Code, Name_Value from LST_PROVINCES
GO


CREATE PROCEDURE RET_LST_CANTONS
AS
	SELECT P_Code, Code, Name_Value from LST_CANTONS
GO

CREATE PROCEDURE RET_LST_DISTRICTS
AS
	SELECT P_Code, Code, Name_Value from LST_DISTRICTS
GO



/**
-START 
STORAGE PROCEDURES FOR PERMISSIONS
**/

CREATE PROCEDURE RET_VIEW_BY_USER
	@SP_Id_User_Type VARCHAR(1) 
AS
	SELECT P.Id_User_Type, V.Controller_Name, V.View_Name, V.View_Description, V.Group_View
	FROM TBL_PERMISSIONS AS P
	JOIN 
	TBL_VIEWS AS V ON P.Id_View = V.View_ID 
	WHERE P.Id_User_Type = @SP_Id_User_Type

GO

/*
	EXECUTE PROCEDURES
*/


EXEC [dbo].[SP_INSERT_TBL_ADMIN_USER] 'admin', '12345678', '1'
GO
EXEC [dbo].[SP_INSERT_TBL_FINANCIAL_USER] 'financiero', '12345678', '1'
GO
EXEC [dbo].[SP_INSERT_TBL_RECRUITER_USER] 'reclutador', '12345678', '1', 1
GO



EXEC [dbo].[SP_INSERT_TBL_STUDENT] '1','1',
           'Estudiante'
           ,'N', '123456789' 
           ,'2002-03-27'
           ,20
           ,'example@gmail.com'
           ,'87878787'
           ,'1','01', '10'
           ,'Sí'
           ,'Comida Rápidas'
           ,'Servicio al cliente'
           ,'Atención del servicio de mesas'
           ,'Sí'
           ,'Universidad'
           ,'UCR'
           ,'Bachiillerato Universitario'
           ,'En curso'
           ,'Contabilidad'
           ,'Básico'
           ,'Inmediata'
           ,'Sí'
           ,'Sí'
           ,'A1,B1'
           ,'Gestor de Servicios Bancarios,Gestor de Cobros'
           ,'Shary Catellón,Esteban Mata'
           ,'Español'
           ,'2022-03-27'
           ,'Lunes'
           ,'6 pm a 9 pm'
           ,'Cowork Real Cariari'
           ,'No'
           ,'No'
           ,'Si'
           ,'estudiante'
           ,'12345678'

GO