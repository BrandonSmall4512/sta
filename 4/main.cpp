#include "Polynom.h"
using namespace std;
int main()
{
    system("chcp 65001");

    int n = 3, k = 3;
    int* arr = new int[n]{1,2,3};
    int* arr2 = new int[k]{1,-2,-3};
    Polynom obj(arr, n), obj2(arr2, k);
    cout << "Первый многочлен: " << obj;
    cout << "Второй многочлен: " << obj2;
    cout << "Результат метода рассчета для заданного x: " << obj.countX(0) << endl << endl;

    cout << "Работа арифметических операторов:" << endl;
    cout << "Оператор сложения: "<< "+  " << obj + obj2;
    cout << "Оператор вычитания: "<< "-  " << obj - obj2;
    cout << "Оператор умножения: "<< "*  " << obj * obj2;

    cout <<"Работа унарных операторов: " << endl;
    cout<< "Оператор +: " << +obj;
    cout <<"Оператор -: " << -obj << endl;

    cout<<"Работа операторов сравнения: " << endl;
    cout<<"Оператор ==" << endl;
    if (obj == obj2){
        cout<<"Многочлены равны" << endl;
    }
    else{
        cout<<"Многочлены разные" << endl;
    }

    cout<<"Оператор != " << endl;
    if (obj!=obj2){
        cout << "Первый многочлен не равен второму" << endl << endl;
    }
    else{
        cout << "Первый многочлен равен второму" << endl << endl;
    }

    cout << "Работа операторов присваивания: " << endl;
    int* arr3 = new int[3] {7, 0, 6};
    Polynom obj3(arr3, 3);
    obj3 = obj2;
    cout<<"Оператор =: " << "Первый полином: " << obj2 <<";"<< " Второй полином: " << obj3 <<endl;

    int* arr4 = new int[3] {7, 0, 6};
    Polynom obj4(arr4, 3);
    obj4*=obj2;
    cout<<"Оператор *=: " << "Первый полином: " << obj2 <<";"<< " Второй полином: " << obj4 <<endl;

    int* arr6 = new int[3] {7, 0, 12};
    Polynom obj6(arr6, 3);
    obj6+=obj2;
    cout<<"Оператор +=: " << "Первый полином: " << obj2 <<";"<< " Второй полином: " << obj6 <<endl;

    int* arr7 = new int[3] {7, 0, 12};
    Polynom obj7(arr7, 3);
    obj7-=obj2;
    cout<<"Оператор -=: " << "Первый полином: " << obj2 <<";"<< " Второй полином: " << obj7 <<endl <<endl;

    int* arr8 = new int[3] {18, 10, 2};
    Polynom obj8(arr8, 3);
    string str = string(obj8);
    cout<< "Конвертация полинома в строку:"<< endl << "Полином до превращения: " << obj8 << "Полином после превращения: " << str << endl;

    return 0;
}