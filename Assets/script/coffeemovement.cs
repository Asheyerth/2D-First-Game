using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffeemovement : MonoBehaviour
{
    public Vector2 velocity;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = velocity;
    }
}
