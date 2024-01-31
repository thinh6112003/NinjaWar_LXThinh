using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] protected CombatText CombatTextPrefab;
    // Start is called before the first frame update
    private float hp;
    public string currentanimname;
    public bool IsDead => hp <= 0;
    private void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        hp = 100;
        healthBar.OnInit(100, transform);
    }
    public virtual void OnDespawn()
    {

    }
    protected virtual void OnDeath()
    {
        ChangeAnim("die");
        Invoke(nameof(OnDespawn), 2f);
    }
    protected void ChangeAnim(string animname)
    {
        if (currentanimname != animname)
        {
            anim.ResetTrigger(animname);
            currentanimname = animname;
            anim.SetTrigger(currentanimname);
        }
    }
    public void OnHit(float damage)
    {
        if (!IsDead)
        {
            hp -= damage;
            if(IsDead)
            {
                hp = 0;
                OnDeath();
            }
            healthBar.SetNewHp(hp);
            Instantiate(CombatTextPrefab, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
        }
    }

    
}
