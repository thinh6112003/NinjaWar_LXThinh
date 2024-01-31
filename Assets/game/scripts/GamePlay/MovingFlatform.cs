using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovingFlatform : MonoBehaviour
{ 
    [SerializeField] private Transform aPoint, bPoint;
    Vector3 target;
    // Start is called before the first frame update
    [SerializeField] private float speed;
    void Start()
    {
        transform.position = aPoint.position;
        target = bPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position, aPoint.position) < 0.1f)
            target = bPoint.position;
        else if (Vector2.Distance(transform.position, bPoint.position) < 0.1f)
            target = aPoint.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }   
    }
}
