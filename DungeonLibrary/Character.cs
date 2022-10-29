
namespace DungeonLibrary
{
    //The "Abstract" modifier:
    //Denotes this datatype class is "incomplete" -- we don't intend
    //to make a Character object, but will instead use Character as 
    //a starting point for other, more specific types. More on this later.
    public abstract class Character
    {        
        //Fields // Funny
        private int _life;
        private string? _name;//? after a datatype just means it's nullable
        private int _hitChance;
        private int _block;
        private int _maxLife;
        private int _initiative;
        //Properties // People

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int HitChance
        {
            get { return _hitChance; }
            set { _hitChance = value; }
        }
        public int Block
        {
            get { return _block; }
            set { _block = value; }
        }
        public int MaxLife
        {
            get { return _maxLife; }
            set { _maxLife = value; }
        }
        public int Life
        {
            get { return _life; }
            //Life cannot be more than maxlife
            set
            {
                if (value <= _maxLife)//prop or field
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
                //_life = value <= MaxLife ? value : MaxLife;
            }//end set
        }//end Life prop
        public int Initiative
        {
            get { return _initiative; }
            set { _initiative = value; }
        }

        //Constructors // Collect
        public Character(string name, int hitChance, int block, int maxLife)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = maxLife;//Default Life to be the same as MaxLife
            _initiative = 20;
        }

        public Character()
        {

        }
        //Methods // Monkeys

        public override string ToString()
        {
            return $"\n----- {Name} -----\n" +
                $"Life: {Life} of {MaxLife}\n" +
                $"Hit Chance: {CalcHitChance()}%\n" +
                $"Block: {Block}\t" + $"Initiative: {Initiative}";
        }

        public virtual int CalcBlock() { return Block; }
        public virtual int CalcHitChance() { return HitChance; }
        public virtual int CalcDamage() { return 0; }

    }
}