using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private float _moveSpeed = 10f;

    public float verticalInput;

    public GameObject topWall;
    public GameObject bottomWall;

    void Update()
    {
        float topWallBottomY = topWall.GetComponent<Renderer>().bounds.min.y;
        float bottomWallTopY = bottomWall.GetComponent<Renderer>().bounds.max.y;
        float paddleHeight = GetComponent<Renderer>().bounds.size.y;

        if (GetComponent<Renderer>().bounds.max.y > topWallBottomY)
        {
            transform.position = new Vector3(transform.position.x, topWallBottomY - (paddleHeight / 2), transform.position.z);
        }

        if (GetComponent<Renderer>().bounds.min.y < bottomWallTopY)
        {
            transform.position = new Vector3(transform.position.x, bottomWallTopY + (paddleHeight / 2), transform.position.z);
        }

        //verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector2.down * -_moveSpeed * Time.deltaTime * verticalInput);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * _moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * _moveSpeed * Time.deltaTime);
        }
    }
}
