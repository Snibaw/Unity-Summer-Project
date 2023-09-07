using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float xOffset = 5f;
    [SerializeField] private float yOffset = 2f;
    [SerializeField] private float movingTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        transform.position = new Vector3(player.position.x + xOffset, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x+xOffset, player.transform.position.y + yOffset, transform.position.z), movingTime);
    }
}
