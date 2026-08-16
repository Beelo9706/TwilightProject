using UnityEngine;

public class HitBoxes : MonoBehaviour
{
    public Collider2D hitBox1;
    public void ColliderEnabled()
    {
        hitBox1.enabled = true;
    }

    public void ColliderDisabled()
    {
        hitBox1.enabled = false;
    }
}
