using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.S3Events;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.LambdaJsonSerializer))]
namespace func_WithCDK
{
    public class Function
    {        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(S3Event evnt, ILambdaContext context)
        {
            var s3Event = evnt.Records[0].S3;
            context.Logger.LogLine ($"Event Received by Lambda Function from {s3Event.Bucket.Name}");

            return "Request Processed Succesfully";
        }
    }
}
