using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForce : MonoBehaviour
{
    public float force = 10f;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            TestPlayerController controller = collision.gameObject.GetComponent<TestPlayerController>();
            if (controller != null)
            {
                controller.ApplyExternalForce(direction * force);
            }
        }
    }
}
