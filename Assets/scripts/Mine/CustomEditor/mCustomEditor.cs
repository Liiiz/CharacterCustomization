using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
public class mCustomEditor : MonoBehaviour
{
    public List<ControConfig> ControConfig = new List<ControConfig>();
    public List<BoneAnimConfig> AnimConfig = new List<BoneAnimConfig>();


    //Control
    public ControConfig AddNewControl()
    {
        ControConfig controConfig = new ControConfig();
        ControConfig.Add(controConfig);
        return controConfig;
    }
    public void DeleteControl(int index)
    {
        if (ControConfig.Count > index)
            ControConfig.RemoveAt(index);
    }
    //Control-Bone
    public BoneControlConfig AddNewBone(int ControlIndex)
    {
        if (ControConfig.Count > ControlIndex)
        {
            BoneControlConfig boneControlConfig = new BoneControlConfig();
            ControConfig[ControlIndex].ControBoneLis.Add(boneControlConfig);
            return boneControlConfig;
        }
        return null;
    }
    void DeletBone(int ControlIndex, int index)
    {
        if (ControConfig.Count > ControlIndex)
        {
            if (ControConfig[ControlIndex].ControBoneLis.Count > index)
                ControConfig[ControlIndex].ControBoneLis.RemoveAt(index);
        }
    }
    //Anim
    public BoneAnimConfig AddBoneAnim()
    {
        BoneAnimConfig boneAnimConfig = new BoneAnimConfig();
        AnimConfig.Add(boneAnimConfig);
        return boneAnimConfig;
    }
    void DeletBoneAnim(int index)
    {
        if (AnimConfig.Count > index)
            AnimConfig.RemoveAt(index);
    }
    //Anim-Key
    public mBoneInfo AddBoneAnimKey(int Animindex)
    {
        if (AnimConfig.Count > Animindex)
        {
            mBoneInfo BoneAnimKeyConfig = new mBoneInfo();
            BoneAnimKeyConfig.trfBone = AnimConfig[Animindex].Bonetransform;
            AnimConfig[Animindex].BoneAimLis.Add(BoneAnimKeyConfig);
            return BoneAnimKeyConfig;
        }
        return null;
    }
    void SetBoneAnimKey(int Animindex, int index)
    {
        if (AnimConfig.Count > Animindex)
        {
            if (AnimConfig[Animindex].Bonetransform == null) return;
            if (AnimConfig[Animindex].BoneAimLis.Count <= index) return;
            mBoneInfo BoneAnimKeyConfig = AnimConfig[Animindex].BoneAimLis[index];
            BoneAnimKeyConfig.vctPos = BoneAnimKeyConfig.trfBone.localPosition;
            BoneAnimKeyConfig.vctRot = BoneAnimKeyConfig.trfBone.localEulerAngles;
            BoneAnimKeyConfig.vctScl = BoneAnimKeyConfig.trfBone.localScale;
        }

    }
    void DeletBoneAnimKey(int Animindex, int index)
    {
        if (AnimConfig.Count > Animindex)
        {
            if (AnimConfig[Animindex].BoneAimLis.Count > index)
            {
                AnimConfig[Animindex].BoneAimLis.RemoveAt(index);
            }
        }
    }


    public string outPutPath = "/Data/Scp/";                   //导出文件夹路径
    public string ControConfigFileName = "ControConfig01";     //导出文件名称
    public string AnimConfigFileName = "AnimConfig01 ";     //导出文件名称
    private string schemeExtension = ".txt";

    private StreamWriter streamWriter;                       //流写入
    StringBuilder sb_BoneControl;
    StringBuilder sb_BoneAnimControl;
    //Save
    public void saveControlConfig()
    {
        //sb_BoneControl = new StringBuilder();
        string Path = outPutPath + ControConfigFileName + schemeExtension;
        InitStreamWriter(Path);
        for (int i = 0; i < ControConfig.Count; i++)
        {
            if (ControConfig[i] == null) continue;
            if (ControConfig[i].ControBoneLis == null) continue;

            List<BoneControlConfig> ControBoneLis = ControConfig[i].ControBoneLis;
            for (int j = 0; j < ControBoneLis.Count; j++)
            {
                if (ControBoneLis[j] == null) continue;
                sb_BoneControl = new StringBuilder();
                sb_BoneControl.Append(ControConfig[i].ControName + '\t');
                sb_BoneControl.Append(ControBoneLis[j].Bonetransform.name + '\t');

                for (int k = 0; k < ControBoneLis[j].ControAble.Length; k++)
                {
                    int enable = ControBoneLis[j].ControAble[k] ? 1 : 0;
                    sb_BoneControl.Append(enable.ToString() + '\t');
                }
                //sb_BoneControl.Append('\n');
                streamWriter.WriteLine(sb_BoneControl.ToString());
            }
        }
        FlushStreamWriter();
        FreeStreamWriter();
    }
    public void saveAnimConfig()
    {
        // sb_BoneAnimControl = new StringBuilder();
        string Path = outPutPath + AnimConfigFileName + schemeExtension;
        InitStreamWriter(Path);

        List<Transform> Bones = new List<Transform>();
        for (int i = 0; i < AnimConfig.Count; i++)
        {
            if (AnimConfig[i].Bonetransform == null) continue;
            sb_BoneAnimControl = new StringBuilder();
            sb_BoneAnimControl.Append(AnimConfig[i].Bonetransform.name + '\t');
            List<mBoneInfo> BoneInfoLis = AnimConfig[i].BoneAimLis;
            for (int k = 0; k < BoneInfoLis.Count; k++)
            {
                sb_BoneAnimControl.Append(k.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctPos.x.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctPos.y.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctPos.z.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctRot.x.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctRot.y.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctRot.z.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctScl.x.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctScl.y.ToString() + '\t');
                sb_BoneAnimControl.Append(BoneInfoLis[k].vctScl.z.ToString() + '\t');
            }
            streamWriter.WriteLine(sb_BoneAnimControl.ToString());
        }
        FlushStreamWriter();
        FreeStreamWriter();
        Debug.Log(sb_BoneAnimControl);
    }

    private void InitStreamWriter(string path)                                 //创建StreamWriter
    {
        FreeStreamWriter();
        string strOutputPath = Application.dataPath + "/" + path;
        streamWriter = new StreamWriter(strOutputPath, false, new System.Text.UTF8Encoding(true));
    }
    private void FlushStreamWriter()                                          //使用StreamWriter写入
    {
        if (null != streamWriter)
        {
            streamWriter.Flush();
        }
    }
    private void FreeStreamWriter()                                           //释放StreamWriter
    {
        if (null != streamWriter)
        {
            streamWriter.Close();
            streamWriter = null;
        }
    }

    //Read
    public List<ControConfig> ReadControlConfig(string path)
    {
        List<ControConfig> list = new List<ControConfig>();
        string str = File.ReadAllText(path);
        string[,] array;
        GetControlStringArray(str, out array);

        string ControName = "";
        ControConfig controConfig = null;
        int length1 = array.GetLength(0);
        for (int i = 0; i < length1; i++)
        {
            string controName = array[i, 0];
            if (controName != ControName)
            {
                if (controConfig != null)
                    list.Add(controConfig);

                controConfig = new ControConfig();
                controConfig.ControName = controName;
                ControName = controName;
            }
            BoneControlConfig boneControlConfig = new BoneControlConfig();
            boneControlConfig.BoneName = array[i, 1];
            boneControlConfig.ControAble[0] = array[i, 2] == "1";
            boneControlConfig.ControAble[1] = array[i, 3] == "1";
            boneControlConfig.ControAble[2] = array[i, 4] == "1";
            boneControlConfig.ControAble[3] = array[i, 5] == "1";
            boneControlConfig.ControAble[4] = array[i, 6] == "1";
            boneControlConfig.ControAble[5] = array[i, 7] == "1";
            boneControlConfig.ControAble[6] = array[i, 8] == "1";
            boneControlConfig.ControAble[7] = array[i, 9] == "1";
            boneControlConfig.ControAble[8] = array[i, 10] == "1";
            controConfig.ControBoneLis.Add(boneControlConfig);

            if (i == length1 - 1)
            {
                list.Add(controConfig);
            }
        }
        return list;
    }
    public List<BoneAnimConfig> ReadAnimConfig(string path)
    {
        List<BoneAnimConfig> list = new List<BoneAnimConfig>();
        string  str = File.ReadAllText(path);
        string[][] array;
       GetAnimConfig(str, out array);

        for (int i = 0; i < array.Length; i++)
        {
            BoneAnimConfig AnimConfig = new BoneAnimConfig();
            AnimConfig.BoneName = array[i][0];
            mBoneInfo mBoneInfo = null;
            int index = 0;
            for (int j = 1; j < array[i].Length; j++)
            {
                switch (index)
                {
                    case 0: mBoneInfo = new mBoneInfo(); break;
                    case 1:
                        float.TryParse(array[i][j], out mBoneInfo.vctPos.x); break;
                    case 2:
                        float.TryParse(array[i][j], out mBoneInfo.vctPos.y); break;
                    case 3:
                        float.TryParse(array[i][j], out mBoneInfo.vctPos.z); break;
                    case 4:
                        float.TryParse(array[i][j], out mBoneInfo.vctRot.x); break;
                    case 5:
                        float.TryParse(array[i][j], out mBoneInfo.vctRot.y); break;
                    case 6:
                        float.TryParse(array[i][j], out mBoneInfo.vctRot.z); break;
                    case 7:
                        float.TryParse(array[i][j], out mBoneInfo.vctScl.x); break;
                    case 8:
                        float.TryParse(array[i][j], out mBoneInfo.vctScl.y); break;
                    case 9:
                        float.TryParse(array[i][j], out mBoneInfo.vctScl.z);
                        AnimConfig.BoneAimLis.Add(mBoneInfo);
                        index = -1;
                        break;
                    default:
                        break;
                }
                index++;
            }
            list.Add(AnimConfig); 
        }
        return list;
    }

    private void GetControlStringArray(string txt, out string[,] data)
    {
        string[] array = txt.Split('\n');
        int num = array.Length;
        if (num != 0)
            if (array[num - 1].Trim() == string.Empty)
                num--;

        string[] array2 = array[0].Split('\t');
        int num2 = array2.Length;
        if (num2 != 0)
            if (array2[num2 - 1].Trim() == string.Empty)
                num2--;

        data = new string[num, num2];

        for (int i = 0; i < num; i++)
        {
            string[] array3 = array[i].Split('\t');
            for (int j = 0; j < array3.Length && j < num2; j++)
            {
                string[,] obj = data;
                int num3 = i;
                int num4 = j;
                string obj2 = array3[j];
                obj[num3, num4] = obj2;
            }
            string[,] obj3 = data;
            int num5 = i;
            int num6 = num2 - 1;
            string text2 = data[i, num2 - 1].Replace("\r", string.Empty).Replace("\n", string.Empty);
            obj3[num5, num6] = text2;
        }
    }
    private void GetAnimConfig(string txt, out string[][] data)
    {
        string[] array = txt.Split('\n');
        int num = array.Length;
        if (num != 0)
            if (array[num - 1].Trim() == string.Empty)
                num--;

        data = new string[num][];

        for (int i = 0; i < num; i++)
        {
            string[] array2 = array[i].Split('\t');
            int num2 = array2.Length;
            if (num2 != 0)
                if (array2[num2 - 1].Trim() == string.Empty)
                    num2--;
            if (num2>0)
            {
                array2[num2 - 1] = array2[num2 - 1].Replace("\r", string.Empty).Replace("\n", string.Empty);
            }
            data[i] = new string[num2];
            Array.Copy(array2, data[i], num2);
        }
    }
}
[Serializable]
public class ControConfig
{
    public string ControName = "";
    public List<BoneControlConfig> ControBoneLis = new List<BoneControlConfig>();
}
[Serializable]
public class BoneControlConfig
{
    public Transform Bonetransform;
    [HideInInspector]
    public string BoneName = "";
    public bool[] ControAble = new bool[9];
}
[Serializable]
public class BoneAnimConfig
{
    public Transform Bonetransform;
    [HideInInspector]
    public string BoneName = "";
    public List<mBoneInfo> BoneAimLis = new List<mBoneInfo>();
}
