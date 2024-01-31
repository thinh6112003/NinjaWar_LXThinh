using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    float timer;
    float randomTime;
    public void OnEnter(Enemy enemy)
    {
        enemy.StopMoving();
        timer = 0;
        randomTime = Random.Range(3f, 6f);
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        
        if(timer < randomTime)
        {
            enemy.Moving();
        }
        else
        {
            enemy.ChangeState(new IdleState());
        }
        
    }

    public void OnExit(Enemy enemy)
    {
        
    }
}
