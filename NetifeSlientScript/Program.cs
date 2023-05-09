// See https://aka.ms/new-console-template for more information

using System.Text.Json.Nodes;
using Grpc.Core;
using NetifeSlientScript;
using NetifeSlientScript.Model;
using NetifeSlientScript.Services;

var jsonNode = JsonNode.Parse(File.ReadAllText(Path.Join("config","core.json")))!;
var configuration = new RuntimeConfiguration();
configuration.DispatcherHost = jsonNode["config"]!["dispatcherHost"]!.ToString();
configuration.DispatcherPort = jsonNode["config"]!["dispatcherPort"]!.ToString();
configuration.FrontendHost = jsonNode["config"]!["frontendHost"]!.ToString();
configuration.FrontendPort = jsonNode["config"]!["frontendPort"]!.ToString();
configuration.JsRemoteHost = jsonNode["config"]!["jsRemoteHost"]!.ToString();
configuration.JsRemotePort = jsonNode["config"]!["jsRemotePort"]!.ToString();
CliHelper.BuildServer(configuration);

new Server
{
    Services =
    {
        NetifeMessage.NetifePost.BindService(new FrontendService())
    },
    Ports = { new ServerPort(configuration.FrontendHost, int.Parse(configuration.FrontendPort), ServerCredentials.Insecure) }
}.Start();

Console.WriteLine("[Netife]Slient Working...");

//关闭事件
Console.CancelKeyPress += (sender, eventArgs) =>
{
    CliHelper.EndServices();
};