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

        //default fields...
        SerializedProperty plantData = serializedObject.FindProperty("_plantData");
        SerializedProperty shooting = serializedObject.FindProperty("_shooting");
        SerializedProperty full_AOE = serializedObject.FindProperty("_full_AOE");

        //basic fields...
        SerializedProperty enemyTag = serializedObject.FindProperty("enemyTag");
        SerializedProperty orientationPoint = serializedObject.FindProperty("OrientationPoint");
        SerializedProperty partToRotat = serializedObject.FindProperty("partToRotat");

        //shooting fields...
        SerializedProperty bullet = serializedObject.FindProperty("_Bullet");
        SerializedProperty shotingPoint = serializedObject.FindProperty("shotingPoint");
        SerializedProperty bulletDestroyTime = serializedObject.FindProperty("BulletDestroyTime");

        //full-AOE fields...
        SerializedProperty gas = serializedObject.FindProperty("gas");
        SerializedProperty startPoint = serializedObject.FindProperty("shotingPoint");
        SerializedProperty gasDestroyTime = serializedObject.FindProperty("gasDestroyTime");

        // Draw default fields
        EditorGUILayout.PropertyField(plantData);
        EditorGUILayout.PropertyField(shooting);
        EditorGUILayout.PropertyField(full_AOE);

        // Check if _shooting is true to display the SHOOTING fields
        if (shooting.boolValue)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("-----SHOOTING----->", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(enemyTag);
            EditorGUILayout.PropertyField(partToRotat);
            EditorGUILayout.PropertyField(orientationPoint);

            EditorGUILayout.PropertyField(bullet);
            EditorGUILayout.PropertyField(shotingPoint);
            EditorGUILayout.PropertyField(bulletDestroyTime);
        }

        // Check if _full_AOE is true to display the FULL/AOE fields
        if (full_AOE.boolValue)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("-----FULL/AOE----->", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(enemyTag);
            EditorGUILayout.PropertyField(orientationPoint);

            EditorGUILayout.PropertyField(gas);
            EditorGUILayout.PropertyField(startPoint);
            EditorGUILayout.PropertyField(gasDestroyTime);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
