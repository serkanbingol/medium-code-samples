using Amazon.CDK;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.Lambda.EventSources;
using Amazon.CDK.AWS.S3;

namespace DotnetLambdaDemo {
    public class DotnetLambdaDemoStack : Stack {
        internal DotnetLambdaDemoStack (Construct scope, string id, IStackProps props = null) : base (scope, id, props) {
            // The code that defines your stack goes here

            // Create S3 Bucket
            var s3Bucket = new Bucket (this, "demoS3", new BucketProps {
                BucketName = "serverless-inventory-app-s3-bucket",
                    RemovalPolicy = RemovalPolicy.DESTROY
            });

            // Create Lambda Function for S3 Upload
            var func_WithCDK = new Function (this, "demoFuncS3", new FunctionProps {
                Runtime = Runtime.DOTNET_CORE_3_1,
                    FunctionName = "serverless-inventory-app-s3-func",
                    Code = Code.FromAsset ("src/func_WithCDK/prod/func_WithCDK"),
                    Handler = "func_WithCDK::func_WithCDK.Function::FunctionHandler"

            });
            
            // Add Lambda Function S3 Event
            func_WithCDK.AddEventSource (new S3EventSource (s3Bucket, new S3EventSourceProps {
                Events = new [] { EventType.OBJECT_CREATED }
            }));
        }
    }
}