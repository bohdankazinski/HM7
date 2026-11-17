using System;

namespace DecoratorTree
{
    abstract class Tree
    {
        public abstract string GetDescription();
        public abstract bool CanShine();

        public void Shine()
        {
            if (CanShine())
                Console.WriteLine("Ялинка світиться!");
            else
                Console.WriteLine("Ялинка не світиться.");
        }
    }

    class FirTree : Tree
    {
        public override string GetDescription() { return "Ялинка"; }
        public override bool CanShine() { return false; }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree tree;
        public TreeDecorator(Tree tree) { this.tree = tree; }

        public override string GetDescription() { return tree.GetDescription(); }
        public override bool CanShine() { return tree.CanShine(); }
    }

    class OrnamentDecorator : TreeDecorator
    {
        private string ornament; 
        private int count;       

        public OrnamentDecorator(Tree tree, string ornament, int count) : base(tree)
        {
            this.ornament = ornament;
            this.count = count;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", " + ornament + " x" + count;
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        private string color; 

        public GarlandDecorator(Tree tree, string color) : base(tree)
        {
            this.color = color;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", гірлянда (" + color + ")";
        }

        public override bool CanShine() { return true; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Tree tree = new FirTree();
            Console.WriteLine(tree.GetDescription());
            tree.Shine();
            Console.WriteLine();

            tree = new OrnamentDecorator(tree, "червоні кульки", 10);
            tree = new OrnamentDecorator(tree, "зірка", 1);
            Console.WriteLine(tree.GetDescription());
            tree.Shine();    
            Console.WriteLine();

            tree = new GarlandDecorator(tree, "різнокольорова");
            Console.WriteLine(tree.GetDescription());
            tree.Shine(); 

            Console.ReadKey();
        }
    }
}
