using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//place holder scrpit, will update with anim data

public class UnlockObject : MonoBehaviour
{

    public GameObject barrierObj;

    public void UnlockObj()
    {
        barrierObj.SetActive(false);
    }
}
