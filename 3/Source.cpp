#include "Fraction.h"
#include <iostream>
#include <string>

using std::string;

Fract::Fract() { //конструктор по умолчанию
    num = 1;
    den = 1;
}

Fract::Fract(int numen) {
    num = numen;
    den = 1;
}

Fract::Fract(int numen, int denom) : Fract() { //ТЗ: знаменатель все время должен быть положительным.
    if (denom > 0) {  //если знаменатель больше нуля
        den = denom; //то он устанавливается как значение знаменателя для объекта
        num = numen;  //числитель устанавливается как значение numen/
    }
    else if (denom < 0) { //если знаменатель отрицателен
        den = -denom; //делаем знаменатель положительным
        num = -numen; //переносим знак минуса из знаменателя в числитель
    }
    reduce(); //сокращение дроби
}

Fract::Fract(const Fract& fract){  //конструктор копирования
    num = fract.num;
    den = fract.den;
}

Fract::Fract(Fract&& fract)noexcept { //конструктор перемещения, спецификация noexcept не будет возбуждать исключения
    num = fract.num;
    den = fract.den;
}
//алгоритм Евклида для нахождения НОД
int gcd(int a, int b) { //нахождение наибольшего общего делителя для числителя и знаменателя
    while (b > 0) {
        int c = a % b;
        a = b;
        b = c;
    }
    return a; //в итоге а = НОД (наибольший общий делитель)
}
//метод reduce - сокращение дробей
void Fract::reduce() {  //сокращение дроби путем деления числителя и знаменателя на их наибольший общий делитель (НОД).
    int g = gcd(abs(num), den); //находим НОД от числителя и знаменателя дроби
    if (g != 1) {
        num /= g; //числитель дроби делится на этот НОД
        den /= g; //знаменатель дроби делится на этот НОД
    }
}
//метод оператора + для сложения двух дробей
Fract operator+(const Fract &left, const Fract &right) {
    Fract answer(left.getNum() * right.getDen() + right.getNum() * left.getDen(), left.getDen() * right.getDen()); //умножаем левый числитель на правый знаменатель + правый чилитель на левый знаменатель = числитель новой дроби
    answer.reduce(); //затем перемножаем знаменатил обеих дробей = знаменатель новой дроби
    return answer; //получаем ответ = новая дробь
}
//метод оператора - для вычитания двух дробей (использует оператор сложения для отсутствия дублирования кода)
Fract operator-(const Fract &left, const Fract &right) {
    return left + (-right);
}
//метод оператора * для перемножения двух дробей
Fract operator*(const Fract left, const Fract right) {
    Fract temp(right.getNum() * left.getNum(), left.getDen() * right.getDen());
    temp.reduce(); //сокращение дроби
    return temp;
}

Fract operator/(const Fract left, const Fract right)
{
    Fract temp;
    temp.setNum(left.getNum() * right.getDen()); //устанавливаем значение числителя = числитель первой дроби * знаменатель второй дроби
    if (right.getNum() >= 0){ //если числитель второй дроби положителен или равен нулю
        temp.setDen(left.getDen() * right.getNum()); //устанавливем значение числителя новой дроби как произведение знаменателя первой дроби на числитель второй дроби
    }
    else { //если числитель второй дроби отрицателен (если вторая дробь отрицательна)
        Fract r = -right; //создаем положительную копию второй дроби с помощью которой значение знаменателя новой дроби
        temp.setDen(left.getDen() *
                    r.getNum()); //устанавливаем значение знаменателя новой дроби как произведение знаменателя первой дроби на числитель второй дроби
        temp.reduce(); //сокращаем полученный результат
        return -temp;//возвращаем полученное значение с отрицательным знаком
    }
    temp.reduce();
    return temp;
}
//операторы сравнения двух дробей
bool operator==(const Fract left, const Fract right) {
    return ((left.num == right.num) && (left.den == right.den));
}

bool operator!=(const Fract left, const Fract right) {
    return !(left == right);
}
//оператор меньше
bool operator<(const Fract left, const Fract right) { //a/b < c/d, когда ad < bc.
    int lside = left.getNum() * right.getDen();
    int rside = left.getDen() * right.getNum();
    return (lside < rside);
}
//оператор больше
bool operator>(const Fract left, const Fract right) { //a/b > c/d, когда ad > bc.
    int lside = left.getNum() * right.getDen();
    int rside = left.getDen() * right.getNum();
    return (lside > rside);
}
//опертаор меньше или равно
bool operator<=(const Fract left, const Fract right) {
    return ((left < right) || (left == right));
}
//оператор больше или равно
bool operator>=(const Fract left, const Fract right) {
    return ((left > right) || (left == right));
}
//перегрузка оператора вывода - оператор принимает два аргумента: ссылку на объект потока вывода (std::ostream&) и ссылку на объект Fract (const Fract&).
std::ostream& operator<<(std::ostream& out, const Fract& obj) {
    out << obj.num; //выводим числитель дроби obj.num в поток out
 //   if (obj.num != 0 && obj.den != 1)
 //   { //если числитель не равен нулю и знаменатель obj.den не равен единице
        out << "/" << obj.den; //функция выводит в поток символ "/" и знаменатель дроби obj.den.
//}
    return out; //функция возвращает объект потока вывода out.
}
//перегрузка оператора ввода - оператор принимает два аргумента: ссылку на объект потока ввода (std::istream&) и ссылку на объект Fract (Fract&).
std::istream& operator>>(std::istream& in, Fract& fract) {
    std::string str; //объявление строковой переменной str, в которую происходит чтение строки из потока ввода in
    in >> fract.num; //считывание числителя дроби
    in >> str; //вводим знак /
    in >> fract.den; //считывание знаменателя дроби fract из потока in.
    fract.reduce(); //вызов метода reduce объекта fract для сокращения полученной дроби
    return in;  //функция возвращает объект потока ввода in
}
//перегрузка операторов присваиваания
//оператор присваивания (=)
Fract Fract::operator=(const Fract obj) {
    setNum(obj.getNum());
    setDen(obj.getDen());
    return *this;
}
//оператор присваивания (+=)
Fract Fract::operator+=(const Fract obj) {
    *this = *this + obj; //текущий равен объект равен текущему объекту + вторая дробь
    return *this; // возвращаем ссылку на текущий объект
}
//оператор присваивания (-=)
Fract Fract::operator-=(const Fract obj) {
    *this = *this - obj; //текущий равен объект равен текущему объекту - вторая дробь
    return *this;
}
//оператор присваивания (*=)
Fract Fract::operator*=(const Fract obj) {
    *this = *this * obj; //текущий равен объект равен текущему объекту * вторая дробь
    return *this;
}
//оператор присваивания (/=)
Fract Fract::operator/=(const Fract obj) {
    *this = *this / obj; //текущий равен объект равен текущему объекту / вторая дробь
    return *this;
}
//перегрузка унарного оператора (+)
Fract Fract::operator+() const {
    return *this;
}
//перегрузка унарного оператора (-)
Fract Fract::operator-() const {
    Fract temp; //создаем временный объект
    temp.setNum(-getNum()); //устанавливаем полученное значение числителя делая его отрицательным
    temp.setDen(getDen()); //устанавливаем полученное значение знаменателя
    return temp; //возвращаем полученный результат
}
//перегрузка приведения типов в float и double, string
//перегрузка приведения типа float
Fract::operator float() {
    return (float)num / (float)den; //переводим числитель и знаменатель дроби в тип float и возвращаем полученное значение типа float
}
//перегрузка приведения типа double
Fract::operator double() {
    return (double)num / (double)den; //переводим числитель и знаменатель дроби в тип double и возвращаем полученное значение типа double
}
//перегрузка приведения типа string
Fract::operator std::string() {
    return std::to_string(num) + '/' + std::to_string(den); //числитель и знаменатель переводятся в тип string и склеиваются знаком /
}
