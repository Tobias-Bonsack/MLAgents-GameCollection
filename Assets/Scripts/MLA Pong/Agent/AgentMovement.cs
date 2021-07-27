using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : AbstractResetEpisode
{

    [SerializeField] int moveSpeed;
    [SerializeField] GameObject manager;
    private Vector3 originLocPos;

    private void Awake() {
        this.AddToEvent(manager);
        this.originLocPos = transform.localPosition;
    }

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

    protected override void ResetGameObject()
    {
        transform.localPosition = originLocPos;
    }
}
