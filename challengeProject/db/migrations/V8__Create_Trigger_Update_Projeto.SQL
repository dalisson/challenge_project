CREATE TRIGGER after_projeto_update
AFTER UPDATE
ON projetos FOR EACH ROW
BEGIN
 
    IF NEW.gerente <> OLD.gerente THEN
        UPDATE membros 
        SET id_empregado=new.gerente
        WHERE membros.id_empregado = old.gerente and membros.id_projeto=new.id_projeto; -- change this condition as you need
    END IF;
    
END