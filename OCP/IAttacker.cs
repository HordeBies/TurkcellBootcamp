namespace OCP
{
    internal interface IAttacker
    {
        public int AttackPower { get; }
        void Attack(ITargetable target);
    }
}