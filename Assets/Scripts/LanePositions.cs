using UnityEngine;

public class LanePositions : MonoBehaviour
{
    public static LanePositions Instance;

    public Transform leftLaneMarker;
    public Transform midLaneMarker;
    public Transform rightLaneMarker;

    private void Awake()
    {
        Instance = this;
    }

    public Vector3 GetLanePosition(Lane lane, float zPosition)
    {
        Vector3 pos;

        switch (lane)
        {
            case Lane.Left:
                pos = leftLaneMarker.position;
                break;
            case Lane.Mid:
                pos = midLaneMarker.position;
                break;
            default:
            case Lane.Right:
                pos = rightLaneMarker.position;
                break;
        }

        pos.z = zPosition;
        return pos;
    }
}
