CREATE TABLE categorias(
id int PRIMARY KEY IDENTITY(1,1),
nome_categoria VARCHAR(100),
registro_ativo bit
);

CREATE TABLE frutas(
id int PRIMARY KEY IDENTITY(1,1),
id_categoria INT not null,
FOREIGN KEY (id_categoria) REFERENCES categorias(id),
nome VARCHAR(100),
preco DECIMAL,
peso float,
registro_ativo bit
);