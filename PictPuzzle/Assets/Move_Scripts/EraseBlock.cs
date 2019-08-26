using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EraseBlock : MonoBehaviour
{
    private Vector3 _hitPos;
    private Vector3 _playerPos;

    public  Vector3 _beforPos, _afterPos;

    private Tilemap _map;
    // Start is called before the first frame update

    private void Start()
    {
        _map = gameObject.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerPos = collision.gameObject.transform.position;
            if (_playerPos.x < 0)
            {
                _hitPos = new Vector3(Mathf.Floor(_playerPos.x), (int)_playerPos.y, (int)_playerPos.z);
                if(_beforPos.x == _hitPos.x)
                {
                    Erase();
                }
            }
            else
            {
                _hitPos = new Vector3(Mathf.Ceil(_playerPos.x), (int)_playerPos.y, (int)_playerPos.z);
                 if(_beforPos.x == _hitPos.x)
                {
                    Erase();
                }
            }
            Debug.Log(_hitPos + _playerPos);
            _beforPos = new Vector3(_hitPos.x,_hitPos.y - 1,_hitPos.z);
            
        }
    }

    private void Erase()
    {
        _map.SetTile(new Vector3Int((int)_beforPos.x, (int)_beforPos.y, (int)_beforPos.z), null);
    }
}
