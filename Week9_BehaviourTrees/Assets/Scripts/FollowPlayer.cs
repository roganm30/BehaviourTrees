using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // I read in a forum that camera movement fits better in LateUpdate, rather than Update
    void LateUpdate()
    {
        if(player != null)
        {
            transform.position = player.transform.position + new Vector3(0, 5, -20);
        }
    }
}
