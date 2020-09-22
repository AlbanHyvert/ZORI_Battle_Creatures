using UnityEditor;

[CustomEditor(typeof(D_StatSystem))]
[CanEditMultipleObjects]
public class E_UIDataSystem : Editor
{
    SerializedProperty d_StatSystem = null;
    D_StatSystem D_Stat = null;

    private void OnEnable()
    {
        d_StatSystem = serializedObject.FindProperty("D_StatSystem");
        D_Stat = (D_StatSystem)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.HelpBox("Below this box are Read Only Variables", MessageType.Info);
        EditorGUILayout.HelpBox("Each value is calculated based on 1 BP", MessageType.Info);
        EditorGUILayout.IntField("HP: ", D_Stat.GetHp);
        EditorGUILayout.IntField("GetAttack: ", D_Stat.GetAttack);
        EditorGUILayout.IntField("GetDefence: ", D_Stat.GetDefence);
        EditorGUILayout.IntField("Spe GetAttack: ", D_Stat.GetSpeAttack);
        EditorGUILayout.IntField("Spe GetDefence: ", D_Stat.GetSpeDefence);
        EditorGUILayout.IntField("Speed: ", D_Stat.GetSpeed);
        EditorGUILayout.IntField("Mana: ", D_Stat.GetMana);
        EditorGUILayout.FloatField("Max Experience: ", D_Stat.GetMaxExperience);
        D_Stat.OnValueChanged();
    }
}
