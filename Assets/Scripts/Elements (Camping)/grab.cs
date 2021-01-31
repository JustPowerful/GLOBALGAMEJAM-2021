using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    private SpringJoint grabJoint;
    private Rigidbody objectGrabbing;
    private Vector3 grabPoint;
    private Vector3 MyGrabPoint;
    private LineRenderer grabLr;
    private Vector3 previousLookDir;
    private Vector3 myHandPoint;
    public Material GrabMaterial;
    public Camera playerCam;
    public LayerMask WhatIsGrabbable;
    public float distance;

    private void LateUpdate()
    {
        DrawGrabbing();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            GrabObject();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            StopGrab();
        }
    }

    private void GrabObject()
    {
        if (objectGrabbing == null)
        {
            StartGrab();
            return;
        }
        HoldGrab();
    }


    private void DrawGrabbing()
    {
        if (!objectGrabbing)
        {
            return;
        }

        MyGrabPoint = Vector3.Lerp(MyGrabPoint, objectGrabbing.position, Time.deltaTime * 450);
        myHandPoint = Vector3.Lerp(myHandPoint, grabJoint.connectedAnchor, Time.deltaTime * 450f);
        grabLr.SetPosition(0, myHandPoint);
        grabLr.SetPosition(1, MyGrabPoint);

    }


    private void StartGrab()
    {
        RaycastHit[] array = Physics.RaycastAll(playerCam.transform.position, playerCam.transform.forward, 5f, WhatIsGrabbable);
        if (array.Length < 1)
        {
            return;
        }
        for (int i = 0; i < array.Length; i++)
        {
            MonoBehaviour.print("testing on: " + array[i].collider.gameObject.layer);
            if (array[i].transform.GetComponent<Rigidbody>())
            {
                objectGrabbing = array[i].transform.GetComponent<Rigidbody>();
                grabPoint = array[i].point;
                grabJoint = objectGrabbing.gameObject.AddComponent<SpringJoint>();
                grabJoint.autoConfigureConnectedAnchor = false;
                grabJoint.minDistance = 0f;
                grabJoint.maxDistance = 0f;
                grabJoint.damper = 4f;
                grabJoint.spring = 10f;
                grabJoint.massScale = 5f;
                objectGrabbing.angularDrag = 5f;
                objectGrabbing.drag = 1f;
                previousLookDir = playerCam.transform.forward;
                grabLr = objectGrabbing.gameObject.AddComponent<LineRenderer>();
                grabLr.positionCount = 2;
                grabLr.startWidth = 2f;
                grabLr.material = GrabMaterial;
                grabLr.numCapVertices = 10;
                grabLr.numCornerVertices = 10;


                return;
            }
        }
    }


    private void HoldGrab()
    {
        grabJoint.connectedAnchor = playerCam.transform.position + playerCam.transform.forward * distance;
        grabLr.startWidth = 0.1f;
        grabLr.endWidth = 0.0075f * objectGrabbing.velocity.magnitude;
        previousLookDir = playerCam.transform.forward;
    }


    private void StopGrab()
    {
        UnityEngine.Object.Destroy(grabJoint);
        UnityEngine.Object.Destroy(grabLr);

        objectGrabbing = null;

    }
}
