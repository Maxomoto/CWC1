using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Update is called once per frame

    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 7, -9);
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; 
    }
}
