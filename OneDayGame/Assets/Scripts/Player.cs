using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private bool colliding_ = false;
    public Vector2 maxVelocity = new Vector2(5, 20);
    public float jumpHeight = 100f;
    private bool collide;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private CircleCollider2D collider2D;

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<CircleCollider2D>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        colliding_ = true;
        var absVelY = Mathf.Abs(body2D.velocity.y);
        if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
        {
            body2D.AddForce(new Vector2(0, jumpHeight));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        var absVelX = Mathf.Abs(body2D.velocity.x);
        var absVelY = Mathf.Abs(body2D.velocity.y);
        var forceX = 0f;
        

        if (Input.GetKey("right"))
        {
            if (absVelX < maxVelocity.x)
            {
                forceX = speed;
            }
            renderer2D.flipX = false;
        } else if (Input.GetKey("left")) 
        {
            if (absVelX < maxVelocity.x)
            {
                forceX = -speed;
            }
            renderer2D.flipX = true;
        }  else if (Input.GetKeyDown("space") || Input.GetKeyDown("up") && colliding_ == true) 
        {
            colliding_ = false;
            if (absVelY < maxVelocity.y)
            {
                body2D.AddForce(new Vector2(0, jumpHeight - body2D.velocity.y));
            }
        }

        body2D.AddForce(new Vector2(forceX, 0));
    }
}
