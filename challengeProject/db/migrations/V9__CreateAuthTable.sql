CREATE TABLE `usuarios` (
	`id` INT NOT NULL AUTO_INCREMENT,
	`user_name` varchar(100) NULL,
	`password` varchar(100) NOT NULL,
	`refresh_token` varchar(100) NULL,
	`refresh_token_expiry_time` DATETIME NULL,
	PRIMARY KEY (`Id`),
	UNIQUE KEY (`user_name`)
)