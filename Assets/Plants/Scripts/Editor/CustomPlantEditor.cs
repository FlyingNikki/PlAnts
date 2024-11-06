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
        SerializedProperty enemyTag = serializedObject.FindProperty("enemyTag");
        SerializedProperty bullet = serializedObject.FindProperty("_Bullet");
        SerializedProperty bulletDestroyTime = serializedObject.FindProperty("BulletDestroyTime");
        SerializedProperty orientationPoint = serializedObject.FindProperty("OrientationPoint");
        SerializedProperty partToRotat = serializedObject.FindProperty("partToRotat");
        SerializedProperty full_AOE = serializedObject.FindProperty("_full_AOE");

        // Draw default fields
        EditorGUILayout.PropertyField(plantData);
        EditorGUILayout.PropertyField(shooting);
        EditorGUILayout.PropertyField(full_AOE);

        // Check if _shooting is true to display the SHOOTING fields
        if (shooting.boolValue)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("-----SHOOTING----->", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(shotingPoint);
            EditorGUILayout.PropertyField(enemyTag);
            EditorGUILayout.PropertyField(bullet);
            EditorGUILayout.PropertyField(bulletDestroyTime);
            EditorGUILayout.PropertyField(orientationPoint);
            EditorGUILayout.PropertyField(partToRotat);
        }

        // Check if _full_AOE is true to display the FULL/AOE fields
        if (full_AOE.boolValue)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("-----FULL/AOE----->", EditorStyles.boldLabel);


        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
