using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public Transform theZombie;
    public static bool aimingGun = false;
    public float aimSpeed;

    void Update()
    {
        aimSpeed = 10;
        if (aimingGun == true)
        {
            Vector3 targetDirection = theZombie.position - transform.position;
            targetDirection.y = 0;
            float rotStep = aimSpeed * Time.deltaTime;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotStep, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
