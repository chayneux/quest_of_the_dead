using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    private void Start()
    {
        Vector3 previousPlayerPosition = PlayerPositionManager.instance.GetPlayerPosition();
        if (previousPlayerPosition != Vector3.zero)
            transform.position = previousPlayerPosition;
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
