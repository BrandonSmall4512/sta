package main

import (
	"fmt"
	"os"
)

func lcd(a, b int) int {
	for b > 0 {
		c := a % b
		a = b
		b = c
	}
	return a
}

func main() {

	fin, err := os.Open("E:\\Projects\\3 Sem\\Golang\\Zadachi\\66\\Input.txt")
	if err != nil {
		panic(err)
	}
	defer fin.Close()

	fout, err := os.Create("E:\\Projects\\3 Sem\\Golang\\Zadachi\\66\\Output.txt")
	if err != nil {
		panic(err)
	}
	defer fout.Close()

	limit_of_fraction_value := 0.0
	denominator := 0
	numerator := 0
	count := 0

	var temp float64
	_, err = fmt.Fscanf(fin, "%f", &temp)
	if temp > 0 && temp <= 1 {
		limit_of_fraction_value = temp
	} else {
		panic("Выход за пределы допустимого значения для предельного значения дроби")
	}
	fmt.Fprintf(fout, "Предел значения дроби: %.4f\n", limit_of_fraction_value)

	temp = 0
	_, err = fmt.Fscanf(fin, "%f", &temp)
	if err != nil {
		panic(err)
	}
	if temp > 2 && temp < 1e5 {
		denominator = int(temp)
	} else {
		panic("Выход за пределы допустимого значения для знаменателя")
	}
	fmt.Fprintf(fout, "Значение знаменателя: %d\n\n", denominator)

	for numerator = 1; numerator < denominator; numerator++ {
		if float64(numerator)/float64(denominator) <= limit_of_fraction_value {
			nod := lcd(numerator, denominator)
			if nod == 1 {
				fmt.Fprintf(fout, "Дробь: %d/%d\n", numerator, denominator)
				fmt.Fprintf(fout, "НОД: %d\n\n", nod)
				count++
			}
		}
	}
	fmt.Fprintf(fout, "Количество подходящих дробей: %d\n", count)
	fmt.Printf("Количество подходящих дробей: %d\n", count)
}
