#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomEnemy))]
public class CustomEnemyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Get the target scripts (CustomEnemy) and serialized properties
        CustomEnemy enemy = (CustomEnemy)target;

        //default fields...
        SerializedProperty enemyData = serializedObject.FindProperty("_enemyData");
        SerializedProperty walking = serializedObject.FindProperty("_walking");
        SerializedProperty flying = serializedObject.FindProperty("_flying");

        //basic fields...
        SerializedProperty partToRotat = serializedObject.FindProperty("PartToRotat");
        SerializedProperty rigidbody = serializedObject.FindProperty("rb");
        SerializedProperty holder = serializedObject.FindProperty("holder");

        //walking fields...
        SerializedProperty walkSpeed = serializedObject.FindProperty("walkSpeed");

        //faying fields...
        SerializedProperty testFields = serializedObject.FindProperty("ComingSoon");

        // Draw default fields
        EditorGUILayout.PropertyField(enemyData);
        EditorGUILayout.PropertyField(walking);
        EditorGUILayout.PropertyField(flying);

        // Check if walking is true to display the WALKING fields
        if (walking.boolValue)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("-----WALKING----->", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(partToRotat);
            EditorGUILayout.PropertyField(rigidbody);
            EditorGUILayout.PropertyField(holder);

            EditorGUILayout.PropertyField(walkSpeed);
        }

        // Check if flaying is true to display the FLAYING fields
        if (flying.boolValue)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("-----FLYING----->", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(rigidbody);
            EditorGUILayout.PropertyField(holder);

            EditorGUILayout.PropertyField(testFields);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif