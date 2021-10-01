CREATE TABLE `membros` (
  `id_empregado` int NOT NULL,
  `id_projeto` int NOT NULL,
  PRIMARY KEY (`id_empregado`,`id_projeto`),
  KEY `membros_FK_1` (`id_projeto`),
  CONSTRAINT `membros_FK` FOREIGN KEY (`id_empregado`) REFERENCES `empregados` (`id_empregado`),
  CONSTRAINT `membros_FK_1` FOREIGN KEY (`id_projeto`) REFERENCES `projetos` (`id_projeto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;