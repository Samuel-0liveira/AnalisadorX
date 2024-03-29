
## :scroll: Pré-requisitos :scroll:

### :wrench: Pré-configuração do banco :wrench:

<p>
Para criação e gerenciamento do banco de dados, será necessário baixar o <a href="https://www.enterprisedb.com/downloads/postgres-postgresql-downloads">postgresql</a> (a versão que está sendo utilizada é a 15.5 do windows). 
<br>

O posgresql utiliza a porta padrão de número 5432, antes de iniciar a instalação precisamos nos certificar de que ela esteja liberada, para garantir isso, basta ver o seguinte <a href="https://atendimento.nasajon.com.br/nasajon/artigos/c72ad9c3-b08f-4c88-9cc0-c81cad98c373">tutorial</a>. <br>

:eyes: Algumas observações baseadas nesse tutorial:
<br>

- Passo 4: O tipo de conexão é TCP;
- Passo 5: Permitir a conexão;
- Passo 6: A regra se aplica nas 3 opções (Domínio, particular e público);
- Passo 7: Em nome, coloque postgres;
- Após concluir, faça a mesma coisa nas **regras de saída**.

:exclamation: Agora, seguiremos com a instalação, aqui teremos mais um <a href="https://www.w3schools.com/postgresql/postgresql_install.php">passo a passo</a>, depois de concluído, será necessário realizar algumas mudanças no arquivo **pg_hba**, o mesmo, pode ser encontrado (caso o diretório padrão de instalação tenha sido mantido) no caminho: C:\Program Files\PostgreSQL\15\data.

<br>

:exclamation: Iremos abrir o arquivo com o bloco de notas, ao rolar para baixo, você encontrará algo semelhante a isso:

<img src="../doc/imagens/Exemplo.png" tittle="Exemplo">

<br>

:exclamation: Basta alterar a linha abaixo de IPv4 local connections para que fique igual a seguinte:

<img src="../doc/imagens/Exemplo 2.png" tittle="Exemplo">

### :bank: Criando nosso banco :bank:

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

<br>

### :computer: Instalando o programa :computer:

Depois dessa aventura que foi configurar e instalar o banco, vamos (finalmente), ao programa principal, é bem simples, basta baixar os arquivos <a href="https://github.com/Samuel-0liveira/AnalisadorX/archive/refs/heads/master.zip">aqui.</a>

Após isso, extraia o arquivo aonde preferir, procure pela pasta do instalador e execute qualquer um dos setup.

Por fim, basta clicar no atalho criado ou procurar o programa via menu do windows (pesquise por AnalisadorX).

Caso queira ver alguns exemplos do programa em execução: <a href="https://github.com/Samuel-0liveira/AnalisadorX/blob/master/doc/FUNCIONALIDADE.md">exemplo.</a>

</p>
