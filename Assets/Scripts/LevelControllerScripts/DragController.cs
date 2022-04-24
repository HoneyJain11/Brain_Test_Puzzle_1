using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    float startPosX;
    float startPosY;
    bool isBeingHeld = false;
    public Level8Controller controller;

    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 pos = Input.mousePosition;
            pos = Camera.main.ScreenToWorldPoint(pos);
            this.gameObject.transform.localPosition = new Vector3(pos.x - startPosX, pos.y - startPosY, 0);
        }

    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true;

        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>())
        {
            this.gameObject.SetActive(false);
            controller.CounterUpdate();
        }
    }
}
