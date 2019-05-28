using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CustomFaceView))]
class CustomFaceViewEditor : Editor
{
    CustomFaceView customFaceView;
    public override void OnInspectorGUI()
    {
        //得到mCustomEditor对象
        customFaceView = (CustomFaceView)target;

        DrawDefaultInspector();
        //if (!Application.isPlaying) return;
        if (GUILayout.Button("读取控制杆配置"))
        {
            customFaceView.ReadControlConfig();
        }

        if (GUILayout.Button("读取骨骼动画配置"))
        {
            customFaceView.ReadAnimConfig();

        }
        if (GUILayout.Button("CutomFace初始化"))
        {
            customFaceView.InitCustomFace();
        }
    }
}
