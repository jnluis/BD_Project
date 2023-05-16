SELECT Ginasio.Exercicio.Nome,Ginasio.Inclui.Tempo, Ginasio.Inclui.Num_Reps, Ginasio.Inclui.Num_Series 
From  Ginasio.Cliente join Ginasio.Plano_Treino on Ginasio.Cliente.CC = Ginasio.Plano_Treino.CC_Cliente
WHERE Works_on.Essn=@func_ssn