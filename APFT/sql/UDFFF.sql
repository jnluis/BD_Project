GO
CREATE FUNCTION Ginasio.funcPlanoTreinoCliente (@CC_Cliente INT) RETURNS @table
TABLE([nameEx] VARCHAR(50), [numReps] INT, [numSeries] INT, [tempo] VARCHAR(8))
AS
BEGIN
    INSERT @table
    SELECT Ginasio.Exercicio.Nome, Ginasio.Inclui.Num_Reps, Ginasio.Inclui.Num_Series, Ginasio.Inclui.Tempo
    FROM Ginasio.Cliente
    JOIN Ginasio.Plano_Treino ON Ginasio.Cliente.CC = Ginasio.Plano_Treino.CC_Cliente
    JOIN Ginasio.Inclui ON Ginasio.Inclui.ID_PT = Ginasio.Plano_Treino.ID
    JOIN Ginasio.Exercicio ON Ginasio.Exercicio.ID = Ginasio.Inclui.ID_Ex
    WHERE Ginasio.Cliente.CC = @CC_Cliente;

    RETURN;
END
GO

-- Test

SELECT * FROM Ginasio.funcPlanoTreinoCliente(123456789);
SELECT * FROM Ginasio.funcPlanoTreinoCliente(245678912);
SELECT * From Ginasio.funcPlanoTreinoCliente(290123456);

