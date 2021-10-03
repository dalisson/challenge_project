# challenge_project
<H1>projeto desafio api restful dotnet core 5</H1>
<p>A api utliliza dotnet core 5 e banco dados MySQL (8.0.26 community), a configuracao de conexao e feita pela string de conexao 
<b>"MySQLConnectionString": "Server=localhost;DataBase=basededados;Uid=usuario;Pwd=password"</b>
no arquivo <b>appsettings.json</b></p>

<H2><b>MIGRATION</b></H2>

Necessário que o banco de dados <b>já tenha sido criado</b> e esteja limpo para a execucao da migration.
A migration ocorre em desenvolvimento <b>(if (Environment.IsDevelopment()))</b>

<b>Usuario Default</b>
<p>Purante a migration há o seed do usuário padrao, o método de cadastro de usuário está disponível como documentado pelo swagger: </p>
<p>Usuario padrão ja cadastrado no banco:</p>
<p>userName:admin1234</p>
<p>password:admin1234</p>

<H2>Sobre o projeto</H2>

<p>Authenticacao por JWT<p>
<p>Arquitetura em camadas.</p>
<p>Padrao de projeto VO.</p>
<p>Aceita JSON ou XML.</p>
<p>Dotnet Core 5.</p>
<p>HATEOAS.</p>
<p>versionamento de endpoints.</p>
