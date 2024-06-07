ARG DOTNETVERSION=7.0

# Etapa 1: Imagem de construção
FROM mcr.microsoft.com/dotnet/sdk:${DOTNETVERSION} AS build-env

WORKDIR /app

# Copie os arquivos do projeto e restaure as dependências
COPY *.csproj ./

# Restaurar dependências para todos os arquivos .csproj
RUN for file in $(ls *.csproj); do dotnet restore "$file"; done

# Copie todos os arquivos e compile a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNETVERSION}
WORKDIR /app
COPY --from=build-env /app/out .

# Exponha a porta usada pela aplicação
EXPOSE 5098

# Defina o ponto de entrada para o contêiner
ENTRYPOINT ["dotnet", "AutoEncontredotnet.dll"]

