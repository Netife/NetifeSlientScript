using Grpc.Core;
using NetifeMessage;

namespace NetifeSlientScript.Services;

public class FrontendService : NetifeMessage.NetifePost.NetifePostBase
{
    public override Task<NetifeMessage.NetifeProbeResponse>
        UploadRequest(NetifeMessage.NetifeProbeRequest request, ServerCallContext context)
    {
        var res = new NetifeProbeResponse();
        res.Uuid = request.Uuid;
        res.DstIpAddr = request.DstIpAddr;
        res.DstIpPort = request.DstIpPort;
        res.ResponseText = request.RawText;
        return Task.FromResult(res);
    }
}