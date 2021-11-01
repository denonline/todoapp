using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ToDoAppCommon.Configuration 
{
    public partial class ToDoConfig : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var config = new ToDoConfig();
            var startupNode = section.SelectSingleNode("Startup");
            if (startupNode?.Attributes != null)
            {
                var attribute = startupNode.Attributes["IgnoreStartupTasks"];
                if (attribute != null)
                    config.IgnoreStartupTasks = Convert.ToBoolean(attribute.Value);
            }
            var userAgentStringsNode = section.SelectSingleNode("UserAgentStrings");
            if (userAgentStringsNode?.Attributes != null)
            {
                var attribute = userAgentStringsNode.Attributes["databasePath"];
                if (attribute != null)
                    config.UserAgentStringsPath = attribute.Value;
            }

            var installationNode = section.SelectSingleNode("Publishing");
            config.UseFastPublishingService = GetBool(installationNode, "UseFastPublishingService");

            var redisCachingNode = section.SelectSingleNode("RedisCaching");
            config.RedisCachingEnabled = GetBool(redisCachingNode, "Enabled");
            config.RedisCachingConnectionString = GetString(redisCachingNode, "ConnectionString");

            var staticCachingNode = section.SelectSingleNode("StaticCaching");
            if (null != staticCachingNode)
            {
                StaticCachingEnabled = GetBool(staticCachingNode, "Enabled");
            }

            var timezoneAliasesNode = section.SelectSingleNode("TZAliasesData");
            if (timezoneAliasesNode?.Attributes != null)
            {
                var attribute = timezoneAliasesNode.Attributes["databasePath"];
                if (null != attribute)
                {
                    config.TimeZoneAliasesDataStorePath = attribute.Value;
                }
            }

            var timezoneMappingNode = section.SelectSingleNode("TZMappingData");
            if (null != timezoneMappingNode && null != timezoneMappingNode.Attributes)
            {
                var attribute = timezoneMappingNode.Attributes["databasePath"];
                if (null != attribute)
                {
                    config.TimeZoneMappingDataStorePath = attribute.Value;
                }
            }
            var pluralizerDataFolderNode = section.SelectSingleNode("Pluralizer");
            if (null != pluralizerDataFolderNode)
            {
                config.PluralizerRulesDataFolder = GetString(pluralizerDataFolderNode, "RulesDataFolder");
            }
            return config;
        }
        public bool IgnoreStartupTasks { get; private set; }
        public string UserAgentStringsPath { get; private set; }
        public bool UseFastPublishingService { get; private set; }
        public bool RedisCachingEnabled { get; private set; }
        public string RedisCachingConnectionString { get; private set; }
        public bool StaticCachingEnabled { get; set; }
        public string PluralizerRulesDataFolder { get; set; }
        #region Data files used by time zone name converter
        public string TimeZoneMappingDataStorePath { get; set; }
        public string TimeZoneAliasesDataStorePath { get; set; }
        #endregion

        #region Utilities
        private string GetString(XmlNode node, string attrName)
        {
            return SetByXElement(node, attrName, Convert.ToString);
        }

        private bool GetBool(XmlNode node, string attrName)
        {
            return SetByXElement(node, attrName, Convert.ToBoolean);
        }

        private T SetByXElement<T>(XmlNode node, string attrName, Func<string, T> converter)
        {
            if (node?.Attributes == null) return default(T);
            var attr = node.Attributes[attrName];
            if (attr == null) return default(T);
            var attrVal = attr.Value;
            return converter(attrVal);
        }
        #endregion
    }
}


