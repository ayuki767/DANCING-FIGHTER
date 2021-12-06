using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  �@Rigidbody2D rbody;
  �@Animator animator;

    public float jumpSpeed;
    bool jump = false; //�W�����v�t���O
 
  �@public bool walkforward = false; //�O���ɕ���
  �@public float walkspeed; //�i�ޑ��x

    bool isAttack = false; // �U��

    // Start is called before the first frame update
    void Start()
  �@ {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
 �@  }

    // Update is called once per frame
  �@ void Update()
   �@{
        if(Input.GetKeyDown("space") && !jump)
        {
            rbody.AddForce(Vector2.up * jumpSpeed);
            jump = true;
            Debug.Log("�W�����v�쓮");
        }
        if(Input.GetMouseButtonDown(0)) //�U��
        {
            isAttack = true;
            Debug.Log("�U��");          
                    
        }
        if(walkforward) //�@X���ɐi��
        {
            gameObject.transform.Translate(walkspeed, 0, 0);
        }
  
   �@}

   �@void FixedUpdate()
   �@{  
        if(jump == false) //�ړ��A�j���[�V����
        {
            animator.SetBool("jump", false);
        }
        else if(jump == true) //�W�����v�A�j���[�V����
        {
            animator.SetBool("jump", true);
        }
        else if(isAttack == true)�@//�U���A�j���[�V����
        {  
           animator.SetTrigger("attack");
        }
 

   �@}

   �@void OnCollisionEnter2D(Collision2D othe)
   �@{
        if(othe.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
   �@}
     
    
}
