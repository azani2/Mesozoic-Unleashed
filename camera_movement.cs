using UnityEngine;

public class camera_movement : MonoBehaviour
{

    private Vector3 myPos;
    public Transform myPlay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        myPos = new Vector3(-0.5f, 0.1f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = myPlay.position + myPos;

    }
}
