using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Invector.vCharacterController;
public class VShoot : MonoBehaviourPunCallbacks
{
    public Photon.Pun.PhotonView pv;
    vThirdPersonCamera cam;
    [SerializeField]
    vThirdPersonController controller;
    [SerializeField]
    float vWalk;
    [SerializeField]
    float vRun;
    void Start()
    {
        cam = GetComponent<vThirdPersonCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine) return;
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1)){
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Vector3[] points = new Vector3[2];
            points[0] = transform.position;
            points[1] = hit.point;
            GetComponent<LineRenderer>().SetPositions(points);
            Debug.Log("Did Hit");
        }
        }
        if (Input.GetMouseButton(1)){
            cam.defaultDistance = -1f;
            controller.strafeSpeed.runningSpeed = 0.5f;
            controller.strafeSpeed.sprintSpeed = 0.5f;
        }else{
            cam.defaultDistance = 2.5f;
            controller.strafeSpeed.runningSpeed = vWalk;
            controller.strafeSpeed.sprintSpeed = vRun;
        }
    }
}
