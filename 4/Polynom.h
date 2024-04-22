#ifndef LAB4_POLYNOM_H
#define LAB4_POLYNOM_H

#pragma once
#include <iostream>
#include <vector>
#include <initializer_list>
using std::vector;

class Polynom
{
private:
    vector <double> multiplier;
public:
    //inline methods
    inline vector <double> getMult()const;
    inline vector <double>& getMult();
    inline void setMult(vector <double>& mult);

    //constructors and destructors
    Polynom()=default;
    Polynom(int* arr, int n);
    Polynom(float* arr, int n);
    Polynom(double* arr, int n);
    Polynom(const Polynom& obj);
    Polynom(Polynom&& obj)noexcept;
    ~Polynom();

    //counting for given x
    double countX(double x)const;

    //at()
    double& at(int id);
    double at(int id)const;

    //арифметические операторы
    Polynom operator-()const;
    Polynom operator+()const;

    void reduce();

    //унарные операторы
    friend Polynom operator+(const Polynom& left, const Polynom& right);
    friend Polynom operator-(const Polynom& left, const Polynom& right);
    friend Polynom operator*(const Polynom& left, const Polynom& right);

    //операторы сравнения
    friend bool operator==(const Polynom& left, const Polynom& right);
    friend bool operator!=(const Polynom& left, const Polynom& right);

    //операторы присваивания
    Polynom operator=(const Polynom& obj);
    Polynom operator+=(const Polynom& obj);
    Polynom operator-=(const Polynom& obj);
    Polynom operator*=(const Polynom& obj);

    //вывод
    friend std::ostream& operator<<(std::ostream& out, const Polynom& obj);

    //перевод в строку
    explicit operator std::string() const;
};

inline vector <double> Polynom::getMult()const
{
    return multiplier;
}
inline vector <double>& Polynom::getMult()
{
    return multiplier;
}
inline void Polynom::setMult(vector <double>& mult)
{
    multiplier = mult;
}

#endif