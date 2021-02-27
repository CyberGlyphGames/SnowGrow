using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    public float sensitivity = 300f;
    public float turnThreshold = 15f;
    private Vector3 mouseStartPos;

    private Vector3 pointInWorld;
    private Vector3 mousePos;
    private float radius = 3.0f;

    public override void Update()
    {
        /*//current mouse position
        var mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            //if mouse button clicked, the mouse start position sets to current mouse position
            mouseStartPos = mousePos;
        }
        else if (Input.GetMouseButton(0))
        {
            //distance between current mouse position and mouse start position, this is why player doesn't move until after moving mouse away from where you first clicked
            float distance = (mousePos - mouseStartPos).magnitude;

            //if mouse button held, and distance above is greater than 15..
            if(distance > turnThreshold)
            {
                //..and greater than 300..
                if(distance > sensitivity)
                {
                    //..then set mouse start position to current mouse position - current direction * sensitivity / 2? Pretty sure this is to cut or reset the sensitivity if you move your mouse too far away...
                    mouseStartPos = mousePos - (curDir * sensitivity / 2f);
                }

                //else set current direction to where your mouse is currently pointing
                var curDir2D = -(mouseStartPos - mousePos).normalized;
                curDir = new Vector3(curDir2D.x, 0, curDir2D.y);
            }
        }
        else
        {
            //if mouse button not held, use WASD keys for movement
            curDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        }*/

        FollowMouse();

        base.Update();
    }

    private void FollowMouse()
    {
        Ray ray = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 1000.0f);

        mousePos = new Vector3(hit.point.x, 0, hit.point.z);
        curDir = mousePos - transform.position;
        curDir.y = 0;

        pointInWorld = curDir.normalized * radius + transform.position;

        transform.LookAt(pointInWorld);
    }

}
