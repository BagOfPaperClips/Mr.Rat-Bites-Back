using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathInfo : MonoBehaviour
{
    public GameObject mouseDeath;
    private void Update()
    {

        if(StaticData.deathtype == 1)
        {
            //mouseDeath.SetActive(false);
        }
        if (StaticData.deathtype == 2)
        {
            //mouseDeath.SetActive(true);
        }
    }
}
