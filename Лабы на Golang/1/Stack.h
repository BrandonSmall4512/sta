#ifndef LABA1_STACK_H
#define LABA1_STACK_H

#include <iostream>
#include <vector>
#include <exception>

using namespace std;
#define SIZE 10

template <typename T>
class Stack
{
    T* arr;
    int topIndex;
    int capacity;

public:

    Stack(int size = SIZE);

    Stack(const Stack& copy);

    Stack(Stack&& transfer);

    Stack(initializer_list<T> values);

    ~Stack();

    void push(const T& value);

    T pop();

    T check_pop();

    static void print(const Stack<T>& pt);

    void clear();

    void top(const T& value);

    void swap(T value);

    bool empty() { return topIndex == -1; }

    size_t size() { return topIndex + 1; }

    bool operator==(const Stack<T>& other);

    bool operator!=(const Stack<T>& other);

    Stack<T>& operator=(const Stack<T>& other);

    Stack<T>& operator<<(const T& value);

    Stack<T>& operator>>(T& value);
};

template <typename T>
Stack<T>::Stack(int size)
{
    arr = new T[size];
    capacity = size;
    topIndex = -1;
}

template <typename T>
Stack<T>::Stack(const Stack& copy)
{
    topIndex = copy.topIndex;
    capacity = copy.capacity;
    arr = new T[capacity];
    for (int i = 0; i <= topIndex; ++i) {
        arr[i] = copy.arr[i];
    }
}

template <typename T>
Stack<T>::Stack(Stack&& transfer)
{
    arr = transfer.arr;
    capacity = transfer.capacity;
    transfer.arr = nullptr;
    transfer.capacity = 0;
}

template <typename T>
Stack<T>::Stack(initializer_list<T> values) {
    if (values.size() > 0) {
        arr = new T[values.size()];
        capacity = values.size();
        topIndex = -1;
        for (const T& value : values) {
            push(value);
        }
    }
}

template <typename T>
Stack<T>::~Stack()
{
    delete[] arr;
}

template <typename T>
void Stack<T>::push(const T& value)
{
    if (topIndex >= capacity - 1)
    {
        T* newArr = new T[capacity * 2];
        for (int i = 0; i <= topIndex; i++)
        {
            newArr[i] = arr[i];
        }
        delete[] arr;
        arr = newArr;
        capacity *= 2;
    }
    arr[++topIndex] = value;
}

template <typename T>
T Stack<T>::pop()
{
    if (empty())
    {
        throw runtime_error("Stack is empty. Cannot delete element.");
    }
    else {
        return arr[topIndex--];
    }
}

template <typename T>
T Stack<T>::check_pop()
{
    if (empty())
    {
        throw runtime_error("Stack is empty. Cannot access top element.");
    }
    else{
        return arr[topIndex];
    }
}

template <typename T>
void Stack<T>::print(const Stack<T>& pt) {
    Stack<T> tempStack = pt;
    if (tempStack.empty()) {
        throw runtime_error("There is no elements in stack.");
    }
    else {
        while (!tempStack.empty()) {
            cout << tempStack.check_pop() << " ";
            tempStack.pop();
        }
        cout << endl;
    }
}

template <typename T>
void Stack<T>::clear()
{
    capacity = SIZE;
    topIndex = -1;
    delete[] arr;
    arr = new T[capacity];
}

template <typename T>
void Stack<T>::top(const T& value)
{
    if (empty())
    {
        throw runtime_error("Stack is empty.");
    }
    else{
        arr[topIndex] = value;
    }
}

template <typename T>
void Stack<T>::swap(const T value) {
    if (empty()) {
        throw runtime_error("Stack is empty.");
    }
    else{
        arr[topIndex] = value;
    }
}

template <typename T>
bool Stack<T>::operator==(const Stack<T>& other)
{
    if (topIndex != other.topIndex) {
        return false;
    }

    for (int i = 0; i <= topIndex; ++i) {
        if (arr[i] != other.arr[i]) {
            return false;
        }
    }
    return true;
}

template <typename T>
bool Stack<T>::operator!=(const Stack<T>& other)
{
    return !(*this == other);
}

template <typename T>
Stack<T>& Stack<T>::operator=(const Stack<T>& other) {
    if (this != &other) {
        delete[] arr;
        capacity = other.capacity;
        arr = new T[capacity];
        for (int i = 0; i <= other.topIndex; i++) {
            arr[i] = other.arr[i];
        }
        topIndex = other.topIndex;
    }
    return *this;
}


template <typename T>
Stack<T>& Stack<T>::operator<<(const T& value) {
    push(value);
    return *this;
}

template <typename T>
Stack<T>& Stack<T>::operator>>(T& value) {
    value = pop();
    return *this;
}

#endif