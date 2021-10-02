# challenge_project
projeto desafio api restful dotnet core 5
A api utliliza dotnet core 5 e banco dados MySQL (8.0.26 community), a configuracao de conexao e feita pela string de conexao 
<b>"MySQLConnectionString": "Server=localhost;DataBase=basededados;Uid=usuario;Pwd=password"</b>
no arquivo <b>appsettings.json</b>

<b>IMPORTANTE</b>

Necessário que o banco de dados <b>já tenha sido criado</b> e esteja limpo para a execucao da migration.
A migration ocorre em desenvolvimento <b>(if (Environment.IsDevelopment()))</b>

Sobre o projeto

<p>Arquitetura em camadas.</p>
<p>Padrao de projeto VO.</p>
<p>Aceita JSON ou XML.</p>
<p>Dotnet Core 5.</p>
<p>HATEOAS.</p>
<p>versionamento de endpoints.</p>
