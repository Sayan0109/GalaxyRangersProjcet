using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

[System.Serializable]
public class PlayerShipRuntimeData {
    
    public ShipData shipData; //ссылка на ScriptableObject

    public GameObject shipPrefab;

    //Runtime переменные
    public float maxHealth;
    public float currentHealth;

    public float damage;
    public float maxSpeed;
    public float rotationSpeed;

    //*не уверен до конца если они будут изменяться
    // public float fireRate;
    // public float abilityCooldown;
    // public float abilityDuration;

    //Способностей пока нету

    // Конструктор
    public PlayerShipRuntimeData(ShipData shipData) {
        this.shipData = shipData;
        
        shipPrefab = shipData.shipPrefab;

        //копирование базовых переменных
        maxHealth = shipData.maxHealth;
        currentHealth = maxHealth;

        damage = shipData.damage;
        maxSpeed = shipData.maxSpeed;
        rotationSpeed = shipData.rotationSpeed;

        // //*не уверен до конца если они будут изменяться
        // fireRate = shipData.fireRate;
        // abilityCooldown = shipData.abilityCooldown;
        // abilityDuration = shipData.abilityDuration;

        //Способностей пока нету
    }

    //Улучшения чтобы было проще применять через сторонние скрипты

    public void AddHealth(float value) {
        maxHealth += value;
        currentHealth += value;
    }

    public void AddDamage(float value) {
        damage += value;
    }

    public void AddSpeed(float speedValue, float rotationValue) {
        maxSpeed += speedValue;
        rotationSpeed += rotationValue;
    }
}
