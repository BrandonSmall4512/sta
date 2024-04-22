#ifndef LAB1_LAB1_H
#define LAB1_LAB1_H

//структура ключ - значение
typedef struct keyvalue
{
    char* key;
    void* value;
    int type; //1-целочисленный 2-строковый 3-вещественный
    int size;
}keyvalue;

typedef struct dictionary{ //структура словарь
    keyvalue* elements;
    int size;
}dictionary;

keyvalue* create_kv(void*value, char* key, int type, int size);

void destroy_kv(keyvalue* kv);

dictionary* create_dict();

void destroy_dict(dictionary* dict_p);

void add_element(dictionary* dict_p, keyvalue* kv);

void remove_element(dictionary* dict_p, char* key);

int find_element(dictionary* dict_p, char* key);

void print_keys(dictionary* dict_p);

void print_element(dictionary* dict_p, char* key);


#endif //LAB1_LAB1_H
