-- Verifica se o cliente tem o pagamento confirmado para criar o plano de treino ---
GO
CREATE TRIGGER Ginasio.VerificarPagamento
ON Ginasio.Plano_Treino
INSTEAD OF INSERT, Update
AS
	BEGIN
	DECLARE @idCliente as int
	SELECT @idCliente = CC_Cliente From inserted;
		IF (Select Estado From Ginasio.Pagamento Where CC_Cliente = @idCliente) != 'Pago'
			RAISERROR('Não é possível criar/editar o plano de Treino! O cliente tem o pagamento da subscrição pendente ou cancelado.', 16, 1);
		ELSE
			INSERT INTO Ginasio.Plano_Treino SELECT * FROM inserted;
END
GO

-- Verifica se o cliente já tem um plano de adesao criado por outro funcionário ---
GO
CREATE TRIGGER Ginasio.VerificarClientePlanosAdesao
ON Ginasio.Plano_Adesao
INSTEAD OF INSERT
AS
	BEGIN
	DECLARE @idCliente as int
	SELECT @idCliente = CC_Cliente From inserted;
		IF (Select Count(CC_Cliente) From Ginasio.Plano_Adesao Where CC_Cliente = @idCliente) > 0
			RAISERROR('Este Cliente já tem um plano de adesão criado por outro funcionário.', 16, 1);
		ELSE
			INSERT INTO Ginasio.Plano_Adesao SELECT * FROM inserted;
END
GO

-- Verificar se ainda há vagas disponíveis para inscrição na aula ---
GO
CREATE TRIGGER Ginasio.VerificarNInscritosAula
ON Ginasio.Inscreve
INSTEAD OF INSERT, UPDATE
AS
	BEGIN
	DECLARE @idHaula as int
	SELECT @idHaula = ID_HAula From inserted;
		IF (SELECT COUNT(ID_HAula)
			FROM Ginasio.Inscreve
			WHERE Estado = 'Confirmada' AND ID_HAula = @idHaula) >= (
			SELECT Sala.Num_Max_alunos
			FROM Ginasio.Sala
			JOIN Ginasio.Aula ON Sala.ID = Aula.Sala_ID
			JOIN Ginasio.Aula_Horario ON Aula.ID = Aula_Horario.Aula_ID
			JOIN inserted ON ID_Horario = inserted.ID_HAula
		)
			RAISERROR('Não há mais vagas disponíveis nesta aula.', 16, 1);
		ELSE
			INSERT INTO Ginasio.Inscreve
			SELECT *
			FROM inserted;
END
GO

-- Verifica se algum professor ou rececionista tem salário superior ao seu gerente
GO
CREATE TRIGGER Ginasio.check_salary
ON Ginasio.staff
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (SELECT * FROM inserted WHERE Salario > (SELECT Salario FROM Ginasio.staff WHERE Num_func = inserted.Gerente_Num))
	BEGIN
		RAISERROR('Error: Employee salary cannot be greater than manager salary.', 16, 1);
		ROLLBACK TRAN;
	END
	ELSE
		PRINT 'Success';
END;
GO