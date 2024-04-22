#include "Fraction.h"
#include <iostream>
#include <string>

using namespace std;

int main() {
    system("chcp 65001");
    Fract obj, obj2;

    cout<<"Введите первую дробь: " << endl;
    cout<<"Введите числитель: ";
    cin >> obj.num;
    cout<<"Введите знаменатель ";
    cin >> obj.den;
    while (obj.den==0)
    {
        cout<<"Ошибка. Введите знаменатель отличный от нуля." << endl;
        cout<<"Введите знаменатель ";
        cin >> obj.den;
    }

    cout<<"Введите вторую дробь: " << endl;
    cout<<"Введите числитель: ";
    cin >> obj2.num;
    cout<<"Введите знаменатель ";
    cin >> obj2.den;
    while (obj2.den==0){
        cout<<"Ошибка, введите знаменатель отличный от нуля." << endl;
        cout<<"Введите знаменатель ";
        cin >> obj2.den;
    }

    //Консруктор копирования
    Fract obj_test_2(1, 3);
    Fract obj_test_3 = obj_test_2;
    cout<<"Результат работы конструктора копирования: "<< obj_test_3 << endl << endl;

    //Конструктор перемещения
    Fract obj_test_4(0, 11);
    Fract obj_test_5(std::move(obj_test_4));
    cout<<"Результат работы конструктора перемещения: " << obj_test_5 << endl << endl;

    cout <<"Первая дробь: ";
    if (obj.den>0){
        cout<<obj<<endl;
    }
    else
    {
        obj.den*=-1;
        obj.num*=-1;
        cout<<obj<<endl;
    }

    cout <<"Вторая дробь: ";
    if (obj2.den>0){
        cout<<obj2<<endl;
    }
    else
    {
        obj2.den*=-1;
        obj2.num*=-1;
        cout<<obj2<<endl;
    }

    cout << "Работа арифметических операторов:" << endl;
    cout << "Оператор сложения: "<< "+  " << obj + obj2 << endl;
    cout << "Оператор вычитания: "<< "-  " << obj - obj2 << endl;
    cout << "Оператор умножения: "<< "*  " << obj * obj2 << endl;
    if (obj2.num != 0)
    {
        cout << "Оператор деления: "<< "/  " << obj / obj2 << endl;
    }
    else{
        cout << "Ошибка! Деление на 0 недопустимо. " << endl;
    }

    cout <<"Арифмитичские операции с единицей: " << endl;
    cout <<"Оператор сложения: " << 1 + obj << endl;
    cout <<"Оператор вычитания: " <<  1 - obj << endl;
    cout <<"Оператор умножения: " <<  1 * obj << endl;
    cout <<"Оператор деления: " <<  1 / obj << endl;

    cout <<"Арифмитичские операции с единицей в обратную сторону: " << endl;
    cout <<"Оператор сложения: " << obj + 1 << endl;
    cout <<"Оператор вычитания: " << obj - 1 << endl;
    cout <<"Оператор умножения: " << obj * 1 << endl;
    cout <<"Оператор деления: " << obj / 1 << endl << endl;

    cout <<"Работа унарных операторов: " << endl;
    cout<< "Оператор +: " << +obj << endl;
    cout <<"Оператор -: " << -obj << endl << endl;

    cout<<"Работа операторов сравнения: " << endl;

    cout<<"Оператор ==" << endl;
    if(obj == obj2){
        cout<<"Дроби равны" << endl;
    }
    else{
        cout<<"Дроби разные" << endl;
    }

    cout<<"Оператор >=" << endl;
    if(obj>=obj2){
        cout << "Первая дробь больше или равна второй" << endl;
    }
    else{
        cout << "Первая дробь не больше и не равна второй дроби" << endl;
    }

    cout<<"Оператор >" << endl;
    if(obj>obj2){
        cout << "Первая дробь больше второй" << endl;
    }
    else{
        cout << "Первая дробь не больше второй дроби" << endl;
    }

    cout<<"Оператор <=" << endl;
    if(obj<=obj2){
        cout << "Первая дробь меньше или равна второй" << endl;
    }
    else{
        cout << "Первая дробь не меньше и не равна второй дроби" << endl;
    }

    cout<<"Оператор <" << endl;
    if(obj<obj2){
        cout << "Первая дробь меньше второй" << endl;
    }
    else{
        cout << "Первая дробь не меньше второй дроби" << endl;
    }

    cout<<"Оператор != " << endl;
    if(obj!=obj2){
        cout << "Первая дробь не равна второй" << endl << endl;
    }
    else{
        cout << "Первая дробь равна второй дроби" << endl << endl;
    }

    cout << "Работа операторов присваивания: " << endl;
    Fract obj3(1, 2);
    obj3 = obj2;
    cout<<"Оператор =: " << "Первая дробь: " << obj2 <<";"<< " Вторая дробь: " << obj3 <<endl;

    Fract obj4(1, 2);
    obj4*=obj2;
    cout<<"Оператор *=: " << "Первая дробь: " << obj2 <<";"<< " Вторая дробь: " << obj4 <<endl;

    Fract obj5(1, 2);
    obj5/=obj2;
    cout<<"Оператор /=: " << "Первая дробь: " << obj2 <<";"<< " Вторая дробь: " << obj5 <<endl;

    Fract obj6(1, 2);
    obj6+=obj2;
    cout<<"Оператор +=: " << "Первая дробь: " << obj2 <<";"<< " Вторая дробь: " << obj6 <<endl;

    Fract obj7(1, 2);
    obj7-=obj2;
    cout<<"Оператор -=: " << "Первая дробь: " << obj2 <<";"<< " Вторая дробь: " << obj7 <<endl <<endl;


    cout<<"Работа приведения типов: "<< endl;
    float rez_1 = (float)obj;
    cout<<"Приведение дроби к типу float: "<< rez_1 <<endl;
    double rez_2 = (double)obj;
    cout<<"Приведение дроби к типу double: "<< rez_2 <<endl;
    string rez_3 = (string)obj;
    cout<<"Приведение дроби к типу string: "<< rez_3 <<endl;

    return 0;
}