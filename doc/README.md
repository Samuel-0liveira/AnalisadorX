<h1 align = "center"> Analisador X </h1>

<p align = "middle">
<img src="../doc/imagens/AnalisadorX - Logotipo.png" alt="drawing" width="200" tittle="Exemplo">
</p>

<p align = "center">
<img loading = "lazy" src = "https://img.shields.io/badge/Status-Em_desenvolvimento-blue"/>
<img loading = "lazy" src = "https://img.shields.io/badge/Licença-MIT-forestgreen"/>
<img loading = "lazy" src = "https://img.shields.io/badge/Linguagem-C_Sharp-purple"/>
<img loading = "lazy" src = "https://img.shields.io/github/forks/Samuel-0liveira/analisadorx"/>
</p>
<br>

## Descrição do projeto
<p>
Projeto em desenvolvimento como parte do meu portfólio, o foco é no backend e o objetivo é estruturar um forms onde é possível criar um usuário, realizar o login do mesmo e cadastrar informações no banco de dados.<br>
<br>Após logar, será possível editar e excluir algumas informações nesse mesmo banco, tudo isso, dentro da temática dos X-Men. 
</p>
<br>

### Funcionalidades

- [x] Cadastro de usuário;
- [x] Tela de login;
- [x] Inclusão de informações no banco de dados;
- [x] Exibir informações do banco de dados;
- [x] Criação de atalho ao instalar;
- [ ] Edição e exclusão de informações do banco de dados.

<br>

### Pré-requisitos

#### Configurando o banco

<p>
Para criação e gerenciamento do banco de dados, será necessário baixar o <a href="https://www.enterprisedb.com/downloads/postgres-postgresql-downloads">postgresql</a> (a versão que está sendo utilizada é a 15.5 do windows). 
<br>

O posgresql utiliza a porta padrão de número 5432, antes de iniciar a instalação precisamos nos certificar de que ela esteja liberada, para garantir isso, basta ver o seguinte <a href="https://atendimento.nasajon.com.br/nasajon/artigos/c72ad9c3-b08f-4c88-9cc0-c81cad98c373">tutorial</a>. <br>

Algumas observações baseadas nesse tutorial:
<br>

- Passo 4: O tipo de conexão é TCP;
- Passo 5: Permitir a conexão;
- Passo 6: A regra se aplica nas 3 opções (Domínio, particular e público);
- Passo 7: Em nome, coloque postgres;
- Após concluir, faça a mesma coisa nas **regras de saída**.

Agora, seguiremos com a instalação, aqui teremos mais um <a href="https://www.w3schools.com/postgresql/postgresql_install.php">passo a passo</a>, depois de concluído, será necessário realizar algumas mudanças no arquivo **pg_hba**, o mesmo, pode ser encontrado (caso o diretório padrão de instalação tenha sido mantido) no caminho: C:\Program Files\PostgreSQL\15\data.

<br>

Iremos abrir o arquivo com o bloco de notas, ao rolar para baixo, você encontrará algo semelhante a isso:

<img src="../doc/imagens/Exemplo.png" tittle="Exemplo">

<br>

Basta alterar a linha abaixo de IPv4 local connections para que fique igual a seguinte:

<img src="../doc/imagens/Exemplo 2.png" tittle="Exemplo">

#### Criando nosso banco

Finalmente, depois de tantas configurações, vamos para a criação do banco de dados que vamos utilizar.<br>
Procure pelo atalho do programa **pgAdmin 4** (programa esse, previamente instalado junto com o postgresql).

Assim que abrir, será requisitado que você crie uma senha mestre para poder conectar em seus futuros servidores, eu costumo colocar a mesma senha que foi colocada no ato da instalação do postgresql.

Depois de criar a senha, vamos abrir a aba de servidores e colocar a senha criada:

<img src="../doc/imagens/Exemplo 4.png" tittle="Exemplo">

<br>

<br>

Aqui existem duas opções, utilizar a database padrão do pgAdmin ou criar uma nova, caso escolha criar mais uma, clique com o lado direito do mouse em cima de Databases, Create, Database:

<img src="../doc/imagens/Exemplo 5.png" tittle="Exemplo">

<br>

Escolha o nome de sua preferência, em seguida, lado direito do mouse e escolha Query Tool: 

<img src="../doc/imagens/Exemplo 6.png" tittle="Exemplo">

<br>

Para recriar o banco de dados utilizado, basta copiar o mesmo do arquivo <a href="https://github.com/Samuel-0liveira/AnalisadorX/blob/master/Banco%20de%20Dados/db_projetox.sql"> db_projetox.sql</a> e executar.

</p>
