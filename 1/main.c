#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "lab1.h"

int main()
{
    void* value;
    int type, size;
    char* key;
    dictionary* dict_p;
    keyvalue* kv;
    dict_p = create_dict();
    while(1)
    {
        printf("\n");
        int action;
        printf("What do you want to do?\nType next line an argument of this list:\n1-add element\n2-delete element\n3-print keys\n4-find element for key\n5-finish program\n");
        scanf("%d", &action);
        printf("Action:%d\n", action);
        if(action == 1)
        {
            key = (char*)malloc(sizeof(char*));
            printf("Enter the key:");
            scanf("%s", key);
            printf("Enter type of value: 1 - int, 2 - string, 3 - double\n");
            scanf("%d", &type);
            if(type == 1)
            {
                printf("Enter your value:");
                scanf("%d", &value);
                size = sizeof(value);
                kv = create_kv(&value, key, type, size);
                add_element(dict_p, kv);
            }
            else if(type == 2){
                value = (char*)malloc(sizeof(char*));
                printf("Enter your value: ");
                scanf("%s", value);
                size = sizeof(char)*(strlen(value)+1);
                kv = create_kv(value, key, type, size);
                add_element(dict_p, kv);
            }
            else if(type == 3){
                printf("Enter your value: ");
                scanf("%lf", &value);
                size = sizeof(value);
                kv = create_kv(&value, key, type, size);
                add_element(dict_p, kv);
            }
        }
        if(action == 2)
        {
            key = (char*)malloc(sizeof(char));
            printf("Enter the key that u want to remove: ");
            scanf("%s", key);
            remove_element(dict_p, key);
        }
        if(action == 3)
        {
            print_keys(dict_p);
        }
        if(action == 4)
        {
            key = (char*)malloc(sizeof(char));
            printf("Enter the key: ");
            scanf("%s", key);
            print_element(dict_p, key);
            free(key);
        }
        if(action == 5)
        {
            destroy_dict(dict_p);
            break;
        }
    }
    return 0;
}
