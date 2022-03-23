using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    public GameObject playerone;
    public float xinit;
    public float playerinit;
    public float setposition;
    // Start is called before the first frame update
    void Start()
    {
        xinit = this.transform.position.x;
        playerinit = playerone.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        setposition = xinit + ((playerone.transform.position.x - playerinit));
        this.transform.localPosition = new Vector3(setposition, this.transform.position.y);
    }
}
