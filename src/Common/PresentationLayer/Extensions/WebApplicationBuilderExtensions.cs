using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;

namespace Common.Presentation.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder MergeConfigurationFiles(this WebApplicationBuilder builder, string prefix, string baseDir)
    {
        var ocelotConfigDirectory = Path.Combine(builder.Environment.ContentRootPath, baseDir);

        if (Directory.Exists(ocelotConfigDirectory))
        {
            var mergedConfig = new JObject();

            string configFileName = $"{prefix}.*.json";
            string mergedFileName = $"{prefix}-merged.json";

            /* if (!builder.Environment.IsProduction())
            {
                mergedFileName = $"{prefix}.{builder.Environment.EnvironmentName}.json";
                configFileName = $"{prefix}.{builder.Environment.EnvironmentName}.*.json";
            } */

            foreach (var file in Directory.GetFiles(ocelotConfigDirectory, configFileName, SearchOption.TopDirectoryOnly))
            {
                var jsonConfig = JObject.Parse(File.ReadAllText(file));
                mergedConfig.Merge(jsonConfig, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union
                });
            }
            
            var mergedConfigFilePath = Path.Combine(builder.Environment.ContentRootPath, baseDir, mergedFileName);
            File.WriteAllText(mergedConfigFilePath, mergedConfig.ToString());
            builder.Configuration.AddJsonFile(mergedConfigFilePath, optional: false, reloadOnChange: true);
        }
        return builder;
    }
}
