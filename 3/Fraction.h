#ifndef LAB3_FRACTION_H
#define LAB3_FRACTION_H

#pragma once
#include <iostream>

class Fract {
    friend Fract operator+(const Fract &left, const Fract &right); //перегрузка оператора +
    friend Fract operator-(const Fract& left, const Fract& right); //перегрузка оператора -
    friend Fract operator*(const Fract left, const Fract right); //перегрузка оператора *
    friend Fract operator/(const Fract left, const Fract right); //перегрузка оператора /
    friend bool operator==(const Fract left, const Fract right); //перегрузка оператора ==
    friend bool operator!=(const Fract left, const Fract right); //перегрузка оператора !=
    friend bool operator<(const Fract left, const Fract right); //перегрузка оператора <
    friend bool operator>(const Fract left, const Fract right); //перегрузка оператора >
    friend bool operator<=(const Fract left, const Fract right); //перегрузка оператора <=
    friend bool operator>=(const Fract left, const Fract right); //перегрузка оператора >=
    friend std::ostream& operator<<(std::ostream& out, const Fract& obj);
    friend std::istream& operator>>(std::istream& in, Fract& obj);
public:
    int num; //числитель
    int den; //знаменатель
    void reduce();//сокращение дроби
    inline int getDen()const;
    inline int getNum()const;
    inline void setDen(int den);
    inline void setNum(int num);

    Fract(); //конструктор по умолчанию
    Fract(int num, int denom);
    Fract(int num);
    Fract(const Fract& fract); //конструктор копирования
    Fract(Fract&& fract)noexcept; //конструктор перемещения

    Fract operator=(const Fract obj); //перегрузка оператора присваивания =
    Fract operator+=(const Fract obj);  //перегрузка оператора присваивания +=
    Fract operator-=(const Fract obj);  //перегрузка оператора присваивания -=
    Fract operator*=(const Fract obj);  //перегрузка оператора присваивания *=
    Fract operator/=(const Fract obj);  //перегрузка оператора присваивания /=

    Fract operator+() const; //перегрузка унарного оператора +
    Fract operator-() const; //перегрузка унарного оператора -
    //explicit перед объявлением каждого оператора указывает на то, что неявное преобразование типа запрещено, и приведение типов будет осуществляться только явно, с использованием операторов приведения типа.
    explicit operator float(); //перегрузка приведения типа float, позволяет привести объект класса Fract к типу float
    explicit operator double(); //перегрузка приведения типа double, позволяет привести объект класса Fract к типу double
    explicit operator std::string(); //перегрузка приведения типа string, позволяет привести объект класса Fract к типу string
};

inline int Fract::getDen()const{ //реализация геттера для получения поля знаменателя
    return den;
}
inline int Fract::getNum()const { //реализация геттера для получения поля числителя
    return num;
}
inline void Fract::setDen(int denom) { //реализация сеттера для установки значения поля заменателя
    if (denom>0) den = denom; //проверка на положительный знаменатель, если положителен - то метод изменяет значение знаменателя объекта класса на заданное, еcли <=0, то метод не изменяет значение знаменателя объекта.
}
inline void Fract::setNum(int numin) { //реализация сеттера для установки значения поля числителя
    num = numin; //изменяет значение числителя объекта класса на заданное значение, не выполняя дополнительных проверок.
}


#endif //LAB3_FRACTION_H
