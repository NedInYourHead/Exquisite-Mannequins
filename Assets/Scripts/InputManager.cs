using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Controls controls;
    private Camera mainCam;
    [SerializeField] private GenericInteractable currentObjectSelected;
    private GenericInteractable CurrentObjectSelected
    {
        get { return currentObjectSelected; }
        set
        {
            if (currentObjectSelected != null)
            {
                currentObjectSelected.gameObject.layer = 0;
            }
            currentObjectSelected = value;
            if (currentObjectSelected != null)
            {
                currentObjectSelected.gameObject.layer = 6;
            }
        }
    }

    private RaycastHit2D[] objectsTouched;
    private Vector2 fingerPosition;
    [SerializeField] private LayerMask selectableLayers;

    private Transform debugFingerTransform;

    void Awake()
    {
        debugFingerTransform = GameObject.Find("DebugFingerPosition").transform;
        mainCam = Camera.main;
        controls = new Controls();
        controls.Playmode.TouchPress.started += ctx => TouchStarted();
        controls.Playmode.TouchPosition.performed += ctx => TouchPosition(mainCam.ScreenToWorldPoint(ctx.ReadValue<Vector2>()));
        controls.Playmode.TouchPress.canceled += ctx => TouchRelease();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void TouchStarted()
    {
        Debug.Log("Started at " + fingerPosition.ToString());

        objectsTouched = Physics2D.RaycastAll(fingerPosition, Vector2.zero, Mathf.Infinity, selectableLayers);

        Transform closestTransform = null;

        for (int i = 0; i < objectsTouched.Length; i++)
        {
            if (closestTransform == null || objectsTouched[i].transform.position.z < closestTransform.position.z)
            {
                closestTransform = objectsTouched[i].transform;
            }
        }
        objectsTouched = null;

        if (closestTransform != null)
        {
            CurrentObjectSelected = closestTransform.gameObject.GetComponent<GenericInteractable>();
            Debug.Log(CurrentObjectSelected.name);
        }
        if (CurrentObjectSelected != null)
        {
            CurrentObjectSelected.Pressed(fingerPosition);
        }
    }


    private void TouchPosition(Vector2 position)
    {
        fingerPosition = position;
        if (CurrentObjectSelected != null)
        {
            CurrentObjectSelected.UpdateFingerPosition(position);
        }
    }

    private void TouchRelease()
    {
        if (CurrentObjectSelected != null)
        {
            CurrentObjectSelected.Released(fingerPosition);
        }
        CurrentObjectSelected = null;
        Debug.Log("Released at " + fingerPosition.ToString());
    }

    private void Update()
    {
        debugFingerTransform.position = new Vector3(fingerPosition.x, fingerPosition.y, -49f);
    }
}
