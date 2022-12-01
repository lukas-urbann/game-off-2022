using System;
using System.Collections;
using System.Collections.Generic;
using Lukas.Interactable;
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

    private void Update()
    {
        if (isWorking)
        {
            smoke.SetActive(true);
        }
        else
        {
            smoke.SetActive(false);
        }
    }

    public void SetRequiredPotion()
    {
        //GetComponent<RemoveItem>().
    }
}
