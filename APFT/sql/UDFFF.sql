GO
CREATE FUNCTION Ginasio.funcPlanoTreinoCliente (@CC_Cliente INT) RETURNS @table
TABLE([nameEx] VARCHAR(50), [numReps] int, [numSeries] int, [tempo] time)
AS
    BEGIN
        INSERT @table
		SELECT Ginasio.Exercicio.Nome,Ginasio.Inclui.Tempo, Ginasio.Inclui.Num_Reps, Ginasio.Inclui.Num_Series 
		From  Ginasio.Cliente join Ginasio.Plano_Treino on Ginasio.Cliente.CC = Ginasio.Plano_Treino.CC_Cliente join Ginasio.Inclui on Ginasio.Inclui.ID_PT = Ginasio.Plano_Treino.ID join Ginasio.Exercicio on Ginasio.Exercicio.ID = Ginasio.Inclui.ID_Ex
        WHERE Ginasio.Cliente.CC= @CC_Cliente
		RETURN;
    END
GO
-- Test
SELECT * FROM Company.Works_on;
SELECT * FROM Company.Project;
SELECT * FROM Company.func_name_location_from_project(21312332);
SELECT * FROM Company.func_name_location_from_project(183623612); -- este Essn não está no Works_on
SELECT * From Company.func_name_location_from_project(41124234);

--Cliente dar return do plano de treino e dos exercicios:

--Crie uma UDF que, para determinado funcionário (ssn), devolva o nome e localização dos projetos em que trabalha.

GO
CREATE FUNCTION Company.func_name_location_from_project (@func_ssn INT) RETURNS @table
TABLE([name] VARCHAR(45), [location] VARCHAR(15))
AS
    BEGIN
        INSERT @table
        SELECT  Company.Project.Pname, Company.Project.Plocation FROM Company.Project
        INNER JOIN Company.Works_on ON Company.Works_on.Pno = Company.Project.Pnumber
        WHERE Works_on.Essn=@func_ssn
		RETURN;
    END
GO
-- Test
SELECT * FROM Company.Works_on;
SELECT * FROM Company.Project;
SELECT * FROM Company.func_name_location_from_project(21312332);
SELECT * FROM Company.func_name_location_from_project(183623612); -- este Essn não está no Works_on
SELECT * From Company.func_name_location_from_project(41124234);
```