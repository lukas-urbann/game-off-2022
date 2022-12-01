using System;
using System.Collections;
using System.Collections.Generic;
using Lukas.Objective;
using UnityEngine;

public class NoTime : MonoBehaviour
{
    public static NoTime Instance;
    public GameObject timer, music;
    
    private void Start()
    {
        StartCoroutine(Fuck());
    }

    private IEnumerator Fuck()
    {
        //yield return new WaitForSeconds(82);
        yield return new WaitForSeconds(1);
        Spawn();
    }

    private void Spawn()
    {
        timer.SetActive(true);
        music.SetActive(true);
        //Instantiate(timer, transform.position, Quaternion.identity);
        //Instantiate(music, transform.position, Quaternion.identity);
    }

    public void EnableExit()
    {
        
    }

    public void UpdateNeededPotions(Machines.ColorType potion, Machines.ColorType machine)
    {
        Mission.Instance.UpdateMission("You need to put [" + potion + "] potion into [" + machine + "] machine!", 4);
    }
}
