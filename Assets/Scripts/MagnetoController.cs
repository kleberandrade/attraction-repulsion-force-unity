using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagnetoController : MonoBehaviour
{
    private Magnetism m_Controller;
    public float m_Step = 1.0f;
    public Text m_Text;

    private void Awake()
    {
        m_Controller = GetComponent<Magnetism>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            m_Controller.m_Type = Magnetism.MagnetismType.Repulsion;

        if (Input.GetKeyDown(KeyCode.A))
            m_Controller.m_Type = Magnetism.MagnetismType.Attraction;

        if (Input.GetKeyDown(KeyCode.N))
            m_Controller.m_Type = Magnetism.MagnetismType.None;

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
