using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongLife : AbstractResetEpisode
{
    [SerializeField] GameObject manager;
    public int life = 3;

    [SerializeField] GameObject[] shownLife;

    private void Awake() {
        this.AddToEvent(manager);
    }

    public void isHitted() {
        life-=1;
        //TODO change visible life

        if(life <= 0) {
            GetComponent<PongAgent>().EndExternalEpisode();
        }
    }

    protected override void ResetGameObject()
    {
        this.life = 3;
    }
}
