#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <ctime>
#include <string>
#include <time.h>
#include <cmath>
#include "Header.h"

using namespace std;

int daysInMonth[12] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

//конструктор без параметров
DateTime::DateTime(){// :: - бинарный оператор, уточняет область
    SetYears(2001);
    SetMonths(9);
    SetDays(11);
    SetHours(0);
    SetMinutes(0);
    SetSeconds(0);
}
//конструктор копирования класса DateTime
DateTime::DateTime(const DateTime& copy){
    Time = copy.Time;
    Date = copy.Date;
}
//конструктор с параметрами
DateTime::DateTime(int sec, int min, int h, int d, int m, int y){
    SetYears(y);
    SetMonths(m);
    SetDays(d);
    SetHours(h);
    SetMinutes(min);
    SetSeconds(sec);
}
//Конструктор перемещения класса DateTime
DateTime::DateTime(DateTime&& transfer){
    Time = move(transfer.Time);
    Date = move(transfer.Date);
}

inline int DateTime::GetYears() const {return Date.years;}
inline int DateTime::GetMonths() const {return Date.months;}
inline int DateTime::GetDays() const {return Date.days;}
inline int DateTime::GetHours() const {return Time.hours;}
inline int DateTime::GetMinutes() const {return Time.minutes;}
inline int DateTime::GetSeconds() const {return Time.seconds;}

inline void DateTime::SetYears(int y){
    if (y >= 0) {Date.years = y;}
    else {Date.years = 0;}
}

inline void DateTime::SetMonths(int m){
    if (m >= 1 && m <= 12){Date.months = m;}
}

inline void DateTime::SetDays(int d){
    if (d >= 1 && d <= 31){Date.days = d;}
    else{Date.days = 1;}
}

inline void DateTime::SetHours(int h){
    if (h >= 0 && h < 24){Time.hours = h;}
    else{Time.hours = 0;}
}

inline void DateTime::SetMinutes(int min){
    if (min >= 0 && min < 60){Time.minutes = min;}
    else{Time.minutes = 0;}
}

inline void DateTime::SetSeconds(int sec){
    if (sec >= 0 && sec < 60){Time.seconds = sec;}
    else{Time.seconds = 0;}
}

bool DateTime::DataCorrect(int y, int m, int d){
    if (((y >= 0) && ((((m == 1) || (m == 3) || (m == 5) || (m == 7) || (m == 8) || (m == 10) || (m == 12)) && (d <= 31))\
				 || (((m == 4) || (m == 6) || (m == 9) || (m == 11)) && (d <= 30))\
					|| ((m == 2) && (d <= 28)))) && (d > 0)){
        return true;
    }
    else { return false; }
}

bool DateTime::TimeCorrect(int h, int min, int sec){
    if (h >= 0 && h <= 23 && min >= 0 && min <= 59 && sec >=0 && sec <= 59){
        return true;
    }
    else { return false; }
}

string DateTime::DateTimeStr(string format){
    if (format.find("DD") != -1){
        format.replace(format.find("DD"), 2, to_string(GetDays()));
    }
    if (format.find("MM") != -1){
        format.replace(format.find("MM"), 2, to_string(GetMonths()));
    }
    if (format.find("YYYY") != -1){
        format.replace(format.find("YYYY"), 4, to_string(GetYears()));
    }
    else if (format.find("YY") != -1){
        format.replace(format.find("YY"), 2, to_string(GetYears()));
    }
    if (format.find("hh") != -1){
        format.replace(format.find("hh"), 2, to_string(GetHours()));
    }
    if (format.find("mm") != -1){
        format.replace(format.find("mm"), 2, to_string(GetMinutes()));
    }
    if (format.find("ss") != -1){
        format.replace(format.find("ss"), 2, to_string(GetSeconds()));
    }
    return format;
}
//возвращение полей объекта DateTime в виде структур (полей даты)
DateTime::Date_st DateTime::date_struct() const{
    return Date;
}
//возвращение полей объекта DateTime в виде структур (полей времени)
DateTime::Time_st DateTime::time_struct() const{
    return Time;
}

int DateTime::DaysTo(DateTime &date1, DateTime &date2){
    int days1 = date1.GetDays() + date1.GetYears()*365;
    for (int i = 0; i < date1.GetMonths()-1; i++){
        days1 += daysInMonth[i];
    }
    int days2 = date2.GetDays() + date2.GetYears()*365;
    for (int i = 0; i < date2.GetMonths()-1; i++){
        days2 += daysInMonth[i];
    }
    return abs(days2 - days1);
}

long long DateTime::SecondsTo(DateTime &date1, DateTime &date2){
    long long sec1 = date1.GetYears() * 365 * 24 * 60 * 60 + date1.GetDays() * 24 * 60 * 60 + date1.GetHours() * 3600 + date1.GetMinutes()*60 + date1.GetSeconds();
    for (int i = 0; i<date1.GetMonths(); i++){
        sec1+=(daysInMonth[i]*24*60*60);
    }
    long long sec2 = date2.GetYears() * 365 * 24 * 60 * 60 + date2.GetDays() * 24 * 60 * 60 + date2.GetHours() * 3600 + date2.GetMinutes()*60 + date2.GetSeconds();
    for (int i = 0; i<date2.GetMonths(); i++){
        sec2+=(daysInMonth[i]*24*60*60);
    }
    return abs(sec2 - sec1);
}


void DateTime::AddYears(int y){
    SetYears(GetYears() + y);
}

void DateTime::AddMonths(int m){
    int k;
    if (DateTime::DataCorrect(GetYears(), GetMonths() + m, GetDays()) == true){
        SetMonths(GetMonths() + m);
    }
    else{
        k = GetMonths() + m;
        SetMonths(k % 12);
        AddYears(k / 12);
    }
}

void DateTime::AddDays(int d){
    if (DateTime::DataCorrect(GetYears(), GetMonths(), GetDays() + d) == true){
        SetDays(GetDays() + d);
    }
    else{
        d += GetDays();
        while(d > daysInMonth[GetMonths()-1]){
            d -= daysInMonth[GetMonths()-1];
            AddMonths(1);
        }
        SetDays(d);
    }
}

void DateTime::AddHours(int h){
    if (DateTime::TimeCorrect(GetHours(), GetMinutes(), GetSeconds()) == true){
        SetHours(GetHours() + h);
    }
    else{
        SetHours((GetHours() + h) % 24);
        AddDays((GetHours() + h) / 24);
    }
}

void DateTime::AddMinutes(int min){
    if (DateTime::TimeCorrect(GetHours(), GetMinutes(), GetSeconds()) == true){
        SetMinutes(GetMinutes() + min);
    }
    else{
        SetMinutes((GetMinutes() + min) % 60);
        AddHours((GetMinutes() + min) / 60);
    }
}

void DateTime::AddSeconds(int sec){
    if (DateTime::TimeCorrect(GetHours(), GetMinutes(), GetSeconds()) == true){
        SetSeconds(GetSeconds() + sec);
    }
    else{
        SetSeconds((GetSeconds() + sec) % 60);
        AddMinutes((GetSeconds() + sec) / 60);
    }
}