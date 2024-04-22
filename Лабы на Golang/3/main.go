package main
import (
"fmt"
"os"
"io/ioutil"
"strings"
"strconv"
)

func getTextFromFile(filename string) (string, error) {
	file, err := os.Open(filename) //открывает файл и возвращает указатель на файл (file) 
    if err != nil { 
        return "", err //ошибку (err), если она есть.
    }
    defer file.Close() //закрытие файла при окончании работы функции

    content, err := ioutil.ReadAll(file) //прочитываем всё содержимое файла указангого перемнной file
    if err != nil {
        return "", err //ошибку (err), если она есть.
    }
    return string(content), nil //преобразуем содержимое файла в строку string(content), nil - нет ошибок
}
//функция проверяет наличие значения what по строке выбранного массива arString[ind]
//ind - индекс, указывающий на внутренний массив arString, в котором будет производиться поиск
//what - строка, которую мы ищем внутри выбранного массива arString[ind].
func getValueOfFlag(length int, ind int, what string, arString [][]string) bool {
    flag := false //если значение what не будет найдено в массиве.
    for i := 0; i < length; i++ { //цикл перебирает элементы внутреннего массива arString[ind]
        if arString[ind][i] == what { //равно ли значение элемента массива arString[ind][i] значению what
            return true //возвращает true, если значение найдено
        }
    }
    return flag //иначе возвращает false.
}
//поиск значения what, но уже в столбце (по индексу ind)
func getValueOfFlagReverse(length int, ind int, what string, arString [][]string) bool {
    flag := false
    for i := 0; i < length; i++ {
        if arString[i][ind] != what {
            return true //начение what найдено в столбце, функция возвращает false
        }
    }
    return flag //иначе false
}
//метод удаляет пробелы из каждой строки, объединяя все слова в строке в одно слово без пробелов.
func spaceFlagHandle(ar []string) {
    for i := 0; i < len(ar); i++ { //Для каждого элемента массива ar
        str := strings.Split(ar[i], " ") //strings.Split разбивает строку на подстроки по разделителю " "
        val := "" //строка val, которая будет содержать объединенные без пробелов подстроки.
        for j := 0; j < len(str); j++ { //внутренний цикл перебирает каждую подстроку в массиве str.
            val += str[j] //объединение всех подстрок в одну строку без пробелов.
        } //Полученная объединенная строка без пробелов присваивается исходному элементу массива ar, заменяя исходную строку.
        ar[i] = val
    }
}
//метод принимает на вход одномерный массив строк ar и переводит их в нижний регистр
func registerFlagHandle(ar []string) {
    for i := 0; i < len(ar); i++ {
        ar[i] = strings.ToLower(ar[i])
    }
}
//работаем с двумя массивами строк _ar1 и _ar2
func getTable(_ar1 []string, _ar2 []string, inputFlag string) [][]string {
    ar1 := make([]string, len(_ar1))
    ar2 := make([]string, len(_ar2))
    copy(ar1, _ar1[:])
    copy(ar2, _ar2[:]) //создаём копии обоих массивов чтобы избежать изменения оригиналов
    arString := make([][]string, len(ar1)) //создаём двумерный масс. для отображения отношения между _ar1 и _ar2
    for i := range arString {
        arString[i] = make([]string, len(ar2))
    }
    if inputFlag == "-b" { //флаг -b = игнорировать пробельные символы
        spaceFlagHandle(ar1)
        spaceFlagHandle(ar2)
    } else if inputFlag == "-i" { //флаг -i = игнорировать регистр букв
        registerFlagHandle(ar1)
        registerFlagHandle(ar2)
    }
    // отметка о равенстве строки из первого и второго файла (для c)
    for i := 0; i < len(ar1); i++ {
        flag := true
        for j := 0; j < len(ar2); j++ { //Если строка из ar1 равна какой-либо строке из ar2, и это равенство еще не было отмечено
            if ar1[i] == ar2[j] && flag && ar1[i] != "" { //и строка из ar1 не является пустой
                flag = false
                arString[i][j] = "ok" //В таблице arString устанавливается пометка "ok" для строки ar1[i] и строки ar2[j]
            } else {
                arString[i][j] = " " //Если строки не равны или равенство уже было отмечено -> в соответствующей ячейке появл. пустая строка
            }
        }
    } //где "ok" отмечает соответствие строк из массивов
    // проверка на "правильность" таблицы, то есть проверка на диагональный вид ok (для c)
    for i := 0; i < len(ar1); i++ {
        for j := 0; j < len(ar2); j++ {
            if arString[i][j] == "ok" {
                flag := true
                for n := i+1; n < len(ar1); n++ {
                    for m := 0; m <= j; m++ { //Проверяется часть таблицы ниже и левее от текущей ячейки, где стоит "ok".
                        if arString[n][m] == "ok" { //Если обнаруживается другая пометка "ok" в области, которая должна быть пустой согласно диагональному виду
                            flag = false
                        }
                    }
                } //если flag стал false то текущая позиция в таблице arString, которая должна быть пустой
                if !flag { //согласно правилам диагонального вида, стирается (" ").
                    arString[i][j] = " "
                }
            }
        }
    }

    // для a, которые будут в начале таблицы
    if len(ar1) != 0 { //убеждаемся, что в ar1 есть элементы для обработки.
        ind := -1
        for j := 0; j < len(ar2); j++ { //Поиск первого вхождения "ok" в столбцах
            for i := 0; i < len(ar1); i++ { //Проходим по столбцам arString, ищем первую пометку "ok" в столбце.
                if arString[i][j] == "ok" { //Если в столбце обнаруживается "ok", сохраняем индекс этого столбца в ind.
                    ind = j
                    break
                }
            }
            if ind != -1 {
                break
            }
        } //для проверки, что столбцы начала таблицы "подходят" под условия "ok".
        flag := getValueOfFlag(len(ar2), 0, "ok", arString)
        if flag && ind != -1 {
            for j := 0; j < ind; j++ {
                if arString[0][j] == " " { //происходит маркировка ячеек в начале таблицы arString как "a".
                    arString[0][j] = "a" //Пометка "a" происходит только в тех столбцах, где ранее была пустая ячейка
                } else {
                    break
                }
            }
        }
    }

    // для a, которые будут в конце
    if len(ar2) != 0 { //Флаг устанавливается в результате вызова функции getValueOfFlag
        flag := getValueOfFlag(len(ar2), len(ar1)-1, "ok", arString)
        if flag {
            for j := len(ar2)-1; j >= 0; j-- { //цикл по элементам массива ar2 в обратном порядке.
                if arString[len(ar1)-1][j] == " " {  // проверяется, содержит ли элемент строки символ пробела.
                    flag = getValueOfFlagReverse(len(ar1), j, " ", arString) //Если символ равен пробелу, то вызывается функция getValueOfFlagReverse
                    if !flag { //если флаг не установлен
                        arString[len(ar1)-1][j] = "a" //символ в строке arString заменяется на символ 'a'.
                    }
                } else {
                    break
                }
            }
        }
    }
    return arString
}

// получение добавленных строк в начало для а
func getBeginAddedString(ar1 []string, ar2 []string, arString [][]string) map[string] string { 
    str := ""
    count := 0
    for j := 0; j < len(ar2); j++ { //проходим по всем элементам массива ar2
        if arString[0][j] == "a" { //если первый символ в соответствующем столбце строки arString равен символу 'a', то:
            str += "> " + ar2[j] + "\n" //К текущей строке str добавляется новая строка с символом '>', содержащая значение текущего элемента массива ar2.
            count += 1
        } else {
            break
        }
    }
    answer := map[string] string {} //пустой словарь типа map[string]string, содержит инфу о добавленных строках.
    if str != "" { //сли строка str не пустая (то есть были добавлены строки)
        answer[strconv.Itoa(0) + "a" + strconv.Itoa(1) + "," + strconv.Itoa(count)] = str
    } //создается запись в словаре answer с ключом в формате 0a1,количество,где 0a1 указывает на начало строки, количество добавленных строк
    return answer //значением этой записи становится строка str с добавленными строками.
}

// получение добавленных строк в конец для а (по аналогии с предыдущим методом)
func getEndAddedString(ar1 []string, ar2 []string, arString [][]string) map[string] string {
    str := ""
    ind := -1
    count := 0
    for j := 0; j < len(ar2); j++ {
        if arString[len(ar1)-1][j] == "a" {
            str += "> " + ar2[j] + "\n"
            ind = j
            count += 1
        }
    }
    answer := map[string] string {}
    if str != "" {
        answer[strconv.Itoa(len(ar1)) + "a" + strconv.Itoa(ind-count+2) + "," + strconv.Itoa(ind+1)] = str
    }
    return answer
}

// проход по таблице 
func getResultForC(ar1 []string, ar2 []string, what string, sign string, arString [][]string) (map[string] string, []string) {
    result := map[string] string {} //словарь для хранения результата
    ind := 0 //индекс
    startInd := 0 //начальный индекс
    str := ""
    keys := []string {} //массив для хранения ключей результата
    for i := 0; i < len(ar1); i++ {
        flag := false 
        if sign == "<" {
            flag = getValueOfFlag(len(ar2), i, what, arString)
        } else {
            flag = getValueOfFlagReverse(len(ar2), i, what, arString)
        }
        if !flag { //Если разница между текущим индексом i и предыдущим ind равна 1 или 0,
            if i - ind == 1 || i - ind == 0 {
                if str == "" { 
                    startInd = i+1 //при начале новой последовательности элементов, когда предыдущая строка была завершена.
                }
                str += sign + " " + ar1[i] + "\n" //к строке str добавляется текст согласно условию
            } else if i - ind > 1 { //последовательность элементов нарушена
                if str != "" { //Если str не пустая (предыдущая строка была заполнена)
                    if str[len(str)-3] == sign[0] { //последний символ str, и если он равен символу sign[0]
                        str = str[:len(str)-4] + "\n" //происходит удаление последних символов строки для корректного формирования следующей строки
                        ind--
                    } //Добавляется ключ в массив keys, соответствующий предыдущей последовательности элементов.
                    keys = append(keys, strconv.Itoa(startInd) + "," + strconv.Itoa(ind+1))
                    if sign == "<" {
                        str = str + "...\n"
                    } //Формируется строка для предыдущей последовательности и добавляется в result с соответствующим ключом.
                    result[strconv.Itoa(startInd) + "," + strconv.Itoa(ind+1)] = str
                }
                startInd = i+1 //так как начинается новая последовательность элементов.
                str = sign + " " + ar1[i] + "\n" //Формируется новая строка str для текущего элемента массива ar1
            }
            ind = i // позволяет отслеживать последний индекс обработанной строки для следующей итерации.
        }
    }
    if str != "" && startInd != 0 { // добавляется ключ, указывающий на диапазон индексов строк
        keys = append(keys, strconv.Itoa(startInd) + "," + strconv.Itoa(ind+1)) //где происходила последняя обработка
        if sign == "<" {
            str = str + "...\n"
        } //запись в словаре result, где ключ представляет собой диапазон индексов, а значение - обработанная строка str
        result[strconv.Itoa(startInd) + "," + strconv.Itoa(ind+1)] = str
    } else if str != "" && startInd == 0 {
        keys = append(keys, strconv.Itoa(startInd)) //Добавляется ключ в массив keys, равный нулю
        if sign == "<" {
            str = str + "...\n"
        }
        result[strconv.Itoa(startInd)] = str
    }
    return result, keys
}

func getVal(key string) string {
    val := key
    splitKey := strings.Split(key, ",") //разбиваем ключ на части при помощи запятой
    if len(splitKey) > 1 && splitKey[0] == splitKey[1] { //splitKey больше 1 и первый элемент splitKey равен второму элементу
        conv, _ := strconv.Atoi(splitKey[0]) //попытка преобразования первой части ключа в число с помощью atoi
        val = strconv.Itoa(conv) //Значение переменной val обновляется, становясь строковым представлением числа conv.
    }
    return val
}

func getC(ar1 []string, ar2 []string, arString [][]string) map[string] string {
    localResult1, keys1 := getResultForC(ar1, ar2, "ok", "<", arString)
    localResult2, keys2 := getResultForC(ar2, ar1, " ", ">", arString)
    result := map[string] string {} //пустой словарь result, который будет содержать результат сравнения строк.
    if len(keys1) == len(keys2) { //если длины массивов keys1 и keys2 (полученных из getResultForC) равны, то для каждой пары ключей
        for i := 0; i < len(keys1); i++ {
            val1 := getVal(keys1[i]) //Ключи обрабатываются с помощью функции getVal
            val2 := getVal(keys2[i]) //чтобы получить единые значения для использования в новом словаре result.
            result[val1 + "c" + val2] = localResult1[keys1[i]] + localResult2[keys2[i]] //Для каждой пары ключей формируется новая запись в словаре 
        }
    } else {
        for i := 0; i < len(keys1); i++ {
            splitKey := strings.Split(keys1[i], ",") //Ключ разбивается на части
            conv, _ := strconv.Atoi(splitKey[0])
            if len(splitKey) > 1 && splitKey[0] == splitKey[1] {
                result[strconv.Itoa(conv) + "d" + strconv.Itoa(conv-1)] = localResult1[keys1[i]][:len(localResult2[keys1[i]])-4]
            } else { //из первой строки (localResult1) удаляется последние 4 символа и формируется запись в словаре result.
                result[keys1[i] + "d" + strconv.Itoa(conv-1)] = localResult1[keys1[i]][:len(localResult1[keys1[i]])-4]
            } //Если условие выше не выполняется, создается запись, соответствующая первой строке с удалением последних 4 символов.
        }
    }
    return result
}

func sort(dict map[string] string) []string{ //сортировка ключей словаря dict
    keys := []string {} //пустой словарь keys для хранения ключей словаря dict 
    for key := range dict { //добавляем каждый ключ в словарь
        keys = append(keys, key)
    }
    for i := 0; i < len(keys)-1; i++ {
        for j := 0; j < len(keys)-1-i; j++ { //методом пузырька сортируем ключи
            key1, _ := strconv.Atoi(strings.Split(strings.Split(keys[j], "c")[0], ",")[0])
            key2, _ := strconv.Atoi(strings.Split(strings.Split(keys[j+1], "c")[0], ",")[0])
            if key1 > key2 {//Если значение первого ключа (key1) больше значения второго ключа (key2), ключи меняются местами.
                keys[j], keys[j+1] = keys[j+1], keys[j]
            }
        }
    }
    return keys
}

func main() {
    values1, err1 := getTextFromFile(os.Args[1])
	if err1 != nil { //считываем названия файлов из консоли
        fmt.Println(err1)
        return
    }
    values2, err2 := getTextFromFile(os.Args[2])
    if err2 != nil {
        fmt.Println(err2)
        return
    }
    flag := ""
    if len(os.Args) == 4 {
        flag = os.Args[3]
    }
	ar1 := strings.Split(values1, "\n") //Переменные ar1 и ar2 инициализируются путем разделения данных из файлов values1 и values2
    ar1 = ar1[:len(ar1)-1]
    ar2 := strings.Split(values2, "\n")
    ar2 = ar2[:len(ar2)-1] //затем убирается последний элемент поскольку он пуст
    arString := getTable(ar1, ar2, flag) //для получения таблицы различий между массивами ar1 и ar2 с учетом переданного флага.
    beginAddedStrings := getBeginAddedString(ar1, ar2, arString) //вызывается для получения добавленных строк в начало.
    endAddedStrings := getEndAddedString(ar1, ar2, arString) //вызывается для получения добавленных строк в конец.
    changedStrings := getC(ar1, ar2, arString) //для получения информации о строках, которые были изменены.
    for key := range beginAddedStrings { //проходимся по ключам словаря beginAdddStrings
        fmt.Print(key + "\n") //выводим ключ
        fmt.Print(beginAddedStrings[key]) //выводим значение связанное с этим ключом
    }
    keys := sort(changedStrings) //сортируем ключи
    for _, key := range keys {
        fmt.Print(key + "\n")
        fmt.Print(changedStrings[key])
    }
    for key := range endAddedStrings {
        fmt.Print(key + "\n")
        fmt.Print(endAddedStrings[key])
    }
}