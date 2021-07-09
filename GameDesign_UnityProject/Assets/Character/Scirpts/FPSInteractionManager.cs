using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;


    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    private CharacterController _fpsController;
    private Vector3 _rayOrigin;

    private Grabbable _grabbedObject = null;
    public Animator animator;
    public GameObject canva;

    void Start()
    {
        _fpsController = GetComponent<CharacterController>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        if (_grabbedObject == null)
            CheckInteraction();

        if ((_grabbedObject != null && Input.GetMouseButtonUp(0))||( _grabbedObject != null && Input.GetButtonUp("Grab")))
            Drop();

        if (_grabbedObject != null && Input.GetMouseButtonDown(1))
            Throw();


        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {
        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            
            //Check if is interactable
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
          
            //Check if is grabbable
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            if (_grabbedObject == null && _pointingGrabbable)
            {
                canva.SetActive(true);
                if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Grab"))
                {
                    canva.SetActive(false);
                    animator.SetBool("magicOn", true);
                    _pointingGrabbable.Grab(gameObject);
                    Grab(_pointingGrabbable);
                }

            }
        }
        //If NOTHING is detected set all to null
        else
        {
            canva.SetActive(false);
            _pointingGrabbable = null;
        }
    }

    private void Drop()
    {
        if (_grabbedObject == null)
            return;
        animator.SetBool("magicOn", false);
        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Drop();

        _grabbedObject = null;
    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;
        grabbable.transform.SetParent(_fpsCameraT);

    }

    private void Throw()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Throw(gameObject);

        _grabbedObject = null;
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }
}
