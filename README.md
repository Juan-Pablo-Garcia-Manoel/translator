# Programa de Tradução e Integração com Azure AI

Olá,

Estou compartilhando com vocês o código desenvolvido para realizar traduções de textos e documentos utilizando os serviços da Azure, especificamente os serviços **Azure Translator** e **Azure OpenAI**.

## Descrição do Projeto:
Este software oferece as seguintes funcionalidades:

- **readText()**: Traduz um texto informado via console e retorna a tradução também via console.
- **readDocument()**: Traduz um documento no formato `.txt` e salva a tradução no mesmo arquivo no formato JSON.
- **chatOpenAI()**: Realiza interações com o Azure OpenAI, podendo ser usado para diversas finalidades (ex: fazer cálculos, responder perguntas, etc.), com a resposta sendo retornada no console.
- **chatOpenAIArticleDocument()**: Traduz o conteúdo de um documento para o idioma solicitado e exibe o resultado no console.

## Instruções para Configuração:

1. **Instalação de Pacotes**:
    - Para utilizar os serviços do **Azure OpenAI**, execute o seguinte comando para instalar os pacotes necessários:
      ```bash
      dotnet add package Azure.AI.OpenAI --prerelease
      ```
    - Para utilizar o **Azure Translator**, instale o pacote **Newtonsoft.Json** em sua IDE.

2. **Configuração dos Serviços Azure**:
    - Preencha as classes `InfoConnectionAzureChatOpenAI` (para Azure OpenAI) e `InfoConnectionTranslate` (para Azure Translator) com as credenciais do serviço (Chave, Endpoint, Região, etc.), conforme informado na página de cada serviço no portal da Azure.

    Links úteis para consulta:
    - [Azure Translator - Documentação](https://learn.microsoft.com/en-us/azure/ai-services/translator/quickstart-text-rest-api?tabs=csharp)
    - [Azure OpenAI - Documentação](https://learn.microsoft.com/pt-br/azure/ai-services/openai/chatgpt-quickstart?tabs=command-line%2Cjavascript-keyless%2Ctypescript-keyless%2Cpython-new&pivots=programming-language-csharp)

3. **Idioma de Tradução**:
    - Ao utilizar os serviços de tradução, utilize a nomenclatura dos códigos de idioma ISO 639, conforme os idiomas suportados pelos serviços.

## ⚠️ **Importante**: Custo dos Serviços Azure

**ATENÇÃO**: O uso dos serviços Azure pode gerar custos, que são cobrados diretamente pela plataforma. **Antes de usar o software, consulte as tarifas e encargos relacionados ao uso dos serviços conforme sua configuração na Azure.**

Esteja ciente de que o consumo dos serviços é cobrado com base nas suas configurações e uso na plataforma da Azure.

## Observações:
- Este software está em constante aprimoramento e novos recursos serão adicionados conforme o avanço nos meus estudos.

Espero que o software seja útil para suas necessidades de tradução e interação com a Azure!

***

# Translation Program and Azure AI Integration

Hello,

I am sharing with you the code developed to perform text and document translations using Azure services, specifically **Azure Translator** and **Azure OpenAI**.

## Project Description:
This software provides the following functionalities:

- **readText()**: Translates a text entered via the console and returns the translation via the console.
- **readDocument()**: Translates a `.txt` document and saves the translation in the same file in JSON format.
- **chatOpenAI()**: Interacts with Azure OpenAI, which can be used for various purposes (e.g., calculations, answering questions, etc.), with the response being returned to the console.
- **chatOpenAIArticleDocument()**: Translates the content of a document to the requested language and displays the result in the console.

## Setup Instructions:

1. **Package Installation**:
    - To use the **Azure OpenAI** services, run the following command to install the necessary packages:
      ```bash
      dotnet add package Azure.AI.OpenAI --prerelease
      ```
    - To use the **Azure Translator** service, install the **Newtonsoft.Json** package in your IDE.

2. **Azure Service Configuration**:
    - Fill in the `InfoConnectionAzureChatOpenAI` class (for Azure OpenAI) and `InfoConnectionTranslate` class (for Azure Translator) with the service credentials (Key, Endpoint, Region, etc.), as provided on each service's page on the Azure portal.

    Useful links for reference:
    - [Azure Translator - Documentation](https://learn.microsoft.com/en-us/azure/ai-services/translator/quickstart-text-rest-api?tabs=csharp)
    - [Azure OpenAI - Documentation](https://learn.microsoft.com/pt-br/azure/ai-services/openai/chatgpt-quickstart?tabs=command-line%2Cjavascript-keyless%2Ctypescript-keyless%2Cpython-new&pivots=programming-language-csharp)

3. **Translation Language**:
    - When using the translation services, use the ISO 639 language code nomenclature, according to the supported languages of each service.

## ⚠️ **Important**: Azure Service Costs

**ATTENTION**: Using Azure services may incur costs, which are charged directly by the platform. **Before using the software, consult the pricing and charges related to each service based on your configuration in Azure.**

Be aware that service consumption is billed based on your configuration and usage on the Azure platform.

## Notes:
- This software is constantly being improved, and new features will be added as I continue my studies.

I hope the software is useful for your translation and Azure interaction needs!

