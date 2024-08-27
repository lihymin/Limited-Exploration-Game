using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigid;
    public string monsterType;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Slime Move
        Vector3 nextPos = player.transform.position - transform.position;
        transform.position += nextPos.normalized * speed * Time.deltaTime;

        //Slime Flip
        if (player.transform.position.x > transform.position.x) 
            spriteRenderer.flipX = true;
        else 
            spriteRenderer.flipX = false;

    }
}
