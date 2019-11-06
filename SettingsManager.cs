using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider[] SettingSliders;

    public MouseLook MouseSettings;

  
    private void Update()
    {
        CurrentMouseSens();
    }

    void CurrentMouseSens()
    {
        MouseSettings.speedH = SettingSliders[0].value;
        MouseSettings.speedV = SettingSliders[0].value;
    }


}
