DROP VIEW IF EXISTS Ginasio.Salas_AND_Aulas_VIEW;
GO

CREATE VIEW Ginasio.Salas_AND_Aulas_VIEW AS
SELECT Aula.Sala_ID, Sala.Tipo, Sala.Num_Max_alunos, Aula_Horario.Hora_Inicio, Aula_Horario.Hora_Fim,Aula_Horario.Dia_Semana, Staff.Fname, Staff.Lname
FROM Ginasio.Aula
JOIN Ginasio.Aula_Horario ON Aula.ID = Aula_Horario.Aula_ID
JOIN Ginasio.Sala ON Aula.Sala_ID = Sala.ID
JOIN Ginasio.Professor ON Aula.ID_Professor = Professor.Num_func
JOIN Ginasio.Staff ON Professor.Num_func = Staff.Num_func;


-- ver as aulas por ordem crescente de sala e por dia da semana
SELECT * FROM Ginasio.Salas_AND_Aulas_VIEW
ORDER BY Sala_ID, CASE Dia_Semana
    WHEN 'Segunda-feira' THEN 1
    WHEN 'Terça-feira' THEN 2
    WHEN 'Quarta-feira' THEN 3
    WHEN 'Quinta-feira' THEN 4
    WHEN 'Sexta-feira' THEN 5
    WHEN 'Sábado' THEN 6
    WHEN 'Domingo' THEN 7
    ELSE 8 -- For any other value, assign it a higher sort order
END;