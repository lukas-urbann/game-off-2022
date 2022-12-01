using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machines : MonoBehaviour
{
    public GameObject bottle, smoke;
    public bool isWorking = false;
    
    public enum ColorType
    {
        Red,
        Green,
        Yellow,
        Purple,
        Blue
    }

    public ColorType machineType;
    public ColorType requiredPotionType;
    public ColorType returnType;
}
