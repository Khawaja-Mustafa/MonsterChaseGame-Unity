using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX = -35, maxX = 35;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    //Background had jitters, as frames loaded late
    //void Update()
    //{
    //    tempPos = transform.position;
    //    tempPos.x = player.position.x;
    //    transform.position = tempPos;
    //}
    //This would remove all conflicts between player update and camera update, and all time frames would be loaded after updation of position, hence it removes jitters in bg
    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        tempPos = transform.position;
        //transforms the position of camera relative to the player
        tempPos.x = player.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;
        transform.position = tempPos;
    }
}
