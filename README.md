# .NetCore5_CleanArchitecture
Projeto para gerenciamento de produtos e categorias criado em .NET Core 5, exemplificando o uso da Clean Architecture

# Ferramentas utilizadas
    * Banco de dados relacional: SQL SERVER  
    * Ferramenta ORM: Entity Framework Core
        Será usada a abordagem Code First do Entity Framework Core para criação do banco de dados e tabelas
            - Provedor:   Microsoft.EntityFrameworkCore.SqlServer
            - Ferramenta Migration:   Microsoft.EntityFrameworkCore.Tools
            - Desacoplamento da camada de acesso a dados ORM: Padrão Repository
            - AutoMapper: Mapeamento dos objetos

# Convenções para nomeação de objetos ( Padrão Microsoft )
    ## CamelCase = Palavras compostas ou frases, onde a primeira letra da palavra será minuscula e o inicio das palavras seguintes será maiuscula. 
        Exemplo: usuarioServico, nomeCompleto, enderecoCliente
        Usado para:
            - Variáveis: _nomeCompleto, _enderecoCliente
            - Parametros: Usuario(string nomeCompleto, string enderecoCliente)

    ## PascalCase = Palavras compostas ou frases, onde a primeira letra da cada palavra será maiuscula. 
        Exemplo: ProcessaFolhaDePagamento(),  ValorSalarioBruto
        Usado para:
            - Classes: Usuario, UsuarioAcesso, Pedido, PedidoItem
            - Interface: IUsuarioRepositorio, IPedidoServico
            - Método: Adicionar(), ProcessaPagamento()
            - Propriedade: Nome, SalarioBruto, SalarioLiquido

    ## Constantes = Para constantes será adotada todas as letras maiusculas
        Exemplo: FATOR_CONVERSAO_BRL_US, DESCONTO_CATEGORIA_X

# Arquitetura da solução
    ## Estrutura da solução

        Será criada uma solução contendo 5 projetos, onde será segregadas as camadas e responsabilidades
    
    ## Projetos 

        CleanArch.Domain: Esse projeto será o núcleo da aplicação, onde não existe dependencias das camadas ou projetos externos, 
        nessa camada são aplicados o modelo de domínio, regras de negócio ( casos de uso ), Interfaces

        CleanArch.Application: Esse projeto será responsável por aplicar: regras de dominios, mapeamentos, servicos, DTOs, CQRS
                    - Depende da camada de dominio, nomeada nesse projeto como CleanArch.Domain
         
        CleanArch.Infra.Data: Esse projeto será responsável por aplicar: EF Core, EntityConfiguration, Migrations, Repository
                    - Depende da camada de dominio, nomeada nesse projeto como CleanArch.Domain
        
        CleanArch.Infra.IoC: Esse projeto será responsável por aplicar: Dependency Injection, Registro de serviços, Tempo de vida
                    - Depende da camada de dominio, nomeada nesse projeto como CleanArch.Domain
                    - Depende da camada de adaptadores, nomeada nesse projeto como CleanArch.Application e CleanArch.Infra.Data

        CleanArch.WebUI: Esse projeto será responsável por aplicar: Interface com o usuário através do padrão MVC: Models, Views, 
        Controllers, ViewModels.
                    - Depende da camada de Inversão de dependencia, nomeada nesse projeto como CleanArch.Infra.IoC

# Distribuição dos componentes em camadas

        ## Domain:
                - Entidades
                    - Product
                    - Category

                - Interfaces dos repositorios 
                    - IProductRepository
                    - ICategoryRepository

                - Caso de uso: Exemplo: Autenticações e Autorizações 
                    - IAuthenticate
                    - ISeedUserRoleInitial
                    - IUser

        ## Application
                - Interfaces de Servicos
                    - IProductService
                    - ICategoryService
                    
                - Servicos
                    - ProductService
                    - CategoryService

                - DTOs
                    - ProductDTO
                    - CategoryDTO

                - Exceptions
                    
                - CQRS
                    - Commands
                    - Querys
                    - Handlers

                - Mappings
                    - DomainViewModel
                    - ViewModelDomain

        ## Infra.Data
                - Repositorios
                    - ProductRepository
                    - CategoryRepository
                - Context
                    - ApplicationDbContext
                - Configuração de entidades
                    - ProductConfiguration
                    - CategoryConfiguration
                - Migrations
        
        ## Infra.IoC    
                - DependencyInjection
            
        ## WebUI
                - Controllers
                    - AccountController
                    - ProductController
                    - CategoryController
                    
                - Models
                    - ProductModel
                    - CategoryModel

                - Views
                    - Product
                        - Index.cshtml
                        - Edit.cshtml 
                        - Create.cshtml
                    - Category
                        - Index.cshtml
                        - Edit.cshtml 
                        - Create.cshtml

                - ViewModels
                    - ProductViewModel
                    - CategoryViewModel

                - Filters
                - Componentes
                - MapConfig


        

