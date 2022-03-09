using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public float speed = 2; //[1] speed
    public Transform[] target;  // [2] target
    public float delta = 0.2f; // difference
    private static int i = 0;

    void Update()
    {
        moveTo();
    }

    void moveTo()
    {
        // [3] Initialize target
        target[i].position = new Vector3(target[i].position.x, transform.position.y, target[i].position.z);

        // [4] make the object face the target point
        transform.LookAt(target[i]);

        // [5] object moves forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // [6] Determine whether the object has reached the target point
        if (transform.position.x > target[i].position.x - delta
            && transform.position.x < target[i].position.x + delta
            && transform.position.z > target[i].position.z - delta
            && transform.position.z < target[i].position.z + delta)
            i = (i + 1) % target.Length;
    }
}
