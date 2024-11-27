using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.AI.OpenAI;
using static System.Environment;

namespace Translator.InfoConnection
{
    internal class InfoConnectionAzureChatOpenAI
    {
        private static readonly string key = "";
        public string getKey()
        {
            return key;
        }

        private static readonly string endpoint = "";
        public string getEndpoint()
        {
            return endpoint;
        }

        private static readonly string deploymentName = "";
        public string getDeploymentName()
        {
            return deploymentName;
        }
    }
}
