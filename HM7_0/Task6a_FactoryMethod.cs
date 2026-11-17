using System;

namespace FactoryMethod
{
    abstract class Document
    {
        public abstract void Open();
    }

    class PdfDocument : Document
    {
        public override void Open() { Console.WriteLine("Відкрито PDF-документ"); }
    }

    class WordDocument : Document
    {
        public override void Open() { Console.WriteLine("Відкрито Word-документ"); }
    }

    class TextDocument : Document
    {
        public override void Open() { Console.WriteLine("Відкрито текстовий документ"); }
    }

    abstract class DocumentCreator
    {
        public abstract Document CreateDocument();

        public void OpenNewDocument()
        {
            Document doc = CreateDocument();
            doc.Open();
        }
    }

    class PdfCreator : DocumentCreator
    {
        public override Document CreateDocument() { return new PdfDocument(); }
    }

    class WordCreator : DocumentCreator
    {
        public override Document CreateDocument() { return new WordDocument(); }
    }

    class TextDocumentCreator : DocumentCreator
    {
        public override Document CreateDocument() { return new TextDocument(); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DocumentCreator creator = new PdfCreator();
            creator.OpenNewDocument();

            creator = new WordCreator();
            creator.OpenNewDocument();

            creator = new TextDocumentCreator();
            creator.OpenNewDocument();

            Console.ReadKey();
        }
    }
}
