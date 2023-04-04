USE Project;
GO

ALTER TABLE Ginasio.Cliente DROP CONSTRAINT IF EXISTS ID_Treino;
ALTER TABLE Ginasio.Treinador DROP CONSTRAINT IF EXISTS Num_Trein;
ALTER TABLE Ginasio.Rececionista DROP CONSTRAINT IF EXISTS Num_Recec;
ALTER TABLE Ginasio.Gerente DROP CONSTRAINT IF EXISTS Num_Gere;
ALTER TABLE Ginasio.Staff DROP CONSTRAINT IF EXISTS Gerente_Num;
ALTER TABLE Ginasio.Plano_Adesao DROP CONSTRAINT IF EXISTS CC_Cliente;
ALTER TABLE Ginasio.Plano_Adesao DROP CONSTRAINT IF EXISTS Num_Rec;
ALTER TABLE Ginasio.Pagamento DROP CONSTRAINT IF EXISTS CC_Cliente_Paga;
ALTER TABLE Ginasio.Pagamento DROP CONSTRAINT IF EXISTS Num_Rec_Paga;
ALTER TABLE Ginasio.Feedback DROP CONSTRAINT IF EXISTS CC_Cliente_Feed;
ALTER TABLE Ginasio.Feedback DROP CONSTRAINT IF EXISTS ID_Treinador_Feed;
ALTER TABLE Ginasio.Aula DROP CONSTRAINT IF EXISTS Sala_ID;
ALTER TABLE Ginasio.Horario DROP CONSTRAINT IF EXISTS Aula_ID;
ALTER TABLE Ginasio.Plano_Treino DROP CONSTRAINT IF EXISTS ID_Treinador_PlanoT;
ALTER TABLE Ginasio.Plano_Treino DROP CONSTRAINT IF EXISTS CC_Cliente_PlanoT;
ALTER TABLE Ginasio.Exercicio DROP CONSTRAINT IF EXISTS ID_Equipamento;
ALTER TABLE Ginasio.Inclui DROP CONSTRAINT IF EXISTS ID_Aula_Insc;
ALTER TABLE Ginasio.Inclui DROP CONSTRAINT IF EXISTS CC_Cliente_Insc;

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

    PRIMARY KEY (CC_Cliente,Num_Rec)
);

CREATE TABLE Ginasio.Feedback(
    CC_Cliente      INT             NOT NULL,
    ID_Treinador    INT             NOT NULL,
    Comentários     VARCHAR(800)    NOT NULL,
    [Data]          DATE            NOT NULL,

    PRIMARY KEY (CC_Cliente, ID_Treinador)
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
    ID_Ex       INT         NOT NULL,
    ID_PT       INT         NOT NULL,
    Tempo       TIME        NOT NULL,
    Num_Series  TINYINT     NOT NULL,
    Nome        VARCHAR(50) NOT NULL,
 
    PRIMARY KEY (ID_Ex, ID_PT)
);

CREATE TABLE Ginasio.Inscreve(
    ID_Aula     INT         NOT NULL,
    CC_Cliente  INT         NOT NULL,
    Estado      VARCHAR(50) NOT NULL,

    PRIMARY KEY (ID_Aula, CC_Cliente)
); 

ALTER TABLE Ginasio.cliente ADD CONSTRAINT ID_Treino FOREIGN KEY (ID_Treino) REFERENCES Ginasio.Plano_Treino(ID)

ALTER TABLE Ginasio.Treinador ADD CONSTRAINT Num_Trein FOREIGN KEY (Num_func) REFERENCES Ginasio.Staff(Num_func) 
ALTER TABLE Ginasio.Rececionista ADD CONSTRAINT Num_Recec FOREIGN KEY (Num_func) REFERENCES Ginasio.Staff(Num_func)
ALTER TABLE Ginasio.Gerente ADD CONSTRAINT Num_Gere FOREIGN KEY (Num_func) REFERENCES Ginasio.Staff(Num_func)

ALTER TABLE Ginasio.Staff ADD CONSTRAINT Gerente_Num FOREIGN KEY (Gerente_Num) REFERENCES Ginasio.Gerente(Num_func)

ALTER TABLE Ginasio.Plano_Adesao ADD CONSTRAINT CC_Cliente FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Cliente(CC)
ALTER TABLE Ginasio.Plano_Adesao ADD CONSTRAINT Num_Rec FOREIGN KEY (Num_Rec) REFERENCES Ginasio.Rececionista(Num_func)

ALTER TABLE Ginasio.Pagamento ADD CONSTRAINT CC_Cliente_Paga FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Plano_Adesao(CC_Cliente)
ALTER TABLE Ginasio.Pagamento ADD CONSTRAINT Num_Rec_Paga FOREIGN KEY (Num_Rec) REFERENCES Ginasio.Plano_Adesao(Num_Rec)

ALTER TABLE Ginasio.Feedback ADD CONSTRAINT CC_Cliente_Feed FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Plano_Adesao(Num_Rec)
ALTER TABLE Ginasio.Feedback ADD CONSTRAINT ID_Treinador_Feed FOREIGN KEY (ID_Treinador) REFERENCES Ginasio.Treinador(Num_func)

ALTER TABLE Ginasio.Aula ADD CONSTRAINT Sala_ID FOREIGN KEY (Sala_ID) REFERENCES Ginasio.Sala(ID)

ALTER TABLE Ginasio.Horario ADD CONSTRAINT Aula_ID FOREIGN KEY (Aula_ID) REFERENCES Ginasio.Aula(ID)

ALTER TABLE Ginasio.Plano_Treino ADD CONSTRAINT ID_Treinador_PlanoT FOREIGN KEY (ID_Treinador) REFERENCES Ginasio.Treinador(Num_func)
ALTER TABLE Ginasio.Plano_Treino ADD CONSTRAINT CC_Cliente_PlanoT FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Cliente(CC)

ALTER TABLE Ginasio.Exercicio ADD CONSTRAINT ID_Equipamento FOREIGN KEY (ID_Equipamento) REFERENCES Ginasio.Equipamento(ID)

ALTER TABLE Ginasio.Inclui ADD CONSTRAINT ID_Ex FOREIGN KEY (ID_Ex) REFERENCES Ginasio.Exercicio(ID)
ALTER TABLE Ginasio.Inclui ADD CONSTRAINT ID_PT FOREIGN KEY (ID_PT) REFERENCES Ginasio.Plano_Treino(ID)

ALTER TABLE Ginasio.Inscreve ADD CONSTRAINT ID_Aula_Insc FOREIGN KEY (ID_Aula) REFERENCES Ginasio.Horario(Aula_ID) -- aqui temos horario(aula_ID) Mas como essa é referenciada  à AUla(ID) não deveria ser Aula(ID), não podemos fazer esta ligação direta
ALTER TABLE Ginasio.Inscreve ADD CONSTRAINT CC_Cliente_Insc FOREIGN KEY (CC_Cliente) REFERENCES Ginasio.Cliente(CC)
