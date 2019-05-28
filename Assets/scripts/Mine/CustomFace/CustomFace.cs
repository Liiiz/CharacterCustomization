using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CustomFace
{
    public ControConfig[] ControConfig;
    public BoneAnimConfig[] AnimConfig;


    private Dictionary<int, List<mCategoryInfo>> dictCategory;//操作杆对应N个模型骨骼ID
    private List<string> DstBoneNameList;
    protected Dictionary<string, mBoneInfo> dictDstBoneInfo; //模型骨骼
    private mAnimationKeyInfo anmKeyInfo = new mAnimationKeyInfo();//关键帧表 每个骨骼25个关键帧  及遥控杆的长度为0-24

    public Transform trfBone;
    private bool InitEnd = false;
    private bool IsChange = false;

    public void SetControConfig(List<ControConfig> ControConfig)
    {
        this.ControConfig = new ControConfig[ControConfig.Count];
        ControConfig.CopyTo(this.ControConfig);
    }
    public void SetAnimConfig(List<BoneAnimConfig> AnimConfig)
    {
        this.AnimConfig = new BoneAnimConfig[AnimConfig.Count];
        AnimConfig.CopyTo(this.AnimConfig);
    }
    public void Init()
    {
        InitEnd = false;
        InitShapeFace(trfBone);
        InitEnd = true;
    }
    public void Init(Transform trfBone)
    {
        InitEnd = false;
        InitShapeFace(trfBone);
        InitEnd = true;
    }
    private bool InitShapeFace(Transform trfBone)
    {
        if (null == trfBone)
        {
            return false;
        }
        dictCategory = new Dictionary<int, List<mCategoryInfo>>();
        dictDstBoneInfo = new Dictionary<string, mBoneInfo>();
        DstBoneNameList = new List<string>();
        InitShapeInfoBase(trfBone); //初始化最关键的一步

        //预制脸部信息导入
        //for (int i = 0; i < ControConfig.Length; i++)
        //{
        //    ChangeValue(i, 0.5f);
        //}
        return true;
    }
    private void InitShapeInfoBase(Transform trfBone)
    {
        anmKeyInfo.LoadInfo(AnimConfig);
        LoadCategoryInfoList();
        GetDstBoneInfo(trfBone, DstBoneNameList);
    }
    private bool LoadCategoryInfoList()
    {
        for (int i = 0; i < ControConfig.Length; i++)
        {
            List<mCategoryInfo> list = new List<mCategoryInfo>();
            for (int j = 0; j < ControConfig[i].ControBoneLis.Count; j++)
            {
                BoneControlConfig boneControlConfig = ControConfig[i].ControBoneLis[j];
                mCategoryInfo categoryInfo = new mCategoryInfo();
                categoryInfo.Initialize();
                categoryInfo.bonename = boneControlConfig.BoneName;

                categoryInfo.use[0][0] = (boneControlConfig.ControAble[0] && true);
                categoryInfo.use[0][1] = (boneControlConfig.ControAble[1] && true);
                categoryInfo.use[0][2] = (boneControlConfig.ControAble[2] && true);
                if (categoryInfo.use[0][0] || categoryInfo.use[0][1] || categoryInfo.use[0][2])
                {
                    categoryInfo.getflag[0] = true;
                }
                categoryInfo.use[1][0] = (boneControlConfig.ControAble[3] && true);
                categoryInfo.use[1][1] = (boneControlConfig.ControAble[4] && true);
                categoryInfo.use[1][2] = (boneControlConfig.ControAble[5] && true);
                if (categoryInfo.use[1][0] || categoryInfo.use[1][1] || categoryInfo.use[1][2])
                {
                    categoryInfo.getflag[1] = true;
                }
                categoryInfo.use[2][0] = (boneControlConfig.ControAble[6] && true);
                categoryInfo.use[2][1] = (boneControlConfig.ControAble[7] && true);
                categoryInfo.use[2][2] = (boneControlConfig.ControAble[8] && true);
                if (categoryInfo.use[2][0] || categoryInfo.use[2][1] || categoryInfo.use[2][2])
                {
                    categoryInfo.getflag[2] = true;
                }
                list.Add(categoryInfo);

                if (!DstBoneNameList.Contains(boneControlConfig.BoneName))
                {
                    DstBoneNameList.Add(boneControlConfig.BoneName);
                }
            }

            if (!dictCategory.ContainsKey(i))
            {
                dictCategory.Add(i, list);
            }
            else
            {
                dictCategory[i] = list;
            }
        }
        return true;
    }
    private bool GetDstBoneInfo(Transform trfBone, List<string> boneNames)
    {
        for (int i = 0; i < boneNames.Count; i++)
        {
            string bonename = boneNames[i];
            if (dictDstBoneInfo.ContainsKey(bonename)) continue;

            GameObject gameObject = trfBone.FindLoop(bonename);
            if ((UnityEngine.Object)null != (UnityEngine.Object)gameObject)
            {
                mBoneInfo boneInfo = new mBoneInfo();
                boneInfo.trfBone = gameObject.transform;
                boneInfo.vctPos = gameObject.transform.localPosition;
                boneInfo.vctRot = gameObject.transform.localEulerAngles;
                boneInfo.vctScl = gameObject.transform.localScale;
                dictDstBoneInfo[bonename] = boneInfo;
            }
        }
        return true;
    }
    //改变滑杆值
    public bool ChangeValue(int category, float value)
    {
        Debug.Log(category + " " + value);
        if (anmKeyInfo == null)
        {
            return false;
        }
        if (!dictCategory.ContainsKey(category))
        {
            return false;
        }
        int count = dictCategory[category].Count;
        string empty = string.Empty;
        for (int i = 0; i < count; i++)
        {
            List<mCategoryInfo> list = dictCategory[category];
            mBoneInfo boneInfo = null;
            empty = list[i].bonename;
            if (dictDstBoneInfo.TryGetValue(empty, out boneInfo))
            {
                Vector3[] array = new Vector3[3];
                for (int j = 0; j < 3; j++)
                {
                    array[j] = Vector3.zero;
                }
                bool[] array2 = new bool[3];
                for (int k = 0; k < 3; k++)
                {
                    array2[k] = list[i].getflag[k];
                }
                anmKeyInfo.GetInfo(empty, value, ref array, array2);
                if (list[i].use[0][0])
                {
                    boneInfo.vctPos.x = array[0].x;
                }
                if (list[i].use[0][1])
                {
                    boneInfo.vctPos.y = array[0].y;
                }
                if (list[i].use[0][2])
                {
                    boneInfo.vctPos.z = array[0].z;
                }
                if (list[i].use[1][0])
                {
                    boneInfo.vctRot.x = array[1].x;
                }
                if (list[i].use[1][1])
                {
                    boneInfo.vctRot.y = array[1].y;
                }
                if (list[i].use[1][2])
                {
                    boneInfo.vctRot.z = array[1].z;
                }
                if (list[i].use[2][0])
                {
                    boneInfo.vctScl.x = array[2].x;
                }
                if (list[i].use[2][1])
                {
                    boneInfo.vctScl.y = array[2].y;
                }
                if (list[i].use[2][2])
                {
                    boneInfo.vctScl.z = array[2].z;
                }
            }
        }
        IsChange = true;
        return true;
    }
    //模型刷新
    public void UpdateDstToScrBONE()
    {
        if (InitEnd && IsChange)
        {
            if (dictDstBoneInfo.Count != 0)
            {
                foreach (var item in dictDstBoneInfo)
                {
                    if (item.Value.trfBone.localPosition != item.Value.vctPos)
                        item.Value.trfBone.localPosition = item.Value.vctPos;
                    if (item.Value.trfBone.localEulerAngles != item.Value.vctRot)
                        item.Value.trfBone.localEulerAngles = item.Value.vctRot;
                    if (item.Value.trfBone.localScale != item.Value.vctScl)
                        item.Value.trfBone.localScale = item.Value.vctScl;
                }
            }
            IsChange = false;
        }
    }
}

[Serializable]
public class mBoneInfo
{
    [HideInInspector]
    public Transform trfBone;

    public Vector3 vctPos = Vector3.zero;

    public Vector3 vctRot = Vector3.zero;

    public Vector3 vctScl = Vector3.one;
}
public class mCategoryInfo
{
    public string bonename = string.Empty;

    public bool[][] use = new bool[3][];

    public bool[] getflag = new bool[3];

    public void Initialize()
    {
        for (int i = 0; i < 3; i++)
        {
            use[i] = new bool[3];
            getflag[i] = false;
        }
    }
}



public class mAnimationKeyInfo
{
    public class mAnmKeyInfo
    {
        public int no;

        public Vector3 pos = default(Vector3);

        public Vector3 rot = default(Vector3);

        public Vector3 scl = default(Vector3);

        public void Set(int _no, Vector3 _pos, Vector3 _rot, Vector3 _scl)
        {
            no = _no;
            pos = _pos;
            rot = _rot;
            scl = _scl;
        }

        public string GetInfoStr()
        {
            StringBuilder stringBuilder = new StringBuilder(128);
            stringBuilder.Append(no.ToString()).Append("\t");
            stringBuilder.Append(pos.ToString("f7")).Append("\t");
            stringBuilder.Append(rot.ToString("f7")).Append("\t");
            stringBuilder.Append(scl.ToString("f7"));
            return stringBuilder.ToString();
        }
    }

    private Dictionary<string, List<mAnmKeyInfo>> dictInfo = new Dictionary<string, List<mAnmKeyInfo>>();

    public bool GetInfo(string name, float rate, ref Vector3[] value, bool[] flag)
    {
        if (value.Length == 3 && flag.Length == 3)
        {
            List<mAnmKeyInfo> list = null;
            if (!dictInfo.TryGetValue(name, out list))
            {
                Debug.Log(name + "が見つからない");
                return false;
            }
            if (flag[0])
            {
                if (rate == 0f)
                {
                    value[0] = list[0].pos;
                }
                else if (rate == 1f)
                {
                    value[0] = list[list.Count - 1].pos;
                }
                else
                {
                    float num = (float)(list.Count - 1) * rate;
                    int num2 = Mathf.FloorToInt(num);
                    float t = num - (float)num2;
                    value[0] = Vector3.Lerp(list[num2].pos, list[num2 + 1].pos, t);
                }
            }
            if (flag[1])
            {
                if (rate == 0f)
                {
                    value[1] = list[0].rot;
                }
                else if (rate == 1f)
                {
                    value[1] = list[list.Count - 1].rot;
                }
                else
                {
                    float num3 = (float)(list.Count - 1) * rate;
                    int num4 = Mathf.FloorToInt(num3);
                    float t2 = num3 - (float)num4;
                    value[1].x = Mathf.LerpAngle(list[num4].rot.x, list[num4 + 1].rot.x, t2);
                    value[1].y = Mathf.LerpAngle(list[num4].rot.y, list[num4 + 1].rot.y, t2);
                    value[1].z = Mathf.LerpAngle(list[num4].rot.z, list[num4 + 1].rot.z, t2);
                }
            }
            if (flag[2])
            {
                if (rate == 0f)
                {
                    value[2] = list[0].scl;
                }
                else if (rate == 1f)
                {
                    value[2] = list[list.Count - 1].scl;
                }
                else
                {
                    float num5 = (float)(list.Count - 1) * rate;
                    int num6 = Mathf.FloorToInt(num5);
                    float t3 = num5 - (float)num6;
                    value[2] = Vector3.Lerp(list[num6].scl, list[num6 + 1].scl, t3);
                }
            }
            return true;
        }
        return false;
    }


    public void LoadInfo(BoneAnimConfig[] boneAnimConfig)
    {
        if (boneAnimConfig == null) return;
        dictInfo.Clear();
        for (int i = 0; i < boneAnimConfig.Length; i++)
        {
            List<mAnmKeyInfo> list = new List<mAnmKeyInfo>();
            for (int j = 0; j < boneAnimConfig[i].BoneAimLis.Count; j++)
            {
                mBoneInfo mBoneInfo = boneAnimConfig[i].BoneAimLis[j];
                mAnmKeyInfo mAnmKeyInfo = new mAnmKeyInfo();
                mAnmKeyInfo.Set(j, mBoneInfo.vctPos, mBoneInfo.vctRot, mBoneInfo.vctScl);
                list.Add(mAnmKeyInfo);
            }
            dictInfo[boneAnimConfig[i].BoneName] = list;
            Debug.Log("s");
        }
    }
  
}