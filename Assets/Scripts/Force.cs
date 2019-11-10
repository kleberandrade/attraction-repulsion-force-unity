using UnityEngine;

public class Force : MonoBehaviour
{
    public enum ForceType { Repulsion = -1, None = 0, Attraction = 1 }
    public ForceType m_Type;
    public Transform m_Pivot;
    public float m_Radius;
    public float m_StopRadius;
    public float m_Force;
    public LayerMask m_Layers;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(m_Pivot.position, m_Radius, m_Layers);

        float signal = (float)m_Type;

        foreach (var collider in colliders)
        {
            Rigidbody body = collider.GetComponent<Rigidbody>();
            if (body == null) 
                continue;

            Vector3 direction = m_Pivot.position - body.position;

            float distance = direction.magnitude;

            direction = direction.normalized;

            if (distance < m_StopRadius) 
                continue;

            float forceRate = (m_Force / distance);

            body.AddForce(direction * (forceRate / body.mass) * signal);
        }
    }
}
