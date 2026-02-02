using UnityEngine;

public class NewBall : MonoBehaviour
{
    public GameObject GameController;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public GameObject rightPaddleP2;
    public GameObject wallSound;

    private Rigidbody2D _rigidbody;

    public float moveSpeed = 400.0f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        AddStartingForce();
    }

    void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        _rigidbody.AddForce(new Vector2(x, y) * moveSpeed);
    }

    void ResetRound()
    {
        GameController.GetComponent<GameController>().ResetBoard();

        _rigidbody.linearVelocity = new Vector2(0, 0);
        AddStartingForce();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        _rigidbody.AddForce(normal * 25);

        if (collision.gameObject.name == "LeftPaddle")
        {
            leftPaddle.GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.name == "RightPaddle")
        {
            rightPaddle.GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.name == "RightPaddleP2")
        {
            rightPaddleP2.GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.tag == "Wall")
        {
            wallSound.GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.name == "LeftWall")
        {
            GameController.GetComponent<GameController>().rightScore++;
            ResetRound();
        }

        if (collision.gameObject.name == "RightWall")
        {
            GameController.GetComponent<GameController>().leftScore++;
            ResetRound();
        }
    }
}
