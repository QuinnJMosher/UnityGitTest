using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ButtonScript : MonoBehaviour {

    public UnityEvent onPresed;
    public UnityEvent onUnpressed;

    public Sprite unpressedSprite;
    public Sprite pressedSprite;

    public Transform activatorCheck;
    public LayerMask whatIsActivator0;
    public LayerMask whatIsActivator1;
    public LayerMask whatIsActivator2;
    float playerCheckRadius = 0.2f;
    bool activated = false;

    public bool startPressed = false;
    public float unpressTime = 0.5f;
    public bool mustLeave = true;
    public bool stayPressed = false;

    bool isPressed;
    float unacivatedTime;

	// Use this for initialization
	void Start () {
        isPressed = startPressed;
	
	}
	
	// Update is called once per frame
	void Update () {
        unacivatedTime += Time.deltaTime;

        activated = false;
        if (Physics2D.OverlapCircle(activatorCheck.position, playerCheckRadius, whatIsActivator0) ||
            Physics2D.OverlapCircle(activatorCheck.position, playerCheckRadius, whatIsActivator1) ||
            Physics2D.OverlapCircle(activatorCheck.position, playerCheckRadius, whatIsActivator2))
        {
            activated = true;
        }

        if (activated && !isPressed)
        {
            onPresed.Invoke();
            isPressed = true;
            unacivatedTime = 0;
        }

        if (isPressed && unacivatedTime >= unpressTime)
        {

            if (mustLeave)
            {
                if (activated)
                {
                    unacivatedTime = 0;
                }
                else
                {
                    if (!stayPressed)
                    {
                        isPressed = false;
                        onUnpressed.Invoke();
                    }
                }
            }
            else
            {
                if (!stayPressed)
                {
                    isPressed = false;
                    onUnpressed.Invoke();
                }
            }

        }

        if (isPressed)
        {
            GetComponent<SpriteRenderer>().sprite = pressedSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = unpressedSprite;
        }

	}
}
