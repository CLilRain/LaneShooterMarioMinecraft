using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CharacterMovement : MonoBehaviour
{
    public float moveDuration = 1f;

    Lane currentlane = Lane.Mid;

    Coroutine moveCoroutine;

    void Update()
    {
        InputUpdate();
    }

    private void InputUpdate()
    {
        // If 
        if (Input.GetKeyDown(KeyCode.A) 
            || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("moved left");

            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D)
            || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("moved Right");
            MoveRight();
        }
    }

    private void MoveLeft()
    {
        if (currentlane == Lane.Mid)
        {
            currentlane = Lane.Left;
        }

        if (currentlane == Lane.Right)
        {
            currentlane = Lane.Mid;
        }

        UpdatePosition();
    }

    private void MoveRight()
    {
        if (currentlane == Lane.Mid)
        {
            currentlane = Lane.Right;
        }

        if (currentlane == Lane.Left)
        {
            currentlane = Lane.Mid;
        }

        UpdatePosition();
    }
    
    private void UpdatePosition()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveToPositionCoroutine());
    }

    IEnumerator MoveToPositionCoroutine()
    {
        var targetPos = LanePositions.Instance.GetLanePosition(currentlane, transform.position.z);
        
        float t = 0;
        while (t < moveDuration)
        {
            var pos = Vector3.Lerp(transform.position, targetPos, t / moveDuration);
            SetPosition(pos);
            yield return null;
            t += Time.deltaTime;
        }

        SetPosition(targetPos);
        moveCoroutine = null;
        Debug.Log(targetPos);
    }

    private void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}