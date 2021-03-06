using Assets.Scripts.Scriptable_Objects;
using Assets.Scripts.Utilities;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;

    [Header("Events")]
    [SerializeField] GameEvent onHealthUpdate;
    [SerializeField] GameEvent onGameOver;
    [SerializeField] GameEvent onSpawnRateUpdate;
    [SerializeField] GameEvent onRequiredItemChanged;
    [SerializeField] GameEvent onPlayerDamage;
    [SerializeField] GameEvent onScoreUpdate;

    [SerializeField] bool _gamePause = true;

    [SerializeField] Item.ItemType _requiredItemType;

    [SerializeField] float _playerHealth;
    [SerializeField] TimeSpan _elapsedTime;
    [SerializeField] int _correctItems;
    [SerializeField] int _wrongItems;
    [SerializeField] float _spawnRate;

    public void OnStartNew()
    {
        ResetStats();
        _spawnRate = 2f;
        _playerHealth = gameSettings.MaxPlayerHealth;
        _elapsedTime = TimeSpan.Zero;

        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = 1f });

        StartGameplay();
        ChangeRequiredItem();
    }

    public void OnResume()
    {
        StartGameplay();
    }

    public void OnPause()
    {
        PauseGameplay();
    }

    public void OnItemCollect(GameEventArgs onItemCollectArgs)
    {
        OnItemCollectArgs args = (OnItemCollectArgs)onItemCollectArgs;

        if (args.type == _requiredItemType)
        {
            _correctItems++;
            IncreasePlayerHealth();
            onScoreUpdate.Invoke(new OnScoreUpdateArgs() { newScore = _correctItems });
        }
        else
        {
            _wrongItems++;
            DecreasePlayerHealth();
            onPlayerDamage.Invoke();
        }

        ChangeRequiredItem();
    }

    void DecreasePlayerHealth()
    {
        _playerHealth -= gameSettings.HealthDecreaseOnHit;
        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = _playerHealth / gameSettings.MaxPlayerHealth });
    }

    void IncreasePlayerHealth()
    {
        _playerHealth = Mathf.Clamp(_playerHealth + gameSettings.HealthIncreaseOnHeal, 0, gameSettings.MaxPlayerHealth);
        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = _playerHealth / gameSettings.MaxPlayerHealth });
    }

    void DecayPlayerHealth()
    {
        _playerHealth -= ((gameSettings.PassiveHealthDecreaseOverTime.Evaluate((float)_elapsedTime.TotalSeconds) *
            (gameSettings.MaxPassiveHealthDecrease - gameSettings.MinPassiveHealthDecrease)) + gameSettings.MinPassiveHealthDecrease)
            * Time.deltaTime;
        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = _playerHealth / gameSettings.MaxPlayerHealth });
    }

    void UpdateSpawnRate()
    {
        if (_gamePause) return;

        _spawnRate = (gameSettings.SpawnRateOverTime.Evaluate((float)_elapsedTime.TotalSeconds) *
            (gameSettings.MaxSpawnRate - gameSettings.MinSpawnRate)) + gameSettings.MinSpawnRate;
        onSpawnRateUpdate.Invoke(new OnSpawnRateUpdateArgs() { newSpawnRate = _spawnRate });
    }

    void GameOver()
    {
        PauseGameplay();
        onGameOver.Invoke(new OnGameOverArgs()
        {
            timeSurvived = _elapsedTime,
            correctItems = _correctItems,
            wrongItems = _wrongItems,
            score = _correctItems
        });
        ResetStats();
    }

    void PauseGameplay()
    {
        _gamePause = true;
        onSpawnRateUpdate.Invoke(new OnSpawnRateUpdateArgs() { newSpawnRate = 0f });
    }

    void StartGameplay()
    {
        _gamePause = false;
        onSpawnRateUpdate.Invoke(new OnSpawnRateUpdateArgs() { newSpawnRate = _spawnRate });
    }

    void ResetStats()
    {
        _playerHealth = gameSettings.MaxPlayerHealth;
        _elapsedTime = TimeSpan.Zero;
        _correctItems = 0;
        _wrongItems = 0;
        _spawnRate = 0;
    }

    void Update()
    {
        if (_gamePause)
        {
            return;
        }

        _elapsedTime += TimeSpan.FromSeconds(Time.deltaTime);

        if (_playerHealth <= 0)
        {
            GameOver();
        }

        DecayPlayerHealth();
        UpdateSpawnRate();
    }

    void ChangeRequiredItem()
    {
        _requiredItemType = (Item.ItemType)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Item.ItemType)).Length);
        onRequiredItemChanged.Invoke(new OnRequiredItemChangeArgs() { type = _requiredItemType });
    }
}
