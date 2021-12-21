namespace DesignPatterns.Behavioral._5_Memento;

// Memento pattern is about capturing and storing the current state of an object in a
// manner that it can be restored later on in a smooth manner.

// The memento pattern is a software design pattern that provides the ability to restore
// an object to its previous state (undo via rollback).

// Take the example of calculator (i.e. originator), where whenever you perform some
// calculation the last calculation is saved in memory (i.e. memento) so that you can get
// back to it and maybe get it restored using some action buttons (i.e. caretaker).

//'Originator' Class
public class Editor
{
    public string Content;

    public EditorMemento MakeMemento(Editor editor)
    {
        return new EditorMemento(editor.Content);
    }

    public void RecoverMemento(EditorMemento memento)
    {
        Content = memento.Content;
    }

    public void DisplayEditorInfo()
    {
        Console.WriteLine("Content: " + Content);
    }

}

//'Memento' class
public class EditorMemento
{
    public string Content;
    public EditorMemento(string content) => Content = content;
    
}

//'CareTaker' class
public class EditorCareTaker
{
    // store a checkpoint for already crossed level
    public EditorMemento EditorMemento;
}

// 'Client' Class
public static class MementoOutPut
{
    public static void Display()
    {
        var editor = new Editor();
        editor.Content = "milad";
        Console.WriteLine("-------- display info --------");
        editor.DisplayEditorInfo();
        Console.WriteLine();
        
        EditorCareTaker editorCareTaker = new EditorCareTaker();
        editorCareTaker.EditorMemento = editor.MakeMemento(editor);
        
        Thread.Sleep(2000);
        editor.Content = "mahdi";
        Console.WriteLine("-------- display info --------");
        editor.DisplayEditorInfo();
        Console.WriteLine();
        
        editor.RecoverMemento(editorCareTaker.EditorMemento);
        Console.WriteLine("-------- recover before state from memento object --------");
        editor.DisplayEditorInfo();
        
    }
}