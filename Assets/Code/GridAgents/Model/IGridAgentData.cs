namespace AIEnemy.GridAgents
{
    public interface IGridAgentData 
    {
        public int X { get; set; } 
        public int Y { get; set; } 
        public int Health { get; set;}
        public int Damage { get; set;}
    }
}