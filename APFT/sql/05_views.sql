
-- View para mostrar o mapa das aulas -- 
DROP VIEW IF EXISTS Ginasio.Salas_AND_Aulas_VIEW;
GO

CREATE VIEW Ginasio.Salas_AND_Aulas_VIEW AS
SELECT Aula_Horario.ID_Horario AS [Nº da Aula], 
	   Aula.Sala_ID AS [Número da Sala],
       Sala.Tipo AS Aula,
       Sala.Num_Max_alunos AS [Nº máximo de alunos],
       Aula_Horario.Hora_Inicio AS [Hora de Início],
       Aula_Horario.Hora_Fim AS [Hora de Fim],
       Aula_Horario.Dia_Semana AS [Dia da semana],
       Staff.Fname + ' ' + Staff.Lname AS Professor, 
       COUNT(ID_HAula) AS [Nº de Inscrições]
FROM Ginasio.Aula
JOIN Ginasio.Aula_Horario ON Aula.ID = Aula_Horario.Aula_ID
JOIN Ginasio.Sala ON Aula.Sala_ID = Sala.ID
JOIN Ginasio.Professor ON Aula.ID_Professor = Professor.Num_func
JOIN Ginasio.Staff ON Professor.Num_func = Staff.Num_func
LEFT JOIN Ginasio.Inscreve ON ID_HAula = ID_Horario AND Estado = 'Confirmada'
GROUP BY Aula_Horario.ID_Horario, Aula.Sala_ID, Sala.Tipo, Sala.Num_Max_alunos, Aula_Horario.Hora_Inicio, Aula_Horario.Hora_Fim, Aula_Horario.Dia_Semana, Staff.Fname + ' ' + Staff.Lname;


-- ver as aulas por ordem crescente de sala e por dia da semana
SELECT * FROM Ginasio.Salas_AND_Aulas_VIEW
ORDER BY "N�mero da Sala", CASE "Dia da semana"
    WHEN 'Segunda-feira' THEN 1
    WHEN 'Ter�a-feira' THEN 2
    WHEN 'Quarta-feira' THEN 3
    WHEN 'Quinta-feira' THEN 4
    WHEN 'Sexta-feira' THEN 5
    WHEN 'S�bado' THEN 6
    WHEN 'Domingo' THEN 7
    ELSE 8 -- For any other value, assign it a higher sort order
END;