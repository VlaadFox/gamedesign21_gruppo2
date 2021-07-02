using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycastin_Security : MonoBehaviour
{
    public float rotationSpeed;
    public float radius;
    public Image Fade;

    [Range(0,360)]
    public float angle;

    public GameObject playeref;

    private Vector3 pos;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()
    {
        playeref = GameObject.FindGameObjectWithTag("Player");
        pos= playeref.transform.position;
        StartCoroutine(FOVRoutine());
        Fade.canvasRenderer.SetAlpha(0f);
        
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
                    fadeIn();
                    //StartCoroutine(pausa(2f));
                    
                    playeref.transform.position = pos;
                   

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
            
            fadeOut();
        }
            
    }

    void fadeIn()
    {
        Fade.CrossFadeAlpha(1, 0.1f, false);
        StartCoroutine(pausa(2f));
       // Fade.CrossFadeAlpha(0, 1, false);
    }
    void fadeOut()
    {
        Fade.CrossFadeAlpha(0, 2.0f, false);
    }


    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        //fadeOut();
    }
}
