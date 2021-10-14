using lesson4.BinaryTree;

namespace lesson4
{
  public interface ITree {
    BTreeNode GetRoot();
    void AddItem(int value); // добавить узел
    void RemoveItem(int value); // удалить узел по значению
    BTreeNode GetNodeByValue(int value); //получить узел дерева по значению
    void PrintTree(); //вывести дерево в консоль
  }
}
