----- SP para adicionar um exercício a um plano de treino -----

CREATE PROCEDURE Ginasio.InserirExercicioNumPlanoTreino
    @Nome VARCHAR(50),
    @Tempo TIME,
	@Num_Series INT,
	@Num_Reps INT,
	@idCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    
    BEGIN TRY
		DECLARE @idEx INT = (SELECT ID FROM Ginasio.Exercicio WHERE Nome = @Nome);
		DECLARE @idPT INT = (SELECT ID FROM Ginasio.Plano_Treino WHERE CC_Cliente = @idCliente);

        INSERT INTO Ginasio.Inclui (ID_Ex, ID_PT, Tempo, Num_Series, Num_Reps)
        VALUES (@idEx, @idPT, @Tempo, @Num_Series, @Num_Reps);
        
        COMMIT;
    END TRY
    BEGIN CATCH
		    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
			PRINT 'Ocorreu um erro: ' + @ErrorMessage;
		ROLLBACK;
    END CATCH;
END
GO
----- SP para eliminar um exercício a um plano de treino -----

CREATE PROCEDURE Ginasio.EliminarExercicioNumPlanoTreino
    @Nome VARCHAR(50),
	@idCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    
    BEGIN TRY
		DECLARE @idEx INT = (SELECT ID FROM Ginasio.Exercicio WHERE Nome = @Nome);
		DECLARE @idPT INT = (SELECT ID FROM Ginasio.Plano_Treino WHERE CC_Cliente = @idCliente);

        DELETE FROM Ginasio.Inclui WHERE ID_Ex = @idEx AND ID_PT = @idPT;
        
        COMMIT;
    END TRY
    BEGIN CATCH
		    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
			PRINT 'Ocorreu um erro: ' + @ErrorMessage;
		ROLLBACK;
    END CATCH;
END
GO

---Inscreve, feedback, Plano Adesão, Plano_Treino SET NULL, Pagamento SET NULL e finalmente cliente
CREATE PROCEDURE Ginasio.EliminarCliente
	@idCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    
    BEGIN TRY
		-- DECLARE @idPT INT = (SELECT CC_Cliente FROM Ginasio.Inscreve WHERE CC_Cliente = @idCliente);
		--UPDATE Ginasio.Pagamento SET CC_Cliente=NULL WHERE CC_Cliente= @idCliente ; Não dá para dar update para NULL neste momento, porque as tabelas têm NOT NULL
		--UPDATE Ginasio.Plano_Treino SET CC_Cliente=NULL WHERE CC_Cliente= @idCliente ;
		DELETE FROM Ginasio.Plano_Treino WHERE CC_Cliente = @idCliente;
        DELETE FROM Ginasio.Inscreve WHERE CC_Cliente = @idCliente;
		DELETE FROM Ginasio.Feedback WHERE CC_Cliente = @idCliente;
		DELETE FROM Ginasio.Pagamento WHERE CC_Cliente = @idCliente;
		DELETE FROM Ginasio.Plano_Adesao WHERE CC_Cliente= @idCliente;
		
        DELETE FROM Ginasio.Cliente WHERE CC = @idCliente;

        COMMIT;
    END TRY
    BEGIN CATCH
		    DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
			PRINT 'Ocorreu um erro: ' + @ErrorMessage;
		ROLLBACK;
    END CATCH;
END
GO
EXEC Ginasio.EliminarCliente '901234567'
SELECT * FROM Ginasio.Cliente
----- SP Para ver o id inserido está correto -----
GO
CREATE PROCEDURE Ginasio.CheckIDExists
    @ID INT,
	@IsClient TINYINT
AS
BEGIN
    SET NOCOUNT ON;

	IF @IsClient = 1
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Ginasio.Cliente WHERE CC = @ID)
        BEGIN
            SELECT 1
        END
        ELSE
        BEGIN
            SELECT 0
        END
    END
    ELSE IF @IsClient = 2
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Ginasio.Professor WHERE Num_func = @ID)
        BEGIN
            SELECT 1
        END
        ELSE
        BEGIN
            SELECT 0
        END
    END
	    ELSE IF @IsClient = 3
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Ginasio.Gerente WHERE Num_func = @ID)
        BEGIN
            SELECT 1
        END
        ELSE
        BEGIN
            SELECT 0
        END
    END
	    ELSE IF @IsClient = 4
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Ginasio.Rececionista WHERE Num_func = @ID)
        BEGIN
            SELECT 1
        END
        ELSE
        BEGIN
            SELECT 0
        END
    END
END
GO
-- testar a SP CheckIDExists
EXEC Ginasio.CheckIDExists 1004, 1;

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

----- UDF Para o cliente ver as aulas em que está inscrito -----

GO
CREATE FUNCTION Ginasio.funcAulasInscritas (@CC_Cliente INT) RETURNS @table
TABLE([Aula] VARCHAR(30), [Hora_Inicio] VARCHAR(5), [Hora_Fim] VARCHAR(5), [Dia_Semana] VARCHAR(25), [Estado] VARCHAR(15))
AS
BEGIN
    INSERT @table
    SELECT Tipo, Hora_Inicio, Hora_Fim, Dia_Semana, Estado 
    FROM Ginasio.Aula_Horario 
    JOIN Ginasio.Aula ON Aula_ID =ID 
    JOIN Ginasio.Sala ON Sala_ID = Ginasio.Sala.ID 
    JOIN Ginasio.Inscreve ON ID_HAula = ID_Horario
    WHERE CC_Cliente = @CC_Cliente;
    RETURN;
END
GO

SELECT * FROM Ginasio.funcPlanoTreinoCliente(123456789);

----- UDF para ver total de inscrições numa aula  -----

CREATE FUNCTION Ginasio.Inscricoes ()
RETURNS @table TABLE ([Aula] VARCHAR(30), [Número Inscrições] INT)
AS
BEGIN
    INSERT INTO @table
    SELECT Tipo, COUNT(Ginasio.Aula.ID)
    FROM Ginasio.Aula 
    JOIN Ginasio.Aula_Horario ON Aula_ID = ID
    JOIN Ginasio.Inscreve ON ID_HAula = ID_Horario
    JOIN Ginasio.Sala ON Ginasio.Sala.ID = Sala_ID
    WHERE Estado = 'Confirmada'
    GROUP BY Tipo

    RETURN;
END
GO

----- UDF para ver a quantidade de cada tipo de plano de adesao criados -----

CREATE FUNCTION Ginasio.TiposPlanosAdesao ()
RETURNS @table TABLE ([Tipo] VARCHAR(30), [Quantidade] INT)
AS
BEGIN
    INSERT INTO @table
    Select Tipo, COUNT(Tipo)
    FROM Ginasio.Plano_Adesao
    GROUP BY Tipo
    RETURN;
END
GO

----- UDF para controlar o estado dos pagamentos -----

CREATE FUNCTION Ginasio.EstadoPagamentos ()
RETURNS @table TABLE ([Estado] VARCHAR(30), [Quantidade] INT)
AS
BEGIN
    INSERT INTO @table
    Select Estado, COUNT(Estado)
    FROM Ginasio.Pagamento
    GROUP BY Estado
    RETURN;
END
GO


----- UDF para ver média de salários por cargo -----

CREATE FUNCTION Ginasio.MediasSalarios()
RETURNS @MediasSalarios TABLE
(
    Cargo NVARCHAR(50),
    MediaSalario DECIMAL(10, 2)
)
AS
BEGIN
    INSERT INTO @MediasSalarios (Cargo, MediaSalario)
	SELECT 'Professores', AVG(Salario) AS MediaSalarioProfessores
	FROM Ginasio.Staff as s
	JOIN Ginasio.Professor as p ON s.Num_func = p.Num_func;

    INSERT INTO @MediasSalarios (Cargo, MediaSalario)
	SELECT 'Gerentes', AVG(Salario) AS MediaSalarioGerentes
	FROM Ginasio.Staff as s
	JOIN Ginasio.Gerente as g ON s.Num_func = g.Num_func;

    INSERT INTO @MediasSalarios (Cargo, MediaSalario)
	SELECT 'Rececionistas', AVG(Salario) AS MediaSalarioRececionistas
	FROM Ginasio.Staff as s
	JOIN Ginasio.Rececionista as r ON s.Num_func = r.Num_func;

    RETURN;
END;

