#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Vis.JustSaveThisGoddamnData
{
    public static class ThisGoddamnScriptableObjectSaverUtility
    {
        public static void Save<T>(T goddamnScriptableObject) where T : ScriptableObject
        {
            var ourPath = AssetDatabase.GUIDToAssetPath("4c2784811bfb73a488f5c1f3bd4bbbef");
            var instance = ScriptableObject.CreateInstance<T>();
            EditorUtility.CopySerialized(goddamnScriptableObject, instance);
            var goddamnDataPath = AssetDatabase.GetAssetPath(goddamnScriptableObject);
            var wastePath = Path.Combine(ourPath, Path.GetFileName(goddamnDataPath));
            AssetDatabase.CreateAsset(instance, wastePath);
            var yamlData = File.ReadAllText(wastePath);
            AssetDatabase.DeleteAsset(wastePath);
            Object.DestroyImmediate(instance);
            File.WriteAllText(goddamnDataPath, yamlData);
        }
    }
}
#endif