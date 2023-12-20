create table fornecedor(
id int primary key auto_increment,
nome VARCHAR(45) NOT NULL,
contato VARCHAR(45) NOT NULL
)
;
CREATE TABLE  produtos (
id int primary key auto_increment,
valor_unidade DECIMAL(8) NOT NULL,
estoque INT NOT NULL
)
;
CREATE TABLE produtos_has_fornecedor (
produtos_id INT NOT NULL,
fornecedor_id INT NOT NULL,
FOREIGN KEY (produtos_id)
REFERENCES produtos(id),
FOREIGN KEY (fornecedor_id)
REFERENCES  fornecedor(id)
);

create table categoria(
id int primary key auto_increment,
nome VARCHAR(45) NOT NULL
)
;
CREATE TABLE produtos_has_categoria (
produtos_id INT NOT NULL,
categoria_id INT NOT NULL,
FOREIGN KEY (produtos_id)
REFERENCES produtos(id),
FOREIGN KEY (categoria_id)
REFERENCES categoria(id)
);
   
create table clientes(
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
nome VARCHAR(45) NOT NULL,
email VARCHAR(45) NOT NULL,
contato VARCHAR(14) NOT NULL,
compras_realizadas INT NOT NULL
);

create table condicoes_de_pagamento (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
froma_de_pagamento VARCHAR(45) not NULL,
inicio DATE NOT NULL,
termino DATE NOT NULL,
valor_total DECIMAL(8) NOT NULL
);

create table vendas(
id int primary key not null auto_increment,
cliente_id int not null,
condicoes_de_pagamento_id int not null,
foreign key (cliente_id) references clientes(id),
foreign key (condicoes_de_pagamento_id) references condicoes_de_pagamento(id)
);

CREATE TABLE vendas_has_produtos (
vendas_id INT NOT NULL,
produtos_id INT NOT NULL,
quantidade_vendida INT NOT NULL,
FOREIGN KEY (vendas_id) REFERENCES vendas(id),
FOREIGN KEY (produtos_id) REFERENCES produtos (id)
);

CREATE TABLE compras (
id INT primary key NOT NULL AUTO_INCREMENT,
condicoes_de_pagamento_id INT NOT NULL,
FOREIGN KEY (condicoes_de_pagamento_id)
REFERENCES condicoes_de_pagamento(id)
);

CREATE TABLE compras_has_produtos(
compras_id INT PRIMARY KEY NOT NULL,
produtos_id INT NOT NULL,
quantiade_comprada INT NOT NULL,
FOREIGN KEY (compras_id)
REFERENCES compras(id),
FOREIGN KEY (produtos_id)
REFERENCES produtos(id)
);

CREATE TABLE receber (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
vendas_id INT NOT NULL,
vendas_condicoes_de_pagamento_id INT NOT NULL,
valor DECIMAL(8) NOT NULL,
FOREIGN KEY (vendas_id)
REFERENCES vendas(id)
);
select * from receber;
alter table receber 
drop column vendas_condicoes_de_pagamento_id
;

CREATE TABLE IF NOT EXISTS pagar (
id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
compras_id INT NOT NULL,
valor DECIMAL(8) NOT NULL,
FOREIGN KEY (compras_id)
REFERENCES compras(id)
);



create table compromisso_contatos(
compromisso_id int not null,
contato_id int not null,
foreign key(compromisso_id) references compromisso(id),
foreign key(contato_id) references contatos(id)	
);

alter table contatos
add local varchar(80) not null;

insert into contatos (nome, email, contato)
values('Patrick', 'patrick@gmail.com','(47)992410514'),
('Patricia', 'patricia@gmail.com','(47)998285614'),
('Eduarda', 'eduarda@gmail.com','(47)988425564');


insert into compromisso_contatos (compromisso_id, contato_id )
values('2', '1'),
('1', '1'),
('1', '2'),
('1', '3');

select * 
from compromisso_contatos, compromisso, contatos
where compromisso_contatos.compromisso_id=compromisso.id and compromisso_contatos.contato_id=contatos.id
;

select id, nome as Nome, email as 'E-mail', contato as Contato from contatos;

select id, descricao as Descrição, data as Data, hora as Hora, local as Onde from compromisso

;

CREATE TABLE compromisso_contatos (
    compromisso_id INT,
    contato_id INT,
    FOREIGN KEY (compromisso_id) REFERENCES compromisso(id),
    FOREIGN KEY (contato_id) REFERENCES contatos(id)
);

select compromisso.id, contatos.id, compromisso_id, contato_id
from contatos, compromisso, compromisso_has_contatos
;

INSERT INTO compromisso_has_contatos (compromisso_id, contato_id)
values(1,1);

INSERT INTO contatos (nome, email, celular )
values('maria','maria@gmail.com','47992410050');

INSERT INTO compromisso (compromisso, data, hora )
values('pescar','2023-10-18','18:45:00');

DELETE FROM contatos WHERE id=1;

select * from contatos;
select * from compromisso;
select * from compromisso_has_contatos;

alter table oi 
add nome varchar(60);

INSERT INTO oi (telefone, nome )
VALUES ('1123', joao );

INSERT INTO tabela_de_compromissos (descricao, dia, hora, tb_contatos_id, tb_locais_id )
values('pescar','2023-10-18','18:45:00','1','2'),('jogar bocha','2023-11-19','18:00:00','2','1');

select descricao as Descriçâo , dia as Data, hora, tabela_de_contatos.nome, email, contato, rua, tabela_de_locais.nome
 from tabela_de_compromissos,tabela_de_contatos, tabela_de_locais
 where tabela_de_compromissos.tb_contatos_id = tabela_de_contatos.id and tabela_de_compromissos.tb_locais_id = tabela_de_locais.id;
