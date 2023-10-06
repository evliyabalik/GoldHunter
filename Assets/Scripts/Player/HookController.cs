using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    PlayerController player;

    GameObject m_valuableObject;

    int m_score;
    ValuableObject valuable;

    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        player.isInteraction = true;

        if (collision.CompareTag("Player"))
        {
           if(m_valuableObject!=null)
                SetScore(valuable);

            player.ResetTransform();
        }

        if (collision.CompareTag("Diamond") || collision.CompareTag("Gold"))
        {
            if(m_valuableObject==null)
                m_valuableObject = collision.gameObject;

            m_valuableObject.transform.position = new Vector2(transform.position.x,transform.position.y-.5f);


            m_valuableObject.transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y,-transform.rotation.z,0);
            valuable = m_valuableObject.GetComponent<ValuableObject>();
            valuable.IsInParent(transform);
        }
    }

    void SetScore(ValuableObject valuable)
    {
        valuable.IsInParent(m_valuableObject.transform);
        m_score += valuable.value;
        GameManager.instance.SetScore(m_score);
        Destroy(m_valuableObject);
    }
}
