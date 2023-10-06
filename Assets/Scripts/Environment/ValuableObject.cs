using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuableObject : MonoBehaviour
{
    public string name;

    public int value = 125;

   


    public void IsInParent(Transform parent = null)
    {
        transform.SetParent(parent);
    }

}
