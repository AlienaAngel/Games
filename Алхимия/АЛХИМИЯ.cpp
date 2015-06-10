#include <stdio.h>
#include <conio.h>
#include <iostream>
#include <stdlib.h>

const int c=5;
struct alch
{
    int ID;
    int UID;
    char name[25];
    int type;
};

const int n=288, lo=14;
alch base[n];
alch usbase[n];
int combase[n][n], id=1, kol=0;
float progr=0;
char types[lo][30];

void outp(int k)
{
     int i;
      printf("%s\n",types[0]);
      for(i=0;i<k;i++)
      {
           printf("%2d %s\n", usbase[i].UID, usbase[i].name);
           if(usbase[i].type<usbase[i+1].type && usbase[i+1].UID>0)
           {
               printf("\n%s\n",types[usbase[i+1].type-1]);
           }
      }
}

/*int elem_cmp(const void *a, const void *b)
{
    alch *x = (alch *)a;
	alch *y = (alch *)b;
    return(strcmp(x->name, y->name));
}*/

int elem_cmp(const void *a, const void *b)
{
    short t=0;
    alch *x = (alch *)a;
	alch *y = (alch *)b;
	if(x->type > y->type) t=1;
	if(x->type < y->type) t=-1;
	return(t);
}
main()
{
      int game(int cm1, int cm2);
      setlocale (LC_ALL,"Russian");
      int i=0, j=0, cm1, cm2, tomenu, flag=0, qw=0;
      FILE *f;
      char fn[15];
      f=fopen("albase.txt","r");
      for(i=0;i<n;i++)
      {
          fscanf(f,"%d%s%d",&base[i].ID, &base[i].name, &base[i].type);
          base[i].UID=0;
          
      }
      fclose(f);
      f=fopen("typebase.txt","r");
      for(i=0;i<lo;i++)
      {
          fscanf(f,"%s",&types[i]);
      }
      fclose(f);
      
      /*for(i=0;i<n;i++)
      {
           printf("%2d %2d %15s ",base[i].ID, base[i].UID, base[i].name);
           printf("\n");
      }*/

      int menu1, exit1=0;
      char buf[2];
      setlocale(LC_ALL, "Russian");
      while(exit1==0)
      {
           system("cls");
           puts("");
           puts("       ~~..++НЕДОАЛХИМИЯ++..~~");
           puts("        _____________________");
           puts("       |  ++Главное Меню++   |");
           puts("       |_____________________|");
           puts("       |1|Новая Игра         |");
           puts("       |_____________________|");
           puts("       |2|Загрузить          |");
           puts("       |_____________________|");
           puts("       |3|Сохранить          |");
           puts("       |_____________________|");
           puts("       |4|Прогресс и         |");
           puts("       |  АЧИВКИ :D          |");
           puts("       |_____________________|");
           puts("       |5|Продолжить игру    |");
           puts("       |_____________________|");
           puts("       |6|Выход              |");
           puts("       |_____________________|");
           do
           {
               scanf("%s",&buf);
               menu1=atoi(buf);
           }while(!menu1);
           switch(menu1)
           {
                case 1:
                     {
                         tomenu=0, kol=0;
                         f=fopen("combase.txt","r");
                         for(i=0;i<n;i++)
                         {
                             for(j=0;j<n;j++)
                             {
                                 fscanf(f,"%d",&combase[i][j]);
                             }
                         }
                         fclose(f);
                         id=1;
                         for(i=0;i<4;i++)
                         {
                             usbase[i]=base[i];
                             usbase[i].UID=id;
                             kol++;
                             id++;
                         }
                         system("cls");
                         puts("У вас есть 4 элемента, комбинируйте их и получайте новые");
                         qsort((void *)usbase, kol, sizeof(alch), elem_cmp);
                         outp(kol);
                         while(tomenu==0)
                         {
                             puts("Введите номера комбинируемых элементов или два раза -1 для выхода в главное меню");
                             scanf("%d%d",&cm1,&cm2);
                             tomenu=game(cm1,cm2);
                         }
                     }
                  break;
                case 2:
                     system("cls");
                     puts("Введите имя файла, который загрузить");
                     fflush(stdin);
                     gets(fn);
                     f=fopen(fn,"r");
                     qw=0;
                     if(f)  qw=1;
                     else
                     {
                         puts("Файл не найден");
                         getch();
                         system("cls");
                     }
                     if(qw==1)
                     {
                          fscanf(f,"%d",&kol);
                          printf("SYSYEM: kol=%d\n",kol);
                          for(i=0;i<kol;i++)
                          {
                              fscanf(f,"%d %d %s",&usbase[i].ID, &usbase[i].UID, &usbase[i].name);
                          }
                          for(i=0;i<n;i++)
                          {
                              for(j=0;j<n;j++)
                              {
                                  fscanf(f,"%d",&combase[i][j]);
                              }
                          }
                          tomenu=0;
                          system("cls");
                          puts("Игра успешно загружена.");
                          qsort((void *)usbase, kol, sizeof(alch), elem_cmp);
                          outp(kol);
                          while(tomenu==0)
                          {
                              id=kol+1;
                              puts("Введите номера комбинируемых элементов или два раза -1 для выхода в главное меню");
                              scanf("%d%d",&cm1,&cm2);
                              tomenu=game(cm1,cm2);
                          }
                     }
                  break;
                case 3:
                     system("cls");
                     puts("Введите имя файла, в который сохранить");
                     fflush(stdin);
                     gets(fn);
                     f=fopen(fn,"w");
                     fprintf(f,"%d\n",kol);
                     for(i=0;i<kol;i++)
                     {
                         fprintf(f,"%d %d %s",usbase[i].ID, usbase[i].UID, usbase[i].name);
                         fprintf(f,"\n");
                     }
                     for(i=0;i<n;i++)
                     {
                         for(j=0;j<n;j++)
                         {
                             fprintf(f,"%2d",combase[i][j]);
                             if(j!=n-1);
                                 fprintf(f," ");
                         }
                         if(i!=n-1) fprintf(f,"\n");
                     }
                  break;
                case 4:
                     {
                         float m=n;
                         progr=(kol/m)*100;
                         system("cls");
                         puts("Прогресс и достижения");
                         printf("|");
                         for(i=0;i<progr/2;i++)
                         {
                             printf("|");
                         }
                         for(i=0;i<50-progr;i++)
                         {
                             printf(" ");
                         }
                         printf("|\n");
                         printf("   %.1f %% (%d/%.0f)",progr, kol, m);
                         getch();
                     }
                     break;
                  case 5:
                    {
                        system("cls");
                        qsort((void *)usbase, kol, sizeof(alch), elem_cmp);
                        outp(kol);
                        tomenu=0;
                        while(tomenu==0)
                        {
                            id=kol+1;
                            puts("Введите номера комбинируемых элементов или два раза -1 для выхода в главное меню");
                            scanf("%d%d",&cm1,&cm2);
                            tomenu=game(cm1,cm2);
                        }
                    }
                  break;
                case 6:
                  exit1=1;
                  break;
                /*case 7:
                  f=fopen("mmm.txt","w");
                  for(i=0;i<n;i++)
                     {
                         for(j=0;j<n;j++)
                         {
                             fprintf(f,"%4d",combase[i][j]);
                             if(j!=n-1);
                                 fprintf(f," ");
                         }
                         if(i!=n-1) fprintf(f,"\n");
                     }
                     fclose(f);
                  break;*/
           }
      }
      return(0);
}




int game(int cm1, int cm2)
{
    int tomenu=0, i, j, flag, fl, fl2=0, fl3=0;
    if(cm1!=-1 && cm2!=-1)
    {
        fl=0;
        if(cm1==cm2) fl=1;
        for(i=0;i<kol ;i++)
        {
            if(usbase[i].UID==cm1 && fl3!=1)
            {
                if(fl==1) cm2=usbase[i].ID;
                cm1=usbase[i].ID;
                //printf("SYSTEM: %d\n",cm1);
                //printf("SYSTEM1: %s\n",usbase[i].name);
                fl3=1;
            }
            if(usbase[i].UID==cm2 && fl!=1 && fl2!=1)
            {
                cm2=usbase[i].ID;
                //printf("SYSTEM: %d\n",cm2);
                //printf("SYSTEM2: %s\n",usbase[i].name);
                fl2=1;
            }
        }
       // printf("SYSTEM: %d %d\n",cm1,cm2);
        //printf("SYSTEM: %d\n",combase[cm1][cm2]);
        flag=0;
        for(i=0;i<n;i++)
        {
            //printf("SYSTEM1: %d\n", base[i].ID);        
            if(base[i].ID==combase[cm1][cm2])
            {
                flag=1;
                usbase[kol]=base[i];
                usbase[kol].UID=id;
                id++;
                kol++;
                combase[cm1][cm2]=combase[cm2][cm1]=-1;
                system("cls");
                printf("Вы получили новый элемент! %s(%d)!\n" ,usbase[kol-1].name, id-1);
                //printf("SYSTEM: %d\n",usbase[kol-1].ID);
                qsort((void *)usbase, kol, sizeof(alch), elem_cmp);
                outp(kol);
            }
        }
        if(flag==0)
        {
             system("cls");
             puts("Не удалось скомбинировать.");
             outp(kol);
        }
    }
    else
    {
        if(cm1==-1 && cm2==-1)
            tomenu=1;
        else
        {
        //printf("SYSTEM: %d\n",combase[cm1][cm2]);
            system("cls");
            puts("Не удалось скомбинировать");
            outp(kol);
        }
    }
    return(tomenu);
}
