using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    public Transform movingblock;
    public Transform startposmovblock;
    public Transform endposmovblock;
    int direction = 1;

    private void Update()
    {


    }
    Vector2 currentMovementTarget()
    { if (direction == 1)
        {
            return startposmovblock.position;
        }
        else
        {
            return endposmovblock.position;
        }
            
                }

}

