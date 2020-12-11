#if UNITY_EDITOR
using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Vis.JustSaveThisGoddamnData
{
    /*
     * Saves ScriptableObjects via hacky way of writing new yaml
     * into .asset file.
     */
    public static class ThisGoddamnScriptableObjectSaverUtility
    {
        public static void Save<T>(T goddamnScriptableObject) where T : ScriptableObject
        {
            var goddamnPath = AssetDatabase.GetAssetPath(goddamnScriptableObject);
            if (string.IsNullOrEmpty(goddamnPath))
            {
                return;
            }
            var ourPath = AssetDatabase.GUIDToAssetPath("6bd30f83b6164734685f670f95eb5e88");
            if (string.IsNullOrEmpty(ourPath))
            {
                throw new ApplicationException($"{nameof(ThisGoddamnScriptableObjectSaverUtility)}: isn't working! Damn...");
            }
            var dummyInstance = ScriptableObject.CreateInstance(goddamnScriptableObject.GetType());
            EditorUtility.CopySerialized(goddamnScriptableObject, dummyInstance);
            var dummyPath = Path.Combine(Path.GetDirectoryName(ourPath), Path.GetFileName(goddamnPath));
            AssetDatabase.CreateAsset(dummyInstance, dummyPath);
            var yamlData = File.ReadAllText(dummyPath);
            AssetDatabase.DeleteAsset(dummyPath);
            Object.DestroyImmediate(dummyInstance);
            File.WriteAllText(goddamnPath, yamlData);
        }
    }
}
#endif