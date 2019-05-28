using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class faceblendshapeview : MonoBehaviour {

    public Slider EyeSlider;
    public Slider EyeOpenSlider;
    public FaceBlendShape FBS;

    void Start()
    {
        if (!FBS) return;

        EyeSlider.maxValue = FBS.EyesCtrl.FBSTarget[0].PtnSet.Length-1;
        EyeSlider.onValueChanged.AddListener(delegate 
        {
            FBS.ChangeEyesPtn( (int)EyeSlider.value);
        });
        EyeOpenSlider.onValueChanged.AddListener(delegate
        {
            FBS.CalcBlend(EyeOpenSlider.value);
        });

    }
}
