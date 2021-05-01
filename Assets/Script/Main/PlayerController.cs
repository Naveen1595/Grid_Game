using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    float dir = 1;
    float dirV = 1;
    public float speed;
    bool faceRight = true;
    bool faceUp = true;
    float horizontal;
    float vertical;

    public float maxSwipeTime;
    public float minSwipeDistance;

    private float startSwipeTime;
    private float endSwipeTime;

    private Vector2 startSwipePosition;
    private Vector2 endSwipePosition;

    private float swipeLength;
    private float swipeTime;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        playerRB.velocity = new Vector2(dir * speed * Time.deltaTime, playerRB.velocity.y);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        PlayerKeyMoveH();
        PlayerMoveV();
        SwipeTest();
    }
    void Move()
    {
        
        dir = -dir;
        faceRight = !faceRight;
    }

    void MoveV()
    {
        dirV = -dirV;
        faceUp = !faceUp;
    }
    void PlayerKeyMoveH()
    {
        if (horizontal < 0 && faceRight == true && vertical == 0)
        {
            Move();
        }
        else if (horizontal > 0 && faceRight == false && vertical == 0)
        {
            Move();
        }
        
    }

    void PlayerMoveV()
    {
        if (vertical < 0 && faceUp == true && horizontal == 0)
        {
            Debug.Log(vertical);
            MoveV();
        }
        else if (vertical > 0 && faceUp == false && horizontal == 0)
        {
            MoveV();
        }
    }
    void SwipeTest()
    {
        if(Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                startSwipeTime = Time.time;
                startSwipePosition = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                endSwipeTime = Time.time;
                endSwipePosition = touch.position;
                swipeTime = startSwipeTime - endSwipeTime;
                swipeLength = (endSwipePosition - startSwipePosition).magnitude;
                if(swipeTime < maxSwipeTime && swipeLength > minSwipeDistance)
                {
                    SwipeControl();
                }
            }
        }
    }

    void SwipeControl()
    {
        Vector2 Distance = endSwipePosition - startSwipePosition;
        float xDistance = Mathf.Abs(Distance.x);
        float yDistance = Mathf.Abs(Distance.y);
        if(xDistance > yDistance)
        {
            if(Distance.x >0 && faceRight == true)
            {
                Move();
            }
            else if(Distance.x<0 && faceRight == false)
            {
                Move();
            }
        }
    }
}
