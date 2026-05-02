using UnityEngine;

public class Camerafollower : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 3, -8);
    public float smoothSpeed = 5f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desirePosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desirePosition, smoothSpeed * Time.deltaTime);

        Quaternion targetRotataion = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotataion, smoothSpeed * Time.deltaTime);
    }
}
