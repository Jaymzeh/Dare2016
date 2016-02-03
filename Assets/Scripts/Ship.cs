using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

    public float floatHeight;
    public float amplitude = 1;
    public float speed = 1;
    public float rotateSpeed;
    float y0;
    public LayerMask groundLayer;
    Ray ray;
    RaycastHit rayHit;

	void Start () {
        y0 = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        ray = new Ray(transform.position, Vector3.down * floatHeight);
        if (Physics.Raycast(ray, out rayHit, groundLayer)) {
            y0 = rayHit.point.y + 1;
        }
        transform.position = new Vector3(transform.position.x,
        y0 + amplitude * Mathf.Sin(speed * Time.time),
        transform.position.z);


        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, Space.World);

          

            transform.localPosition += Input.GetAxis("Vertical")*transform.forward;
        
	}

    void OnDrawGizmos() {
        //Gizmos.DrawRay(ray);
        //Gizmos.DrawSphere(rayHit.point, 1);
    }
}
