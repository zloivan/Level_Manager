namespace LevelManager.MechanicsSystems.Patterns.Prototype
{
    public class Dog : Monster
    {
        private readonly int _health;
        private readonly int _speed;

        public Dog(int health, int speed) : base(health, speed)
        {
            _health = health;
            _speed = speed;
        }

        public override Monster Clone()
        {
            return new Dog(_health, _speed);
        }
    }
}