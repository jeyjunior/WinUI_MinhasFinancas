-- =============================================
-- SCRIPT DE DROP TABLE (em ordem reversa para evitar conflitos de FK)
-- =============================================
DROP TABLE IF EXISTS TransacaoFinanceira;
DROP TABLE IF EXISTS TransacaoRecorrente;
DROP TABLE IF EXISTS Entidade;
DROP TABLE IF EXISTS FormaPagamento;
DROP TABLE IF EXISTS Categoria;
DROP TABLE IF EXISTS TipoTransacao;
DROP TABLE IF EXISTS Usuario;

-- =============================================
-- SCRIPT DE CRIAÇÃO DAS TABELAS (CORRIGIDO)
-- =============================================

-- Tabela de Usuários 
CREATE TABLE Usuario 
(
    PK_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Nome NVARCHAR(255) NOT NULL,
    LoginApi NVARCHAR(2000) NULL,
    DataCadastro DATETIME NOT NULL DEFAULT GETDATE(),
    Ativo BIT NOT NULL DEFAULT 1
);

-- Tabela de Tipos de Transação (Todos/Entrada/Saída)
CREATE TABLE TipoTransacao 
(
    PK_TipoTransacao INT PRIMARY KEY,
    Codigo VARCHAR(20) NOT NULL UNIQUE,
);

-- Tabela de Categorias com tipo específico
CREATE TABLE Categoria 
(
    PK_Categoria INT IDENTITY(1,1) PRIMARY KEY,
    Nome NVARCHAR(100) NOT NULL,
    FK_TipoTransacao INT NOT NULL, -- 0=Todos, 1=Entrada, 2=Saída
    FK_Usuario INT NULL,
    
    CONSTRAINT FK_Categoria_TipoTransacao FOREIGN KEY (FK_TipoTransacao) REFERENCES TipoTransacao(PK_TipoTransacao),
    CONSTRAINT FK_Categoria_Usuario FOREIGN KEY (FK_Usuario) REFERENCES Usuario(PK_Usuario)
);

-- Tabela de Formas de Pagamento
CREATE TABLE FormaPagamento 
(
    PK_FormaPagamento INT IDENTITY(1,1) PRIMARY KEY,
    FK_TipoTransacao INT NOT NULL, -- 0=Todos, 1=Entrada, 2=Saída
    Nome NVARCHAR(100) NOT NULL, -- 'PIX', 'Cartão Crédito', 'Débito', 'Dinheiro'
    Ativo BIT NOT NULL DEFAULT 1,
    FK_Usuario INT NULL,
    
    CONSTRAINT FK_FormaPagamento_TipoTransacao FOREIGN KEY (FK_TipoTransacao) REFERENCES TipoTransacao(PK_TipoTransacao),
    CONSTRAINT FK_FormaPagamento_Usuario FOREIGN KEY (FK_Usuario) REFERENCES Usuario(PK_Usuario)
);

-- Tabela de Entidades/Contrapartes
CREATE TABLE Entidade 
(
    PK_Entidade BIGINT IDENTITY(1,1) PRIMARY KEY,
    FK_TipoTransacao INT NOT NULL, -- 0=Todos, 1=Entrada, 2=Saída
    Nome NVARCHAR(255) NOT NULL, -- 'Savegnago', 'CPFL', 'Gestor Tecnologia', 'Maria Lucia'
    FK_Usuario INT NULL,
    
    CONSTRAINT FK_Entidade_TipoTransacao FOREIGN KEY (FK_TipoTransacao) REFERENCES TipoTransacao(PK_TipoTransacao),
    CONSTRAINT FK_Entidade_Usuario FOREIGN KEY (FK_Usuario) REFERENCES Usuario(PK_Usuario)
);

-- TABELA PRINCIPAL DE TRANSAÇÕES FINANCEIRAS
CREATE TABLE TransacaoFinanceira 
(
    PK_TransacaoFinanceira BIGINT IDENTITY(1,1) PRIMARY KEY,
    
    -- Informações básicas
    FK_TipoTransacao INT NOT NULL, -- Entrada ou Saída
    Valor DECIMAL(18,2) NOT NULL,
    Descricao NVARCHAR(300) NOT NULL,
    
    -- Datas importantes
    DataTransacao DATETIME  NULL, -- Quando ocorreu efetivamente
    DataVencimento DATETIME NULL, -- Quando deveria ocorrer (para boletos, recebíveis)
    
    -- Relacionamentos
    FK_Categoria INT NOT NULL,
    FK_FormaPagamento INT NULL,
    FK_Entidade BIGINT NULL, -- Quem pagou/recebeu
    
    -- Status e controle
    Recorrente BIT NOT NULL DEFAULT 0, -- Se é uma transação recorrente
    
    -- Metadados
    FK_Usuario INT NOT NULL,
    DataCriacao DATETIME NOT NULL DEFAULT GETDATE(),
    DataAtualizacao DATETIME NULL,
    
    -- Constraints
    CONSTRAINT FK_Transacao_TipoTransacao FOREIGN KEY (FK_TipoTransacao) REFERENCES TipoTransacao(PK_TipoTransacao),
    CONSTRAINT FK_Transacao_Categoria FOREIGN KEY (FK_Categoria) REFERENCES Categoria(PK_Categoria),
    CONSTRAINT FK_Transacao_FormaPagamento FOREIGN KEY (FK_FormaPagamento) REFERENCES FormaPagamento(PK_FormaPagamento),
    CONSTRAINT FK_Transacao_Entidade FOREIGN KEY (FK_Entidade) REFERENCES Entidade(PK_Entidade),
    CONSTRAINT FK_Transacao_Usuario FOREIGN KEY (FK_Usuario) REFERENCES Usuario(PK_Usuario),
);

-- ÍNDICES PARA PERFORMANCE
CREATE INDEX IX_Transacao_Usuario_Data ON TransacaoFinanceira(FK_Usuario, DataTransacao);
CREATE INDEX IX_Transacao_Usuario_Vencimento ON TransacaoFinanceira(FK_Usuario, DataVencimento) WHERE DataVencimento IS NOT NULL;
CREATE INDEX IX_Transacao_Tipo_Data ON TransacaoFinanceira(FK_TipoTransacao, DataTransacao);
CREATE INDEX IX_Transacao_Categoria ON TransacaoFinanceira(FK_Categoria);
CREATE INDEX IX_Transacao_Entidade ON TransacaoFinanceira(FK_Entidade);
CREATE INDEX IX_Transacao_FormaPagamento ON TransacaoFinanceira(FK_FormaPagamento);
CREATE INDEX IX_Categoria_Usuario_Tipo ON Categoria(FK_Usuario, FK_TipoTransacao);