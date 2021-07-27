using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    public event StartNewEpisodeDelegate startNewEpisodeEvent;

    public void TriggerSNEE() {
        startNewEpisodeEvent();
    }
}
