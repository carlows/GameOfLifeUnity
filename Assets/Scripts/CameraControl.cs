using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public float camSpeed = 10.0f;

    private float cameraSize = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        cameraSize -= scroll;
        cameraSize = Mathf.Clamp(cameraSize, 5.0f, 20.0f);

        if(scroll != 0)
        {
            Camera.main.orthographicSize = cameraSize;
        }

        var speed = new Vector3(horizontalInput, verticalInput, 0) * camSpeed * Time.deltaTime;
        transform.Translate(speed);
	}
}
