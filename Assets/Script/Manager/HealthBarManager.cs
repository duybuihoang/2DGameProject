using DuyBui.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DuyBui
{
    public class HealthBarManager : MonoBehaviour
    {
        private Stats playerStats;
        private Slider healthBarSlider;

        private void Awake()
        {
            healthBarSlider = GetComponentInChildren<Slider>();
            var player = GameObject.Find("Player").gameObject;
            playerStats = player?.GetComponentInChildren<Stats>();
        }

        private void OnEnable()
        {
            playerStats.OnHealthChange += SetValue;
        }

        private void OnDisable()
        {
            playerStats.OnHealthChange -= SetValue;
        }

        private void SetValue(float ratio)
        {
            healthBarSlider.value = ratio;
        }
    }
}
