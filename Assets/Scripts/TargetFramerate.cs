using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFramerate : MonoBehaviour
{
    public void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
