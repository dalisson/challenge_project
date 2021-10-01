CREATE TABLE IF NOT EXISTS `empregados` (
  `id_empregado` int NOT NULL,
  `primeiro_nome` varchar(200) DEFAULT NULL,
  `ultimo_nome` varchar(200) DEFAULT NULL,
  `telefone` bigint DEFAULT NULL,
  `endereco` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id_empregado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;