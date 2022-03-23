using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnercoffee : MonoBehaviour
{

    public GameObject coffee;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawncoffee", 0, 2);
    }

   void spawncoffee()
    {
        Instantiate(coffee, transform.position, Quaternion.identity);
    }
}
