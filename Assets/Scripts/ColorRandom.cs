using UnityEngine;

public class ColorRandom : MonoBehaviour
{
    private Renderer m_Renderer;

    public void Start()
    {
        m_Renderer = GetComponent<Renderer>();

        Color color = Color.white;
        color.r = Random.Range(0.0f, 1.0f);
        color.g = Random.Range(0.0f, 1.0f);
        color.b = Random.Range(0.0f, 1.0f);

        m_Renderer.material.SetColor("_Color", color);
    }
}
