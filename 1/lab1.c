#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "lab1.h"

keyvalue* create_kv(void* value, char* key, int type, int size)
{
    keyvalue* new_kv;
    new_kv = (keyvalue*)malloc(sizeof(keyvalue));
    new_kv->key=(char*)malloc(sizeof(char)*(strlen(key)+1));
    new_kv->value=malloc(size);
    new_kv->type=type;
    new_kv->size=size;
    memcpy(new_kv->value,value,size);
    memcpy(new_kv->key,key,sizeof(char)*(strlen(key)+1));
    return new_kv;
}

void destroy_kv(keyvalue* kv)
{
    free(kv->value);
    free(kv->key);
    free(kv);
}

dictionary* create_dict()
{
    dictionary* dict_p;
    dict_p=(dictionary*)malloc(sizeof(dictionary));
    dict_p->size=0;
    dict_p->elements=(keyvalue*)malloc(sizeof(keyvalue));
    return dict_p;
}

void destroy_dict(dictionary* dict_p){
    for(int i = 0; i < dict_p->size; i++){
        remove_element(dict_p, dict_p->elements[i].key);
    }
    free(dict_p->elements); //чистим память для элементов
    free(dict_p); //чистим память для словаря
}

void add_element(dictionary* dict_p, keyvalue* kv)
{
    int check = find_element(dict_p, kv->key);
    if (check != -1){
        remove_element(dict_p, kv->key);
    }
    dict_p->size++;
    dict_p->elements = realloc(dict_p->elements, sizeof(keyvalue)*dict_p->size);
    dict_p->elements[dict_p->size-1] = *kv;
}

void remove_element(dictionary* dict_p, char* key){
    if (dict_p->size != 0){
        int pos = find_element(dict_p, key);
        if(pos != -1){
            dict_p->elements[pos] = dict_p->elements[dict_p->size-1];
            dict_p->size--;
            dict_p->elements = realloc(dict_p->elements, sizeof(keyvalue)*dict_p->size);
        }
        else{
            printf("Your key does not exist in dictionary\n");
        }
    }
    else{
        printf("Dictionary is empty\n");
    }
}

int find_element(dictionary* dict_p, char* key)
{
    int pos = -1;
    if (dict_p->size != 0)
    {
        for(int i = 0; i < dict_p->size; i++)
        {
            if(strcmp(dict_p->elements[i].key, key) == 0)
            {
                pos = i;
            }
        }
    }
    return pos;
}

void print_keys(dictionary* dict_p){
    if (dict_p->size == 0){
        printf("Dictionary is empty\n");
    }
    else{
        for (int i = 0; i < dict_p->size; i++){
            if (dict_p->elements[i].type == 1){
                printf("%d key - [%s] = %d\n", i, dict_p->elements[i].key, *(int*)dict_p->elements[i].value);
            }
            if (dict_p->elements[i].type == 2){
                printf("%d key - [%s] = %s\n", i, dict_p->elements[i].key, (char*)dict_p->elements[i].value);
            }
            if (dict_p->elements[i].type == 3){
                printf("%d key - [%s] = %lf\n", i, dict_p->elements[i].key, *(double*)dict_p->elements[i].value);
            }
        }
    }
}

void print_element(dictionary* dict_p, char* key)
{
    int check = find_element(dict_p,key);
    if(check != -1)
    {
        keyvalue element_info = dict_p->elements[check];
        if (element_info.type == 1){
            printf("Your value is %d\n", *(int*)element_info.value);
        }
        if (element_info.type == 2){
            printf("Your value is %s\n",(char*)element_info.value);
        }
        if (element_info.type == 3){
            printf("Your value is %lf\n", *(double*)element_info.value);
        }
    }
    else{
        printf("Your key doesnt exist -> element appsend\n");
    }
}