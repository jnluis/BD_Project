----- UDF Para ver o plano de treino de um cliente -----

GO
CREATE FUNCTION Ginasio.funcPlanoTreinoCliente (@CC_Cliente INT) RETURNS @table
TABLE([Exercicio] VARCHAR(50), [Repetições] INT, [Séries] INT, [Tempo] VARCHAR(8), [Equipamento] VARCHAR(50))
AS
BEGIN
    INSERT @table
    SELECT Ginasio.Exercicio.Nome, Ginasio.Inclui.Num_Reps, Ginasio.Inclui.Num_Series, Ginasio.Inclui.Tempo, Ginasio.Equipamento.Nome
    FROM Ginasio.Cliente
    JOIN Ginasio.Plano_Treino ON Ginasio.Cliente.CC = Ginasio.Plano_Treino.CC_Cliente
    JOIN Ginasio.Inclui ON Ginasio.Inclui.ID_PT = Ginasio.Plano_Treino.ID
    JOIN Ginasio.Exercicio ON Ginasio.Exercicio.ID = Ginasio.Inclui.ID_Ex
	JOIN Ginasio.Equipamento ON Ginasio.Equipamento.ID = Ginasio.Exercicio.ID_Equipamento
    WHERE Ginasio.Cliente.CC = @CC_Cliente;

    RETURN;
END
GO


SELECT * FROM Ginasio.funcPlanoTreinoCliente(123456789);

----- UDF Para ver o horario de um professor -----

GO
CREATE FUNCTION Ginasio.funcHorarioProfessor (@IDProf INT) RETURNS @table
TABLE([Hora_Inicio] VARCHAR(5), [Hora_Fim] VARCHAR(5), [Dia_Semana] VARCHAR(25), [Tipo] VARCHAR(15))
AS
BEGIN
    INSERT @table
    SELECT Hora_Inicio, Hora_Fim, Dia_Semana, Tipo
    FROM Ginasio.Aula_Horario 
    JOIN Ginasio.Aula ON Ginasio.Aula.ID = Ginasio.Aula_Horario.Aula_ID 
    JOIN Ginasio.Sala ON Ginasio.Sala.ID = Ginasio.Aula.Sala_ID
    WHERE ID_Professor = @IDProf;
    RETURN;
END
GO

--Test
SELECT * FROM Ginasio.funcHorarioProfessor(1004);
