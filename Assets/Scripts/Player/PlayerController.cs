using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_movementSpeed;
    [SerializeField] float m_rotateSpeed;
    [SerializeField] GameObject m_hook;
    [SerializeField] Transform m_hookStartTransform;

    Rigidbody2D m_rigidbody;
    float m_raidus = 1;
    float m_angle = 0;
    public bool isMove = false;
    public bool isInteraction = false;


    // Start is called before the first frame update
    void Start()
    {

        m_rigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isMove)
            HookRotate();
        else
        {
            if (!isInteraction)
                HookMovement(-m_hook.transform.up);
            else
                HookMovement(m_hook.transform.up);
        }
       

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isMove = true;
    }

    void HookRotate()
    {
        if (transform.rotation.z > 0.45f)
            m_raidus = -1;
        else if (transform.rotation.z < -0.45f)
            m_raidus = 1;


        var rotation = transform.rotation;
        rotation.z = Mathf.Cos(m_angle) * m_raidus / 2;

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * m_rotateSpeed).normalized;

    }

    void HookMovement(Vector2 hookTransform)
    {

        m_rigidbody.velocity = hookTransform * Time.deltaTime * m_movementSpeed;

        
    }

    public void ResetTransform()
    {
        isInteraction = false;
        isMove = false;

        m_rigidbody.velocity=Vector3.zero;
        
        transform.rotation = Quaternion.identity;
        m_hook.transform.position = m_hookStartTransform.position;
    
        m_hook.transform.rotation = Quaternion.identity;
      
    }
}



