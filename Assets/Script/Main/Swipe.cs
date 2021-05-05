﻿using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        swipeLeft = swipeRight = swipeUp = swipeDown = false;

        if(Input.touches.Length > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if((Input.touches[0].phase == TouchPhase.Ended) || (Input.touches[0].phase == TouchPhase.Canceled))
            {
                isDragging = false;
                Reset();
            }
        }
        

        //Calculate the Distance
        swipeDelta = Vector2.zero;
        if(isDragging)
        {
            if(Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }

        }

        //Did we cross the deadzone?
        if(SwipeDelta.magnitude > 100)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if(x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                //Up or Down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }
            }
        }
    }

     
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeUp { get { return swipeUp; } }
}
