using System;
using System.Collections.Generic;

namespace CompositeExample
{
    abstract class FileSystemItem
    {
        protected string name;
        public FileSystemItem(string name) { this.name = name; }

        public abstract int GetSize();
        public abstract void Print(string indent);
    }

    class FileItem : FileSystemItem
    {
        private int size;
        public FileItem(string name, int size) : base(name) { this.size = size; }

        public override int GetSize() { return size; }

        public override void Print(string indent)
        {
            Console.WriteLine("{0}{1} ({2} КБ)", indent, name, size);
        }
    }

    class FolderItem : FileSystemItem
    {
        private List<FileSystemItem> children = new List<FileSystemItem>();
        public FolderItem(string name) : base(name) { }

        public void Add(FileSystemItem item) { children.Add(item); }
        public void Remove(FileSystemItem item) { children.Remove(item); }

        public override int GetSize()
        {
            int total = 0;
            foreach (FileSystemItem item in children)
                total += item.GetSize();
            return total;
        }

        public override void Print(string indent)
        {
            Console.WriteLine("{0}[{1}] ({2} КБ)", indent, name, GetSize());
            foreach (FileSystemItem item in children)
                item.Print(indent + "    ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            FolderItem root = new FolderItem("Документи");
            FolderItem lab = new FolderItem("Лабораторні");
            FolderItem photos = new FolderItem("Фото");

            lab.Add(new FileItem("lab1.docx", 120));
            lab.Add(new FileItem("lab2.docx", 95));
            photos.Add(new FileItem("img1.png", 400));
            photos.Add(new FileItem("img2.png", 350));

            root.Add(lab);
            root.Add(photos);
            root.Add(new FileItem("readme.txt", 5));

            root.Print("");

            Console.ReadKey();
        }
    }
}
