using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {
        // reference to player
        private ThirdPersonCharacter _player;

        // reference to goal effect
        private GoalEffect _goalEffect;

        // reference to player
        private Objective _objective;

        private bool _isGameOver;
        private bool _isObjectiveNotNull;
        public bool IsGameOver { get { return _isGameOver; } }


        // initialize references
        private void Start()
        {
            _isObjectiveNotNull = _objective != null;
        }

        private void Awake()
        {
            _player = Object.FindObjectOfType<ThirdPersonCharacter>();
            _objective = Object.FindObjectOfType<Objective>();
            _goalEffect = Object.FindObjectOfType<GoalEffect>();
        }

        // end the level
        public void EndLevel()
        {
            //mylogs Probably remove this later
            if (Debug.isDebugBuild) Debug.Log($"<color=purple>End Game Called</color>");

            if (_player != null)
            {
                // disable the player controls
                ThirdPersonUserControl thirdPersonControl =
                    _player.GetComponent<ThirdPersonUserControl>();

                if (thirdPersonControl != null)
                {
                    thirdPersonControl.enabled = false;
                }

                // remove any existing motion on the player
                Rigidbody rbody = _player.GetComponent<Rigidbody>();
                if (rbody != null)
                {
                    rbody.velocity = Vector3.zero;
                }

                // force the player to a stand still
                _player.Move(Vector3.zero, false, false);
            }

            // check if we have set IsGameOver to true, only run this logic once
            if (_goalEffect != null && !_isGameOver)
            {
                _isGameOver = true;
                _goalEffect.PlayEffect();
                
                SceneManager.LoadScene("Level2");
            }
        }

        // check for the end game condition on each frame
        private void Update()
        {
            if (_isObjectiveNotNull & _objective.IsComplete)
            {
                EndLevel();
            }
        }

    }
}