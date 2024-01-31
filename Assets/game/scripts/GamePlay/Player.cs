using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Rigidbody2D rb;
    //    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask groundedLayer;
    [SerializeField] private int Speed = 5;
    [SerializeField] private float jumpForce = 350;
    [SerializeField] private Kunai kunaiPrefab;
    [SerializeField] private Transform throwpoint;
    [SerializeField] private GameObject attackArea;
    private bool isGrounded = true;
    private bool isJumping = false;
    private bool isAttack = false;

    private float horizontal;
    private int coin = 0;
    private Vector3 savePoint;
    private void OnEnable()
    {
        
    }
    private void Awake()
    {
        coin = PlayerPrefs.GetInt("coin", 0);       
    }
    void Update()
    {

        if (IsDead)
        {
            return;
        }
        isGrounded = CheckGrounded();
        //horizontal = Input.GetAxisRaw("Horizontal");
        if (isAttack)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        if (isGrounded)
        {
            if (isJumping)
            {
                return;
            }
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                jump();
            }
            if (Mathf.Abs(horizontal) > 0.1f)
            {
                changeanim("run");
            }
            if (Input.GetKeyDown(KeyCode.C) && isGrounded)
            {
                attack();
            }
            if (Input.GetKeyDown(KeyCode.V) && isGrounded)
            {
                Throw();
            }
        }
        if (!isGrounded && rb.velocity.y < 0)
        {
            changeanim("fall");
            isJumping = false;
        }
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(0, horizontal > 0 ? 0 : 180, 0));
        }
        else if (isGrounded)
        {
            changeanim("idle");
            rb.velocity = Vector2.zero;
        }
    }
    public override void OnInit()
    {
        base.OnInit();
        isAttack = false;
        transform.position = savePoint;
        changeanim("idle");
        DeActiveAttack();
        SavePoint();
        UIManager.instance.SetCoin(coin);
    }
    public override void OnDespawn()
    {
        base.OnDespawn(); 
    }
    protected override void OnDeath()
    {
        base.OnDeath();
    }
    private bool CheckGrounded()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.1f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundedLayer);
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void attack()
    {
        changeanim("attack");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
        ActiveAttack();
        Invoke(nameof(DeActiveAttack), 0.5f);
    }
    private void ResetAttack()
    {
        changeanim("idle");
        isAttack = false;
    }
    public void Throw()
    {
        changeanim("throw");
        isAttack = true;
        Invoke(nameof(ResetAttack), 0.5f);
        Instantiate(kunaiPrefab, throwpoint.position, throwpoint.rotation);
    }
    public void jump()
    {
        isJumping = true;
        changeanim("jump");
        rb.AddForce(jumpForce * Vector2.up);
    }
    private void changeanim(string animname)
    {
        if (currentanimname != animname)
        {
            anim.ResetTrigger(animname);
            currentanimname = animname;
            anim.SetTrigger(currentanimname);
        }
    }
    internal void SavePoint()
    {
        savePoint = transform.position;
    }
    private void ActiveAttack()
    {
        attackArea.SetActive(true);
    }
    private void DeActiveAttack()
    {
        attackArea.SetActive(false);
    }
    public void SetMove(float horizontal)
    {
        this.horizontal = horizontal;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "coin")
        {
            coin++;
            PlayerPrefs.SetInt("coin", coin);
            Destroy(collision.gameObject);
            UIManager.instance.SetCoin(coin);
        }
        if (collision.tag == "DeathZone")
        {
            changeanim("die");
            Invoke(nameof(OnInit), 1f);
        }
    }
}
