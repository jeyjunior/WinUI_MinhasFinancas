-- =============================================
-- INSERÇÃO DE DADOS PARA TESTE
-- =============================================

-- Inserir Usuário
INSERT INTO Usuario (Email, Nome, LoginApi, Ativo)
VALUES ('teste@email.com', 'Usuário Teste', 'login_api', 1);

-- Inserir Tipos de Transação
INSERT INTO TipoTransacao (Codigo) VALUES 
('Todos'),
('Entrada'),
('Saída');

-- Inserir Formas de Pagamento
INSERT INTO FormaPagamento (FK_TipoTransacao, Nome, Ativo, FK_Usuario) VALUES 
(3, 'PIX', 1, 1),                    -- Ambos
(3, 'Dinheiro', 1, 1),               -- Ambos
(2, 'Cartão de Crédito', 1, 1),      -- Saída
(2, 'Cartão de Débito', 1, 1),       -- Saída
(3, 'Transferência Bancária', 1, 1), -- Ambos
(2, 'Boleto', 1, 1),                 -- Saída
(1, 'Depósito', 1, 1);               -- Entrada

-- Inserir Categorias
-- Categorias para ENTRADA
INSERT INTO Categoria (Nome, FK_TipoTransacao, FK_Usuario) VALUES 
('Salário', 1, 1),
('Freelance', 1, 1),
('Investimentos', 1, 1),
('Renda Extra', 1, 1),
('Reembolso', 1, 1);

-- Categorias para SAÍDA
INSERT INTO Categoria (Nome, FK_TipoTransacao, FK_Usuario) VALUES 
('Alimentação', 2, 1),
('Moradia', 2, 1),
('Transporte', 2, 1),
('Educação', 2, 1),
('Lazer', 2, 1),
('Saúde', 2, 1),
('Contas Fixas', 2, 1);

-- Categorias para AMBOS
INSERT INTO Categoria (Nome, FK_TipoTransacao, FK_Usuario) VALUES 
('Transferência', 3, 1),
('Ajuste', 3, 1);

-- Inserir Entidades
-- Entidades para ENTRADA
INSERT INTO Entidade (FK_TipoTransacao, Nome, FK_Usuario) VALUES 
(1, 'Gestor Tecnologia', 1),
(1, 'Maria Lucia', 1),
(1, 'João Silva', 1);

-- Entidades para SAÍDA
INSERT INTO Entidade (FK_TipoTransacao, Nome, FK_Usuario) VALUES 
(2, 'Savegnago', 1),
(2, 'Imobiliária Martinelli', 1),
(2, 'CPFL', 1),
(2, 'Eletropaulo', 1),
(2, 'Supermercado ABC', 1);

-- Entidades para AMBOS
INSERT INTO Entidade (FK_TipoTransacao, Nome, FK_Usuario) VALUES 
(3, 'Banco do Brasil', 1),
(3, 'Minha Carteira', 1);

-- Inserir Transações Financeiras (seus exemplos)
INSERT INTO TransacaoFinanceira 
(FK_TipoTransacao, Valor, Descricao, DataTransacao, DataVencimento, FK_Categoria, FK_FormaPagamento, FK_Entidade, Recorrente, FK_Usuario)
VALUES 
-- 1º Exemplo: Compra no Savegnago
(2, 129.49, 'Compra de mercadorias no Savegnago', '2025-11-19', NULL, 
 (SELECT PK_Categoria FROM Categoria WHERE Nome = 'Alimentação'), 
 (SELECT PK_FormaPagamento FROM FormaPagamento WHERE Nome = 'Cartão de Crédito'),
 (SELECT PK_Entidade FROM Entidade WHERE Nome = 'Savegnago'), 
 0, 1),

-- 2º Exemplo: Pagamento de aluguel
(2, 1100.00, 'Pagamento aluguel - Imobiliária Martinelli', '2025-11-20', '2025-11-25',
 (SELECT PK_Categoria FROM Categoria WHERE Nome = 'Moradia'),
 (SELECT PK_FormaPagamento FROM FormaPagamento WHERE Nome = 'Transferência Bancária'),
 (SELECT PK_Entidade FROM Entidade WHERE Nome = 'Imobiliária Martinelli'),
 1, 1),

-- 3º Exemplo: Conta vencida CPFL
(2, 300.00, 'Pagamento conta atrasada CPFL', '2025-11-21', '2025-10-20',
 (SELECT PK_Categoria FROM Categoria WHERE Nome = 'Contas Fixas'),
 (SELECT PK_FormaPagamento FROM FormaPagamento WHERE Nome = 'Boleto'),
 (SELECT PK_Entidade FROM Entidade WHERE Nome = 'CPFL'),
 0, 1),

-- 4º Exemplo: Conta de luz Eletropaulo
(2, 20.00, 'Pagamento conta de luz', '2025-11-20', '2025-11-20',
 (SELECT PK_Categoria FROM Categoria WHERE Nome = 'Contas Fixas'),
 (SELECT PK_FormaPagamento FROM FormaPagamento WHERE Nome = 'Débito Automático'),
 (SELECT PK_Entidade FROM Entidade WHERE Nome = 'Eletropaulo'),
 1, 1),

-- 5º Exemplo: Recebimento aula particular
(1, 640.00, 'Aula particular para Pietro', '2025-11-23', NULL,
 (SELECT PK_Categoria FROM Categoria WHERE Nome = 'Renda Extra'),
 (SELECT PK_FormaPagamento FROM FormaPagamento WHERE Nome = 'PIX'),
 (SELECT PK_Entidade FROM Entidade WHERE Nome = 'Maria Lucia'),
 0, 1),

-- 6º Exemplo: Adiantamento salário
(1, 1000.00, 'Adiantamento salarial', '2025-11-20', NULL,
 (SELECT PK_Categoria FROM Categoria WHERE Nome = 'Salário'),
 (SELECT PK_FormaPagamento FROM FormaPagamento WHERE Nome = 'Depósito'),
 (SELECT PK_Entidade FROM Entidade WHERE Nome = 'Gestor Tecnologia'),
 1, 1);