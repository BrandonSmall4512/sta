#include "Stack.h"
using namespace std;

int main(){
    system("chcp 65001");
    using T = int;
    Stack<T> pt;
    Stack<T> pt2 = { 17, 7, 15 };
    T value;
    int choose;
    cout << "Выберите действие:"                              << endl;
    cout << "1 - Проверка стека на пустоту"                   << endl;
    cout << "2 - Вывод верхнего элемента стека"               << endl;
    cout << "3 - Добавить элемент в стек"                     << endl;
    cout << "4 - Очистить стек"                               << endl;
    cout << "5 - Распечатать стек"                            << endl;
    cout << "6 - Размер стека"                                << endl;
    cout << "7 - Обменять верхний элемент стека с элементом"  << endl;
    cout << "8 - Оператор =="                                 << endl;
    cout << "9 - Оператор !="                                 << endl;
    cout << "10 - Оператор ="                                 << endl;
    cout << "11 - Оператор <<"                                << endl;
    cout << "12 - Оператор >>"                                << endl;
    cout << "13 - Выход"                                      << endl;
    cout << "Действие:"                                       << endl;
    while (1){
        cin >> choose;
        try {
            switch (choose) {
                case 1:
                    if (pt.empty())
                    {
                        cout << "Стек пуст" << endl;
                    }
                    else
                    {
                        cout << "Стек не пуст" << endl;
                    }
                    break;
                case 2:
                    cout << "Верхний элемент стека: " << pt.check_pop() << endl;
                    break;
                case 3:
                    cout << "Введите значение которое хотите добавить в стек: " << endl;
                    cin >> value;
                    pt.push(value);
                    break;
                case 4:
                    pt.clear();
                    cout << "Стек очищен" << endl;
                    break;
                case 5:
                    cout << "Элементы стека(голова слева): " << endl;
                    Stack<T>::print(pt);
                    break;
                case 6:
                    cout << "Размер стека: " << pt.size() << endl;
                    break;
                case 7:
                    T elem;
                    elem = 9;
                    pt.swap(elem);
                    Stack<T>::print(pt);
                    break;
                case 8:
                    if (pt == pt2) {
                        cout << "Стеки равны" << endl;
                    }
                    else {
                        cout << "Стеки не равны" << endl;
                    }
                    break;
                case 9:
                    if (pt != pt2) {
                        cout << "Стеки не равны" << endl;
                    }
                    else {
                        cout << "Стеки равны" << endl;
                    }
                    break;
                case 10:
                    pt = pt2;
                    cout << "Новый объект pt полученный из объекта pt2 путём присваивания копированием: " << endl;
                    Stack<T>::print(pt);
                    break;
                case 11:
                    pt << 2 << 187 << 19;
                    cout << "Результат работы <<:" << endl;
                    Stack<T>::print(pt);
                    break;
                case 12:
                    pt >> value;
                    cout << "Результат работы >>: " << value << endl;
                    break;
                case 13:
                    exit(0);
                    break;
            }
        }
        catch (const runtime_error& e) {
            cerr << "Error: " << e.what() << endl;
        }
    }
    return 0;
}
