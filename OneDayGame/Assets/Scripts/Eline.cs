using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eline : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D body;
    private SpriteRenderer renderer2D;
    private Transform t;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        t = target.transform;
        renderer2D = target.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer2D.flipX.Equals(true))
        {
            body.velocity = new Vector3((t.transform.position.x - body.transform.position.x) * 2 + 0.4f, (t.transform.position.y - body.transform.position.y) * 2 + 0.4f, 0);
        } else
        {
            body.velocity = new Vector3((t.transform.position.x - body.transform.position.x) * 2 - 0.4f, (t.transform.position.y - body.transform.position.y) * 2 + 0.4f, 0);
        }
        
    }
}
