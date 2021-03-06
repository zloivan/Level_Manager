using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityStandardAssets.Characters.ThirdPerson;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {
        [FormerlySerializedAs("_sceneName")] [SerializeField]
        private string _levelName;

        [SerializeField] private bool _useDirectSceneName;

        // reference to player
        private ThirdPersonCharacter _player;


        // reference to goal effect
        private GoalEffect _goalEffect;


        // reference to player
        private Objective _objective;

        private bool _isGameOver;
        public bool IsGameOver => _isGameOver;

        private static GameManager _instance;

        public static GameManager Instance => _instance;

        // initialize references

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;


            _player = FindObjectOfType<ThirdPersonCharacter>();
            _objective = FindObjectOfType<Objective>();
            _goalEffect = FindObjectOfType<GoalEffect>();
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        // end the level

        private void Update()
        {
            if (_objective != null && _objective.IsComplete)
            {
                EndLevel();
            }
        }

        private void EndLevel()
        {
            if (_player != null)
            {
                // disable the player controls
                var thirdPersonControl = _player.GetComponent<ThirdPersonUserControl>();

                if (thirdPersonControl != null)
                {
                    thirdPersonControl.enabled = false;
                }

                // remove any existing motion on the player
                var rbody = _player.GetComponent<Rigidbody>();
                if (rbody != null)
                {
                    rbody.velocity = Vector3.zero;
                }

                // force the player to a stand still
                _player.Move(Vector3.zero, false, false);
            }

            // check if we have set IsGameOver to true, only run this logic once
            if (_goalEffect == null || _isGameOver) return;

            _isGameOver = true;
            _goalEffect.PlayEffect();
            if (_useDirectSceneName)
            {
                LoadLevel(_levelName);
            }
            else
            {
                LoadNextLevel();
            }
        }

        public void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: Invalid level name is specified!", this);
            }
        }

        public void LoadLevel(int levelIndex)
        {
            if (levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("GAMEMANAGER LoadLevel Error: Invalid level index is specified!", this);
            }
        }

        public void LoadNextLevel()
        {
            var currentIndex = SceneManager.GetActiveScene().buildIndex;

            var nextSceneIndex = currentIndex + 1;

            var totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

            nextSceneIndex %= totalNumberOfScenes;

            LoadLevel(nextSceneIndex);
        }

        public void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}