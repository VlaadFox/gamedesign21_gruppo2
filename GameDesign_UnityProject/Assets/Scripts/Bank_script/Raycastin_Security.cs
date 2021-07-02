using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastin_Security : MonoBehaviour
{
    public float rotationSpeed;
    public float distance;

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right , distance);
        if (hitinfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitinfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }
    }
}
