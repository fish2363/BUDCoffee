using KHG.Interface;
using UnityEngine;

public class Bullet : MonoBehaviour, IThrowable
{
    private Rigidbody _rigid;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    public void Throw(Vector3 direction, float force)
    {
        _rigid.AddForce(direction * force, ForceMode.Impulse);
    }
}
