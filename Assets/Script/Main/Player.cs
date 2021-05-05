using UnityEngine;

public class Player : MonoBehaviour
{
    public Swipe swipeControl;

    Transform player;
    [SerializeField]float step = 0.05f;
    Vector2 moveDirection;
    public Vector2 WorldUnitsInCamera;
    public GameObject Camera;

    private void Awake()
    {
        //Finding Pixel To World Unit Conversion Based On Orthographic Size Of Camera
        WorldUnitsInCamera.y = Camera.GetComponent<Camera>().orthographicSize * 2;
        WorldUnitsInCamera.x = WorldUnitsInCamera.y * Screen.width / Screen.height;
        
    }

    private void Start()
    {
        player = gameObject.transform;
        moveDirection = player.transform.position;
        player.position = moveDirection;
    }


    private void FixedUpdate()
    {
        Move();
    }


    private void Update()
    {
        Control();
        SwipeControl();
        ScreenBound();
    }

    void SwipeControl()
    {
        if (swipeControl.SwipeUp)
        {
            moveDirection = Vector2.up;
        }
        else if (swipeControl.SwipeDown)
        {
            moveDirection = Vector2.down;
        }
        else if (swipeControl.SwipeLeft)
        {
            moveDirection = Vector2.left;
        }
        else if (swipeControl.SwipeRight)
        {
            moveDirection = Vector2.right;
        }

    }

    void ScreenBound()
    {
        //right
        if (gameObject.transform.position.x > WorldUnitsInCamera.x / 2)
        {
            Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            pos.x = -(WorldUnitsInCamera.x / 2);
            gameObject.transform.position = pos;
        }
        //left
        if (gameObject.transform.position.x < -(WorldUnitsInCamera.x / 2))
        {
            Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            pos.x = WorldUnitsInCamera.x / 2;
            gameObject.transform.position = pos;
        }
        //up
        if (gameObject.transform.position.y > WorldUnitsInCamera.y / 2)
        {
            Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            pos.y = -(WorldUnitsInCamera.y / 2);
            gameObject.transform.position = pos;
        }
        //down
        if (gameObject.transform.position.y < -(WorldUnitsInCamera.y / 2))
        {
            Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            pos.y = WorldUnitsInCamera.y / 2;
            gameObject.transform.position = pos;
        }
    }



    void Control()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = Vector2.right;
        }
        
    }

    void Move()
    {
        player.up = moveDirection;
        player.position += player.up * step;
    }

}
