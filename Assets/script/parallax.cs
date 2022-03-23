using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public GameObject playerone;
    public float xinit;
    public float playerinit;
    public float setposition;
    // Start is called before the first frame update
    void Start()
    {
        xinit = this.transform.localPosition.x;
        playerinit = playerone.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        setposition= xinit + ((playerone.transform.position.x - playerinit) / 4);
        this.transform.localPosition = new Vector3(setposition, this.transform.localPosition.y);
    }
}
