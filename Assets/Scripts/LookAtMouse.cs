using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {

    // Speed of turret rotation/movement
    public float speed = 2.5f;

	void Start ()
    {
	
	}

	void FixedUpdate ()
    {
        // Generates a plane that intersects the transform's position with an upwards normal
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determines the point where the cursor ray intersects the plane
        float hitdist = 0.0f;

        // If the ray is parallel to the plane, Raycast will return false
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Gets the point along the ray that hits the calculated distance
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determines the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotates towards the target point
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }
}
