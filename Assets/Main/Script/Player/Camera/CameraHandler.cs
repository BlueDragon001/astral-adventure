using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Transform player;
    public Vector3 secondaryOffset;
    public Vector3 primaryOffset;
    public LayerMask layerMask;

    void Update()
    {
        GameObject spirit = GameObject.FindGameObjectWithTag(staticString.spiritTag);
        if (spirit == null)
        {
            NoSpiritCamera();
        }
        else
        {
            SpiritCamera(spirit);
        }
    }

    void NoSpiritCamera()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.down.normalized;
        Vector3 groundPosition;

        if (Physics.Raycast(player.position, direction, out hit, 3f, layerMask))
        {
            groundPosition = hit.point + primaryOffset;
                
        }
        else
        {
            groundPosition = player.position + secondaryOffset;
        }

        transform.position = Vector3.Lerp(transform.position, groundPosition, Time.deltaTime * 10f);

    }

    void SpiritCamera(GameObject Spirit)
    {
        Vector3 deiredPosition = Spirit.transform.position + new Vector3(secondaryOffset.x, secondaryOffset.y + 1, secondaryOffset.z);
        transform.position = Vector3.Lerp(transform.position, deiredPosition, Time.deltaTime * 5f);
    }
}
