using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float h;
    public float v;
    public float speed;
    public float pushPower;
    Vector3 dir;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public GameObject slime;
    Enemy slimeLogic;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        slimeLogic = slime.GetComponent<Enemy>();
    }

    void Update()
    {
        //Player Move Value
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //Player Flip
        if (h == 1) {
            spriteRenderer.flipX = false;
            dir = Vector3.right;
        }

        else if (h == -1)  {
            spriteRenderer.flipX = true;
            dir = Vector3.left;
        }

        //Player Walk Animation
        if (h != 0 || v != 0) {
            anim.SetBool("isWalking", true);
        }
            
        else {
            anim.SetBool("isWalking", false);
        }

        //Enemy Search
        Debug.DrawRay(rigid.position, dir * 0.9f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dir, 0.9f, LayerMask.GetMask("Enemy"));

        //Enemy Attack
        if ((rayHit.collider.gameObject.tag == "Enemy" && rigid.position.x <= slimeLogic.rigid.position.x) && Input.GetButtonDown("Fire1")) {
            slimeLogic.rigid.AddForce(Vector3.right * pushPower, ForceMode2D.Impulse);
            pushPower = Random.Range(5, 11);
        }

        else if ((rayHit.collider.gameObject.tag == "Enemy" && rigid.position.x > slimeLogic.rigid.position.x) && Input.GetButtonDown("Fire1")) {
            slimeLogic.rigid.AddForce(Vector3.left * pushPower, ForceMode2D.Impulse);
            pushPower = Random.Range(5, 14);
        }
    }

    void FixedUpdate()
    {
        //Player Move
        rigid.velocity = new Vector3(h, v, 0) * speed;
    }
    
}
