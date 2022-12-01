using System;
using System.Collections;
using System.Collections.Generic;
using Lukas.Interactable;
using Lukas.Objective;
using Lukas.Player;
using UnityEngine;

public class Machines : InteractableObject
{
    public GameObject smoke;
    public bool isWorking = false;
    public string requiredItem = "";
    public GameObject item;

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

    private void Cook()
    {
        isWorking = true;
        StartCoroutine(Asd());
    }

    private IEnumerator Asd()
    {
        yield return new WaitForSeconds(10);
        CreatePotion();
        isWorking = false;
        GetComponent<cakeslice.Outline>().enabled = false;
        gameObject.tag = "Untagged";
    }

    public void CreatePotion()
    {
        item.SetActive(true);
        isWorking = false;
    }

    public override void PrivateInteraction()
    {
        if (Inventory.Instance.CheckItem(requiredItem))
        {
            Inventory.Instance.RemoveItem(requiredItem);
            Cook();
        }
        else
        {
            Mission.Instance.UpdateMission("You need to put [" + requiredItem + "] into this machine!", 3);
        }
    }
}