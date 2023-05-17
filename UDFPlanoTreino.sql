SELECT Ginasio.Exercicio.Nome,Ginasio.Inclui.Tempo, Ginasio.Inclui.Num_Reps, Ginasio.Inclui.Num_Series 
From  Ginasio.Cliente join Ginasio.Plano_Treino on Ginasio.Cliente.CC = Ginasio.Plano_Treino.CC_Cliente join Ginasio.Inclui on Ginasio.Inclui.ID_PT = Ginasio.Plano_Treino.ID join Ginasio.Exercicio on Ginasio.Exercicio.ID = Ginasio.Inclui.ID_Ex
WHERE Ginasio.Cliente.CC = '123456789'
