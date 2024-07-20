using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
