using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    dynamic data = await req.Content.ReadAsStringAsync();
    log.Info("\n\n**** Sent Message -> \n" + data.ToString());

    return req.CreateResponse(HttpStatusCode.OK, "Message Received");
}
