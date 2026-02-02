using UnityEngine;

public class ComputerPlayer : MonoBehaviour
{
    private float _moveSpeed = 12.5f;
    public GameObject ball;
    public GameObject topWall;
    public GameObject bottomWall;

    void Update()
    {
        float topWallBottomY = topWall.GetComponent<Renderer>().bounds.min.y;
        float bottomWallTopY = bottomWall.GetComponent<Renderer>().bounds.max.y;
        float paddleHeight = GetComponent<Renderer>().bounds.size.y;

        Vector3 targetPosition = ball.transform.position;
        targetPosition.x = transform.position.x;

        if (ball.transform.position.x < -14)
        {
            // Sleep time!
        }
        else
        {
            if (targetPosition.y > transform.position.y)
            {
                transform.Translate(0, 1 * _moveSpeed * Time.deltaTime, 0);
            }
            
            if (targetPosition.y < transform.position.y)
            {
                transform.Translate(0, -1 * _moveSpeed * Time.deltaTime, 0);
            }
        }

        if (GetComponent<Renderer>().bounds.max.y > topWallBottomY)
        {
            transform.position = new Vector3(transform.position.x, topWallBottomY - (paddleHeight / 2), transform.position.z);
        }

        if (GetComponent<Renderer>().bounds.min.y < bottomWallTopY)
        {
            transform.position = new Vector3(transform.position.x, bottomWallTopY + (paddleHeight / 2), transform.position.z);
        }
    }
}
