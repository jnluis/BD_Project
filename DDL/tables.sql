-- USE Project;
-- GO

IF OBJECT_ID('Ginasio.Exercicio', 'U') IS NOT NULL
AND OBJECT_ID('Ginasio.Aula', 'U') IS NOT NULL
AND OBJECT_ID('Ginasio.Staff', 'U') IS NOT NULL
BEGIN
    ALTER TABLE Ginasio.Exercicio DROP CONSTRAINT IF EXISTS ID_Equipamento;
    ALTER TABLE Ginasio.Aula DROP CONSTRAINT IF EXISTS Sala_ID;
    ALTER TABLE Ginasio.Staff DROP CONSTRAINT IF EXISTS Gerente_Num;
END

DROP TABLE IF EXISTS Ginasio.Certificacoes_Prof;
DROP TABLE IF EXISTS Ginasio.Inscreve;
DROP TABLE IF EXISTS Ginasio.Inclui;
DROP TABLE IF EXISTS Ginasio.Equipamento;
DROP TABLE IF EXISTS Ginasio.Exercicio;
DROP TABLE IF EXISTS Ginasio.Plano_Treino;
DROP TABLE IF EXISTS Ginasio.Sala;
DROP TABLE IF EXISTS Ginasio.Aula_Horario
DROP TABLE IF EXISTS Ginasio.Aula;
DROP TABLE IF EXISTS Ginasio.Feedback;
DROP TABLE IF EXISTS Ginasio.Pagamento;
DROP TABLE IF EXISTS Ginasio.Plano_Adesao;
DROP TABLE IF EXISTS Ginasio.Gerente;
DROP TABLE IF EXISTS Ginasio.Rececionista;
DROP TABLE IF EXISTS Ginasio.Professor;
DROP TABLE IF EXISTS Ginasio.Staff;
DROP TABLE IF EXISTS Ginasio.Cliente;

DROP SCHEMA IF EXISTS Ginasio;
GO

Create Schema Ginasio;
GO

CREATE TABLE Ginasio.Cliente(
    CC          INT             NOT NULL,
    Fname       VARCHAR(50)     NOT NULL,
    Lname       VARCHAR(50)     NOT NULL,
    Email       NVARCHAR(255),
    Telemovel   INT             NOT NULL    CHECK (Telemovel >= 900000000 AND Telemovel <= 999999999),
    NIF         INT                         CHECK (NIF >= 100000000 AND NIF <= 999999999),
    Morada      VARCHAR(100),
    Data_Nasc   DATE,

    PRIMARY KEY (CC)
);

CREATE TABLE Ginasio.Staff(
    CC          INT             NOT NULL,
    Fname       VARCHAR(50)     NOT NULL,
    Lname       VARCHAR(50)     NOT NULL,
    Email       NVARCHAR(255),
    Telemovel   INT             NOT NULL    CHECK (Telemovel >= 900000000 AND Telemovel <= 999999999),
    NIF         INT                         CHECK (NIF >= 100000000 AND NIF <= 999999999),
    Morada      VARCHAR(100),
    Data_Nasc   DATE            NOT NULL,
    Salario     INT             NOT NULL    CHECK (Salario >= 0),
    Num_func    INT             NOT NULL,   
    Data_Contr  DATE            NOT NULL,
    Horario_Lab TIME            NOT NULL,
    Gerente_Num INT             NOT NULL,

    PRIMARY KEY (Num_func)
);

CREATE TABLE Ginasio.Professor(
    Num_func        INT         NOT NULL,

    PRIMARY KEY (Num_func),
    FOREIGN KEY (Num_func) REFERENCES Ginasio.Staff(Num_func)
);

CREATE TABLE Ginasio.Rececionista(
    Num_func    INT             NOT NULL,

    PRIMARY KEY (Num_func),
    FOREIGN KEY (Num_func) REFERENCES Ginasio.Staff(Num_func)
);

CREATE TABLE Ginasio.Gerente(
    Num_func    INT             NOT NULL,

    PRIMARY KEY (Num_func),
    FOREIGN KEY (Num_func) REFERENCES Ginasio.Staff(Num_func)
);

CREATE TABLE Ginasio.Plano_Adesao(
    Tipo        VARCHAR(50)     NOT NULL,
    CC_Cliente  INT             NOT NULL,
    Preco       SMALLMONEY      NOT NULL,
    Data_fim    DATE            NOT NULL,
    Data_inicio DATE            NOT NULL, 
    Num_Rec     INT             NOT NULL,

    PRIMARY KEY (CC_Cliente,Num_Rec),
    FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Cliente(CC),
    FOREIGN KEY (Num_Rec) REFERENCES Ginasio.Rececionista(Num_func)
);

CREATE TABLE Ginasio.Pagamento(
    ID          INT             NOT NULL,
    Valor       SMALLMONEY      NOT NULL,
    Metodo      VARCHAR(50)     NOT NULL,
    Estado      VARCHAR(50)     NOT NULL,
    Data_venc   DATE            NOT NULL,
    Data_canc   DATE,
    CC_Cliente  INT             NOT NULL,
    Num_Rec     INT             NOT NULL,
    Data_Pagamento DATE,

    PRIMARY KEY (ID),
    FOREIGN KEY (CC_Cliente, Num_Rec) REFERENCES Ginasio.Plano_Adesao(CC_Cliente, Num_Rec),
    FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Cliente(CC)
);



CREATE TABLE Ginasio.Feedback(
    CC_Cliente      INT             NOT NULL,
    ID_Professor    INT             NOT NULL,
    Comentários     VARCHAR(800)    NOT NULL,
    [Data]          DATE            NOT NULL,

    PRIMARY KEY (CC_Cliente, ID_Professor),
    FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Cliente(CC),
    FOREIGN KEY (ID_Professor) REFERENCES Ginasio.Professor(Num_func)
);

CREATE TABLE Ginasio.Aula(
    ID          INT    NOT NULL,
    Sala_ID     INT,
    Num_Insc    INT    NOT NULL,    
    ID_Professor     INT    NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (ID_Professor) REFERENCES Ginasio.Professor(Num_func)
);

CREATE TABLE Ginasio.Aula_Horario(
    Aula_ID     INT             NOT NULL,
    Hora_Inicio TIME            NOT NULL,
    Hora_Fim    TIME            NOT NULL,
    Dia_Semana  VARCHAR(50)     NOT NULL,    
    
    PRIMARY KEY (Aula_ID, Hora_Inicio, Hora_Fim, Dia_Semana),
    FOREIGN KEY (Aula_ID) REFERENCES Ginasio.Aula(ID)
);

CREATE TABLE Ginasio.Sala(
    ID              INT             NOT NULL,
    Estado          VARCHAR(50)     NOT NULL,
    Num_Max_alunos  TINYINT         NOT NULL,
    
    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Plano_Treino(
    ID                      INT     NOT NULL,
    Data_Inicio             DATE    NOT NULL,
    Data_Fim                DATE, 
    Num_Treinos_Semanais    TINYINT NOT NULL,
    ID_Professor            INT     NOT NULL,
    CC_Cliente              INT     NOT NULL,

    PRIMARY KEY (ID),
    FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Cliente(CC),
    FOREIGN KEY (ID_Professor) REFERENCES Ginasio.Professor(Num_func)
);

CREATE TABLE Ginasio.Exercicio(
    ID              INT          NOT NULL,
    Nome            VARCHAR(50) NOT NULL,
    ID_Equipamento  INT,
 
    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Equipamento(
    ID      INT         NOT NULL,
    Nome    VARCHAR(50) NOT NULL,
 
    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Inclui(
    ID_Ex       INT         NOT NULL,
    ID_PT       INT         NOT NULL,
    Tempo       TIME,
    Num_Series  INT,
    Num_Reps    INT,
 
    PRIMARY KEY (ID_Ex, ID_PT),
    FOREIGN KEY (ID_Ex) REFERENCES Ginasio.Exercicio(ID),
    FOREIGN KEY (ID_PT) REFERENCES Ginasio.Plano_Treino(ID)
);

CREATE TABLE Ginasio.Inscreve(
    ID_Aula     INT         NOT NULL,
    CC_Cliente  INT         NOT NULL,
    Estado      VARCHAR(50),

    PRIMARY KEY (ID_Aula, CC_Cliente),
    FOREIGN KEY (ID_Aula) REFERENCES Ginasio.Aula(ID),
    FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Cliente(CC)
); 

CREATE TABLE Ginasio.Certificacoes_Prof(
    Num_func      INT         NOT NULL,
    Certificacoes VARCHAR(100)  NOT NULL,
    FOREIGN KEY (Num_func) REFERENCES Ginasio.Professor(Num_func)
);


ALTER TABLE Ginasio.Staff ADD CONSTRAINT Gerente_Num FOREIGN KEY (Gerente_Num) REFERENCES Ginasio.Gerente(Num_func);

ALTER TABLE Ginasio.Aula ADD CONSTRAINT Sala_ID FOREIGN KEY (Sala_ID) REFERENCES Ginasio.Sala(ID);

ALTER TABLE Ginasio.Exercicio ADD CONSTRAINT ID_Equipamento FOREIGN KEY (ID_Equipamento) REFERENCES Ginasio.Equipamento(ID);
