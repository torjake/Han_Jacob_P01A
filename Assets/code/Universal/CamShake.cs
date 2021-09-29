using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField] private GameObject _red;
    public IEnumerator Shake(float _duration, float _magnitude)
    {
        Vector3 _originalPos = transform.localPosition;

        float _elapsed = 0f;

        while (_elapsed < _duration)
        {
            float x = Random.Range(-1f, 1f) * _magnitude;
            float y = Random.Range(-1f, 1f) * _magnitude;

            transform.localPosition = new Vector3(x, y, _originalPos.z);

            _red.SetActive(true);

            _elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _originalPos;
        _red.SetActive(false);
    }
    private void Start()
    {
        //StartCoroutine(Shake(0.5f, 4f));
    }
}
