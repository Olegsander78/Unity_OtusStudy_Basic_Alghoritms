using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIScript : MonoBehaviour
{
    public Vector3 targetPosition;
    void Start()
    {
        Seeker seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, targetPosition);
    }
}
