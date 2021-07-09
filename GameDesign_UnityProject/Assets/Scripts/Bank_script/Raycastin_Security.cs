using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycastin_Security : MonoBehaviour
{
    public float rotationSpeed;
    public float radius;
    //public Image Fade;
    public Animator transistion;

    [Range(0,360)]
    public float angle;

    public GameObject playeref;
    public GameObject playerpos;


    private Vector3 pos;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        playeref = GameObject.FindGameObjectWithTag("Player");
        pos= playerpos.transform.position;
        StartCoroutine(FOVRoutine());
        //Fade.canvasRenderer.SetAlpha(0f);
        
    }
    private IEnumerator FOVRoutine()
    {
        
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private IEnumerator pausa(float tempo)
    { 
        yield return new WaitForSeconds(tempo);
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    Debug.Log("hit");
                    // fadeIn();
                    //StartCoroutine(pausa(2f));
                    //transistion.SetTrigger("dead");
                    // transistion.SetTrigger("restabilize");
                    transistion.SetTrigger("start");
                    transistion.SetTrigger("end");


                    StartCoroutine(despawn());
                   

                }


                else
                {
                    canSeePlayer = false;
                }
                    

            }
            else
            {
                canSeePlayer = false;
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            

            // fadeOut();
        }
            
    }

   


    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        //fadeOut();
    }


    public IEnumerator despawn()
    {
        yield return new WaitForSeconds(1f);
        playeref.transform.position = pos;

    }
}
