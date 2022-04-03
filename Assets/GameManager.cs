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

    [SerializeField] bool _gamePause = true;

    [SerializeField] Item.ItemType _requiredItemType;

    [SerializeField] float _playerHealth;
    [SerializeField] TimeSpan _elapsedTime;
    [SerializeField] int _correctItems;
    [SerializeField] int _wrongItems;
    [SerializeField] int _spawnRate;


    public void OnStartNew()
    {
        _playerHealth = gameSettings.MaxPlayerHealth;
        _elapsedTime = TimeSpan.Zero;
        _gamePause = false;
        
        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = 1f });
        onSpawnRateUpdate.Invoke(new OnSpawnRateUpdateArgs() { newSpawnRate = _spawnRate });
    }

    public void OnResume()
    {
        _gamePause = false;
        onSpawnRateUpdate.Invoke(new OnSpawnRateUpdateArgs() { newSpawnRate = _spawnRate });
    }

    public void OnPause()
    {
        _gamePause = true;
        onSpawnRateUpdate.Invoke(new OnSpawnRateUpdateArgs() { newSpawnRate = 0f });
    }

    public void OnItemCollect(GameEventArgs onItemCollectArgs)
    {
        OnItemCollectArgs args = (OnItemCollectArgs)onItemCollectArgs;

        if (args.type == _requiredItemType)
        {
            _correctItems++;
            IncreasePlayerHealth();
        }
        else
        {
            _wrongItems++;
            DecreasePlayerHealth();
        }
    }

    void DecreasePlayerHealth()
    {
        _playerHealth -= gameSettings.HealthDecreaseOnHit;
        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = _playerHealth / gameSettings.MaxPlayerHealth });
    }

    void IncreasePlayerHealth()
    {
        _playerHealth += gameSettings.HealthIncreaseOnHeal;
        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = _playerHealth / gameSettings.MaxPlayerHealth });
    }

    void DecayPlayerHealth()
    {
        _playerHealth -= gameSettings.PassiveHealthDecrease;
        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = _playerHealth / gameSettings.MaxPlayerHealth });
    }

    void GameOver()
    {
        _gamePause = true;
        
        onSpawnRateUpdate.Invoke(new OnSpawnRateUpdateArgs() { newSpawnRate = 0f });
        onGameOver.Invoke(new OnGameOverArgs()
        {
            timeSurvived = _elapsedTime,
            correctItems = _correctItems,
            wrongItems = _wrongItems,
            score = _correctItems - _wrongItems
        });
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
    }
}
