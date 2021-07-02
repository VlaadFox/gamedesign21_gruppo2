using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;

    //[SerializeField] private Image _target;
    //private GameObject _target = null;

    //public bool ImmagineASchermo;

    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    private CharacterController _fpsController;
    private Vector3 _rayOrigin;

    private Grabbable _grabbedObject = null;


    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
        //_target = GameObject.FindGameObjectWithTag("Hand");
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        if (_grabbedObject == null)
            CheckInteraction();

        if (_grabbedObject != null && Input.GetMouseButtonUp(0))
            Drop();

        if (_grabbedObject != null && Input.GetMouseButtonDown(1))
            Throw();

        //UpdateUITarget();

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
            if (_pointingInteractable)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _pointingInteractable.Interact(gameObject);
                }
            }

            //Check if is grabbable
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            if (_grabbedObject == null && _pointingGrabbable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _pointingGrabbable.Grab(gameObject);
                    Grab(_pointingGrabbable);
                }

            }
        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractable = null;
            _pointingGrabbable = null;
        }
    }

   /* private void UpdateUITarget()
    {
        if (_pointingGrabbable || _pointingInteractable)
            _target.color = Color.green;
        else
        {
            _target.color = new Color(_target.color.r, _target.color.g, _target.color.b, 0f);
            //_target.SetActive(false);


        }



    }
   */
    private void Drop()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Drop();

       // _target.enabled = true;
        _grabbedObject = null;
    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;
        grabbable.transform.SetParent(_fpsCameraT);

       // _target.enabled = false;
    }

    private void Throw()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Throw(gameObject);

       // _target.enabled = true;
        _grabbedObject = null;
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }
}
