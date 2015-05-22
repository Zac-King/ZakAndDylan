using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour 
{
    public GameObject m_target; //my target

    private float m_attackRange = 1.5f;
    private float m_moveSpeed = .005f;

    private float m_move;

    private int m_Strength = 1;

    private bool targetDetected = false;
    //private bool alert = false;

    private void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "player")
        {
            m_target = c.gameObject;
            targetDetected = true;
            //alert = true;
        }
    }

    private void attack()
    {
        float distance = Vector3.Distance(transform.position, m_target.transform.position);
        if(distance <= m_attackRange)
        {
            m_target.GetComponent<PlayerStats>().m_currentHealth -= m_Strength;
        }
    }

	void Start () {}
	

	void Update () 
    {
        if(targetDetected == true)
        {
            m_move = Time.deltaTime + m_moveSpeed;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(m_target.transform.position - transform.position), Time.deltaTime * 5);
            transform.position += transform.forward * m_move;
            attack();
        }
	}
}
