using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EraseBlock : MonoBehaviour
{
    public Vector3 _playerPos;
    private Tilemap _map;
    public Vector3Int PlayerPosBefor;
    public Vector3Int ErasePos;
    // Start is called before the first frame update

    private void Start()
    {
        _map = gameObject.GetComponent<Tilemap>();
        _playerPos =  PlayerPosBefor = new Vector3Int(100, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerPos != PlayerPosBefor)
        {
            Debug.Log(_playerPos);
            Erase(PlayerPosBefor);
            PlayerPosBefor = new Vector3Int((int)_playerPos.x, (int)_playerPos.y, (int)_playerPos.z);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _playerPos = collision.gameObject.transform.position;
            _playerPos = new Vector3(Mathf.Round(_playerPos.x), Mathf.Round(_playerPos.y), _playerPos.z);
            // Erase(ErasePos);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Erase(PlayerPosBefor);
        }
    }
        private void Erase(Vector3Int vector)
    {
        if (vector.x < 100 || vector.x > -100)
        { 
        _map.SetTile(new Vector3Int(vector.x, vector.y - 1, vector.z), null);
        }
    }
}
