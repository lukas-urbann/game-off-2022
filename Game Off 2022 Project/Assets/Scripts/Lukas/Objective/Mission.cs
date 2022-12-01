using System;
using System.Collections;
using System.Collections.Generic;
using Lukas.Triggers;
using TMPro;
using UnityEngine;

namespace Lukas.Objective
{
    public class Mission : MonoBehaviour
    {
        public static Mission Instance;
        [SerializeField] private TMP_Text missionLabel;
        [SerializeField] private Animator missionAnimator;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        private void Start()
        {
            if (GetComponent<TMP_Text>() != null && GetComponent<Animator>() != null)
            {
                missionAnimator = GetComponent<Animator>();
                missionLabel = GetComponent<TMP_Text>();
            }
        }

        public void UpdateMission(string mission, float seconds)
        {
            missionLabel.text = mission;
            StartCoroutine(DisplayMissionLabel(seconds));
        }

        private IEnumerator DisplayMissionLabel(float seconds)
        {
            missionAnimator.Play("ObjectiveAppear");
            yield return new WaitForSeconds(seconds);
            missionAnimator.Play("ObjectiveDisappear");
        }
    }
}
