# BD: Trabalho Prático APF-T

**Grupo**: P4G5
- João Luís, NMEC: 107403
- Diana Miranda, NMEC: 107457

# Instructions - TO REMOVE

Este template é flexível.
É sugerido seguir a estrutura, links de ficheiros e imagens, mas adicione ou remova conteúdo sempre que achar necessário.

---

This template is flexible.
It is suggested to follow the structure, file links and images but add more content where necessary.

The files should be organized with the following nomenclature:

- sql\01_ddl.sql: mandatory for DDL
- sql\02_sp_functions.sql: mandatory for Store Procedure, Functions,... 
- sql\03_triggers.sql: mandatory for triggers
- sql\04_db_init.sql: scripts to init the database (i.e. inserts etc.)
- sql\05_any_other_matter.sql: any other scripts.

Por favor remova esta secção antes de submeter.

Please remove this section before submitting.

## Introdução / Introduction
 
Para o projeto de Bases de Dados, decidimos desenvolver um Sistema de Gestão de Ginásios. Com este sistema, pretendemos proporcionar aos gestores do ginásio uma ferramenta eficaz para gerir todas as operações de forma mais eficiente e assertiva.
Nesta entrega temos a análise de requisitos, o Diagrama Entidade-Relacionamento e o Esquema Relacional para a base de dados a desenvolver no resto do projeto.  

## ​Análise de Requisitos / Requirements

* Um cliente é caracterizado por nome, CC, data de nascimento, morada, contribuinte, número telemóvel e email.
* Quando um cliente se inscreve pela primeira vez no ginásio, é necessário subscrever um plano de adesão que pode ser mensal, anual ou semanal.
* Um plano de adesão é definido pelo tipo, preço, data de início, data de fim.
* Quando um plano de adesão é criado pelo Rececionista, é emitido um pagamento para o cliente realizar, que aquando realizado é registada a data. Este pagamento é caracterizado por um ID, valor, método, estado, data de vencimento e data de cancelamento (se se aplicar).
* Todos os membros do staff são identificados por número de funcionário, nome, CC, NIF, data de nascimento, e-mail, número de telemóvel, morada, horário de trabalho, salário e data de contratação.
* O cliente tem a opção de solicitar um plano de treino a um professor. Esse plano é definido por um ID, data de início, data de fim e número de treinos por semana. Para cada exercício, é necessário especificar o ID, nome e quando este é incluído num plano é possível definir o número de séries, número de repetições e tempo de execução. O exercício pode utilizar ou não um equipamento.
* O equipamento é caracterizado por ID e nome.
* O professor faz parte do staff, no entanto tem também de entregar as suas certificações.
* O professor pode dar aulas no ginásio, que são identificadas por um ID. É registado em cada aula a sala onde se vai realizar. Cada aula pode ser realizada em vários horários diferentes. Cada horário é definido pela hora de início e fim e pelo dia da semana em que se vai realizar.
* Cada sala é definida por um ID, número máximo de alunos e tipo.
* O cliente pode inscrever-se em várias aulas desde que haja disponibilidade e a inscrição seja aceite.
* O cliente tem a opção de fornecer feedback sobre o seu plano de treino ao treinador que o criou. Este feedback é caracterizado pela data e comentários associados.
* Embora seja um membro do staff, o gerente tem a responsabilidade de gerir a equipa de funcionários.

## DER - Diagrama Entidade Relacionamento/Entity Relationship Diagram

### Versão final/Final version

![DER Diagram!](der.jpg "AnImage")

### APFE 

Descreva sumariamente as melhorias sobre a primeira entrega.
Describe briefly the improvements made since the first delivery.

## ER - Esquema Relacional/Relational Schema

### Versão final/Final Version

![ER Diagram!](er.jpg "AnImage")

### APFE

Descreva sumariamente as melhorias sobre a primeira entrega.
Describe briefly the improvements made since the first delivery.

## ​SQL DDL - Data Definition Language

[SQL DDL File](sql/01_ddl.sql "SQLFileQuestion")

## SQL DML - Data Manipulation Language

Uma secção por formulário.
A section for each form.

### Formulario exemplo/Example Form

![Exemplo Screenshot!](screenshots/screenshot_1.jpg "AnImage")

```sql
-- Show data on the form
SELECT * FROM MY_TABLE ....;
SELECT Nome FROM Ginasio.Exercicio ORDER BY Nome
SELECT Fname, Lname FROM Ginasio.Staff WHERE Num_func = @IDinicial
Select * From Ginasio.Plano_Adesao Where Num_Rec = @numFunc

-- Insert new element
INSERT INTO MY_TABLE ....;

INSERT INTO Ginasio.Plano_Adesao (Tipo, CC_Cliente, Preco, Data_Fim, Data_Inicio, Num_Rec) " + "VALUES (@tipo, @cc, @preco, @dataFim, @dataInicio, @numRec)
INSERT INTO Ginasio.Cliente (CC, Fname, Lname, Email, Telemovel, NIF, Morada, Data_Nasc) " + "VALUES (@CC, @Fname, @Lname, @Email, @Telemovel, @NIF, @Morada, @Data_Nasc)
UPDATE Ginasio.Cliente " + "SET Fname = @Fname, " + "Lname = @Lname, " + " Email = @Email, " + " Telemovel = @Telemovel, " + " NIF = @NIF, " + " Morada = @Morada, " + " Data_Nasc = @Data_Nasc " + "WHERE CC = @CC
DELETE Ginasio.Cliente WHERE CC=@CC



```

...

## Normalização/Normalization

Descreva os passos utilizados para minimizar a duplicação de dados / redução de espaço.
Justifique as opções tomadas.
Describe the steps used to minimize data duplication / space reduction.
Justify the choices made.

## Índices/Indexes

Descreva os indices criados. Junte uma cópia do SQL de criação do indice.
Describe the indexes created. Attach a copy of the SQL to create the index.

```sql
-- Create an index to speed
CREATE INDEX index_name ON table_name (column1, column2, ...);
```

## SQL Programming: Stored Procedures, Triggers, UDF

[SQL SPs and Functions File](sql/02_sp_functions.sql "SQLFileQuestion")

[SQL Triggers File](sql/03_triggers.sql "SQLFileQuestion")

## Outras notas/Other notes

### Dados iniciais da dabase de dados/Database init data

[Indexes File](sql/01_dml.sql "SQLFileQuestion")



 