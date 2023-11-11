using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    public static PlayerPositionManager instance; 

    private Vector3 playerPosition;
    private bool isFlipped;
    private float yPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerState(Vector3 position, bool flipped, float yPos)
    {
        playerPosition = position;
        isFlipped = flipped;
        yPosition = yPos;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }

    public bool GetPlayerFlipState()
    {
        return isFlipped;
    }

    public float GetPlayerYPosition()
    {
        return yPosition;
    }
}
