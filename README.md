# Simple Magnetism for Games in Unity

Example of an attraction and repulsion magnetism for games

<p align="center">
  <img width="600" src="Images/magnetism.gif">
</p>

## Methods

First, we calculate the object direction to magnetic center. Where *D* is the vector direction, *P* is the object and *C* is the maginetic center.

<img src="http://www.sciweavers.org/tex2img.php?eq=D%20%3D%20C%20-%20P&bc=White&fc=Black&im=jpg&fs=12&ff=arev&edit=0" align="center" border="0" alt="D = C - P" width="83" height="17" />

First, we calculate the force proportional to distance from object to magnetic center. Where *F* is the proportional force, *F_{max}* is the maximum force and *D* is the distance from the object to the magnetic center.

<img src="http://www.sciweavers.org/tex2img.php?eq=F%20%3D%20%5Cfrac%7BF_%7Bmax%7D%7D%7B%7CD%7C%7D&bc=White&fc=Black&im=jpg&fs=12&ff=arev&edit=0" align="center" border="0" alt="F = \frac{F_{max}}{|D|}" width="76" height="46" />

Finally, we calculate the vector force according to the attraction or repulsion function. Where *f* is the vector force applied to the object, *\sigma* is the type of magnetism (none, repulsion or attraction) and *m* is the mass of the object.

<img src="http://www.sciweavers.org/tex2img.php?eq=%5Csigma%20%3D%20%5Cbegin%7Bcases%7D-1%20%26%20%5Ctext%7B%20if%20%7D%20repulsion%20%5C%5C%200%20%26%20%5Ctext%7B%20if%20%7D%20none%20%5C%5C%201%20%26%20%5Ctext%7B%20if%20%7D%20attraction%20%5Cend%7Bcases%7D&bc=White&fc=Black&im=jpg&fs=12&ff=arev&edit=0" align="center" border="0" alt="\sigma = \begin{cases}-1 & \text{ if } repulsion \\ 0 & \text{ if } none \\ 1 & \text{ if } attraction \end{cases}" width="203" height="81" />

<img src="http://www.sciweavers.org/tex2img.php?eq=f%20%3D%20D%20%5Cfrac%7BF%7D%7Bm%7D%5Csigma&bc=White&fc=Black&im=jpg&fs=12&ff=arev&edit=0" align="center" border="0" alt="f = D \frac{F}{m}\sigma" width="79" height="43" />

## Code

Basic code created from equations

```csharp
public class Magnetism : MonoBehaviour
{
    public enum MagnetismType { Repulsion = -1, None = 0, Attraction = 1 }
    public MagnetismType m_Type;
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
            if (body == null) continue;

            Vector3 direction = m_Pivot.position - body.position;

            float distance = direction.magnitude;

            direction = direction.normalized;

            if (distance < m_StopRadius) continue;

            float forceRate = (m_Force / distance);

            body.AddForce(direction * (forceRate / body.mass) * signal);
        }
    }
}
```

## License

    Copyright 2019 Kleber de Oliveira Andrade
    
    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:
    
    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.
    
    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.
