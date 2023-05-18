DROP VIEW IF EXISTS Ginasio.Salas_AND_Aulas_VIEW;
GO
--CREATE VIEW Salas_AND_Aulas_VIEW AS
--SELECT Sala_ID, ID_Professor, Num_Max_alunos
--FROM Ginasio.Aula
--JOIN Ginasio.Sala ON Ginasio.Aula.Sala_ID = Ginasio.Sala.ID
CREATE VIEW Ginasio.Salas_AND_Aulas_VIEW AS
SELECT Aula.Sala_ID, Sala.Tipo, Sala.Num_Max_alunos, Aula_Horario.Hora_Inicio, Aula_Horario.Hora_Fim,Aula_Horario.Dia_Semana, Staff.Fname, Staff.Lname
FROM Ginasio.Aula
JOIN Ginasio.Aula_Horario ON Aula.ID = Aula_Horario.Aula_ID
JOIN Ginasio.Sala ON Aula.Sala_ID = Sala.ID
JOIN Ginasio.Professor ON Aula.ID_Professor = Professor.Num_func
JOIN Ginasio.Staff ON Professor.Num_func = Staff.Num_func;



--SELECT * FROM Ginasio.Salas_AND_Aulas_VIEW