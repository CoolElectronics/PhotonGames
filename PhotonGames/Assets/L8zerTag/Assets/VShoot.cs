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
        if (!pv.IsMine)
            return;
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1)){
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            Debug.Log("Did Hit");
            if (hit.collider.gameObject.tag == "Player"){
                Debug.Log("Ow");
                photonView.RPC("hitPlayer", RpcTarget.All, hit.point, transform.position,hit.collider.gameObject.GetPhotonView().ViewID);
            }
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
    [PunRPC]
    void hitPlayer(Vector3 hitPoint, Vector3 pos, int victimId){
            Debug.Log("Ow");
            Vector3[] points = new Vector3[2];
            points[0] = pos;
            points[1] = hitPoint;
            GetComponent<LineRenderer>().SetPositions(points);
            GameObject victim = PhotonView.Find(victimId).gameObject;
            victim.transform.position = new Vector3(122,-17,-28);
    }
}
