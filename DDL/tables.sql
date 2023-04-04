USE Project;
GO

DROP TABLE IF EXISTS Ginasio.Cliente;
DROP TABLE IF EXISTS Ginasio.Staff;
DROP TABLE IF EXISTS Ginasio.Treinador;
DROP TABLE IF EXISTS Ginasio.Rececionista;
DROP TABLE IF EXISTS Ginasio.Gerente;
DROP TABLE IF EXISTS Ginasio.Pagamento;
DROP TABLE IF EXISTS Ginasio.Plano_Adesao;
DROP TABLE IF EXISTS Ginasio.Feedback;
DROP TABLE IF EXISTS Ginasio.Aula;
DROP TABLE IF EXISTS Ginasio.Horario;
DROP TABLE IF EXISTS Ginasio.Sala;
DROP TABLE IF EXISTS Ginasio.Plano_Treino;
DROP TABLE IF EXISTS Ginasio.Exercicio;
DROP TABLE IF EXISTS Ginasio.Equipamento;
DROP TABLE IF EXISTS Ginasio.Inclui;
DROP TABLE IF EXISTS Ginasio.Inscreve;

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
    Data_Nasc   DATE            NOT NULL,
    ID_Treino   INT             NOT NULL,

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
    Gerente_Num INT,

    PRIMARY KEY (Num_func)
);

CREATE TABLE Ginasio.Treinador(
    Num_func        INT         NOT NULL,
    Certificacoes   VARCHAR(100), -- de que tipo é isto???

    PRIMARY KEY (Num_func)
);

CREATE TABLE Ginasio.Rececionista(
    Num_func    INT             NOT NULL,

    PRIMARY KEY (Num_func)
);

CREATE TABLE Ginasio.Gerente(
    Num_func    INT             NOT NULL,

    PRIMARY KEY (Num_func)
);

CREATE TABLE Ginasio.Pagamento(
    ID          INT             NOT NULL,
    Valor       SMALLMONEY      NOT NULL,
    Metodo      VARCHAR(50)     NOT NULL,
    Estado      VARCHAR(50)     NOT NULL,
    Data_venc   DATE            NOT NULL,
    Data_canc   DATE            NOT NULL,
    CC_Cliente  INT             NOT NULL,
    Num_Rec     INT             NOT NULL-- de que tipo é isto???

    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Plano_Adesao(
    Tipo        VARCHAR(50)     NOT NULL,
    CC_Cliente  INT             NOT NULL,
    Preco       SMALLMONEY      NOT NULL,
    Servicos    VARCHAR(50)     NOT NULL,
    Data_fim    DATE            NOT NULL,
    Data_inicio DATE            NOT NULL, 
    Num_Rec     INT             NOT NULL-- de que tipo é isto???

    PRIMARY KEY (CC_Cliente)
);

CREATE TABLE Ginasio.Feedback(
    CC_Cliente      INT             NOT NULL,
    ID_treinador    INT             NOT NULL,
    Comentários     VARCHAR(800)    NOT NULL,
    [Data]          DATE            NOT NULL,

    PRIMARY KEY (CC_Cliente, ID_treinador)
);

CREATE TABLE Ginasio.Aula(
    ID          INT             NOT NULL,
    Sala_ID     INT             NOT NULL,
    Num_Insc    INT             NOT NULL,    
    
    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Horario(
    Aula_ID     INT             NOT NULL,
    Hora_Inicio TIME            NOT NULL,
    Hora_Fim    TIME            NOT NULL,
    Dia_Semana  VARCHAR(50)     NOT NULL,    
    
    PRIMARY KEY (Aula_ID)
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
    Data_Fim                DATE    NOT NULL, 
    Num_Treinos_Semanais    TINYINT NOT NULL,
    ID_Treinador            INT     NOT NULL,
    CC_Cliente              INT     NOT NULL,

    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Exercicio(
    ID              INT     NOT NULL,
    Num_Reps        TINYINT NOT NULL,
    ID_Equipamento  INT     NOT NULL,
 
    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Equipamento(
    ID      INT         NOT NULL,
    Nome    VARCHAR(50) NOT NULL,
 
    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Inclui(
    ID      INT         NOT NULL,
    Nome    VARCHAR(50) NOT NULL,
 
    PRIMARY KEY (ID)
);

CREATE TABLE Ginasio.Inscreve(
    ID_Aula     INT         NOT NULL,
    CC_Cliente  INT         NOT NULL,
    Estado      VARCHAR(50) NOT NULL,

    PRIMARY KEY (ID_Aula, CC_Cliente)
); 