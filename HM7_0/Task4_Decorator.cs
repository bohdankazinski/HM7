using System;

namespace DecoratorTree
{
    abstract class Tree
    {
        public abstract string GetDescription();
        public abstract bool CanShine();

        public virtual void Shine()
        {
            if (CanShine())
                Console.WriteLine("Ялинка яскраво світиться!");
            else
                Console.WriteLine("Ялинка поки що не світиться.");
        }
    }

    class FirTree : Tree
    {
        public override string GetDescription() { return "Новорічна ялинка"; }
        public override bool CanShine() { return false; }
    }

    abstract class TreeDecorator : Tree
    {
        protected Tree decoratedTree;
        public TreeDecorator(Tree tree) { this.decoratedTree = tree; }

        public override string GetDescription() { return decoratedTree.GetDescription(); }
        public override bool CanShine() { return decoratedTree.CanShine(); }
    }

    class OrnamentDecorator : TreeDecorator
    {
        private string toyName;
        private int amount;

        public OrnamentDecorator(Tree tree, string toyName, int amount) : base(tree)
        {
            this.toyName = toyName;
            this.amount = amount;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", " + toyName + " (" + amount + " шт.)";
        }
    }

    class GarlandDecorator : TreeDecorator
    {
        private string garlandColor;

        public GarlandDecorator(Tree tree, string garlandColor) : base(tree)
        {
            this.garlandColor = garlandColor;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", гірлянда [" + garlandColor + "]";
        }

        public override bool CanShine() { return true; }

        public override void Shine()
        {
            Console.WriteLine("Ялинка світиться! Колір вогників: " + garlandColor + ".");
        }
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

            tree = new OrnamentDecorator(tree, "золоті кульки", 12);
            tree = new OrnamentDecorator(tree, "сріблястий дощик", 3);
            tree = new OrnamentDecorator(tree, "янгол на верхівку", 1);
            Console.WriteLine(tree.GetDescription());
            tree.Shine();
            Console.WriteLine();

            tree = new GarlandDecorator(tree, "зелений");
            Console.WriteLine(tree.GetDescription());
            tree.Shine();

            Console.ReadKey();
        }
    }
}
