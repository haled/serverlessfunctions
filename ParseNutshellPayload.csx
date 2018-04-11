using System.Net;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    dynamic data = await req.Content.ReadAsAsync<object>();
    log.Info("\n\n**** Payload as Object ->\n" + data.ToString());

    if(data != null && data.events != null)
    {
        //log.Info("\n\n**** In IF");
        foreach(var nutshellEvent in data.events)
        {
            //log.Info("\n\n**** In FOREACH -> " + nutshellEvent.payloadType);
            if(nutshellEvent.payloadType == "leads" && nutshellEvent.action == "update")
            {
                log.Info("\n\n**** Detected a Lead Change -> " + nutshellEvent.htmlUrl);
            }
        }
    }

    return req.CreateResponse(HttpStatusCode.OK, "Object Parsed");
}