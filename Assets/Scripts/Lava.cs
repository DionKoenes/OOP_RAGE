using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : KillingObstacle
{
    void Update()
    {
        StopPlayer();
    }

}
