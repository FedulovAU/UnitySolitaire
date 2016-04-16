using UnityEngine;
using System;

public class Button : MonoBehaviour
{

    public Transform pressed;
    public Transform released;
    public event Action<Transform> Triggered;

    public string pressedLabel;
    public string releasedLabel;


    private BoxCollider2D collider;
    private Vector3 worldPoin;
    private Vector2 screenPoin;

    private TextMesh textMesh;

    private bool isPressed = false;

    
    void Start () {

        textMesh = gameObject.GetComponentInChildren<TextMesh>();

        collider = GetComponent<BoxCollider2D>();
        isPressed = false;
        setState();
    }
	
	// Update is called once per frame
	void Update () {

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 1)
        {
            Debug.Log("here!");
            worldPoin = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            screenPoin = new Vector2(worldPoin.x, worldPoin.y);
            if (collider == Physics2D.OverlapPoint(screenPoin))
            {
                isPressed = true;
                pressed.gameObject.SetActive(isPressed);
                released.gameObject.SetActive(!isPressed);
            }
        }
#else
        if (!isPressed && Input.GetMouseButton(0))
        {
            worldPoin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            screenPoin = new Vector2(worldPoin.x, worldPoin.y);
            if (collider == Physics2D.OverlapPoint(screenPoin))
            {
                isPressed = true;
                setState();
            }
        } else if (isPressed && !Input.GetMouseButton(0))
        {
            isPressed = false;
            setState();

            if (Triggered != null)
            {
                Triggered(transform);
            }


        }
#endif


    }

    private void setState()
    {
        if (isPressed)
        {
            textMesh.text = pressedLabel;
        } else
        {
            textMesh.text = releasedLabel;
        }
        pressed.gameObject.SetActive(isPressed);
        released.gameObject.SetActive(!isPressed);
    }


}
