using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject m_Prefab;
    public int m_Numbers = 100;
    public float m_Radius = 20;
    public float m_MinScale = 0.3f;
    public float m_MaxScale = 1.0f;

    private void Start()
    {
        for (int i = 0; i < m_Numbers; i++)
        {
            // Criação do objeto
            Vector3 position = Random.insideUnitSphere * m_Radius;
            Quaternion rotation = Quaternion.Euler(Random.insideUnitSphere * 360.0f);
            GameObject go = Instantiate(m_Prefab, position, rotation);
            // Configuração escala e peso
            go.transform.localScale = Vector3.one * Random.Range(m_MinScale, m_MaxScale);
            go.GetComponent<Rigidbody>().mass = go.transform.localScale.magnitude;
        }
    }

}
