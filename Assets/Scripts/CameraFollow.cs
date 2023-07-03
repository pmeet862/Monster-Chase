using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // LateUpdate is called once per frame after all Updates are called
    void LateUpdate()
    {
        if (!player)
        {
            return;
        }
        if (player.position.x > minX && player.position.x < maxX)
        {
            tempPos = transform.position;
            tempPos.x = player.position.x;
            transform.position = tempPos;
        }
    }
}
