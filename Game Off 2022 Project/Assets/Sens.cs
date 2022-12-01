using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sens : MonoBehaviour
{
    public void SetSens(float sens)
    {
        PlayerPrefs.SetFloat("sens", sens);
    }
}
