namespace LevelManager.MechanicsSystems.Patterns.Prototype
{
    public abstract class Monster
    {
        protected readonly int _health;
        protected readonly int _speed;

        public Monster(int health, int speed)
        {
            _health = health;
            _speed = speed;
        }

        public abstract Monster Clone();
    }

    public class Spawner
    {
        private Monster _prototype;
        public Spawner(Monster prototype)
        {
            _prototype = prototype;
        }
        public Monster SpawnMonster()
        {
            return _prototype.Clone();
        }
    }
}