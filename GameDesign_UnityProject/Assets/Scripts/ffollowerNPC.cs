using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ffollowerNPC : MonoBehaviour
{

    public float Speed = 20f;
    public Transform FollowPos = null;
    // Update is called once per frame
    void Update()
    {
        //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0f, -25f, 0f), Speed*Time.deltaTime);
        Quaternion rotTarget = Quaternion.LookRotation(FollowPos.position - this.transform.position);

        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, rotTarget, Speed * Time.deltaTime);

    }
}
