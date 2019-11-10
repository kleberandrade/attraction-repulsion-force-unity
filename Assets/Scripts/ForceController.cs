using UnityEngine;
using UnityEngine.UI;

public class ForceController : MonoBehaviour
{
    private Force m_Controller;
    public float m_Step = 1.0f;
    public Text m_Text;

    private void Awake()
    {
        m_Controller = GetComponent<Force>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            m_Controller.m_Type = Force.ForceType.Repulsion;

        if (Input.GetKeyDown(KeyCode.A))
            m_Controller.m_Type = Force.ForceType.Attraction;

        if (Input.GetKeyDown(KeyCode.N))
            m_Controller.m_Type = Force.ForceType.None;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            m_Controller.m_Radius += m_Step * Time.deltaTime;
            m_Controller.transform.localScale = Vector3.one * m_Controller.m_Radius * 2.0f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Controller.m_Radius -= m_Step * Time.deltaTime;
            m_Controller.transform.localScale = Vector3.one * m_Controller.m_Radius * 2.0f;
        }


        m_Text.text = m_Controller.m_Type.ToString();
    }
}
