using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Texture2D Normal;
    [SerializeField] private Texture2D Shoot;
    [SerializeField] private Texture2D Reload;
    private Vector2 hotspost = new Vector2(16, 48);
    void Start()
    {
        Cursor.SetCursor(Normal, hotspost, CursorMode.Auto);
        if (GameObject.FindWithTag("Player") == null)
        {
            Vector3 spawnPos = Vector3.zero;

            if (SceneManager.GetActiveScene().name == GameData.LastScene && GameData.LastDeathPosition != Vector3.zero)
            {
                spawnPos = GameData.LastDeathPosition;
            }

            Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        }
        if (GameObject.FindWithTag("Player2") == null)
    {
        Vector3 spawnPos = Vector3.zero;

        if (SceneManager.GetActiveScene().name == GameData.LastScene &&
            GameData.LastDeathPosition != Vector3.zero)
        {
            spawnPos = GameData.LastDeathPosition;
        }

        Instantiate(playerPrefab, spawnPos, Quaternion.identity);
    }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(Shoot, hotspost, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(Normal, hotspost, CursorMode.Auto);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(Reload, hotspost, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Cursor.SetCursor(Normal, hotspost, CursorMode.Auto);
        }
    }
    public GameObject playerPrefab;
   
}
