using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SavePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") collision.GetComponent<Player>().SavePoint();
    }
}
