
CREATE TABLE LST_PROVINCES (
  id int NOT NULL,
  code varchar(3) DEFAULT NULL,
  name_value varchar(45) DEFAULT NULL,
  PRIMARY KEY (id)
) 

INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('1', '1', 'San José');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('2', '2', 'Alajuela');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('3', '3', 'Cartago');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('4', '4', 'Heredia');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('5', '5', 'Guanacaste');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('6', '6', 'Puntarenas');
INSERT INTO LST_PROVINCES (id, code, name_value) VALUES ('7', '7', 'Limón');