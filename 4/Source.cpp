#include "Polynom.h"
#include <algorithm>
#include <string>
#include <cmath>

//конструкторы и дестркуторы
Polynom::Polynom(int* arr, int n) {
    multiplier.reserve(n); //Резервируется память для n элементов в векторе multiplier, чтобы избежать повторных выделений памяти при добавлении элементов.
    multiplier.insert(multiplier.begin(), &arr[0], &arr[n]); //Происходит вставка элементов из массива arr в начало вектора multiplier, диапазон задается указателями
}
Polynom::Polynom(float* arr, int n) {
    multiplier.reserve(n);
    multiplier.insert(multiplier.begin(), &arr[0], &arr[n]); //Происходит вставка элементов из массива arr в начало вектора multiplier, диапазон задается указателями
}
Polynom::Polynom(double* arr, int n) {
    multiplier.reserve(n);
    multiplier.insert(multiplier.begin(), &arr[0], &arr[n]); //Происходит вставка элементов из массива arr в начало вектора multiplier, диапазон задается указателями
}
Polynom::Polynom(const Polynom& obj) { //конструктор копирования
    multiplier = obj.multiplier;
}
Polynom::Polynom(Polynom&& obj)noexcept { //конструктор перемещения
    multiplier = move(obj.multiplier);
}
Polynom::~Polynom() {
    multiplier.clear(); //удаляет все эелементы из вектора и освобождает используемую для них память
}


double Polynom::countX(double x)const { //метод countX() класса Polynom, который вычисляет значение полинома для заданного значения x.
    double result = 0;
    if (x == 0){
        result = getMult().at(0);
    }
    else{
        for (int i = 0; i < getMult().size(); i++) { //проходимся по элементам многочлена
            result += getMult().at(i)*pow(x,i); //вычисление произведения этого элемента на x, возведенное в степень i, с использованием функции pow().
        }
    }
    return result; //возвращаем полученный результат
}

//at()
double& Polynom::at(int id) {
    return getMult().at(id);
}
double Polynom::at(int id)const {
    return getMult().at(id);
}

//арифметические операторы
Polynom Polynom::operator+()const{ //унарный оператор сложения
    return *this; //просто возвращаем объект
}
Polynom Polynom::operator-()const { //унарный оператор вычитания
    Polynom result(*this); //создаем новый объект - копия текущего объекта при помощи конструктора копирования
    for (int i = 0; i < result.multiplier.size(); i++) { //проходимся по всему полиному
        result.multiplier[i] = -result.multiplier[i]; //Для каждого элемента выполняется отрицание (-), то есть знак коэффициента меняется на противоположный.
    }
    return result; //возвращаемый измененный объект уже с противоположными знаками у коэффициентов
}

void Polynom::reduce(){
    while (multiplier[multiplier.size() - 1] == 0 && multiplier.size() > 1){
        multiplier.pop_back();
    }
}

Polynom operator+(const Polynom& left, const Polynom& right) { //бинарный оператор сложения
    Polynom result; //новый объект Polynom под названием result, который будет содержать результат сложения.
    int size = 0;
    if (left.multiplier.size() >= right.multiplier.size()) { //проверка размеров векторов multiplier у объектов left и right.
        result = left; //если размер левого многочлена больше правого, то в переменную result записываем его
        size = right.multiplier.size(); //переменной size присваиваем размер правого многочлена
    }
    else {
        result = right; //в противоположном случае записываем в переменную result правый многочлен
        size = left.multiplier.size(); //переменной size присваиваем размер левого многочлена
    }
    for (int i = 0; i < size; i++) { //идем до конца размера одного из меньших по длине многочленов (чтобы сложить конкретно одинаковые по степеням коэффициенты и не выйти за пределы самих многочленов)
        result.at(i) += right.at(i); //для каждого индекса одного многочлена прибавляем значение индекса второго многочлена
    }
    result.reduce();
    return result; //объект result, содержащий сумму коэффициентов, возвращается в качестве результата оператора.
}
Polynom operator-(const Polynom& left, const Polynom& right) { //бинарный оператор вычитания
    return left + (-right); //по аналогии с лаб№3 вычитание происходит при помощи перегруженного оператора сложения
}
Polynom operator*(const Polynom& left, const Polynom& right) { //перегрузка бинарного оператора умножения 
    int size = left.multiplier.size() + right.multiplier.size() - 1; //Это значение будет использоваться для определения размера вектора коэффициентов у результирующего полинома.
    double* arr = new double[size]{0}; //создается динамический массив типа double размером size, инициализированный нулями.
    Polynom result(arr,size);
    delete[] arr;
    for (int i = 0; i < left.multiplier.size(); i++) {
        for (int j = 0; j < right.multiplier.size(); j++) {
            result.multiplier.at(i + j) += left.at(i) * right.at(j); //в промежуточную переменную result прибавляем результат перемножения коэффициентов обоих многочленов
        }
    }
    return result; //возвращаем полученный результат
}

//перегрузка операторов сравнения
bool operator==(const Polynom& left, const Polynom& right) {
    if (left.multiplier.size() != right.multiplier.size()){
        return 0;
    }
    return (left.multiplier == right.multiplier); //если многочлены равны то функция возвращает 1, иначе - 0
}
bool operator!=(const Polynom& left, const Polynom& right) {
    if (left.multiplier.size() != right.multiplier.size()){
        return 1;
    }
    return !(left == right); //если многочлены не равны то функция возвращает 1, иначе 0.
}

//перегрузка операторов присваивания
Polynom Polynom::operator=(const Polynom& obj) {
    multiplier = obj.multiplier;
    return *this;
}
Polynom Polynom::operator+=(const Polynom& obj) {
    *this = *this + obj;
    return *this;
}
Polynom Polynom::operator-=(const Polynom& obj) {
    *this = *this - obj; //вычитаем из текущего полинома второй полином
    return *this;
}
Polynom Polynom::operator*=(const Polynom& obj) {
    *this = *this * obj; //перемножаем оба полинома
    return *this;
}

//print
std::ostream& operator<<(std::ostream& out, const Polynom& obj) {
    //out << (std::string)obj;
    for (int i = (obj.multiplier.size()-1); i >= 0; i--) { //идем от последнего элемента к первому
        if (obj.at(i) != 0) { //проверяем не равен ли текущий элемент нулю
            if (i != obj.multiplier.size() - 1) { //проверяет, не является ли текущий коэффициент первым (самым высоким) в полиноме
                if (obj.at(i) >= 0) out << " + "; //если текущий коэффициент положителен - добавляем знак "+"
                if (obj.at(i) < 0) out << " - "; //если текущий коэффициент отрицателен - добавляем знак "-"
            }
            else if (obj.at(i) < 0) out << "-"; //когда первый ненулевой коэффициент является отрицательным - перед ним выводится символ минуса
            if (i != 0) { //если степень не равна 0
                out << abs(obj.at(i)) << "X^" << i; //выводится его модуль затем выводится X и степень
            }
            else { //иначе просто выводим коэффициент
                out << abs(obj.at(i));
            }
        }
    }
    if (obj.multiplier.size() == 1 && obj.at(0) == 0){
        out << " 0";
    }
    out << std::endl; //символ новой строки (std::endl)
    return out;  //возвращается ссылка на объект потока вывода out.
}

//convert to string
Polynom::operator std::string() const{
    std::string str; //создаем строковый объект который будет содержать конечный результат
    for (int i = multiplier.size()-1; i >= 0; i--) { //идем от последнего элемента к первому
        if (at(i) != 0) { //если текущий коэффициент не равен 0
            if (i != 0) { //если степень элемента не равна 0
                str += std::to_string(at(i)); //преобразовываем текущий коэффциент в строчку и добавляем в переменную str
                str += "X^"; //добавляем значок икса со знаком степени
                str += std::to_string(i);  //добавляем показатель степени
                if (i>0){
                    str +=  " + "; //добавляем символ пробела в конец строки
                }
                else{
                    str += " - "; //добавляем символ пробела в конец строки
                }
            }
            else { //если степень равна 0
                str += std::to_string(at(i)); //просто выводим значение элемента
            }
        }
    }
    return str;
}