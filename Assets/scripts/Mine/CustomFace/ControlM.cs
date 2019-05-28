using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ControlM : MonoBehaviour
{
    public readonly string[] cf_headshapename = new string[67]
{
    "顔全体横幅",
    "顔上部前後",
    "顔上部上下",
    "顔下部前後",
    "顔下部横幅",
    "顎横幅",
    "顎上下",
    "顎前後",
    "顎角度",
    "顎下部上下",
    "顎先幅",
    "顎先上下",
    "顎先前後",
    "頬下部上下",
    "頬下部前後",
    "頬下部幅",
    "頬上部上下",
    "頬上部前後",
    "頬上部幅",
    "眉毛上下",
    "眉毛横位置",
    "眉毛角度Z軸",
    "眉毛内側形状",
    "眉毛外側形状",
    "目上下",
    "目横位置",
    "目前後",
    "目の横幅",
    "目の縦幅",
    "目の角度Z軸",
    "目の角度Y軸",
    "目頭左右位置",
    "目尻左右位置",
    "目頭上下位置",
    "目尻上下位置",
    "まぶた形状１",
    "まぶた形状２",
    "瞳の上下調整",
    "瞳の横幅",
    "瞳の縦幅",
    "鼻全体上下",
    "鼻全体前後",
    "鼻全体角度X軸",
    "鼻全体横幅",
    "鼻筋高さ",
    "鼻筋横幅",
    "鼻筋形状",
    "小鼻横幅",
    "小鼻上下",
    "小鼻前後",
    "小鼻角度X軸",
    "小鼻角度Z軸",
    "鼻先高さ",
    "鼻先角度X軸",
    "鼻先サイズ",
    "口上下",
    "口横幅",
    "口縦幅",
    "口角度X軸",
    "口形状上",
    "口形状下",
    "口形状口角",
    "耳サイズ",
    "耳角度Y軸",
    "耳角度Z軸",
    "耳上部形状",
    "耳下部形状"
};
    public enum DstBoneName
    {
        cf_J_CheekLow_L,
        cf_J_CheekLow_R,
        cf_J_CheekUp_L,
        cf_J_CheekUp_R,
        cf_J_Chin_rs,
        cf_J_ChinLow,
        cf_J_ChinTip_s,
        cf_J_EarBase_s_L,
        cf_J_EarBase_s_R,
        cf_J_EarLow_L,
        cf_J_EarLow_R,
        cf_J_EarRing_L,
        cf_J_EarRing_R,
        cf_J_EarUp_L,
        cf_J_EarUp_R,
        cf_J_Eye_r_L,
        cf_J_Eye_r_R,
        cf_J_eye_rs_L,
        cf_J_eye_rs_R,
        cf_J_Eye_s_L,
        cf_J_Eye_s_R,
        cf_J_Eye_t_L,
        cf_J_Eye_t_R,
        cf_J_Eye01_L,
        cf_J_Eye01_R,
        cf_J_Eye02_L,
        cf_J_Eye02_R,
        cf_J_Eye03_L,
        cf_J_Eye03_R,
        cf_J_Eye04_L,
        cf_J_Eye04_R,
        cf_J_EyePos_rz_L,
        cf_J_EyePos_rz_R,
        cf_J_FaceBase,
        cf_J_FaceLow_s,
        cf_J_FaceLowBase,
        cf_J_FaceUp_ty,
        cf_J_FaceUp_tz,
        cf_J_Mayu_L,
        cf_J_Mayu_R,
        cf_J_MayuMid_s_L,
        cf_J_MayuMid_s_R,
        cf_J_MayuTip_s_L,
        cf_J_MayuTip_s_R,
        cf_J_megane,
        cf_J_Mouth_L,
        cf_J_Mouth_R,
        cf_J_MouthLow,
        cf_J_Mouthup,
        cf_J_MouthBase_s,
        cf_J_MouthBase_tr,
        cf_J_Nose_t,
        cf_J_Nose_tip,
        cf_J_NoseBase_s,
        cf_J_NoseBase_trs,
        cf_J_NoseBridge_s,
        cf_J_NoseBridge_t,
        cf_J_NoseWing_tx_L,
        cf_J_NoseWing_tx_R,
        cf_J_pupil_s_L,
        cf_J_pupil_s_R,
        cf_J_MouthCavity
    }
    public enum SrcBoneName
    {
        cf_s_CheekLow_tx_L,
        cf_s_CheekLow_tx_R,
        cf_s_CheekLow_ty,
        cf_s_CheekLow_tz,
        cf_s_CheekUp_tx_L,
        cf_s_CheekUp_tx_R,
        cf_s_CheekUp_ty,
        cf_s_CheekUp_tz_00,
        cf_s_CheekUp_tz_01,
        cf_s_Chin_rx,
        cf_s_Chin_sx,
        cf_s_Chin_ty,
        cf_s_Chin_tz,
        cf_s_ChinLow,
        cf_s_ChinTip_sx,
        cf_s_ChinTip_ty,
        cf_s_ChinTip_tz,
        cf_s_EarBase_ry_L,
        cf_s_EarBase_ry_R,
        cf_s_EarBase_rz_L,
        cf_s_EarBase_rz_R,
        cf_s_EarBase_s_L,
        cf_s_EarBase_s_R,
        cf_s_EarLow_L,
        cf_s_EarLow_R,
        cf_s_EarRing_L,
        cf_s_EarRing_R,
        cf_s_EarRing_rz_L,
        cf_s_EarRing_rz_R,
        cf_s_EarRing_s_L,
        cf_s_EarRing_s_R,
        cf_s_EarUp_L,
        cf_s_EarUp_R,
        cf_s_Eye_ry_L,
        cf_s_Eye_ry_R,
        cf_s_Eye_rz_L,
        cf_s_Eye_rz_R,
        cf_s_Eye_sx_L,
        cf_s_Eye_sx_R,
        cf_s_Eye_sy_L,
        cf_s_Eye_sy_R,
        cf_s_Eye_tx_L,
        cf_s_Eye_tx_R,
        cf_s_Eye_ty,
        cf_s_Eye_tz,
        cf_s_Eye01_L,
        cf_s_Eye01_R,
        cf_s_Eye01_rx_L,
        cf_s_Eye01_rx_R,
        cf_s_Eye02_L,
        cf_s_Eye02_R,
        cf_s_Eye02_ry_L,
        cf_s_Eye02_ry_R,
        cf_s_Eye03_L,
        cf_s_Eye03_R,
        cf_s_Eye03_rx_L,
        cf_s_Eye03_rx_R,
        cf_s_Eye04_L,
        cf_s_Eye04_R,
        cf_s_Eye04_ry_L,
        cf_s_Eye04_ry_R,
        cf_s_EyePos_L,
        cf_s_EyePos_R,
        cf_s_EyePos_rz_L,
        cf_s_EyePos_rz_R,
        cf_s_FaceBase_sx,
        cf_s_FaceLow_sx,
        cf_s_FaceLow_tz,
        cf_s_FaceUp_ty,
        cf_s_FaceUp_tz,
        cf_s_Mayu_L,
        cf_s_Mayu_R,
        cf_s_Mayu_tx_L,
        cf_s_Mayu_tx_R,
        cf_s_Mayu_ty,
        cf_s_Mayu02_L,
        cf_s_Mayu02_R,
        cf_s_MayuMid_s_L,
        cf_s_MayuMid_s_R,
        cf_s_MayuTip_s_L,
        cf_s_MayuTip_s_R,
        cf_s_megane_rx_nosebridge,
        cf_s_megane_ty_eye,
        cf_s_megane_ty_nose,
        cf_s_megane_tz_nosebridge,
        cf_s_MouthBase_tz,
        cf_s_Mouthup,
        cf_s_Mouth_L,
        cf_s_Mouth_R,
        cf_s_MouthBase_sx,
        cf_s_MouthBase_sy,
        cf_s_MouthBase_ty,
        cf_s_MouthLow,
        cf_s_Nose_rx,
        cf_s_Nose_tip,
        cf_s_Nose_tz,
        cf_s_NoseBase,
        cf_s_NoseBase_rx,
        cf_s_NoseBase_sx,
        cf_s_NoseBase_ty,
        cf_s_NoseBase_tz,
        cf_s_NoseBridge_rx,
        cf_s_NoseBridge_sx,
        cf_s_NoseBridge_ty,
        cf_s_NoseBridge_tz_00,
        cf_s_NoseBridge_tz_01,
        cf_s_NoseWing_rx,
        cf_s_NoseWing_rz_L,
        cf_s_NoseWing_rz_R,
        cf_s_NoseWing_tx_L,
        cf_s_NoseWing_tx_R,
        cf_s_NoseWing_ty,
        cf_s_NoseWing_tz,
        cf_s_pupil_ssx_L,
        cf_s_pupil_ssx_R,
        cf_s_pupil_ssy_L,
        cf_s_pupil_ssy_R,
        cf_s_pupil_sx_L,
        cf_s_pupil_sx_R,
        cf_s_pupil_sy_L,
        cf_s_pupil_sy_R,
        cf_s_MouthC_ty,
        cf_s_MouthC_tz,
        cf_s_MayuMid_ftz,
        cf_s_MayuMid_ntz,
        cf_s_MayuMidre_tz,
        cf_s_MayuTip_esx
    }

    private Dictionary<int, List<CategoryInfo>> dictCategory;//操作杆对应N个模型骨骼ID

    protected Dictionary<int, BoneInfo> dictDstBoneInfo; //模型骨骼

    protected Dictionary<int, BoneInfo> dictSrcBoneInfo; //操作杆抽象骨骼

    private AnimationKeyInfo anmKeyInfo = new AnimationKeyInfo();//关键帧表 每个骨骼25个关键帧  及遥控杆的长度为0-24

    public Transform trfBone;
    private bool InitEnd = false;
    private bool IsChange = false;
    private void Start()
    {
        InitEnd = false;
        InitShapeFace(trfBone);
        InitSlider();
        InitEnd = true;
    }

    private bool InitShapeFace(Transform trfBone)
    {
        if ((UnityEngine.Object)null == (UnityEngine.Object)trfBone)
        {
            return false;
        }
        dictCategory = new Dictionary<int, List<CategoryInfo>>();
        dictDstBoneInfo = new Dictionary<int, BoneInfo>();
        dictSrcBoneInfo = new Dictionary<int, BoneInfo>();

        InitShapeInfo(/* "list/customshape.unity3d", assetAnmShapeFace, cateInfoName,*/ trfBone); //初始化最关键的一步

        //return true;
        //预制脸部信息导入
        for (int i = 0; i < cf_headshapename.Length; i++)
        {
            //ChangeValue(i, PresetFaceValue[i]);
            ChangeValue(i, 0.5f);
            if (i< Sliders.Count)
            {
                Sliders[i].GetComponent<Slider>().value = 0.5f;
            }
        }
        return true;
    }
    private void InitShapeInfo(Transform trfObj)
    {
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        DstBoneName[] array = (DstBoneName[])Enum.GetValues(typeof(DstBoneName));
        DstBoneName[] array2 = array;
        foreach (DstBoneName dstBoneName in array2)
        {
            dictionary[dstBoneName.ToString()] = (int)dstBoneName;
        }
        Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
        SrcBoneName[] array3 = (SrcBoneName[])Enum.GetValues(typeof(SrcBoneName));
        SrcBoneName[] array4 = array3;
        foreach (SrcBoneName srcBoneName in array4)
        {
            dictionary2[srcBoneName.ToString()] = (int)srcBoneName;
        }
        InitShapeInfoBase(trfObj, dictionary, dictionary2);
    }
    private void InitShapeInfoBase(Transform trfObj, Dictionary<string, int> dictEnumDst, Dictionary<string, int> dictEnumSrc)
    {

        anmKeyInfo.LoadInfo("cf_anmShapeHead1");
        LoadCategoryInfoList(  dictEnumSrc);
        GetDstBoneInfo(trfObj, dictEnumDst);
        GetSrcBoneInfo();
    }


    private bool LoadCategoryInfoList( Dictionary<string, int> dictEnumSrc)
    {
        TextAsset textAsset = Resources.Load<TextAsset>("cf_customhead");
        string[,] array;
        GetListString(textAsset.text, out array);
        int length = array.GetLength(0);
        int length2 = array.GetLength(1);
        dictCategory.Clear();
        if (length != 0 && length2 != 0)
        {
            int num = 0;
            for (int i = 0; i < length; i++)
            {
                CategoryInfo categoryInfo = new CategoryInfo();
                categoryInfo.Initialize();
                num = int.Parse(array[i, 0]);
                categoryInfo.name = array[i, 1];
                int id = 0;
                if (!dictEnumSrc.TryGetValue(categoryInfo.name, out id))
                {
                    string message3 = "SrcBone【" + categoryInfo.name + "】のIDが見つかりません";
                    Debug.LogWarning(message3);
                }
                else
                {
                    categoryInfo.id = id;
                    categoryInfo.use[0][0] = (!(array[i, 2] == "0") && true);
                    categoryInfo.use[0][1] = (!(array[i, 3] == "0") && true);
                    categoryInfo.use[0][2] = (!(array[i, 4] == "0") && true);
                    if (categoryInfo.use[0][0] || categoryInfo.use[0][1] || categoryInfo.use[0][2])
                    {
                        categoryInfo.getflag[0] = true;
                    }
                    categoryInfo.use[1][0] = (!(array[i, 5] == "0") && true);
                    categoryInfo.use[1][1] = (!(array[i, 6] == "0") && true);
                    categoryInfo.use[1][2] = (!(array[i, 7] == "0") && true);
                    if (categoryInfo.use[1][0] || categoryInfo.use[1][1] || categoryInfo.use[1][2])
                    {
                        categoryInfo.getflag[1] = true;
                    }
                    categoryInfo.use[2][0] = (!(array[i, 8] == "0") && true);
                    categoryInfo.use[2][1] = (!(array[i, 9] == "0") && true);
                    categoryInfo.use[2][2] = (!(array[i, 10] == "0") && true);
                    if (categoryInfo.use[2][0] || categoryInfo.use[2][1] || categoryInfo.use[2][2])
                    {
                        categoryInfo.getflag[2] = true;
                    }
                    List<CategoryInfo> list = null;
                    if (!dictCategory.TryGetValue(num, out list))
                    {
                        list = new List<CategoryInfo>();
                        dictCategory[num] = list;
                    }
                    list.Add(categoryInfo);
                }
            }
        }
        // AssetBundleManager.UnloadAssetBundle(assetBundleName, true, null);
        return true;
    }

    private bool GetDstBoneInfo(Transform trfBone, Dictionary<string, int> dictEnumDst)
    {
        dictDstBoneInfo.Clear();
        foreach (KeyValuePair<string, int> item in dictEnumDst)
        {
            GameObject gameObject = trfBone.FindLoop(item.Key);
            if ((UnityEngine.Object)null != (UnityEngine.Object)gameObject)
            {
                BoneInfo boneInfo = new BoneInfo();
                boneInfo.trfBone = gameObject.transform;
                dictDstBoneInfo[item.Value] = boneInfo;
            }
        }
        return true;
    }

    private void GetSrcBoneInfo()
    {
        dictSrcBoneInfo.Clear();
        foreach (KeyValuePair<int, List<CategoryInfo>> item in dictCategory)
        {
            int count = item.Value.Count;
            for (int i = 0; i < count; i++)
            {
                BoneInfo value = null;
                if (!dictSrcBoneInfo.TryGetValue(item.Value[i].id, out value))
                {
                    value = new BoneInfo();
                    dictSrcBoneInfo[item.Value[i].id] = value;
                }
            }
        }
    }
    //模型刷新
    public void UpdateDstToScrBONE()
    {
        if (InitEnd && dictSrcBoneInfo.Count != 0)
        {
            dictDstBoneInfo[61].trfBone.SetLocalPositionY(dictSrcBoneInfo[121].vctPos.y);
            dictDstBoneInfo[61].trfBone.SetLocalPositionZ(dictSrcBoneInfo[122].vctPos.z + dictSrcBoneInfo[121].vctPos.z);
            dictDstBoneInfo[38].trfBone.SetLocalPositionX(dictSrcBoneInfo[72].vctPos.x);
            dictDstBoneInfo[38].trfBone.SetLocalPositionY(dictSrcBoneInfo[74].vctPos.y);
            dictDstBoneInfo[38].trfBone.SetLocalPositionZ(dictSrcBoneInfo[74].vctPos.z + dictSrcBoneInfo[70].vctPos.z + dictSrcBoneInfo[72].vctPos.z + dictSrcBoneInfo[75].vctPos.z);
            dictDstBoneInfo[38].trfBone.SetLocalRotation(dictSrcBoneInfo[74].vctRot.x + dictSrcBoneInfo[70].vctRot.x + dictSrcBoneInfo[75].vctRot.x, dictSrcBoneInfo[70].vctRot.y + dictSrcBoneInfo[72].vctRot.y, dictSrcBoneInfo[70].vctRot.z);
            dictDstBoneInfo[39].trfBone.SetLocalPositionX(dictSrcBoneInfo[73].vctPos.x);
            dictDstBoneInfo[39].trfBone.SetLocalPositionY(dictSrcBoneInfo[74].vctPos.y);
            dictDstBoneInfo[39].trfBone.SetLocalPositionZ(dictSrcBoneInfo[74].vctPos.z + dictSrcBoneInfo[71].vctPos.z + dictSrcBoneInfo[73].vctPos.z + dictSrcBoneInfo[76].vctPos.z);
            dictDstBoneInfo[39].trfBone.SetLocalRotation(dictSrcBoneInfo[74].vctRot.x + dictSrcBoneInfo[71].vctRot.x + dictSrcBoneInfo[76].vctRot.x, dictSrcBoneInfo[71].vctRot.y + dictSrcBoneInfo[73].vctRot.y, dictSrcBoneInfo[71].vctRot.z);
            dictDstBoneInfo[40].trfBone.SetLocalPositionY(dictSrcBoneInfo[77].vctPos.y);
            dictDstBoneInfo[40].trfBone.SetLocalPositionZ(dictSrcBoneInfo[77].vctPos.z + dictSrcBoneInfo[123].vctPos.z + dictSrcBoneInfo[124].vctPos.z + dictSrcBoneInfo[125].vctPos.z);
            dictDstBoneInfo[40].trfBone.SetLocalRotation(dictSrcBoneInfo[77].vctRot.x + dictSrcBoneInfo[123].vctRot.x + dictSrcBoneInfo[124].vctRot.x + dictSrcBoneInfo[125].vctRot.x, dictSrcBoneInfo[77].vctRot.y + dictSrcBoneInfo[125].vctRot.y, dictSrcBoneInfo[77].vctRot.z);
            dictDstBoneInfo[41].trfBone.SetLocalPositionY(dictSrcBoneInfo[78].vctPos.y);
            dictDstBoneInfo[41].trfBone.SetLocalPositionZ(dictSrcBoneInfo[78].vctPos.z + dictSrcBoneInfo[123].vctPos.z + dictSrcBoneInfo[124].vctPos.z + dictSrcBoneInfo[125].vctPos.z);
            dictDstBoneInfo[41].trfBone.SetLocalRotation(dictSrcBoneInfo[78].vctRot.x + dictSrcBoneInfo[123].vctRot.x + dictSrcBoneInfo[124].vctRot.x + dictSrcBoneInfo[125].vctRot.x, dictSrcBoneInfo[78].vctRot.y - dictSrcBoneInfo[125].vctRot.y, dictSrcBoneInfo[78].vctRot.z);
            dictDstBoneInfo[42].trfBone.SetLocalPositionY(dictSrcBoneInfo[79].vctPos.y);
            dictDstBoneInfo[42].trfBone.SetLocalPositionZ(dictSrcBoneInfo[79].vctPos.z + dictSrcBoneInfo[126].vctPos.z);
            dictDstBoneInfo[42].trfBone.SetLocalRotation(dictSrcBoneInfo[79].vctRot.x + dictSrcBoneInfo[126].vctRot.x, dictSrcBoneInfo[79].vctRot.y, dictSrcBoneInfo[79].vctRot.z);
            dictDstBoneInfo[43].trfBone.SetLocalPositionY(dictSrcBoneInfo[80].vctPos.y);
            dictDstBoneInfo[43].trfBone.SetLocalPositionZ(dictSrcBoneInfo[80].vctPos.z + dictSrcBoneInfo[126].vctPos.z);
            dictDstBoneInfo[43].trfBone.SetLocalRotation(dictSrcBoneInfo[80].vctRot.x + dictSrcBoneInfo[126].vctRot.x, dictSrcBoneInfo[80].vctRot.y, dictSrcBoneInfo[80].vctRot.z);
            dictDstBoneInfo[21].trfBone.SetLocalPositionX(dictSrcBoneInfo[41].vctPos.x);
            dictDstBoneInfo[21].trfBone.SetLocalPositionY(dictSrcBoneInfo[43].vctPos.y);
            dictDstBoneInfo[21].trfBone.SetLocalPositionZ(dictSrcBoneInfo[44].vctPos.z);
            dictDstBoneInfo[21].trfBone.SetLocalRotation(0f, 0f, dictSrcBoneInfo[35].vctRot.z);
            dictDstBoneInfo[22].trfBone.SetLocalPositionX(dictSrcBoneInfo[42].vctPos.x);
            dictDstBoneInfo[22].trfBone.SetLocalPositionY(dictSrcBoneInfo[43].vctPos.y);
            dictDstBoneInfo[22].trfBone.SetLocalPositionZ(dictSrcBoneInfo[44].vctPos.z);
            dictDstBoneInfo[22].trfBone.SetLocalRotation(0f, 0f, dictSrcBoneInfo[36].vctRot.z);
            dictDstBoneInfo[19].trfBone.SetLocalScale(dictSrcBoneInfo[37].vctScl.x, dictSrcBoneInfo[39].vctScl.y, 1f);
            dictDstBoneInfo[15].trfBone.SetLocalRotation(0f, dictSrcBoneInfo[33].vctRot.y, 0f);
            dictDstBoneInfo[20].trfBone.SetLocalScale(dictSrcBoneInfo[38].vctScl.x, dictSrcBoneInfo[40].vctScl.y, 1f);
            dictDstBoneInfo[16].trfBone.SetLocalRotation(0f, dictSrcBoneInfo[34].vctRot.y, 0f);
            dictDstBoneInfo[23].trfBone.SetLocalRotation(dictSrcBoneInfo[47].vctRot.x, dictSrcBoneInfo[45].vctRot.y + dictSrcBoneInfo[47].vctRot.y, 0f);
            dictDstBoneInfo[25].trfBone.SetLocalRotation(dictSrcBoneInfo[49].vctRot.x, dictSrcBoneInfo[51].vctRot.y, dictSrcBoneInfo[51].vctRot.z);
            dictDstBoneInfo[27].trfBone.SetLocalPositionX(dictSrcBoneInfo[53].vctPos.x);
            dictDstBoneInfo[27].trfBone.SetLocalRotation(dictSrcBoneInfo[55].vctRot.x, dictSrcBoneInfo[53].vctRot.y, 0f);
            dictDstBoneInfo[29].trfBone.SetLocalRotation(dictSrcBoneInfo[57].vctRot.x, dictSrcBoneInfo[59].vctRot.y, dictSrcBoneInfo[59].vctRot.z);
            dictDstBoneInfo[24].trfBone.SetLocalRotation(dictSrcBoneInfo[48].vctRot.x, dictSrcBoneInfo[46].vctRot.y + dictSrcBoneInfo[48].vctRot.y, 0f);
            dictDstBoneInfo[26].trfBone.SetLocalRotation(dictSrcBoneInfo[50].vctRot.x, dictSrcBoneInfo[52].vctRot.y, dictSrcBoneInfo[52].vctRot.z);
            dictDstBoneInfo[28].trfBone.SetLocalPositionX(dictSrcBoneInfo[54].vctPos.x);
            dictDstBoneInfo[28].trfBone.SetLocalRotation(dictSrcBoneInfo[56].vctRot.x, dictSrcBoneInfo[54].vctRot.y, 0f);
            dictDstBoneInfo[30].trfBone.SetLocalRotation(dictSrcBoneInfo[58].vctRot.x, dictSrcBoneInfo[60].vctRot.y, dictSrcBoneInfo[60].vctRot.z);
            dictDstBoneInfo[31].trfBone.SetLocalRotation(0f, 0f, dictSrcBoneInfo[63].vctRot.z);
            dictDstBoneInfo[17].trfBone.SetLocalRotation(dictSrcBoneInfo[61].vctRot.x, 0f, 0f);
            dictDstBoneInfo[32].trfBone.SetLocalRotation(0f, 0f, dictSrcBoneInfo[64].vctRot.z);
            dictDstBoneInfo[18].trfBone.SetLocalRotation(dictSrcBoneInfo[62].vctRot.x, 0f, 0f);
            dictDstBoneInfo[59].trfBone.SetLocalPositionY(dictSrcBoneInfo[119].vctPos.y);
            dictDstBoneInfo[59].trfBone.SetLocalPositionZ(dictSrcBoneInfo[113].vctPos.z + dictSrcBoneInfo[115].vctPos.z + dictSrcBoneInfo[117].vctPos.z + dictSrcBoneInfo[119].vctPos.z);
            dictDstBoneInfo[59].trfBone.SetLocalScale(dictSrcBoneInfo[113].vctScl.x * dictSrcBoneInfo[115].vctScl.x * dictSrcBoneInfo[117].vctScl.x, dictSrcBoneInfo[113].vctScl.y * dictSrcBoneInfo[115].vctScl.y * dictSrcBoneInfo[119].vctScl.y, dictSrcBoneInfo[117].vctScl.z * dictSrcBoneInfo[119].vctScl.z);
            dictDstBoneInfo[60].trfBone.SetLocalPositionY(dictSrcBoneInfo[120].vctPos.y);
            dictDstBoneInfo[60].trfBone.SetLocalPositionZ(dictSrcBoneInfo[114].vctPos.z + dictSrcBoneInfo[116].vctPos.z + dictSrcBoneInfo[118].vctPos.z + dictSrcBoneInfo[120].vctPos.z);
            dictDstBoneInfo[60].trfBone.SetLocalScale(dictSrcBoneInfo[114].vctScl.x * dictSrcBoneInfo[116].vctScl.x * dictSrcBoneInfo[118].vctScl.x, dictSrcBoneInfo[114].vctScl.y * dictSrcBoneInfo[116].vctScl.y * dictSrcBoneInfo[120].vctScl.y, dictSrcBoneInfo[118].vctScl.z * dictSrcBoneInfo[120].vctScl.z);
            dictDstBoneInfo[33].trfBone.SetLocalScale(dictSrcBoneInfo[65].vctScl.x, 1f, 1f);
            dictDstBoneInfo[36].trfBone.SetLocalPositionY(dictSrcBoneInfo[68].vctPos.y);
            dictDstBoneInfo[37].trfBone.SetLocalPositionZ(dictSrcBoneInfo[69].vctPos.z);
            dictDstBoneInfo[2].trfBone.SetLocalPositionX(dictSrcBoneInfo[4].vctPos.x);
            dictDstBoneInfo[2].trfBone.SetLocalPositionY(dictSrcBoneInfo[6].vctPos.y);
            dictDstBoneInfo[2].trfBone.SetLocalPositionZ(dictSrcBoneInfo[7].vctPos.z + dictSrcBoneInfo[8].vctPos.z);
            dictDstBoneInfo[3].trfBone.SetLocalPositionX(dictSrcBoneInfo[5].vctPos.x);
            dictDstBoneInfo[3].trfBone.SetLocalPositionY(dictSrcBoneInfo[6].vctPos.y);
            dictDstBoneInfo[3].trfBone.SetLocalPositionZ(dictSrcBoneInfo[7].vctPos.z + dictSrcBoneInfo[8].vctPos.z);
            dictDstBoneInfo[0].trfBone.SetLocalPositionX(dictSrcBoneInfo[0].vctPos.x);
            dictDstBoneInfo[0].trfBone.SetLocalPositionY(dictSrcBoneInfo[2].vctPos.y);
            dictDstBoneInfo[0].trfBone.SetLocalPositionZ(dictSrcBoneInfo[3].vctPos.z);
            dictDstBoneInfo[1].trfBone.SetLocalPositionX(dictSrcBoneInfo[1].vctPos.x);
            dictDstBoneInfo[1].trfBone.SetLocalPositionY(dictSrcBoneInfo[2].vctPos.y);
            dictDstBoneInfo[1].trfBone.SetLocalPositionZ(dictSrcBoneInfo[3].vctPos.z);
            dictDstBoneInfo[35].trfBone.SetLocalPositionZ(dictSrcBoneInfo[67].vctPos.z);
            dictDstBoneInfo[34].trfBone.SetLocalScale(dictSrcBoneInfo[66].vctScl.x, 1f, 1f);
            dictDstBoneInfo[50].trfBone.SetLocalPositionY(dictSrcBoneInfo[91].vctPos.y);
            dictDstBoneInfo[50].trfBone.SetLocalPositionZ(dictSrcBoneInfo[91].vctPos.z + dictSrcBoneInfo[85].vctPos.z);
            dictDstBoneInfo[49].trfBone.SetLocalScale(dictSrcBoneInfo[89].vctScl.x, dictSrcBoneInfo[90].vctScl.y, 1f);
            dictDstBoneInfo[48].trfBone.SetLocalPositionY(dictSrcBoneInfo[86].vctPos.y);
            dictDstBoneInfo[47].trfBone.SetLocalPositionY(dictSrcBoneInfo[92].vctPos.y);
            dictDstBoneInfo[47].trfBone.SetLocalPositionZ(dictSrcBoneInfo[92].vctPos.z);
            dictDstBoneInfo[47].trfBone.SetLocalScale(dictSrcBoneInfo[92].vctScl.x, 1f, 1f);
            dictDstBoneInfo[45].trfBone.SetLocalPositionY(dictSrcBoneInfo[87].vctPos.y);
            dictDstBoneInfo[45].trfBone.SetLocalRotation(0f, 0f, dictSrcBoneInfo[87].vctRot.z);
            dictDstBoneInfo[46].trfBone.SetLocalPositionY(dictSrcBoneInfo[88].vctPos.y);
            dictDstBoneInfo[46].trfBone.SetLocalRotation(0f, 0f, dictSrcBoneInfo[88].vctRot.z);
            dictDstBoneInfo[5].trfBone.SetLocalPositionY(dictSrcBoneInfo[13].vctPos.y);
            dictDstBoneInfo[4].trfBone.SetLocalPositionY(dictSrcBoneInfo[11].vctPos.y + dictSrcBoneInfo[9].vctPos.y);
            dictDstBoneInfo[4].trfBone.SetLocalPositionZ(dictSrcBoneInfo[12].vctPos.z + dictSrcBoneInfo[9].vctPos.z);
            dictDstBoneInfo[4].trfBone.SetLocalRotation(dictSrcBoneInfo[9].vctRot.x, 0f, 0f);
            dictDstBoneInfo[4].trfBone.SetLocalScale(dictSrcBoneInfo[10].vctScl.x, 1f, 1f);
            dictDstBoneInfo[6].trfBone.SetLocalPositionY(dictSrcBoneInfo[15].vctPos.y);
            dictDstBoneInfo[6].trfBone.SetLocalPositionZ(dictSrcBoneInfo[16].vctPos.z);
            dictDstBoneInfo[6].trfBone.SetLocalScale(dictSrcBoneInfo[14].vctScl.x, dictSrcBoneInfo[14].vctScl.y, dictSrcBoneInfo[14].vctScl.z);
            dictDstBoneInfo[56].trfBone.SetLocalPositionY(dictSrcBoneInfo[103].vctPos.y);
            dictDstBoneInfo[56].trfBone.SetLocalPositionZ(dictSrcBoneInfo[104].vctPos.z + dictSrcBoneInfo[105].vctPos.z + dictSrcBoneInfo[103].vctPos.z + dictSrcBoneInfo[101].vctPos.z);
            dictDstBoneInfo[56].trfBone.SetLocalRotation(dictSrcBoneInfo[101].vctRot.x, 0f, 0f);
            dictDstBoneInfo[55].trfBone.SetLocalScale(dictSrcBoneInfo[102].vctScl.x, 1f, 1f);
            dictDstBoneInfo[54].trfBone.SetLocalPositionY(dictSrcBoneInfo[97].vctPos.y + dictSrcBoneInfo[99].vctPos.y + dictSrcBoneInfo[96].vctPos.y);
            dictDstBoneInfo[54].trfBone.SetLocalPositionZ(dictSrcBoneInfo[97].vctPos.z + dictSrcBoneInfo[100].vctPos.z + dictSrcBoneInfo[96].vctPos.z);
            dictDstBoneInfo[53].trfBone.SetLocalRotation(dictSrcBoneInfo[97].vctRot.x + dictSrcBoneInfo[96].vctRot.x, 0f, 0f);
            dictDstBoneInfo[53].trfBone.SetLocalScale(dictSrcBoneInfo[98].vctScl.x, dictSrcBoneInfo[98].vctScl.y, dictSrcBoneInfo[98].vctScl.z);
            dictDstBoneInfo[57].trfBone.SetLocalPositionX(dictSrcBoneInfo[109].vctPos.x);
            dictDstBoneInfo[57].trfBone.SetLocalPositionY(dictSrcBoneInfo[111].vctPos.y);
            dictDstBoneInfo[57].trfBone.SetLocalPositionZ(dictSrcBoneInfo[112].vctPos.z);
            dictDstBoneInfo[57].trfBone.SetLocalRotation(dictSrcBoneInfo[106].vctRot.x, 0f, dictSrcBoneInfo[107].vctRot.z);
            dictDstBoneInfo[58].trfBone.SetLocalPositionX(dictSrcBoneInfo[110].vctPos.x);
            dictDstBoneInfo[58].trfBone.SetLocalPositionY(dictSrcBoneInfo[111].vctPos.y);
            dictDstBoneInfo[58].trfBone.SetLocalPositionZ(dictSrcBoneInfo[112].vctPos.z);
            dictDstBoneInfo[58].trfBone.SetLocalRotation(dictSrcBoneInfo[106].vctRot.x, 0f, dictSrcBoneInfo[108].vctRot.z);
            dictDstBoneInfo[52].trfBone.SetLocalPositionY(dictSrcBoneInfo[94].vctPos.y);
            dictDstBoneInfo[52].trfBone.SetLocalPositionZ(dictSrcBoneInfo[94].vctPos.z);
            dictDstBoneInfo[52].trfBone.SetLocalScale(dictSrcBoneInfo[94].vctScl.x, dictSrcBoneInfo[94].vctScl.y, dictSrcBoneInfo[94].vctScl.z);
            dictDstBoneInfo[51].trfBone.SetLocalPositionY(dictSrcBoneInfo[93].vctPos.y);
            dictDstBoneInfo[51].trfBone.SetLocalPositionZ(dictSrcBoneInfo[95].vctPos.z);
            dictDstBoneInfo[51].trfBone.SetLocalRotation(dictSrcBoneInfo[93].vctRot.x, 0f, 0f);
            dictDstBoneInfo[44].trfBone.SetLocalPositionY(dictSrcBoneInfo[83].vctPos.y + dictSrcBoneInfo[81].vctPos.y + dictSrcBoneInfo[82].vctPos.y);
            dictDstBoneInfo[44].trfBone.SetLocalPositionZ(dictSrcBoneInfo[83].vctPos.z + dictSrcBoneInfo[84].vctPos.z + dictSrcBoneInfo[82].vctPos.z);
            dictDstBoneInfo[44].trfBone.SetLocalRotation(dictSrcBoneInfo[83].vctRot.x + dictSrcBoneInfo[81].vctRot.x + dictSrcBoneInfo[82].vctRot.x, 0f, 0f);
            dictDstBoneInfo[7].trfBone.SetLocalRotation(0f, dictSrcBoneInfo[17].vctRot.y, dictSrcBoneInfo[19].vctRot.z);
            dictDstBoneInfo[7].trfBone.SetLocalScale(dictSrcBoneInfo[21].vctScl.x, dictSrcBoneInfo[21].vctScl.y, dictSrcBoneInfo[21].vctScl.z);
            dictDstBoneInfo[13].trfBone.SetLocalPositionX(dictSrcBoneInfo[31].vctPos.x);
            dictDstBoneInfo[13].trfBone.SetLocalPositionY(dictSrcBoneInfo[31].vctPos.y);
            dictDstBoneInfo[13].trfBone.SetLocalPositionZ(dictSrcBoneInfo[31].vctPos.z);
            dictDstBoneInfo[13].trfBone.SetLocalRotation(dictSrcBoneInfo[31].vctRot.x, dictSrcBoneInfo[31].vctRot.y, 0f);
            dictDstBoneInfo[13].trfBone.SetLocalScale(dictSrcBoneInfo[31].vctScl.x, dictSrcBoneInfo[31].vctScl.y, dictSrcBoneInfo[31].vctScl.z);
            dictDstBoneInfo[9].trfBone.SetLocalPositionY(dictSrcBoneInfo[23].vctPos.y);
            dictDstBoneInfo[9].trfBone.SetLocalPositionZ(dictSrcBoneInfo[23].vctPos.z);
            dictDstBoneInfo[9].trfBone.SetLocalScale(dictSrcBoneInfo[23].vctScl.x, dictSrcBoneInfo[23].vctScl.y, dictSrcBoneInfo[23].vctScl.z);
            dictDstBoneInfo[8].trfBone.SetLocalRotation(0f, dictSrcBoneInfo[18].vctRot.y, dictSrcBoneInfo[20].vctRot.z);
            dictDstBoneInfo[8].trfBone.SetLocalScale(dictSrcBoneInfo[22].vctScl.x, dictSrcBoneInfo[22].vctScl.y, dictSrcBoneInfo[22].vctScl.z);
            dictDstBoneInfo[14].trfBone.SetLocalPositionX(dictSrcBoneInfo[32].vctPos.x);
            dictDstBoneInfo[14].trfBone.SetLocalPositionY(dictSrcBoneInfo[32].vctPos.y);
            dictDstBoneInfo[14].trfBone.SetLocalPositionZ(dictSrcBoneInfo[32].vctPos.z);
            dictDstBoneInfo[14].trfBone.SetLocalRotation(dictSrcBoneInfo[32].vctRot.x, dictSrcBoneInfo[32].vctRot.y, 0f);
            dictDstBoneInfo[14].trfBone.SetLocalScale(dictSrcBoneInfo[32].vctScl.x, dictSrcBoneInfo[32].vctScl.y, dictSrcBoneInfo[32].vctScl.z);
            dictDstBoneInfo[10].trfBone.SetLocalPositionY(dictSrcBoneInfo[24].vctPos.y);
            dictDstBoneInfo[10].trfBone.SetLocalPositionZ(dictSrcBoneInfo[24].vctPos.z);
            dictDstBoneInfo[10].trfBone.SetLocalScale(dictSrcBoneInfo[24].vctScl.x, dictSrcBoneInfo[24].vctScl.y, dictSrcBoneInfo[24].vctScl.z);
            dictDstBoneInfo[11].trfBone.SetLocalPositionY(dictSrcBoneInfo[25].vctPos.y);
            dictDstBoneInfo[11].trfBone.SetLocalRotation(0f, 0f, dictSrcBoneInfo[27].vctRot.z);
            dictDstBoneInfo[11].trfBone.SetLocalScale(dictSrcBoneInfo[29].vctScl.x, dictSrcBoneInfo[29].vctScl.y, dictSrcBoneInfo[29].vctScl.z);
            dictDstBoneInfo[12].trfBone.SetLocalPositionY(dictSrcBoneInfo[26].vctPos.y);
            dictDstBoneInfo[12].trfBone.SetLocalRotation(0f, 0f, dictSrcBoneInfo[28].vctRot.z);
            dictDstBoneInfo[12].trfBone.SetLocalScale(dictSrcBoneInfo[30].vctScl.x, dictSrcBoneInfo[30].vctScl.y, dictSrcBoneInfo[30].vctScl.z);
        }
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
        int num = 0;
        for (int i = 0; i < count; i++)
        {
            List<CategoryInfo> list = dictCategory[category];
            BoneInfo boneInfo = null;
            num = list[i].id;
            empty = list[i].name;
            if (dictSrcBoneInfo.TryGetValue(num, out boneInfo))
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

    private void GetListString(string text, out string[,] data)
    {
        string[] array = text.Split('\n');
        int num = array.Length;
        if (num != 0 && array[num - 1].Trim() == string.Empty)
        {
            num--;
        }
        string[] array2 = array[0].Split('\t');
        int num2 = array2.Length;
        if (num2 != 0 && array2[num2 - 1].Trim() == string.Empty)
        {
            num2--;
        }
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
            int num6 = array3.Length - 1;
            string text2 = data[i, array3.Length - 1].Replace("\r", string.Empty).Replace("\n", string.Empty);
            obj3[num5, num6] = text2;
        }
    }

    private void Update()
    {
        if (IsChange)
        {
            UpdateDstToScrBONE();
            IsChange = false;
        }
    }

    public void ChangeSlider(int value)
    {
         float val=  Sliders[value].GetComponent<Slider>().value;
        ChangeValue(value, val);
    }
    private void InitSlider()
    {
        for (int i = 0; i < cf_headshapename.Length; i++)
        {
            GameObject Slider = GameObject.Instantiate(Sliders[0]);
            Slider.transform.SetParent(ViewContent,false);
            Slider.gameObject.SetActive(true);
            Slider.transform.Find("SliderName").GetComponent<Text>().text = cf_headshapename[i];
            Slider slider = Slider.GetComponent<Slider>();
            int intval = i;
            slider.onValueChanged.AddListener(delegate 
            {
                float val = slider.value;
                ChangeValue(intval, val);
            });
        }
    }
    public List<GameObject> Sliders;
    public Transform ViewContent;
}
public class BoneInfo
{
    public Transform trfBone;

    public Vector3 vctPos = Vector3.zero;

    public Vector3 vctRot = Vector3.zero;

    public Vector3 vctScl = Vector3.one;
}
public class CategoryInfo
{
    public int id;

    public string name = string.Empty;

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
