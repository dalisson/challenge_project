CREATE TABLE IF NOT EXISTS `projetos` (
  `id_projeto` int NOT NULL,
  `nome` varchar(200) DEFAULT NULL,
  `data_criacao` datetime DEFAULT NULL,
  `data_termino` datetime DEFAULT NULL,
  `gerente` int DEFAULT NULL,
  PRIMARY KEY (`id_projeto`),
  KEY `Projetos_FK` (`gerente`),
  CONSTRAINT `Projetos_FK` FOREIGN KEY (`gerente`) REFERENCES `empregados` (`id_empregado`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;