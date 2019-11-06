using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightFunctions : MonoBehaviour
{
    public Light LightForFL;

    public Animator LighterAnim;

    bool enableLighter = false;

    public bool playerHasLighter = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && playerHasLighter)
        {
            enableLighter = !enableLighter;
        }

        FlashlightState();

    }

    void FlashlightState()
    {
        switch (enableLighter)
        {
            case true:
                LightForFL.enabled = true;
                LighterAnim.SetBool("open_lighter", true);
                break;

            case false:
                LightForFL.enabled = false;
                LighterAnim.SetBool("open_lighter", false);
                break;
        }

    }

}
