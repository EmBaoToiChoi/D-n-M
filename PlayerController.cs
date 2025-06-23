using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;
public class PlayerController : MonoBehaviour
{
    public int level = 1;
    public int score = 0;
    public int hp = 100;
    private SaveManager saveManager;

    void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
        if (saveManager == null)
        {
            Debug.LogError("SaveManager not found in the scene!");
        }
    }

    void Update()
    {
        // Nhấn S để lưu game
        if (Input.GetKeyDown(KeyCode.S))
{
    saveManager.SaveGame(level, score, hp, transform.position);
}

        // Nhấn L để tải game
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerData data = saveManager.LoadGame();
            if (data != null)
{
    level = data.level;
    score = data.score;
    hp = data.hp; // ➕ Load máu
    transform.position = data.position;
    Debug.Log($"Loaded Level: {level}, Score: {score}, HP: {hp}, Position: {transform.position}");
}
        }
    }
}
