using Azure.AI.OpenAI;
using Azure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Translator;

namespace translator
{
    internal class Message 
    {
        private string text;
        public string getText()
        {
            return text;
        }
        public void setText(string text)
        {
            this.text = text;
        }

        private string systemText;
        public string getSystemText()
        {
            return systemText;
        }
        public void setSystemText(string systemText)
        {
            this.systemText = systemText;
        }


        private string systemTextUser;
        public string getSystemTextUser()
        {
            return systemTextUser;
        }
        public void setSystemTextUser(string systemTextUser)
        {
            this.systemTextUser = systemTextUser;
        }

        private string languageFrom;
        public string getLanguageFrom()
        {
            return languageFrom;
        }
        public void setLanguageFrom(string languageFrom)
        {
            this.languageFrom = languageFrom;
        }
        
        private string languageTo;
        public string getLanguageTo()
        {
            return languageTo;
        }
        public void setLanguageTo(string languageTo)
        {
            this.languageTo = languageTo;
        }

        private static readonly string caminhoDocs = "H:\\GitHub\\translator\\Arquivos\\Indios - Legião Urbana.txt";
        public string getCaminhoDocs()
        {
            return caminhoDocs;
        }

        public async Task readText()
        {

            Console.Write("\nInforme o idioma do texto: ");
            setLanguageFrom(Console.ReadLine());

            Console.Write("\nInforme o idioma de tradução: ");
            setLanguageTo(Console.ReadLine());

            Console.Write("\nInforme a menssagem: ");
            setText(Console.ReadLine());

            try
            {
                ConnectionTranslatorAPI connectionTranslatorAPI = new ConnectionTranslatorAPI();
                await connectionTranslatorAPI.connectionAPI(this);
                Console.WriteLine(connectionTranslatorAPI.getResult());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao processar a tradução: {ex.Message}\n");
            }

        }

        public async Task readDocument()
        {

            Console.Write($"\nInforme o idioma do texto: ");
            setLanguageFrom(Console.ReadLine());

            Console.Write($"\nInforme o idioma de tradução: ");
            setLanguageTo(Console.ReadLine());

            try
            {
                string textDocument = " ";

                var lines = File.ReadAllLines(getCaminhoDocs());

                for (int i = 0; i < lines.Length; i++)
                {
                    textDocument += lines[i];
                }

                setText(textDocument);

                ConnectionTranslatorAPI connectionTranslatorAPI = new ConnectionTranslatorAPI();
                await connectionTranslatorAPI.connectionAPI(this);

                var file = File.CreateText(getCaminhoDocs());
                file.WriteLine(connectionTranslatorAPI.getResult());
                file.Close();
                Console.WriteLine("\nTradução salva no arquivo!\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\nErro ao processar o arquivo: {ex.Message}\n");
            }
            
        }

        public async Task chatOpenAI()
        {
            Console.Write("\nQual a minha será a minha funcionalidade :");
            setSystemText(Console.ReadLine());

            Console.Write("\nInforme a menssagem: ");
            setSystemTextUser(Console.ReadLine());

            try
            {
                ConnectionTranslatorAPI connectionTranslatorAPI = new ConnectionTranslatorAPI();
                await connectionTranslatorAPI.connectionAzureChatOpenAI(this);
                Console.WriteLine(connectionTranslatorAPI.getResult());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao processar a solicitação: {ex.Message}\n");
            }
        }

        public async Task chatOpenAIArticleDocument()
        {
            setSystemText("Você atua como tradutor de textos.");

            Console.Write("\nInforme o idioma de tradução: ");
            setLanguageTo(Console.ReadLine());

            try
            {
                string textDocument = " ";

                var lines = File.ReadAllLines(getCaminhoDocs());

                for (int i = 0; i < lines.Length; i++)
                {
                    textDocument += lines[i];
                }

                setText(textDocument);

                setSystemTextUser($"Traduza o {textDocument} para o idioma {getLanguageTo()} e responda em markdown removendo a estrutura json!");

                ConnectionTranslatorAPI connectionTranslatorAPI = new ConnectionTranslatorAPI();
                await connectionTranslatorAPI.connectionAzureChatOpenAI(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao processar: {ex.Message}\n");
            }
        }
    }
}