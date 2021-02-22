using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
#endif

[CanEditMultipleObjects]
public class DialogueComponent : MonoBehaviour
{
    [System.Serializable]
    public class Dialogue
    {
        public GameObject box = null;
        public Sprite boxSprite = null; 
        public string text = "";
        public float waintingTime = 0f; 
        public float letterPerSecond = .02f;
    }

    public List<Dialogue> dialogues = new List<Dialogue>(); 
    private DialogueBox tmpDialBox = null;
    private bool canPlay = true; 
    private PlayerController player = null;
    public static bool launch = true; 
    private int currentDial = 0;

    private void Start() 
    {
        player = GameManager.FindObjectOfType<PlayerController>();     
    }

    private void Update() 
    {
        if(launch)    
        {
            tmpDialBox = dialogues[currentDial].box.GetComponent<DialogueBox>();
            tmpDialBox.dialogSprite = dialogues[currentDial].boxSprite;
            tmpDialBox.letterPerSecond = dialogues[currentDial].letterPerSecond; 

            if(!tmpDialBox.Exist())
            {
                tmpDialBox.Clear();
                tmpDialBox.AddString(dialogues[currentDial].text);
                tmpDialBox.Play(); 
            }
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueComponent))]
public class DialogueEditor : Editor
{
    private ReorderableList list;
    GUIStyle style;
    GUIStyle styleText;
    private bool initStyle = false;
    private void InitStyles(DialogueComponent d)
    {
        style = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleCenter,
            fontSize = 20,
            fontStyle = FontStyle.Normal,
            fixedHeight = 30,
            fixedWidth = 30,
            stretchHeight = true,
            margin = new RectOffset(0,10,10,5),
            padding = new RectOffset(0,0,0,0)
        };
        styleText = new GUIStyle(GUI.skin.label)
        {
            alignment = TextAnchor.MiddleCenter,
            fontSize = 20,
            fontStyle = FontStyle.Normal,
            fixedHeight = 30,
            fixedWidth = 30,
            stretchHeight = true,
            margin = new RectOffset(0, 10, 10, 5),
            padding = new RectOffset(0, 0, 0, 0)
        };
        initStyle = true;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DialogueComponent DialogueComponent = (DialogueComponent)target;

        InitStyles(DialogueComponent);
            

        // if (!DialogueComponent.doOnce)
        // {
        //     DialogueComponent.dialogues.Add(new DialogueComponent.DialogueClass());
        //     DialogueComponent.doOnce = true;
        // }
        DialogueComponent.dialogues.Add(new DialogueComponent.Dialogue());
        EditorGUILayout.BeginHorizontal();
        
        EditorGUILayout.BeginHorizontal("box");
        EditorGUIUtility.fieldWidth = 160;
        EditorGUIUtility.labelWidth = 80;
       // DialogueComponent.stopPlayer = EditorGUILayout.Toggle("Block Player", DialogueComponent.stopPlayer);
        EditorGUILayout.EndHorizontal();

        GUILayout.FlexibleSpace();
        if (GUILayout.Button("+", style))
        {
            DialogueComponent.dialogues.Add(new DialogueComponent.Dialogue());
        }
        if (GUILayout.Button("-", style))
        {
            if(DialogueComponent.dialogues.Count > 0)
                DialogueComponent.dialogues.RemoveAt(DialogueComponent.dialogues.Count - 1);
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginVertical("box");
        
        for (int i = 0; i < DialogueComponent.dialogues.Count; i++)
        {
            
            EditorGUILayout.BeginHorizontal("window");
            EditorGUILayout.BeginVertical();
            EditorGUIUtility.fieldWidth = 140;
            EditorGUIUtility.labelWidth = 60;
            DialogueComponent.dialogues[i].box = (GameObject)EditorGUILayout.ObjectField("Speeker", DialogueComponent.dialogues[i].box, typeof(GameObject), true, GUILayout.ExpandWidth(false));
            EditorGUIUtility.labelWidth = 60;
            EditorGUIUtility.fieldWidth = 130;
            EditorStyles.textField.wordWrap = true;
            EditorGUILayout.LabelField("Text");
            
            DialogueComponent.dialogues[i].text = GUILayout.TextArea(DialogueComponent.dialogues[i].text, 44, GUILayout.Height(30));
            EditorGUIUtility.labelWidth = 80;
            EditorGUIUtility.fieldWidth = 30;
           // DialogueComponent.dialogues[i].waitingTime = EditorGUILayout.Slider("Waiting Time", DialogueComponent.dialogues[i].waitingTime, 0f, 10f);
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();
            EditorGUIUtility.labelWidth = 70;
            EditorGUIUtility.fieldWidth = 60;
            DialogueComponent.dialogues[i].boxSprite = (Sprite)EditorGUILayout.ObjectField("DialogueComponent", DialogueComponent.dialogues[i].boxSprite, typeof(Sprite), false, GUILayout.Height(100));
            EditorGUILayout.LabelField("Writing Speed(S)");
            EditorGUIUtility.labelWidth = 80;
            EditorGUIUtility.fieldWidth = 40;

            DialogueComponent.dialogues[i].letterPerSecond = EditorGUILayout.Slider(DialogueComponent.dialogues[i].letterPerSecond, 0.01f, 1f);
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(10);
         }
        EditorGUILayout.EndVertical();
        EditorUtility.SetDirty(DialogueComponent);
        serializedObject.ApplyModifiedProperties();
        
    }
}
#endif
