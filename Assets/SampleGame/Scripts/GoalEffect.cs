using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{
    // plays a set of ParticleSystems 
    public class GoalEffect : MonoBehaviour
    {
        // top transform of the ParticleSystems
        [SerializeField]
        private Transform _particleEffectXform;

        // delay before particles trigger
        [SerializeField]
        private float _delay = 1f;

        public void PlayEffect()
        {
            StartCoroutine(PlayEffectRoutine());
        }

        // find all of the ParticleSystem components and play
        private IEnumerator PlayEffectRoutine()
        {
            // wait for a delay
            yield return new WaitForSeconds(_delay);

            // find ParticleSystems under the top transform
            if (_particleEffectXform == null)
            {
                yield break;
            }
            
            var particleSystems = 
                _particleEffectXform.GetComponentsInChildren<ParticleSystem>();
                
            // stop and play each ParticleSystem
            foreach (var ps in particleSystems)
            {
                if (ps != null)
                {
                    ps.Stop();
                    ps.Play();  
                }
            }
        }
    }
}