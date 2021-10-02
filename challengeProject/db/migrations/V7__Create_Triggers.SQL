CREATE TRIGGER after_projeto_create
AFTER INSERT
ON projetos FOR EACH ROW
BEGIN
    
     INSERT INTO membros(id_projeto, id_empregado)
        
     VALUES(new.id_projeto, new.gerente);
    
END