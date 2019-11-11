

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public CharacterController characterController;

    public MouseLook mouseLook;

    private Transform cam;

    private Vector3 camFwd;
    private Vector3 movement;

    public float Movement_Speed;

    public bool allowRaycast = true;

    public bool allowMovement = false;

    
    float h;
    float v;
    float mouse_y;

    private void Start()
    {

        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else

            Debug.Log("Could not find main camera");
    } 

    void Update()
    {
        if(allowMovement)
        {
            ControllerMovementAndRotation();

        }

        if (allowRaycast)
        {
            Interaction();

        }

      
        mouseLook.enabled = true;


    }

    void Interaction()
    {

        int layerMask = 9;
        float raycastRange = 8f;
        bool foundInteractable = false;
       
        layerMask = ~layerMask; //ingoring everying but the interactable layer      

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.transform.TransformDirection(Vector3.forward), out hit, raycastRange, layerMask))
        {
            Debug.DrawRay(cam.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //Debug.Log("Hit GameObject: " + hit.transform.gameObject.name);
            foundInteractable = true;
        }

        else
        {
            Debug.DrawRay(cam.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
            foundInteractable = false;
        }

        if(Input.GetButtonDown("Fire1") && foundInteractable)
        {
            //Debug.Log("Player pressed interact button");
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            interactable.Interact();

            if (interactable == null)
            {
                Debug.Log("Interactable script could not be found on item!");
            }

        }

    }

  
    void ControllerMovementAndRotation()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");


        camFwd = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
        movement = v * camFwd + h * cam.right;

        Vector3 facingDir = Vector3.Normalize(new Vector3(h, 0, v));
        Vector3 fowardDir = facingDir.z * camFwd + facingDir.x * cam.right;

        if (movement.sqrMagnitude > 1f)
        {
            movement = movement.normalized;
        }

        characterController.SimpleMove(movement * Movement_Speed * Time.deltaTime);

    }

}
