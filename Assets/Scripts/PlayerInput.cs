using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public PhysicBall playerBall;
    public TrajectoryCreator trajectoryCreator;
    private float pushForce;
    private Vector2 direction;
    private float distance;
    private float t;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Vector2 force;
    private Vector2 force1;
    private bool isShoot;

    void Start()
    {
        t = .02f;
        pushForce = 40f;
    }

    void Shoot(Vector3 Force)
    {
        isShoot = true;
        playerBall.isRolling = true;
        playerBall.invT = 0f;
        playerBall.colInt = 0;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touches.Length < 2)
        {
            mouseReleasePos = Input.mousePosition;
            distance = Mathf.Clamp(Vector3.Distance(mousePressDownPos, mouseReleasePos),0f,50f);
            direction = (mousePressDownPos - mouseReleasePos).normalized;
            force = direction * distance * pushForce;
            force1 = (1-t)*new Vector2(playerBall.pos.x, playerBall.pos.z)+t*force;
            trajectoryCreator.UpdateDots(playerBall.pos, force1);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Input.touches.Length < 2)
        {
            isShoot = false;
            mousePressDownPos = Input.mousePosition;
            trajectoryCreator.Show();
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Input.touches.Length < 2)
        {
            mouseReleasePos = Input.mousePosition;
            Shoot(force);
            trajectoryCreator.Hide();
        }
    }
    void FixedUpdate()
    {
        if (isShoot)
        {
            playerBall.Rolling(force);
        }
    }
}
