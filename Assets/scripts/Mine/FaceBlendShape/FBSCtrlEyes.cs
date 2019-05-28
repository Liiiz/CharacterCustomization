// FBSCtrlEyes
using System;

[Serializable]
public class FBSCtrlEyes : FBSBase
{
    public void CalcBlend(float blinkRate)
    {
        if (0f <= blinkRate)
        {
            base.openRate = blinkRate;
        }
        base.CalculateBlendShape();
    }
}
