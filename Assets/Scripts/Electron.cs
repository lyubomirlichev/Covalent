using System;
using System.Collections;
using UnityEngine;

public class Electron : MonoBehaviour
{
    public Action OnFired;
    private Vector3 direction;
    
    private float projectileSpeed = 0.02f;
    
    public void Init()
    {
        OnFired += () =>
        {
            direction = transform.position - transform.parent.position;
            direction.Normalize();
            transform.SetParent(null,true);
            
            StartCoroutine(FlyOut());
        };
    }

    private IEnumerator FlyOut()
    {
        while (true)
        {
            transform.position += direction * projectileSpeed;
            yield return null;
        }
    }
    
}