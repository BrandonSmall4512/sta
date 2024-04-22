#include <iostream>
#include <string>
#include "Header.h"

using namespace std;

int main(int argc, char* argv[])
{
    system("chcp 65001");
    DateTime g; //конструктор по умолчанию
    DateTime f(0, 28, 7, 21, 10, 2015); //конструктор со значениями
    DateTime h(f); //конструктор копирования

    cout<< "Конструктор по умолчанию:" << endl;
    cout<< "Количество секунд: " << g.GetSeconds() << endl;
    cout<< "Количество минут: " << g.GetMinutes() << endl;
    cout<< "Количество часов: " << g.GetHours() << endl;
    cout<< "Количество дней: " << g.GetDays() << endl;
    cout<< "Количество месяцев: " << g.GetMonths() << endl;
    cout<< "Количество лет: " << g.GetYears() << endl;

    cout<< "Результат работы конструктора копирования:" << endl;
    cout<< "Количество секунд: " << h.GetSeconds() << endl;
    cout<< "Количество минут: " << h.GetMinutes() << endl;
    cout<< "Количество часов: " << h.GetHours() << endl;
    cout<< "Количество дней: " << h.GetDays() << endl;
    cout<< "Количество месяцев: " << h.GetMonths() << endl;
    cout<< "Количество лет: " << h.GetYears() << endl;

    string format = "ss:mm:hh DD:MM:YY";
    cout << "Полученная по формату строка: " << h.DateTimeStr(format) << endl;

    DateTime date1 (1, 1, 1, 20, 4, 2016);
    DateTime date2 (1, 1, 1, 10, 6, 2016);
    int diff = g.DaysTo(date1, date2);
    cout << "Дней между " << date1.DateTimeStr(format) << " и " << date2.DateTimeStr(format) << " = " << diff << endl;
    long long diff_2 = g.SecondsTo(date1, date2);
    cout << "Секунд между " << date1.DateTimeStr(format) << " и " << date2.DateTimeStr(format) << " = " << diff_2 << endl;

    DateTime now(0, 0, 0, 1, 5, 2023);
    now.AddYears(0);
    now.AddMonths(0);
    now.AddDays(366);
    now.AddHours(0);
    now.AddMinutes(0);
    now.AddSeconds(0);
    cout<< "Результат работы функций добавления времени:" << endl;
    cout<< "Количество секунд: " << now.GetSeconds() << endl;
    cout<< "Количество минут: " << now.GetMinutes() << endl;
    cout<< "Количество часов: " << now.GetHours() << endl;
    cout<< "Количество дней: " << now.GetDays() << endl;
    cout<< "Количество месяцев: " << now.GetMonths() << endl;
    cout<< "Количество лет: " << now.GetYears() << endl;
    return 0;
}