1) Crie um usuário postgres com a senha 4dm1n

2) Crie um database no pgadmin com o nome DeveloperEvaluation

3) Ir até o diretório \Ambev.DeveloperEvaluation\backend\src\Ambev.DeveloperEvaluation.WebApi e rodar dotnet ef database update

4) Cadastar as filiais
{
  "codigo": "SP",
  "nome": "São Paulo"
}
{
  "codigo": "RJ",
  "nome": "Rio de Janeiro"
}
{
  "codigo": "MG",
  "nome": "Minas Gerais"
}

5) Crie a sequence no banco de dados

CREATE SEQUENCE IF NOT EXISTS seq_venda;

6) Execute o Projeto Backend no Visual Studio

7) Vá até o caminho deste diretório Ambev.DeveloperEvaluation\frontend\AmbevFront, após a instalação do angular rode ng serve