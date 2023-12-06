<p align="center">
  <img src="https://imgur.com/LyoYvJ0.png" style="width: 120px; height: 120px;"/>
</p>
<h1 align="center">API Backend - Projeto Integrador II</h1>
<p align="center">
  <a><img src="https://img.shields.io/badge/status-online-green" /></a>
</p>

# Introdução
<div style='text-align: justify;'>
    Este projeto é referente a uma das partes do trabalho realizado na disciplina de Projeto Integrador II da Universidade do Extremo Sul Catarinense (UNESC). 
    Tem-se como objetivo disponibilizar o acesso ao banco de dados a parte física (ESP32 e Arduino) e ao frontend.
</div>

# Instalação e Requerimentos
Para instalar o projeto é necessário possuir o [Docker](https://www.docker.com) instalado no computador de destino.

Com o Docker instalado, deve-se clonar o repositório na máquina.

Agora, precisa-se utilizar os seguintes comandos para a criação da imagem Docker no computador e a sua execução.

### Criação da Imagem
Para criar a imagem docker você deve utilizar o comando a seguir:

```powershell
docker build -f "[Caminho do Dockerfile no projeto]\Dockerfile" --force-rm -t apipostgresql  --label "com.microsoft.created-by=visual-studio" --label "com.microsoft.visual-studio.project-name=API_PostgreSql" "[Caminho da raiz do projeto]\API-Base-PostgreSql"
```

Lembrando que no ```[Caminho do Dockerfile no projeto]``` deve-se inserir o local onde está localizado o Dockerfile dentro do projeto.

Junto a isso, no ```[Caminho da raiz do projeto]``` precisa-se inserir o caminho do repositório onde o projeto foi clonado.

### Criação e execução do container
Após a criação da imagem, é preciso executar o comando a seguir para criar o container com a imagem indicada:

```powershell
docker run --name apipostgresql -p 80:80 -it apipostgresql
```
Com o container já criado, será possível acessar os endpoints disponíveis na documentação a seguir:

https://app.swaggerhub.com/apis/MARCIOJRGODOI_1/api-postgre_sql/1.0


# Tecnologias utilizadas
Para a criação desta API foi utilizado a linguagem de programação C# com um projeto ASP.NET Core e Docker para a containerização de todo o projeto.
