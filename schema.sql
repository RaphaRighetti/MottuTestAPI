USE mottu_tech_test;

CREATE TABLE mecanicos (
    mecanicoId INT PRIMARY KEY,
    nome VARCHAR(50),
    idade INT,
    tempoPorDia INT,
    nivelComplexidade INT
);

CREATE TABLE tipoConserto (
    id INT PRIMARY KEY,
    tempoEstimado INT
);

CREATE TABLE consertoDeMotos (
    motoId INT,
    complexidadeDoConserto INT,
    tipoConsertoId INT,
    tempoReal INT,
    dataEntrada DATE,
    mecanicoId INT,
    PRIMARY KEY (motoId, dataEntrada, tipoConsertoId),
    FOREIGN KEY (mecanicoId) REFERENCES mecanicos(mecanicoId),
    FOREIGN KEY (tipoConsertoId) REFERENCES tipoConserto(id)
);

INSERT INTO mecanicos (mecanicoId, nome, idade, tempoPorDia, nivelComplexidade) VALUES
(1, 'Carlos', 25, 8, 2),
(2, 'Ana', 30, 8, 1),
(3, 'João', 22, 8, 3),
(4, 'Mariana', 28, 8, 2),
(5, 'Pedro', 35, 8, 1),
(6, 'Julia', 19, 8, 3),
(7, 'Ricardo', 45, 8, 1),
(8, 'Fernanda', 27, 8, 2),
(9, 'Thiago', 32, 8, 3),
(10, 'Laura', 24, 8, 1);

INSERT INTO tipoConserto (id, tempoEstimado) VALUES
(1, 2),
(2, 4),
(3, 3),
(4, 5),
(5, 1);

INSERT INTO consertoDeMotos (motoId, complexidadeDoConserto, tipoConsertoId, tempoReal, dataEntrada, mecanicoId) VALUES
(34, 1, 3, 4, '2024-07-10', 2),
(294, 2, 1, 3, '2024-07-10', 1),
(314, 1, 2, 2, '2024-07-10', 7),
(488, 3, 4, 1, '2024-07-10', 6),
(123, 2, 3, 4, '2024-07-10', 4),
(221, 1, 1, 2, '2024-07-10', 10),
(456, 3, 5, 5, '2024-07-11', 9),
(89, 2, 2, 6, '2024-07-11', 8),
(190, 1, 4, 1, '2024-07-11', 7),
(402, 2, 3, 3, '2024-07-11', 1),
(76, 1, 1, 4, '2024-07-11', 10),
(320, 2, 5, 5, '2024-07-11', 8),
(145, 3, 2, 6, '2024-07-11', 6),
(67, 1, 3, 1, '2024-07-11', 2),
(290, 2, 4, 2, '2024-07-11', 4),
(112, 1, 5, 4, '2024-07-11', 7),
(404, 3, 2, 1, '2024-07-12', 9),
(310, 1, 3, 2, '2024-07-12', 3),
(22, 2, 1, 4, '2024-07-12', 8),
(459, 3, 4, 1, '2024-07-12', 6),
(134, 2, 5, 3, '2024-07-12', 4),
(293, 1, 2, 2, '2024-07-12', 10),
(378, 3, 3, 4, '2024-07-12', 6),
(101, 1, 4, 1, '2024-07-12', 7),
(488, 2, 1, 3, '2024-07-12', 8),
(376, 3, 5, 5, '2024-07-12', 9),
(184, 1, 2, 6, '2024-07-13', 2),
(231, 2, 3, 4, '2024-07-13', 1),
(498, 1, 4, 2, '2024-07-13', 10),
(345, 3, 1, 1, '2024-07-13', 9),
(109, 2, 5, 3, '2024-07-13', 4),
(203, 1, 3, 2, '2024-07-13', 7),
(402, 3, 2, 4, '2024-07-13', 3),
(187, 1, 5, 1, '2024-07-13', 2),
(291, 2, 4, 3, '2024-07-13', 8),
(412, 3, 1, 5, '2024-07-13', 6),
(175, 2, 3, 6, '2024-07-14', 4),
(64, 1, 2, 4, '2024-07-14', 7),
(344, 3, 4, 1, '2024-07-14', 3),
(220, 2, 5, 3, '2024-07-14', 1),
(128, 1, 3, 2, '2024-07-14', 10),
(376, 3, 2, 1, '2024-07-14', 9),
(401, 1, 4, 4, '2024-07-14', 2),
(147, 2, 1, 5, '2024-07-14', 8),
(338, 3, 3, 6, '2024-07-14', 6),
(178, 1, 2, 1, '2024-07-14', 7),
(234, 2, 5, 3, '2024-07-14', 4),
(97, 3, 4, 2, '2024-07-14', 9),
(120, 1, 3, 4, '2024-07-14', 3),
(221, 2, 1, NULL, '2024-07-15', NULL),
(154, 3, 5, NULL, '2024-07-15', NULL),
(299, 1, 2, NULL, '2024-07-15', NULL),
(432, 2, 4, NULL, '2024-07-15', NULL),
(75, 3, 3, NULL, '2024-07-15', NULL);
