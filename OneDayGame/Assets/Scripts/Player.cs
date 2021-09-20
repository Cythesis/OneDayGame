using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    public Vector2 maxVelocity = new Vector2(3, 5);
    public int doubleJumpCorrectionFactor = 50;
    public float jumpHeight = 200f;
    private int jumpToken = 0;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private CircleCollider2D collide2D;

    // ASSISSTIVE FUNCTIONS
    void KeyboardBehaviour()
    {
        if (Input.GetKey("right"))
        {
            if (Mathf.Abs(body2D.velocity.x) < maxVelocity.x)
            {
                body2D.AddForce(new Vector2(speed, 0));
            }
            renderer2D.flipX = false;
        }
        if (Input.GetKey("left"))
        {
            if (Mathf.Abs(body2D.velocity.x) < maxVelocity.x)
            {
                body2D.AddForce(new Vector2(-speed, 0));
            }
            renderer2D.flipX = true;
        }
        if ((Input.GetKeyDown("space") || Input.GetKeyDown("up")) && jumpToken > 0)
        {
            jumpToken -= 1;
            if (Mathf.Abs(body2D.velocity.y) < maxVelocity.y)
            {
                body2D.AddForce(new Vector2(0, jumpHeight - body2D.velocity.y * doubleJumpCorrectionFactor));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        collide2D = GetComponent<CircleCollider2D>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        jumpToken = 1;        
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardBehaviour();
        
    }
}
