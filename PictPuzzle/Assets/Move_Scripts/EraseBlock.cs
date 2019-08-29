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
            _playerPos = new Vector3(Mathf.Round(_playerPos.x), Mathf.FloorToInt((int)_playerPos.y), _playerPos.z);
            if (_playerPos != PlayerPosBefor)
            {
                PlayerPosBefor = new Vector3Int((int)_playerPos.x, (int)_playerPos.y - 1, (int)_playerPos.z);
            }
            Erase(ErasePos);
            ErasePos = PlayerPosBefor;

        }
    }
    private void Erase(Vector3Int vector)
    {
        _map.SetTile(vector, null);
    }
}
