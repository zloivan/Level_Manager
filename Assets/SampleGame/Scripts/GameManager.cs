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

        [SerializeField] private string _levelName = "Level2";
        [SerializeField] private int _levelIndex = 0;
        
        // initialize references
        private void Start()
        {
            _isObjectiveNotNull = _objective != null;
        }

        private void Awake()
        {
            _player = FindObjectOfType<ThirdPersonCharacter>();
            _objective = FindObjectOfType<Objective>();
            _goalEffect = FindObjectOfType<GoalEffect>();
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

                LoadLevel(_levelIndex);
            }
        }

        public static void LoadLevel(string sceneName)
        {
            var isSceneValid = Application.CanStreamedLevelBeLoaded(sceneName);

            if (isSceneValid)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: Invalid scene name!");
            }
            
        }
        
        public static void LoadLevel(int sceneIndex)
        {
            if (sceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: Invalid scene index!");
            }
        }

        public void LoadNextLevel()
        {
            var activeScene = SceneManager.GetActiveScene();
            var currentSceneIndex = activeScene.buildIndex;

            var nextSceneIndex = currentSceneIndex + 1 % SceneManager.sceneCountInBuildSettings;
            
            SceneManager.LoadScene(nextSceneIndex);
        }
        

        // check for the end game condition on each frame
        private void Update()
        {
            if (_isObjectiveNotNull && _objective.IsComplete)
            {
                EndLevel();
            }
        }

    }
}