using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PicsGeneration))]
public class PicsGenerationEditor : Editor {
    public override void OnInspectorGUI() {
        PicsGeneration scripts = ((PicsGeneration) target);
        base.OnInspectorGUI();

        GUILayout.Space(4);
        using (new GUILayout.HorizontalScope()) {
            GUILayout.Label("LEFT :", EditorStyles.boldLabel);
            if (GUILayout.Button("Generate Random Pics Left")) scripts.GenerateRandomPicsBySide(Side.Left);
            if (GUILayout.Button("Reset Pics Left")) scripts.ResetPicsBySide(Side.Left, true);
        }
        GUILayout.Space(4);
        using (new GUILayout.HorizontalScope()) {
            GUILayout.Label("RIGHT :", EditorStyles.boldLabel);
            if (GUILayout.Button("Generate Random Pics Right")) scripts.GenerateRandomPicsBySide(Side.Right);
            if (GUILayout.Button("Reset Pics Right")) scripts.ResetPicsBySide(Side.Right, true);
        }
    }
}
