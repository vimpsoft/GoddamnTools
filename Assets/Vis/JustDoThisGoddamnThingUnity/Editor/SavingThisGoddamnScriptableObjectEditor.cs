using UnityEngine;
using Vis.JustSaveThisGoddamnData;

namespace Vis.JustDoThisGoddamnThingUnity
{
    /// <summary>
    /// Just inherit this class for your scriptableObject type to make it goddman savable:)
    /// </summary>
    public class SavingThisGoddamnScriptableObjectEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var so = target as ScriptableObject;
            if (so != default && GUILayout.Button("Save"))
            {
                ThisGoddamnScriptableObjectSaverUtility.Save(so);
            }
        }
    }
}
