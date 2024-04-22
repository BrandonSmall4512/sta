package main

import (
	"fmt"
	"math"
	"os"
	"strconv"
)

func isPrime(num int) bool {
	if num < 2 {
		return false
	}
	for i := 2; i <= int(math.Sqrt(float64(num))); i++ {
		if num%i == 0 {
			return false
		}
	}
	return true
}

func countTriplets(left_border, right_border int) int {
	count := 0
	for p := left_border; p <= right_border; p++ {
		if isPrime(p) {
			for a := left_border; a <= right_border; a++ {
				for b := left_border; b <= right_border; b++ {
					if (math.Sqrt(float64(a)))-math.Sqrt(float64(b)) == math.Sqrt(float64(p)) {
						count++
						fmt.Print(a, b, p, "\n")
					}
				}
			}
		}
	}
	return count
}

func main() {
	file, err := os.Open("E:\\Projects\\3 Sem\\Golang\\Zadachi\\134\\Input")
	if err != nil {
		fmt.Println(err)
		return
	}
	defer file.Close()

	var left_border, right_border int
	_, err = fmt.Fscanf(file, "%d %d", &left_border, &right_border)
	if err != nil {
		fmt.Println(err)
		return
	}

	count := countTriplets(left_border, right_border)

	outputFile, err := os.Create("E:\\Projects\\3 Sem\\Golang\\Zadachi\\134\\Output")
	if err != nil {
		fmt.Println(err)
		return
	}
	defer outputFile.Close()

	_, err = outputFile.WriteString(strconv.Itoa(count))
	if err != nil {
		fmt.Println(err)
		return
	}
}
