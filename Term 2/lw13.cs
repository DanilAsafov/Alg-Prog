using System;

public class BinaryTreeNode {
    public int Id {get; set;}
    public string Name {get; set;}
    public BinaryTreeNode Left {get; set;}
    public BinaryTreeNode Right {get; set;}

    public BinaryTreeNode(int id, string name) {
        Id = id;
        Name = name;
        Left = null;
        Right = null;
    }
}

public class BinaryTree {
    public BinaryTreeNode Root {get; set;}

    public void Insert(int id, string name) {
        Root = InsertRecursive(Root, id, name);
    }

    private BinaryTreeNode InsertRecursive(BinaryTreeNode node, int id, string name) {
        if (node == null) {
            return new BinaryTreeNode(id, name);
        }

        if (id < node.Id) {
            node.Left = InsertRecursive(node.Left, id, name);
        } else if (id > node.Id) {
            node.Right = InsertRecursive(node.Right, id, name);
        } else {
            node.Name = name;
        }
        return node;
    }

    public void InOrderTraversal() {
        InOrderRecursive(Root);
    }

    private void InOrderRecursive(BinaryTreeNode node) {
        if (node != null) {
            InOrderRecursive(node.Left);
            Console.WriteLine($"ID: {node.Id}, Животное: {node.Name}");
            InOrderRecursive(node.Right);
        }
    }
}


class Program {
    static void Main() {
        BinaryTree tree = new();
        
        tree.Insert(5, "Кошка");
        tree.Insert(3, "Собака");
        tree.Insert(7, "Медведь");
        tree.Insert(2, "Слон");
        
        tree.InOrderTraversal();
    }
}