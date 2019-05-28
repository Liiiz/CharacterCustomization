using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(mCustomEditor))]
class MCustomEditor : Editor
{
    mCustomEditor mCustomEditor;
    //输入文字的内容
    private string text;
    private Transform BoneTransform;
    private bool[] BoneTransformAble = new bool[9];
    //private string[] BoneTransformAbleStr = new string[9]
    //{"Px", "Py", "Pz", "Rx", "Ry", "Rz","Sx", "Sy", "Sz" };

    private Transform AimBoneTransform;

    private bool DrawControlBool;
    private bool DrawAnimBool;

    
    //在这里方法中就可以绘制面板。
    public override void OnInspectorGUI()
    {
        //得到mCustomEditor对象
        mCustomEditor = (mCustomEditor)target;
        DrawDefaultInspector();

        if (GUILayout.Button("控制杆->骨骼 配置："))
        {
            DrawControlBool = !DrawControlBool;
        }
        if (DrawControlBool)
        {
            DrawControlInspector();
            GUILayout.Space(20);
        }

        if (GUILayout.Button("骨骼->动画 配置："))
        {
            DrawAnimBool = !DrawAnimBool;
        }
        if (DrawAnimBool)
        {
            DrawAnimInspector();
        }
    }

    void DrawControlInspector()
    {
        //GUILayout.Label("控制杆->骨骼 配置：", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        //输入框控件
        text = EditorGUILayout.TextField("控制杆名称:", text);
        if (GUILayout.Button("添加控制杆", GUILayout.Width(200)))
        {
            ControConfig controConfig = mCustomEditor.AddNewControl();
            controConfig.ControName = text;
        }
        GUILayout.EndHorizontal();

        if (mCustomEditor.ControConfig.Count > 0)
        {
            GUILayout.Label("骨骼->权限：", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            BoneTransform = EditorGUILayout.ObjectField(BoneTransform, typeof(Transform)) as Transform;
            for (int i = 0; i < BoneTransformAble.Length; i++)
            {
                BoneTransformAble[i] = EditorGUILayout.Toggle(BoneTransformAble[i]);
            }
            GUILayout.EndHorizontal();

        }

        for (int i = 0; i < mCustomEditor.ControConfig.Count; ++i)
        {
            DrawControl(i);
        }
        GUILayout.Space(5);
       // mCustomEditor.ControConfigFileName = EditorGUILayout.TextField(mCustomEditor.ControConfigFileName);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("保存控制Config", GUILayout.Width(200)))
        {
            mCustomEditor.saveControlConfig();
        }
        if (GUILayout.Button("导入Config", GUILayout.Width(200)))
        {
        }
        GUILayout.EndHorizontal();
    }
    void DrawControl(int index)
    {
        if (index < 0 || index >= mCustomEditor.ControConfig.Count)
        {
            return;
        }
        GUILayout.Space(5);
        SerializedObject _serializedObject = new SerializedObject(mCustomEditor);
        SerializedProperty listIterator = _serializedObject.FindProperty("ControConfig");

        GUILayout.BeginHorizontal();
        {
            //GUILayout.Label("Name", EditorStyles.label, GUILayout.Width(50));

            EditorGUI.BeginChangeCheck();

            string newName = GUILayout.TextField(mCustomEditor.ControConfig[index].ControName, GUILayout.Width(120));

            if (EditorGUI.EndChangeCheck())
            {
                //Create an Undo/Redo step for this modification
                Undo.RecordObject(mCustomEditor, "Modify State");

                mCustomEditor.ControConfig[index].ControName = newName;

                // 如果我们直接修改属性，而没有通过serializedObject，那么Unity并不会保存这些数据，Unity只会保存那些标识为dirty的属性
                EditorUtility.SetDirty(mCustomEditor);
            }

            if (GUILayout.Button("Remove"))
            {
                EditorApplication.Beep();

                //// 可以很方便的显示一个包含特定按钮的对话框，例如是否同意删除
                if (EditorUtility.DisplayDialog("Really?", "Do you really want to remove the state '" + mCustomEditor.ControConfig[index].ControName + "'?", "Yes", "No") == true)
                {
                    Undo.RecordObject(mCustomEditor, "Delete State");
                    mCustomEditor.ControConfig.RemoveAt(index);
                    EditorUtility.SetDirty(mCustomEditor);
                }
            }
            if (GUILayout.Button("添加骨骼", GUILayout.Width(200)))
            {
                if (BoneTransform == null) return;

                BoneControlConfig boneControlConfig = new BoneControlConfig();
                boneControlConfig.Bonetransform = BoneTransform;
                boneControlConfig.BoneName = BoneTransform.name;
                for (int i = 0; i < boneControlConfig.ControAble.Length; i++)
                {
                    boneControlConfig.ControAble[i] = BoneTransformAble[i];
                }
                mCustomEditor.ControConfig[index].ControBoneLis.Add(boneControlConfig);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUI.BeginChangeCheck();
            SerializedProperty ControBoneLis = listIterator.GetArrayElementAtIndex(index).FindPropertyRelative("ControBoneLis");
            EditorGUILayout.PropertyField(ControBoneLis, true);
            if (EditorGUI.EndChangeCheck())
            {
                _serializedObject.ApplyModifiedProperties();
            }
            GUILayout.EndHorizontal();
        }

    }

    void DrawAnimInspector()
    {
      //  GUILayout.Label("骨骼->动画 配置：", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        AimBoneTransform = EditorGUILayout.ObjectField(AimBoneTransform, typeof(Transform)) as Transform;
        if (AimBoneTransform != null)
        {
            if (GUILayout.Button("添加骨骼", GUILayout.Width(200)))
            {
                BoneAnimConfig boneAnimConfig = mCustomEditor.AddBoneAnim();
                boneAnimConfig.Bonetransform = AimBoneTransform;
                boneAnimConfig.BoneName = AimBoneTransform.name;
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(5);
        GUILayout.Label("动画->Key：", EditorStyles.boldLabel);

        for (int i = 0; i < mCustomEditor.AnimConfig.Count; ++i)
        {
            DrawAnim(i);
        }
        GUILayout.Space(5);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("保存骨骼动画Config", GUILayout.Width(200)))
        {
            mCustomEditor.saveAnimConfig();
        }
        if (GUILayout.Button("导入Config", GUILayout.Width(200)))
        {
        }
        GUILayout.EndHorizontal();
    }

    void DrawAnim(int index)
    {
        if (index < 0 || index >= mCustomEditor.AnimConfig.Count)
        {
            return;
        }
        GUILayout.Space(5);
        Transform BoneTransform = mCustomEditor.AnimConfig[index].Bonetransform;
        SerializedObject _serializedObject = new SerializedObject(mCustomEditor);
        SerializedProperty listIterator = _serializedObject.FindProperty("AnimConfig");

        EditorGUI.BeginChangeCheck();

        GUILayout.BeginHorizontal();
        mCustomEditor.AnimConfig[index].Bonetransform = EditorGUILayout.ObjectField(mCustomEditor.AnimConfig[index].Bonetransform, typeof(Transform)) as Transform;
        if (GUILayout.Button("Remove"))
        {
            EditorApplication.Beep();

            //// 可以很方便的显示一个包含特定按钮的对话框，例如是否同意删除
            if (EditorUtility.DisplayDialog("Really?", "Do you really want to remove the state '" + mCustomEditor.AnimConfig[index].Bonetransform + "'?", "Yes", "No") == true)
            {
                Undo.RecordObject(mCustomEditor, "Delete State");
                mCustomEditor.AnimConfig.RemoveAt(index);
                EditorUtility.SetDirty(mCustomEditor);
            }
        }
        if (BoneTransform)
        {
            if (GUILayout.Button("添加Key", GUILayout.Width(200)))
            {
                mBoneInfo BoneInfo = mCustomEditor.AddBoneAnimKey(index);
                if (BoneInfo != null)
                {
                    BoneInfo.vctPos = BoneTransform.localPosition;
                    BoneInfo.vctRot = BoneTransform.localEulerAngles;
                    BoneInfo.vctScl = BoneTransform.localScale;
                }
            }
        }
        GUILayout.EndHorizontal();

        SerializedProperty ControBoneLis = listIterator.GetArrayElementAtIndex(index).FindPropertyRelative("BoneAimLis");
        EditorGUILayout.PropertyField(ControBoneLis, true);

        if (EditorGUI.EndChangeCheck())
        {
            _serializedObject.ApplyModifiedProperties();
        }
    }
}

