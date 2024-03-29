----- SP para adicionar um exercício a um plano de treino -----
GO
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
GO
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

--- SP para Eliminiar um cliente e garantir que todas as informações nas outras tabelas sobre esse cliente são também eliminadas---
GO
CREATE PROCEDURE Ginasio.EliminarCliente
	@idCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;
    
    BEGIN TRY
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

----- SP Para ver o id inserido quando de entra na base de dados está correto -----
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

----- UDF para ver total de inscrições numa aula  -----
GO
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
GO
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
GO
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
GO
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
GO

