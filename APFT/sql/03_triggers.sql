
-- Verifica se o cliente tem o pagamento confirmado para criar o plano de treino ---

CREATE TRIGGER Ginasio.VerificarPagamento
ON Ginasio.Plano_Treino
INSTEAD OF INSERT, Update
AS
	BEGIN
    -- Verificar se o pagamento está confirmado para todos os clientes inseridos nos planos de treino
	DECLARE @idCliente as int
	SELECT @idCliente = CC_Cliente From inserted;
		IF (Select Estado From Ginasio.Pagamento Where CC_Cliente = @idCliente) != 'Pago'
			RAISERROR('Não é possível criar/editar o plano de Treino! O cliente tem o pagamento da subscrição pendente ou cancelado.', 16, 1);
		ELSE
			INSERT INTO Ginasio.Plano_Treino SELECT * FROM inserted;
END
GO

-- Verifica se o cliente já tem um plano de adesao criado por outro funcionário ---

CREATE TRIGGER Ginasio.VerificarClientePlanosAdesao
ON Ginasio.Plano_Adesao
INSTEAD OF INSERT
AS
	BEGIN
    -- Verificar se o pagamento está confirmado para todos os clientes inseridos nos planos de treino
	DECLARE @idCliente as int
	SELECT @idCliente = CC_Cliente From inserted;
		IF (Select Count(CC_Cliente) From Ginasio.Plano_Adesao Where CC_Cliente = @idCliente) > 0
			RAISERROR('Este Cliente já tem um plano de adesão criado por outro funcionário.', 16, 1);
		ELSE
			INSERT INTO Ginasio.Plano_Adesao SELECT * FROM inserted;
END
GO

