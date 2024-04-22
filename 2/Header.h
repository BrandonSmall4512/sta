#ifndef LAB2_HEADER_H
#define LAB2_HEADER_H

#pragma once
#include <iostream>
#include <ctime>
#include <string>
#include <time.h>

using namespace std;

class DateTime
{
private:
    struct Time_st{
        int hours;
        int minutes;
        int seconds;
    }Time;

    struct Date_st{
        int years;
        int months;
        int days;
    }Date;

public:

    DateTime();

    DateTime(const DateTime& copy);

    DateTime(int d, int m, int y, int h, int min, int sec);

    DateTime(DateTime&& transfer);

    inline int GetYears() const;
    inline int GetMonths() const;
    inline int GetDays() const;
    inline int GetHours() const;
    inline int GetMinutes() const;
    inline int GetSeconds() const;

    inline void SetYears(int y);
    inline void SetMonths(int m);
    inline void SetDays(int d);
    inline void SetHours(int h);
    inline void SetMinutes(int min);
    inline void SetSeconds(int sec);

    static Date_st CurrentDate();

    static Time_st CurrentTime();

    static bool DataCorrect(int y, int m, int d);

    static bool TimeCorrect(int h, int min, int sec);

    string DateTimeStr(string format);

    Date_st date_struct() const;

    Time_st time_struct() const;

    int DaysTo(DateTime &date1, DateTime &date2);

    long long SecondsTo(DateTime &date1, DateTime &date2);

    void AddYears(int y);
    void AddMonths(int m);
    void AddDays(int d);
    void AddHours(int h);
    void AddMinutes(int min);
    void AddSeconds(int sec);
};

#endif //LAB2_HEADER_H
