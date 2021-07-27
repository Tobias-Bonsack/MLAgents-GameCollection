using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{

    [SerializeField] int moveSpeed;

    public void moveUp()
    {
        Vector3 dir = Vector3.forward * moveSpeed * Time.deltaTime;
        transform.localPosition += dir;
    }

    public void moveDown()
    {
        Vector3 dir = Vector3.back * moveSpeed * Time.deltaTime;
        transform.localPosition += dir;
    }

}
