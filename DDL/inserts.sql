
INSERT INTO Ginasio.Cliente (CC, Fname, Lname, Email, Telemovel, NIF, Morada, Data_Nasc) 
VALUES (123456789, 'Ana', 'Silva', 'ana.silva@example.com', 912345678, 205896325, 'Rua das Flores, 1', '1990-01-01'),
       (987654321, 'Pedro', 'Santos', 'pedro.santos@example.com', 931234567, 200142589, 'Rua do Sol, 2', '1985-06-20'),
       (456789123, 'Marta', 'Ferreira', 'marta.ferreira@example.com', 931234568, NULL, 'Avenida da Liberdade, 3', '1995-09-14'),
       (789123456, 'Tiago', 'Oliveira', 'tiago.oliveira@example.com', 912345679, 189858585, 'Rua da Praia, 4', '1982-03-10'),
       (654321987, 'Sofia', 'Gonçalves', NULL, 931234569, 188745214, 'Rua da Montanha, 5', '1998-12-31'),
       (321987654, 'Rui', 'Sousa', 'rui.sousa@example.com', 912345670, NULL, 'Travessa das Oliveiras, 6', '1988-08-08'),
       (234567891, 'Carla', 'Rodrigues', 'carla.rodrigues@example.com', 931234570, 189658236, 'Rua dos Pinheiros, 7', '1993-05-15'),
       (678912345, 'Diogo', 'Pereira', 'diogo.pereira@example.com', 912345671, 253478963, 'Rua da Lagoa, 8', '1980-11-22'),
       (345678912, 'Ana', 'Fernandes', 'ana.fernandes@example.com', 931234571, 251458758, 'Avenida das Oliveiras, 9', '1991-08-03'),
       (890123456, 'Miguel', 'Costa', 'miguel.costa@example.com', 912345672, 255569856, 'Rua dos Cedros, 10', '1996-02-17');

INSERT INTO Ginasio.Staff (CC, Fname, Lname, Email, Telemovel, NIF, Morada, Data_Nasc, Salario, Num_func, Data_Contr, Horario_Lab, Gerente_Num)
VALUES (111222333, 'Maria', 'Santos', 'maria.santos@example.com', 912345678, 123456789, 'Rua das Flores, 1', '1990-01-01', 2500, 1001, '2022-01-15', '09:00:00', 1002),
       (444555666, 'João', 'Silva', 'joao.silva@example.com', 931234567, 987654321, 'Rua do Sol, 2', '1985-06-20', 2800, 1002, '2021-09-10', '08:30:00', 1002),
       (777888999, 'Andreia', 'Fernandes', 'andreia.fernandes@example.com', 931234568, 456789123, 'Avenida da Liberdade, 3', '1995-09-14', 2200, 1003, '2023-02-05', '10:00:00', 1002),
       (999888777, 'Ricardo', 'Pereira', 'ricardo.pereira@example.com', 912345679, 789123456, 'Rua da Praia, 4', '1982-03-10', 3000, 1004, '2020-07-20', '08:00:00', 1002),
       (222333444, 'Ana', 'Oliveira', NULL, 931234569, 654321987, 'Rua da Montanha, 5', '1998-12-31', 2600, 1005, '2022-03-25', '09:30:00', 1002),
       (555444333, 'Pedro', 'Sousa', 'pedro.sousa@example.com', 912345670, 321987654, 'Travessa das Oliveiras, 6', '1988-08-08', 2400, 1006, '2023-04-05', NULL, 1002);

INSERT INTO Ginasio.Gerente (Num_func)
VALUES (1002);

INSERT INTO Ginasio.Rececionista (Num_func)
VALUES (1005),
       (1006);

INSERT INTO Ginasio.Professor (Num_func)
VALUES (1001),
       (1003),
       (1004);

INSERT INTO Ginasio.Certificacoes_Prof (Num_func, Certificacoes)
VALUES (1004, 'Personal Trainer'),
       (1001, 'Treino Funcional'),
       (1003, 'Pilates'),
       (1004, 'Musculação Avançada'),
       (1001, 'CrossFit'),
       (1003, 'Yoga'),
       (1004, 'Boxe');

INSERT INTO Ginasio.Plano_Adesao (Tipo, CC_Cliente, Preco, Data_fim, Data_inicio, Num_Rec)
VALUES ('Plano Básico', 123456789, 380.00, '2023-12-31', '2023-01-01', 1005),
       ('Plano Premium', 987654321, 500.00, '2024-06-30', '2023-01-01', 1005),
       ('Plano Básico', 456789123, 380.00, '2023-09-30', '2023-01-01', 1005),
       ('Plano Básico', 789123456, 380.00, '2023-12-31', '2023-01-01', 1005),
       ('Plano Básico', 654321987, 380.00, '2023-12-31', '2023-01-01', 1005),
       ('Plano Básico', 321987654, 380.00, '2024-03-31', '2023-01-01', 1005),
       ('Plano Básico', 234567891, 380.00, '2023-12-31', '2023-01-01', 1006),
       ('Plano Premium', 678912345, 500.00, '2024-06-30', '2023-01-01', 1006),
       ('Plano Básico', 345678912, 380.00, '2023-12-31', '2023-01-01', 1006),
       ('Plano Premium', 890123456, 500.00, '2024-03-31', '2023-01-01', 1006);

INSERT INTO Ginasio.Pagamento (ID, Valor, Metodo, Estado, Data_venc, Data_canc, CC_Cliente, Num_Rec, Data_Pagamento)
VALUES (1, 50.00, 'Cartão de Crédito', 'Pago', '2023-01-31', NULL, 123456789, 1005, '2023-01-10'),
       (2, 30.00, 'Débito Automático', 'Pago', '2023-03-31', NULL, 987654321, 1005, '2023-03-01'),
       (3, 30.00, 'Transferência Bancária', 'Pago', '2023-04-30', NULL, 456789123, 1005, '2023-04-05'),
       (4, 50.00, 'Dinheiro', 'Pendente', '2023-01-31', NULL, 789123456, 1005, NULL),
       (5, 30.00, 'Cartão de Crédito', 'Pendente', '2023-01-31', NULL, 654321987, 1005, NULL),
       (6, 60.00, 'Débito Automático', 'Pago', '2023-03-28', NULL, 321987654, 1005, '2023-03-01'),
       (7, 50.00, 'Transferência Bancária', 'Pendente', '2023-02-28', NULL, 234567891, 1006, NULL),
       (8, 50.00, 'Dinheiro', 'Cancelado', '2023-01-31', '2023-01-14', 678912345, 1006, NULL),
       (9, 50.00, 'Cartão de Crédito', 'Pendente', '2023-01-31', NULL, 345678912, 1006, NULL),
       (10, 500.00, 'Transferência Bancária', 'Pago', '2023-01-31', NULL, 890123456, 1006, '2023-01-05');

INSERT INTO Ginasio.Feedback (CC_Cliente, ID_Professor, Comentários, [Data])
VALUES (123456789, 1004, 'Excelente professor! Sempre motivado e dedicado às aulas.', '2023-04-15'),
       (987654321, 1001, 'Ótimo profissional! Explicações claras e atencioso com os alunos.', '2023-05-02'),
       (456789123, 1003, 'Adorei treinar com esta professora! Muito simpática e motivadora.', '2023-03-25'),
       (321987654, 2004, 'O professor é muito competente e sempre traz novidades para as aulas.', '2023-04-10'),
       (890123456, 2005, 'Excelente professor! Ele me ajudou a atingir meus objetivos de forma eficiente.', '2023-05-05');

INSERT INTO Ginasio.Aula (ID, Sala_ID, Num_Insc, ID_Professor)
VALUES (1, 101, 20, 1004),
       (2, 102, 15, 1001),
       (3, 103, 10, 1003),
       (4, 101, 18, 1004),
       (5, 102, 12, 1001);