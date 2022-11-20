using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padlock : MonoBehaviour
{
    [SerializeField] private ushort code = 123;

    public void StartPadlock()
    {
        print(code);
    }
}
