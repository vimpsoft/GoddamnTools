using UnityEngine;

namespace VimpSoft.GoddamnTools
{
    /// <summary>
    /// Just derive this class for your scriptableObject editor to make it goddamn savable:)
    /// 
    /// Use like this:
    /// [CustomEditor(typeof(*Your ScriptableObject-derived type name *))]
    /// public class *Your ScriptableObject-derived type name* : SavingThisGoddamnScriptableObjectEditor
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
