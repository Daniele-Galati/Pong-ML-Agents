using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Transform localOrigin;
    [SerializeField] float speed = 1f;
    [SerializeField] float speedBounceMultiplier = 0.01f;
    [SerializeField] PlayerMovement player1;
    [SerializeField] PlayerMovement player2;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResetBall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.linearVelocity = rb.linearVelocity * (1f + speedBounceMultiplier);

        if (collision.gameObject.CompareTag("Goal1"))
        {
            Debug.Log("Team 2 scored!");
            player2.RewardPlayer(1f);
            player1.RewardPlayer(-1f);
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("Goal2"))
        {
            Debug.Log("Team 1 scored!");
            player1.RewardPlayer(1f);
            player2.RewardPlayer(-1f);
            ResetBall();
        }

    }

    public void ResetBall()
    {
        transform.localPosition = localOrigin.position;
        Vector3 newVelocity = new Vector3(Random.Range(0, 2)==1?1:-1 ,0, Random.Range(0, 2) == 1 ? 0.5f : -0.5f);
        rb.linearVelocity = newVelocity * speed;
    }
}
