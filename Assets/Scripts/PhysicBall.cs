using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PhysicBall : MonoBehaviour
{
    private Transform _tr;
    public Transform _tr1;
    private Vector3 _pos;
    private bool isGronded;
    public bool isRolling;
    private bool _timerOn;
    private float _timeLeft;
    private float _lower;
    [HideInInspector] public float invT;
    [HideInInspector] public int colInt;
    private Vector3 vel;
    private Quaternion toRotation;
    private Vector3 vell6;
    private Vector3 vell5;
    private Vector3 vell;
    private Vector3 vell4;
    private Vector3 vell3;
    private Vector3 vell2;
    private Vector3 grav;
    [SerializeField]private float time;
    [SerializeField]private GameObject ball;
    public bool isFlying;
    private GameObject col;
    public LayerMask layerMask;
    private Vector3 actualForce;
    private Vector3 vell1;
    private RaycastHit hit;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    void Start()
    {
        _tr = transform;
        grav = new Vector3(0, -9.81f, 0);
    }
    public void Rolling(Vector3 force)
    {
        if (isRolling)
        {
            actualForce = new Vector3(force.x, 0, force.y)/5;
                invT += Time.fixedDeltaTime * Time.fixedDeltaTime;
            _lower = Mathf.Clamp(.101f - invT, 0, 1) * Mathf.Clamp(.101f - invT, 0, 1);
            if (_lower > 0)
            {
                switch (colInt)
                {
                    case 0:
                        vel = actualForce * _lower;
                        toRotation = Quaternion.LookRotation(actualForce, Vector3.up);
                        vell = vel;
                        break;
                    case 1:
                        vel = Vector3.Reflect(vell, col.transform.forward) * _lower * 50;
                        toRotation = Quaternion.LookRotation(Vector3.Reflect(vell, Vector3.up));
                        vell1 = vel;
                        break;
                    case 2:
                        vel = Vector3.Reflect(vell1, col.transform.forward) * _lower * 50;
                        toRotation = Quaternion.LookRotation(Vector3.Reflect(vell1, Vector3.up));
                        vell2 = vel;
                        break;
                    case 3:
                        vel = Vector3.Reflect(vell2, col.transform.forward) * _lower * 50;
                        toRotation = Quaternion.LookRotation(Vector3.Reflect(vell2, Vector3.up));
                        vell3 = vel;
                        break;
                    case 4:
                        vel = Vector3.Reflect(vell3, col.transform.forward) * _lower * 50;
                        toRotation = Quaternion.LookRotation(Vector3.Reflect(vell3, Vector3.up));
                        vell4 = vel;
                        break;
                    case 5:
                        vel = Vector3.Reflect(vell4, col.transform.forward) * _lower * 50;
                        toRotation = Quaternion.LookRotation(Vector3.Reflect(vell4, Vector3.up));
                        vell5 = vel;
                        break;
                    case 6:
                        vel = Vector3.Reflect(vell5, col.transform.forward) * _lower * 50;
                        toRotation = Quaternion.LookRotation(Vector3.Reflect(vell5, Vector3.up));
                        vell6 = vel;
                        break;
                }
                Vector3 vel1 = vel;
                _tr.SetPositionAndRotation(new Vector3(_tr.position.x, _tr.position.y, _tr.position.z) + vel1/5, toRotation);
                _tr1.Rotate(Vector3.right * _lower * 500);
            }
            else
            {
                isRolling = false;
                invT = 0;
            } 
        }
    }
    void Update()
    {
        // gravity
        if (!isGronded)
        {
            vel += grav * Time.deltaTime;
            Vector3 posit = _tr.position + vel * Time.deltaTime;
            _tr.position = posit;
        }
        // jump 
        if (_timerOn)
        {
            if (_timeLeft > 0f)
            {
                _timeLeft -= Time.deltaTime;
                _tr.position = Vector3.MoveTowards(_tr.position, _tr.position + new Vector3(0, 19.81f, 0), .3f);
                print("���� �����");
            }
            else
            {
                _timeLeft = time;
                _timerOn = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGronded = true;
            print("is Grounded"+isGronded);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            col = collision.gameObject;
            colInt += 1;
            print("wall");
            if (Physics.OverlapSphere(_tr.position, 1.8f)[0].gameObject.CompareTag("wall"))
            {
                Vector3 colf = Physics.OverlapSphere(_tr.position, 1.8f)[0].transform.position;
                float dis = Vector3.Distance(pos, colf);
                Vector3 colP = pos + (colf - pos) * ((_tr.localScale.x / 2) / dis);
                GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                g.transform.position = colP;
                print(hit.normal);

                //ContactPoint contPoint = collision.contacts[0];

                //if (Physics.Raycast(_tr.position, contPoint.point, out hit, 3f, layerMask))
                //{
                //    print(hit.normal);
                //    print(col.transform.forward);
                //}
            }
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x/2);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGronded = false;
            print("is Grounded" + isGronded);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            print("wallOut");
        }
    }
}
