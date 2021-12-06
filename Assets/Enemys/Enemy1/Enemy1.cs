using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed;
    public string direction = "left";
    public float range = 0.0f; //“®‚«‰ñ‚é”ÍˆÍ
    Vector3 defPos; //‰ŠúˆÊ’u

    public float reactionDistance; //UŒ‚”½‰ž‹——£

    bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        if(direction == "right")
        {
            transform.localScale = new Vector2(-5, 5);
        }
        defPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(range > 0.0f)
        {
            if(transform.position.x < defPos.x - (range / 2))
            {
                direction = "right";
                transform.localScale = new Vector2(-5, 5);
            }
            if(transform.position.x > defPos.x + (range / 2))
            {
                direction = "left";
                transform.localScale = new Vector2(5, 5);
            }

        }
    }

    void FixedUpdate()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        Animator anime = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist < reactionDistance)
        {
            isAttack = true;
            anime.SetBool("attack", true);
            anime.SetBool("walk", false);
        }
        else if (dist > reactionDistance)
        {
            anime.SetBool("attack", false);

            if (direction == "right")
            {
                rbody.velocity = new Vector2(speed, rbody.velocity.y);
                anime.SetBool("walk", true);
            }
            else
            {
                rbody.velocity = new Vector2(-speed, rbody.velocity.y);
                anime.SetBool("walk", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (direction == "right")
        {
            direction = "left";
            transform.localScale = new Vector2(5, 5);
        }
        else
        {
            direction = "right";
            transform.localScale = new Vector2(-5, 5);
        } 
    }
        
}
