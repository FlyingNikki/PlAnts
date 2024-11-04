#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomPlant))]
public class CustomPlantEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Get the target script (CustomPlant) and serialized properties
        CustomPlant plant = (CustomPlant)target;
        SerializedProperty plantData = serializedObject.FindProperty("_plantData");
        SerializedProperty shooting = serializedObject.FindProperty("_shooting");
        SerializedProperty shotingPoint = serializedObject.FindProperty("shotingPoint");
        SerializedProperty plantID = serializedObject.FindProperty("plantID");
        SerializedProperty enemyTag = serializedObject.FindProperty("enemyTag");
        SerializedProperty orientationPoint = serializedObject.FindProperty("OrientationPoint");
        SerializedProperty partToRotat = serializedObject.FindProperty("partToRotat");

        // Draw default fields
        EditorGUILayout.PropertyField(plantData);
        EditorGUILayout.PropertyField(shooting);

        // Check if _shooting is true to display the LOL fields
        if (shooting.boolValue)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("-----LOL----->", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(shotingPoint);
            EditorGUILayout.PropertyField(plantID);
            EditorGUILayout.PropertyField(enemyTag);
            EditorGUILayout.PropertyField(orientationPoint);
            EditorGUILayout.PropertyField(partToRotat);
        }

        // Apply changes
        serializedObject.ApplyModifiedProperties();
    }
}
#endif
