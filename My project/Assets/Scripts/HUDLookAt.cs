using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDEnemy : MonoBehaviour
{
    public Transform HudTarget;
    void Update()
    {
        if (HudTarget != null)
        {
            Vector3 direction = HudTarget.position - HudTarget.position;
            transform.LookAt(new Vector3(HudTarget.position.x, transform.position.y, HudTarget.position.z));
            transform.Rotate(0, 180, 0);
        }
    }

}
