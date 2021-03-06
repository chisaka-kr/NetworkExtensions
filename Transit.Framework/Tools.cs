﻿using static ColossalFramework.Plugins.PluginManager;
using ColossalFramework.Plugins;
using ColossalFramework.PlatformServices;
using Object = UnityEngine.Object;
using UnityEngine;
using System.Linq;
using ICities;
using System;
using Transit.Framework.Mod;

namespace Transit.Framework
{
    public static class Tools
    {
        public static void Compare<T>(T unityObj, T otherUnityObj)
             where T : Object
        {
            Debug.Log(string.Format("TFW: ----->  Comparing {0} with {1}", unityObj.name, otherUnityObj.name));

            var fields = typeof(T).GetAllFieldsFromType();

            foreach (var f in fields)
            {
                var newValue = f.GetValue(unityObj);
                var oldValue = f.GetValue(otherUnityObj);

                if (!Equals(newValue, oldValue))
                {
                    Debug.Log(string.Format("Value {0} not equal (N-O) ({1},{2})", f.Name, newValue, oldValue));
                }
            }
        }

        public static void ListMembers<T>(this T unityObj)
            where T : Object
        {
            Debug.Log(string.Format("TFW: ----->  Listing {0}", unityObj.name));

            var fields = typeof(T).GetAllFieldsFromType();

            foreach (var f in fields)
            {
                var value = f.GetValue(unityObj);
                Debug.Log(string.Format("Member name \"{0}\" value is \"{1}\"", f.Name, value));
            }
        }

        public static string PackageName(string assetName)
        {
            var publishedFileID = PluginInfo.publishedFileID.ToString();
            if (publishedFileID.Equals(PublishedFileId.invalid.ToString()))
            {
                return assetName;
            }
            return publishedFileID;
        }

        private static PluginInfo PluginInfo
        {
            get
            {
                var pluginManager = PluginManager.instance;
                var plugins = pluginManager.GetPluginsInfo();

                foreach (var item in plugins)
                {
                    try
                    {
                        var instances = item.GetInstances<IUserMod>();
                        if (!(instances.FirstOrDefault() is TransitModBase))
                        {
                            continue;
                        }
                        return item;
                    }
                    catch
                    {

                    }
                }
                throw new Exception("Failed to find NetworkExtensions assembly!");

            }
        }
    }
}
