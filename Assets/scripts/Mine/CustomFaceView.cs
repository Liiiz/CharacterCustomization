using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomFaceView : MonoBehaviour {
    mCustomEditor mCustomEditor;
    CustomFace customFace;
    private void Awake()
    {
        mCustomEditor = new mCustomEditor();
        customFace = new CustomFace();
    }
    public string ControlConfigPath = "";
    public string AnimConfigPath = "";

    public Transform trfBone;

    private void InitSlider()
    {
        for (int i = 0; i < customFace.ControConfig.Length; i++)
        {
            GameObject Slider = GameObject.Instantiate(Sliders[0]);
            Slider.transform.SetParent(ViewContent, false);
            Slider.gameObject.SetActive(true);
            Slider.transform.Find("SliderName").GetComponent<Text>().text = customFace.ControConfig[i].ControName;
            Slider slider = Slider.GetComponent<Slider>();
            int intval = i;
            slider.onValueChanged.AddListener(delegate
            {
                float val = slider.value;
                customFace.ChangeValue(intval, val);
            });
        }
    }
    public List<GameObject> Sliders;
    public Transform ViewContent;

    private void Update()
    {
        customFace.UpdateDstToScrBONE();
    }

    public void InitCustomFace()
    {
        ReadControlConfig();
        ReadAnimConfig();
        customFace.Init(trfBone);
        InitSlider();
    }
    public void ReadControlConfig() {
        customFace.SetControConfig(mCustomEditor.ReadControlConfig(Application.dataPath + "/" + ControlConfigPath));
    }
    public void ReadAnimConfig() {
        customFace.SetAnimConfig(mCustomEditor.ReadAnimConfig(Application.dataPath + "/" + AnimConfigPath));
    }
}
