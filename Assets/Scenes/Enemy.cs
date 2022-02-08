using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] private Vector3 newPos;
    
    [ContextMenu("Move")]
    public void Move()
    {
        Vector3 oldPos = transform.position;

        //transform.position.x = 10f;// += newPos;
        oldPos += newPos;

        transform.position = oldPos;
    }
}
