// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace ConsoleDotNettyServer
{
    using System;
    using DotNetty.Common.Internal.Logging;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging.Console;

    public static class ExampleHelper
    {
        static ExampleHelper()
        {
            Configuration = new ConfigurationBuilder() // nuget Microsoft.Extensions.Configuration
                .SetBasePath(ProcessDirectory)  // nuget Microsoft.Extensions.Configuration.FileExtensions;
                .AddJsonFile("appsettings.json")// nuget Microsoft.Extensions.Configuration.Json
                .Build();
            /*  备用两个引用 
             nuget Microsoft.Extensions.Configuration.Binder;
             nuget Microsoft.Extensions.Configuration.EnvironmentVariables;
             */
        }

        public static string ProcessDirectory
        {
            get
            {
#if NETSTANDARD1_3
                return AppContext.BaseDirectory;
#else
                return AppDomain.CurrentDomain.BaseDirectory;
#endif
            }
        }

        public static IConfigurationRoot Configuration { get; }

        public static void SetConsoleLogger() => InternalLoggerFactory.DefaultFactory.AddProvider(new ConsoleLoggerProvider((s, level) => true, false));
    }
}