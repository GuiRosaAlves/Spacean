using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamb1 : MonoBehaviour {

    private void OnDestroy()
    {
        Spawner.rangedSpawned = false;
    }

}
