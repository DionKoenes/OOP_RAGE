using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : KillingObstacle
{
    void Update()
    {
        StopPlayer();
    }
}