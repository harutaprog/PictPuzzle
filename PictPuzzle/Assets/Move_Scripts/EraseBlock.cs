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
            if(collision.gameObject.transform.localScale.x < 0)
            {
                _hitPos = new Vector3(Mathf.Ceil(_playerPos.x), (int)_playerPos.y, (int)_playerPos.z);
                if()
                {
                    _beforPos = new Vector3(_hitPos.x, _hitPos.y - 1, _hitPos.z);
                }
            }
            else
            {
                _hitPos = new Vector3(Mathf.Floor(_playerPos.x), (int)_playerPos.y, (int)_playerPos.z);

                _beforPos = new Vector3(_hitPos.x, _hitPos.y - 1, _hitPos.z);

            }
            Erase(_beforPos);
//          Invoke("Erase", 1f);
        }
    }

    private void Erase(Vector3 vector)
    {
        _map.SetTile(new Vector3Int((int)vector.x, (int)vector.y, (int)vector.z), null);
    }
}
