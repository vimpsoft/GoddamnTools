#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEngine;

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

            var ourPath = AssetDatabase.GUIDToAssetPath("4c2784811bfb73a488f5c1f3bd4bbbef");
            var instance = ScriptableObject.CreateInstance(goddamnScriptableObject.GetType());
            EditorUtility.CopySerialized(goddamnScriptableObject, instance);
            var wastePath = Path.Combine(ourPath, Path.GetFileName(goddamnPath));
            AssetDatabase.CreateAsset(instance, wastePath);
            var yamlData = File.ReadAllText(wastePath);
            AssetDatabase.DeleteAsset(wastePath);
            Object.DestroyImmediate(instance);
            File.WriteAllText(goddamnPath, yamlData);
        }
    }
}
#endif