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

    [SerializeField] bool _gamePause = true;

    [SerializeField] Item.ItemType _requiredItemType;

    [SerializeField] float _playerHealth;
    [SerializeField] TimeSpan _elapsedTime;
    [SerializeField] int _correctItems;
    [SerializeField] int _wrongItems;
    

    public void OnStartNew()
    {
        _playerHealth = gameSettings.MaxPlayerHealth;
        _elapsedTime = TimeSpan.Zero;

        onHealthUpdate.Invoke(new OnHealthUpdateArgs() { value = 1f });
    }

    public void OnResume()
    {
        _gamePause = false;
    }

    public void OnPause()
    {
        _gamePause = true;
    }

    public void OnItemCollect(GameEventArgs onItemCollectArgs)
    {
        OnItemCollectArgs args = (OnItemCollectArgs)onItemCollectArgs;

        Debug.Log("Item Collected: " + args.type);

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
