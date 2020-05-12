using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetLambdaDemo
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new DotnetLambdaDemoStack(app, "DotnetLambdaDemoStack");
            app.Synth();
        }
    }
}
