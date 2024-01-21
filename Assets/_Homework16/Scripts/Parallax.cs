using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _parallaxEffect = 0;
    
    private float _spriteLenght;
    private float _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position.x;
        _spriteLenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tempPosition = _camera.transform.position.x * (1 - _parallaxEffect);
        float distPosition = _camera.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPosition + distPosition, transform.position.y, transform.position.z);

        if (tempPosition > _startPosition + _spriteLenght) _startPosition += _spriteLenght;
        else if (tempPosition < _startPosition - _spriteLenght) _startPosition -= _spriteLenght;
    }
}
