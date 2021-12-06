using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  　Rigidbody2D rbody;
  　Animator animator;

    public float jumpSpeed;
    bool jump = false; //ジャンプフラグ
 
  　public bool walkforward = false; //前方に歩く
  　public float walkspeed; //進む速度

    bool isAttack = false; // 攻撃

    // Start is called before the first frame update
    void Start()
  　 {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
 　  }

    // Update is called once per frame
  　 void Update()
   　{
        if(Input.GetKeyDown("space") && !jump)
        {
            rbody.AddForce(Vector2.up * jumpSpeed);
            jump = true;
            Debug.Log("ジャンプ作動");
        }
        if(Input.GetMouseButtonDown(0)) //攻撃
        {
            isAttack = true;
            Debug.Log("攻撃");          
                    
        }
        if(walkforward) //　X軸に進む
        {
            gameObject.transform.Translate(walkspeed, 0, 0);
        }
  
   　}

   　void FixedUpdate()
   　{  
        if(jump == false) //移動アニメーション
        {
            animator.SetBool("jump", false);
        }
        else if(jump == true) //ジャンプアニメーション
        {
            animator.SetBool("jump", true);
        }
        else if(isAttack == true)　//攻撃アニメーション
        {  
           animator.SetTrigger("attack");
        }
 

   　}

   　void OnCollisionEnter2D(Collision2D othe)
   　{
        if(othe.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
   　}
     
    
}
