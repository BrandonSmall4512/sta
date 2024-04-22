#include <iostream>
#include <mutex>
#include <vector>
#include <functional>
#include <chrono>
#include <iomanip>
using namespace std;

template <typename T>
class BinarySearchTree {
private:
    struct Node
    {
        T key;
        Node* left;
        Node* right;
        Node(const T& value) {
            key = value;
            left = nullptr;
            right = nullptr;
        }
    };
    Node* root;
    mutex tree_mutex;

public:

    BinarySearchTree() {
        root = nullptr;
    }

    template <typename Iterator> //конструктор с итераторами
    BinarySearchTree(Iterator begin, Iterator end) {
        root = nullptr;
        for (Iterator it = begin; it != end; ++it) {
            Insert(*it);
        }
    }

    BinarySearchTree(initializer_list<T> values) { //конструктор инициализации
        root = nullptr;
        for (const T& value : values)
        {
            Insert(value);
        }
    }

    BinarySearchTree(const BinarySearchTree& other) { //конструктор копирования
        root = copyTree(other.root);
    }

    BinarySearchTree(BinarySearchTree&& other) { //конструктор перемещения
        root = other.root;
        other.root = nullptr;
    }


    ~BinarySearchTree() {
        DestroyTree(root);
    }

    BinarySearchTree findTree(const T& key) {
        Node* subtreeRoot = findSubtreeRoot(root, key);
        if (subtreeRoot == nullptr) {
            throw runtime_error("Поддерево с указанным ключом не найдено.");
        }
        BinarySearchTree subtree;
        subtree.root = copySubtree(subtreeRoot);
        return subtree;
    }

    Node* copyTree(Node* node) {
        if (node == nullptr) {
            return nullptr;
        }

        Node* newNode = new Node(node->key);
        newNode->left = copyTree(node->left);
        newNode->right = copyTree(node->right);

        return newNode;
    }

    void DestroyTree(Node* node) {
        if (node == nullptr) {
            return;
        }

        DestroyTree(node->left);
        DestroyTree(node->right);
        delete node;
    }

    //рекурсивный поиск поддерева в текущем дереве
    Node* findSubtreeRoot(Node* node, const T& key) { //Если узел node имеет ключ, равный key, то метод возвращает этот узел.
        if (node == nullptr || node->key == key) {
            return node;
        }
        if (key < node->key) { //если нет - идем в левое поддерево
            return findSubtreeRoot(node->left, key);
        }
        else {
            return findSubtreeRoot(node->right, key);
        }
    }
    Node* copySubtree(Node* originalRoot) { //копируем нашего поддерево в новое пустое дерево
        if (originalRoot == nullptr) {
            return nullptr;
        }
        Node* newNode = new Node(originalRoot->key);
        newNode->left = copySubtree(originalRoot->left);
        newNode->right = copySubtree(originalRoot->right);
        return newNode;
    }

    friend BinarySearchTree& operator<<(BinarySearchTree& tree, const T& value) {
        tree.Insert(value);
        return tree;
    }

    BinarySearchTree& operator<<(const BinarySearchTree& subtree) {
        unite(subtree);
        return *this;
    }

    friend ostream& operator<< (ostream& os, const BinarySearchTree& tree) {
        if (tree.root == nullptr) {
            throw runtime_error("В дереве нет узлов");
        }
        tree.print(os);
        return os;
    }

    bool operator == (const BinarySearchTree& other) {
        if (root == nullptr && other.root == nullptr) {
            return true;
        }
        return isIdentical(root, other.root);
    }

    bool operator != (const BinarySearchTree& other) {
        if (root == nullptr && other.root == nullptr) {
            return false;
        }
        return !isIdentical(root, other.root);
    }

    Node* getRoot() const {
        return root;
    }

    void Insert(const T& value) {
        lock_guard<mutex> lock(tree_mutex);
        root = Insert(root, value);
    }

    Node* Insert(Node* node, const T& value) {
        if (node == nullptr) {
            return new Node(value);
        }
        if (value < node->key) {
            node->left = Insert(node->left, value);
        }
        else {
            node->right = Insert(node->right, value);
        }

        return node;
    }

    void clear() {
        clear(root);
        root == nullptr;
    }

    void clear(Node* node) {
        if (node == nullptr) {
            throw runtime_error("В дереве нет узлов");
        }
        if (node) {
            clear(node->left);
            clear(node->right);
            delete node;
        }
    }

    T findValue(const T& key) {
        Node* result = search(root, key);
        if (result) {
            return result->key;
        }
        else {
            throw runtime_error("Такого значения в дереве нет");
        }
    }

    Node* minValueNode(Node* node) {
        Node* current = node;
        while (current->left != nullptr) {
            current = current->left;
        }
        return current;
    }

    Node* search(Node* node, const T& key)
    {
        if (node == nullptr || key == node->key) {
            return node;
        }
        if (key < node->key) {
            return search(node->left, key);
        }
        else {
            return search(node->right, key);
        }
    }

    void Delete_Elem(const T& key) {
        root = Delete_Elem(root, key);
    }

    Node* Delete_Elem(Node* node, const T& key)
    {
        if (node == nullptr) {
            throw runtime_error("Такого значения в дереве нет");
        }
        else if (key < node->key) {
            node->left = Delete_Elem(node->left, key);
        }
        else if (key > node->key) {
            node->right = Delete_Elem(node->right, key);
        }
        else { //Если текущий узел не имеет потомков
            if (node->left == nullptr && node->right == nullptr) {
                delete node;
                return nullptr;
            } //Если у узла есть только один потомок
            else if (node->left == nullptr) {
                Node* temp = node;  //этот потомок поднимается на место удаляемого узла, а затем удаляется
                node = node->right;
                delete temp;
            }
            else if (node->right == nullptr) {
                Node* temp = node;
                node = node->left;
                delete temp;
            }
            else { //Если у узла есть оба потомка, находится узел с наименьшим ключом в правом поддереве (метод minValueNode).
                Node* temp = minValueNode(node->right);  //Этот узел заменяет текущий узел, а затем удаляется из правого поддерева.
                node->key = temp->key;
                node->right = Delete_Elem(node->right, temp->key);
            }
        }
        return node;
    }

    void print(ostream& os = cout) const {
        inOrderTraversal(root, os);
    }

    bool isIdentical(const Node* node_1, const Node* node_2) {
        if (node_1 == nullptr && node_2 == nullptr) {
            return true;
        }
        if (node_1 == nullptr || node_2 == nullptr) {
            return false;
        }

        return (node_1->key == node_2->key) && isIdentical(node_1->left, node_2->left) && isIdentical(node_1->right, node_2->right);
    }

    void unite(const BinarySearchTree& other) { //слияние
        if (other.root != nullptr) {
            unite(root, other.root);
        }
    }

    void unite(Node* root1, Node* root2) {
        if (root2 == nullptr) {
            return;
        }

        root1 = Insert(root1, root2->key);

        unite(root1, root2->left);
        unite(root1, root2->right);
    }

    void Traverse(const function<void(const T&)>& callback, int order) {
        if (order == 0) {
            PreOrderTraversal(root, callback);
        }
        else if (order == 1) {
            InOrderTraversal(root, callback);
        }
        else if (order == 2) {
            PostOrderTraversal(root, callback);
        }
    }

    void inOrderTraversal(Node* node, ostream& os) const {
        if (node == nullptr) {
            return;
        }
        inOrderTraversal(node->left, os);
        os << node->key << " ";
        inOrderTraversal(node->right, os);
    }


    void InOrderTraversal(Node* node, const function<void(const T&)>& callback) {
        if (node == nullptr) {
            return;
        }
        InOrderTraversal(node->left, callback);
        callback(node->key);
        InOrderTraversal(node->right, callback);
    }

    void PreOrderTraversal(Node* node, const function<void(const T&)>& callback) {
        if (node == nullptr) {
            return;
        }
        callback(node->key);
        PreOrderTraversal(node->left, callback);
        PreOrderTraversal(node->right, callback);
    }

    void PostOrderTraversal(Node* node, const function<void(const T&)>& callback) {
        if (node == nullptr) {
            return;
        }
        PostOrderTraversal(node->left, callback);
        PostOrderTraversal(node->right, callback);
        callback(node->key);
    }
};