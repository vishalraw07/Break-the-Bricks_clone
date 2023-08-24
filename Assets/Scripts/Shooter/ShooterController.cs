using System.Collections;
using TMPro;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float boundX;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float force;
    [SerializeField] private int numberOfBalls;
    [SerializeField] private LevelController levelController;

    private int currentBallCount;
    private int ballsReturned;
    private bool hasBallsReturned;
    private Vector3 mousePos;
    private Camera mainCamera;
    private bool isRunning = false;
    private bool isShooting = false;
    private bool decreasedHeight;
    private void Start()
    {
        ballsReturned = 0;
        mainCamera = Camera.main;
        decreasedHeight = true;
        hasBallsReturned = true;
        currentBallCount = numberOfBalls;
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        MoveDirectionalArrow(mousePos);

        if (!isShooting)
        {
            Move(horizontal);
        }

        if(ballsReturned == numberOfBalls)
        {
            Time.timeScale = 1.0f;
            decreasedHeight = false;
            hasBallsReturned = true;
            ballsReturned = 0;
        }

        if(hasBallsReturned && !decreasedHeight)
        {
            decreasedHeight = true;
            levelController.MoveBricks();
        }
            

        if(Input.GetMouseButtonDown(0) && !isRunning && hasBallsReturned)
        {
            isRunning = true;
            isShooting = true;
            hasBallsReturned = false;
            StartCoroutine(ShootBall());
        }
    }

    private void MoveDirectionalArrow(Vector3 mousePos)
    {
        Vector3 rotation = (mousePos - transform.position).normalized;
        float rotZ = Mathf.Clamp(Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg, 30, 150);
        transform.rotation = Quaternion.Euler(0, 0, rotZ); 
    }

    public int GetCurrentBalls()
    {
        return currentBallCount;
    }

    private IEnumerator ShootBall()
    {
        ballsReturned = 0;
        for (int i = 0; i < numberOfBalls; i++)
        {
            currentBallCount--;
            Vector3 rotation = (arrow.transform.position - transform.position).normalized;
            GameObject shotBall = Instantiate(ball, arrow.transform.position, Quaternion.identity);
            Rigidbody2D rb = shotBall.GetComponent<Rigidbody2D>();
            rb.AddForce(rotation * force);
            yield return new WaitForSeconds(0.2f);
        }
        
        isRunning = false;
        isShooting = false;
    }

    private void Move(float _horizontal)
    {
        Vector3 temp = transform.position;
        temp.x = Mathf.Clamp(temp.x + speed * _horizontal * Time.deltaTime, -boundX, boundX);
        transform.position = temp;
    }
    public void IncreaseBalls()
    {
        currentBallCount++;
        ballsReturned++;
    }
}
