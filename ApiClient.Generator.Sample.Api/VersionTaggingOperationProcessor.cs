using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace ApiClient.Generator.Sample.Api;

/// <summary>
/// 
/// </summary>
public class VersionTaggingOperationProcessor : IOperationProcessor
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public bool Process(OperationProcessorContext context)
    {
        var apiDesc = ((AspNetCoreOperationProcessorContext)context).ApiDescription;
        context.OperationDescription.Operation.Tags.Insert(0, apiDesc.GroupName);

        return true;
    }
}