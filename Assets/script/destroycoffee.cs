using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroycoffee : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "block")
        {
            Destroy(coll.gameObject);
        }
    }
}
