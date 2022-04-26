using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SampleGame
{
    // plays a set of ParticleSystems 
    public class GoalEffect : MonoBehaviour
    {
        // top transform of the ParticleSystems
        [SerializeField] private Transform _particleEffectXform;

        // delay before particles trigger
        [SerializeField] private float _delay = 1f;

        private ParticleSystem[] _particleSystems;

        private void Awake()
        {
            _particleSystems = _particleEffectXform.GetComponentsInChildren<ParticleSystem>();
        }

        public void PlayEffect()
        {
            PlayEffectAsync();
        }

        private async void PlayEffectAsync()
        {
            // wait for a delay
            await UniTask.Delay(TimeSpan.FromSeconds(_delay));

            // find ParticleSystems under the top transform
            if (_particleEffectXform == null) return;


            // stop and play each ParticleSystem
            foreach (var ps in _particleSystems)
            {
                if (ps == null) continue;

                ps.Stop();
                ps.Play();
            }
        }
    }
}