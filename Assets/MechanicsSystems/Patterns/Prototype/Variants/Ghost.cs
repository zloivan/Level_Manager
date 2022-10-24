using UnityEngine;

namespace LevelManager.MechanicsSystems.Patterns.Prototype
{
    public class Ghost : Monster
    {
        public override Monster Clone()
        {
            Debug.Log("Ghost cloned");
            return new Ghost(15, 20);
        }


        public Ghost(int health, int speed) : base(health, speed)
        {
        }
    }
}