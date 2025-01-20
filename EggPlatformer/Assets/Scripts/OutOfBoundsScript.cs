using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody playerRigidBody;

    public Transform OutOfBoundsDest;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRigidBody.velocity = Vector3.zero;
            playerRigidBody.transform.position = OutOfBoundsDest.position;
        }
    }

}
