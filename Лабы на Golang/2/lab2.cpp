#include "Souder.h"

int main()
{
    system("chcp 65001"); cout<<endl;

    using T = int;

    BinarySearchTree<T> test;

    test.Insert(2);
    test.Insert(3);
    test.Insert(7);
    //лямбда функция принимает один аргумент (целое число) и выводит это число в консоль с добавлением пробела
    auto printCallback = [](const int& value) {
        cout << value << " ";
    };

    cout <<"Прямой обход (КЛП): корень → левое поддерево → правое поддерево: ";
    test.Traverse(printCallback, 0);
    cout << endl;

    cout <<"Центрированный обход (ЛКП): левое поддерево → корень → правое поддерево: ";
    test.Traverse(printCallback, 1);
    cout << endl;

    cout <<"Обратный обход (ЛПК): левое поддерево → правое поддерево → корень: ";
    test.Traverse(printCallback, 2);
    cout << endl;

    int choose;
    cout << "Выберите действие которое хотите совершить: 1 - найти элемент, 2 - удалить элемент, " << endl;
    cout << "3 - очистить дерево, 4 - распечатать дерево, 5 - оператор ==, 6 - оператор !=, " << endl;
    cout << "7 - объединить два дерева, 8 - вернуть поддерево по ключу, 9 - добавить элемент в дерево" << endl;
    while (1)
    {
        cin >> choose;
        try
        {
            switch (choose) {
                case 1:
                {
                    BinarySearchTree<T> tree_5 = {1, 2, 3, 4};
                    cout << "Введите значение которое нужно найти в дереве: ";
                    T find;
                    cin >> find;
                    T result = tree_5.findValue(find);
                    cout << "Результат работы поиска: " << result << endl;
                    break;
                }
                case 2:
                {
                    T del;
                    BinarySearchTree<T> tree_6 = {1, 2, 3};
                    cout << "Дерево до удаления элемента: ";
                    tree_6.print();
                    cout << endl;
                    cout << "Введите элемент который хотите удалить: ";
                    cin >> del;
                    tree_6.Delete_Elem(del);
                    cout << "Дерево после удаления элемента: ";
                    tree_6.print();
                    cout << endl;
                    break;
                }
                case 3: {
                    BinarySearchTree<T> tree_7 = {1, 3, 5};
                    cout << "Дерево до удаления: ";
                    tree_7.print();
                    cout << endl;
                    tree_7.clear();
                    cout << "Дерево очищено";
                    cout << endl;
                    break;
                }
                case 4:
                {
                    BinarySearchTree<T> tree_8 = {1, 5, 7};
                    cout << "Перегрузка оператора << для распечатки дерева: " << endl;
                    cout << tree_8;
                    cout << endl;
                    break;
                }
                case 5:
                {
                    BinarySearchTree<T> test = {1, 4, 5};
                    BinarySearchTree<T> test_2 = {1, 4, 5};
                    cout << "Результат работы перегруженного оператора ==: " << endl;
                    if (test == test_2) {
                        cout << "Деревья равны" << endl;
                    } else {
                        cout << "Деревья не равны" << endl;
                    }
                    break;
                }
                case 6:
                {
                    BinarySearchTree<T> test_3 = {1, 4, 5};
                    BinarySearchTree<T> test_4 = {1, 5};
                    cout << "Результат работы перегруженного оператора ==: " << endl;
                    if (test_3 != test_4) {
                        cout << "Деревья не равны" << endl;
                    } else {
                        cout << "Деревья равны" << endl;
                    }
                    break;
                }
                case 7:
                {
                    BinarySearchTree<T> test_5 = {1, 3, 5};
                    BinarySearchTree<T> test_6 = {2, 4};
                    test_5.unite(test_6);
                    cout << "Результат добавления дерева test_6 в дерево test_5: ";
                    cout << test_5;
                    cout << endl;
                    break;
                }
                case 8:
                {
                    BinarySearchTree<T> test_7 = {2, 1, 3, 6, 5, 4};
                    T key;
                    cout << "Введите корень поддерева которое хотите вернуть: " << endl;
                    cin >> key;
                    BinarySearchTree<T> subtree = test_7.findTree(key);
                    cout << "Поддерево:" << endl;
                    cout << subtree << endl;
                    break;
                }
                case 9:
                {
                    BinarySearchTree<T> test_8 = {1, 2};
                    T key;
                    cout << "Введите элемент которое хотите добавить: ";
                    cin >> key;
                    test_8.Insert(key);
                    cout << "Дерево после добавления элемента: ";
                    cout << test_8 << endl;
                }
                case 10:
                {
                    BinarySearchTree<T> test_8 = {5, -2, 10, -4, 0, -1, 3, 4};
                    test_8.print();
//                    test_8.Delete_Elem(11);
//                    cout << "Дерево после удаления элемента: ";
//                    test_8.print();
                    test_8.Delete_Elem(0);
                    cout << "Дерево после удаления элемента: ";
                    test_8.print();
                    test_8.Delete_Elem(5);
                    cout << "Дерево после удаления элемента: ";
                    test_8.print();
                    test_8.Delete_Elem(10);
                    cout << "Дерево после удаления элемента: ";
                    test_8.print();
                    cout << endl;
                    break;
                }
            }
        }
        catch (const runtime_error& e)
        {
            cout << e.what() << endl;
        }
    }
    return 0;
}