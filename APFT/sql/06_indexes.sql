CREATE INDEX idxNomeCliente ON Ginasio.Cliente(Fname, Lname);
CREATE INDEX idxCCliente ON Ginasio.Cliente(CC);
CREATE INDEX idxExerciciosPlanoTreino ON Ginasio.Inclui(ID_Ex, ID_PT);

CREATE INDEX idxNomeProfessor ON Ginasio.Professor(Fname, Lname);
CREATE INDEX idxNumFuncProfessor ON Ginasio.Professor(Num_func);