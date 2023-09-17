using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Fruit"))
        {
            //TODO: play sound
            Score.inst.Addscore(1);
            
            
        }
    }
}
