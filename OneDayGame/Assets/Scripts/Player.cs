using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public Vector2 maxVelocity = new Vector2(2, 5);
    public int doubleJumpCorrectionFactor = 50;
    public float jumpHeight = 200f;
    private int jumpToken = 0;
    private Rigidbody2D body2D;
    private SpriteRenderer renderer2D;
    private Animator anim;

    // ASSISSTIVE FUNCTIONS
    void KeyboardBehaviour()
    {
        if (Input.GetKey("right") && (Input.GetKey("left shift") || Input.GetKey("right shift")))
        {
            anim.SetInteger("state", 1);
            if (Mathf.Abs(body2D.velocity.x) < 1f)
            {
                body2D.AddForce(new Vector2(speed/2, 0));
            }
            renderer2D.flipX = false;
        } else if (Input.GetKey("right"))
        {
            anim.SetInteger("state", 2);
            if (body2D.velocity.x < maxVelocity.x)
            {
                body2D.AddForce(new Vector2(speed, 0));
            }
            renderer2D.flipX = false;
        }
        if (Input.GetKey("left") && (Input.GetKey("left shift") || Input.GetKey("right shift")))
        {
            anim.SetInteger("state", 1);
            if (Mathf.Abs(body2D.velocity.x) < 1f)
            {
                body2D.AddForce(new Vector2(-speed/2, 0));
            }
            renderer2D.flipX = true;
        } else if (Input.GetKey("left"))
        {
            anim.SetInteger("state", 2);
            if (body2D.velocity.x > -maxVelocity.x)
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
    void AnimationBehaviour()
    {
        if (Mathf.Abs(body2D.velocity.x) < 0.1f)
        {
            anim.SetInteger("state", 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        renderer2D = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            jumpToken = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardBehaviour();
        AnimationBehaviour();
    }
}
