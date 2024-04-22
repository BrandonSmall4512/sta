package main

import (
	"fmt"
	"math"
	"os"
)

func readFile() (uint, uint) {
	file, err := os.Open("E:\\Projects\\Zadachi\\17\\Input.txt")
	if err != nil {
		panic(err)
	}
	defer file.Close()

	var origNum, operCount uint
	_, err = fmt.Fscanf(file, "%d %d", &origNum, &operCount)
	if err != nil {
		panic(err)
	}

	return origNum, operCount
}

func main() {
	origNum, operCount := readFile()

	fout, err := os.Create("E:\\Projects\\3 Sem\\Golang\\Zadachi\\17\\Output.txt")
	if err != nil {
		panic(err)
	}
	defer fout.Close()

	var digit, sumOfDigits uint
	oc := operCount
	on := origNum
	i := 1

	fmt.Println("Первородное число:", origNum)
	fmt.Println("Количество операций:", operCount, "\n")

	for operCount > 0 {
		fmt.Println("Вычисление №", i, ":\n")
		fmt.Println("Обрабатываемое число:", origNum, "\n")

		for origNum != 0 {
			digit = origNum % 10
			sumOfDigits += uint(math.Pow(float64(digit), 2))
			origNum /= 10

			fmt.Println("Обрабатываемая цифра:", digit)
			fmt.Println("Следующая в обработке:", origNum)
			fmt.Println("Сумма цифр в квадрате:", sumOfDigits, "\n")
		}
		origNum = sumOfDigits
		fmt.Println("Итоговое число:", origNum, "\n")
		operCount--
		i++
	}
	fmt.Println("Сумма цифр числа", on, "в квадрате после", oc, "раз вычислений:", sumOfDigits)
	fmt.Fprintf(fout, "Сумма цифр числа %d в квадрате после %d раз вычислений: %d\n", on, oc, sumOfDigits)
}
