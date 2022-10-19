namespace DungeonLibrary
{
    //The "Abstract" modifier:
    //Denotes this datatype class is "incomplete" -- we don't intend
    //to make a Character object, but will instead use Character as 
    //a starting point for other, more specific types. More on this later.

    public /*abstract*/ class Character
    {
        /*
        //props/fields
        life – int

        name – string

        hitChance – int

        block – int

        maxLife – int
        
        //methods

        Fully Qualified CTOR

        CalcBlock() – returns the value of Block

        CalcHitChance() – returns the value of HitChance

        CalcDamage() – returns 0

        NicelyFormatted ToString()
         
         */
        //Funny People Collect Monkeys
        //Fields
        private int _life;
        private string? _name;
        private int _hitChance;
        private int _block;
        private int _maxLife;
        //Properties
        public string? Name
        {
            get {  return _name; }
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
            set
            {
                if (value <= _maxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }
        //Ctor
        public Character(string name, int hitChance, int block, int maxLife)
        {
            Name = name;
            HitChance = hitChance;
            Block = block;
            MaxLife = maxLife;
            Life = maxLife; //Default Life to be the same as MaxLife
        }
        //Methods

        public override string ToString()
        {
            return $"----- {Name} -----\n" +
                $"Life: {Life} of {MaxLife}\n" + 
                $"Hit Chance: {HitChance}%\n" +
                $"Block: {Block}";
        }
        //overriden in a child class
        public virtual int CalcBlock() { return Block; }
        public virtual int CalcHitChance() { return HitChance; }

        public virtual int CalcDamage() { return 0; }
    }//end abstract class
}//end namespace